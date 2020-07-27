﻿using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK.Graphics;
using osuTK;
using GamesToGo.Desktop.Graphics;
using GamesToGo.Desktop.Database.Models;
using GamesToGo.Desktop.Project;
using System.Linq;
using osu.Framework.Platform;
using GamesToGo.Desktop.Online;
using System.Collections.Generic;
using GamesToGo.Desktop.Overlays;

namespace GamesToGo.Desktop.Screens
{
    /// <summary>
    /// Pantalla del menu principal, muestra los proyectos del usuario, su perfil, y un modal para cerrar sesión. (WIP)
    /// </summary>
    public class MainMenuScreen : Screen
    {
        private Container userInformation;
        private Context database;
        private Storage store;
        private APIController api;
        private FillFlowContainer<ProjectSummaryContainer> projectsList;
        private FillFlowContainer<OnlineProjectSummaryContainer> onlineProjectsList;

        [BackgroundDependencyLoader]
        private void load(Context database, Storage store, APIController api, SplashInfoOverlay infoOverlay)
        {
            this.database = database;
            this.store = store;
            this.api = api;
            RelativePositionAxes = Axes.X;
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4 (106,100,104, 255)      //Color fondo general
                },
                new GridContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    ColumnDimensions = new Dimension[]
                    {
                        new Dimension(GridSizeMode.Relative, 0.25f),
                        new Dimension(GridSizeMode.Distributed)
                    },
                    Content = new []
                    {
                        new Drawable[]
                        {
                            userInformation = new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                RelativePositionAxes = Axes.Both,
                                Children = new Drawable[]
                                {
                                    new Box
                                    {
                                        RelativeSizeAxes = Axes.Both,
                                        Colour = new Color4 (145,144,144, 255)   //Color userInformation
                                    },
                                    new CircularContainer
                                    {
                                        Size = new Vector2(250),
                                        Child = new Box         //Cambiar Box por Sprite
                                        {
                                            RelativeSizeAxes = Axes.Both
                                            //FillMode= FillMode.Fill,
                                        },
                                        BorderColour = Color4.Black,
                                        BorderThickness = 3.5f,
                                        Anchor = Anchor.TopCentre,
                                        Origin = Anchor.TopCentre,
                                        Position = new Vector2(0,125),
                                        Masking = true
                                    },
                                    new SpriteText
                                    {
                                        Text = api.LocalUser.Value.Username,
                                        Anchor = Anchor.TopCentre,
                                        Origin = Anchor.TopCentre,
                                        Position = new Vector2(0,450)
                                    },
                                    new GamesToGoButton
                                    {
                                        Text = "Perfil",
                                        BackgroundColour = new Color4 (106,100,104, 255),  //Color Boton userInformation
                                        BorderColour = Color4.Black,
                                        BorderThickness = 2f,
                                        RelativeSizeAxes = Axes.X,
                                        Masking = true,
                                        Height = 40,
                                        Anchor = Anchor.TopCentre,
                                        Origin = Anchor.TopCentre,
                                        Position = new Vector2(0,600)
                                    },
                                    new GamesToGoButton
                                    {
                                        Text = "Cerrar Sesión",
                                        BackgroundColour = new Color4 (106,100,104, 255),   //Color Boton userInformation
                                        BorderColour = Color4.Black,
                                        BorderThickness = 2f,
                                        RelativeSizeAxes = Axes.X,
                                        Masking = true,
                                        Height = 40,
                                        Anchor = Anchor.TopCentre,
                                        Origin = Anchor.TopCentre,
                                        Position = new Vector2(0,700),
                                        Action = logout,
                                    }
                                }
                            },
                            new GridContainer
                            {
                                RelativeSizeAxes = Axes.Both,
                                RowDimensions = new Dimension[]
                                {
                                    new Dimension(),
                                    new Dimension(GridSizeMode.AutoSize),
                                },
                                Content = new []
                                {
                                    new Drawable[]
                                    {
                                        new BasicScrollContainer
                                        {
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre,
                                            ClampExtension = 10,
                                            Padding = new MarginPadding() { Top = 200, Horizontal = 150 },
                                            RelativeSizeAxes = Axes.Both,
                                            Child = new FillFlowContainer
                                            {
                                                Anchor = Anchor.TopCentre,
                                                Origin = Anchor.TopCentre,
                                                Spacing = new Vector2(0, 7),
                                                RelativeSizeAxes = Axes.X,
                                                AutoSizeAxes = Axes.Y,
                                                Direction = FillDirection.Vertical,
                                                Children = new Drawable[]
                                                {
                                                    projectsList = new FillFlowContainer<ProjectSummaryContainer>
                                                    {
                                                        BorderColour = Color4.Black,
                                                        BorderThickness = 3f,
                                                        Masking = true,
                                                        Anchor = Anchor.TopCentre,
                                                        Origin = Anchor.TopCentre,
                                                        Spacing = new Vector2(0, 7),
                                                        RelativeSizeAxes = Axes.X,
                                                        AutoSizeAxes = Axes.Y,
                                                        Direction = FillDirection.Vertical,
                                                    },
                                                    onlineProjectsList = new FillFlowContainer<OnlineProjectSummaryContainer>
                                                    {
                                                        BorderColour = Color4.Black,
                                                        BorderThickness = 3f,
                                                        Masking = true,
                                                        Anchor = Anchor.TopCentre,
                                                        Origin = Anchor.TopCentre,
                                                        Spacing = new Vector2(0, 7),
                                                        RelativeSizeAxes = Axes.X,
                                                        AutoSizeAxes = Axes.Y,
                                                        Direction = FillDirection.Vertical,
                                                    }
                                                }
                                            }
                                        },
                                    },
                                    new Drawable[]
                                    {
                                        new GamesToGoButton
                                        {
                                            Text = "Crear Nuevo Proyecto",
                                            BackgroundColour = new Color4 (145,144,144, 255),
                                            BorderColour = Color4.Black,
                                            BorderThickness = 2f,
                                            RelativeSizeAxes = Axes.X,
                                            Masking = true,
                                            Height = 100,
                                            Anchor = Anchor.BottomCentre,
                                            Origin = Anchor.BottomCentre,
                                            Action = createProject,
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var getGame = new DownloadProjectRequest(1, "A024C54D5D296168B1ED06430428A5CEFF3C2603", store);
            getGame.Success += filename => infoOverlay.Show(store.GetFullPath(filename), Color4.Black);
            api.Queue(getGame);

            populateProjectList();
        }

        private void logout()
        {
            api.Logout();
            this.Exit();
        }

        public override void OnEntering(IScreen last)
        {
            base.OnEntering(last);

            this.MoveToX(-1).MoveToX(0, 1000, Easing.InOutQuart);
            userInformation.MoveToX(-1).Then().Delay(300).MoveToX(0, 1500, Easing.OutBounce);
        }

        public override bool OnExiting(IScreen next)
        {
            this.MoveToX(-1, 1000, Easing.InOutQuart);

            return base.OnExiting(next);
        }

        public override void OnResuming(IScreen last)
        {
            base.OnResuming(last);

            onlineProjectsList.Clear();
            projectsList.Clear();
            populateProjectList();
        }

        private void populateProjectList()
        {
            foreach (var proj in database.Projects)
            {
                projectsList.Add(new ProjectSummaryContainer(proj) { EditAction = OpenProject, DeleteAction = DeleteProject });
            }

            var getProjects = new GetAllProjectsRequest();
            getProjects.Success += u =>
            {
                foreach (var proj in u)
                {
                    onlineProjectsList.Add(new OnlineProjectSummaryContainer(proj.Id));
                }
            };
            api.Queue(getProjects);
        }

        public void OpenProject(WorkingProject project)
        {
            LoadComponentAsync(new ProjectEditor(project), pe => this.Push(pe));
        }

        public void DeleteProject(ProjectInfo project)
        {
            if (project.Relations != null)
                database.Relations.RemoveRange(project.Relations);
            projectsList.Remove(projectsList.Children.First(p => p.ProjectInfo.LocalProjectID == project.LocalProjectID));
            store.Delete($"files/{project.File.NewName}");
            database.Files.Remove(project.File);
            database.Projects.Remove(project);
            database.SaveChanges();
        }

        private void createProject()
        {
            OpenProject(null);
        }
    }
}
