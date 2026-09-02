using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001AC5 RID: 6853
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssRankRoleData
{
	// Token: 0x0600C4D3 RID: 50387 RVA: 0x0033EF40 File Offset: 0x0033D140
	public Dictionary<int, int> GetEquipPluginMap()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < 9; i++)
		{
			dictionary[i] = 0;
		}
		for (int j = 0; j < this.DangoEquipIds.Length; j++)
		{
			dictionary[j] = this.DangoEquipIds[j];
		}
		return dictionary;
	}

	// Token: 0x04005E73 RID: 24179
	public bool IsEmpty = true;

	// Token: 0x04005E74 RID: 24180
	public int RoleSkinId;

	// Token: 0x04005E75 RID: 24181
	public int RoleLevel;

	// Token: 0x04005E76 RID: 24182
	public int DangoId;

	// Token: 0x04005E77 RID: 24183
	public bool IsOnline;

	// Token: 0x04005E78 RID: 24184
	public int Pos;

	// Token: 0x04005E79 RID: 24185
	public int[] DangoEquipIds = Array.Empty<int>();
}
