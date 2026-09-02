using System;
using System.Collections.Generic;

// Token: 0x020008FE RID: 2302
// (Invoke) Token: 0x060025AB RID: 9643
[EventRule(EEventName.OwnHandCardRemove)]
internal delegate void Delegate_OwnHandCardRemove(IReadOnlyList<int> removeCardList);
