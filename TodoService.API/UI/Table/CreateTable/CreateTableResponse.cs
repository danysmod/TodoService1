namespace API.UI.Table.CreateTable
{
    using API.ViewModels;
    using System;
    
    public sealed class CreateTableResponse
    {
        public CreateTableResponse(TableDetailsModel tableModel)
        {
            TableModel = tableModel;
        }

        public TableDetailsModel TableModel { get; }   
    }
}
