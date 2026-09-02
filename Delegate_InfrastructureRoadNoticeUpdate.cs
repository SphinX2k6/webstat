using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Infrastructure;

// Token: 0x020009A7 RID: 2471
// (Invoke) Token: 0x0600284F RID: 10319
[EventRule(EEventName.InfrastructureRoadNoticeUpdate)]
internal delegate void Delegate_InfrastructureRoadNoticeUpdate(IReadOnlyList<InfrastructureDefine.InfrNoticeData> noticeList);
