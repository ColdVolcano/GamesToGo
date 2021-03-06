﻿using GamesToGo.Editor.Project.Arguments;
using JetBrains.Annotations;

namespace GamesToGo.Editor.Project.Actions
{
    [UsedImplicitly]
    public class RemovePlayerAction : EventAction
    {
        public override int TypeID => 7;

        public override ArgumentType[] ExpectedArguments { get; } = {
            ArgumentType.SinglePlayer,
        };

        public override string[] Text { get; } = {
            @"Eliminar jugador",
        };
    }
}
