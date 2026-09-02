using System;
using Aki.Protocol;

// Token: 0x020002DB RID: 731
// (Invoke) Token: 0x06000D1F RID: 3359
[EventRule(EEventName.OnVisionRefineSubResult)]
internal delegate void Delegate_OnVisionRefineSubResult(PhantomVicePolishAckResponse response, bool ack);
