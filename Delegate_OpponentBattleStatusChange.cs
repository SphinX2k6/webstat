using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x02000900 RID: 2304
// (Invoke) Token: 0x060025B3 RID: 9651
[EventRule(EEventName.OpponentBattleStatusChange)]
internal delegate void Delegate_OpponentBattleStatusChange(IReadOnlyList<PhantomBattleRoleStatus> statusList);
