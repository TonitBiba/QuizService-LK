namespace QuizService.Data {
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Question {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int QuizID { get; set; }

        public int QuestionTypeID { get; set; }

        public int Nr { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_SQ { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_EN { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_NO { get; set; }

        [Required]
        public DateTime InsertedDate { get; set; } = DateTime.Now;

        public Quiz Quiz { get; set; }

        public QuestionType QuestionType { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
