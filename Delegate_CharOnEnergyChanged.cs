using System;
using Aki.Protocol;

// Token: 0x0200013B RID: 315
// (Invoke) Token: 0x0600069F RID: 1695
[EventRule(EEventName.CharOnEnergyChanged)]
internal delegate void Delegate_CharOnEnergyChanged(EAttributeType attr, float newValue, float oldValue);
