using System;

// Token: 0x02002135 RID: 8501
public class ExploreToolAuthorizationLogData
{
	// Token: 0x060103A2 RID: 66466 RVA: 0x00475828 File Offset: 0x00473A28
	public ExploreToolAuthorizationLogData(int auth_id, int item_id)
	{
		this.i_auth_id = auth_id;
		this.i_item_id = item_id;
	}

	// Token: 0x04007DFA RID: 32250
	public int i_auth_id;

	// Token: 0x04007DFB RID: 32251
	public int i_item_id;
}
