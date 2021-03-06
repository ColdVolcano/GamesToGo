﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using GamesToGo.Common.Game;
using Newtonsoft.Json;

// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace GamesToGo.Common.Online.RequestModel
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class OnlineGame
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string LastEdited
        {
            get => DateTimeLastEdited.ToString(@"yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            set => DateTimeLastEdited = DateTime.ParseExact(value, @"yyyyMMddHHmmssfff", CultureInfo.InvariantCulture).ToLocalTime();
        }

        [JsonIgnore]
        public DateTime DateTimeLastEdited { get; private set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public string Description { get; set; }
        public CommunityStatus Status { get; set; }
        public int Minplayers { get; set; }
        public int Maxplayers { get; set; }
        public User Creator { get; set; }
    }
}
