using System;
using System.Collections.Generic;

// Token: 0x0200046B RID: 1131
// (Invoke) Token: 0x0600135F RID: 4959
[EventRule(EEventName.GachaHistoryResponse)]
internal delegate void Delegate_GachaHistoryResponse(IReadOnlyList<GachaRecord> record);
