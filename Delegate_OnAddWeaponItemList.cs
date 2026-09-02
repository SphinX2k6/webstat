using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x020004DD RID: 1245
// (Invoke) Token: 0x06001527 RID: 5415
[EventRule(EEventName.OnAddWeaponItemList)]
internal delegate void Delegate_OnAddWeaponItemList(IReadOnlyList<WeaponItem> weaponItem, bool bAddFromRole, bool bShowNewTips);
