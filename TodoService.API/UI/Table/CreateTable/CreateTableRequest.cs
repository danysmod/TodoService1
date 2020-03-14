namespace API.UI.Table.CreateTable
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public sealed class CreateTableRequest
    {
        [Required]
        public string TableName { get; set; }
    }
}
