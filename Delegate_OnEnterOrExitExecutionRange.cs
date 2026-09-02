using System;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x02000773 RID: 1907
// (Invoke) Token: 0x06001F7F RID: 8063
[EventRule(EEventName.OnEnterOrExitExecutionRange)]
internal delegate void Delegate_OnEnterOrExitExecutionRange(bool isEnter, int entityId, ECustomOptionType? optionType);
