/* 
 * OpenHack
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Team Roster for Register API
    /// </summary>
    [DataContract]
    public partial class TeamRosterModel :  IEquatable<TeamRosterModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRosterModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TeamRosterModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRosterModel" /> class.
        /// </summary>
        /// <param name="TeamId">Team Id (available in the channelData object of Activity) (required).</param>
        /// <param name="Members">Array of Members (available from GetConversationMembersAsync method) (required).</param>
        public TeamRosterModel(string TeamId = default(string), List<TeamRosterMemberModel> Members = default(List<TeamRosterMemberModel>))
        {
            // to ensure "TeamId" is required (not null)
            if (TeamId == null)
            {
                throw new InvalidDataException("TeamId is a required property for TeamRosterModel and cannot be null");
            }
            else
            {
                this.TeamId = TeamId;
            }
            // to ensure "Members" is required (not null)
            if (Members == null)
            {
                throw new InvalidDataException("Members is a required property for TeamRosterModel and cannot be null");
            }
            else
            {
                this.Members = Members;
            }
        }
        
        /// <summary>
        /// Team Id (available in the channelData object of Activity)
        /// </summary>
        /// <value>Team Id (available in the channelData object of Activity)</value>
        [DataMember(Name="teamId", EmitDefaultValue=false)]
        public string TeamId { get; set; }

        /// <summary>
        /// Array of Members (available from GetConversationMembersAsync method)
        /// </summary>
        /// <value>Array of Members (available from GetConversationMembersAsync method)</value>
        [DataMember(Name="members", EmitDefaultValue=false)]
        public List<TeamRosterMemberModel> Members { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TeamRosterModel {\n");
            sb.Append("  TeamId: ").Append(TeamId).Append("\n");
            sb.Append("  Members: ").Append(Members).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return this.Equals(input as TeamRosterModel);
        }

        /// <summary>
        /// Returns true if TeamRosterModel instances are equal
        /// </summary>
        /// <param name="input">Instance of TeamRosterModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TeamRosterModel input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.TeamId == input.TeamId ||
                    (this.TeamId != null &&
                    this.TeamId.Equals(input.TeamId))
                ) && 
                (
                    this.Members == input.Members ||
                    this.Members != null &&
                    this.Members.SequenceEqual(input.Members)
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
                if (this.TeamId != null)
                    hashCode = hashCode * 59 + this.TeamId.GetHashCode();
                if (this.Members != null)
                    hashCode = hashCode * 59 + this.Members.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}