using System;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x02000774 RID: 1908
// (Invoke) Token: 0x06001F83 RID: 8067
[EventRule(EEventName.OnExecutionOptionChange)]
internal delegate void Delegate_OnExecutionOptionChange(bool isExecution, int entityId, ECustomOptionType? optionType);
