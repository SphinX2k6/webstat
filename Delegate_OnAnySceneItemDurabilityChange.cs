using System;

// Token: 0x02000335 RID: 821
// (Invoke) Token: 0x06000E87 RID: 3719
[EventRule(EEventName.OnAnySceneItemDurabilityChange)]
internal delegate void Delegate_OnAnySceneItemDurabilityChange(EntityHandle entity, int newDurability, int currentDurability);
