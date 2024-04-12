using System;
using System.Collections.Generic;

namespace Api_MarioKart.Models;

public partial class Personaggi
{
    public int PersonaggioId { get; set; }

    public int Costo { get; set; }

    public string? Codice { get; set; }

    public string Categoria { get; set; } = null!;

    public string? Img { get; set; }

    public int? SquadraRif { get; set; }

    public Squadra? SquadraRifNavigation { get; set; }
}
