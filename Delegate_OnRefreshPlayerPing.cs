using System;
using Aki.Protocol;

// Token: 0x02000462 RID: 1122
// (Invoke) Token: 0x0600133B RID: 4923
[EventRule(EEventName.OnRefreshPlayerPing)]
internal delegate void Delegate_OnRefreshPlayerPing(int playerId, ENetPingState ping);
