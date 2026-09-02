using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020002D5 RID: 725
// (Invoke) Token: 0x06000D07 RID: 3335
[EventRule(EEventName.OnVisionRecoveryBatchResult)]
internal delegate void Delegate_OnVisionRecoveryBatchResult([Nullable(new byte[]
{
	0,
	1,
	1
})] OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse> response);
