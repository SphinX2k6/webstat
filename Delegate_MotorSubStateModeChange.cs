using System;
using UnrealEngine;

// Token: 0x02000B18 RID: 2840
// (Invoke) Token: 0x06002E13 RID: 11795
[EventRule(EEventName.MotorSubStateModeChange)]
internal delegate void Delegate_MotorSubStateModeChange(EMotorSubState oldState, EMotorSubState newState);
