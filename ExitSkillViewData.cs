using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B55 RID: 6997
[NullableContext(1)]
[Nullable(0)]
public class ExitSkillViewData
{
	// Token: 0x0600CA73 RID: 51827 RVA: 0x0035E08C File Offset: 0x0035C28C
	public void AddData(int roleId, int onlineIndex, int playerId)
	{
		ExitSkillItemData item = new ExitSkillItemData
		{
			RoleId = new int?(roleId),
			OnlineIndex = new int?(onlineIndex),
			PlayerId = new int?(playerId)
		};
		this.Items.Add(item);
	}

	// Token: 0x0600CA74 RID: 51828 RVA: 0x0035E0CF File Offset: 0x0035C2CF
	public List<ExitSkillItemData> GetItems()
	{
		return this.Items;
	}

	// Token: 0x040060DB RID: 24795
	private readonly List<ExitSkillItemData> Items = new List<ExitSkillItemData>();
}
