using System;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x020005A2 RID: 1442
// (Invoke) Token: 0x0600183B RID: 6203
[EventRule(EEventName.BattleUiBossStateAreaChanged)]
internal delegate void Delegate_BattleUiBossStateAreaChanged(EBossStateAreaType lastType, EBossStateAreaType curType);
