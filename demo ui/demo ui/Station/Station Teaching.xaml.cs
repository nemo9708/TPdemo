using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDemoApp.Station
{
    public partial class Station_Teaching : UserControl
    {
        private readonly Random _rnd = new Random();

        public Station_Teaching()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var content = btn.Content.ToString();
            string code = "0000";
            string desc = "Button Pressed";

            switch (content)
            {
                case "Cassette":
                    code = "C001";
                    desc = "Cassette button Check";
                    break;

                case "Stage":
                    code = "S002";
                    desc = "Stage Initialization Check";
                    break;

                case "Drive":
                    code = "D003";
                    desc = "Drive Servo On/Off Status";
                    break;

                case "Num.Value":
                    code = "N004";
                    desc = "Numeric Value Input Required";
                    break;

                case "Auto Reg.":
                    code = "A005";
                    desc = "Auto Registration Process Started";
                    break;

                case "Test":
                    code = "T007";
                    desc = "Test Mode Activated";
                    break;

                case "Sensor":
                    code = "E010";
                    desc = "Sensor Input Signal Error";
                    break;

                case "Calibrate":
                    code = "C099";
                    desc = "Calibration Sequence Ready";
                    break;

                case "Apply":
                    code = "P001";
                    desc = "Speed Parameter Applied";
                    break;
            }

            UpdateAlarm(code, desc, content);
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var pointName = btn.Content.ToString();
            UpdateAlarm("P_SEL", "Selected Point: " + pointName, pointName);

            // 좌표 랜덤 시뮬레이션
            TbR.Text = GetRandom(-180, 180);
            TbZ.Text = GetRandom(0, 500);
            TbT.Text = GetRandom(-180, 180);
            Tbr.Text = GetRandom(0, 200);
        }

        private string GetRandom(double min, double max)
        {
            var value = _rnd.NextDouble() * (max - min) + min;
            return value.ToString("F2");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SavePopup.IsOpen = true;
            UpdateAlarm("SV00", "Save Dialog Opened", "Save");
        }

        private void PopupClose_Click(object sender, RoutedEventArgs e)
        {
            SavePopup.IsOpen = false;
            UpdateAlarm("0000", "Ready", "System");
        }

        private void CloseTab_Click(object sender, RoutedEventArgs e)
        {
            MainContentBorder.Visibility = Visibility.Collapsed;
            EmptyMessage.Visibility = Visibility.Visible;
        }

        private void UpdateAlarm(string code, string description, string source)
        {
            AlarmTitle.Text = string.Format("Alarm Type : [{0}] {1} Check", code, source);
            AlarmDesc.Text = "Description : " + description;

            if (code.StartsWith("E"))
                AlarmTitle.Foreground = Brushes.Red;
            else
                AlarmTitle.Foreground = Brushes.Yellow;
        }
    }
}
