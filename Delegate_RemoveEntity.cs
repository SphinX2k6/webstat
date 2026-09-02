using System;
using Aki.Protocol;

// Token: 0x020001B6 RID: 438
// (Invoke) Token: 0x0600088B RID: 2187
[EventRule(EEventName.RemoveEntity)]
internal delegate void Delegate_RemoveEntity(ERemoveEntityType removeType, EntityHandle handle);
