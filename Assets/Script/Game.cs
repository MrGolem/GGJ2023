using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
   //1. Телепортуємося до стартової позиції показуючи усю мапу
   //2. Стейти мапа: бросок кубика ,рух на мапі, отримання результату. 
   //3. бросок кубика : Логіка : Рандом від 1 до 6. додаємо значення кубіку до группи  графіка : додати 3 д куб, Анімувати падіння, 
   //4. рух на мапі : дивимося значення кубику. вибираємо точку робимо шлях. Малювати шлях.
   //5. Отримання результату : со з від 1 до 6 з % що може випасти. Відкриваємо окно діалогу. К діям прикріпленні кнопки

   public static Dice Dice;

   public static Player Player;

   public static FightData FightData;

   private LoopStateMachine _loopStateMachine;

   private static Game Instance;

   public static bool BattleIsOver = false;

   [SerializeField]
   private PlayerMap _playerOnMap;
   [SerializeField]
   private CharacterStatsConfig _characterStatsConfig;

   private void Awake() {
      if (Instance == null) {
         Instance = this;
         DontDestroyOnLoad(gameObject);
      } else {
         Destroy(gameObject);
         return;
      }
      
      InitParams();
      InitGame();
      
      SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
      Events.Fight.StartFight += StartFight;
   }

   private void SceneManagerOnsceneLoaded (Scene arg0, LoadSceneMode arg1) {
      if (arg0.name == "MainMenu") {
         Instance = null;
         Destroy(gameObject);
      }
   }

   private void OnDestroy() {
      Events.Fight.StartFight -= StartFight;
      SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
   }

   private void StartFight (Character character) {
      FightData._enemyCharacter = character;
      SceneManager.LoadSceneAsync("BattleScene");
   }

   private void InitParams() {
      Dice = new Dice();
      Player = new Player(_characterStatsConfig);
      FightData = new FightData();
      FightData._playerCharacter = Player.CharacterStats;

      _loopStateMachine = new LoopStateMachine();
   }

   private void InitGame() {
      Events.StateControllerEvent.StartState?.Invoke(GameStateEnum.Wait);
   }
}
public class FightData {
   public Character _enemyCharacter;
   public Character _playerCharacter;
   public Character _assistantCharacter;
}
