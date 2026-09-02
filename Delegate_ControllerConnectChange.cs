using System;

// Token: 0x02000431 RID: 1073
// (Invoke) Token: 0x06001277 RID: 4727
[EventRule(EEventName.ControllerConnectChange)]
internal delegate void Delegate_ControllerConnectChange(bool bIsConnected, int platformUserId, int controllerId);
