using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WFP_CONNECT_DB
{
    public class ViewModel: INotifyPropertyChanged
    {

        private string StText_value = "Aguardando acción";

        public string StText
        {
            get { return StText_value; }
            set
            {
                if (value != StText_value)

                    StText_value = value;
                    OnPropertyChanged("StStatus");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;



        //private ImageSource ImageSource;

        //public string ist
        //{
        //    get { return ImageSource; }
        //    set { ImageSource = value; }
        //}

        public string Status
        {
            get { return this.StText; }

            set
            {
                if (value != this.StText)
                {
                    this.StText = value;
                    NotifyPropertyChanged("StStatus");
                }
            }
        }
        public BitmapImage StatusImage { get; internal set; }
        //public event PropertyChangedEventHandler PropertyChanged;
        ////private string StText = String.Empty;
        //private string StText = "Perro";
        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        //public string Status
        //{
        //    get { return this.StText; }

        //    set
        //    {
        //        if (value != this.StText)
        //        {
        //            this.StText = value;
        //            NotifyPropertyChanged("StText");
        //        }
        //    }
        //}
    }
    //get { return @"Resources/disk_blue_error.png"; }


    //    //    public string Status { get; set; }

    //    //public event PropertyChangedEventHandler PropertyChanged;
    //    string _StText = "Bob";

    //    public string StText
    //    {
    //        get { return _StText; }
    //        set { _StText = value; }
    //    }

    //    public string FullName
    //    {
    //        get { return string.Format("{0}", StText); }
    //    }
    //}
}