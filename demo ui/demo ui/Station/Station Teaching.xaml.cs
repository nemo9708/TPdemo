using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDemoApp.Station
{
    public partial class Station_Teaching : UserControl
    {
        public Station_Teaching()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string content = btn.Content.ToString();
                string code = "0000";
                string desc = "Button Pressed";

                switch (content)
                {
                    case "Cassette": code = "C001"; desc = "Cassette button Check"; break;
                    case "Stage": code = "S002"; desc = "Stage Initialization Check"; break;
                    case "Drive": code = "D003"; desc = "Drive Servo On/Off Status"; break;
                    case "Num.Value": code = "N004"; desc = "Numeric Value Input Required"; break;
                    case "Auto Reg.": code = "A005"; desc = "Auto Registration Process Started"; break;
                    case "Test": code = "T007"; desc = "Test Mode Activated"; break;
                    case "Sensor": code = "E010"; desc = "Sensor Input Signal Error"; break;
                    case "Calibrate": code = "C099"; desc = "Calibration Sequence Ready"; break;
                    case "Apply": code = "P001"; desc = "Speed Parameter Applied"; break;
                }

                UpdateAlarm(code, desc, content);
            }
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string pointName = btn.Content.ToString();
                UpdateAlarm("P_SEL", $"Selected Point: {pointName}", pointName);

                // R, Z, T, r 좌표값 시뮬레이션
                Random rnd = new Random();
                TbR.Text = (rnd.NextDouble() * 360 - 180).ToString("F2"); // R (deg)
                TbZ.Text = (rnd.NextDouble() * 500).ToString("F2");       // Z (mm)
                TbT.Text = (rnd.NextDouble() * 360 - 180).ToString("F2"); // T (deg)
                Tbr.Text = (rnd.NextDouble() * 200).ToString("F2");       // r (mm)
            }
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
            AlarmTitle.Text = $"Alarm Type : [{code}] {source} Check";
            AlarmDesc.Text = $"Description : {description}";

            if (code.StartsWith("E"))
                AlarmTitle.Foreground = Brushes.Red;
            else
                AlarmTitle.Foreground = Brushes.Yellow;
        }
    }
}