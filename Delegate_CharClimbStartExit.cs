using System;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x0200011A RID: 282
// (Invoke) Token: 0x0600061B RID: 1563
[EventRule(EEventName.CharClimbStartExit)]
internal delegate void Delegate_CharClimbStartExit(int charId, EExitClimb exitClimbType);
