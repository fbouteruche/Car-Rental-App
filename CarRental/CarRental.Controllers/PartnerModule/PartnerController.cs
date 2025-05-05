using CarRental.Controllers.Shared;
using CarRental.Domain.PartnerModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.PartnerModule
{
    public class PartnerController : Controller<Partner>
    {
        #region queries
        private const string sqlInsertPartner =
            @"INSERT INTO TBPARCEIRO
                (
                    [NOMEPARCEIRO]
                ) 
                VALUES
                (
                    @NOMEPARCEIRO
                )";

        private const string sqlEditPartner =
            @"UPDATE TBPARCEIRO
                    SET
                        [NOMEPARCEIRO] = @NOMEPARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlDeletePartner =
            @"DELETE 
                FROM
                        TBPARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlSelectPartnerById =
            @"SELECT
                        [ID],
                    [NOMEPARCEIRO]
                FROM
                        TBPARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlSelectAllPartners =
            @"SELECT
                        [ID],
                    [NOMEPARCEIRO]
                FROM
                        TBPARCEIRO";

        private const string sqlPartnerExists =
            @"SELECT 
                    COUNT(*) 
                FROM 
                    [TBPARCEIRO]
                WHERE 
                    [ID] = @ID";
        #endregion
        public override string InsertNew(Partner partner)
        {
            string validationResult = partner.Validate();

            if (validationResult == "VALID")
                partner.Id = Db.Insert(sqlInsertPartner, GetPartnerParameters(partner));

            return validationResult;
        }

        public override List<Partner> SelectAll()
        {
            return Db.GetAll(sqlSelectAllPartners, ConvertToPartner);
        }       

        public override Partner SelectById(int id)
        {
            return Db.Get(sqlSelectPartnerById, ConvertToPartner, AddParameter("ID", id));
        }        
        public override string Edit(int id, Partner partner)
        {
            string validationResult = partner.Validate();

            if (validationResult == "VALID")
            {
                partner.Id = id;
                Db.Update(sqlEditPartner, GetPartnerParameters(partner));
            }

            return validationResult;
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeletePartner, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlPartnerExists, AddParameter("ID", id));
        }

        private Dictionary<string, object> GetPartnerParameters(Partner partner)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("ID", partner.Id);
            parameters.Add("NOMEPARCEIRO", partner.Name);

            return parameters;
        }
        private Partner ConvertToPartner(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string name = Convert.ToString(reader["NOMEPARCEIRO"]);

            Partner partner = new Partner(id, name);

            partner.Id = id;

            return partner;
        }
    }
}
