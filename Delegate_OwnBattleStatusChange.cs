using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x020008FB RID: 2299
// (Invoke) Token: 0x0600259F RID: 9631
[EventRule(EEventName.OwnBattleStatusChange)]
internal delegate void Delegate_OwnBattleStatusChange(IReadOnlyList<PhantomBattleRoleStatus> statusList);
