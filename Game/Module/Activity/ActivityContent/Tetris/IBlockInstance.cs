using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x02006297 RID: 25239
	public interface IBlockInstance
	{
		// Token: 0x17009C4B RID: 40011
		// (get) Token: 0x0603F858 RID: 260184
		// (set) Token: 0x0603F859 RID: 260185
		int ConfigId { get; set; }

		// Token: 0x17009C4C RID: 40012
		// (get) Token: 0x0603F85A RID: 260186
		// (set) Token: 0x0603F85B RID: 260187
		[TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})]
		[Nullable(new byte[]
		{
			1,
			0
		})]
		List<ValueTuple<int, int>> Offsets { [return: TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [return: Nullable(new byte[]
		{
			1,
			0
		})] get; [param: TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [param: Nullable(new byte[]
		{
			1,
			0
		})] set; }

		// Token: 0x17009C4D RID: 40013
		// (get) Token: 0x0603F85C RID: 260188
		// (set) Token: 0x0603F85D RID: 260189
		int ColorId { get; set; }

		// Token: 0x17009C4E RID: 40014
		// (get) Token: 0x0603F85E RID: 260190
		// (set) Token: 0x0603F85F RID: 260191
		EGemType GemType { get; set; }

		// Token: 0x17009C4F RID: 40015
		// (get) Token: 0x0603F860 RID: 260192
		// (set) Token: 0x0603F861 RID: 260193
		EGemFillType GemFill { get; set; }

		// Token: 0x17009C50 RID: 40016
		// (get) Token: 0x0603F862 RID: 260194
		// (set) Token: 0x0603F863 RID: 260195
		int GemOffSet { get; set; }
	}
}
