using System;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02000251 RID: 593
// (Invoke) Token: 0x06000AF7 RID: 2807
[EventRule(EEventName.TrackMapMark)]
internal delegate void Delegate_TrackMapMark(EMarkType martType, int markId, bool isTrack);
