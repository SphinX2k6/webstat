using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E59 RID: 24153
	[NullableContext(2)]
	[Nullable(0)]
	public class PropMediumItemGrid : MediumItemGridBase
	{
		// Token: 0x1700994A RID: 39242
		// (get) Token: 0x0603CCA7 RID: 248999 RVA: 0x00F6FDD4 File Offset: 0x00F6DFD4
		public override EMediumItemGridType Type
		{
			get
			{
				return EMediumItemGridType.Prop;
			}
		}

		// Token: 0x040221D7 RID: 139735
		public bool? IsIconHide;

		// Token: 0x040221D8 RID: 139736
		public bool? IsRedDotVisible;

		// Token: 0x040221D9 RID: 139737
		public bool? IsNewVisible;

		// Token: 0x040221DA RID: 139738
		public bool? IsNewOverRedDot;

		// Token: 0x040221DB RID: 139739
		public EMediumItemGridBuffType? BuffIconType;

		// Token: 0x040221DC RID: 139740
		public bool? IsLockVisible;

		// Token: 0x040221DD RID: 139741
		public bool? IsDeprecate;

		// Token: 0x040221DE RID: 139742
		public int? Level;

		// Token: 0x040221DF RID: 139743
		public bool? IsLevelInfinite;

		// Token: 0x040221E0 RID: 139744
		public bool? IsLevelTextUseChangeColor;

		// Token: 0x040221E1 RID: 139745
		public int? StarLevel;

		// Token: 0x040221E2 RID: 139746
		public float? CoolDown;

		// Token: 0x040221E3 RID: 139747
		public float? TotalCoolDown;

		// Token: 0x040221E4 RID: 139748
		public bool? IsProhibit;

		// Token: 0x040221E5 RID: 139749
		public LongPressButton ReduceButtonInfo;

		// Token: 0x040221E6 RID: 139750
		public bool? IsGreenSelected;

		// Token: 0x040221E7 RID: 139751
		public bool? IsWarning;

		// Token: 0x040221E8 RID: 139752
		public bool? IsCheckTick;

		// Token: 0x040221E9 RID: 139753
		public bool? IsTimeFlagVisible;

		// Token: 0x040221EA RID: 139754
		public bool? IsReceivedFlagVisible;

		// Token: 0x040221EB RID: 139755
		public RoleHeadInfo RoleHeadInfo;

		// Token: 0x040221EC RID: 139756
		public int? SortIndex;

		// Token: 0x040221ED RID: 139757
		public bool? IsDisable;

		// Token: 0x040221EE RID: 139758
		public bool? IsMainVisionVisible;

		// Token: 0x040221EF RID: 139759
		public int[] VisionSlotStateList;

		// Token: 0x040221F0 RID: 139760
		public int? VisionFetterGroupId;

		// Token: 0x040221F1 RID: 139761
		public VisionRoleHeadInfo VisionRoleHeadInfo;

		// Token: 0x040221F2 RID: 139762
		public MediumItemGridComposeTag ComposeIconTag;

		// Token: 0x040221F3 RID: 139763
		public bool? ChangeAble;

		// Token: 0x040221F4 RID: 139764
		public DangoRoleHeadInfo DangoRoleHeadInfo;

		// Token: 0x040221F5 RID: 139765
		public bool? IsRogueFinish;

		// Token: 0x040221F6 RID: 139766
		public IMediumItemPrice ItemPrice;

		// Token: 0x040221F7 RID: 139767
		public bool? IsUpGrade;

		// Token: 0x040221F8 RID: 139768
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] TagPathList;

		// Token: 0x040221F9 RID: 139769
		public string RightTopValue;

		// Token: 0x040221FA RID: 139770
		public bool? IsBranchUpgrade;

		// Token: 0x040221FB RID: 139771
		public string SubIconPath;

		// Token: 0x040221FC RID: 139772
		public bool? IsRecommendVisible;

		// Token: 0x040221FD RID: 139773
		public int? RoundCount;

		// Token: 0x040221FE RID: 139774
		public MediumWarningPanelInfo WarningPanelInfo;
	}
}
