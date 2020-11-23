﻿using GamesToGo.Editor.Project.Arguments;

namespace GamesToGo.Editor.Project.Events
{
    public class DrawCardTypeOffTileEvent : ProjectEvent
    {
        public override int TypeID => 4;

        public override EventSourceActivator Source => EventSourceActivator.SingleTile;

        public override EventSourceActivator Activator => EventSourceActivator.SinglePlayer;

        public override string[] Text => new[] { @"Al tomar una carta de tipo" };

        public override ArgumentType[] ExpectedArguments => new[]
        {
            ArgumentType.CardType,
        };
    }
}