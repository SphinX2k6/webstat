using System;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x020008BC RID: 2236
// (Invoke) Token: 0x060024A3 RID: 9379
[EventRule(EEventName.OnCharacterMorphTypeChanged)]
internal delegate void Delegate_OnCharacterMorphTypeChanged(Entity entity, EMorphType morphType, EMorphType oldMorphType);
