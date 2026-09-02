using System;

// Token: 0x0200015B RID: 347
// (Invoke) Token: 0x0600071F RID: 1823
[EventRule(EEventName.OnTeamLivingStateChange)]
internal delegate void Delegate_OnTeamLivingStateChange(bool isMyTeam, ETeamGroupType groupType, ETeamLivingState newState, ETeamLivingState oldState);
