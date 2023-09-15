using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
        public class Team
        {
            public List<Player> Players { get; } = new List<Player>(); //list s igrokami
            public string Name { get; private set; }
            public Game Game { get; set; } //element klassa game

            public Team(string name) //konstruktor klassa
            {
                Name = name;
            }

            //fuc kotoraya nachinayet igru i randomno rozstavlyaet igrokov po polyu
            public void StartGame(int width, int height)
            {
                Random rnd = new Random();
                foreach (var player in Players)
                {
                    player.SetPosition(
                        rnd.NextDouble() * width,
                        rnd.NextDouble() * height
                        );
                }
            }

            //dobavlenie v komandu
            public void AddPlayer(Player player)
            {
                if (player.Team != null) return;
                Players.Add(player);
                player.Team = this;
            }

            public (double, double) GetBallPosition() //gets coordinates
            {
                return Game.GetBallPositionForTeam(this);
            }

            public void SetBallSpeed(double vx, double vy) //ustanavlivaet skorost myacha
        {
                Game.SetBallSpeedForTeam(this, vx, vy);
            }

            public Player GetClosestPlayerToBall() //perebiraet znacheniya rasstoyaniya igrokov k myachu
            {
                Player closestPlayer = Players[0];
                double bestDistance = Double.MaxValue;
                foreach (var player in Players)
                {
                    var distance = player.GetDistanceToBall();
                    if (distance < bestDistance)
                    {
                        closestPlayer = player;
                        bestDistance = distance;
                    }
                }

                return closestPlayer;
            }

            public void Move() //vse igroki dvigayutsya k myachu
        {
                GetClosestPlayerToBall().MoveTowardsBall();
                Players.ForEach(player => player.Move());
            }
        }
    
}
