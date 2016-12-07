using System;
using System.Windows;

namespace ATP.Kiosk.Views {
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class AdamMessageBox : Window {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public TimeSpan ClosingInterval { get; set; }

        public AdamMessageBox() {
            InitializeComponent();
            this.Loaded += MessageBox_Loaded;
           
           
            //dispatcherTimer.Tick += DispatcherTimer_Tick;
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            //dispatcherTimer.Start();
            // this.DataContext = this;

        }


        //public static readonly DependencyProperty YesTextProperty = DependencyProperty.Register("YesText", typeof(string), typeof(AdamMessageBox), new FrameworkPropertyMetadata(null));
        //public string YesText {
        //    get { return (string)GetValue(YesTextProperty); }
        //    set { SetValue(YesTextProperty, value); }
        //}

        //public static readonly DependencyProperty NoTextProperty = DependencyProperty.Register("NoText", typeof(string), typeof(AdamMessageBox), new FrameworkPropertyMetadata(null));
        //public string NoText {
        //    get { return (string)GetValue(NoTextProperty); }
        //    set { SetValue(NoTextProperty, value); }
        //}




        private void DispatcherTimer_Tick(object sender, System.EventArgs e) {
            this.Close();
        }

        void MessageBox_Loaded(object sender, RoutedEventArgs e) {
            var w = System.Windows.SystemParameters.WorkArea.Width;
            var h = System.Windows.SystemParameters.WorkArea.Height;
            // PrintPopUpwindow.WindowState = WindowState.Maximized;
            this.Width = w * .5;
            this.Height = h * .4;
        }

        public string ErrorMessage {
            get { return TxtError.Text; }
            set {
                TxtError.Text = value;
            }
        }

        private void CmdOk_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
            this.Close();

        }

        private void BtnYes_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;

            this.Close();
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

        private void cmdDropKeys_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
        }
    }
}
