using System;
using System.Runtime.CompilerServices;

// Token: 0x020031C3 RID: 12739
public static class StareActionTypeHelper
{
	// Token: 0x0601A69B RID: 108187 RVA: 0x007CA514 File Offset: 0x007C8714
	[NullableContext(1)]
	public static string GetActionTypeName(EStareActionType type)
	{
		switch (type)
		{
		case EStareActionType.LookAtPlayer:
			return "生态注视玩家";
		case EStareActionType.InterestEvent:
			return "兴趣点注视";
		case EStareActionType.LevelEventEntityLookAt:
			return "关卡行为-启用实体注视";
		case EStareActionType.TurnToPlayer:
			return "转身面向玩家";
		case EStareActionType.SystemUI:
			return "系统商店";
		case EStareActionType.Plot:
			return "剧情";
		case EStareActionType.Photograph:
			return "拍照系统";
		default:
			return type.ToString();
		}
	}
}
