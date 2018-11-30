using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrackableEventHandler : DefaultTrackableEventHandler {

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Cat cat = GetComponentInChildren<Cat>();
        cat.CheckMarkerControlStatus(cat.catModel.imageTargetID); 
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
    }
}
