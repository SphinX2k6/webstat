using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x020030AC RID: 12460
[NullableContext(2)]
public interface ISkillTarget
{
	// Token: 0x1700228A RID: 8842
	// (get) Token: 0x06019ACA RID: 105162
	// (set) Token: 0x06019ACB RID: 105163
	int? LockOnConfigId { get; set; }

	// Token: 0x1700228B RID: 8843
	// (get) Token: 0x06019ACC RID: 105164
	// (set) Token: 0x06019ACD RID: 105165
	ESkillTargetPriority? SkillTargetPriority { get; set; }

	// Token: 0x1700228C RID: 8844
	// (get) Token: 0x06019ACE RID: 105166
	// (set) Token: 0x06019ACF RID: 105167
	bool? ShowTarget { get; set; }

	// Token: 0x1700228D RID: 8845
	// (get) Token: 0x06019AD0 RID: 105168
	// (set) Token: 0x06019AD1 RID: 105169
	bool? GlobalTarget { get; set; }

	// Token: 0x1700228E RID: 8846
	// (get) Token: 0x06019AD2 RID: 105170
	// (set) Token: 0x06019AD3 RID: 105171
	string BlackboardKey { get; set; }

	// Token: 0x1700228F RID: 8847
	// (get) Token: 0x06019AD4 RID: 105172
	// (set) Token: 0x06019AD5 RID: 105173
	double? SkillTargetRemainTime { get; set; }
}
