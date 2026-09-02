using System;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x020008BD RID: 2237
// (Invoke) Token: 0x060024A7 RID: 9383
[EventRule(EEventName.OnBeforeCharacterMorphTypeChanged)]
internal delegate void Delegate_OnBeforeCharacterMorphTypeChanged(Entity entity, EMorphType morphType, EMorphType oldMorphType);
