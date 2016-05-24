
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Testing_v_0._1.BO;
using Testing_v_0._1.DAL;
using Testing_v_0._1.Models;

namespace Testing_v_0._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerator<string> _slideEnumerator;
        private IEnumerator<TestItem> _testItemEnumerator;

        private ItemService ItemService { get; set; }
        private Topic CurrentTopic { get; set; }

        public MainWindow()
        {
            ItemService = new ItemService();

            InitializeComponent();

            DataContext = ItemService.GetTopics();

            TopicCanvas.Visibility = Visibility.Hidden;
            SlideShowCanvas.Visibility = Visibility.Hidden;
            TestCanvas.Visibility = Visibility.Hidden;
            ResultCanvas.Visibility = Visibility.Hidden;
        }
        
        private void Topic1_Start_OnClick(object sender, RoutedEventArgs e)
        {
            ShowTopic(sender);
        }

        private void Topic2_Start_OnClick(object sender, RoutedEventArgs e)
        {
            ShowTopic(sender);
        }

        private void Topic3_Start_OnClick(object sender, RoutedEventArgs e)
        {
            ShowTopic(sender);
        }

        private void TopicStartSlideShow_OnClick(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(350);
            CurrentTopic = (Topic)(sender as Button).DataContext;

            TopicCanvas.Visibility = Visibility.Hidden;
            SlideShowCanvas.Visibility = Visibility.Visible;

            _slideEnumerator = CurrentTopic.SlideShow.Slides.GetEnumerator();
            _slideEnumerator.MoveNext();

            DataContext = _slideEnumerator.Current;
        }

        private void NextSlideButton_OnClick(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(350);

            if (_slideEnumerator.MoveNext())
            {
                DataContext = _slideEnumerator.Current;
            }
            else
            {
                SlideShowCanvas.Visibility = Visibility.Hidden;
                TopicCanvas.Visibility = Visibility.Visible;

                DataContext = CurrentTopic;
            }
        }

        private void TopicStartTest_OnClick(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(350);

            StartTest(sender);
        }

        private void StartTest(object sender)
        {
            CurrentTopic = (Topic)(sender as Button).DataContext;

            TopicCanvas.Visibility = Visibility.Hidden;
            TestCanvas.Visibility = Visibility.Visible;

            _testItemEnumerator = CurrentTopic.Test.Items.GetEnumerator();
            _testItemEnumerator.MoveNext();

            DataContext = _testItemEnumerator.Current;
        }

        private void Answer1_OnClick(object sender, RoutedEventArgs e)
        {
            CalculateAnswer(sender);
        }

        private void Answer2_OnClick(object sender, RoutedEventArgs e)
        {
            CalculateAnswer(sender);
        }

        private void Answer3_OnClick(object sender, RoutedEventArgs e)
        {
            CalculateAnswer(sender);
        }

        private void ToMainCanvas_OnClick(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(400);

            TopicCanvas.Visibility = Visibility.Hidden;
            MianWindowCanvas.Visibility = Visibility.Visible;

            DataContext = ItemService.GetTopics();
        }

        private void ShowTopic(object sender)
        {
            Thread.Sleep(350);
            var topic = (Topic)(sender as Button).DataContext;
            
            MianWindowCanvas.Visibility = Visibility.Hidden;
            TopicCanvas.Visibility = Visibility.Visible;

            DataContext = topic;
        }

        private void CalculateAnswer(object sender)
        {
            Thread.Sleep(400);

            var answer = (Answer)(sender as Button).DataContext;
            _testItemEnumerator.Current.Answered = answer;

            if (_testItemEnumerator.MoveNext())
            {
                DataContext = _testItemEnumerator.Current;
            }
            else
            {
                var totalQuestions = CurrentTopic.Test.Items.Count;

                var resultModel = new ResultModel
                {
                    CorrectAnswers = CurrentTopic.Test.Items.Count(x => x.Answered.IsCorrect),
                    WrongAnswers = CurrentTopic.Test.Items.Count(x => !x.Answered.IsCorrect)
                };

                TestCanvas.Visibility = Visibility.Hidden;
                ResultCanvas.Visibility = Visibility.Visible;

                DataContext = resultModel;
            }
        }

        private void Return_To_Main_Button_OnClick(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(400);

            ResultCanvas.Visibility = Visibility.Hidden;
            MianWindowCanvas.Visibility = Visibility.Visible;

            DataContext = ItemService.GetTopics();
        }


    }
}
