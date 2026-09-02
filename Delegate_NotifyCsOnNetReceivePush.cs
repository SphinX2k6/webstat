using System;
using UnrealEngine;

// Token: 0x02000A5E RID: 2654
// (Invoke) Token: 0x06002B2B RID: 11051
[EventRule(EEventName.NotifyCsOnNetReceivePush)]
internal delegate void Delegate_NotifyCsOnNetReceivePush(int seqNo, int messageId, FArrayBuffer messageBuffer);
