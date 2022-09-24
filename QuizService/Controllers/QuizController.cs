namespace QuizService.Controllers {
    using Microsoft.AspNetCore.Mvc;
    using QuizService.Models.Quizzes;
    using QuizService.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : BaseController {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService) {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<QuizVM[]> Get() {
            return await _quizService.GetQuizzes();
        }

        [HttpGet("{id}")]
        public async Task<QuizInfoVM?> Get(int id) {
            return await _quizService.QuizInfo(id);
        }

        [HttpGet("{id}/questions/{qnr}")]
        public async Task<QuestionVM?> GetQuestion(int id, int qnr) {
            return await _quizService.GetQuestion(id, qnr);
        }
    }
}