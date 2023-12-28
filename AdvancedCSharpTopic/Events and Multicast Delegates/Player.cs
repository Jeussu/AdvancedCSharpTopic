using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_and_Multicast_Delegates
{
    //player name
    public class Player
    {
        public string PlayerName { get; set; }
        //simple constructor
        public Player(string name)
        {
            this.PlayerName = name;
            //subscribe to the OngameStart and OnGameOver events
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameOver += GameOver;
            
        }

        //at the start of the game, spawn the player.
        private void StartGame()
        {
            Console.WriteLine($"Spawning player with ID: {PlayerName}");
        }

        //when the game is over, remove the player from the game
        private void GameOver()
        {
            Console.WriteLine($"Removing Player with ID: {PlayerName}");
        }
    }
}
