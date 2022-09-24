namespace QuizService.Models.Quizzes {
    public class QuizInfoVM {
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public DateTime RegisterDate { get; set; }

        public QuestionTypeVM[] QuestionTypes { get; set; }

    }

    public class QuestionTypeVM {
        public string? Type { get; set; }
        public int Count { get; set; }
    }
}