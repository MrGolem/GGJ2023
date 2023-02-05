using UnityEngine;
public class Character {
  public CharacterStatsConfig _characterStatsConfig;

  public Character (CharacterStatsConfig characterStatsConfig) {
    _characterStatsConfig = characterStatsConfig;
    CurrentHealth = MaxHealth;
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
    Events.Fight.UpdateStatsUI?.Invoke();
  }

  public void ChangeHealthTo (int value) {
    CurrentHealth = Mathf.Clamp(value, 0, MaxHealth);
    Events.Fight.UpdateStatsUI?.Invoke();

  }
}