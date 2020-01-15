using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionControl.DataAccess.Entities
{
    public class User : IdentityUser<int>,IBaseEntity
    {
        public User()
        {
            WeightInfos = new HashSet<WeightInfo>();
        }

        public int? UserAdditionalInfoId { get; set; }
        public UserAdditionalInfo UserAdditionalInfo { get; set; }
        public ICollection<WeightInfo> WeightInfos { get; set; }
    }
}
