using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020002D4 RID: 724
// (Invoke) Token: 0x06000D03 RID: 3331
[EventRule(EEventName.OnVisionRecoveryResult)]
internal delegate void Delegate_OnVisionRecoveryResult([Nullable(new byte[]
{
	0,
	1,
	1
})] OneOf<PhantomBatchDirectRefiningResponse, PhantomRefiningResponse> response);
