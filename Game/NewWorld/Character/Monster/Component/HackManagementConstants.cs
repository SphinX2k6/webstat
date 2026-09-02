using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Monster.Component
{
	// Token: 0x020048DD RID: 18653
	public static class HackManagementConstants
	{
		// Token: 0x0401BF8C RID: 114572
		public static readonly int NUM_TAG_ID = GameplayTagDefine.EGameplayTagId["辅助机.骇入型.骇入可用次数"];

		// Token: 0x0401BF8D RID: 114573
		public static readonly int NUM_IS_EMPTY_TAG_ID = GameplayTagDefine.EGameplayTagId["辅助机.骇入型.骇入已满"];

		// Token: 0x0401BF8E RID: 114574
		public static readonly int HACKING_TAG_ID = GameplayTagDefine.EGameplayTagId["辅助机.骇入型.骇入中"];

		// Token: 0x0401BF8F RID: 114575
		[Nullable(1)]
		public const string TIP_TEXT_ID = "ClientErrorCode_0_Text";

		// Token: 0x0401BF90 RID: 114576
		public const int SHOW_TIP_INTERVAL = 1000;
	}
}
