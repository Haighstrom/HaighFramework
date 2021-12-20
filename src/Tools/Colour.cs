using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;


namespace HaighFramework
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Colour : IEquatable<Colour>
    {
        #region Static
        #region System Colours
        /// <summary>
        /// (255, 255, 255, 0)
        /// </summary>
        public static Colour Transparent => new Colour(255, 255, 255, 0);
        /// <summary>
        /// (240, 248, 255, 255)
        /// </summary>
        public static Colour AliceBlue => new Colour(240, 248, 255, 255);
        /// <summary>
        /// (250, 235, 215, 255)
        /// </summary>
        public static Colour AntiqueWhite => new Colour(250, 235, 215, 255);
        /// <summary>
        /// (0, 255, 255, 255)
        /// </summary>
        public static Colour Aqua => new Colour(0, 255, 255, 255);
        /// <summary>
        /// (127, 255, 212, 255)
        /// </summary>
        public static Colour Aquamarine => new Colour(127, 255, 212, 255);
        /// <summary>
        /// (240, 255, 255, 255)
        /// </summary>
        public static Colour Azure => new Colour(240, 255, 255, 255);
        /// <summary>
        /// (245, 245, 220, 255)
        /// </summary>
        public static Colour Beige => new Colour(245, 245, 220, 255);
        /// <summary>
        /// (255, 228, 196, 255)
        /// </summary>
        public static Colour Bisque => new Colour(255, 228, 196, 255);
        /// <summary>
        /// (0, 0, 0, 255)
        /// </summary>
        public static Colour Black => new Colour(0, 0, 0, 255);
        /// <summary>
        /// (255, 235, 205, 255)
        /// </summary>
        public static Colour BlanchedAlmond => new Colour(255, 235, 205, 255);
        /// <summary>
        /// (0, 0, 255, 255)
        /// </summary>
        public static Colour Blue => new Colour(0, 0, 255, 255);
        /// <summary>
        /// (138, 43, 226, 255)
        /// </summary>
        public static Colour BlueViolet => new Colour(138, 43, 226, 255);
        /// <summary>
        /// (165, 42, 42, 255)
        /// </summary>
        public static Colour Brown => new Colour(165, 42, 42, 255);
        /// <summary>
        /// (222, 184, 135, 255)
        /// </summary>
        public static Colour BurlyWood => new Colour(222, 184, 135, 255);
        /// <summary>
        /// (95, 158, 160, 255)
        /// </summary>
        public static Colour CadetBlue => new Colour(95, 158, 160, 255);
        /// <summary>
        /// (127, 255, 0, 255)
        /// </summary>
        public static Colour Chartreuse => new Colour(127, 255, 0, 255);
        /// <summary>
        /// (210, 105, 30, 255)
        /// </summary>
        public static Colour Chocolate => new Colour(210, 105, 30, 255);
        /// <summary>
        /// (255, 127, 80, 255)
        /// </summary>
        public static Colour Coral => new Colour(255, 127, 80, 255);
        /// <summary>
        /// (100, 149, 237, 255)
        /// </summary>
        public static Colour CornflowerBlue => new Colour(100, 149, 237, 255);
        /// <summary>
        /// (255, 248, 220, 255)
        /// </summary>
        public static Colour Cornsilk => new Colour(255, 248, 220, 255);
        /// <summary>
        /// (220, 20, 60, 255)
        /// </summary>
        public static Colour Crimson => new Colour(220, 20, 60, 255);
        /// <summary>
        /// (0, 255, 255, 255)
        /// </summary>
        public static Colour Cyan => new Colour(0, 255, 255, 255);
        /// <summary>
        /// (0, 0, 139, 255)
        /// </summary>
        public static Colour DarkBlue => new Colour(0, 0, 139, 255);
        /// <summary>
        /// (0, 139, 139, 255)
        /// </summary>
        public static Colour DarkCyan => new Colour(0, 139, 139, 255);
        /// <summary>
        /// (184, 134, 11, 255)
        /// </summary>
        public static Colour DarkGoldenrod => new Colour(184, 134, 11, 255);
        /// <summary>
        /// (169, 169, 169, 255)
        /// </summary>
        public static Colour DarkGray => new Colour(169, 169, 169, 255);
        /// <summary>
        /// (0, 100, 0, 255)
        /// </summary>
        public static Colour DarkGreen => new Colour(0, 100, 0, 255);
        /// <summary>
        /// (189, 183, 107, 255)
        /// </summary>
        public static Colour DarkKhaki => new Colour(189, 183, 107, 255);
        /// <summary>
        /// (139, 0, 139, 255)
        /// </summary>
        public static Colour DarkMagenta => new Colour(139, 0, 139, 255);
        /// <summary>
        /// (85, 107, 47, 255)
        /// </summary>
        public static Colour DarkOliveGreen => new Colour(85, 107, 47, 255);
        /// <summary>
        /// (255, 140, 0, 255)
        /// </summary>
        public static Colour DarkOrange => new Colour(255, 140, 0, 255);
        /// <summary>
        /// (153, 50, 204, 255)
        /// </summary>
        public static Colour DarkOrchid => new Colour(153, 50, 204, 255);
        /// <summary>
        /// (139, 0, 0, 255)
        /// </summary>
        public static Colour DarkRed => new Colour(139, 0, 0, 255);
        /// <summary>
        /// (233, 150, 122, 255)
        /// </summary>
        public static Colour DarkSalmon => new Colour(233, 150, 122, 255);
        /// <summary>
        /// (143, 188, 139, 255)
        /// </summary>
        public static Colour DarkSeaGreen => new Colour(143, 188, 139, 255);
        /// <summary>
        /// (72, 61, 139, 255)
        /// </summary>
        public static Colour DarkSlateBlue => new Colour(72, 61, 139, 255);
        /// <summary>
        /// (47, 79, 79, 255)
        /// </summary>
        public static Colour DarkSlateGray => new Colour(47, 79, 79, 255);
        /// <summary>
        /// (0, 206, 209, 255)
        /// </summary>
        public static Colour DarkTurquoise => new Colour(0, 206, 209, 255);
        /// <summary>
        /// (148, 0, 211, 255)
        /// </summary>
        public static Colour DarkViolet => new Colour(148, 0, 211, 255);
        /// <summary>
        /// (255, 20, 147, 255)
        /// </summary>
        public static Colour DeepPink => new Colour(255, 20, 147, 255);
        /// <summary>
        /// (0, 191, 255, 255)
        /// </summary>
        public static Colour DeepSkyBlue => new Colour(0, 191, 255, 255);
        /// <summary>
        /// (105, 105, 105, 255)
        /// </summary>
        public static Colour DimGray => new Colour(105, 105, 105, 255);
        /// <summary>
        /// (30, 144, 255, 255)
        /// </summary>
        public static Colour DodgerBlue => new Colour(30, 144, 255, 255); 
        /// <summary>
        /// (178, 34, 34, 255)
        /// </summary>
        public static Colour Firebrick => new Colour(178, 34, 34, 255); 
        /// <summary>
        /// (255, 250, 240, 255)
        /// </summary>
        public static Colour FloralWhite => new Colour(255, 250, 240, 255); 
        /// <summary>
        /// (34, 139, 34, 255)
        /// </summary>
        public static Colour ForestGreen => new Colour(34, 139, 34, 255); 
        /// <summary>
        /// (255, 0, 255, 255)
        /// </summary>
        public static Colour Fuchsia => new Colour(255, 0, 255, 255); 
        /// <summary>
        /// (220, 220, 220, 255)
        /// </summary>
        public static Colour Gainsboro => new Colour(220, 220, 220, 255); 
        /// <summary>
        /// (248, 248, 255, 255)
        /// </summary>
        public static Colour GhostWhite => new Colour(248, 248, 255, 255); 
        /// <summary>
        /// (255, 215, 0, 255)
        /// </summary>
        public static Colour Gold => new Colour(255, 215, 0, 255); 
        /// <summary>
        /// (218, 165, 32, 255)
        /// </summary>
        public static Colour Goldenrod => new Colour(218, 165, 32, 255); 
        /// <summary>
        /// (128, 128, 128, 255)
        /// </summary>
        public static Colour Gray => new Colour(128, 128, 128, 255); 
        /// <summary>
        /// (0, 128, 0, 255)
        /// </summary>
        public static Colour Green => new Colour(0, 128, 0, 255); 
        /// <summary>
        /// (173, 255, 47, 255)
        /// </summary>
        public static Colour GreenYellow => new Colour(173, 255, 47, 255); 
        /// <summary>
        /// (240, 255, 240, 255)
        /// </summary>
        public static Colour Honeydew => new Colour(240, 255, 240, 255); 
        /// <summary>
        /// (255, 105, 180, 255)
        /// </summary>
        public static Colour HotPink => new Colour(255, 105, 180, 255); 
        /// <summary>
        /// (205, 92, 92, 255)
        /// </summary>
        public static Colour IndianRed => new Colour(205, 92, 92, 255); 
        /// <summary>
        /// (75, 0, 130, 255)
        /// </summary>
        public static Colour Indigo => new Colour(75, 0, 130, 255); 
        /// <summary>
        /// (255, 255, 240, 255)
        /// </summary>
        public static Colour Ivory => new Colour(255, 255, 240, 255); 
        /// <summary>
        /// (240, 230, 140, 255)
        /// </summary>
        public static Colour Khaki => new Colour(240, 230, 140, 255); 
        /// <summary>
        /// (230, 230, 250, 255)
        /// </summary>
        public static Colour Lavender => new Colour(230, 230, 250, 255); 
        /// <summary>
        /// (255, 240, 245, 255)
        /// </summary>
        public static Colour LavenderBlush => new Colour(255, 240, 245, 255); 
        /// <summary>
        /// (124, 252, 0, 255)
        /// </summary>
        public static Colour LawnGreen => new Colour(124, 252, 0, 255); 
        /// <summary>
        /// (255, 250, 205, 255)
        /// </summary>
        public static Colour LemonChiffon => new Colour(255, 250, 205, 255); 
        /// <summary>
        /// (173, 216, 230, 255)
        /// </summary>
        public static Colour LightBlue => new Colour(173, 216, 230, 255); 
        /// <summary>
        /// (240, 128, 128, 255)
        /// </summary>
        public static Colour LightCoral => new Colour(240, 128, 128, 255); 
        /// <summary>
        /// (224, 255, 255, 255)
        /// </summary>
        public static Colour LightCyan => new Colour(224, 255, 255, 255); 
        /// <summary>
        /// (250, 250, 210, 255)
        /// </summary>
        public static Colour LightGoldenrodYellow => new Colour(250, 250, 210, 255); 
        /// <summary>
        /// (144, 238, 144, 255)
        /// </summary>
        public static Colour LightGreen => new Colour(144, 238, 144, 255); 
        /// <summary>
        /// (211, 211, 211, 255)
        /// </summary>
        public static Colour LightGray => new Colour(211, 211, 211, 255); 
        /// <summary>
        /// (255, 182, 193, 255)
        /// </summary>
        public static Colour LightPink => new Colour(255, 182, 193, 255); 
        /// <summary>
        /// (255, 160, 122, 255)
        /// </summary>
        public static Colour LightSalmon => new Colour(255, 160, 122, 255); 
        /// <summary>
        /// (32, 178, 170, 255)
        /// </summary>
        public static Colour LightSeaGreen => new Colour(32, 178, 170, 255); 
        /// <summary>
        /// (135, 206, 250, 255)
        /// </summary>
        public static Colour LightSkyBlue => new Colour(135, 206, 250, 255); 
        /// <summary>
        /// (119, 136, 153, 255)
        /// </summary>
        public static Colour LightSlateGray => new Colour(119, 136, 153, 255); 
        /// <summary>
        /// (176, 196, 222, 255)
        /// </summary>
        public static Colour LightSteelBlue => new Colour(176, 196, 222, 255); 
        /// <summary>
        /// (255, 255, 224, 255)
        /// </summary>
        public static Colour LightYellow => new Colour(255, 255, 224, 255); 
        /// <summary>
        /// (0, 255, 0, 255)
        /// </summary>
        public static Colour Lime => new Colour(0, 255, 0, 255); 
        /// <summary>
        /// (50, 205, 50, 255)
        /// </summary>
        public static Colour LimeGreen => new Colour(50, 205, 50, 255); 
        /// <summary>
        /// (250, 240, 230, 255)
        /// </summary>
        public static Colour Linen => new Colour(250, 240, 230, 255); 
        /// <summary>
        /// (255, 0, 255, 255)
        /// </summary>
        public static Colour Magenta => new Colour(255, 0, 255, 255); 
        /// <summary>
        /// (128, 0, 0, 255)
        /// </summary>
        public static Colour Maroon => new Colour(128, 0, 0, 255); 
        /// <summary>
        /// (102, 205, 170, 255)
        /// </summary>
        public static Colour MediumAquamarine => new Colour(102, 205, 170, 255); 
        /// <summary>
        /// (0, 0, 205, 255)
        /// </summary>
        public static Colour MediumBlue => new Colour(0, 0, 205, 255); 
        /// <summary>
        /// (186, 85, 211, 255)
        /// </summary>
        public static Colour MediumOrchid => new Colour(186, 85, 211, 255); 
        /// <summary>
        /// (147, 112, 219, 255)
        /// </summary>
        public static Colour MediumPurple => new Colour(147, 112, 219, 255); 
        /// <summary>
        /// (60, 179, 113, 255)
        /// </summary>
        public static Colour MediumSeaGreen => new Colour(60, 179, 113, 255); 
        /// <summary>
        /// (123, 104, 238, 255)
        /// </summary>
        public static Colour MediumSlateBlue => new Colour(123, 104, 238, 255); 
        /// <summary>
        /// (0, 250, 154, 255)
        /// </summary>
        public static Colour MediumSpringGreen => new Colour(0, 250, 154, 255); 
        /// <summary>
        /// (72, 209, 204, 255)
        /// </summary>
        public static Colour MediumTurquoise => new Colour(72, 209, 204, 255); 
        /// <summary>
        /// (199, 21, 133, 255)
        /// </summary>
        public static Colour MediumVioletRed => new Colour(199, 21, 133, 255); 
        /// <summary>
        /// (25, 25, 112, 255)
        /// </summary>
        public static Colour MidnightBlue => new Colour(25, 25, 112, 255); 
        /// <summary>
        /// (245, 255, 250, 255)
        /// </summary>
        public static Colour MintCream => new Colour(245, 255, 250, 255); 
        /// <summary>
        /// (255, 228, 225, 255)
        /// </summary>
        public static Colour MistyRose => new Colour(255, 228, 225, 255); 
        /// <summary>
        /// (255, 228, 181, 255)
        /// </summary>
        public static Colour Moccasin => new Colour(255, 228, 181, 255); 
        /// <summary>
        /// (255, 222, 173, 255)
        /// </summary>
        public static Colour NavajoWhite => new Colour(255, 222, 173, 255); 
        /// <summary>
        /// (0, 0, 128, 255)
        /// </summary>
        public static Colour Navy => new Colour(0, 0, 128, 255); 
        /// <summary>
        /// (253, 245, 230, 255)
        /// </summary>
        public static Colour OldLace => new Colour(253, 245, 230, 255); 
        /// <summary>
        /// (128, 128, 0, 255)
        /// </summary>
        public static Colour Olive => new Colour(128, 128, 0, 255); 
        /// <summary>
        /// (107, 142, 35, 255)
        /// </summary>
        public static Colour OliveDrab => new Colour(107, 142, 35, 255); 
        /// <summary>
        /// (255, 165, 0, 255)
        /// </summary>
        public static Colour Orange => new Colour(255, 165, 0, 255); 
        /// <summary>
        /// (255, 69, 0, 255)
        /// </summary>
        public static Colour OrangeRed => new Colour(255, 69, 0, 255); 
        /// <summary>
        /// (218, 112, 214, 255)
        /// </summary>
        public static Colour Orchid => new Colour(218, 112, 214, 255); 
        /// <summary>
        /// (238, 232, 170, 255)
        /// </summary>
        public static Colour PaleGoldenrod => new Colour(238, 232, 170, 255); 
        /// <summary>
        /// (152, 251, 152, 255)
        /// </summary>
        public static Colour PaleGreen => new Colour(152, 251, 152, 255); 
        /// <summary>
        /// (175, 238, 238, 255)
        /// </summary>
        public static Colour PaleTurquoise => new Colour(175, 238, 238, 255); 
        /// <summary>
        /// (219, 112, 147, 255)
        /// </summary>
        public static Colour PaleVioletRed => new Colour(219, 112, 147, 255); 
        /// <summary>
        /// (255, 239, 213, 255)
        /// </summary>
        public static Colour PapayaWhip => new Colour(255, 239, 213, 255); 
        /// <summary>
        /// (255, 218, 185, 255)
        /// </summary>
        public static Colour PeachPuff => new Colour(255, 218, 185, 255); 
        /// <summary>
        /// (205, 133, 63, 255)
        /// </summary>
        public static Colour Peru => new Colour(205, 133, 63, 255); 
        /// <summary>
        /// (255, 192, 203, 255)
        /// </summary>
        public static Colour Pink => new Colour(255, 192, 203, 255); 
        /// <summary>
        /// (221, 160, 221, 255)
        /// </summary>
        public static Colour Plum => new Colour(221, 160, 221, 255); 
        /// <summary>
        /// (176, 224, 230, 255)
        /// </summary>
        public static Colour PowderBlue => new Colour(176, 224, 230, 255); 
        /// <summary>
        /// (128, 0, 128, 255)
        /// </summary>
        public static Colour Purple => new Colour(128, 0, 128, 255); 
        /// <summary>
        /// (255, 0, 0, 255)
        /// </summary>
        public static Colour Red => new Colour(255, 0, 0, 255); 
        /// <summary>
        /// (188, 143, 143, 255)
        /// </summary>
        public static Colour RosyBrown => new Colour(188, 143, 143, 255); 
        /// <summary>
        /// (65, 105, 225, 255)
        /// </summary>
        public static Colour RoyalBlue => new Colour(65, 105, 225, 255); 
        /// <summary>
        /// (139, 69, 19, 255)
        /// </summary>
        public static Colour SaddleBrown => new Colour(139, 69, 19, 255); 
        /// <summary>
        /// (250, 128, 114, 255)
        /// </summary>
        public static Colour Salmon => new Colour(250, 128, 114, 255); 
        /// <summary>
        /// (244, 164, 96, 255)
        /// </summary>
        public static Colour SandyBrown => new Colour(244, 164, 96, 255); 
        /// <summary>
        /// (46, 139, 87, 255)
        /// </summary>
        public static Colour SeaGreen => new Colour(46, 139, 87, 255); 
        /// <summary>
        /// (255, 245, 238, 255)
        /// </summary>
        public static Colour SeaShell => new Colour(255, 245, 238, 255); 
        /// <summary>
        /// (160, 82, 45, 255)
        /// </summary>
        public static Colour Sienna => new Colour(160, 82, 45, 255); 
        /// <summary>
        /// (192, 192, 192, 255)
        /// </summary>
        public static Colour Silver => new Colour(192, 192, 192, 255); 
        /// <summary>
        /// (135, 206, 235, 255)
        /// </summary>
        public static Colour SkyBlue => new Colour(135, 206, 235, 255); 
        /// <summary>
        /// (106, 90, 205, 255)
        /// </summary>
        public static Colour SlateBlue => new Colour(106, 90, 205, 255); 
        /// <summary>
        /// (112, 128, 144, 255)
        /// </summary>
        public static Colour SlateGray => new Colour(112, 128, 144, 255); 
        /// <summary>
        /// (255, 250, 250, 255)
        /// </summary>
        public static Colour Snow => new Colour(255, 250, 250, 255); 
        /// <summary>
        /// (0, 255, 127, 255)
        /// </summary>
        public static Colour SpringGreen => new Colour(0, 255, 127, 255); 
        /// <summary>
        /// (70, 130, 180, 255)
        /// </summary>
        public static Colour SteelBlue => new Colour(70, 130, 180, 255); 
        /// <summary>
        /// (210, 180, 140, 255)
        /// </summary>
        public static Colour Tan => new Colour(210, 180, 140, 255); 
        /// <summary>
        /// (0, 128, 128, 255)
        /// </summary>
        public static Colour Teal => new Colour(0, 128, 128, 255); 
        /// <summary>
        /// (216, 191, 216, 255)
        /// </summary>
        public static Colour Thistle => new Colour(216, 191, 216, 255); 
        /// <summary>
        /// (255, 99, 71, 255)
        /// </summary>
        public static Colour Tomato => new Colour(255, 99, 71, 255); 
        /// <summary>
        /// (64, 224, 208, 255)
        /// </summary>
        public static Colour Turquoise => new Colour(64, 224, 208, 255); 
        /// <summary>
        /// (238, 130, 238, 255)
        /// </summary>
        public static Colour Violet => new Colour(238, 130, 238, 255); 
        /// <summary>
        /// (245, 222, 179, 255)
        /// </summary>
        public static Colour Wheat => new Colour(245, 222, 179, 255); 
        /// <summary>
        /// (255, 255, 255, 255)
        /// </summary>
        public static Colour White => new Colour(255, 255, 255, 255); 
        /// <summary>
        /// (245, 245, 245, 255)
        /// </summary>
        public static Colour WhiteSmoke => new Colour(245, 245, 245, 255); 
        /// <summary>
        /// (255, 255, 0, 255)
        /// </summary>
        public static Colour Yellow => new Colour(255, 255, 0, 255); 
        /// <summary>
        /// (154, 205, 50, 255)
        /// </summary>
        public static Colour YellowGreen => new Colour(154, 205, 50, 255);
        #endregion
        #endregion

        #region Fields
        /// <summary>
        /// The Red colour component [0,255]
        /// </summary>
        public byte R;
        /// <summary>
        /// The Green colour component [0,255]
        /// </summary>
        public byte G;
        /// <summary>
        /// The Blue colour component [0,255]
        /// </summary>
        public byte B;
        /// <summary>
        /// The Alpha component [0,255]
        /// </summary>
        public byte A;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a Colour from float components. The components should be between 0 and 1.
        /// </summary>
        public Colour(float r, float g, float b, float a = 1)
        {
            if (r < 0 || r > 1 || g < 0 || g > 1 || b < 0 || b > 1 || a < 0 || a > 1)
                throw new HException("Arguments should be between 0 & 1. You requested: R:{0}, G:{1}, B:{2}, A:{3}", r, g, b, a);

            R = (byte)(r * 255);
            G = (byte)(g * 255);
            B = (byte)(b * 255);
            A = (byte)(a * 255);
        }

        /// <summary>
        /// Builds a colour from a string in the format "r,g,b,a" with byte values (integers in [0,255])
        /// </summary>
        /// <param name="colourComponents"></param>
        public Colour(string colourComponents)
            : this((byte)Convert.ChangeType(colourComponents.Split(',')[0], typeof(byte)),
                  (byte)Convert.ChangeType(colourComponents.Split(',')[1], typeof(byte)),
                  (byte)Convert.ChangeType(colourComponents.Split(',')[2], typeof(byte)),
                  (byte)Convert.ChangeType(colourComponents.Split(',')[3], typeof(byte)))
        {
        }

        /// <summary>
        /// Creates a Colour from components. The components should be between 0 and 255.
        /// </summary>
        public Colour(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Colour(Colour colour, byte alpha)
        {
            R = colour.R;
            G = colour.G;
            B = colour.B;
            A = alpha;
        }

        public Colour(Colour colour, float alpha)
        {
            if (alpha < 0 || alpha > 1)
                throw new HException("Arguments should be between 0 & 1. You requested: A:{0}", alpha);

            R = colour.R;
            G = colour.G;
            B = colour.B;
            A = (byte)(alpha * 255);
        }
        #endregion

        #region IEquatable
        #region Equals
        public bool Equals(Colour other)
        {
            return R == other.R &&
                G == other.G &&
                B == other.B &&
                A == other.A;
        }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Returns the same colour but with the specified alpha
        /// </summary>
        public Colour WithAlpha(byte alpha) => new Colour(R, G, B, alpha);
        #endregion

        #region Overloads / Overrides
        #region +
        public static Colour operator +(Colour l, Colour r)
        {
            return new Colour
            {
                R = (byte)Math.Min(l.R + r.R, Byte.MaxValue),
                G = (byte)Math.Min(l.G + r.G, Byte.MaxValue),
                B = (byte)Math.Min(l.B + r.B, Byte.MaxValue),
                A = (byte)Math.Min(l.A + r.A, Byte.MaxValue),
            };
        }
        #endregion

        #region -
        public static Colour operator -(Colour l, Colour r)
        {
            return new Colour
            {
                R = (byte)Math.Max(l.R - r.R, 0),
                G = (byte)Math.Max(l.G - r.G, 0),
                B = (byte)Math.Max(l.B - r.B, 0),
                A = (byte)Math.Max(l.A - r.A, 0),
            };
        }
        #endregion

        #region *
        public static Colour operator *(Colour l, Colour r)
        {
            return new Colour
            {
                R = (byte)Math.Min(l.R * r.R / 255, Byte.MaxValue),
                G = (byte)Math.Min(l.G * r.G / 255, Byte.MaxValue),
                B = (byte)Math.Min(l.B * r.B / 255, Byte.MaxValue),
                A = (byte)Math.Min(l.A * r.A / 255, Byte.MaxValue),
            };
        }

        public static Colour operator *(Colour l, float r) => r * l;

        public static Colour operator *(float l, Colour r)
        {
            return new Colour
            {
                R = (byte)Math.Min(Math.Max(l * r.R, 0), Byte.MaxValue),
                G = (byte)Math.Min(Math.Max(l * r.G, 0), Byte.MaxValue),
                B = (byte)Math.Min(Math.Max(l * r.B, 0), Byte.MaxValue),
                A = (byte)Math.Min(Math.Max(l * r.A, 0), Byte.MaxValue),
            };
        }
        #endregion

        #region ==
        public static bool operator ==(Colour left, Colour right)
        {
            return left.Equals(right);
        }
        #endregion

        #region !=
        public static bool operator !=(Colour left, Colour right)
        {
            return !left.Equals(right);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (!(obj is Colour))
                return false;

            return Equals((Colour)obj);
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return string.Format("(R:{0}, G:{1}, B:{2}, A:{3})", R, G, B, A);
        }
        #endregion

        #region GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #endregion
    }
}