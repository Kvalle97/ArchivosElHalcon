namespace CSNegocios.Modelos.Bodegas
{
    public class Bodega
    {
        public int IdBodega { get; set; }
        public string Descripcion { get; set; }
        public string Comentarios { get; set; }
        public int IdEmpresa { get; set; }
        public string Costo { get; set; }
    }
}