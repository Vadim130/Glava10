using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace _10._1._3_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private CancellationTokenSource _cts;
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.Enabled = false;
            CancelButton.Enabled = false;
            try
            {
                _cts = new CancellationTokenSource();
                CancellationToken token = _cts.Token;
                await Task.Delay(TimeSpan.FromSeconds(5), token);
                MessageBox.Show("Delay completed successfully.");
            }
 catch (OperationCanceledException)
            {
                MessageBox.Show("Delay was canceled.");
            }
            catch (Exception)
            {
                MessageBox.Show("Delay completed with error.");
                throw;
            }
            finally
            {
                StartButton.Enabled = true;
                CancelButton.Enabled = true;
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
            CancelButton.Enabled = false;
        }
    }

}
