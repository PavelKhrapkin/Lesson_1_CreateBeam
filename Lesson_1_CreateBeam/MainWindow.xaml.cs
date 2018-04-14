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
using Tekla.Structures;
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;

namespace Lesson_1_CreateBeam
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
            Model Model = new Model();
            Beam NewBeam = new Beam();
            NewBeam.StartPoint = new T3D.Point(0, 0, 0);
            NewBeam.EndPoint = new T3D.Point(1000, 0, 0);
            NewBeam.Profile.ProfileString = "I40B1_20_93";
            NewBeam.Material.MaterialString = "C245";
            NewBeam.Class = "4";
            NewBeam.Insert();
            Model.CommitChanges();
        }
    }
}
