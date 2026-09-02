using System;
using System.Collections.Generic;

// Token: 0x02000A9F RID: 2719
// (Invoke) Token: 0x06002C2F RID: 11311
[EventRule(EEventName.CsRequestDeleteMail)]
internal delegate void Delegate_CsRequestDeleteMail(IReadOnlyList<string> mailIdList);
