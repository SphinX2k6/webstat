using System;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02000155 RID: 341
// (Invoke) Token: 0x06000707 RID: 1799
[EventRule(EEventName.CharRecordOperate)]
internal delegate void Delegate_CharRecordOperate(EntityHandle target, int skillId, ESkillGenre skillGenre);
