/*
 * DotAAS Part 2 | HTTP/REST | Asset Administration Shell Repository
 *
 * An exemplary interface combination for the use case of an Asset Administration Shell Repository
 *
 * OpenAPI spec version: Final-Draft
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Referable : HasExtensions, IEquatable<Referable>
    { 
        /// <summary>
        /// Gets or Sets Category
        /// </summary>

        [DataMember(Name="category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [DataMember(Name="description")]
        public List<LangString> Description { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>

        [DataMember(Name="displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets IdShort
        /// </summary>
        [Required]

        [DataMember(Name="idShort")]
        public string IdShort { get; set; }

        /// <summary>
        /// Gets or Sets ModelType
        /// </summary>
        [Required]

        [DataMember(Name="modelType")]
        public ModelType ModelType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Referable {\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  IdShort: ").Append(IdShort).Append("\n");
            sb.Append("  ModelType: ").Append(ModelType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Referable)obj);
        }

        /// <summary>
        /// Returns true if Referable instances are equal
        /// </summary>
        /// <param name="other">Instance of Referable to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Referable other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Category == other.Category ||
                    Category != null &&
                    Category.Equals(other.Category)
                ) && 
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.SequenceEqual(other.Description)
                ) && 
                (
                    DisplayName == other.DisplayName ||
                    DisplayName != null &&
                    DisplayName.Equals(other.DisplayName)
                ) && 
                (
                    IdShort == other.IdShort ||
                    IdShort != null &&
                    IdShort.Equals(other.IdShort)
                ) && 
                (
                    ModelType == other.ModelType ||
                    ModelType != null &&
                    ModelType.Equals(other.ModelType)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Category != null)
                    hashCode = hashCode * 59 + Category.GetHashCode();
                    if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                    if (DisplayName != null)
                    hashCode = hashCode * 59 + DisplayName.GetHashCode();
                    if (IdShort != null)
                    hashCode = hashCode * 59 + IdShort.GetHashCode();
                    if (ModelType != null)
                    hashCode = hashCode * 59 + ModelType.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Referable left, Referable right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Referable left, Referable right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
