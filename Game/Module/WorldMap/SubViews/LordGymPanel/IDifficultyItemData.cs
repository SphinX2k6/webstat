using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.LordGymPanel
{
	// Token: 0x02004BA7 RID: 19367
	[NullableContext(1)]
	public interface IDifficultyItemData
	{
		// Token: 0x170086E9 RID: 34537
		// (get) Token: 0x060328F9 RID: 207097
		// (set) Token: 0x060328FA RID: 207098
		string NameTextId { get; set; }

		// Token: 0x170086EA RID: 34538
		// (get) Token: 0x060328FB RID: 207099
		// (set) Token: 0x060328FC RID: 207100
		[Nullable(new byte[]
		{
			2,
			1
		})]
		object[] NameTextArg { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170086EB RID: 34539
		// (get) Token: 0x060328FD RID: 207101
		// (set) Token: 0x060328FE RID: 207102
		List<ELordGymDifficultyState> StateList { get; set; }
	}
}
