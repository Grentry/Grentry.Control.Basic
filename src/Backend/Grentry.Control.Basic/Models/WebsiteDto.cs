using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grentry.Control.Basic.Models
{
    public class WebsiteDto
    {
        public WebsiteDto()
        {
            TextItems = new List<TextItem>();
            ButtonItems = new List<ButtonItem>();
        }
        /// <summary>
        /// Background color (example #FF0055)
        /// </summary>
        public string BackgroundColor { get; set; }
        public List<TextItem> TextItems { get; set; }
        public List<ButtonItem> ButtonItems { get; set; }
    }

    public class ItemBase
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Text { get; set; }
        public int TextSize { get; set; }
    }

    public class TextItem : ItemBase
    {
    }

    public class ButtonItem : ItemBase
    {
    }

}
