using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E37 RID: 15927
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/ECommonQteInputAction.ECommonQteInputAction")]
	public enum ECommonQteInputAction : byte
	{
		// Token: 0x04014882 RID: 84098
		无,
		// Token: 0x04014883 RID: 84099
		跳跃,
		// Token: 0x04014884 RID: 84100
		攀爬,
		// Token: 0x04014885 RID: 84101
		走跑切换,
		// Token: 0x04014886 RID: 84102
		攻击,
		// Token: 0x04014887 RID: 84103
		闪避,
		// Token: 0x04014888 RID: 84104
		技能1,
		// Token: 0x04014889 RID: 84105
		幻象1,
		// Token: 0x0401488A RID: 84106
		大招,
		// Token: 0x0401488B RID: 84107
		幻象2,
		// Token: 0x0401488C RID: 84108
		切换角色1,
		// Token: 0x0401488D RID: 84109
		切换角色2,
		// Token: 0x0401488E RID: 84110
		切换角色3,
		// Token: 0x0401488F RID: 84111
		锁定目标,
		// Token: 0x04014890 RID: 84112
		瞄准,
		// Token: 0x04014891 RID: 84113
		通用交互,
		// Token: 0x04014892 RID: 84114
		向前移动,
		// Token: 0x04014893 RID: 84115
		向后移动,
		// Token: 0x04014894 RID: 84116
		向左移动,
		// Token: 0x04014895 RID: 84117
		向右移动,
		// Token: 0x04014896 RID: 84118
		QTE选项1,
		// Token: 0x04014897 RID: 84119
		QTE选项2,
		// Token: 0x04014898 RID: 84120
		QTE选项3,
		// Token: 0x04014899 RID: 84121
		QTE选项4,
		// Token: 0x0401489A RID: 84122
		QTE方向上,
		// Token: 0x0401489B RID: 84123
		QTE方向下,
		// Token: 0x0401489C RID: 84124
		QTE方向左,
		// Token: 0x0401489D RID: 84125
		QTE方向右,
		// Token: 0x0401489E RID: 84126
		QTE分体选项1_左,
		// Token: 0x0401489F RID: 84127
		QTE分体选项2_右,
		// Token: 0x040148A0 RID: 84128
		QTE_R2攻击,
		// Token: 0x040148A1 RID: 84129
		交互动态漫_向上拖动,
		// Token: 0x040148A2 RID: 84130
		交互动态漫_转动,
		// Token: 0x040148A3 RID: 84131
		交互动态漫_点击,
		// Token: 0x040148A4 RID: 84132
		交互动态漫_长按,
		// Token: 0x040148A5 RID: 84133
		QTE_空格A,
		// Token: 0x040148A6 RID: 84134
		交互动态漫_向下拖动,
		// Token: 0x040148A7 RID: 84135
		载具漂移,
		// Token: 0x040148A8 RID: 84136
		载具子弹跳,
		// Token: 0x040148A9 RID: 84137
		载具退场技和下车,
		// Token: 0x040148AA RID: 84138
		载具探索工具,
		// Token: 0x040148AB RID: 84139
		载具氮气,
		// Token: 0x040148AC RID: 84140
		ECommonQteInputAction_MAX
	}
}
