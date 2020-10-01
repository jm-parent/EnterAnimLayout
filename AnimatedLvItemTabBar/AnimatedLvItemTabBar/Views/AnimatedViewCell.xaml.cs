using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnimatedLvItemTabBar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimatedLvItemTabBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimatedViewCell : ViewCell
    {
        public AnimatedViewCell()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var aze =((StackLayout)this.LayoutMy);
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(200 * ((AboutViewModel.ItemModel)BindingContext).Index,CancellationToken.None);
                if (AnimationTypeVal == AnimationType.Fade)
                {
                    await aze.FadeTo(1, 300);
                }
                else if (AnimationTypeVal == AnimationType.Scale)
                {
                    await aze.FadeTo(1, 100);
                    await aze.ScaleTo(1.2, 170, easing: Easing.Linear);
                    await aze.ScaleTo(1, 170, easing: Easing.Linear);
                }
                else if (AnimationTypeVal == AnimationType.ScaleDown)
                {
                    await aze.FadeTo(1, 100);
                    await aze.ScaleTo(0.95, 100, easing: Easing.Linear);
                    await aze.ScaleTo(1, 100, easing: Easing.Linear);
                }
                else if (AnimationTypeVal == AnimationType.Rotate)
                {
                    await aze.FadeTo(1, 100);
                    await aze.RotateTo(360, 200, easing: Easing.Linear);
                    aze.Rotation = 0;
                }
                else if (AnimationTypeVal == AnimationType.FlipHorizontal)
                {
                    await aze.FadeTo(1, 100);
                    // Perform half of the flip
                    await aze.RotateYTo(90, 200);
                    await aze.RotateYTo(0, 200);
                }
                else if (AnimationTypeVal == AnimationType.FlipVertical)
                {
                    await aze.FadeTo(1, 100);
                    // Perform half of the flip
                    await aze.RotateXTo(90, 200);
                    await aze.RotateXTo(0, 200);
                }
                else if (AnimationTypeVal == AnimationType.Shake)
                {
                    await aze.FadeTo(1, 100);
                    await aze.TranslateTo(-15, 0, 50);
                    await aze.TranslateTo(15, 0, 50);
                    await aze.TranslateTo(-10, 0, 50);
                    await aze.TranslateTo(10, 0, 50);
                    await aze.TranslateTo(-5, 0, 50);
                    await aze.TranslateTo(5, 0, 50);
                    aze.TranslationX = 0;
                }

            });
         
        }

        public static readonly BindableProperty AnimationTypeProperty =
            BindableProperty.Create(nameof(AnimationTypeVal), typeof(AnimationType), typeof(AnimatedViewCell), AnimationType.Fade);

        public AnimationType AnimationTypeVal
        {
            get { return (AnimationType)GetValue(AnimationTypeProperty); }
            set { SetValue(AnimationTypeProperty, value); }
        }
        public enum AnimationType
        {
            Fade,
            FlipHorizontal,
            FlipVertical,
            Rotate,
            Scale,
            Shake,
            ScaleDown
        }
    }
    
}