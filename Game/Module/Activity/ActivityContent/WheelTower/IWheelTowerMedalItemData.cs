using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006223 RID: 25123
	public interface IWheelTowerMedalItemData
	{
		// Token: 0x17009C20 RID: 39968
		// (get) Token: 0x0603F649 RID: 259657
		// (set) Token: 0x0603F64A RID: 259658
		int GroupId { get; set; }

		// Token: 0x17009C21 RID: 39969
		// (get) Token: 0x0603F64B RID: 259659
		// (set) Token: 0x0603F64C RID: 259660
		bool? IsLast { get; set; }

		// Token: 0x17009C22 RID: 39970
		// (get) Token: 0x0603F64D RID: 259661
		// (set) Token: 0x0603F64E RID: 259662
		bool? DisableInteract { get; set; }

		// Token: 0x17009C23 RID: 39971
		// (get) Token: 0x0603F64F RID: 259663
		// (set) Token: 0x0603F650 RID: 259664
		bool? HideDetails { get; set; }
	}
}
