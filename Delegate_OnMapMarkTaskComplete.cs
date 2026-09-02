using System;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02000253 RID: 595
// (Invoke) Token: 0x06000AFF RID: 2815
[EventRule(EEventName.OnMapMarkTaskComplete)]
internal delegate void Delegate_OnMapMarkTaskComplete(EMarkType markType, int markId);
