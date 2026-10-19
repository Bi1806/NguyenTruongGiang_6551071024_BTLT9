
using System;
using System.IO;
using System.Text.Json;

namespace KeHoachDaNgoai.Services
{
    public class UserSettings
    {
        public string Language { get; set; } = "vi";

        private static readonly string FolderPath =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "KeHoachDaNgoai");

        private static readonly string FilePath =
            Path.Combine(FolderPath, "usersettings.json");

        public static UserSettings Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);

                    return JsonSerializer.Deserialize<UserSettings>(json)
                           ?? new UserSettings();
                }
            }
            catch
            {
                // Nếu file lỗi, sử dụng ngôn ngữ mặc định.
            }

            return new UserSettings();
        }

        public void Save()
        {
            Directory.CreateDirectory(FolderPath);

            string json = JsonSerializer.Serialize(
                this,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(FilePath, json);
        }
    }
}
