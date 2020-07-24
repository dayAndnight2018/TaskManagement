using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManagement.Models;
using WpfControlLibrary.WPFControls;

namespace TaskManagement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer = new Timer();
        bool check = false;
        public MainWindow()
        {
            InitializeComponent();
            this.onTaskBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, onTaskBtn));
            timer.Interval = 1000;
            timer.Elapsed += (o, e) =>
            {
                var now = DateTime.Now; 
                if(now.Second == 0)
                {
                    bool flag = false;
                    foreach(var item in ConfigurationManager.GetTaskItems())
                    {
                        var old = item.Status;
                        WpfControlLibrary.WPFControls.TaskStatus temp;
                        if(now > item.EndTime)
                        {
                            temp = WpfControlLibrary.WPFControls.TaskStatus.已超时;
                        }
                        else if(now > item.StartTime)
                        {
                            temp = WpfControlLibrary.WPFControls.TaskStatus.进行中;
                        }
                        else
                        {
                            temp = WpfControlLibrary.WPFControls.TaskStatus.即将开始;
                        }
                        if(item.Status!=temp)
                        {
                            ConfigurationManager.UpdateStatus(item.Id, temp);
                            flag = true;
                        }
                    }
                    if(flag && check)
                    {
                        this.onTaskBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, onTaskBtn));
                    }
                }
            };
            timer.Enabled = true;
            timer.Start();
        }

        private void minBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            ConfigurationManager.SaveChanges();
            this.Close();
        }

        private void onTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            check = true;
            onTaskBtn.Background = new SolidColorBrush(Colors.Red);
            finishedBtn.Background = new SolidColorBrush(Color.FromRgb(0, 52, 114));
            canceledBtn.Background = new SolidColorBrush(Color.FromRgb(0, 52, 114));

            container.Children.Clear();
            foreach (var item in ConfigurationManager.GetTaskItems())
            {
                var control = new WpfControlLibrary.WPFControls.TaskItem(item.Content, item.StartTime, item.EndTime, item.Status);
                control.Margin = new Thickness(5);
                control.finishedCbx_CheckedHandler(new RoutedEventHandler((o, args) =>
                {
                    ConfigurationManager.AddFinishedTask(item.Id);
                    this.onTaskBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, onTaskBtn));
                }));
                control.cancelCbx_CheckedHandler(new RoutedEventHandler((o, args) =>
                {
                    ConfigurationManager.AddCanceledTask(item.Id);
                    this.onTaskBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, onTaskBtn));
                }));
                control.deleteBtnHandler(new RoutedEventHandler((o, args) =>
                {
                    ConfigurationManager.RemoveTaskItem(item.Id);
                    this.onTaskBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, onTaskBtn));
                }));
                control.editBtnHandler(new RoutedEventHandler((o, args) =>
                {
                    if((bool)new NewTaskWindow(item.Content, item.StartTime, item.EndTime).ShowDialog())
                    {
                        this.onTaskBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, onTaskBtn));
                    }                    
                }));
                container.Children.Add(control);
            }           

        }

        private void finishedBtn_Click(object sender, RoutedEventArgs e)
        {
            check = false;
            finishedBtn.Background = new SolidColorBrush(Colors.Red);
            onTaskBtn.Background = new SolidColorBrush(Color.FromRgb(0, 52, 114));
            canceledBtn.Background = new SolidColorBrush(Color.FromRgb(0, 52, 114));

            container.Children.Clear();
            foreach (var item in ConfigurationManager.GetFinishedTasks())
            {
                var control = new WpfControlLibrary.WPFControls.FinishedTaskItem(item.Content, item.StartTime, item.EndTime,item.FinishTime,true);
                control.Margin = new Thickness(5);
                control.deleteBtnHandler(new RoutedEventHandler((o, args) =>
                {
                    ConfigurationManager.RemoveFinishedTask(item.Id);
                    this.finishedBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, finishedBtn));
                }));
                container.Children.Add(control);
            }
        }

        private void canceledBtn_Click(object sender, RoutedEventArgs e)
        {
            check = false;
            canceledBtn.Background = new SolidColorBrush(Colors.Red);
            onTaskBtn.Background = new SolidColorBrush(Color.FromRgb(0, 52, 114));
            finishedBtn.Background = new SolidColorBrush(Color.FromRgb(0, 52, 114));

            container.Children.Clear();
            foreach (var item in ConfigurationManager.GetCanceledTasks())
            {
                var control = new WpfControlLibrary.WPFControls.CanceledTaskItem(item.Content, item.StartTime, item.EndTime, item.CancelTime, true);
                control.Margin = new Thickness(5);
                control.deleteBtnHandler(new RoutedEventHandler((o, args) =>
                {
                    ConfigurationManager.RemoveCanceledTask(item.Id);
                    this.canceledBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, canceledBtn));
                }));
                container.Children.Add(control);
            }
        }

        private void newTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)new NewTaskWindow().ShowDialog())
            {
                this.onTaskBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, onTaskBtn));
            }
        }
    }
}
