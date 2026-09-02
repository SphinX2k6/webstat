using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x02006740 RID: 26432
	[NullableContext(1)]
	public interface IBusinessTipsShopData
	{
		// Token: 0x1700A0BE RID: 41150
		// (get) Token: 0x06041ED2 RID: 270034
		// (set) Token: 0x06041ED3 RID: 270035
		int RoleId { get; set; }

		// Token: 0x1700A0BF RID: 41151
		// (get) Token: 0x06041ED4 RID: 270036
		// (set) Token: 0x06041ED5 RID: 270037
		bool IsMoreSuccessful { get; set; }

		// Token: 0x1700A0C0 RID: 41152
		// (get) Token: 0x06041ED6 RID: 270038
		// (set) Token: 0x06041ED7 RID: 270039
		int TrainType { get; set; }

		// Token: 0x1700A0C1 RID: 41153
		// (get) Token: 0x06041ED8 RID: 270040
		// (set) Token: 0x06041ED9 RID: 270041
		EditTeamData LastData { get; set; }
	}
}
