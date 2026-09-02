using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E5B RID: 24155
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomMediumItemGrid : MediumItemGridBase
	{
		// Token: 0x1700994B RID: 39243
		// (get) Token: 0x0603CCA9 RID: 249001 RVA: 0x00F6FDDF File Offset: 0x00F6DFDF
		public override EMediumItemGridType Type
		{
			get
			{
				return EMediumItemGridType.Phantom;
			}
		}

		// Token: 0x04022203 RID: 139779
		public bool? IsRedDotVisible;

		// Token: 0x04022204 RID: 139780
		public string QualityIconResourceId;

		// Token: 0x04022205 RID: 139781
		public int? Level;

		// Token: 0x04022206 RID: 139782
		public bool? IsLevelTextUseChangeColor;

		// Token: 0x04022207 RID: 139783
		public int? MonsterId;

		// Token: 0x04022208 RID: 139784
		public int? StarLevel;

		// Token: 0x04022209 RID: 139785
		public bool? IsMainVisionVisible;

		// Token: 0x0402220A RID: 139786
		public RoleHeadInfo RoleHeadInfo;

		// Token: 0x0402220B RID: 139787
		public int[] VisionSlotStateList;

		// Token: 0x0402220C RID: 139788
		public bool? IsNewVisible;

		// Token: 0x0402220D RID: 139789
		public bool? IsLockVisible;

		// Token: 0x0402220E RID: 139790
		public bool? IsDeprecate;

		// Token: 0x0402220F RID: 139791
		public bool? IsPhantomLock;

		// Token: 0x04022210 RID: 139792
		public DevelopRewardInfo DevelopRewardInfo;

		// Token: 0x04022211 RID: 139793
		public int? FetterGroupId;

		// Token: 0x04022212 RID: 139794
		public VisionRoleHeadInfo VisionRoleHeadInfo;

		// Token: 0x04022213 RID: 139795
		public EMediumItemGridPhantomSpecialSkill? SpecialSkill;

		// Token: 0x04022214 RID: 139796
		public int? SortNum;

		// Token: 0x04022215 RID: 139797
		public bool? IsDisable;

		// Token: 0x04022216 RID: 139798
		public MediumWarningPanelInfo WarningPanelInfo;
	}
}
