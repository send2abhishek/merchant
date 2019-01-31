using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
namespace Attra.EWallet.Models
{
   public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color  BackgroundColor { get; set; }
        public Type TargetType { get; set; }
        public MasterMenuItem(string Title,string IconSource,Color color,Type type)
        {
            this.Title = Title;
            this.IconSource = IconSource;
            this.BackgroundColor = color;
            this.TargetType = type;
        }
    }
}
