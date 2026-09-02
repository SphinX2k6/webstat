using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;

namespace ActivityNamespace.MapTravel
{
	// Token: 0x020043C5 RID: 17349
	public class MapTravelTabItem : MapTravelTabItemBase
	{
		// Token: 0x0602E1EA RID: 188906 RVA: 0x00AD7E66 File Offset: 0x00AD6066
		[NullableContext(1)]
		public MapTravelTabItem(ActivityMapTravelData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x0602E1EB RID: 188907 RVA: 0x00AD7E70 File Offset: 0x00AD6070
		[NullableContext(1)]
		public override void RefreshByData(MapTravelAreaData data, int index)
		{
			base.RefreshByData(data, index);
			Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(data.AreaId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), areaInfo.Value.Title, Array.Empty<object>());
			bool uiactive = this.ActivityBaseData.IsAreaTaskFinish(data.AreaId);
			bool areaRewardState = this.ActivityBaseData.GetAreaRewardState(data.AreaId);
			base.GetItem(2).SetUIActive(uiactive);
			base.GetItem(3).SetUIActive(!data.IsUnlock);
			base.GetItem(4).SetUIActive(areaRewardState);
		}

		// Token: 0x0200A62F RID: 42543
		private new class ETabComponents
		{
			// Token: 0x04033638 RID: 210488
			public const int Toggle = 0;

			// Token: 0x04033639 RID: 210489
			public const int Name = 1;

			// Token: 0x0403363A RID: 210490
			public const int SpriteDone = 2;

			// Token: 0x0403363B RID: 210491
			public const int SpriteLock = 3;

			// Token: 0x0403363C RID: 210492
			public const int RedDot = 4;
		}
	}
}
