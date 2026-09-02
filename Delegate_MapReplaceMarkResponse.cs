using System;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x0200024C RID: 588
// (Invoke) Token: 0x06000AE3 RID: 2787
[EventRule(EEventName.MapReplaceMarkResponse)]
internal delegate void Delegate_MapReplaceMarkResponse(EMarkType markType, int markId, int newConfigId);
