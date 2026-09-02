using System;
using Aki.Protocol;

// Token: 0x020004DC RID: 1244
// (Invoke) Token: 0x06001523 RID: 5411
[EventRule(EEventName.OnAddWeaponItem)]
internal delegate void Delegate_OnAddWeaponItem(WeaponItem weaponItem, bool bAddFromRole, bool bShowNewTips);
