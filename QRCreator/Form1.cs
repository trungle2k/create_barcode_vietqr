using Newtonsoft.Json;
using RestSharp;
using System.Drawing.Imaging;

namespace QRCreator
{
    public partial class Form1 : Form
    {
        private NotifyIcon m_notifyIcon;
        private List<ApiRequest> m_lstApiRequests;
        private string m_strFileNameCsv;

        public Form1()
        {
            InitializeComponent();

            // Hello 
            // Hi 
            // Create ContextMenuStrip
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Add "Copy Image" menu item
            ToolStripMenuItem copyImageItem = new ToolStripMenuItem("Copy Image");
            copyImageItem.Click += CopyImageItem_Click;
            contextMenu.Items.Add(copyImageItem);

            // Assign ContextMenuStrip to PictureBox
            pictureBox1.ContextMenuStrip = contextMenu;

            // Main: Commit 2
            cb_template.SelectedIndex = 1;

            // Initialize NotifyIcon
            m_notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information, // Use a built-in icon or your own
                Visible = true, // Make it visible in the system tray
                BalloonTipTitle = "Notification Title", // Title for the balloon tip
                BalloonTipText = "This is your notification message.", // Message text
                BalloonTipIcon = ToolTipIcon.Info // Icon type
            };

            m_lstApiRequests = new List<ApiRequest>();
            m_strFileNameCsv = string.Empty;
            // add comment 2
            // commit2 : crate_barcode_vietqr branch2
        }

        private void CopyImageItem_Click(object? sender, EventArgs e)
        {
            CopyImageToClipboard();
        }

        private void buttonCreateQR_Click(object sender, EventArgs e)
        {
            var apiRequest = new ApiRequest();
            apiRequest.acqId = 970418;
            apiRequest.accountNo = long.Parse(txtSTK.Text);
            apiRequest.accountName = txtTenTaiKhoan.Text;
            apiRequest.amount = Convert.ToInt32(txtSoTien.Text);
            apiRequest.format = "text";
            apiRequest.template = cb_template.Text;
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            // use restsharp for request api.
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            string? content = response.Content;
            if (string.IsNullOrEmpty(content) == false)
            {
                ApiResponse? dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);
                if (dataResult != null && dataResult.data != null && dataResult.data.qrDataURL != null)
                {
                    Image image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
                    pictureBox1.Image = image;
                }
            }
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void CopyImage_Click(object sender, EventArgs e)
        {
            CopyImageToClipboard();
        }

        private void CopyImageToClipboard()
        {
            // Ensure the PictureBox contains an image
            if (pictureBox1.Image != null)
            {
                try
                {
                    Clipboard.SetImage(pictureBox1.Image);
                    ShowNotification("Success", "Image copied to clipboard successfully!");
                }
                catch (Exception ex)
                {
                    ShowNotification("Error", $"Error copying image: {ex.Message}");
                }
            }
            else
            {
                ShowNotification("Warning", "No image in PictureBox to copy.");
            }
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            // Ensure the PictureBox contains an image
            if (pictureBox1.Image != null)
            {
                try
                {
                    // Show a SaveFileDialog to choose file path and name
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
                        saveFileDialog.Title = "Save an Image File";
                        saveFileDialog.FileName = "Image";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Save the image in the selected format
                            string filePath = saveFileDialog.FileName;

                            // Determine the format based on file extension
                            ImageFormat format = ImageFormat.Png; // Default
                            if (filePath.EndsWith(".jpg"))
                                format = ImageFormat.Jpeg;
                            else if (filePath.EndsWith(".bmp"))
                                format = ImageFormat.Bmp;

                            pictureBox1.Image.Save(filePath, format);
                            MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No image in PictureBox to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, control keys (e.g., backspace), and decimal points
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Reject the input
            }
        }

        public void ShowNotification(string title, string message)
        {
            if (m_notifyIcon != null)
            {
                m_notifyIcon.BalloonTipTitle = title;
                m_notifyIcon.BalloonTipText = message;
                m_notifyIcon.ShowBalloonTip(3000); // Show for 3 seconds
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cleanup NotifyIcon when the form closes
            m_notifyIcon.Dispose();
            base.OnFormClosing(e);
        }

        private void buttonCretateQRFromFile_Click(object sender, EventArgs e)
        {
            // Open File Dialog to choose Excel file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.csv";
                openFileDialog.Title = "Select an CSV File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var values = line.Split(';'); // Split using semicolon
                            var record = new ApiRequest
                            {
                                accountNo = long.Parse(txtSTK.Text),
                                accountName = txtTenTaiKhoan.Text,
                                acqId = 970418,
                                amount = int.Parse(values[3]),
                                addInfo = values[1] + " " + values[2],
                                format = "text",
                                template = "compact2"
                            };
                            m_lstApiRequests.Add(record);
                        }
                    }

                    if (m_lstApiRequests.Count > 0)
                    {
                        int i = 0;
                        foreach (var record in m_lstApiRequests)
                        {
                            var jsonRequest = JsonConvert.SerializeObject(record);
                            // use restsharp for request api.
                            var client = new RestClient("https://api.vietqr.io/v2/generate");
                            var request = new RestRequest();

                            request.Method = Method.Post;
                            request.AddHeader("Accept", "application/json");

                            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

                            RestResponse response = client.Execute(request);
                            string? content = response.Content;
                            if (string.IsNullOrEmpty(content) == false)
                            {
                                ApiResponse? dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);
                                if (dataResult != null && dataResult.data != null && dataResult.data.qrDataURL != null)
                                {
                                    Image image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));

                                    // Save the image
                                    string saveDirectory = @"C:\Images";
                                    if (!Directory.Exists(saveDirectory))
                                    {
                                        Directory.CreateDirectory(saveDirectory);
                                    }

                                    string fileName = $"{i++}_QR.png";
                                    string savePath = Path.Combine(saveDirectory, fileName);

                                    image.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// checkBox1 CheckedChanged event
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                btnLoadFile.Enabled = true;
                txtSoTien.Enabled = false;
                txtNoiDung.Enabled = false;
                txtNoiDung.Enabled = false; // Main: commit 1
            }
            else 
            {
                btnLoadFile.Enabled = false;
                txtSoTien.Enabled = true;
                txtNoiDung.Enabled = true;
            }
        }

        // commit : crate_barcode_vietqr branch

        // test commit: gitTest branch
        // test commit2: gitTest branch2
        // commit NO1:
        // commit no2:
    }
}
