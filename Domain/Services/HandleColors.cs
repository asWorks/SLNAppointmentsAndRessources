using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Domain.Services
{
    public class HandleColors
    {
        public static SolidColorBrush GetTerminBackground(Enums.TerminBackground color)
        {
            SolidColorBrush bg;
            switch (color)
            {
                case Enums.TerminBackground.White:
                    bg= new SolidColorBrush(Colors.White);
                    break;
                case Enums.TerminBackground.Yellow:
                    bg = new SolidColorBrush(Colors.Yellow);
                    break;
                case Enums.TerminBackground.Orange:
                    bg = new SolidColorBrush(Colors.Orange);
                    break;
                case Enums.TerminBackground.LightBlue:
                    bg = new SolidColorBrush(Colors.LightBlue);
                    break;
                case Enums.TerminBackground.LightGrey:
                    bg = new SolidColorBrush(Colors.LightGray);
                    break;
                default:
                    bg = new SolidColorBrush(Colors.Gold);
                    break;
            }

            return bg;
            

        }
    }
}
