using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006217 RID: 25111
	[NullableContext(1)]
	public interface IWheelTowerResultViewButtonData
	{
		// Token: 0x17009BD5 RID: 39893
		// (get) Token: 0x0603F5AC RID: 259500
		// (set) Token: 0x0603F5AD RID: 259501
		string Name { get; set; }

		// Token: 0x17009BD6 RID: 39894
		// (get) Token: 0x0603F5AE RID: 259502
		// (set) Token: 0x0603F5AF RID: 259503
		Action OnClick { get; set; }

		// Token: 0x17009BD7 RID: 39895
		// (get) Token: 0x0603F5B0 RID: 259504
		// (set) Token: 0x0603F5B1 RID: 259505
		EConfirmBoxConfigId? ConfirmBoxId { get; set; }
	}
}
