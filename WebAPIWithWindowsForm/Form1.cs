using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Dtos.User;

namespace WebAPIWithWindowsForm
{
    public partial class Form1 : Form
    {

        #region Defines
        private string url = "http://localhost:16148/api/";
        private int selectedId = 0;
        #endregion

        #region Forms1
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            await DataGridViewFill();
            CmbGenderFill();
        }
        #endregion

        #region Crud
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserAddDto userAddDto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text),
                    Email = txtEmail.Text,
                    Gender = cmbGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url + "Users/Add", userAddDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ekleme İşlemi Başarılı");
                    await DataGridViewFill();
                    ClearForm();

                }
                else
                {
                    MessageBox.Show("Ekleme işlemi başarısız");
                }
            }
        }

        private async void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (HttpClient httpClient = new HttpClient())
            {
                var user = await httpClient.GetFromJsonAsync<UserDto>(url + "Users/GetById/" + selectedId);

                txtAddress.Text = user.Address;
                cmbGender.SelectedValue = user.Gender == true ? 1 : 2;
                txtFirstName.Text = user.FirstName;
                txtUserName.Text = user.UserName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                txtPassword.Text = String.Empty;
                dtpDateOfBirth.Value = user.DateOfBirth;
            }
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserUpdateDto userUpdateDto = new UserUpdateDto()
                {
                    Id = selectedId,
                    FirstName = txtFirstName.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text),
                    Email = txtEmail.Text,
                    Gender = cmbGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(url + "Users/Update", userUpdateDto);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Düzenleme İşlemi Başarılı");
                    await DataGridViewFill();
                    ClearForm();

                }
                else
                {
                    MessageBox.Show("Düzenleme işlemi başarısız");
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(url + "Users/Delete/" + selectedId);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Silme işlemi başarılı");
                    await DataGridViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız");
                }
            }
        }
        #endregion

        #region Methods
        private async Task DataGridViewFill()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "Users/GetList");
                dataGridView1.DataSource = users;
            }
        }

        private void ClearForm()
        {
            txtAddress.Text = String.Empty;
            cmbGender.SelectedValue = 0;
            txtFirstName.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
            dtpDateOfBirth.Value = DateTime.Now;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void CmbGenderFill()
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender() { Id = 1, GenderName = "Erkek" });
            genders.Add(new Gender() { Id = 2, GenderName = "Kadın" });
            cmbGender.DataSource = genders;
            cmbGender.DisplayMember = "GenderName";
            cmbGender.ValueMember = "Id";
        }

        class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }

        #endregion


    }
}
