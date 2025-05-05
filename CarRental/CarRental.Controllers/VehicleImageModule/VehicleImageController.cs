using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CarRental.Controllers.Shared;
using CarRental.Domain.VehicleImageModule;

namespace CarRental.Controllers.VehicleImageModule
{
    public class VehicleImageController : Controller<VehicleImage>
    {
        #region Queries
        private const string insertCommand = @"INSERT INTO [DBO].[TBIMAGEMVEICULO] 
                                                (
                                                 [ID_VEICULO],
                                                 [IMAGEM]
                                                )VALUES
                                                (
                                                @ID_VEICULO,
                                                @IMAGEM
                                                );";
        private const string deleteCommand = "DELETE FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID] = @ID";
        private const string deleteAllByVehicleIdCommand = "DELETE FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO";
        private const string selectAllByVehicleIdCommand = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO;";
        private const string selectByIdCommand = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID] = @ID";
        private const string selectByVehicleIdCommand = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO";
        private const string selectAllCommand = "SELECT * FROM DBO].[TBIMAGEMVEICULO]";
        #endregion
        public override string Edit(int id, VehicleImage record)
        {
            record.Id = Db.Insert(insertCommand, GetImageParameters(record));
            return "";
        }

        public void EditList(List<VehicleImage> records)
        {
            if (records != null)
            {
                if (records.Count != 0)
                    DeleteByVehicleId(records[0].VehicleId);
                foreach (VehicleImage image in records)
                {
                    InsertNew(image);
                }
            }
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(deleteCommand, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool DeleteByVehicleId(int vehicleId)
        {
            try
            {
                Db.Delete(deleteAllByVehicleIdCommand, AddParameter("ID_Veiculo", vehicleId));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public override string InsertNew(VehicleImage record)
        {
            string validationResult = "VALID";

            record.Id = Db.Insert(insertCommand, GetImageParameters(record));

            return validationResult;
        }

        public override VehicleImage SelectById(int id)
        {
            return Db.Get(selectByIdCommand, ConvertToVehicleImage, AddParameter("ID", id));
        }
        public List<VehicleImage> SelectByVehicleId(int vehicleId)
        {
            return Db.GetAll(selectByVehicleIdCommand, ConvertToVehicleImage, AddParameter("ID_VEICULO", vehicleId));
        }

        public override List<VehicleImage> SelectAll()
        {
            return Db.GetAll(selectAllCommand, ConvertToVehicleImage);
        }

        public List<VehicleImage> SelectAllImagesOfVehicle(int vehicleId)
        {
            return Db.GetAll(selectAllByVehicleIdCommand, ConvertToVehicleImage, AddParameter("ID_VEICULO", vehicleId));
        }

        private Dictionary<string, object> GetImageParameters(VehicleImage vehicleImage)
        {
            Bitmap bitmap = vehicleImage.Image;
            MemoryStream memory = new MemoryStream();
            bitmap.Save(memory, ImageFormat.Bmp);
            byte[] imageBytes = memory.ToArray();

            var parameters = new Dictionary<string, object>();

            parameters.Add("ID", vehicleImage.Id);
            parameters.Add("ID_VEICULO", vehicleImage.VehicleId);
            parameters.Add("IMAGEM", imageBytes);

            return parameters;
        }

        private Bitmap ConvertToImage(IDataReader reader)
        {
            byte[] bytes = (byte[])(reader["IMAGEM"]);

            TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(Bitmap));
            Bitmap bitmap = (Bitmap)typeConverter.ConvertFrom(bytes);

            return bitmap;
        }

        private VehicleImage ConvertToVehicleImage(IDataReader reader)
        {
            byte[] byteArray = (byte[])(reader["IMAGEM"]);
            var id = Convert.ToInt32(reader["ID"]);
            var vehicleId = Convert.ToInt32(reader["ID_VEICULO"]);

            TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(Bitmap));
            Bitmap bitmap = (Bitmap)typeConverter.ConvertFrom(byteArray);
            Bitmap image = new Bitmap(bitmap);

            return new VehicleImage(id, vehicleId, image);
        }
    }
}
