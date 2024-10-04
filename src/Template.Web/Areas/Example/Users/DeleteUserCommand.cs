using System;
using Template.Services.Shared;

namespace Template.Web.Areas.Example.Users
{
    internal class DeleteUserCommand : AddOrUpdateUserCommand
    {
        public Guid Id { get; set; }
    }
}