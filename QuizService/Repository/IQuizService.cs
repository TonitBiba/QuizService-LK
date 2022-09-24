namespace QuizService.Repository {
    using global::QuizService.Models.Quizzes;

    public interface IQuizService {
        public Task<QuizVM[]> GetQuizzes();

        public Task<QuizInfoVM?> QuizInfo(int id);

        public Task<QuestionVM?> GetQuestion(int id, int qnr);

    }
}
