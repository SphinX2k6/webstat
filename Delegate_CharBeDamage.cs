using System;
using UnrealEngine;

// Token: 0x02000113 RID: 275
// (Invoke) Token: 0x060005FF RID: 1535
[EventRule(EEventName.CharBeDamage)]
internal delegate void Delegate_CharBeDamage(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition);
