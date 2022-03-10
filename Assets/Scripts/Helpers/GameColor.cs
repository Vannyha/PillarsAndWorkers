using System.Collections.Generic;
using System.Drawing;

namespace Helpers
{
    public static class ColorHelper
    {
        public static Dictionary<GameColor, Color> GameColorToRGB = new Dictionary<GameColor, Color>
        {
            {GameColor.None, Color.White},
            {GameColor.Red, Color.Red},
            {GameColor.Green, Color.Green},
            {GameColor.Blue, Color.Blue},
        };
        
        public static Color GetRGBFromGameColor(GameColor color)
        {
            return GameColorToRGB[color];
        }
    }
    public enum GameColor
    {
        None = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
    }
}