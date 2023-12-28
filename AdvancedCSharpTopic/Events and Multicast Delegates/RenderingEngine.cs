using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_and_Multicast_Delegates
{
    //RenderingEngine Class
    public class RenderingEngine
    {
        //simple constructor
        public RenderingEngine()
        {
            //subscribe to the OnGameStart and OnGameOver events
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameOver += GameOver;
        }
        //at the start of the game
        //we want to enable the rendering engine  and start drawing the visuals
        private void StartGame()
        {
            Console.WriteLine("Rendring Engine Started");
            Console.WriteLine("Drawing Visual....");
        }

        //When the game is over, we want to stop our rendering engine
        private void GameOver()
        {
            Console.WriteLine("Rendring Engine Stopped");
        }
    }
}
