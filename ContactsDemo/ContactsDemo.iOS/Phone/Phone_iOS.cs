using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactsDemo.Interfaces;
using CoreTelephony;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactsDemo.iOS.Phone.Phone_iOS))]
namespace ContactsDemo.iOS.Phone
{
    public class Phone_iOS : IPhone
    {
        public void PlaceCall(string number)
        {
            Device.BeginInvokeOnMainThread(() => {
               
                if (CanDevicePlacePhoneCall(number))
                {
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("telprompt://" + number));
                }
                else
                {
                    App.MasterNavigation.DisplayAlert("Cannot make call", "Check if SIM card present and phone can make calls", "Ok");
                }
            });
        }

        private bool CanDevicePlacePhoneCall(String pNumber)
        {
            if (UIApplication.SharedApplication.CanOpenUrl(new NSUrl(@"tel://" + pNumber)))
            {
                //A dialer is installed, now let's check if we can actually make a call.
                var networkInfo = new CTTelephonyNetworkInfo();
                var carrier = networkInfo.SubscriberCellularProvider;
                if (carrier == null)
                {
                    App.MasterNavigation.DisplayAlert("Cannot make call", "No carrier", "Ok");
                    return false;
                }
                var networkCode = carrier.MobileNetworkCode;
                if (String.IsNullOrEmpty(networkCode) || networkCode == "65535")
                {
                    //Device can not place a call
                    //SIM is probably inactive or not installed.
                    return false;
                }
                else
                {
                    //Device most likely can make calls.
                    return true;
                }
            }

            return false;
        }
    }
}