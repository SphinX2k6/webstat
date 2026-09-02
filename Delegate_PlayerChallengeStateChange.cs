using System;

// Token: 0x020004A4 RID: 1188
// (Invoke) Token: 0x06001443 RID: 5187
[EventRule(EEventName.PlayerChallengeStateChange)]
internal delegate void Delegate_PlayerChallengeStateChange(int playerId, EContinuingChallenge state);
