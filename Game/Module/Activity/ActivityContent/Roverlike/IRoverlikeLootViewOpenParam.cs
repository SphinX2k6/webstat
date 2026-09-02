using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006453 RID: 25683
	[NullableContext(2)]
	public interface IRoverlikeLootViewOpenParam
	{
		// Token: 0x17009E20 RID: 40480
		// (get) Token: 0x0604074A RID: 264010
		// (set) Token: 0x0604074B RID: 264011
		bool IsInGame { get; set; }

		// Token: 0x17009E21 RID: 40481
		// (get) Token: 0x0604074C RID: 264012
		// (set) Token: 0x0604074D RID: 264013
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<RoverRogueGainEntry> Loots { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009E22 RID: 40482
		// (get) Token: 0x0604074E RID: 264014
		// (set) Token: 0x0604074F RID: 264015
		bool? EnableUse { get; set; }

		// Token: 0x17009E23 RID: 40483
		// (get) Token: 0x06040750 RID: 264016
		// (set) Token: 0x06040751 RID: 264017
		List<int> EquippedLootIds { get; set; }

		// Token: 0x17009E24 RID: 40484
		// (get) Token: 0x06040752 RID: 264018
		// (set) Token: 0x06040753 RID: 264019
		Action<int, int> OnConfirmSelect { get; set; }

		// Token: 0x17009E25 RID: 40485
		// (get) Token: 0x06040754 RID: 264020
		// (set) Token: 0x06040755 RID: 264021
		int DefaultSelectedLootId { get; set; }
	}
}
