using System;
using System.Collections.Generic;

// Token: 0x020008FD RID: 2301
// (Invoke) Token: 0x060025A7 RID: 9639
[EventRule(EEventName.OwnHandCardAdd)]
internal delegate void Delegate_OwnHandCardAdd(IReadOnlyList<int> addCardList);
