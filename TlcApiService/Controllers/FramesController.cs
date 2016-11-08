using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using TlcApiService.Models;
using TlcApiService.Providers;
using TlcDataAccess;

namespace TlcApiService.Controllers
{
    [BasicAuthorization]
    [RoutePrefix("api/Frames")]
    public class FramesController : ApiController
    {
        [Route("{SerialNumber}")]
        public HttpResponseMessage Get(string serialNumber)
        {
            try
            {
                using (TLC_DBEntities entities = new TLC_DBEntities())
                {
                    var entity = entities.tbFrames.FirstOrDefault(row => row.vcSerialNumber == serialNumber);

                    if (entity != null)
                    {
                        FrameBindingModel frameModel = new FrameBindingModel
                        {
                            Frame = entity
                        };

                        if (entity.vcInstalled.ToString() != "Uninstalled")
                        {
                            frameModel.Fabrics = entities.tbFabrics.Where(row => row.kFrame == entity.kFrame).ToList();
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, frameModel);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found with SerialNumber " + serialNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("Fabric")]
        [HttpPost]
        public HttpResponseMessage AddFabric([FromBody]FabricBindingModel fabricModel)
        {
            try
            {
                using (TLC_DBEntities entities = new TLC_DBEntities())
                {
                    int maxKey = entities.tbFabrics.Max(row => row.kFabric);
                    var client = entities.tbLookClients.FirstOrDefault(row => row.kLookClient == fabricModel.ClientKey);
                    var frame = entities.tbFrames.FirstOrDefault(row => row.kFrame == fabricModel.FrameKey);

                    tbFabric fabric = new tbFabric
                    {
                        kFabric = maxKey + 1,
                        kLookClient = fabricModel.ClientKey,
                        kLookClientCustomer = fabricModel.ClientLocationKey,
                        kFrame = fabricModel.FrameKey,
                        vcSerialNumber = frame.vcSerialNumber,
                        vcExtrusion = fabricModel.Extrusion,
                        vcFileName = fabricModel.FileName,
                        intHeight = fabricModel.Height,
                        intWidth = fabricModel.Width,
                        vcClientID = client.vcClientID,
                        vcClientName = client.vcClientName
                    };

                    frame.vcInstalled = "Installed";
                    entities.tbFabrics.Add(fabric);
                    entities.SaveChanges();
                    
                    return Request.CreateResponse(HttpStatusCode.Created, fabric);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("Fabric/{id}")]
        [HttpDelete]
        public HttpResponseMessage RemoveFabric(int id)
        {
            try
            {
                using (TLC_DBEntities entities = new TLC_DBEntities())
                {
                    var entity = entities.tbFabrics.FirstOrDefault(row => row.kFabric == id);

                    if (entity != null)
                    {
                        entities.tbFabrics.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found with key " + id.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
