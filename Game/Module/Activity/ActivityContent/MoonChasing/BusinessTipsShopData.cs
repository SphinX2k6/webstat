using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x02006741 RID: 26433
	[NullableContext(1)]
	[Nullable(0)]
	public class BusinessTipsShopData : IBusinessTipsShopData
	{
		// Token: 0x1700A0C2 RID: 41154
		// (get) Token: 0x06041EDA RID: 270042 RVA: 0x010EA7BA File Offset: 0x010E89BA
		// (set) Token: 0x06041EDB RID: 270043 RVA: 0x010EA7C2 File Offset: 0x010E89C2
		public int RoleId { get; set; }

		// Token: 0x1700A0C3 RID: 41155
		// (get) Token: 0x06041EDC RID: 270044 RVA: 0x010EA7CB File Offset: 0x010E89CB
		// (set) Token: 0x06041EDD RID: 270045 RVA: 0x010EA7D3 File Offset: 0x010E89D3
		public bool IsMoreSuccessful { get; set; }

		// Token: 0x1700A0C4 RID: 41156
		// (get) Token: 0x06041EDE RID: 270046 RVA: 0x010EA7DC File Offset: 0x010E89DC
		// (set) Token: 0x06041EDF RID: 270047 RVA: 0x010EA7E4 File Offset: 0x010E89E4
		public int TrainType { get; set; }

		// Token: 0x1700A0C5 RID: 41157
		// (get) Token: 0x06041EE0 RID: 270048 RVA: 0x010EA7ED File Offset: 0x010E89ED
		// (set) Token: 0x06041EE1 RID: 270049 RVA: 0x010EA7F5 File Offset: 0x010E89F5
		public EditTeamData LastData { get; set; }
	}
}
