namespace QuizService.Repository {
    using Microsoft.EntityFrameworkCore;
    using global::QuizService.Data;
    using global::QuizService.Models.Quizzes;

    public class QuizServices : IQuizService {
        private readonly QuizContext _db;

        public QuizServices(QuizContext db) {
            _db = db;
        }

        public async Task<QuizVM[]> GetQuizzes() =>
             await _db.Quiz.Select(t => new QuizVM {
                ID = t.ID,
                Name = t.Name_EN,
                Image = t.Image,
                Description  = t.Description_EN
            }).ToArrayAsync();

        public async Task<QuizInfoVM?> QuizInfo(int id) =>
            await _db.Quiz.Where(quiz => quiz.ID == id).Select(quiz => new QuizInfoVM { 
                ID = quiz.ID,
                Description = quiz.Description_EN,
                Name = quiz.Name_EN,
                Image= quiz.Image,
                RegisterDate = quiz.InsertedDate,
                QuestionTypes = quiz.Questions.GroupBy(question => question.QuestionTypeID).Select(question=>new QuestionTypeVM { 
                    Count = question.Count(),
                    Type = question.Select(type=>type.QuestionType.Name_EN).FirstOrDefault()
                }).ToArray()
            }).FirstOrDefaultAsync();

        public async Task<QuestionVM?> GetQuestion(int id, int qnr) =>
            await _db.Question.Where(q => q.QuizID == id && q.Nr == qnr).Select(q => new QuestionVM { 
                Id = q.ID,
                Name= q.Name_EN,
                Nr = q.Nr,
                TypeName = q.QuestionType.Name_EN,
                TypeId = q.QuestionTypeID, 
                Options = q.Options.Select(o => new OptionVM {
                    Id = o.ID,
                    Name = o.Name_EN
                }).ToArray()
            }).FirstOrDefaultAsync();

        
    }
}
