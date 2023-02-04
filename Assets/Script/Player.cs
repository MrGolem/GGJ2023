using System.Collections.Generic;
using UnityEngine;
public class Player {
  public Player (CharacterStatsConfig characterStatsConfig) {
    Path = new List<int>();
    Inventory = new Inventory();
    CharacterStats = new PlayerCharacter(characterStatsConfig);
  }
  
  public List<int> Path;
  public Inventory Inventory;
  public PlayerCharacter CharacterStats ;
  public int Health;
}

public class PlayerCharacter : Character {
  public override int Armor
    => _characterStatsConfig.Armor + Game.Player.Inventory.ArmorItem.Armor;

  public override (int, int) Damage
    => ((int)_characterStatsConfig.Damage.x + Damage.Item1, (int)_characterStatsConfig.Damage.y + Damage.Item1);

  public PlayerCharacter(CharacterStatsConfig characterStatsConfig) : base(characterStatsConfig) {}
}

public class Character {
  protected CharacterStatsConfig _characterStatsConfig;

  public Character (CharacterStatsConfig characterStatsConfig) {
    _characterStatsConfig = characterStatsConfig;
  }

  public int CurrentHealth;
  public virtual int MaxHealth
    => _characterStatsConfig.Health;

  public virtual int Armor
    => _characterStatsConfig.Armor;
  public virtual (int, int) Damage
    => ((int)_characterStatsConfig.Damage.x, (int)_characterStatsConfig.Damage.y);

  public void ChangeHealthBy (int value) {
    CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, MaxHealth);
  }

  public void ChangeHealthTo (int value) {
    CurrentHealth = Mathf.Clamp(value, 0, MaxHealth);
  }
}

public class CharacterStatsConfig : ScriptableObject {
  public int Health;
  public int Armor;
  public Vector2 Damage;

}