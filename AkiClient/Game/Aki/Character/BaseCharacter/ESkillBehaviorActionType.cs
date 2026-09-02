using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200421A RID: 16922
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorActionType.ESkillBehaviorActionType")]
	public enum ESkillBehaviorActionType : byte
	{
		// Token: 0x040191A1 RID: 102817
		设置位置,
		// Token: 0x040191A2 RID: 102818
		设置朝向,
		// Token: 0x040191A3 RID: 102819
		播放特效,
		// Token: 0x040191A4 RID: 102820
		创建子弹,
		// Token: 0x040191A5 RID: 102821
		镜头效果,
		// Token: 0x040191A6 RID: 102822
		特写镜头,
		// Token: 0x040191A7 RID: 102823
		设置移动状态,
		// Token: 0x040191A8 RID: 102824
		设置碰撞,
		// Token: 0x040191A9 RID: 102825
		伴生物使用技能,
		// Token: 0x040191AA RID: 102826
		Buff增删,
		// Token: 0x040191AB RID: 102827
		Tag增删,
		// Token: 0x040191AC RID: 102828
		退出脆弱,
		// Token: 0x040191AD RID: 102829
		播放蒙太奇,
		// Token: 0x040191AE RID: 102830
		更新自定义数据,
		// Token: 0x040191AF RID: 102831
		批量生成子弹,
		// Token: 0x040191B0 RID: 102832
		ESkillBehaviorActionType_MAX
	}
}
