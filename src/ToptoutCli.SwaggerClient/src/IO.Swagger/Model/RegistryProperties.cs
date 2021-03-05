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
    /// RegistryProperties
    /// </summary>
    [DataContract]
        public partial class RegistryProperties :  IEquatable<RegistryProperties>
    {
        /// <summary>
        /// Defines Root
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum RootEnum
        {
            /// <summary>
            /// Enum CLASSESROOT for value: HKEY_CLASSES_ROOT
            /// </summary>
            [EnumMember(Value = "HKEY_CLASSES_ROOT")]
            CLASSESROOT = 1,
            /// <summary>
            /// Enum CURRENTCONFIG for value: HKEY_CURRENT_CONFIG
            /// </summary>
            [EnumMember(Value = "HKEY_CURRENT_CONFIG")]
            CURRENTCONFIG = 2,
            /// <summary>
            /// Enum CURRENTUSER for value: HKEY_CURRENT_USER
            /// </summary>
            [EnumMember(Value = "HKEY_CURRENT_USER")]
            CURRENTUSER = 3,
            /// <summary>
            /// Enum CURRENTUSERLOCALSETTINGS for value: HKEY_CURRENT_USER_LOCAL_SETTINGS
            /// </summary>
            [EnumMember(Value = "HKEY_CURRENT_USER_LOCAL_SETTINGS")]
            CURRENTUSERLOCALSETTINGS = 4,
            /// <summary>
            /// Enum LOCALMACHINE for value: HKEY_LOCAL_MACHINE
            /// </summary>
            [EnumMember(Value = "HKEY_LOCAL_MACHINE")]
            LOCALMACHINE = 5,
            /// <summary>
            /// Enum PERFORMANCEDATA for value: HKEY_PERFORMANCE_DATA
            /// </summary>
            [EnumMember(Value = "HKEY_PERFORMANCE_DATA")]
            PERFORMANCEDATA = 6,
            /// <summary>
            /// Enum PERFORMANCENLSTEXT for value: HKEY_PERFORMANCE_NLSTEXT
            /// </summary>
            [EnumMember(Value = "HKEY_PERFORMANCE_NLSTEXT")]
            PERFORMANCENLSTEXT = 7,
            /// <summary>
            /// Enum PERFORMANCETEXT for value: HKEY_PERFORMANCE_TEXT
            /// </summary>
            [EnumMember(Value = "HKEY_PERFORMANCE_TEXT")]
            PERFORMANCETEXT = 8,
            /// <summary>
            /// Enum USERS for value: HKEY_USERS
            /// </summary>
            [EnumMember(Value = "HKEY_USERS")]
            USERS = 9        }
        /// <summary>
        /// Gets or Sets Root
        /// </summary>
        [DataMember(Name="root", EmitDefaultValue=false)]
        public RootEnum Root { get; set; }
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum TypeEnum
        {
            /// <summary>
            /// Enum BINARY for value: REG_BINARY
            /// </summary>
            [EnumMember(Value = "REG_BINARY")]
            BINARY = 1,
            /// <summary>
            /// Enum DWORD for value: REG_DWORD
            /// </summary>
            [EnumMember(Value = "REG_DWORD")]
            DWORD = 2,
            /// <summary>
            /// Enum DWORDLITTLEENDIAN for value: REG_DWORD_LITTLE_ENDIAN
            /// </summary>
            [EnumMember(Value = "REG_DWORD_LITTLE_ENDIAN")]
            DWORDLITTLEENDIAN = 3,
            /// <summary>
            /// Enum DWORDBIGENDIAN for value: REG_DWORD_BIG_ENDIAN
            /// </summary>
            [EnumMember(Value = "REG_DWORD_BIG_ENDIAN")]
            DWORDBIGENDIAN = 4,
            /// <summary>
            /// Enum EXPANDSZ for value: REG_EXPAND_SZ
            /// </summary>
            [EnumMember(Value = "REG_EXPAND_SZ")]
            EXPANDSZ = 5,
            /// <summary>
            /// Enum LINK for value: REG_LINK
            /// </summary>
            [EnumMember(Value = "REG_LINK")]
            LINK = 6,
            /// <summary>
            /// Enum MULTISZ for value: REG_MULTI_SZ
            /// </summary>
            [EnumMember(Value = "REG_MULTI_SZ")]
            MULTISZ = 7,
            /// <summary>
            /// Enum NONE for value: REG_NONE
            /// </summary>
            [EnumMember(Value = "REG_NONE")]
            NONE = 8,
            /// <summary>
            /// Enum QWORD for value: REG_QWORD
            /// </summary>
            [EnumMember(Value = "REG_QWORD")]
            QWORD = 9,
            /// <summary>
            /// Enum QWORDLITTLEENDIAN for value: REG_QWORD_LITTLE_ENDIAN
            /// </summary>
            [EnumMember(Value = "REG_QWORD_LITTLE_ENDIAN")]
            QWORDLITTLEENDIAN = 10,
            /// <summary>
            /// Enum SZ for value: REG_SZ
            /// </summary>
            [EnumMember(Value = "REG_SZ")]
            SZ = 11        }
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryProperties" /> class.
        /// </summary>
        /// <param name="root">root (required).</param>
        /// <param name="path">path (required).</param>
        /// <param name="key">key (required).</param>
        /// <param name="type">type (required).</param>
        /// <param name="value">value (required).</param>
        public RegistryProperties(RootEnum root = default(RootEnum), string path = default(string), string key = default(string), TypeEnum type = default(TypeEnum), Value value = default(Value))
        {
            // to ensure "root" is required (not null)
            if (root == null)
            {
                throw new InvalidDataException("root is a required property for RegistryProperties and cannot be null");
            }
            else
            {
                this.Root = root;
            }
            // to ensure "path" is required (not null)
            if (path == null)
            {
                throw new InvalidDataException("path is a required property for RegistryProperties and cannot be null");
            }
            else
            {
                this.Path = path;
            }
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new InvalidDataException("key is a required property for RegistryProperties and cannot be null");
            }
            else
            {
                this.Key = key;
            }
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for RegistryProperties and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new InvalidDataException("value is a required property for RegistryProperties and cannot be null");
            }
            else
            {
                this.Value = value;
            }
        }
        

        /// <summary>
        /// Gets or Sets Path
        /// </summary>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }

        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [DataMember(Name="key", EmitDefaultValue=false)]
        public string Key { get; set; }


        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public Value Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RegistryProperties {\n");
            sb.Append("  Root: ").Append(Root).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as RegistryProperties);
        }

        /// <summary>
        /// Returns true if RegistryProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of RegistryProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RegistryProperties input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Root == input.Root ||
                    (this.Root != null &&
                    this.Root.Equals(input.Root))
                ) && 
                (
                    this.Path == input.Path ||
                    (this.Path != null &&
                    this.Path.Equals(input.Path))
                ) && 
                (
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Root != null)
                    hashCode = hashCode * 59 + this.Root.GetHashCode();
                if (this.Path != null)
                    hashCode = hashCode * 59 + this.Path.GetHashCode();
                if (this.Key != null)
                    hashCode = hashCode * 59 + this.Key.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                return hashCode;
            }
        }
    }
}