using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Guarantee;

// Token: 0x02000602 RID: 1538
// (Invoke) Token: 0x060019BB RID: 6587
[EventRule(EEventName.AddGuaranteeAction)]
internal delegate void Delegate_AddGuaranteeAction(string instigatorName, [Nullable(2)] GeneralContext instigatorContext, GuaranteeActionInfo guaranteeAction, bool? bNeedGuaranteeInQuest);
