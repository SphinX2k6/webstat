using System;
using UnrealEngine;

// Token: 0x02000A5C RID: 2652
// (Invoke) Token: 0x06002B23 RID: 11043
[EventRule(EEventName.NotifyCsOnNetReceiveException)]
internal delegate void Delegate_NotifyCsOnNetReceiveException(int seqNo, int rpcId, int errorCode, FArrayBuffer stringBuffer);
