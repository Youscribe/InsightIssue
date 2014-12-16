using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using ModernHttpClient;

namespace TestInsight
{
	[Activity (Label = "TestInsight", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected async override void OnCreate (Bundle bundle)
		{
			Xamarin.Insights.Initialize ("{InsightAppId}", this);

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var httpClient = new HttpClient (new NativeMessageHandler ());

			try
			{
				var response = await httpClient.GetAsync ("http://sturegnzngpzgzpgzego.br");
			}
			catch (Exception e) {
				Xamarin.Insights.Report (e);
			}

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}


