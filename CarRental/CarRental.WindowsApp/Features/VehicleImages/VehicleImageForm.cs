using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRental.WindowsApp.Features.Vehicles;
using CarRental.Domain.VehicleImageModule;

namespace CarRental.WindowsApp.Features.VehicleImages
{
    public partial class VehicleImageForm : Form
    {
        private const long twoMB = 2097152;
        private const int back = -1;
        private const int forward = 1;
        private int currentImage = 0;
        public List<Domain.VehicleImageModule.VehicleImage> images;
        private readonly VehicleForm baseForm;
        public VehicleImageForm(VehicleForm baseForm)
        {
            this.baseForm = baseForm;
            if (baseForm.vehicleImages == null)
                images = new List<Domain.VehicleImageModule.VehicleImage>();
            else
                images = baseForm.vehicleImages;
            InitializeComponent();
            if (images.Count != 0)
                pctBoxImagem.Image = images[0].Image;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog()  == DialogResult.OK)
            {
                var imagePath = openFileDialog.FileName;
                var size = new FileInfo(imagePath).Length;
                if (size <= twoMB)
                {
                    images.Add(new Domain.VehicleImageModule.VehicleImage(0, 0, (Bitmap)Image.FromFile(imagePath)));
                    if (images.Count == 1)
                        UpdateImage();
                    else
                    {
                        ChangeCurrentImage((images.Count() - 1));
                    }
                }
                else
                    MessageBox.Show("The image must be at most 2MB!","Car Rental",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ChangeCurrentImage(int index)
        {
            if (currentImage == 0 && index == back)
                currentImage = images.Count() - 1;
            else if (currentImage + 1 == images.Count() && index == forward)
                currentImage = 0;
            else if (index != 1 && index != -1)
                currentImage = index;
            else
                currentImage = currentImage + index;
            UpdateImage();
        }
        private void UpdateImage()
        {
            if (images.Count != 0)
                pctBoxImagem.Image = images[currentImage].Image;
            else
                pctBoxImagem.Image = default;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (images.Count() != 0)
                ChangeCurrentImage(back);
        }
        private void btnForward_Click(object sender, EventArgs e)
        {
            if (images.Count() != 0)
                ChangeCurrentImage(forward);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the image?", "Car Rental",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (images.Count() != 0)
                {
                    images.RemoveAt(currentImage);
                    ChangeCurrentImage(0);
                }
                else
                {
                    pctBoxImagem.Image = default;
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            baseForm.UpdateImageList(images);
            this.Close();
        }
    }
}
