using System;
using Aki.TDConfigMgr.Action;

// Token: 0x02000298 RID: 664
// (Invoke) Token: 0x06000C13 RID: 3091
[EventRule(EEventName.UpdatePortraitVisible)]
internal delegate void Delegate_UpdatePortraitVisible(SetHeadIconVisible config, Action callback);
