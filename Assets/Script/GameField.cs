using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameField : MonoBehaviour {
  [SerializeField]
  private List<FightInventoryButton> _fightInventoryButtons;

  [SerializeField]
  private CharacterView Player;
  [SerializeField]
  private CharacterView Enemy;
  [SerializeField]
  private CharacterView Assistant;




    public void Awake() {
    Events.Fight.DealDamage += DealDamage;
    Init();


    Events.Fight.PlayerTeamAttack += PlayerTeamAttack;
    Events.Fight.EnemyTeamAttack += EnemyTeamAttack;
  }
  

  private void Init() {
    Player.SetCharacter(Game.FightData._playerCharacter);
    Enemy.SetCharacter(Game.FightData._enemyCharacter);
    
    
    if(Game.FightData._assistantCharacter != null)
      Assistant.SetCharacter(Game.FightData._assistantCharacter);
    
    foreach (var button in _fightInventoryButtons) {
      button.Clear();
    }

    for (int index = 0; index < Game.Player.Inventory.ActionItems.Count; index++) {
      ActionItem actionItem = Game.Player.Inventory.ActionItems[index];
      _fightInventoryButtons[index].Init(actionItem);
    }
  }

  private void PlayerTeamAttack() {
    if (Game.FightData._playerCharacter.CurrentHealth <= 0) {
      Player.Dead();
      var sequence = DOTween.Sequence();
      sequence.AppendInterval(0.75f);
      sequence.OnKill(() => Events.Fight.OpenLoseMenu?.Invoke());
      return;
    }

      Player.OnAttackComplete = () => {
      if (Assistant._characterStatsConfig == null) {
        Events.StateControllerEvent.StartState(GameStateEnum.EnemyTeamAttack);
        return;
      }
    
      Assistant.OnAttackComplete = () => { Events.StateControllerEvent.StartState(GameStateEnum.EnemyTeamAttack); };
      Assistant.DealDamage();
    };
    
    
    Player.DealDamage();
  }

  private void EnemyTeamAttack() {
    if (Game.FightData._enemyCharacter.CurrentHealth <= 0) {
      Enemy.Dead();
      var sequence = DOTween.Sequence();
      sequence.AppendInterval(0.75f);
      sequence.OnKill(() => Events.Fight.OpenWinMenu?.Invoke());
    }
    
    Enemy.OnAttackComplete = () => {
      Events.StateControllerEvent.StartState(GameStateEnum.Wait);
    };
    
    Enemy.DealDamage();
  }

  private void OnDestroy() {
    Events.Fight.DealDamage -= DealDamage;    
    Events.Fight.PlayerTeamAttack -= PlayerTeamAttack;
    Events.Fight.EnemyTeamAttack -= EnemyTeamAttack;


  }

  public void DealDamage (UnitType unitType, int damage) {
    switch (unitType) {
      case UnitType.Player:
        Enemy.GetDamage(damage);
        break;
      case UnitType.Enemy:
        Player.GetDamage(damage);
        break;
      default:
        Enemy.GetDamage(damage);
        break;
    }
  }
}