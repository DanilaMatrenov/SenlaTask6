using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SenlaTask6WPFNET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ClassBuffer> buffers = new List<ClassBuffer>();
        public int i=0;
        public int mweight = 0;
        public int weight = 0;
        public string predm;
        public int costs = 0;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ценность груза " + buffers.Sum(x => x.Cost).ToString());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mweight=int.Parse(txtMaxWeight.Text);
            weight=int.Parse(txtWeight.Text);
            costs=int.Parse(txtCost.Text);
            if(i==0 && (mweight > weight))
            {
                buffers.Add(new ClassBuffer { Name = txtName.Text, Cost = costs, Weight = weight });
                dtRukzak.ItemsSource = buffers.ToArray();
                txtMaxWeight.IsEnabled = false;
                
            }
            else if (i == 0 && (mweight <= weight))
            {
                MessageBox.Show("Перебор по весу");
                i--;
            }
            if ((buffers.Sum(x => x.Weight) < mweight) && i >= 1)
            {
               buffers.Add(new ClassBuffer { Name = txtName.Text, Cost = int.Parse(txtCost.Text.ToString()), Weight = int.Parse(txtWeight.Text.ToString()) });
            dtRukzak.ItemsSource= buffers.ToArray();
            }
            else if((buffers.Sum(x => x.Weight) >= mweight) && i >= 1)
            {
                MessageBox.Show("Перебор по весу");
            }
            i++;
        }
    }
}
