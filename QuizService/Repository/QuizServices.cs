namespace QuizService.Repository {
    using Microsoft.EntityFrameworkCore;
    using global::QuizService.Data;
    using global::QuizService.Models.Quizzes;
    using QuizService.Controllers;

    public class QuizServices : IQuizService {
        private readonly QuizContext _db;

        public QuizServices(QuizContext db) {
            _db = db;
        }

        public async Task<QuizVM[]> GetQuizzes(LanguageEnum lan) =>
             await _db.Quiz.Select(t => new QuizVM {
                ID = t.ID,
                Name = lan == LanguageEnum.English? t.Name_EN:(lan == LanguageEnum.Albania?t.Name_SQ: t.Name_NO),
                Image = t.Image,
                Description  = lan == LanguageEnum.English ? t.Description_EN : (lan == LanguageEnum.Albania ? t.Description_SQ : t.Description_NO)
             }).ToArrayAsync();

        public async Task<QuizInfoVM?> QuizInfo(int id, LanguageEnum lan) =>
            await _db.Quiz.Where(quiz => quiz.ID == id).Select(quiz => new QuizInfoVM { 
                ID = quiz.ID,
                Description = lan == LanguageEnum.English ? quiz.Description_EN : (lan == LanguageEnum.Albania ? quiz.Description_SQ : quiz.Description_NO),
                Name = lan == LanguageEnum.English ? quiz.Name_EN : (lan == LanguageEnum.Albania ? quiz.Name_SQ : quiz.Name_NO),
                Image= quiz.Image,
                RegisterDate = quiz.InsertedDate,
                QuestionTypes = quiz.Questions.GroupBy(question => question.QuestionTypeID).Select(question=>new QuestionTypeVM { 
                    Count = question.Count(),
                    Type = question.Select(type=> lan == LanguageEnum.English ? type.QuestionType.Name_EN : (lan == LanguageEnum.Albania ? type.QuestionType.Name_SQ : type.QuestionType.Name_NO)).FirstOrDefault()
                }).ToArray()
            }).FirstOrDefaultAsync();

        public async Task<QuestionVM?> GetQuestion(int id, int qnr, LanguageEnum lan) =>
            await _db.Question.Where(q => q.QuizID == id && q.Nr == qnr).Select(q => new QuestionVM { 
                Id = q.ID,
                Name= lan == LanguageEnum.English ? q.Name_EN : (lan == LanguageEnum.Albania ? q.Name_SQ : q.Name_NO),
                Nr = q.Nr,
                TypeName = lan == LanguageEnum.English ? q.QuestionType.Name_EN : (lan == LanguageEnum.Albania ? q.QuestionType.Name_SQ : q.QuestionType.Name_NO),
                TypeId = q.QuestionTypeID, 
                Options = q.Options.Select(o => new OptionVM {
                    Id = o.ID,
                    Name = lan == LanguageEnum.English ? o.Name_EN : (lan == LanguageEnum.Albania ? o.Name_SQ : o.Name_NO)
                }).ToArray()
            }).FirstOrDefaultAsync();

        public async Task<bool> IsCorrect(int id, int qnr, int[] Answer, LanguageEnum lan) {
            int[] correctOptions = await _db.Option.Where(opt => opt.Question.Nr == qnr && opt.Question.QuizID == id && opt.IsCorrect).Select(opt => opt.ID).ToArrayAsync();
            return Enumerable.SequenceEqual(Answer, correctOptions);
        }
    }
}
