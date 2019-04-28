using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsCell : ViewCell
	{
		public NewsCell ()
		{
			InitializeComponent ();
		}
        #region "Head BindableProperty"
        public static readonly BindableProperty HeadProperty =
            BindableProperty.Create(
                "Head",
                typeof(string),
                typeof(NewsCell),
                null);
        public string Head
        {
            get { return (string)GetValue(HeadProperty); }
            set { SetValue(HeadProperty, value); }
        }
        #endregion

        #region "Theme BindableProperty"
        public static readonly BindableProperty ThemeProperty =
            BindableProperty.Create(
                "Theme",
                typeof(string),
                typeof(NewsCell),
                null);
        public string Theme
        {
            get { return (string)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }
        #endregion

        #region "Date BindableProperty"
        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(
                "Date",
                typeof(string),
                typeof(NewsCell),
                null);
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
        #endregion

        #region "Photo BindableProperty"
        public static readonly BindableProperty PhotoProperty =
            BindableProperty.Create(
                "Photo",
                typeof(ImageSource),
                typeof(NewsCell),
                null);
        public ImageSource Photo
        {
            get { return (ImageSource)GetValue(PhotoProperty); }
            set { SetValue(PhotoProperty, value); }
        }
        #endregion

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                imgPhoto.Source = Photo;
                lblHead.Text = Head;
                lblTheme.Text = Theme;
                lblDate.Text = Date;
            }
        }
    }
}