namespace SysTaimsal.UI.Models
{
    public class FileViewModel
    {
        public string name { get; set; }
        public string path { get; set; }

        public static string SaveFile(IFormFile archivo)
        {
            FileViewModel fileViewModel = new FileViewModel();
            //renombrar el archivo
            fileViewModel.name = Guid.NewGuid().ToString() + archivo.FileName;
            fileViewModel.path = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\GuardarImagen\\" + fileViewModel.name);
            //guardar la immage en la carpeta img
            using var stream = new FileStream(fileViewModel.path, FileMode.Create);
            archivo.CopyTo(stream);
            //guardar la ruta relativa del archivo en sql
            //retornar la ruta relativa del archivo
            return "..\\GuardarImagen\\" + fileViewModel.name;
        }
    }
}
