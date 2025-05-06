using System.Windows.Forms;


namespace CarRental.WindowsApp.Shared

{
    public interface IRecordable
    {
        void InsertNewRecord();

        void EditRecord();
        void DeleteRecord();
        UserControl GetTable();
       void FilterRecords();
       void GroupRecords();
    }
}
