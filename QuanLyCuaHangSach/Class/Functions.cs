using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BAEK_PERCENT.Class
{
    internal static class Functions
    {
        public static void HandleError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void HandleInfo(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void HandleWarning(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool HandleQuestion(string message)
        {
            DialogResult result = MessageBox.Show(message, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDate(string d)
        {
            string[] parts = d.Split('/');

            if (parts.Length != 3)
                return false;

            int day, month, year;
            if (!int.TryParse(parts[0], out day) || !int.TryParse(parts[1], out month) || !int.TryParse(parts[2], out year))
                return false;

            if (day < 1 || day > 31 || month < 1 || month > 12 || year < 1900)
                return false;

            if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
                return false;

            if (month == 2)
            {
                bool isLeapYear = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if ((isLeapYear && day > 29) || (!isLeapYear && day > 28))
                    return false;
            }

            return true;
        }

        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');

            if (parts.Length != 3)
                throw new ArgumentException("Định dạng ngày tháng không hợp lệ.");

            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }

        public static string ChuyenSoSangChu(string sNumber)
        {
            // Xóa các dấu "," nếu có
            sNumber = sNumber.Replace(",", "");
            string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            int mLen = sNumber.Length - 1;
            string mTemp = "";

            for (int i = 0; i <= mLen; i++)
            {
                int mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp += " " + mNumText[mDigit];

                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp
                    break;

                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp += " tỷ";
                        i = SkipZeros(sNumber, i);
                        break;
                    case 6:
                        mTemp += " triệu";
                        i = SkipZeros(sNumber, i);
                        break;
                    case 3:
                        mTemp += " nghìn";
                        i = SkipZeros(sNumber, i);
                        break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2:
                                mTemp += " trăm";
                                break;
                            case 1:
                                mTemp += " mươi";
                                break;
                        }
                        break;
                }
            }

            // Tạo từ điển cho các trường hợp cần thay thế
            Dictionary<string, string> replaceDict = new Dictionary<string, string>
            {
                { "không mươi không", "" },
                { "không mươi ", "linh " },
                { "mươi không", "mươi" },
                { "một mươi", "mười" },
                { "mươi bốn", "mươi tư" },
                { "linh bốn", "linh tư" },
                { "mươi năm", "mươi lăm" },
                { "mươi một", "mươi mốt" },
                { "mười năm", "mười lăm" }
            };

            // Thay thế các chuỗi theo từ điển
            foreach (var item in replaceDict)
            {
                mTemp = mTemp.Replace(item.Key, item.Value);
            }

            // Bỏ ký tự space thừa
            mTemp = mTemp.Trim();

            // Viết hoa ký tự đầu tiên
            if (mTemp.Length > 0)
            {
                mTemp = char.ToUpper(mTemp[0]) + mTemp.Substring(1) + " đồng";
            }

            return mTemp;
        }

        private static int SkipZeros(string sNumber, int currentIndex)
        {
            int i = currentIndex;
            while (i + 3 < sNumber.Length && sNumber.Substring(i + 1, 3) == "000")
            {
                i += 3;
            }
            return i;
        }

        public static string ConvertTimeTo24(string hour)
        {
            if (int.TryParse(hour, out int h))
            {
                // Điều chỉnh giờ PM (giờ 13-23) và giờ 12 AM (giờ 0)
                h = (h % 12) + 12;
                return h == 24 ? "00" : h.ToString();
            }
            else
            {
                throw new ArgumentException("Invalid hour format");
            }
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Tạo instance của SHA-256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi chuỗi đầu vào thành mảng byte
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Chuyển đổi mảng byte thành chuỗi hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
