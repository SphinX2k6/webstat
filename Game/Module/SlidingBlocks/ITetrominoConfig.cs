using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EF9 RID: 20217
	[NullableContext(1)]
	public interface ITetrominoConfig
	{
		// Token: 0x17008A09 RID: 35337
		// (get) Token: 0x06034424 RID: 214052
		// (set) Token: 0x06034425 RID: 214053
		string ShapeName { get; set; }

		// Token: 0x17008A0A RID: 35338
		// (get) Token: 0x06034426 RID: 214054
		// (set) Token: 0x06034427 RID: 214055
		SlidingBlocksDefine.ETetrominoType Type { get; set; }

		// Token: 0x17008A0B RID: 35339
		// (get) Token: 0x06034428 RID: 214056
		// (set) Token: 0x06034429 RID: 214057
		ITetrisBoard Board { get; set; }
	}
}
