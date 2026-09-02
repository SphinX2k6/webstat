using System;
using CSharpScript.Game.NewWorld.Pawn.Component;

// Token: 0x02000946 RID: 2374
// (Invoke) Token: 0x060026CB RID: 9931
[EventRule(EEventName.OnForeverTimeDilationRemove)]
internal delegate void Delegate_OnForeverTimeDilationRemove(ETimeScaleSourceType type, float timeScale, int priority);
