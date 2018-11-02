using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MouseWheelTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CoreWindow.GetForCurrentThread().PointerWheelChanged += MainPage_PointerWheelChanged;
            this.Loaded += MainPage_Loaded;
            Window.Current.Content.PreviewKeyDown += Content_PreviewKeyDown;


        }
        private void Content_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            e.Handled = e.Key == VirtualKey.Tab ? true : false;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {   // RootLayout is Grid name.
            childrenCount = RootLayout.Children.Count;
        }

        private int childrenCount; // sub items count 
        private int index; // index of focus control
        private bool IsFirt = true; // first use flag
        private void MainPage_PointerWheelChanged(CoreWindow sender, PointerEventArgs args)
        {
            //get mouse wheel delta
            var value = args.CurrentPoint.Properties.MouseWheelDelta;

            if (IsFirt)
            {
                switch (value)
                {
                    case 120:

                        index = childrenCount;
                        if (index == 0)
                        {
                            index = childrenCount - 1;
                        }
                        else
                        {
                            index--;
                        }
                        break;

                    case -120:

                        index = -1;

                        if (index == childrenCount - 1)
                        {
                            index = 0;
                        }
                        else
                        {
                            index++;
                        }
                        break;

                }

                IsFirt = false;
            }
            else
            {
                switch (value)
                {
                    case 120:

                        if (index == 0)
                        {
                            index = childrenCount - 1;
                        }
                        else
                        {
                            index--;
                        }

                        break;

                    case -120:

                        if (index == childrenCount - 1)
                        {
                            index = 0;
                        }
                        else
                        {
                            index++;
                        }

                        break;
                }

            }
            // focus control with index
            var element = RootLayout.Children[index] as Control;
            element.Focus(FocusState.Keyboard);

        }




    }
}
