﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnInteract();
}

public interface IChargeable
{
    void OnChargeEvent();
}
