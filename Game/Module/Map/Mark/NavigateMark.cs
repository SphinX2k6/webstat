using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x0200581C RID: 22556
	[RequiredMember]
	public class NavigateMark
	{
		// Token: 0x0603959E RID: 234910 RVA: 0x00E8E35B File Offset: 0x00E8C55B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public NavigateMark()
		{
		}

		// Token: 0x040209B8 RID: 133560
		[RequiredMember]
		public int MarkId;

		// Token: 0x040209B9 RID: 133561
		[RequiredMember]
		public EMarkType MarkType;

		// Token: 0x040209BA RID: 133562
		public float? Height;

		// Token: 0x040209BB RID: 133563
		public bool? Focal;

		// Token: 0x040209BC RID: 133564
		public bool? FocusTween;

		// Token: 0x040209BD RID: 133565
		public int? GamePlayId;

		// Token: 0x040209BE RID: 133566
		[Nullable(2)]
		public string ExploreTypeName;

		// Token: 0x040209BF RID: 133567
		public bool? NeedTempShow;
	}
}
