namespace Events_and_Multicast_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create an audio system
            AudioSystem audioSystem = new AudioSystem();
            //create a rendering engine
            RenderingEngine renderingEngine = new RenderingEngine();
            //create two player and give them Id's
            Player player1 = new Player("StellCow");
            Player player2 = new Player("DoggoSilva");
            Player player3 = new Player("DragonDog");

            GameEventManager.TriggerGameStart();

            Console.WriteLine("Game is Running... Press any key to end the game");

            //Pause
            Console.Read();

            //trigger the GameOver event
            GameEventManager.TriggerGameOver();
        }
    }
}
