﻿using JetBrains.Annotations;

namespace GamesToGo.Editor.Project.Arguments
{
    [UsedImplicitly]
    public class PlayerCardsWithTokenArgument : Argument
    {
        public override int ArgumentTypeID => 17;

        public override ArgumentType Type => ArgumentType.MultipleCard;

        public override ArgumentType[] ExpectedArguments { get; } = {
            ArgumentType.SinglePlayer,
            ArgumentType.TokenType,
        };

        public override string[] Text { get; } = {
            @"cartas de",
            @"con fichas de tipo",
        };
    }
}
