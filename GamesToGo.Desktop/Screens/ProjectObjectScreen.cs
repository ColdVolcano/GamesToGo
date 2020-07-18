﻿using GamesToGo.Desktop.Graphics;
using GamesToGo.Desktop.Project;
using GamesToGo.Desktop.Project.Elements;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace GamesToGo.Desktop.Screens
{
    public class ProjectObjectScreen : Screen
    {
        private IBindable<ProjectElement> currentEditing = new Bindable<ProjectElement>();
        private ProjectEditor editor;
        private BasicTextBox nameTextBox;
        private Container noSelectionContainer;
        private BasicScrollContainer activeEditContainer;
        private Container editAreaContainer;
        private Container customElementsContainer;

        [BackgroundDependencyLoader]
        private void load(ProjectEditor editor)
        {
            this.editor = editor;

            InternalChildren = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4 (106, 100, 104, 255),
                },
                new GridContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Content = new[]
                    {
                        new Drawable[]
                        {
                            //Listas de elementos
                            new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                Children = new Drawable []
                                {
                                    new Box
                                    {
                                        RelativeSizeAxes = Axes.Both,
                                        Colour = Color4.Gray
                                    },
                                    new ProjectObjectManagerContainer<Card>("Cartas", true)
                                    {
                                        Anchor = Anchor.TopLeft,
                                        Origin = Anchor.TopLeft,
                                        Height = 1/3f,
                                    },
                                    new ProjectObjectManagerContainer<Token>("Fichas", true)
                                    {
                                        Anchor = Anchor.CentreLeft,
                                        Origin = Anchor.CentreLeft,
                                        Height = 1/3f,
                                    },
                                    new ProjectObjectManagerContainer<Board>("Tableros", true)
                                    {
                                        Anchor = Anchor.BottomLeft,
                                        Origin = Anchor.BottomLeft,
                                        Height = 1/3f,
                                    }
                                }
                            },
                            //Area de edición
                            editAreaContainer = new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                Children = new Drawable[]
                                {
                                    activeEditContainer = new BasicScrollContainer
                                    {
                                        RelativeSizeAxes = Axes.Both,
                                        Child = new FillFlowContainer
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Direction = FillDirection.Vertical,
                                            Children = new Drawable[]
                                            {
                                                new Container
                                                {
                                                    RelativeSizeAxes = Axes.X,
                                                    AutoSizeAxes = Axes.Y,
                                                    Children = new Drawable[]
                                                    {
                                                        new Box
                                                        {
                                                            RelativeSizeAxes = Axes.Both,
                                                            Colour = Color4.Cyan
                                                        },
                                                        new Container
                                                        {
                                                            RelativeSizeAxes = Axes.X,
                                                            AutoSizeAxes = Axes.Y,
                                                            Padding = new MarginPadding() { Horizontal = 60, Vertical = 50 },
                                                            Children = new Drawable[]
                                                            {
                                                                new ImagePreviewContainer(),
                                                                new SpriteText
                                                                {
                                                                    Anchor = Anchor.TopRight,
                                                                    Origin = Anchor.TopRight,
                                                                    Position = new Vector2(-675,10),
                                                                    Text = "Nombre:",
                                                                    Colour = Color4.Black
                                                                },
                                                                nameTextBox = new BasicTextBox
                                                                {
                                                                    Anchor = Anchor.TopRight,
                                                                    Origin = Anchor.TopRight,
                                                                    Position = new Vector2(-250,0),
                                                                    Height = 35,
                                                                    Width = 400,
                                                                },
                                                                new SpriteText
                                                                {
                                                                    Anchor = Anchor.TopRight,
                                                                    Origin = Anchor.TopRight,
                                                                    Position = new Vector2(-675,80),
                                                                    Text = "Descripcion:",
                                                                    Colour = Color4.Black
                                                                },
                                                                new BasicTextBox
                                                                {
                                                                    Anchor = Anchor.TopRight,
                                                                    Origin = Anchor.TopRight,
                                                                    Position = new Vector2(-250, 70),
                                                                    Height = 35,
                                                                    Width = 400,
                                                                }
                                                            }
                                                        }
                                                    }
                                                },
                                                customElementsContainer = new Container
                                                {
                                                    RelativeSizeAxes = Axes.X,
                                                    Height = 400,
                                                    Children = new Drawable[]
                                                    {
                                                        new Box
                                                        {
                                                            RelativeSizeAxes = Axes.Both,
                                                            Colour = Color4.Fuchsia
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    noSelectionContainer = new Container
                                    {
                                        RelativeSizeAxes = Axes.Both,
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Child = new SpriteText
                                        {
                                            Text = "Selecciona un objeto para editarlo",
                                        },
                                    },
                                }
                            }
                        }
                    },
                    ColumnDimensions = new Dimension[]
                    {
                        new Dimension(GridSizeMode.Relative, 0.25f),
                        new Dimension(GridSizeMode.Distributed)
                    }
                }
            };

            currentEditing.BindTo(editor.CurrentEditingElement);
            currentEditing.BindValueChanged(checkData, true);
        }

        private void checkData(ValueChangedEvent<ProjectElement> obj)
        {
            activeEditContainer.FadeTo(obj.NewValue == null ? 0 : 1);
            noSelectionContainer.FadeTo(obj.NewValue == null ? 1 : 0);

            nameTextBox.Current.UnbindEvents();

            if (obj.NewValue != null)
            {
                nameTextBox.Text = obj.NewValue.Name.Value;
            }

            nameTextBox.Current.ValueChanged += (obj) => currentEditing.Value.Name.Value = obj.NewValue;
        }
    }
}
