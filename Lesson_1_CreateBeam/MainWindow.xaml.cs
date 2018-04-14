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
using TSMUI = Tekla.Structures.Model.UI;

namespace Lesson_1_CreateBeam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model Model;

        public MainWindow()
        {
            InitializeComponent();

            try { Model = new Model(); }
            catch { throw new Exception("Tekla is not connected"); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Beam NewBeam = new Beam();
            NewBeam.StartPoint = new T3D.Point(0, 0, 0);
            NewBeam.EndPoint = new T3D.Point(1000, 0, 0);
            NewBeam.Profile.ProfileString = "I40B1_20_93";
            NewBeam.Material.MaterialString = "C245";
            NewBeam.Class = "4";
            NewBeam.Insert();
            Model.CommitChanges();
        }

        private void Button_ModifySelected_Click(object sender, RoutedEventArgs e)
        {
            TSMUI.ModelObjectSelector GetSelectedObjects = new TSMUI.ModelObjectSelector();
            ModelObjectEnumerator SelectedObjects = GetSelectedObjects.GetSelectedObjects();
            while(SelectedObjects.MoveNext())
            {
                Beam ThisBeam = SelectedObjects.Current as Beam;
                if(ThisBeam != null)
                {
                    ThisBeam.Profile.ProfileString = "I20_8239_89";
                    ThisBeam.Class = "6";
                    ThisBeam.StartPoint = new T3D.Point(0, 1000, 0);
                    ThisBeam.EndPoint = new T3D.Point(4000, 1000, 0);
                    ThisBeam.Modify();
                }
            }
            Model.CommitChanges();
        }

        private void Button_ModifyByClick_Click(object sender, RoutedEventArgs e)
        {
            TSMUI.Picker Picker = new TSMUI.Picker();
            Beam ThisBeam = Picker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as Beam;
            if(ThisBeam != null)
            {
                ThisBeam.Profile.ProfileString = "I20_8239_89";
                ThisBeam.Class = "6";
                ThisBeam.StartPoint = new T3D.Point(0, 1000, 0);
                ThisBeam.EndPoint = new T3D.Point(4000, 1000, 0);
                ThisBeam.Modify();

                Model.CommitChanges();
            }
        }
    }
}
