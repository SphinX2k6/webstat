using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004222 RID: 16930
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorRotationType.ESkillBehaviorRotationType")]
	public enum ESkillBehaviorRotationType : byte
	{
		// Token: 0x040191E8 RID: 102888
		技能目标,
		// Token: 0x040191E9 RID: 102889
		小队当前角色,
		// Token: 0x040191EA RID: 102890
		召唤者_伴生物专用_,
		// Token: 0x040191EB RID: 102891
		当前小队摄像机_玩家专用_,
		// Token: 0x040191EC RID: 102892
		技能目标玩家摄像机_怪物专用_,
		// Token: 0x040191ED RID: 102893
		技能施法者朝向,
		// Token: 0x040191EE RID: 102894
		输入朝向_玩家专用_,
		// Token: 0x040191EF RID: 102895
		ESkillBehaviorRotationType_MAX
	}
}
