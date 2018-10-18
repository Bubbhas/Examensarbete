using GameOfDojan.Areas.Identity.Pages.Account.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDojan.Models
{
    public class SuperIndexModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IndexModel IndexModel{ get; set; }
    }
}
