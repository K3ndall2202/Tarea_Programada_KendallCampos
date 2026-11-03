using Tarea_Programada_KendallCampos.Datos;
using Tarea_Programada_KendallCampos.Logica;
using Tarea_Programada_KendallCampos.Formularios;

namespace Tarea_Programada_KendallCampos;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var servicio = new GestionServicio(new RepositorioSqlServer());
        Application.Run(new FrmCategorias(servicio));
    }
}
