namespace GameOfDojan.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int ShoePicId { get; set; }
        public ShoePic ShoePic{ get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
