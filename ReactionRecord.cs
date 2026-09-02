using System;

// Token: 0x02002120 RID: 8480
public class ReactionRecord
{
	// Token: 0x06010362 RID: 66402 RVA: 0x00474F38 File Offset: 0x00473138
	public ReactionRecord(int roleId, int reactionNumber)
	{
		this.role_id = roleId;
		this.reaction = reactionNumber;
	}

	// Token: 0x04007D15 RID: 32021
	public int role_id;

	// Token: 0x04007D16 RID: 32022
	public int reaction;

	// Token: 0x04007D17 RID: 32023
	public int trigger_count;

	// Token: 0x04007D18 RID: 32024
	public int damage;
}
