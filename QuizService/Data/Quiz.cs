namespace QuizService.Data {
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Quiz {

        public Quiz() {
            Questions = new HashSet<Question>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public string Image { get; set; }

        [StringLength(1024)]
        public string? Description_SQ { get; set; }

        [StringLength(1024)]
        public string? Description_EN { get; set; }

        [StringLength(1024)]
        public string? Description_NO { get; set; }

        [Required]
        public DateTime InsertedDate { get; set; } = DateTime.Now;

        public ICollection<Question> Questions { get; set; }

    }
}