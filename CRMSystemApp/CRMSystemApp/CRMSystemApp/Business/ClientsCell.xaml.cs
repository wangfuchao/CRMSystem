using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Business
{
	public partial class ClientsCell : ViewCell
	{
		public ClientsCell ()
		{
			InitializeComponent ();
		}
        #region "Name BindableProperty"
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(
                "Name",
                typeof(string),
                typeof(ClientsCell),
                null);
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        #endregion
        #region "Phone BindableProperty"
        public static readonly BindableProperty PhoneProperty =
            BindableProperty.Create(
                "Phone",
                typeof(string),
                typeof(ClientsCell),
                null);
        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
        #endregion
        #region "Priority BindableProperty"
        public static readonly BindableProperty PriorityProperty =
            BindableProperty.Create(
                "Priority",
                typeof(string),
                typeof(ClientsCell),
                null);
        public string Priority
        {
            get { return (string)GetValue(PriorityProperty); }
            set { SetValue(PriorityProperty, value); }
        }
        #endregion

        #region "Photo BindableProperty"
        public static readonly BindableProperty PhotoProperty =
            BindableProperty.Create(
                "Photo",
                typeof(ImageSource),
                typeof(ClientsCell),
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
            if(BindingContext!=null)
            {
                imgPhoto.Source = Photo;
                lblName.Text = Name;
                lblPhone.Text = Phone;
                lblPriority.Text = Priority;
            }
        }
        public void OnMore(object sender, EventArgs e)
        {
          
        }
        public void OnDelete(object sender, EventArgs e)
        {

        }
    }
}