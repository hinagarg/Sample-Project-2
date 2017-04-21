using System;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace myportfolio.Models.Navigation
{
    public class Links : List<Links>, IRenderingModel
    {
        public Sitecore.Mvc.Presentation.Rendering Rendering { get; set; }
        public Item Item { get; set; }
        public Item PageItem { get; set; }
        public virtual string Title { get; set; }
        public virtual string URL { get; set; }
        public List<Links> MenuLinks = new List<Links>();
        public Links() { }
        public Links(Item item)
        {
            this.Title = FieldRenderer.Render(item, "Title");
            this.URL = FieldRenderer.Render(item, "Link");
        }
        public void Initialize(Sitecore.Mvc.Presentation.Rendering rendering)
        {
            Rendering = rendering;
            Item = rendering.Item;
            PageItem = PageContext.Current.Item;
            foreach (Item child in rendering.Item.GetChildren())
            {
                Links obj = new Links(child);
                MenuLinks.Add(obj);
            }
        }
    }
}