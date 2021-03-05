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
    /// ExecScope
    /// </summary>
    [DataContract]
        public partial class ExecScope :  IEquatable<ExecScope>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecScope" /> class.
        /// </summary>
        /// <param name="machine">machine.</param>
        /// <param name="user">user.</param>
        /// <param name="process">process.</param>
        public ExecScope(ExecProperties machine = default(ExecProperties), ExecProperties user = default(ExecProperties), ExecProperties process = default(ExecProperties))
        {
            this.Machine = machine;
            this.User = user;
            this.Process = process;
        }
        
        /// <summary>
        /// Gets or Sets Machine
        /// </summary>
        [DataMember(Name="machine", EmitDefaultValue=false)]
        public ExecProperties Machine { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name="user", EmitDefaultValue=false)]
        public ExecProperties User { get; set; }

        /// <summary>
        /// Gets or Sets Process
        /// </summary>
        [DataMember(Name="process", EmitDefaultValue=false)]
        public ExecProperties Process { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ExecScope {\n");
            sb.Append("  Machine: ").Append(Machine).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  Process: ").Append(Process).Append("\n");
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
            return this.Equals(input as ExecScope);
        }

        /// <summary>
        /// Returns true if ExecScope instances are equal
        /// </summary>
        /// <param name="input">Instance of ExecScope to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExecScope input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Machine == input.Machine ||
                    (this.Machine != null &&
                    this.Machine.Equals(input.Machine))
                ) && 
                (
                    this.User == input.User ||
                    (this.User != null &&
                    this.User.Equals(input.User))
                ) && 
                (
                    this.Process == input.Process ||
                    (this.Process != null &&
                    this.Process.Equals(input.Process))
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
                if (this.Machine != null)
                    hashCode = hashCode * 59 + this.Machine.GetHashCode();
                if (this.User != null)
                    hashCode = hashCode * 59 + this.User.GetHashCode();
                if (this.Process != null)
                    hashCode = hashCode * 59 + this.Process.GetHashCode();
                return hashCode;
            }
        }
    }
}