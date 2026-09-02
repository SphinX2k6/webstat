using System;
using System.Collections.Generic;

// Token: 0x02000427 RID: 1063
// (Invoke) Token: 0x0600124F RID: 4687
[EventRule(EEventName.ApplicationHandled)]
internal delegate void Delegate_ApplicationHandled(EFriendItemOperation operationType, IReadOnlyList<int> ids);
