using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Business.InfoClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BusinessDetailCell : ViewCell
	{
		public BusinessDetailCell ()
		{
			InitializeComponent ();
		}
        #region "Date BindableProperty"
        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(
                "Date",
                typeof(string),
                typeof(BusinessDetailCell),
                null);
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
        #endregion

        #region "State BindableProperty"
        public static readonly BindableProperty StateProperty =
            BindableProperty.Create(
                "State",
                typeof(string),
                typeof(BusinessDetailCell),
                null);
        public string State
        {
            get { return (string)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        #endregion
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                lblDate.Text = Date;
                lblState.Text = State;
            }
        }
    }
}