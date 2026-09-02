using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E6 RID: 16870
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBulletShape.EBulletShape")]
	public enum EBulletShape : byte
	{
		// Token: 0x04019025 RID: 102437
		单位长方体,
		// Token: 0x04019026 RID: 102438
		单位球体,
		// Token: 0x04019027 RID: 102439
		扇形柱,
		// Token: 0x04019028 RID: 102440
		圆柱,
		// Token: 0x04019029 RID: 102441
		激光,
		// Token: 0x0401902A RID: 102442
		自定义模型,
		// Token: 0x0401902B RID: 102443
		大长方体,
		// Token: 0x0401902C RID: 102444
		大球体,
		// Token: 0x0401902D RID: 102445
		大扇形柱,
		// Token: 0x0401902E RID: 102446
		大圆柱,
		// Token: 0x0401902F RID: 102447
		EBulletShape_MAX
	}
}
