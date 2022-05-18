using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionChecker : DropCondition
{
    public override bool Check(DraggableComponent draggable,EquipmentPart slotEquipmentPart)
    {
        var item = draggable.item;
        return item != null && item.equipmenttype == slotEquipmentPart;
    }
}
