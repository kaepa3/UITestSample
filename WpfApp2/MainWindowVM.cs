using Livet;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp2.Sub;

namespace WpfApp2
{
    public class MainWindowVM : ViewModel
    {
        public ReactiveProperty<string> Text { get; set; } = new ReactiveProperty<string>("first");
        public ReactiveCommand ButtonCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand DisplayWindowCommand { get; set; } = new ReactiveCommand();


        public MainWindowVM()
        {
            this.ButtonCommand.Subscribe(ButtonAction);
            this.DisplayWindowCommand.Subscribe(DisplayWindowAction);
        }

        void DisplayWindowAction()
        {
            var wnd = new SubWindow();
            wnd.Show();
        }
        void ButtonAction()
        {
            this.Text.Value = "Click";

        }
    }

}
