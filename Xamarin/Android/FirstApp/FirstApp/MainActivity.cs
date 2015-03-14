using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;

namespace FirstApp
{
    [Activity(Label = "FirstApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate
            //{
            //    button.Text = string.Format("{0} clicks!", count++);
            //};

            //EditText et = FindViewById<EditText>(Resource.Id.editText1);

            var translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            var callButton = FindViewById<Button>(Resource.Id.CallButton);

            var phoneNumberEditText = FindViewById<EditText>(Resource.Id.PhoneNumberText);

            translateButton.Click += delegate
            {
                //keyboard dismissal
                var imm = (InputMethodManager) GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(phoneNumberEditText.WindowToken, 0);
            };

            callButton.Click += delegate
            {

            };

            //var dialog = new AlertDialog.Builder(this);

            //dialog.SetTitle("Title");
            //dialog.SetMessage("Message Goes Here");

            //var callIntent = new Intent(Intent.ActionCall);

            //callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));

            //StartActivity(callIntent);
        }
    }
}

