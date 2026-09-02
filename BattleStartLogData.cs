using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002115 RID: 8469
[NullableContext(1)]
[Nullable(0)]
public class BattleStartLogData : PlayerCommonLogData
{
	// Token: 0x17001376 RID: 4982
	// (get) Token: 0x0601034A RID: 66378 RVA: 0x00474D0A File Offset: 0x00472F0A
	public override string event_id
	{
		get
		{
			return "102704";
		}
	}

	// Token: 0x04007C7C RID: 31868
	public int i_area_id;

	// Token: 0x04007C7D RID: 31869
	public double f_x;

	// Token: 0x04007C7E RID: 31870
	public double f_y;

	// Token: 0x04007C7F RID: 31871
	public double f_z;

	// Token: 0x04007C80 RID: 31872
	public string s_battle_id = "";

	// Token: 0x04007C81 RID: 31873
	public List<int> s_team_character;

	// Token: 0x04007C82 RID: 31874
	public List<int> s_team_hp_per;
}
