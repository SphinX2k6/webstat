using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x020030AD RID: 12461
[NullableContext(2)]
[Nullable(0)]
public class SkillTargetImpl : ISkillTarget
{
	// Token: 0x17002290 RID: 8848
	// (get) Token: 0x06019AD6 RID: 105174 RVA: 0x007770FC File Offset: 0x007752FC
	// (set) Token: 0x06019AD7 RID: 105175 RVA: 0x00777104 File Offset: 0x00775304
	public int? LockOnConfigId { get; set; }

	// Token: 0x17002291 RID: 8849
	// (get) Token: 0x06019AD8 RID: 105176 RVA: 0x0077710D File Offset: 0x0077530D
	// (set) Token: 0x06019AD9 RID: 105177 RVA: 0x00777115 File Offset: 0x00775315
	public ESkillTargetPriority? SkillTargetPriority { get; set; }

	// Token: 0x17002292 RID: 8850
	// (get) Token: 0x06019ADA RID: 105178 RVA: 0x0077711E File Offset: 0x0077531E
	// (set) Token: 0x06019ADB RID: 105179 RVA: 0x00777126 File Offset: 0x00775326
	public bool? ShowTarget { get; set; }

	// Token: 0x17002293 RID: 8851
	// (get) Token: 0x06019ADC RID: 105180 RVA: 0x0077712F File Offset: 0x0077532F
	// (set) Token: 0x06019ADD RID: 105181 RVA: 0x00777137 File Offset: 0x00775337
	public bool? GlobalTarget { get; set; }

	// Token: 0x17002294 RID: 8852
	// (get) Token: 0x06019ADE RID: 105182 RVA: 0x00777140 File Offset: 0x00775340
	// (set) Token: 0x06019ADF RID: 105183 RVA: 0x00777148 File Offset: 0x00775348
	public string BlackboardKey { get; set; }

	// Token: 0x17002295 RID: 8853
	// (get) Token: 0x06019AE0 RID: 105184 RVA: 0x00777151 File Offset: 0x00775351
	// (set) Token: 0x06019AE1 RID: 105185 RVA: 0x00777159 File Offset: 0x00775359
	public double? SkillTargetRemainTime { get; set; }
}
