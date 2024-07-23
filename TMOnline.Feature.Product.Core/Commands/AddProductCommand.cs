using System.ComponentModel.DataAnnotations;

using MediatR;

using TMOnline.Feature.Product.Core.Resources;

namespace TMOnline.Feature.Product.Core.Commands
{
    public class AddProductCommand : IRequest<Shared.Entities.Product>
    {
        [Required(ErrorMessageResourceName = nameof(ValidationErrorMessages.Required), ErrorMessageResourceType = typeof(ValidationErrorMessages))]
        [StringLength(255, ErrorMessageResourceName = nameof(ValidationErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ValidationErrorMessages))]
        public string Name { get; set; }

        [Required]
        public int TransactionYearId { get; set; }
    }
}
