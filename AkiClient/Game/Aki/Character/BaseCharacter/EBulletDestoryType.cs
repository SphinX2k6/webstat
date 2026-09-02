using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E2 RID: 16866
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBulletDestoryType.EBulletDestoryType")]
	public enum EBulletDestoryType : byte
	{
		// Token: 0x0401900D RID: 102413
		子弹时间销毁特效,
		// Token: 0x0401900E RID: 102414
		子弹碰撞障碍销毁特效,
		// Token: 0x0401900F RID: 102415
		子弹碰撞单位销毁特效,
		// Token: 0x04019010 RID: 102416
		子弹打断销毁特效,
		// Token: 0x04019011 RID: 102417
		EBulletDestoryType_MAX
	}
}
