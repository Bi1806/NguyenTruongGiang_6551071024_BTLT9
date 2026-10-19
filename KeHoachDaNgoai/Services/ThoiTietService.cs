
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace KeHoachDaNgoai.Services
{
    public class ThoiTietService
    {
        private static readonly HttpClient client = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(8)
        };

        public class KetQuaThoiTiet
        {
            public string MoTa { get; set; } = "";
            public string BieuTuong { get; set; } = "";
            public double NhietDoThap { get; set; }
            public double NhietDoCao { get; set; }
            public int KhaNangMua { get; set; }
            public bool CoCanhBao { get; set; }
            public string ThongBao { get; set; } = "";
        }

        public async Task<KetQuaThoiTiet> LayThoiTietAsync(
            string diaDiem, DateTime ngayDi)
        {
            // Tìm tọa độ địa điểm
            string tenDiaDiem = Uri.EscapeDataString(diaDiem.Trim());

            string urlDiaDiem =
                $"https://geocoding-api.open-meteo.com/v1/search" +
                $"?name={tenDiaDiem}&count=1&language=vi&format=json";

            using JsonDocument docDiaDiem = JsonDocument.Parse(
                await client.GetStringAsync(urlDiaDiem));

            if (!docDiaDiem.RootElement.TryGetProperty(
                "results", out JsonElement ketQua) ||
                ketQua.GetArrayLength() == 0)
            {
                throw new Exception(
                    "Không tìm thấy địa điểm. Hãy thử nhập tên không dấu, ví dụ: Da Lat.");
            }

            JsonElement diaDiemDauTien = ketQua[0];

            double latitude =
                diaDiemDauTien.GetProperty("latitude").GetDouble();

            double longitude =
                diaDiemDauTien.GetProperty("longitude").GetDouble();

            // Lấy dự báo thời tiết
            string urlThoiTiet =
                "https://api.open-meteo.com/v1/forecast" +
                $"?latitude={latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}" +
                $"&longitude={longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}" +
                "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
                "&timezone=auto&forecast_days=16";

            using JsonDocument docThoiTiet = JsonDocument.Parse(
                await client.GetStringAsync(urlThoiTiet));

            JsonElement daily =
                docThoiTiet.RootElement.GetProperty("daily");

            string[] ngayDuBao = daily.GetProperty("time")
                .EnumerateArray()
                .Select(x => x.GetString() ?? "")
                .ToArray();

            string ngayCanTim = ngayDi.ToString("yyyy-MM-dd");

            int index = Array.IndexOf(ngayDuBao, ngayCanTim);

            if (index < 0)
            {
                throw new Exception(
                    "Ngày đi nằm ngoài phạm vi dự báo 16 ngày của API.");
            }

            int maThoiTiet = daily.GetProperty("weather_code")[index]
                .GetInt32();

            double nhietDoThap =
                daily.GetProperty("temperature_2m_min")[index].GetDouble();

            double nhietDoCao =
                daily.GetProperty("temperature_2m_max")[index].GetDouble();

            JsonElement mua =
                daily.GetProperty("precipitation_probability_max")[index];

            int khaNangMua = mua.ValueKind == JsonValueKind.Number
                ? mua.GetInt32() : 0;

            var ketQuaThoiTiet = new KetQuaThoiTiet
            {
                NhietDoThap = nhietDoThap,
                NhietDoCao = nhietDoCao,
                KhaNangMua = khaNangMua
            };

            switch (maThoiTiet)
            {
                case 0:
                    ketQuaThoiTiet.MoTa = "Trời quang";
                    ketQuaThoiTiet.BieuTuong = "☀️";
                    break;

                case 1:
                case 2:
                case 3:
                    ketQuaThoiTiet.MoTa = "Có mây";
                    ketQuaThoiTiet.BieuTuong = "⛅";
                    break;

                case 45:
                case 48:
                    ketQuaThoiTiet.MoTa = "Có sương mù";
                    ketQuaThoiTiet.BieuTuong = "🌫️";
                    break;

                case >= 51 and <= 67:
                case >= 80 and <= 82:
                    ketQuaThoiTiet.MoTa = "Có mưa";
                    ketQuaThoiTiet.BieuTuong = "🌧️";
                    break;

                case >= 95 and <= 99:
                    ketQuaThoiTiet.MoTa = "Có giông";
                    ketQuaThoiTiet.BieuTuong = "⛈️";
                    break;

                default:
                    ketQuaThoiTiet.MoTa = "Thời tiết khác";
                    ketQuaThoiTiet.BieuTuong = "🌤️";
                    break;
            }

            ketQuaThoiTiet.CoCanhBao = khaNangMua >= 60;

            ketQuaThoiTiet.ThongBao =
                ketQuaThoiTiet.CoCanhBao
                ? "Nên mang áo mưa hoặc cân nhắc dời lịch."
                : "Chưa có cảnh báo mưa lớn theo ngưỡng đã đặt.";

            return ketQuaThoiTiet;
        }
    }
}
