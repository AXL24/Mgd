using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private readonly HttpClient _httpClient;
        private const string MANGADEX_API_BASE = "https://api.mangadex.org";

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "MangaDownloader/1.0");

            cmbLanguage.Items.AddRange(new string[] { "en", "ja", "vi", "ko", "zh" });

        }
        //làm sạch tên folder
        private string CleanFolderName(string name)
        {
            string invalid = new string(Path.GetInvalidFileNameChars());
            foreach (char c in invalid)
            {
                name = name.Replace(c, '_');
            }
            return name;
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMangaId.Text))
            {
                MessageBox.Show("Please enter a Manga ID");
                return;
            }

            btnDownload.Enabled = false;
            txtProgress.Clear();
            await DownloadManga(txtMangaId.Text, cmbLanguage.SelectedItem.ToString(), txtProgress);
            btnDownload.Enabled = true;
        }

        private async Task DownloadManga(string mangaId, string language, TextBox progressBox)
        {
            //gửi request, lấy json
            //trích json lấy tên truyện
            var mangaResponse = await _httpClient.GetAsync($"{MANGADEX_API_BASE}/manga/{mangaId}");
            var mangaJson = await mangaResponse.Content.ReadAsStringAsync();
            var mangaData = JsonConvert.DeserializeObject<dynamic>(mangaJson);
            string mangaTitle = mangaData.data.attributes.title.en ?? mangaData.data.attributes.title.vi;
            string cleanTitle = CleanFolderName(mangaTitle);

            //gửi request tới endpoint /feed (lấy chương truyện theo param chỉ định)
            //trích json lấy chương
            var chaptersUrl = $"{MANGADEX_API_BASE}/manga/{mangaId}/feed?translatedLanguage[]={language}&order[chapter]=asc&contentRating[]=safe&contentRating[]=suggestive&contentRating[]=erotica&contentRating[]=pornographic";
            var chaptersResponse = await _httpClient.GetAsync(chaptersUrl);
            var chaptersJson = await chaptersResponse.Content.ReadAsStringAsync();
            var chaptersData = JsonConvert.DeserializeObject<dynamic>(chaptersJson);

            //chọn folder,để tải truyện 
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select download location";
                if (folderDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                //tạo folder với tên truyện

                string downloadPath = Path.Combine(folderDialog.SelectedPath, cleanTitle);
                Directory.CreateDirectory(downloadPath);

                progressBox.AppendText($"Downloading: {mangaTitle}\r\n");
                int totalPages = 0;
                //tải từng chương ứng với dử liệu đa trích
                foreach (var chapter in chaptersData.data)

                {

                    //lấy chapter id và tên chương hiện tại
                    string chapterId = chapter.id.ToString();
                    string chapterNumber = chapter.attributes.chapter.ToString();

                    //gửi request tới để lấy số URL hình ảnh trang
                    var chapterResponse = await _httpClient.GetAsync($"{MANGADEX_API_BASE}/at-home/server/{chapterId}");
                    var chapterJson = await chapterResponse.Content.ReadAsStringAsync();
                    var chapterData = JsonConvert.DeserializeObject<dynamic>(chapterJson);
                    
                    //tạo folder cho chương
                    string chapterPath = Path.Combine(downloadPath, $"Chapter_{chapterNumber}");
                    int pages = (int)(chapter.attributes.pages ?? 0);
                    totalPages += chapterData.chapter.data.Count;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = totalPages;
                    progressBar1.Value = 0;
                    int downloadedPages = 0;
                    Directory.CreateDirectory(chapterPath);

                    int pageCount = 0;

                    //tải từng trang ứng với chương trong chương
                    foreach (var page in chapterData.chapter.data)
                    {
                        //tải trang đặt tên file ảnh tương ứng
                        string pageUrl = $"{chapterData.baseUrl}/data/{chapterData.chapter.hash}/{page}";
                        string pagePath = Path.Combine(chapterPath, $"page_{++pageCount:D3}.jpg");

                        var pageResponse = await _httpClient.GetAsync(pageUrl);
                        //lưu
                        using (var fileStream = File.Create(pagePath))
                        {
                            await pageResponse.Content.CopyToAsync(fileStream);
                        }

                        progressBox.AppendText($"Downloaded Chapter {chapterNumber} - Page {pageCount}\r\n");
                        downloadedPages++;
                        progressBar1.Value = Math.Min(downloadedPages, progressBar1.Maximum);


                    }
                }
                progressBar1.Value = progressBar1.Maximum;
                progressBox.AppendText("Download completed!\r\n");
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtProgress_TextChanged(object sender, EventArgs e) { }
        private void progressBar1_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {

        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
