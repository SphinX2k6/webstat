using System;
using System.Collections.Generic;

// Token: 0x02000A9E RID: 2718
// (Invoke) Token: 0x06002C2B RID: 11307
[EventRule(EEventName.CsRequestPickMailAttachment)]
internal delegate void Delegate_CsRequestPickMailAttachment(IReadOnlyList<string> attachmentList, int pickType);
