using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x02000841 RID: 2113
// (Invoke) Token: 0x060022B7 RID: 8887
[EventRule(EEventName.OnFlySkinEquipToAllRoleResponse)]
internal delegate void Delegate_OnFlySkinEquipToAllRoleResponse(IReadOnlyList<RoleFlySkinChange> skinChanges);
