using CarRental.Controllers.Shared;
using CarRental.Domain.CouponModule;
using CarRental.Domain.PartnerModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.CouponModule
{
    public class CouponController : Controller<Coupon>
    {
        #region queries
        private const string sqlInsertCoupon =
           @"INSERT INTO [TBCUPOM_DESCONTO]
                (
                    [NOMECUPOM],
                    [CODIGO],      
                    [VALORMINIMO],
                    [VALOR], 
                    [EHDESCONTOFIXO],
                    [VALIDADE],                    
                    [ID_PARCEIRO] 
                )
            VALUES
                (
                    @NOMECUPOM,
                    @CODIGO,
                    @VALORMINIMO,
                    @VALOR,
                    @EHDESCONTOFIXO,
                    @VALIDADE,
                    @ID_PARCEIRO
                )";

        private const string sqlEditCoupon =
            @" UPDATE [TBCUPOM_DESCONTO]
                SET 
                    [NOMECUPOM] = @NOMECUPOM, 
                    [CODIGO] = @CODIGO, 
                    [VALORMINIMO] = @VALORMINIMO,
                    [VALOR] = @VALOR, 
                    [EHDESCONTOFIXO] = @EHDESCONTOFIXO,
                    [VALIDADE] = @VALIDADE,
                    [ID_PARCEIRO] = @ID_PARCEIRO
                WHERE [ID] = @ID";

        private const string sqlDeleteCoupon =
            @"DELETE FROM [TBCUPOM_DESCONTO] 
                WHERE [ID] = @ID";

        private const string sqlSelectAllCoupons =
            @"SELECT 
                    D.[ID],       
                    D.[NOMECUPOM],       
                    D.[CODIGO], 
                    D.[VALORMINIMO],
                    D.[VALOR],                    
                    D.[EHDESCONTOFIXO],                                                           
                    D.[VALIDADE],
                    D.[ID_PARCEIRO],
                    P.[ID],
                    P.[NOMEPARCEIRO]
            FROM
                [TBCUPOM_DESCONTO] AS D INNER JOIN
                [TBPARCEIRO] AS P
            ON
                D.ID_PARCEIRO = P.ID";
        private const string sqlSelectCouponById =
            @"SELECT 
                    D.[ID],       
                    D.[NOMECUPOM],       
                    D.[CODIGO], 
                    D.[VALORMINIMO],
                    D.[VALOR],                    
                    D.[EHDESCONTOFIXO],                                                           
                    D.[VALIDADE],
                    D.[ID_PARCEIRO],
                    P.[ID],
                    P.[NOMEPARCEIRO]
            FROM
                [TBCUPOM_DESCONTO] AS D INNER JOIN
                [TBPARCEIRO] AS P
            ON
                D.ID_PARCEIRO = P.ID
            WHERE 
                D.[ID] = @ID";

        private const string sqlSelectCouponByCode =
            @"SELECT 
                    D.[ID],       
                    D.[NOMECUPOM],       
                    D.[CODIGO], 
                    D.[VALORMINIMO],
                    D.[VALOR],                    
                    D.[EHDESCONTOFIXO],                                                           
                    D.[VALIDADE],
                    D.[ID_PARCEIRO],
                    P.[ID],
                    P.[NOMEPARCEIRO]
            FROM
                [TBCUPOM_DESCONTO] AS D INNER JOIN
                [TBPARCEIRO] AS P
            ON
                D.ID_PARCEIRO = P.ID
            WHERE 
                D.[CODIGO] = @CODIGO";

        private const string sqlCouponExists =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCUPOM_DESCONTO]
            WHERE 
                [ID] = @ID";

        private const string sqlCodeExists =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCUPOM_DESCONTO]
            WHERE 
                [CODIGO] = @CODIGO";
        #endregion
        public override string InsertNew(Coupon coupon)
        {
            string validationResult = coupon.Validate();

            if (validationResult == "VALID")
                coupon.Id = Db.Insert(sqlInsertCoupon, GetCouponParameters(coupon));

            return validationResult;
        }

        public override List<Coupon> SelectAll()
        {
            return Db.GetAll(sqlSelectAllCoupons, ConvertToCoupon);
        }

        public override Coupon SelectById(int id)
        {
            return Db.Get(sqlSelectCouponById, ConvertToCoupon, AddParameter("ID", id));
        }

        public Coupon SelectByCode(string code)
        {
            return Db.Get(sqlSelectCouponByCode, ConvertToCoupon, AddParameter("CODIGO", code));
        }

        public override string Edit(int id, Coupon coupon)
        {
            string validationResult = coupon.Validate();

            if (validationResult == "VALID")
            {
                coupon.Id = id;
                Db.Update(sqlEditCoupon, GetCouponParameters(coupon));
            }

            return validationResult;
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeleteCoupon, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlCouponExists, AddParameter("ID", id));
        }

        public bool CodeExists(string code)
        {
            return Db.Exists(sqlCodeExists, AddParameter("CODIGO", code));
        }

        private Dictionary<string, object> GetCouponParameters(Coupon coupon)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("ID", coupon.Id);
            parameters.Add("NOMECUPOM", coupon.Name);
            parameters.Add("CODIGO", coupon.Code);
            parameters.Add("VALORMINIMO", coupon.MinimumValue);
            parameters.Add("VALOR", coupon.Value);
            parameters.Add("EHDESCONTOFIXO", coupon.IsFixedDiscount);
            parameters.Add("VALIDADE", coupon.ExpirationDate);
            parameters.Add("ID_PARCEIRO", coupon.Partner.Id);

            return parameters;
        }

        private Coupon ConvertToCoupon(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string name = Convert.ToString(reader["NOMECUPOM"]);
            string code = Convert.ToString(reader["CODIGO"]);
            double minimumValue = Convert.ToDouble(reader["VALORMINIMO"]);
            double value = Convert.ToDouble(reader["VALOR"]);            
            bool isFixedDiscount = Convert.ToBoolean(reader["EHDESCONTOFIXO"]);
            DateTime expirationDate = Convert.ToDateTime(reader["VALIDADE"]);

            int partnerId = Convert.ToInt32(reader["ID_PARCEIRO"]);
            string partnerName = Convert.ToString(reader["NOMEPARCEIRO"]);
            Partner partner = new Partner(partnerId, partnerName);

            Coupon coupon = new Coupon(id, name, code, value, minimumValue, isFixedDiscount, expirationDate, partner);

            coupon.Id = id;

            return coupon;
        }
    }
}
