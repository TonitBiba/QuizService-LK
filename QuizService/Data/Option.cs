namespace QuizService.Data {
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Option {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int QuestionID { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_SQ { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_EN { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_NO { get; set; }

        public bool IsCorrect { get; set; }

        public Question Question { get; set; }
    }
}
