﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthWebApp.Models.HouseholMember
{
    public class HouseholdMembersIndexModel
    {
        public IEnumerable<HouseholdMemberDetailModel> Members { get; set; }
    }
}
