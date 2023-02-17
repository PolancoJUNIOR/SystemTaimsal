namespace SysTaimsal.UI.Models
{
    public class FileView
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid guid = new Guid();

        public static string SaveFileProduct(IFormFile file)
        {
            FileView fileView = new FileView();
            fileView.Name = Guid.NewGuid().ToString() + file.FileName;
            fileView.Image = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\ImgProduct\\" + fileView.Image);
            using var stream = new FileStream(fileView.Name, FileMode.Create);
            file.CopyTo(stream);
            return "..\\ImgProduct\\" + fileView.Name;
        }
    }
}
