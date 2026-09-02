using System;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x02005732 RID: 22322
	public static class MingSuDefine
	{
		// Token: 0x040205CF RID: 132559
		public const int EXP_BAR_ANIMATION_TIME = 1200;

		// Token: 0x040205D0 RID: 132560
		public const int MING_SU_ITEM_CONFIG_ID = 40040001;

		// Token: 0x040205D1 RID: 132561
		public const int MING_SU_POOL_CONFIG_ID = 1;

		// Token: 0x040205D2 RID: 132562
		public const int CHENG_XIAO_SHAN_POOL_CONFIG_ID = 2;

		// Token: 0x040205D3 RID: 132563
		public const int DARK_COAST_POOL_CONFIG_ID = 3;

		// Token: 0x040205D4 RID: 132564
		public const int PUPU_VILLAGE_POOL_CONFIG_ID = 4;

		// Token: 0x040205D5 RID: 132565
		public const int PUPU_VILLAGE_QIQIU_POOL_CONFIG_ID = 5;

		// Token: 0x040205D6 RID: 132566
		public const int LAHAILUOSHENGXIA_POOL_CONFIG_ID = 6;

		// Token: 0x040205D7 RID: 132567
		public const int RILINGCOLLECT_POOL_CONFIG_ID = 7;

		// Token: 0x040205D8 RID: 132568
		public const int MENGZHOU_POOL_CONFIG_ID = 8;

		// Token: 0x040205D9 RID: 132569
		public const int PLOTPARAM_NUM = 3;

		// Token: 0x040205DA RID: 132570
		public const int DARK_COAST_HELP_ID = 113;

		// Token: 0x0200B7E3 RID: 47075
		public enum EMingSuShowState
		{
			// Token: 0x04038DF5 RID: 232949
			Done,
			// Token: 0x04038DF6 RID: 232950
			OnGoing,
			// Token: 0x04038DF7 RID: 232951
			NoStart,
			// Token: 0x04038DF8 RID: 232952
			Finish
		}

		// Token: 0x0200B7E4 RID: 47076
		public enum EDragonPoolStatus
		{
			// Token: 0x04038DFA RID: 232954
			UnActive,
			// Token: 0x04038DFB RID: 232955
			OnGoing,
			// Token: 0x04038DFC RID: 232956
			Finish
		}

		// Token: 0x0200B7E5 RID: 47077
		public enum EDarkCoastDeliveryLevelDataState
		{
			// Token: 0x04038DFE RID: 232958
			Lock,
			// Token: 0x04038DFF RID: 232959
			UnLock,
			// Token: 0x04038E00 RID: 232960
			Passed = 3,
			// Token: 0x04038E01 RID: 232961
			Received
		}
	}
}
