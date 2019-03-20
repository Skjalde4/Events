using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Events.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateEvent : Page
    {
        public CreateEvent()
        {
            this.InitializeComponent();
        }

        
        private void Grid_Loading(FrameworkElement sender, object args)
        {
            pnlHide.Visibility = Visibility.Collapsed;
        }

        private void btnBirthday_Click(object sender, RoutedEventArgs e)
        {
            pnlHide.Visibility = Visibility.Visible;
            if (cmbCategory.SelectedItem == btnBirthday)
            {
                txtCategoryName.Text = "Birthday";
            }
        }

        private void btnWedding_Click(object sender, RoutedEventArgs e)
        {
            pnlHide.Visibility = Visibility.Visible;
            if (cmbCategory.SelectedItem == btnWedding)
            {
                txtCategoryName.Text = "Wedding";
            }
        }

        private void btnBachlorette_Click(object sender, RoutedEventArgs e)
        {
            pnlHide.Visibility = Visibility.Visible;
            if (cmbCategory.SelectedItem == btnBachlorette)
            {
                txtCategoryName.Text = "Bachlorette";
            }
        }

        private void btnAnniversary_Click(object sender, RoutedEventArgs e)
        {
            pnlHide.Visibility = Visibility.Visible;
            if (cmbCategory.SelectedItem == btnAnniversary)
            {
                txtCategoryName.Text = "Anniversary";
            }
        }

        private void btnValentinesDay_Click(object sender, RoutedEventArgs e)
        {
            pnlHide.Visibility = Visibility.Visible;
            if (cmbCategory.SelectedItem == btnValentinesDay)
            {
                txtCategoryName.Text = "Valentines Day";
            }
        }

        //private void CheckEvent()
        //{
        //    if (txbDescription.Text != "" && txbID.Text != "" && txbName.Text != "" && txbPlace.Text != "" && Calendar.PlaceholderText != "select a date")
        //    {
        //        ((Frame)Window.Current.Content).Navigate(typeof(Confirmation));
        //    }
        //}

        private void BtnRequestEvent_Click(object sender, RoutedEventArgs e)
        {
        //    if (txbDescription.Text != "" && txbID.Text != "" && txbName.Text != "" && txbPlace.Text != "" && Calendar.PlaceholderText != "select a date")
        //    {
        //        ((Frame) Window.Current.Content).Navigate(typeof(Confirmation));
        //    }
        }
    }
}
