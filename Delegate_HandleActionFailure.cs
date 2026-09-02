using System;

// Token: 0x02000601 RID: 1537
// (Invoke) Token: 0x060019B7 RID: 6583
[EventRule(EEventName.HandleActionFailure)]
internal delegate void Delegate_HandleActionFailure(int groupId, string type, bool isError, bool showLog);
