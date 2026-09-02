using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x0200087E RID: 2174
// (Invoke) Token: 0x060023AB RID: 9131
[EventRule(EEventName.OnFloroRanchNextDayTaskRefresh)]
internal delegate void Delegate_OnFloroRanchNextDayTaskRefresh(IReadOnlyList<FloroRanchPlayTask> taskList);
