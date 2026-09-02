using System;
using System.Runtime.CompilerServices;

// Token: 0x02000A31 RID: 2609
// (Invoke) Token: 0x06002A77 RID: 10871
[EventRule(EEventName.OnTsBasePlayerControllerInputAxis)]
internal delegate void Delegate_OnTsBasePlayerControllerInputAxis([Nullable(2)] TsBasePlayerController playerController, string axisName, float value, bool alwaysTick);
