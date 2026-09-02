using System;
using System.Runtime.CompilerServices;

// Token: 0x020013D9 RID: 5081
[NullableContext(1)]
[Nullable(0)]
public class MoonChasingPopularityUpData
{
	// Token: 0x06008C7E RID: 35966 RVA: 0x0024EFD9 File Offset: 0x0024D1D9
	public MoonChasingPopularityUpData(int roleId, int lastPopularity, int currentPopularity, string dialogName, string title)
	{
		this.RoleId = roleId;
		this.LastPopularity = lastPopularity;
		this.CurrentPopularity = currentPopularity;
		this.DialogName = dialogName;
		this.Title = title;
	}

	// Token: 0x04004177 RID: 16759
	public int RoleId;

	// Token: 0x04004178 RID: 16760
	public int LastPopularity;

	// Token: 0x04004179 RID: 16761
	public int CurrentPopularity;

	// Token: 0x0400417A RID: 16762
	public string DialogName = string.Empty;

	// Token: 0x0400417B RID: 16763
	public string Title;
}
