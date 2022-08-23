using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCenterDemo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Analytics.TrackEvent("Button clicked", new Dictionary<string, string> {
        { "Category", "MainWindow" },
        { "FileName", $"{Guid.NewGuid()}.txt" }
      });
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
      try
      {
        throw new NullReferenceException($"{Guid.NewGuid()}");
      }
      catch (Exception exception)
      {
        var attachments = new ErrorAttachmentLog[]
        {
        ErrorAttachmentLog.AttachmentWithText("Hello world!", "hello.txt"),
        ErrorAttachmentLog.AttachmentWithBinary(Encoding.UTF8.GetBytes("Fake image"), "fake_image.jpeg", "image/jpeg")
        };
        Crashes.TrackError(exception, attachments: attachments);
      }
    }
  }
}
