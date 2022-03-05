/*
 * DotAAS Part 2 | HTTP/REST | Registry and Discovery
 *
 * The registry and discovery interface as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: Final-Draft
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Registry.Attributes;
using IO.Swagger.Registry.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IO.Swagger.Registry.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class RegistryAndDiscoveryInterfaceApiController : ControllerBase
    {
        /// <summary>
        /// Deletes all Asset identifier key-value-pair linked to an Asset Administration Shell to edit discoverable content
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Asset identifier key-value-pairs deleted successfully</response>
        [HttpDelete]
        [Route("/lookup/shells/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteAllAssetLinksById")]
        public virtual IActionResult DeleteAllAssetLinksById([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an Asset Administration Shell Descriptor, i.e. de-registers an AAS
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Asset Administration Shell Descriptor deleted successfully</response>
        [HttpDelete]
        [Route("/registry/shell-descriptors/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteAssetAdministrationShellDescriptorById")]
        public virtual IActionResult DeleteAssetAdministrationShellDescriptorById([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a Submodel Descriptor, i.e. de-registers a submodel
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Submodel Descriptor deleted successfully</response>
        [HttpDelete]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteSubmodelDescriptorById")]
        public virtual IActionResult DeleteSubmodelDescriptorById([FromRoute][Required] string aasIdentifier, [FromRoute][Required] string submodelIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all Asset Administration Shell Descriptors
        /// </summary>
        /// <response code="200">Requested Asset Administration Shell Descriptors</response>
        [HttpGet]
        [Route("/registry/shell-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("GetAllAssetAdministrationShellDescriptors")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<AssetAdministrationShellDescriptor>), description: "Requested Asset Administration Shell Descriptors")]
        public virtual IActionResult GetAllAssetAdministrationShellDescriptors()
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<AssetAdministrationShellDescriptor>));
            /*
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<AssetAdministrationShellDescriptor>>(exampleJson)
            : default(List<AssetAdministrationShellDescriptor>);            //TODO: Change the data returned
            return new ObjectResult(example);
            */
            try
            {
                //collect aasetIds
                var aasList = new List<AssetAdministrationShellDescriptor>();

                foreach (AdminShellNS.AdminShellPackageEnv env in AasxServer.Program.env)
                {
                    if (env != null)
                    {
                        AssetAdministrationShellDescriptor ad = new AssetAdministrationShellDescriptor();
                        var aas = env.AasEnv.AdministrationShells[0];
                        string assetId = aas.assetRef?[0].value;

                        // ad.Administration.Version = aas.administration.version;
                        // ad.Administration.Revision = aas.administration.revision;
                        ad.IdShort = aas.idShort;
                        ad.Identification = aas.identification.id;
                        var e = new Endpoint();
                        e.ProtocolInformation = new ProtocolInformation();
                        e.ProtocolInformation.EndpointAddress =
                            AasxServer.Program.externalBlazor + "/shells/" +
                            Base64UrlEncoder.Encode(ad.Identification) +
                            "/aas";
                        ad.Endpoints = new List<Endpoint>();
                        ad.Endpoints.Add(e);
                        aasList.Add(ad);
                    }
                }

                return new ObjectResult(aasList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a list of Asset Administration Shell ids based on Asset identifier key-value-pairs
        /// </summary>
        /// <param name="assetIds">The key-value-pair of an Asset identifier</param>
        /// <param name="assetId">An Asset identifier</param>
        /// <response code="200">Requested Asset Administration Shell ids</response>
        [HttpGet]
        [Route("/lookup/shells")]
        [ValidateModelState]
        [SwaggerOperation("GetAllAssetAdministrationShellIdsByAssetLink")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<string>), description: "Requested Asset Administration Shell ids")]
        public virtual IActionResult GetAllAssetAdministrationShellIdsByAssetLink(
            [FromQuery] List<IdentifierKeyValuePair> assetIds,
            [FromQuery] String assetId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<string>));
            /*
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<string>>(exampleJson)
                        : default(List<string>);            //TODO: Change the data returned
            return new ObjectResult(example);

            [
            {"key": "globalAssetId", "subjectId": "x", "value": "http://example.company/myAsset"},
            {"key": "myOwnInternalAssetId", "subjectId": "x", "value": "12345ABC"}
            ]
            */

            try
            {
                //collect aasetIds
                var assetList = new List<String>();
                foreach (var kv in assetIds)
                {
                    if (kv.Value != "")
                        assetList.Add(kv.Value);
                }

                var aasList = new List<String>();

                foreach (AdminShellNS.AdminShellPackageEnv env in AasxServer.Program.env)
                {
                    if (env != null)
                    {
                        string asset = "";
                        var assetRef = env.AasEnv.AdministrationShells[0].assetRef;
                        if (assetRef != null && assetRef.Count != 0)
                            asset = env.AasEnv.AdministrationShells[0].assetRef?[0].value;

                        // if (assetList.Count == 0 || asset == null ||
                        //    assetList.Contains(asset))
                        if (assetId == "" || assetId == asset)
                        {
                            aasList.Add(env.AasEnv.AdministrationShells[0].identification.id);
                        }
                    }
                }

                return new ObjectResult(aasList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a list of Asset identifier key-value-pairs based on an Asset Administration Shell id to edit discoverable content
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested Asset identifier key-value-pairs</response>
        [HttpGet]
        [Route("/lookup/shells/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("GetAllAssetLinksById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<IdentifierKeyValuePair>), description: "Requested Asset identifier key-value-pairs")]
        public virtual IActionResult GetAllAssetLinksById([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<IdentifierKeyValuePair>));
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<IdentifierKeyValuePair>>(exampleJson)
            : default(List<IdentifierKeyValuePair>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Returns all Submodel Descriptors
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested Submodel Descriptors</response>
        [HttpGet]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("GetAllSubmodelDescriptors")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SubmodelDescriptor>), description: "Requested Submodel Descriptors")]
        public virtual IActionResult GetAllSubmodelDescriptors([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<SubmodelDescriptor>));
            string exampleJson = null;
            exampleJson = "[ {\n  \"semanticId\" : \"\",\n  \"identification\" : \"identification\",\n  \"idShort\" : \"idShort\",\n  \"administration\" : {\n    \"version\" : \"version\",\n    \"revision\" : \"revision\"\n  },\n  \"description\" : [ {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  }, {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  } ]\n}, {\n  \"semanticId\" : \"\",\n  \"identification\" : \"identification\",\n  \"idShort\" : \"idShort\",\n  \"administration\" : {\n    \"version\" : \"version\",\n    \"revision\" : \"revision\"\n  },\n  \"description\" : [ {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  }, {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  } ]\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<SubmodelDescriptor>>(exampleJson)
            : default(List<SubmodelDescriptor>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Returns a specific Asset Administration Shell Descriptor
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested Asset Administration Shell Descriptor</response>
        [HttpGet]
        [Route("/registry/shell-descriptors/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("GetAssetAdministrationShellDescriptorById")]
        [SwaggerResponse(statusCode: 200, type: typeof(AssetAdministrationShellDescriptor), description: "Requested Asset Administration Shell Descriptor")]
        public virtual IActionResult GetAssetAdministrationShellDescriptorById([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(AssetAdministrationShellDescriptor));
            /*
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<AssetAdministrationShellDescriptor>(exampleJson)
            : default(AssetAdministrationShellDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
            */
            try
            {
                //collect aasetIds
                var aasList = new List<AssetAdministrationShellDescriptor>();

                foreach (AdminShellNS.AdminShellPackageEnv env in AasxServer.Program.env)
                {
                    if (env != null)
                    {
                        AssetAdministrationShellDescriptor ad = new AssetAdministrationShellDescriptor();
                        var aas = env.AasEnv.AdministrationShells[0];
                        string assetId = aas.assetRef?[0].value;

                        var aasId = Base64UrlEncoder.Encode(aas.identification.id);

                        if (aasId == aasIdentifier)
                        {
                            // ad.Administration.Version = aas.administration.version;
                            // ad.Administration.Revision = aas.administration.revision;
                            ad.IdShort = aas.idShort;
                            ad.Identification = aas.identification.id;
                            var e = new Endpoint();
                            e.ProtocolInformation = new ProtocolInformation();
                            e.ProtocolInformation.EndpointAddress =
                                AasxServer.Program.externalBlazor + "/shells/" +
                                Base64UrlEncoder.Encode(ad.Identification) +
                                "/aas";
                            ad.Endpoints = new List<Endpoint>();
                            ad.Endpoints.Add(e);
                            aasList.Add(ad);
                        }
                    }
                }

                return new ObjectResult(aasList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a specific Submodel Descriptor
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested Submodel Descriptor</response>
        [HttpGet]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("GetSubmodelDescriptorById")]
        [SwaggerResponse(statusCode: 200, type: typeof(SubmodelDescriptor), description: "Requested Submodel Descriptor")]
        public virtual IActionResult GetSubmodelDescriptorById([FromRoute][Required] string aasIdentifier, [FromRoute][Required] string submodelIdentifier)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(SubmodelDescriptor));
            string exampleJson = null;
            exampleJson = "{\n  \"semanticId\" : \"\",\n  \"identification\" : \"identification\",\n  \"idShort\" : \"idShort\",\n  \"administration\" : {\n    \"version\" : \"version\",\n    \"revision\" : \"revision\"\n  },\n  \"description\" : [ {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  }, {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  } ]\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<SubmodelDescriptor>(exampleJson)
            : default(SubmodelDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Creates all Asset identifier key-value-pair linked to an Asset Administration Shell to edit discoverable content
        /// </summary>
        /// <param name="body">Asset identifier key-value-pairs</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="201">Asset identifier key-value-pairs created successfully</response>
        [HttpPost]
        [Route("/lookup/shells/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("PostAllAssetLinksById")]
        [SwaggerResponse(statusCode: 201, type: typeof(List<IdentifierKeyValuePair>), description: "Asset identifier key-value-pairs created successfully")]
        public virtual IActionResult PostAllAssetLinksById([FromBody] List<IdentifierKeyValuePair> body, [FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(List<IdentifierKeyValuePair>));
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<IdentifierKeyValuePair>>(exampleJson)
            : default(List<IdentifierKeyValuePair>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Creates a new Asset Administration Shell Descriptor, i.e. registers an AAS
        /// </summary>
        /// <param name="body">Asset Administration Shell Descriptor object</param>
        /// <response code="201">Asset Administration Shell Descriptor created successfully</response>
        [HttpPost]
        [Route("/registry/shell-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("PostAssetAdministrationShellDescriptor")]
        [SwaggerResponse(statusCode: 201, type: typeof(AssetAdministrationShellDescriptor), description: "Asset Administration Shell Descriptor created successfully")]
        public virtual IActionResult PostAssetAdministrationShellDescriptor([FromBody] AssetAdministrationShellDescriptor body)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(AssetAdministrationShellDescriptor));
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<AssetAdministrationShellDescriptor>(exampleJson)
            : default(AssetAdministrationShellDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Creates a new Submodel Descriptor, i.e. registers a submodel
        /// </summary>
        /// <param name="body">Submodel Descriptor object</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="201">Submodel Descriptor created successfully</response>
        [HttpPost]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("PostSubmodelDescriptor")]
        [SwaggerResponse(statusCode: 201, type: typeof(SubmodelDescriptor), description: "Submodel Descriptor created successfully")]
        public virtual IActionResult PostSubmodelDescriptor([FromBody] SubmodelDescriptor body, [FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(SubmodelDescriptor));
            string exampleJson = null;
            exampleJson = "{\n  \"semanticId\" : \"\",\n  \"identification\" : \"identification\",\n  \"idShort\" : \"idShort\",\n  \"administration\" : {\n    \"version\" : \"version\",\n    \"revision\" : \"revision\"\n  },\n  \"description\" : [ {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  }, {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  } ]\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<SubmodelDescriptor>(exampleJson)
            : default(SubmodelDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Updates an existing Asset Administration Shell Descriptor
        /// </summary>
        /// <param name="body">Asset Administration Shell Descriptor object</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Asset Administration Shell Descriptor updated successfully</response>
        [HttpPut]
        [Route("/registry/shell-descriptors/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("PutAssetAdministrationShellDescriptorById")]
        public virtual IActionResult PutAssetAdministrationShellDescriptorById([FromBody] AssetAdministrationShellDescriptor body, [FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing Submodel Descriptor
        /// </summary>
        /// <param name="body">Submodel Descriptor object</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Submodel Descriptor updated successfully</response>
        [HttpPut]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("PutSubmodelDescriptorById")]
        public virtual IActionResult PutSubmodelDescriptorById([FromBody] SubmodelDescriptor body, [FromRoute][Required] string aasIdentifier, [FromRoute][Required] string submodelIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }
    }
}
