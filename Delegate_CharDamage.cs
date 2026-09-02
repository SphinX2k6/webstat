using System;
using UnrealEngine;

// Token: 0x02000110 RID: 272
// (Invoke) Token: 0x060005F3 RID: 1523
[EventRule(EEventName.CharDamage)]
internal delegate void Delegate_CharDamage(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition);
