using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004229 RID: 16937
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillOverrideType.ESkillOverrideType")]
	public enum ESkillOverrideType : byte
	{
		// Token: 0x0401921C RID: 102940
		默认,
		// Token: 0x0401921D RID: 102941
		覆盖受击,
		// Token: 0x0401921E RID: 102942
		覆盖弹反,
		// Token: 0x0401921F RID: 102943
		覆盖破弱,
		// Token: 0x04019220 RID: 102944
		顶级,
		// Token: 0x04019221 RID: 102945
		ESkillOverrideType_MAX
	}
}
