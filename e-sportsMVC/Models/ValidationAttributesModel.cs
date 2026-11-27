using System.ComponentModel.DataAnnotations;

namespace e_sportsMVC.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UniqueAttribute : ValidationAttribute
    {
        private readonly Type _entityType;
        private readonly string? _propertyName;

        public UniqueAttribute(Type entityType, string? propertyName = null)
        {
            _entityType = entityType;
            _propertyName = propertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || (value is string str && string.IsNullOrWhiteSpace(str)))
                return ValidationResult.Success;

            string targetProperty = _propertyName ?? validationContext.MemberName!;

            var type = validationContext.GetType;
            var idProperty = validationContext.ObjectType.GetProperty("ID");

            bool exists = false;
            switch (_entityType)
            {
                case Type t when t == typeof(ChampionShipModel):
                    exists = DataBaseModel.ChampionShips.Exists(c => c.ID.ToString() == value.ToString());
                    break;

                case Type t when t == typeof(MatchModel):
                    exists = DataBaseModel.MatchesIDs.Exists(c => c.ToString() == value.ToString());
                    break;

                case Type t when t == typeof(PlayerModel):
                    exists = DataBaseModel.PlayersIDs.Exists(c => c.ToString() == value.ToString()); 
                    break;

                case Type t when t == typeof(TeamModel):
                    exists = DataBaseModel.TeamsIDs.Exists(c => c.ToString() == value.ToString());
                    break;

                case Type t when t == typeof(TournamentModel):
                    exists = DataBaseModel.TournamentsIDs.Exists(c => c.ToString() == value.ToString());
                    break;

                case Type t when t == typeof(UserModel):
                    exists = DataBaseModel.UsersIDs.Exists(c => c.ToString() == value.ToString());
                    break;
            } 

            return exists ? new ValidationResult("This ID is already in use") : ValidationResult.Success;
        }
    }
}
