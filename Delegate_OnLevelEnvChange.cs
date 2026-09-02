using System;
using UnrealEngine;

// Token: 0x0200076B RID: 1899
// (Invoke) Token: 0x06001F5F RID: 8031
[EventRule(EEventName.OnLevelEnvChange)]
internal delegate void Delegate_OnLevelEnvChange(ELevelEnvChangeType type, FVectorDouble? pos, float? range);
