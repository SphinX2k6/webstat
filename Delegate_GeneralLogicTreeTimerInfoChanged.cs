using System;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;

// Token: 0x020003C3 RID: 963
// (Invoke) Token: 0x060010BF RID: 4287
[EventRule(EEventName.GeneralLogicTreeTimerInfoChanged)]
internal delegate void Delegate_GeneralLogicTreeTimerInfoChanged(long treeIncId, ETimerType timerType, TimerSetType setType, int seconds);
