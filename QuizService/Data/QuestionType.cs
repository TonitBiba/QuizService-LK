namespace QuizService.Data {
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuestionType {
        public QuestionType() {
            Questions = new HashSet<Question>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_SQ { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_EN { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name_NO { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

    }
}
