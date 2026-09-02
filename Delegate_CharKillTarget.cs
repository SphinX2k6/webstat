using System;
using UnrealEngine;

// Token: 0x02000111 RID: 273
// (Invoke) Token: 0x060005F7 RID: 1527
[EventRule(EEventName.CharKillTarget)]
internal delegate void Delegate_CharKillTarget(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition);
