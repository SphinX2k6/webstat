using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x02006742 RID: 26434
	public interface IBusinessRoleTrainData
	{
		// Token: 0x1700A0C6 RID: 41158
		// (get) Token: 0x06041EE3 RID: 270051
		// (set) Token: 0x06041EE4 RID: 270052
		bool IsMoreSuccessful { get; set; }

		// Token: 0x1700A0C7 RID: 41159
		// (get) Token: 0x06041EE5 RID: 270053
		// (set) Token: 0x06041EE6 RID: 270054
		int TrainType { get; set; }

		// Token: 0x1700A0C8 RID: 41160
		// (get) Token: 0x06041EE7 RID: 270055
		// (set) Token: 0x06041EE8 RID: 270056
		int LastLevel { get; set; }
	}
}
