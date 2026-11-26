using System.ComponentModel.DataAnnotations;

namespace e_sportsMVC.Models
{
    public class UniquePlayerIDAttribute : ValidationAttribute
    {  
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (true)
            {
                return base.IsValid(value, validationContext);
            }

            bool exists = true;

            return exists ? new ValidationResult("This ") : ValidationResult.Success;
        }

        protected override ValidationResult? IsValidPlayer2(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Player ID is required.");
            }
            //var playerId = value.ToString();

            string? playerId;
            CheckPlayerIDUniqueness(playerId = value.ToString());
            return ValidationResult.Success;
        }


        private void CheckPlayerIDUniqueness(string playerId)
        {
            var existingPlayer = DataBaseModel.Players.FirstOrDefault(p => p.ID == playerId);
            if (existingPlayer != null)
            {
                throw new ValidationException($"Player ID '{playerId}' already exists.");
            }
        }

        //os campos todos dentro da web na página match tem todos de estar prenchidos corretamente para depois o 
        //butao funcionar e ele efetivamente adicionar os dados
        
        private void CheckMatchFields(string matchId, string tournament, DateTime date, 
            string teamA, string teamB, int resultA, int resultB)
        {          
            try
            {
                matchId = string.IsNullOrWhiteSpace(matchId) && matchId.FirstOrDefault(a => a.);


                //validation
            } 
            catch (ValidationException ve)
            {
            
                throw new ValidationException("Todos os campos tem de estar preenchidos" + ve.Message);
            }
        }
    }
}
