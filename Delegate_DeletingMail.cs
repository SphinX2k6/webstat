using System;
using System.Collections.Generic;

// Token: 0x020001CD RID: 461
// (Invoke) Token: 0x060008E7 RID: 2279
[EventRule(EEventName.DeletingMail)]
internal delegate void Delegate_DeletingMail(IReadOnlyList<string> deletedMails);
