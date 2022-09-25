namespace QuizService.Data {
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Log {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [StringLength(1024)]
        public string? Url { get; set; }

        public string? FormContent { get; set; }
        
        [StringLength(64)]
        public string? HttpMethod { get; set; }

        public bool IsError { get; set; }
        
        public string? Exception { get; set; }

        public DateTime InsertedDate { get; set; } = DateTime.Now;
    }
}