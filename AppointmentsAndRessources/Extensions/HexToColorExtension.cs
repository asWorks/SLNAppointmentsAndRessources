using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AppointmentsAndRessources.Extensions
{
    
    // From PresentationCore.dll

    public static class HexToColorExtension
    {
        public static Color Rgb(this int hex)
        {
            return Color.FromRgb((byte)(hex >> 16), (byte)(hex >> 8), (byte)(hex >> 0));
        }

        public static Color Argb(this uint hex)
        {
            return Color.FromArgb((byte)(hex >> 24), (byte)(hex >> 16), (byte)(hex >> 8), (byte)(hex >> 0));
        }

        public static Color Argb(this int hex)
        {
            return Color.FromArgb((byte)(hex >> 24), (byte)(hex >> 16), (byte)(hex >> 8), (byte)(hex >> 0));
        }
    }
}
