using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064AA RID: 25770
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookTabItemLock : RoadBookTabItemBase
	{
		// Token: 0x0604099F RID: 264607 RVA: 0x0108F38A File Offset: 0x0108D58A
		public RoadBookTabItemLock(ActivityRoadBookData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x060409A0 RID: 264608 RVA: 0x0108F393 File Offset: 0x0108D593
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x060409A1 RID: 264609 RVA: 0x0108F3BC File Offset: 0x0108D5BC
		public override void RefreshByData(RoadBookAreaData data, int index)
		{
			base.RefreshByData(data, index);
			Area value = ConfigBase<AreaConfig>.Instance.GetAreaInfo(data.AreaId).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Title, Array.Empty<object>());
		}
	}
}
