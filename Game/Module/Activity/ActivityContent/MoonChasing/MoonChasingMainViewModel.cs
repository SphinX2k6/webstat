using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x02006750 RID: 26448
	public class MoonChasingMainViewModel
	{
		// Token: 0x04024CA8 RID: 150696
		public EMoonChasingSkipDefine SkipTarget;

		// Token: 0x04024CA9 RID: 150697
		public bool BuildingBackToBusiness;

		// Token: 0x04024CAA RID: 150698
		public int RefreshBuildingId;

		// Token: 0x04024CAB RID: 150699
		public bool IsInBuildingModule;

		// Token: 0x04024CAC RID: 150700
		public EMoonChasingTaskType TaskType = EMoonChasingTaskType.MainLine;

		// Token: 0x04024CAD RID: 150701
		public bool IsLastTask;
	}
}
