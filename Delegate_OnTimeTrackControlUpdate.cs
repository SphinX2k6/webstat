using System;
using Aki.Protocol;

// Token: 0x0200034C RID: 844
// (Invoke) Token: 0x06000EE3 RID: 3811
[EventRule(EEventName.OnTimeTrackControlUpdate)]
internal delegate void Delegate_OnTimeTrackControlUpdate(int curControlPoint, ErrorCode UpdateCode);
