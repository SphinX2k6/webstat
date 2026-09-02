using System;

// Token: 0x02000722 RID: 1826
// (Invoke) Token: 0x06001E3B RID: 7739
[EventRule(EEventName.OnSignalDeviceLinking)]
internal delegate void Delegate_OnSignalDeviceLinking(bool isAdd, int from, bool isFromDot, int to, bool isToDot);
