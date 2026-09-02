using System;

// Token: 0x0200042D RID: 1069
// (Invoke) Token: 0x06001267 RID: 4711
[EventRule(EEventName.InputControllerChange)]
internal delegate void Delegate_InputControllerChange(EInputControllerType last, EInputControllerType now);
