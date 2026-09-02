using System;
using System.Collections.Generic;

// Token: 0x02000AC0 RID: 2752
// (Invoke) Token: 0x06002CB3 RID: 11443
[EventRule(EEventName.CsRequestFriendHandle)]
internal delegate void Delegate_CsRequestFriendHandle(int @operator, IReadOnlyDictionary<int, int> HandleMap);
