using System;

// Token: 0x020017B6 RID: 6070
public class BirthdayInfo
{
	// Token: 0x0600AB42 RID: 43842 RVA: 0x002DC4D9 File Offset: 0x002DA6D9
	public BirthdayInfo(BirthdayDefine.ETriggerType triggerType, int year, int? roleId = null)
	{
		this.TriggerType = triggerType;
		this.Year = year;
		this.RoleId = roleId;
	}

	// Token: 0x04005175 RID: 20853
	public BirthdayDefine.ETriggerType TriggerType;

	// Token: 0x04005176 RID: 20854
	public int Year;

	// Token: 0x04005177 RID: 20855
	public int? RoleId;
}
