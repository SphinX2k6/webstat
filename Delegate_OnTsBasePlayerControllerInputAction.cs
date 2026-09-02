using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000A30 RID: 2608
// (Invoke) Token: 0x06002A73 RID: 10867
[EventRule(EEventName.OnTsBasePlayerControllerInputAction)]
internal delegate void Delegate_OnTsBasePlayerControllerInputAction([Nullable(2)] TsBasePlayerController playerController, string actionName, bool bPress, FKey key);
