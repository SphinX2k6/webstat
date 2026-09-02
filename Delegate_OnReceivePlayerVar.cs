using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x020001C3 RID: 451
// (Invoke) Token: 0x060008BF RID: 2239
[EventRule(EEventName.OnReceivePlayerVar)]
internal delegate void Delegate_OnReceivePlayerVar(IReadOnlyDictionary<string, VarDefinePb> varInfos);
