using System;
using System.Collections.Generic;

// Token: 0x02000ADB RID: 2779
// (Invoke) Token: 0x06002D1F RID: 11551
[EventRule(EEventName.CsRequestSdkTargetRelationData)]
internal delegate void Delegate_CsRequestSdkTargetRelationData(int reqId, IReadOnlyList<string> accountList);
