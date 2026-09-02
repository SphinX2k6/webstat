using System;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x020008B3 RID: 2227
// (Invoke) Token: 0x0600247F RID: 9343
[EventRule(EEventName.EntityCampModify)]
internal delegate void Delegate_EntityCampModify(Entity entity, ECamp oldCamp, ECamp newCamp);
