using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components.SubComponents
{
	// Token: 0x020058AE RID: 22702
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaNpcMarkSelectComponent : MarkSelectComponent
	{
		// Token: 0x06039AD0 RID: 236240 RVA: 0x00E9FB91 File Offset: 0x00E9DD91
		protected override string GetSelectSequenceName()
		{
			return "Start";
		}

		// Token: 0x06039AD1 RID: 236241 RVA: 0x00E9FB98 File Offset: 0x00E9DD98
		protected override string GetUnSelectSequenceName()
		{
			return "Close";
		}
	}
}
