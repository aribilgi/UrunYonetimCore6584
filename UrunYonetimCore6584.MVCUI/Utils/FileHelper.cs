namespace UrunYonetimCore6584.MVCUI.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string filePath = "")
        {
            string fileName = "";
            fileName = formFile.FileName.ToLower().Replace(' ', '-');
            string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + filePath + fileName;
            using var stream = new FileStream(directory, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return fileName;
        }
    }
}
