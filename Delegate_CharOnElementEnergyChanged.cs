using System;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x0200013E RID: 318
// (Invoke) Token: 0x060006AB RID: 1707
[EventRule(EEventName.CharOnElementEnergyChanged)]
internal delegate void Delegate_CharOnElementEnergyChanged(EElementType elementID, float newValue, float oldValue);
