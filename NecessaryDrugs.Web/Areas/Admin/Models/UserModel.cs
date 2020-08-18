using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NecessaryDrugs.Core.Entities;
using NecessaryDrugs.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace NecessaryDrugs.Web.Areas.Admin.Models
{
    public class UserModel
    {
        private readonly UserManager<NormalUser> _userManager;

        public UserModel()
        {
            _userManager = Startup.AutofacContainer.Resolve<UserManager<NormalUser>>();
        }
        public string Id { get; set; }
        public String Name { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        //internal object GetAllUsers(DataTablesAjaxRequestModel tableModel)
        //{
        //    int total = 0;
        //    int totalFiltered = 0;
        //    var start = (tableModel.PageIndex - 1) * tableModel.PageSize;
        //    IEnumerable<NormalUser> records = null;
        //    if (string.IsNullOrWhiteSpace(tableModel.SearchText))
        //        records = _userManager.Users.Skip(start).Take(tableModel.PageSize);
        //    else
        //        records = _userManager.Users.Where(x => x.UserName.Contains(tableModel.SearchText));

        //    return new
        //    {
        //        recordsTotal = total,
        //        recordsFiltered = totalFiltered,
        //        data = (from record in records
        //                select new string[]
        //                {
        //                        record.Id.ToString(),
        //                        record.FirstName+" "+record.LastName,
        //                        record.Email,
        //                        record.PhoneNumber,
        //                        record.Id.ToString(),
        //                        record.Id.ToString()
        //                }
        //            ).ToArray()

        //    };
        //}



        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var allData = _userManager.Users.ToList();
            var userList = new List<UserModel>();
            foreach (var user in allData)
            {
                string roleString = null;
                var roles = await _userManager.GetRolesAsync(user);
                foreach (string role in roles)
                {
                    roleString = roleString + ", " + role;
                    roleString=roleString.TrimStart(',',' ');
                }
                userList.Add(new UserModel
                {
                    Id = user.Id,
                    Name = user.FirstName+" "+user.LastName,
                    Email = user.Email,
                    Roles=roleString,
                    PhoneNumber = user.PhoneNumber
                });
                
            }
            return userList;
        }

        //public string GetRoles(NormalUser user)
        //{
        //    //string roleString = null;
        //    //IEnumerable<ApplicationUserRole> roles = user.UserRoles;

        //    //foreach (ApplicationUserRole role in roles)
        //    //{
        //    //    roleString = roleString + " " + role.Role.Name;
        //    //}
        //    //var roles = await _userManager.GetRolesAsync(user);
        //    //Task<IList<string>> roles;
        //    var roles = await _userManager.GetRolesAsync(user);
        //    foreach (string role in roles.Result)
        //    {
        //        roleString = roleString + " " + role;
        //    }
            
        //    var Users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();


        //    //IList<string> roles = null;
        //    //var roles =  _userManager.GetRolesAsync(user).Result;

        //    return roleString.TrimStart();
        //}
    }
}
