using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_team3
{
    public class Layers
    {
        private int _horisontal;
        public int Horisontal
        {
            get
            {
                return _horisontal;
            }
            set
            {
                if (value > 0)
                {
                    _horisontal = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int _vertical;
        public int Vertical
        {
            get
            {
                return _horisontal;
            }
            set
            {
                if (value > 0)
                {
                    _vertical = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value");
                }
            }
        }

        public Layers(int width, int height)
        {
            Horisontal = width;
            Vertical = height;
        }

        public override string ToString()
        {

            return $"{_horisontal}, {_vertical}";

        }

    }
}

