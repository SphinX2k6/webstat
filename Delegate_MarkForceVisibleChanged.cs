using System;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02000259 RID: 601
// (Invoke) Token: 0x06000B17 RID: 2839
[EventRule(EEventName.MarkForceVisibleChanged)]
internal delegate void Delegate_MarkForceVisibleChanged(EMarkType markType, int markId, bool currentVisible);
