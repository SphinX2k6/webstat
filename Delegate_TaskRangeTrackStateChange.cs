using System;

// Token: 0x0200027A RID: 634
// (Invoke) Token: 0x06000B9B RID: 2971
[EventRule(EEventName.TaskRangeTrackStateChange)]
internal delegate void Delegate_TaskRangeTrackStateChange(ETrackSource trackSource, long treeIncId, int behaviorId, int markId, bool rangeImageActive);
