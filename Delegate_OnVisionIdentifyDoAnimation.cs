using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x02000300 RID: 768
// (Invoke) Token: 0x06000DB3 RID: 3507
[EventRule(EEventName.OnVisionIdentifyDoAnimation)]
internal delegate void Delegate_OnVisionIdentifyDoAnimation(int uniqueId, IReadOnlyList<Aki.Protocol.PhantomPropInfo> data);
