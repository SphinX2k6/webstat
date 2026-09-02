using System;
using CSharpScript.Game.Module.AutoPilot;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE2 RID: 19682
	public class AutoPilotRideShareBtnComponent : LongPressWithProgressComponent
	{
		// Token: 0x060333AD RID: 209837 RVA: 0x00CD40A9 File Offset: 0x00CD22A9
		public AutoPilotRideShareBtnComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333AE RID: 209838 RVA: 0x00CD40B2 File Offset: 0x00CD22B2
		protected override float OnGetProgress()
		{
			return ModelBase<AutoPilotModel>.Instance.RideShareBtnProgress;
		}
	}
}
