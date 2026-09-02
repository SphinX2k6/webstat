using System;
using System.Collections.Generic;

// Token: 0x02000446 RID: 1094
// (Invoke) Token: 0x060012CB RID: 4811
[EventRule(EEventName.ParkourFinished)]
internal delegate void Delegate_ParkourFinished(string ParkourConfig, IReadOnlyDictionary<int, int> totalScore);
