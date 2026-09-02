using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006454 RID: 25684
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeLootViewOpenParam : IRoverlikeLootViewOpenParam
	{
		// Token: 0x17009E26 RID: 40486
		// (get) Token: 0x06040756 RID: 264022 RVA: 0x010853B9 File Offset: 0x010835B9
		// (set) Token: 0x06040757 RID: 264023 RVA: 0x010853C1 File Offset: 0x010835C1
		public bool IsInGame { get; set; }

		// Token: 0x17009E27 RID: 40487
		// (get) Token: 0x06040758 RID: 264024 RVA: 0x010853CA File Offset: 0x010835CA
		// (set) Token: 0x06040759 RID: 264025 RVA: 0x010853D2 File Offset: 0x010835D2
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RoverRogueGainEntry> Loots { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009E28 RID: 40488
		// (get) Token: 0x0604075A RID: 264026 RVA: 0x010853DB File Offset: 0x010835DB
		// (set) Token: 0x0604075B RID: 264027 RVA: 0x010853E3 File Offset: 0x010835E3
		public bool? EnableUse { get; set; }

		// Token: 0x17009E29 RID: 40489
		// (get) Token: 0x0604075C RID: 264028 RVA: 0x010853EC File Offset: 0x010835EC
		// (set) Token: 0x0604075D RID: 264029 RVA: 0x010853F4 File Offset: 0x010835F4
		public List<int> EquippedLootIds { get; set; }

		// Token: 0x17009E2A RID: 40490
		// (get) Token: 0x0604075E RID: 264030 RVA: 0x010853FD File Offset: 0x010835FD
		// (set) Token: 0x0604075F RID: 264031 RVA: 0x01085405 File Offset: 0x01083605
		public Action<int, int> OnConfirmSelect { get; set; }

		// Token: 0x17009E2B RID: 40491
		// (get) Token: 0x06040760 RID: 264032 RVA: 0x0108540E File Offset: 0x0108360E
		// (set) Token: 0x06040761 RID: 264033 RVA: 0x01085416 File Offset: 0x01083616
		public int DefaultSelectedLootId { get; set; }
	}
}
