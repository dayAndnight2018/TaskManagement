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
using System.Windows.Shapes;
using TaskManagement.Models;

namespace TaskManagement
{
    /// <summary>
    /// NewTaskWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public NewTaskWindow()
        {
            InitializeComponent();
            var now = DateTime.Now;
            this.startDate.SelectedDate = now;
            this.endDate.SelectedDate = now;
        }

        public NewTaskWindow(String Content, DateTime startTime, DateTime endTime)
        {
            InitializeComponent();
            this.content.Text = Content;
            this.startDate.SelectedDate = startTime;
            this.endDate.SelectedDate = endTime;
            this.startTime.SetTime(startTime);
            this.endTime.SetTime(endTime);
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            DateTime SelectedStartDate = (DateTime)startDate.SelectedDate;
            DateTime SelectedStartTime = startTime.GetTime();
            DateTime SelectedEndDate = (DateTime)endDate.SelectedDate;
            DateTime SelectedEndTime = endTime.GetTime();
            var now = DateTime.Now;

            DateTime start = new DateTime(SelectedStartDate.Year, SelectedStartDate.Month, SelectedStartDate.Day, SelectedStartTime.Hour, SelectedStartTime.Minute, SelectedStartTime.Second);
            DateTime end = new DateTime(SelectedEndDate.Year, SelectedEndDate.Month, SelectedEndDate.Day, SelectedEndTime.Hour, SelectedEndTime.Minute, SelectedEndTime.Second);
            if(start > end)
            {
                MessageBox.Show("请检查起止时间!");
                return;
            }

            if (now > end)
            {
                MessageBox.Show("已超时任务!");
                return;
            }

            var temp = new TaskItem
            {
                Content = this.content.Text.Trim(),
                StartTime = start,
                EndTime = end,
                Status = WpfControlLibrary.WPFControls.TaskStatus.即将开始,
                Id = Guid.NewGuid()
            };
            if (now > temp.EndTime)
            {
                temp.Status = WpfControlLibrary.WPFControls.TaskStatus.已超时;
            }
            else if (now > temp.StartTime)
            {
                temp.Status = WpfControlLibrary.WPFControls.TaskStatus.进行中;
            }
            else
            {
                temp.Status = WpfControlLibrary.WPFControls.TaskStatus.即将开始;
            }
            ConfigurationManager.AddTaskItem(temp);
            DialogResult = true;
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
