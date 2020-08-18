using Autofac;
using Microsoft.AspNetCore.Identity;
using NecessaryDrugs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Admin.Models
{
    public class RoleUpdateModel : BaseModel
    {
        public string RoleName { get; set; }

        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleUpdateModel()
        {
            _roleManager = Startup.AutofacContainer.Resolve<RoleManager<ApplicationRole>>();
        }

        internal async Task AddNewRole()
        {
            await _roleManager.CreateAsync(new ApplicationRole() { Name = this.RoleName });
            Notification = new NotificationModel("Success", "Role Added", Notificationtype.Success);
        }
    }
}
