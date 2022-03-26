using System;
using Xamarin.Forms;

namespace QuickTourXFSample.Controls
{
    public class AnimatedView : ContentView
    {
        public AnimatedView()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
            {
                this.ScaleTo(0.95, 900, Easing.CubicInOut).ContinueWith((x) =>
                {
                    this.ScaleTo(1, 900, Easing.CubicInOut);
                });

                return true;
            });
        }
    }
}