using System;
using Aki.Protocol;

// Token: 0x02002E49 RID: 11849
// (Invoke) Token: 0x0601847B RID: 99451
[AbilityEventRule(EAbilityEventName.OnAttributeChange)]
internal delegate void Delegate_Ability_OnAttributeChange(EAttributeType attrType, Entity entity, float newValue, float oldValue);
