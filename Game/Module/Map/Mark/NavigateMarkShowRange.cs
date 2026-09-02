using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x0200581B RID: 22555
	public class NavigateMarkShowRange : NavigateMark
	{
		// Token: 0x0603959D RID: 234909 RVA: 0x00E8E353 File Offset: 0x00E8C553
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public NavigateMarkShowRange()
		{
		}

		// Token: 0x040209B5 RID: 133557
		public float? Width;

		// Token: 0x040209B6 RID: 133558
		[Nullable(2)]
		public string Tips;

		// Token: 0x040209B7 RID: 133559
		public bool? IsDiscover;
	}
}
