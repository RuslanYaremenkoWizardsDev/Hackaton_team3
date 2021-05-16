using System;
using System.Collections.Generic;
using System.Text;

namespace Hackaton_team3
{
    public class Layers
    {
        private int _horisontal;
        private int _vertical;
        public int Horisontal
        {
            get
            {
                return _horisontal;
            }
            set
            {
                _horisontal = value > 0 ? value : 1;
            }
        }
        public int Vertical
        {
            get
            {
                return _vertical;
            }
            set
            {
                _vertical = value > 0 ? value : 1;
            }
        }

        public Layers(int width, int height)
        {
            Horisontal = width;
            Vertical = height;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{Horisontal},{Vertical}");

            return result.ToString();
        }
    }
}
