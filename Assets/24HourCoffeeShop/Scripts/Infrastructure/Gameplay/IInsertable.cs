using System;
using System.Collections.Generic;
using System.Text;

public interface IInsertable
{
    bool CanInsert(GameEnums.GrabItems item);
    void Insert(IGrabbable grabbable); 
}
