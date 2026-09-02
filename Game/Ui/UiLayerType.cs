using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049E3 RID: 18915
	public class UiLayerType
	{
		// Token: 0x0401CC64 RID: 117860
		public const int TIP_LAYER_UNIT_COUNT = 3;

		// Token: 0x0401CC65 RID: 117861
		public const int LOADING_LAYER_UNIT_COUNT = 2;

		// Token: 0x0401CC66 RID: 117862
		public const int BATTLE_VIEW_UNIT_COUNT = 3;

		// Token: 0x0401CC67 RID: 117863
		public const int NORMAL_CONTAINER_TYPE = 2050;

		// Token: 0x0401CC68 RID: 117864
		public const int PLOT_CONTAINER_TYPE = 4;

		// Token: 0x0401CC69 RID: 117865
		public const int NORMAL_PLOT_CONTAINER_TYPE = 2054;

		// Token: 0x0401CC6A RID: 117866
		public const int IGNORE_MASK_TYPE = 384;

		// Token: 0x0401CC6B RID: 117867
		public const int UIBLUR_TYPE = 70;

		// Token: 0x0401CC6C RID: 117868
		public const int BLOCKCLICK_TYPE = 70;

		// Token: 0x0401CC6D RID: 117869
		public const int MULTIPLE_VIEW_TYPE = 128;

		// Token: 0x0401CC6E RID: 117870
		public const int MOBILE_SWITCH_ALLOW_VIEW_TYPE = 3072;

		// Token: 0x0401CC6F RID: 117871
		public const int LOADING_VIEW_NODE_TYPE = 0;

		// Token: 0x0401CC70 RID: 117872
		public const int SE_COVER_LOADING_VIEW_NODE_TYPE = 1;

		// Token: 0x0401CC71 RID: 117873
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly ELayerType[] LayerTypeEnumValues = Enum.GetValues<ELayerType>();
	}
}
