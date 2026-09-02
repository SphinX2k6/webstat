using System;
using UnrealEngine;

// Token: 0x02000114 RID: 276
// (Invoke) Token: 0x06000603 RID: 1539
[EventRule(EEventName.GlobalCharDamage)]
internal delegate void Delegate_GlobalCharDamage(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition);
