﻿using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace GamesToGo.Desktop.Project.Elements
{
    public class Token : IProjectElement
    {
        public int ID { get; set; }
        public Bindable<string> Name { get; set; } = new Bindable<string>("Nueva Ficha");

        public Dictionary<string, Image> Images => new Dictionary<string, Image>();

        public string ToSaveable()
        {
            return "";
        }
    }
}
