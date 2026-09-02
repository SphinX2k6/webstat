using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Gameplay.InformationLib
{
	// Token: 0x02003EB2 RID: 16050
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/InformationLib/EInfoLib.EInfoLib")]
	public enum EInfoLib : byte
	{
		// Token: 0x04014E9D RID: 85661
		文字,
		// Token: 0x04014E9E RID: 85662
		图片,
		// Token: 0x04014E9F RID: 85663
		声音,
		// Token: 0x04014EA0 RID: 85664
		视频,
		// Token: 0x04014EA1 RID: 85665
		EInfoLib_MAX
	}
}
