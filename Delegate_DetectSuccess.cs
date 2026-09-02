using System;
using Aki.Protocol;

// Token: 0x020004EE RID: 1262
// (Invoke) Token: 0x0600156B RID: 5483
[EventRule(EEventName.DetectSuccess)]
internal delegate void Delegate_DetectSuccess(int id, DetectionType type);
