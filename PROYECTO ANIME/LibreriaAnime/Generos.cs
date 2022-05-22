using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaAnime
{
    [Flags]
    public enum Generos
    {
        None = 0,
        Aventura = 1,
        Fantasia = 2,
        Accion = 4, 
        Comedia = 8,
        Drama = 16,
        CienciaFision = 32,
        Espacial = 64,
        Shounen = 128,
        Shojo = 256,
        Misterio = 512,
        Policias = 1024,
        SubernNtural = 2048,
        Magia = 4096
    }
}
