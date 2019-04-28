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
	public partial class MessagePage : ContentPage
	{
        string Post;
        string Date;
        string Theme;
        string Head;
        string Detail;
		public MessagePage (string thePost,string theDate,string theTheme,string theHead,string theContent)
		{
			InitializeComponent ();
            Post = thePost;
            Date = theDate;
            Theme = theTheme;
            Head = theHead;
            Detail = theContent;

            newsPost.Text = Post;
            newsTime.Text = Date;
            newsTheme.Text = Theme;
            newsHead.Text = Head;
            newsContent.Text = Detail;

		}
	}
}