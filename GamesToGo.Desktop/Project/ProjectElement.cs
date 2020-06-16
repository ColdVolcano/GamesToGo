﻿using System.Collections.Generic;
using System.Text;
using osu.Framework.Bindables;

namespace GamesToGo.Desktop.Project
{
    public abstract class ProjectElement
    {
        public int ID { get; set; }

        public abstract Bindable<string> Name { get; set; }

        public abstract Dictionary<string, Bindable<Image>> Images { get; }

        public virtual string ToSaveable()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{ID}|{Name}");
            builder.AppendLine($"Images:{Images.Count}");
            foreach (var image in Images)
            {
                builder.AppendLine($"{image.Key}={image.Value.Value?.DatabaseObject?.NewName ?? "null"}");
            }

            return builder.ToString();
        }
    }
}
