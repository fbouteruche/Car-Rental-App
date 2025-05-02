using System.Windows.Forms;


namespace CarRental.WindowsApp.Shared

{
    public interface ICadastravel
    {
        void InserirNovoRegistro();

        void EditarRegistro();
        void ExcluirRegistro();
        UserControl ObterTabela();
       void FiltrarRegistros();
       void AgruparRegistros();
    }
}
