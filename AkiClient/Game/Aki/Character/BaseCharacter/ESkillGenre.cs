using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004226 RID: 16934
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillGenre.ESkillGenre")]
	public enum ESkillGenre : byte
	{
		// Token: 0x04019201 RID: 102913
		普攻0,
		// Token: 0x04019202 RID: 102914
		蓄力1,
		// Token: 0x04019203 RID: 102915
		E技能2,
		// Token: 0x04019204 RID: 102916
		大招3,
		// Token: 0x04019205 RID: 102917
		QTE4,
		// Token: 0x04019206 RID: 102918
		极限闪避反击5,
		// Token: 0x04019207 RID: 102919
		地面闪避6,
		// Token: 0x04019208 RID: 102920
		极限闪避7,
		// Token: 0x04019209 RID: 102921
		被动技能8,
		// Token: 0x0401920A RID: 102922
		战斗幻象技9,
		// Token: 0x0401920B RID: 102923
		探索幻象技10,
		// Token: 0x0401920C RID: 102924
		空中闪避11,
		// Token: 0x0401920D RID: 102925
		退场技12,
		// Token: 0x0401920E RID: 102926
		破弱技能13,
		// Token: 0x0401920F RID: 102927
		无类别,
		// Token: 0x04019210 RID: 102928
		ESkillGenre_MAX
	}
}
