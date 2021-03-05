/* 
 * Toptout
 *
 * Get data about telemetry channels in various applications
 *
 * OpenAPI spec version: 0.0.1
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
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Toptout
    /// </summary>
    [DataContract]
        public partial class Toptout :  IEquatable<Toptout>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Toptout" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="executableName">executableName.</param>
        /// <param name="description">description (required).</param>
        /// <param name="categoryId">categoryId (required).</param>
        /// <param name="categoryName">categoryName (required).</param>
        /// <param name="links">links (required).</param>
        /// <param name="telemetry">telemetry.</param>
        public Toptout(string id = default(string), string name = default(string), string executableName = default(string), string description = default(string), string categoryId = default(string), string categoryName = default(string), Links links = default(Links), List<Telemetry> telemetry = default(List<Telemetry>))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for Toptout and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for Toptout and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new InvalidDataException("description is a required property for Toptout and cannot be null");
            }
            else
            {
                this.Description = description;
            }
            // to ensure "categoryId" is required (not null)
            if (categoryId == null)
            {
                throw new InvalidDataException("categoryId is a required property for Toptout and cannot be null");
            }
            else
            {
                this.CategoryId = categoryId;
            }
            // to ensure "categoryName" is required (not null)
            if (categoryName == null)
            {
                throw new InvalidDataException("categoryName is a required property for Toptout and cannot be null");
            }
            else
            {
                this.CategoryName = categoryName;
            }
            // to ensure "links" is required (not null)
            if (links == null)
            {
                throw new InvalidDataException("links is a required property for Toptout and cannot be null");
            }
            else
            {
                this.Links = links;
            }
            this.ExecutableName = executableName;
            this.Telemetry = telemetry;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ExecutableName
        /// </summary>
        [DataMember(Name="executable_name", EmitDefaultValue=false)]
        public string ExecutableName { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets CategoryId
        /// </summary>
        [DataMember(Name="category_id", EmitDefaultValue=false)]
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or Sets CategoryName
        /// </summary>
        [DataMember(Name="category_name", EmitDefaultValue=false)]
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue=false)]
        public Links Links { get; set; }

        /// <summary>
        /// Gets or Sets Telemetry
        /// </summary>
        [DataMember(Name="telemetry", EmitDefaultValue=false)]
        public List<Telemetry> Telemetry { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Toptout {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ExecutableName: ").Append(ExecutableName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  CategoryId: ").Append(CategoryId).Append("\n");
            sb.Append("  CategoryName: ").Append(CategoryName).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
            sb.Append("  Telemetry: ").Append(Telemetry).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Toptout);
        }

        /// <summary>
        /// Returns true if Toptout instances are equal
        /// </summary>
        /// <param name="input">Instance of Toptout to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Toptout input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.ExecutableName == input.ExecutableName ||
                    (this.ExecutableName != null &&
                    this.ExecutableName.Equals(input.ExecutableName))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.CategoryId == input.CategoryId ||
                    (this.CategoryId != null &&
                    this.CategoryId.Equals(input.CategoryId))
                ) && 
                (
                    this.CategoryName == input.CategoryName ||
                    (this.CategoryName != null &&
                    this.CategoryName.Equals(input.CategoryName))
                ) && 
                (
                    this.Links == input.Links ||
                    (this.Links != null &&
                    this.Links.Equals(input.Links))
                ) && 
                (
                    this.Telemetry == input.Telemetry ||
                    this.Telemetry != null &&
                    input.Telemetry != null &&
                    this.Telemetry.SequenceEqual(input.Telemetry)
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
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.ExecutableName != null)
                    hashCode = hashCode * 59 + this.ExecutableName.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.CategoryId != null)
                    hashCode = hashCode * 59 + this.CategoryId.GetHashCode();
                if (this.CategoryName != null)
                    hashCode = hashCode * 59 + this.CategoryName.GetHashCode();
                if (this.Links != null)
                    hashCode = hashCode * 59 + this.Links.GetHashCode();
                if (this.Telemetry != null)
                    hashCode = hashCode * 59 + this.Telemetry.GetHashCode();
                return hashCode;
            }
        }
    }
}