using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_and_Multicast_Delegates
{
    public class GameEventManager
    {
        //a new delegate type called GameEvent
        public delegate void GameEvent();
        //create two delegates variables calll OnGameStart and OnGameOver
        public static event GameEvent OnGameStart, OnGameOver;

        public static void TriggerGameStart()
        {
            //check if the OngameStart event is not empty,
            //meaning that other methods already subscribe to it
            if (OnGameStart != null)
            {
                //print a simple message 
                Console.WriteLine("The game has started....");
                //call the OnGameStart that will trigger all the methods subscribed to this events
                OnGameStart();
            }
        }

        //a static method to trigger OnGameOver
        public static void TriggerGameOver()
        {
            //check if the OnGameOver event is not empty
            //meaning that other methods already subscribe to it
            if (OnGameOver != null)
            {
                //print a simple message 
                Console.WriteLine("The game has over....");
                //call the OnGameStart that will trigger all the methods subscribed to this events
                OnGameOver();
            }
        }
    }
}
