using System;
using System.Collections.Generic;

// Token: 0x02000B06 RID: 2822
// (Invoke) Token: 0x06002DCB RID: 11723
[EventRule(EEventName.TsSyncAchievementFinish)]
internal delegate void Delegate_TsSyncAchievementFinish(IReadOnlyList<int> categoryIdList, IReadOnlyList<int> groupIdList, IReadOnlyList<int> achievementIdList, int startCount, int finishCount);
