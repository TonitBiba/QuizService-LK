namespace QuizService.Models.Quizzes {
    public class QuestionVM {
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public int TypeId { get; set; }

        public int Nr { get; set; }

        public string? TypeName { get; set; }

        public OptionVM[] Options { get; set; }
    }

    public class OptionVM {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}