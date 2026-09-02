using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EC6 RID: 20166
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseLockedHint : ITowerDefenseLockedHint
	{
		// Token: 0x170089B6 RID: 35254
		// (get) Token: 0x06034180 RID: 213376 RVA: 0x00D04B50 File Offset: 0x00D02D50
		// (set) Token: 0x06034181 RID: 213377 RVA: 0x00D04B58 File Offset: 0x00D02D58
		public string TextId { get; set; }

		// Token: 0x170089B7 RID: 35255
		// (get) Token: 0x06034182 RID: 213378 RVA: 0x00D04B61 File Offset: 0x00D02D61
		// (set) Token: 0x06034183 RID: 213379 RVA: 0x00D04B69 File Offset: 0x00D02D69
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] Args { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
