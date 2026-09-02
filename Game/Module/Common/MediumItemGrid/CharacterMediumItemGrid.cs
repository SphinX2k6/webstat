using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E5C RID: 24156
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class CharacterMediumItemGrid : MediumItemGridBase
	{
		// Token: 0x1700994C RID: 39244
		// (get) Token: 0x0603CCAB RID: 249003 RVA: 0x00F6FDEA File Offset: 0x00F6DFEA
		public override EMediumItemGridType Type
		{
			get
			{
				return EMediumItemGridType.Character;
			}
		}

		// Token: 0x0603CCAC RID: 249004 RVA: 0x00F6FDED File Offset: 0x00F6DFED
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CharacterMediumItemGrid()
		{
		}

		// Token: 0x04022217 RID: 139799
		[RequiredMember]
		public int SkinId;

		// Token: 0x04022218 RID: 139800
		public int? ElementId;

		// Token: 0x04022219 RID: 139801
		public bool? IsTrialRoleVisible;

		// Token: 0x0402221A RID: 139802
		public int? Level;

		// Token: 0x0402221B RID: 139803
		public bool? IsLevelTextUseChangeColor;

		// Token: 0x0402221C RID: 139804
		public int? Index;

		// Token: 0x0402221D RID: 139805
		public bool? IsInTeam;

		// Token: 0x0402221E RID: 139806
		public bool? HighlightIndex;

		// Token: 0x0402221F RID: 139807
		public bool? IsRecommendVisible;

		// Token: 0x04022220 RID: 139808
		public bool? IsDisable;

		// Token: 0x04022221 RID: 139809
		public bool? IsNewVisible;

		// Token: 0x04022222 RID: 139810
		public MediumItemGridCostComponentData ShowCostData;

		// Token: 0x04022223 RID: 139811
		public bool? IsShowLock;

		// Token: 0x04022224 RID: 139812
		public bool? IsShowWeeklyRogueTag;

		// Token: 0x04022225 RID: 139813
		public HaveAreaInfo HalfAreaInfo;

		// Token: 0x04022226 RID: 139814
		public bool? IsUnRecommendVisible;

		// Token: 0x04022227 RID: 139815
		public bool? FrameEffect;

		// Token: 0x04022228 RID: 139816
		public IMediumLevelAndStar LvAndStar;

		// Token: 0x04022229 RID: 139817
		public ERoleDevelopHotRoleTag? RoleDevTag;

		// Token: 0x0402222A RID: 139818
		public bool? IsRecommendBottomVisible;

		// Token: 0x0402222B RID: 139819
		public bool? IsTrialBottomVisible;

		// Token: 0x0402222C RID: 139820
		public bool? IsRoleDevelopTagMark;

		// Token: 0x0402222D RID: 139821
		public int? AddLevel;

		// Token: 0x0402222E RID: 139822
		public int? SkillBranchIndex;

		// Token: 0x0402222F RID: 139823
		public bool? IsShowArchive;
	}
}
