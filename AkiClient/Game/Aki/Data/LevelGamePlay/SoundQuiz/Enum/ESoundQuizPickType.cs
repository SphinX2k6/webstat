using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.LevelGamePlay.SoundQuiz.Enum
{
	// Token: 0x02003E85 RID: 16005
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/LevelGamePlay/SoundQuiz/Enum/ESoundQuizPickType.ESoundQuizPickType")]
	public enum ESoundQuizPickType : byte
	{
		// Token: 0x04014C96 RID: 85142
		指定音源,
		// Token: 0x04014C97 RID: 85143
		指定音源类型,
		// Token: 0x04014C98 RID: 85144
		无指定,
		// Token: 0x04014C99 RID: 85145
		ESoundQuizPickType_MAX
	}
}
