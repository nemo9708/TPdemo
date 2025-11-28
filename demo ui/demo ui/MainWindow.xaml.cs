using System.Windows;
using System.Windows.Controls;

namespace WpfDemoApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 초기 설정 등 필요한 코드를 여기에 추가합니다.
            // Title = $"WPF Demo Screen - {DateTime.Now.Year}"; // C# 6.0 문자열 보간 예시
        }

        // 모든 메뉴 버튼에 대한 단일 클릭 이벤트 핸들러
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // 이벤트를 발생시킨 버튼을 가져옵니다.
            if (sender is Button clickedButton)
            {
                // 버튼의 Content와 Tag를 사용하여 어떤 버튼이 클릭되었는지 확인합니다.
                string menuName = clickedButton.Content?.ToString() ?? "Unknown";

                // XAML에서 Tag="StationTeaching" 등으로 설정했습니다.
                string tagValue = clickedButton.Tag?.ToString();

                // 실제 애플리케이션에서는 MainContentArea의 Content를 UserControl로 변경하는 로직이 들어갑니다.
                MessageBox.Show($"'{menuName}' 버튼이 클릭되었습니다. (Tag: {tagValue})", "메뉴 클릭 이벤트");
            }
        }
    }
}