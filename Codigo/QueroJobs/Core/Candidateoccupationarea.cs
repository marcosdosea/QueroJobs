﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Candidateoccupationarea
    {
        public int IdOccupationArea { get; set; }
        public int IdCandidate { get; set; }

        public virtual Occupationarea IdOccupationAreaNavigation { get; set; }
    }
}
