using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.ViewModel
{
    public class DocumentViewModel
    {
        public string DocumentName { get; set; } //used to display the file name from database.
        public string FolderDocumentName { get; set; } //used to display the file name from the folder
        public string FolderDocumentPath { get; set; }   //file parth
        public byte[] DocumentContent { get; set; }       //the file content in the database. 
        public IFormFile FormDocument{ get; set; }       // this is used to upload file.
    }
}
