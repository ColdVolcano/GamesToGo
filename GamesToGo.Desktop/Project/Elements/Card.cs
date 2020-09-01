using System;
using System.Collections.Generic;
using GamesToGo.Desktop.Project.Events;
using osu.Framework.Bindables;
using osuTK;

namespace GamesToGo.Desktop.Project.Elements
{
    public class Card : ProjectElement, IHasSize, IHasEvents
    {
        public override ElementType Type => ElementType.Card;

        public override Bindable<string> Name { get; set; } = new Bindable<string>("Nueva Carta");

        public override Bindable<string> Description { get; set; } = new Bindable<string>("¡Describe esta carta para poder identificarla mejor!");

        protected override string DefaultImageName => @"Card";

        public override Dictionary<string, Bindable<Image>> Images { get; } = new Dictionary<string, Bindable<Image>>(new List<KeyValuePair<string, Bindable<Image>>>
        {
            new KeyValuePair<string, Bindable<Image>>("Frente", new Bindable<Image>()),
            new KeyValuePair<string, Bindable<Image>>("Posterior", new Bindable<Image>()),
        });

        public Bindable<Vector2> Size { get; } = new Bindable<Vector2>(new Vector2(400));

        public BindableList<Event> Events { get; } = new BindableList<Event>();

        public Type[] CompatibleEvents { get; } = Array.Empty<Type>();
    }
}
