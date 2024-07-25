 namespace SuperShop.Data.Entities
{
    public interface IEntity
    {

        int Id { get; set; }

        //Useful to allow items to be marked as deleted while still existing
        //bool WasDeleted {  get; set; }



    }
}
