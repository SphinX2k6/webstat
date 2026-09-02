using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062DF RID: 25311
	[NullableContext(1)]
	public interface IGridPoolManager
	{
		// Token: 0x0603FA8F RID: 260751
		[return: TupleElementNames(new string[]
		{
			"Grid",
			"IsNew"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		ValueTuple<TetrisGridPanel, bool> GetGrid(UUIItem poolContainer);

		// Token: 0x0603FA90 RID: 260752
		void ReturnGrid(TetrisGridPanel grid);
	}
}
