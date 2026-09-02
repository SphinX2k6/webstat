using System;

// Token: 0x02000AAA RID: 2730
// (Invoke) Token: 0x06002C5B RID: 11355
[EventRule(EEventName.TsRequestAdjustTime)]
internal delegate void Delegate_TsRequestAdjustTime(int seconds, int reason, int addDay);
