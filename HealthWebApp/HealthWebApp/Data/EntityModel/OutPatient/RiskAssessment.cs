﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthWebApp.Data.EntityModel.OutPatient
{
    public class RiskAssessment
    {
        public long Id { get; set; }

        public long ConsultationId { get; set; }
        public virtual Consultation Consultation { get; set; }
    }
}
