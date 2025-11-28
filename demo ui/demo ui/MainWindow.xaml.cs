using System.Windows;
using System.Windows.Controls;
// Station 폴더의 네임스페이스를 추가합니다.
using WpfDemoApp.Station;

namespace WpfDemoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string tag = clickedButton.Tag?.ToString();

                // Tag 값에 따라 오른쪽 화면 교체
                switch (tag)
                {
                    case "StationTeaching":
                        // Station_Teaching 화면을 생성하여 컨텐츠로 설정
                        MainContentArea.Content = new Station_Teaching();
                        break;

                    case "Setting":
                        // (예시) Setting 화면이 있다면 연결
                        // MainContentArea.Content = new SettingView();
                        MessageBox.Show("Setting 화면은 아직 구현되지 않았습니다.");
                        break;

                    default:
                        MessageBox.Show($"'{clickedButton.Content}' 버튼이 클릭되었습니다.");
                        break;
                }
            }
        }
    }
}