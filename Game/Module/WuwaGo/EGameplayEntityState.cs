using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004A98 RID: 19096
	[EnumExtensions]
	public enum EGameplayEntityState
	{
		// Token: 0x0401D2B5 RID: 119477
		[EnumStringMember("关卡.Common.状态.封锁")]
		Locked,
		// Token: 0x0401D2B6 RID: 119478
		[EnumStringMember("关卡.Common.状态.常态")]
		Normal,
		// Token: 0x0401D2B7 RID: 119479
		[EnumStringMember("关卡.Common.状态.激活")]
		Activated,
		// Token: 0x0401D2B8 RID: 119480
		[EnumStringMember("关卡.Common.状态.完成")]
		Completed
	}
}
