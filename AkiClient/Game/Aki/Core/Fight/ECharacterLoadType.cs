using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F62 RID: 16226
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/ECharacterLoadType.ECharacterLoadType")]
	public enum ECharacterLoadType : byte
	{
		// Token: 0x040155AA RID: 87466
		通用,
		// Token: 0x040155AB RID: 87467
		肉鸽,
		// Token: 0x040155AC RID: 87468
		Ai角色,
		// Token: 0x040155AD RID: 87469
		坎特蕾拉特殊玩法,
		// Token: 0x040155AE RID: 87470
		主线书页副本2_4,
		// Token: 0x040155AF RID: 87471
		塔防道具2_6,
		// Token: 0x040155B0 RID: 87472
		拍照活动2_7,
		// Token: 0x040155B1 RID: 87473
		幸存者2_7,
		// Token: 0x040155B2 RID: 87474
		仇远主线副本2_7,
		// Token: 0x040155B3 RID: 87475
		主线黑潮副本2_7,
		// Token: 0x040155B4 RID: 87476
		主线辛吉勒姆副本3_1,
		// Token: 0x040155B5 RID: 87477
		巴别塔3_5,
		// Token: 0x040155B6 RID: 87478
		神肉鸽3_6,
		// Token: 0x040155B7 RID: 87479
		黑梦3_4,
		// Token: 0x040155B8 RID: 87480
		主线重楼副本3_5,
		// Token: 0x040155B9 RID: 87481
		御剑流程3_6,
		// Token: 0x040155BA RID: 87482
		无冠者战斗3_6,
		// Token: 0x040155BB RID: 87483
		ECharacterLoadType_MAX
	}
}
