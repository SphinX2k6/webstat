using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EFA RID: 20218
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class TetrominoConfig : ITetrominoConfig
	{
		// Token: 0x17008A0C RID: 35340
		// (get) Token: 0x0603442A RID: 214058 RVA: 0x00D12C83 File Offset: 0x00D10E83
		// (set) Token: 0x0603442B RID: 214059 RVA: 0x00D12C8B File Offset: 0x00D10E8B
		[RequiredMember]
		public string ShapeName { get; set; }

		// Token: 0x17008A0D RID: 35341
		// (get) Token: 0x0603442C RID: 214060 RVA: 0x00D12C94 File Offset: 0x00D10E94
		// (set) Token: 0x0603442D RID: 214061 RVA: 0x00D12C9C File Offset: 0x00D10E9C
		[RequiredMember]
		public SlidingBlocksDefine.ETetrominoType Type { get; set; }

		// Token: 0x17008A0E RID: 35342
		// (get) Token: 0x0603442E RID: 214062 RVA: 0x00D12CA5 File Offset: 0x00D10EA5
		// (set) Token: 0x0603442F RID: 214063 RVA: 0x00D12CAD File Offset: 0x00D10EAD
		[RequiredMember]
		public ITetrisBoard Board { get; set; }

		// Token: 0x06034430 RID: 214064 RVA: 0x00D12CB6 File Offset: 0x00D10EB6
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public TetrominoConfig()
		{
		}
	}
}
