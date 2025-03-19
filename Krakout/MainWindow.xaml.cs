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
        if (labdaX > 950) xSeb = -5;
        if (labdaX < 0) xSeb = 5;
        if (labdaY > 550)
        { ySeb = -5;
            //vonjon le egy pontot
          lbPontszam.Content = --pontszam;
        }

        if (labdaY < 0) ySeb = 5;
        // ütközési vizsgálat a labda és az ütő között
        var jatekosX = Canvas.GetLeft(jatekos);
        var jatekosY = Canvas.GetTop(jatekos);
        if (labdaX + labda.Width > jatekosX
            && labdaX < jatekosX + jatekos.Width
            && labdaY + labda.Height > jatekosY
            && labdaY < jatekosY + jatekos.Height)
        {
            ySeb = -5;
            lbPontszam.Content = ++pontszam;
        }
            // a labda mozgatása
            Canvas.SetLeft(labda, labdaX + xSeb);
        Canvas.SetTop(labda, labdaY + ySeb);

    }
}