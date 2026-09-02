using System;
using Aki.Protocol;

// Token: 0x020001B9 RID: 441
// (Invoke) Token: 0x06000897 RID: 2199
[EventRule(EEventName.EntityVarUpdate)]
internal delegate void Delegate_EntityVarUpdate(string name, VarDefinePb variable);
