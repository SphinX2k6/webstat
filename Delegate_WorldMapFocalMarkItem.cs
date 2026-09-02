using System;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02000281 RID: 641
// (Invoke) Token: 0x06000BB7 RID: 2999
[EventRule(EEventName.WorldMapFocalMarkItem)]
internal delegate void Delegate_WorldMapFocalMarkItem(int markId, EMarkType markType, bool focal, bool focusTween, bool? needTempShow);
