using System;

// Token: 0x020009E7 RID: 2535
// (Invoke) Token: 0x0600294F RID: 10575
[EventRule(EEventName.OnPhoneMsgReadProgressUpdate)]
internal delegate void Delegate_OnPhoneMsgReadProgressUpdate(int shortMessageId, int progress, bool isFinish);
