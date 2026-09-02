using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x02000872 RID: 2162
// (Invoke) Token: 0x0600237B RID: 9083
[EventRule(EEventName.OnRacingBetsDangoOrderRefresh)]
internal delegate void Delegate_OnRacingBetsDangoOrderRefresh(int round, IReadOnlyList<DangoIdToDiceNum> dangoDiceList, CustomPromise promise);
