using System;

// Token: 0x0200087A RID: 2170
// (Invoke) Token: 0x0600239B RID: 9115
[EventRule(EEventName.OnRacingBetsMatchStateChange)]
internal delegate void Delegate_OnRacingBetsMatchStateChange(int legMatchId, ERacingBetsLegMatchState matchState);
