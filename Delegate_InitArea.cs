using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x020001AB RID: 427
// (Invoke) Token: 0x0600085F RID: 2143
[EventRule(EEventName.InitArea)]
internal delegate void Delegate_InitArea(IReadOnlyList<SceneAreaState> areas);
