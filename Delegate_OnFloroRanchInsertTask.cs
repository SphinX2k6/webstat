using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x0200087F RID: 2175
// (Invoke) Token: 0x060023AF RID: 9135
[EventRule(EEventName.OnFloroRanchInsertTask)]
internal delegate void Delegate_OnFloroRanchInsertTask(IReadOnlyList<FloroRanchPlayTask> taskList);
