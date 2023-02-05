using System.Collections.Generic;
using Unity.VisualScripting;
public class Player {
  public Player (CharacterStatsConfig characterStatsConfig) {
    Path = new List<int>();
    Inventory = new Inventory();
    CharacterStats = new PlayerCharacter(characterStatsConfig);
  }
  
  public List<int> Path;
  public Inventory Inventory;
  public PlayerCharacter CharacterStats ;
}