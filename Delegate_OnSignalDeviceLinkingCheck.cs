using System;
using System.Collections.Generic;

// Token: 0x0200071F RID: 1823
// (Invoke) Token: 0x06001E2F RID: 7727
[EventRule(EEventName.OnSignalDeviceLinkingCheck)]
internal delegate void Delegate_OnSignalDeviceLinkingCheck(bool result, IReadOnlyList<int> indexArray);
