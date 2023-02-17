namespace SysTaimsal.UI.Models
{
    public class FileViewModel
    {
        public string name { get; set; }
        public string path { get; set; }
        public Guid guid = new Guid();

        public static string SaveFile(IFormFile archivo)
        {
            FileViewModel fileViewModel = new FileViewModel();
            fileViewModel.name = Guid.NewGuid().ToString() + archivo.FileName;
            fileViewModel.path = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\GuardarImagen\\" + fileViewModel.name);
            using var stream = new FileStream(fileViewModel.path, FileMode.Create);
            archivo.CopyTo(stream);
            return "..\\GuardarImagen\\" + fileViewModel.name;
        }
    }
}
