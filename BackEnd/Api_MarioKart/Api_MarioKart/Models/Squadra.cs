﻿using System;
using System.Collections.Generic;

namespace Api_MarioKart.Models;

public partial class Squadra
{
    public int SquadraId { get; set; }

    public string NomeUtente { get; set; } = null!;

    public string NomeSquadra { get; set; } = null!;

    public int? Crediti { get; set; }

    public string? Codice { get; set; }

    public List<Personaggi> Personaggis { get; set; } = new List<Personaggi>();
}
