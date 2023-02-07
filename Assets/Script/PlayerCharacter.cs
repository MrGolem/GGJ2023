public class PlayerCharacter : Character {
  public override int Armor {
    get {
      if( Game.Player.Inventory.ArmorItem != null)
      return _characterStatsConfig.Armor + Game.Player.Inventory.ArmorItem.Armor;

      return _characterStatsConfig.Armor;
    }
  }

  public override (int, int) Damage {
    get {
      if( Game.Player.Inventory.WeaponItem != null)
      return ((int)_characterStatsConfig.Damage.x + Game.Player.Inventory.WeaponItem.Damage.Item1, (int)_characterStatsConfig.Damage.y +  Game.Player.Inventory.WeaponItem.Damage.Item2);
      
      return ((int)_characterStatsConfig.Damage.x, (int)_characterStatsConfig.Damage.y);
    }
  }

  public PlayerCharacter (CharacterStatsConfig characterStatsConfig) : base(characterStatsConfig) {
  }
}