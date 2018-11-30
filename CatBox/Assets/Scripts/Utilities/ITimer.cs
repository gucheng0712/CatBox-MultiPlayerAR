using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimer
{
     float CurrentTime { get; set; }
     float CoolDown { get; set; }
}
