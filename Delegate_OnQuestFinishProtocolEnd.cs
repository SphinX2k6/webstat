using System;
using System.Collections.Generic;

// Token: 0x020003B3 RID: 947
// (Invoke) Token: 0x0600107F RID: 4223
[EventRule(EEventName.OnQuestFinishProtocolEnd)]
internal delegate void Delegate_OnQuestFinishProtocolEnd(IReadOnlyList<int> questIds);
