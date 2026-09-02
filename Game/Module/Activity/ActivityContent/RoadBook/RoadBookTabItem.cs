using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064A9 RID: 25769
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookTabItem : RoadBookTabItemBase
	{
		// Token: 0x0604099D RID: 264605 RVA: 0x0108F2E2 File Offset: 0x0108D4E2
		public RoadBookTabItem(ActivityRoadBookData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x0604099E RID: 264606 RVA: 0x0108F2EC File Offset: 0x0108D4EC
		public override void RefreshByData(RoadBookAreaData data, int index)
		{
			base.RefreshByData(data, index);
			Area value = ConfigBase<AreaConfig>.Instance.GetAreaInfo(data.AreaId).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Title, Array.Empty<object>());
			bool uiactive = this.ActivityBaseData.IsAreaTaskFinish(data.AreaId);
			bool areaRewardState = this.ActivityBaseData.GetAreaRewardState(data.AreaId);
			base.GetItem(2).SetUIActive(uiactive);
			base.GetItem(3).SetUIActive(!data.IsUnlock);
			base.GetItem(4).SetUIActive(areaRewardState);
		}
	}
}
