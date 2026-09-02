using System;
using System.Collections.Generic;
using UnrealEngine;

// Token: 0x020003DF RID: 991
// (Invoke) Token: 0x0600112F RID: 4399
[EventRule(EEventName.MotorcycleBaseMovementChanged)]
internal delegate void Delegate_MotorcycleBaseMovementChanged(IReadOnlySet<UPrimitiveComponent> newBaseMovementSet);
