using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042ED RID: 17133
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EBattleUIChild.EBattleUIChild")]
	public enum EBattleUIChild : byte
	{
		// Token: 0x040197F7 RID: 104439
		通用,
		// Token: 0x040197F8 RID: 104440
		退出按钮,
		// Token: 0x040197F9 RID: 104441
		菜单按钮,
		// Token: 0x040197FA RID: 104442
		顶部其他按钮,
		// Token: 0x040197FB RID: 104443
		小地图,
		// Token: 0x040197FC RID: 104444
		任务,
		// Token: 0x040197FD RID: 104445
		聊天按钮,
		// Token: 0x040197FE RID: 104446
		队伍头像,
		// Token: 0x040197FF RID: 104447
		队伍头像手柄,
		// Token: 0x04019800 RID: 104448
		技能按钮,
		// Token: 0x04019801 RID: 104449
		技能按钮手柄,
		// Token: 0x04019802 RID: 104450
		角色状态条,
		// Token: 0x04019803 RID: 104451
		摇杆,
		// Token: 0x04019804 RID: 104452
		boss状态条,
		// Token: 0x04019805 RID: 104453
		头顶状态条,
		// Token: 0x04019806 RID: 104454
		部位血条,
		// Token: 0x04019807 RID: 104455
		伤害数字,
		// Token: 0x04019808 RID: 104456
		战斗hud层,
		// Token: 0x04019809 RID: 104457
		战斗Float层,
		// Token: 0x0401980A RID: 104458
		交互,
		// Token: 0x0401980B RID: 104459
		QTE按键,
		// Token: 0x0401980C RID: 104460
		EBattleUIChild_MAX
	}
}
