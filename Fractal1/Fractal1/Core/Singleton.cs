﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fractal1.Core
{
    using System;

    public class Singleton
    {
        private static Singleton instance;

        public struct RGBElement
        {
            public string Context;
            public string RGBValues;
        }
        public static Dictionary<string, Dictionary<string, string> > Colors ;


        private Singleton() { if (Colors == null) Colors = new Dictionary<string, Dictionary<string, string>>(); }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}