using System;
using UnrealEngine;

// Token: 0x02000A5B RID: 2651
// (Invoke) Token: 0x06002B1F RID: 11039
[EventRule(EEventName.NotifyCsOnNetReceiveResponse)]
internal delegate void Delegate_NotifyCsOnNetReceiveResponse(int msgType, int seqNo, int rpcId, int messageId, FArrayBuffer messageBuffer);
