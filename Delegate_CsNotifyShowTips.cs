using System;
using System.Collections.Generic;

// Token: 0x02000A54 RID: 2644
// (Invoke) Token: 0x06002B03 RID: 11011
[EventRule(EEventName.CsNotifyShowTips)]
internal delegate void Delegate_CsNotifyShowTips(int typeId, string textKey, IReadOnlyList<string> mainTextParams);
