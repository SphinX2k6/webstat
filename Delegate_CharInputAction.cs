using System;
using UnrealEngine;

// Token: 0x02000156 RID: 342
// (Invoke) Token: 0x0600070B RID: 1803
[EventRule(EEventName.CharInputAction)]
internal delegate void Delegate_CharInputAction(string actionName, bool isPress, FKey key);
