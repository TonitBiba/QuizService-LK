namespace QuizService.Repository {
    using global::QuizService.Models.Quizzes;
    using QuizService.Controllers;

    public interface IQuizService {
        public Task<QuizVM[]> GetQuizzes(LanguageEnum lan);

        public Task<QuizInfoVM?> QuizInfo(int id, LanguageEnum lan);

        public Task<QuestionVM?> GetQuestion(int id, int qnr, LanguageEnum lan);

        public Task<bool> IsCorrect(int id, int qnr, int[] Answer, LanguageEnum lan);

    }
}
