using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class Program
    {


        public class Player
        {
            public string name;
            public char move;

            public Player(string n, char m)
            {
                name = n;
                move = m;
            }
        }


        public class Game
        {
            public Player first;
            public Player second;

            public Game(Player p1, Player p2)
            {
                first = p1;
                second = p2;
            }
        }

        public static Player rps_game_winner (Game game)
        {
            if (game.first is Nullable || game.second is Nullable)
                throw new WrongNumberOfPlayersError();
             
            switch (Char.ToUpper(game.first.move))
            {
                case 'R':
                    switch (Char.ToUpper(game.second.move))
                    {
                        case 'R': return game.first;
                        case 'P': return game.second;
                        case 'S': return game.first;
                        default: throw new NoSuchStrategyError(game.second);
                    }                       
                case 'P':
                    switch (Char.ToUpper(game.second.move))
                    {
                        case 'P': return game.first;
                        case 'R': return game.first;
                        case 'S': return game.second;
                        default: throw new NoSuchStrategyError(game.second);
                    }
                case 'S':
                    switch (Char.ToUpper(game.second.move))
                    {
                        case 'S': return game.first;
                        case 'R': return game.second;
                        case 'P': return game.first;
                        default: throw new NoSuchStrategyError(game.second);
                    }
                default: throw new NoSuchStrategyError(game.first);
            }

        }

        public class WrongNumberOfPlayersError : System.Exception
        {
            public WrongNumberOfPlayersError() : base() {
                Console.WriteLine("Wrong number of players.");
            }
        }

        public class NoSuchStrategyError : System.Exception
        {
            public NoSuchStrategyError(Player p)
                : base()
            {
                Console.WriteLine("Invalid player \'"+ p.name +"\' strategy");
            }
        }

        static void Main(string[] args)
        {

            Player Armando = new Player("Armando",'P');
            Player Dave = new Player("Dave",'S');
            Player Richard = new Player("Richard",'R');
            Player Michael = new Player("Michael",'S');
            Player Allen = new Player("Allen",'S');
            Player Omer = new Player("Omer",'P');
            Player DavidE = new Player("David E.",'R');
            Player RichardX = new Player("Richard X.",'P');

            Game A1 = new Game(Armando, Dave);
            Game A2 = new Game(Richard, Michael);
            Game B1 = new Game(Allen, Omer);
            Game B2 = new Game(DavidE, RichardX);

            Game C1 = new Game(rps_game_winner(A1), rps_game_winner(A2));
            Game C2 = new Game(rps_game_winner(B1), rps_game_winner(B2));

            Game Final = new Game(rps_game_winner(C1), rps_game_winner(C2));

            Player Winner = rps_game_winner(Final);

            Console.WriteLine(Winner.name + " Winner");
            Console.ReadKey();
        }
    }
}
