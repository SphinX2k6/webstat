using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x02006298 RID: 25240
	public class BlockInstance : IBlockInstance
	{
		// Token: 0x17009C51 RID: 40017
		// (get) Token: 0x0603F864 RID: 260196 RVA: 0x010491EE File Offset: 0x010473EE
		// (set) Token: 0x0603F865 RID: 260197 RVA: 0x010491F6 File Offset: 0x010473F6
		public int ConfigId { get; set; }

		// Token: 0x17009C52 RID: 40018
		// (get) Token: 0x0603F866 RID: 260198 RVA: 0x010491FF File Offset: 0x010473FF
		// (set) Token: 0x0603F867 RID: 260199 RVA: 0x01049207 File Offset: 0x01047407
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
		public List<ValueTuple<int, int>> Offsets { [return: TupleElementNames(new string[]
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

		// Token: 0x17009C53 RID: 40019
		// (get) Token: 0x0603F868 RID: 260200 RVA: 0x01049210 File Offset: 0x01047410
		// (set) Token: 0x0603F869 RID: 260201 RVA: 0x01049218 File Offset: 0x01047418
		public int ColorId { get; set; }

		// Token: 0x17009C54 RID: 40020
		// (get) Token: 0x0603F86A RID: 260202 RVA: 0x01049221 File Offset: 0x01047421
		// (set) Token: 0x0603F86B RID: 260203 RVA: 0x01049229 File Offset: 0x01047429
		public EGemType GemType { get; set; }

		// Token: 0x17009C55 RID: 40021
		// (get) Token: 0x0603F86C RID: 260204 RVA: 0x01049232 File Offset: 0x01047432
		// (set) Token: 0x0603F86D RID: 260205 RVA: 0x0104923A File Offset: 0x0104743A
		public EGemFillType GemFill { get; set; }

		// Token: 0x17009C56 RID: 40022
		// (get) Token: 0x0603F86E RID: 260206 RVA: 0x01049243 File Offset: 0x01047443
		// (set) Token: 0x0603F86F RID: 260207 RVA: 0x0104924B File Offset: 0x0104744B
		public int GemOffSet { get; set; }
	}
}
