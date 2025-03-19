using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Krakout;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
        double xSeb = 5;
        double ySeb = 5;
        int alapySeb = 5;
        int pontszam = 0;
    public MainWindow()
    {
        InitializeComponent();
        var ido = new DispatcherTimer();
        ido.Interval = TimeSpan.FromMilliseconds(1);
        ido.Tick += mozgatas;
        ido.Start();
    }

    private void mozgatas(object? sender, EventArgs e)
    {
        //játékos mozgatása
        Canvas.SetLeft(jatekos, Mouse.GetPosition(jatekter).X);
        var labdaY = Canvas.GetTop(labda);
        var labdaX = Canvas.GetLeft(labda);
        //nézzük a képernyő határait
        if (labdaX < 0 || labdaX > 950) xSeb *= -1;
        if (labdaY > 550)
        {
            //vonjon le egy pontot
            pontszam = 0;
          lbPontszam.Content = 0;
          Canvas.SetTop(labda, 0);
          labdaY = 0;
          ySeb = alapySeb;
        }

        if (labdaY < 0) ySeb *= -1;
        // ütközési vizsgálat a labda és az ütő között
        var jatekosX = Canvas.GetLeft(jatekos);
        var jatekosY = Canvas.GetTop(jatekos);
        if (labdaX + labda.Width > jatekosX
            && labdaX < jatekosX + jatekos.Width
            && labdaY + labda.Height > jatekosY
            && labdaY < jatekosY + jatekos.Height)
        {
            ySeb *= -1.3;
            lbPontszam.Content = ++pontszam;
        }
            // a labda mozgatása
            Canvas.SetLeft(labda, labdaX + xSeb);
        Canvas.SetTop(labda, labdaY + ySeb);

    }
}