using System;
using UnrealEngine;

// Token: 0x02000130 RID: 304
// (Invoke) Token: 0x06000673 RID: 1651
[EventRule(EEventName.CharMovementModeChanged)]
internal delegate void Delegate_CharMovementModeChanged(int charId, EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode);
