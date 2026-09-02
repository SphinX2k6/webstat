using System;
using Aki.Protocol;

// Token: 0x02000489 RID: 1161
// (Invoke) Token: 0x060013D7 RID: 5079
[EventRule(EEventName.OnAttributeLockUpperBoundChange)]
internal delegate void Delegate_OnAttributeLockUpperBoundChange(int entityId, EAttributeType attributeId);
