using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_v_0._1.BO;
using Testing_v_0._1.Models;

namespace Testing_v_0._1.DAL
{
    public class ItemService
    {
        private List<Topic> Topics { get; set; }

        public ItemService()
        {
            Topics = new List<Topic>();

            var topic1 = new Topic
            {
                Id = 1,
                Title = "Первая тема",

                SlideShow = new SlideShow
                {
                    Id = 1,
                    Title = "Слайд-шоу первой темы",
                    Slides = new List<string>
                  {
                      "Первый текстовый блок",
                      "второй текстовый блок",
                      "третий текстовый блок"
                  }
                },

                Test = new Test
                {
                    Id = 1,
                    Title = "Тест первой темы",
                    Items = new List<TestItem>
                    {
                        new TestItem
                        {
                            Id = 1,
                            Question = "Первый вопрос",

                            CoorectAnswer = new Answer {Id = 7, IsCorrect = true, Content = "правильный"},

                            WrongAnswers = new List<Answer>
                            {
                                new Answer {Content = "неправильный", Id = 1, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 2, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 3, IsCorrect = false}
                            }
                        },
                        new TestItem
                        {
                            Id = 2,
                            Question = "второй вопрос",

                            CoorectAnswer = new Answer {Id = 8, IsCorrect = true, Content = "правильный"},

                            WrongAnswers = new List<Answer>
                            {
                                new Answer {Content = "неправильный", Id = 4, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 5, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 6, IsCorrect = false}
                            }
                        },
                        new TestItem
                        {
                            Id = 3,
                            Question = "третий вопрос",

                            CoorectAnswer = new Answer {Id = 9, IsCorrect = true, Content = "правильный"},

                            WrongAnswers = new List<Answer>
                            {
                                new Answer {Content = "неправильный", Id = 10, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 11, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 12, IsCorrect = false}
                            }
                        }
                    }
                },

            };

            var topic2 = new Topic
            {
                Id = 2,
                Title = "Вторая тема",

                SlideShow = new SlideShow
                {
                    Id = 2,
                    Title = "Слайд-шоу второй темы",
                    Slides = new List<string>
                  {
                      "Первый текстовый блок",
                      "второй текстовый блок",
                      "третий текстовый блок"
                  }
                },

                Test = new Test
                {
                    Id = 2,
                    Title = "Тест второй темы",
                    Items = new List<TestItem>
                    {
                        new TestItem
                        {
                            Id = 4,
                            Question = "первый вопрос",

                            CoorectAnswer = new Answer {Id = 13, IsCorrect = true, Content = "правильный"},

                            WrongAnswers = new List<Answer>
                            {
                                new Answer {Content = "неправильный", Id = 14, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 15, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 16, IsCorrect = false}
                            }
                        },
                        new TestItem
                        {
                            Id = 5,
                            Question = "второй вопрос",

                            CoorectAnswer = new Answer {Id = 17, IsCorrect = true, Content = "правильный"},

                            WrongAnswers = new List<Answer>
                            {
                                new Answer {Content = "неправильный", Id = 18, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 19, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 20, IsCorrect = false}
                            }
                        },
                        new TestItem
                        {
                            Id = 6,
                            Question = "третий вопрос",

                            CoorectAnswer = new Answer {Id = 21, IsCorrect = true, Content = "правильный"},

                            WrongAnswers = new List<Answer>
                            {
                                new Answer {Content = "неправильный", Id = 22, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 23, IsCorrect = false},
                                new Answer {Content = "неправильный", Id = 24, IsCorrect = false}
                            }
                        }
                    }
                }
            };

            Topics.Add(topic1);
            Topics.Add(topic2);
        }


        public List<Topic> GetTopics()
        {
            return Topics;
        }

        public Topic GetTopic(int topicId)
        {
            return Topics.First(t => t.Id == topicId);
        }

        public SlideShow GetSlideShow(int slideShowId)
        {
            var xxx = Topics.First(t => t.SlideShow.Id == slideShowId).SlideShow;
            return xxx;
        }

        /*public Test GetTest(int testId)
        {
            var topic = Topics.First(t => t.Test.Id == testId);
            Random rnd = new Random();

            topic.Test.Items.ForEach(i =>
            {
                i.AnswersToDisplay = new List<Answer>();
                i.AnswersToDisplay.Add(i.CoorectAnswer);

                var incorrectAnswers = i.WrongAnswers.OrderBy(x => rnd.Next()).Take(2).ToList();

                i.AnswersToDisplay.AddRange(incorrectAnswers);

                i.AnswersToDisplay = i.AnswersToDisplay.OrderBy(x => rnd.Next()).ToList();
            });

            return topic.Test;
        }*/
    }
}
