using System;
using CSharpScript.Game.Input;

// Token: 0x0200058B RID: 1419
// (Invoke) Token: 0x060017DF RID: 6111
[EventRule(EEventName.BattleInputEnableChanged)]
internal delegate void Delegate_BattleInputEnableChanged(EInputAction inputAction, bool enable);
