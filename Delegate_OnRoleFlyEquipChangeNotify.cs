using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x0200083D RID: 2109
// (Invoke) Token: 0x060022A7 RID: 8871
[EventRule(EEventName.OnRoleFlyEquipChangeNotify)]
internal delegate void Delegate_OnRoleFlyEquipChangeNotify(IReadOnlyList<RoleFlySkinChange> skinChanges);
