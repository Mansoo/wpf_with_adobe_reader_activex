using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


// https://csharp.hotexamples.com/examples/-/AxAcroPDFLib.AxAcroPDF/-/php-axacropdflib.axacropdf-class-examples.html
// https://stackoverflow.com/questions/29952970/trying-to-open-a-pdf-with-axacropdflib
// WPF AxAcroPDFLib.AxAcroPDF   
//   on google.com

namespace WpfApp1
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
        AxAcroPDFLib.AxAcroPDF _adobeReader = new AxAcroPDFLib.AxAcroPDF();

        private void WindowsFormsHost_Loaded(object sender, RoutedEventArgs e)
        {
            this._adobeReader = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this._adobeReader)).BeginInit();
            this._adobeReader.Dock = System.Windows.Forms.DockStyle.Fill;
            this._adobeReader.Enabled = true;
            this._adobeReader.Location = new System.Drawing.Point(103, 3);
            this._adobeReader.Name = "_adobeReader";
            //this._adobeReader.TabIndex = 5;
            ((System.ComponentModel.ISupportInitialize)(this._adobeReader)).EndInit();

            A.Child = _adobeReader;
            var inst = (AcroPDFLib.IAcroAXDocShim) _adobeReader.GetOcx();
            inst.setShowToolbar(false);
            //bool ok = inst.LoadFile(@"c:\a.pdf");
            //Debug.Assert(ok);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            A.Child = null;
            _adobeReader.Enabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var inst = (AcroPDFLib.IAcroAXDocShim)_adobeReader.GetOcx();
                inst.src = openFileDialog.FileName;
            }
        }
    }
}
