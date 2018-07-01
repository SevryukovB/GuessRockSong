using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GuessRockSong.UiHelpers;
using GuessRockSong.ViewModels;
using Xamarin.Forms;

namespace GuessRockSong.Controls
{

    public class ListViewSelectedItemBehavior : Behavior<ListView>
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += OnListViewItemSelected;
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item  = (GameUiHelper) e.SelectedItem;
            if (sender is ListView lv)
            {
                //block choose second variant for user
                lv.IsEnabled = false;

                if (item.IsTrue)
                    item.BandTextColor = Color.FromHex("#57beff");
                else
                {
                    item.BandTextColor = Color.FromHex("#f93c6a");

                    var answers = (IEnumerable<GameUiHelper>)lv.ItemsSource;
                    var trueAnswer = answers.FirstOrDefault(z => z.IsTrue);
                    trueAnswer.BandTextColor = Color.FromHex("#57beff");
                    trueAnswer.SoundTextColor = Color.FromHex("#7e98d0");
                }
                item.SoundTextColor = Color.FromHex("#7e98d0");

                if (lv.BindingContext is GamePageViewModel vm)
                    vm.CheckAnswer(item, true);

                //unblock after 2 sec
                await Task.Delay(2000);
                lv.IsEnabled = true;
            }
        }
        
        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= OnListViewItemSelected;
        }
    }
}
