﻿using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK;

namespace GamesToGo.App.Graphics
{
    public class SimpleIconButton : Button
    {
        private readonly IconUsage buttonIcon;

        public SimpleIconButton(IconUsage buttonIcon)
        {
            this.buttonIcon = buttonIcon;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Masking = true;
            CornerRadius = 5;
            Size = new Vector2(100, 100);
            Children = new Drawable[]
            {
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding(5),
                    Children = new[]
                    {
                        new SpriteIcon
                        {
                            RelativeSizeAxes = Axes.Both,
                            Icon = buttonIcon,
                        },
                    },
                },
            };
        }
    }
}
