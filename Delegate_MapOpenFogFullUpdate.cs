using System;
using System.Collections.Generic;

// Token: 0x02000242 RID: 578
// (Invoke) Token: 0x06000ABB RID: 2747
[EventRule(EEventName.MapOpenFogFullUpdate)]
internal delegate void Delegate_MapOpenFogFullUpdate(IReadOnlyDictionary<int, bool> openAreaIds);
