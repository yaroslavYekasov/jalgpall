using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Ball
    {
        // X-koordinaat palli asukohale
        public double X { get; private set; }

        // Y-koordinaat palli asukohale
        public double Y { get; private set; }

        // Palli kiirus X- ja Y-suunas
        private double _vx, _vy;

        // Mäng, kus pall asub
        private Game _game;

        // Palli konstruktor, määrates algse asukoha ja mängu
        public Ball(double x, double y, Game game)
        {
            _game = game;
            X = x;
            Y = y;
        }

        // Määra palli kiirus
        public void SetSpeed(double vx, double vy)
        {
            _vx = vx;
            _vy = vy;
        }

        // Liiguta palli vastavalt tema kiirusele
        public void Move()
        {
            double newX = X + _vx;
            double newY = Y + _vy;

            // Kontrolli, kas pall on staadioni sees
            if (_game.Stadium.IsIn(newX, newY))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                // Kui pall jõuab staadioni piiridest välja, siis peatame selle
                _vx = 0;
                _vy = 0;
            }
        }
    }

}
