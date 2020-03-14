namespace API.UI.Account
{
    using API.ViewModels;
    using App.Boundaries.Account.Register;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public sealed class RegisterPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Output(RegisterOutput output)
        {
            //var tables = new List<TableDetailsModel>();
            //foreach (var item in output.Account.Tables.GetTables())
            //{
            //    var tasks = new List<TableTaskModel>();

            //    foreach (var task in item.GetTasks())
            //    {
            //        tasks.Add(new TableTaskModel(
            //            task.Id.ToGuid(), 
            //            task.Text.ToString(), 
            //            (int)task.State));
            //    }

            //    tables.Add(new TableDetailsModel(
            //        item.Name.ToString(), 
            //        item.Id.ToGuid(), 
            //        (int)item.State, 
            //        tasks));
            //}

            //var accountDetails = new AccountDetailsModel(
            //    output.UserName, tables, output.Account.Id.ToGuid());

            var res = "ABC";

            ViewModel = new OkObjectResult(res);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
