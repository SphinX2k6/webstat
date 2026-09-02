using System;
using Aki.TDConfigMgr.Quest;

// Token: 0x02000B60 RID: 2912
// (Invoke) Token: 0x06002F33 RID: 12083
[EventRule(EEventName.OnArcadeGameplayFinish)]
internal delegate void Delegate_OnArcadeGameplayFinish(EArcadeGameplayType type, int levelId);
