using System;
using CSharpScript.Game.AI.StateMachine;

// Token: 0x020000F8 RID: 248
// (Invoke) Token: 0x06000593 RID: 1427
[EventRule(EEventName.ConditionDrivenSMTickLock)]
internal delegate void Delegate_ConditionDrivenSMTickLock(bool isLock, EConditionDrivenSmTickReason reason);
