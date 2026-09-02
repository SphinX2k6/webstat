using System;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x02000A62 RID: 2658
// (Invoke) Token: 0x06002B3B RID: 11067
[EventRule(EEventName.CsNetCall)]
internal delegate void Delegate_CsNetCall(ERequestMessageId requestMessageId, FArrayBuffer messageBuffer, int rpcId, int timeoutMs);
