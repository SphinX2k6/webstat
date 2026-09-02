using System;
using UnrealEngine;

// Token: 0x02000112 RID: 274
// (Invoke) Token: 0x060005FB RID: 1531
[EventRule(EEventName.CharBeKilled)]
internal delegate void Delegate_CharBeKilled(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition);
