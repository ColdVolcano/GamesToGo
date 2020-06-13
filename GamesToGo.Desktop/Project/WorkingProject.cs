﻿using System;
using System.Collections.Generic;
using System.Text;
using GamesToGo.Desktop.Project.Elements;
using System.Linq;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Textures;
using osu.Framework.Platform;
using GamesToGo.Desktop.Database.Models;

namespace GamesToGo.Desktop.Project
{
    public class WorkingProject
    {
        private TextureStore textures;

        public ProjectInfo DatabaseObject { get; }

        private int latestElementID = 1;

        private readonly BindableList<IProjectElement> projectElements = new BindableList<IProjectElement>();

        public IEnumerable<Card> ProjectCards => projectElements.Where(e => e is Card).Select(e => (Card)e);

        public IEnumerable<Token> ProjectTokens => projectElements.Where(e => e is Token).Select(e => (Token)e);

        public IEnumerable<Board> ProjectBoards => projectElements.Where(e => e is Board).Select(e => (Board)e);

        public IBindableList<IProjectElement> ProjectElements => projectElements;

        public List<Image> Images = new List<Image>();

        public WorkingProject(ProjectInfo project, Storage store, TextureStore textures)
        {
            this.textures = textures;
            DatabaseObject = project;

            if (DatabaseObject.File != null)
                parse(System.IO.File.ReadAllLines(store.GetFullPath($"files/{DatabaseObject.File.NewName}")));
        }

        public void AddElement(IProjectElement element)
        {
            element.ID = latestElementID++;
            projectElements.Add(element);
        }

        public void AddImage(File image)
        {
            Images.Add(new Image(() => { return textures.Get($"files/{image.NewName}"); }, image));
        }

        /// <summary>
        /// Solo llamar cuando se quiera guardar
        /// </summary>
        /// <returns></returns>
        public string SaveableString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("[Info]");
            builder.AppendLine("OnlineProjectID=-1");
            builder.AppendLine("CreatorID=-1");
            builder.AppendLine($"Name={DatabaseObject.Name}");
            builder.AppendLine($"MinNumberPlayers={DatabaseObject.MinNumberPlayers}");
            builder.AppendLine($"MaxNumberPlayers={DatabaseObject.MaxNumberPlayers}");
            builder.AppendLine($"Files={Images.Count}");
            foreach(var img in Images)
            {
                builder.AppendLine($" {img.DatabaseObject.NewName}");
            }
            builder.AppendLine($"LastEdited={(DatabaseObject.LastEdited = DateTime.Now).ToUniversalTime():yyyyMMddHHmmssfff}");
            builder.AppendLine();

            builder.AppendLine("[Objects]");
            foreach(IProjectElement elem in ProjectElements)
            {
                builder.AppendLine($"{elem.ToSaveable()}");
            }

            return builder.ToString();
        }

        private void parse(string[] lines)
        {
            foreach (var line in lines)
            {
                if(line.StartsWith('['))
                {

                }
            }
        }
    }
}
