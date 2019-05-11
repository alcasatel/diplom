using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace diplomApp.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Annotation { get; set; }

        public DateTime CreationDate { get; set; }

        public string PathToPageContent { get; set; }

        public string Image { get; set; }

        public int? MaterialTypeId { get; set; }

        public MaterialType MaterialType { get; set; }

        public string Tags { get; set; }

        public string Category { get; set; }

    }

    public class MaterialType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Material> Materials { get; set; }

        public string About { get; set; }

        public MaterialType()
        {
            Materials = new List<Material>();
        }
    }

    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public int MaxResult { get; set; }

        public ICollection<Material> Materials { get; set; }

        public ICollection<Result> Results { get; set; }

        public string PathToPage { get; set; }

        public Lesson()
        {
            Materials = new List<Material>();
            Results = new List<Result>();
        }

    }

    public class Result
    {
        [Key]
        public int Id { get; set; }

        public int? Points { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? LessonId { get; set; }

        public Lesson Lesson { get; set; }
    }

}