using System;
using System.Runtime.CompilerServices;

// Token: 0x02000118 RID: 280
// (Invoke) Token: 0x06000613 RID: 1555
[EventRule(EEventName.OnBuffTriggerEvent)]
internal delegate void Delegate_OnBuffTriggerEvent(EBuffTriggerType passiveEffectType, [Nullable(2)] BaseBuffComponent opponentBuffComp, Partial_RequirementPayload payload);
