public interface IInsertable
{
    bool CanInsert(GameEnums.GrabItems item);
    void Insert(IGrabbable grabbable); 
}
