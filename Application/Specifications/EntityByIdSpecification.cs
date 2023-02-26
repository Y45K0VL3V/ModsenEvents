using Domain.Primitives;

namespace Application.Specifications
{
    public class EntityByIdSpecification<T> : SpecificationBase<T> where T : EntityBase
    {
        public EntityByIdSpecification(Guid id) 
        {
            Criteria = mEvent => mEvent.Id == id;
        }
    }
}
