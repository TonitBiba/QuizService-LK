namespace QuizService.Controllers {
    using Microsoft.AspNetCore.Mvc;
    using QuizService.Data;
    using QuizService.Models.Quizzes;
    using QuizService.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : BaseController {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService, QuizContext db):base(db) {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<QuizVM[]> Get() {
            return await _quizService.GetQuizzes(lang);
        }

        [HttpGet("{id}")]
        public async Task<QuizInfoVM?> Get(int id) {
            return await _quizService.QuizInfo(id, lang);
        }

        [HttpGet("{id}/questions/{qnr}")]
        public async Task<QuestionVM?> GetQuestion(int id, int qnr) {
            return await _quizService.GetQuestion(id, qnr, lang);
        }

        [HttpPost("{id}/questions/{qnr}")]
        public async Task<bool> PostCheckIfCorrect(int id, int qnr, [FromBody] CheckForCorrect check) {
            return await _quizService.IsCorrect(id, qnr, check.Answer, lang);
        }
    }
}