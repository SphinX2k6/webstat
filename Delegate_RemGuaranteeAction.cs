using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Guarantee;

// Token: 0x02000603 RID: 1539
// (Invoke) Token: 0x060019BF RID: 6591
[EventRule(EEventName.RemGuaranteeAction)]
internal delegate void Delegate_RemGuaranteeAction(string instigatorName, [Nullable(2)] GeneralContext instigatorContext, GuaranteeActionInfo guaranteeAction, bool? bNeedGuaranteeInQuest);
