using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TlcDataAccess;

namespace TlcApiService.Models
{
    public class FrameBindingModel
    {
        [Required]
        public tbFrame Frame { get; set; }

        public List<tbFabric> Fabrics { get; set; }
    }

    public class FabricBindingModel
    {
        /*
          ,[kLookClient]
          ,[kLookClientCustomer]
          ,[kFrame]
          ,[vcItemNumber]
          ,[vcSerialNumber]
          ,[intHeight]
          ,[intWidth]
          ,[vcExtrusion]
          ,[vcFileName]
          ,[vcNFCUrl]
          ,[vcLookCSR]
          ,[dtShippedFromTLC]
          ,[dtInstalled]
          ,[vcSource]
          ,[vcClientID]
          ,[vcClientName]
          ,[vcStatus]
      */

        [Required]
        public int ClientKey { get; set; }

        [Required]
        public int ClientLocationKey { get; set; }

        [Required]
        public int FrameKey { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public string Extrusion { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}