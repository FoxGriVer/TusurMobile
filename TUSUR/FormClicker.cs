using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSUR.Views;
using Xamarin.Forms;


namespace TUSUR
{
    public class FormClicker : Behavior<Grid>
    {
        protected override void OnAttachedTo(Grid grid)
        {
            base.OnAttachedTo(grid);
        }

        protected override void OnDetachingFrom(Grid grid)
        {
            base.OnDetachingFrom(grid);
        }

        public FormClicker()
        {
        }
    }
}
