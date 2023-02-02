using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
   //1. Телепортуємося до стартової позиції показуючи усю мапу
   //2. Стейти мапа: бросок кубика ,рух на мапі, отримання результату. 
   //3. бросок кубика : Логіка : Рандом від 1 до 6. додаємо значення кубіку до группи  графіка : додати 3 д куб, Анімувати падіння, 
   //4. рух на мапі : дивимося значення кубику. вибираємо точку робимо шлях. Малювати шлях.
   //5. Отримання результату : со з від 1 до 6 з % що може випасти. Відкриваємо окно діалогу. К діям прикріпленні кнопки

   public static Dice Dice;

   public static Player Player;
   

   [SerializeField]
   private PlayerMap _playerOnMap;

   private void Awake() {
      InitParams();
      InitGame();
   }

   private void InitParams() {
      Dice = new Dice();
      Player = new Player();
   }

   private void InitGame() {
      Events.StateControllerEvent.StartState?.Invoke(GameStateEnum.Wait);
   }
}
