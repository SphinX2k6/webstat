using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;

namespace ActivityNamespace.MapTravel
{
	// Token: 0x020043C6 RID: 17350
	public class MapTravelTabItemLock : MapTravelTabItemBase
	{
		// Token: 0x0602E1EC RID: 188908 RVA: 0x00AD7F0E File Offset: 0x00AD610E
		[NullableContext(1)]
		public MapTravelTabItemLock(ActivityMapTravelData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x0602E1ED RID: 188909 RVA: 0x00AD7F17 File Offset: 0x00AD6117
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(false);
		}

		// Token: 0x0602E1EE RID: 188910 RVA: 0x00AD7F40 File Offset: 0x00AD6140
		[NullableContext(1)]
		public override void RefreshByData(MapTravelAreaData data, int index)
		{
			base.RefreshByData(data, index);
			Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(data.AreaId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), areaInfo.Value.Title, Array.Empty<object>());
		}

		// Token: 0x0200A630 RID: 42544
		private new class ETabComponents
		{
			// Token: 0x0403363D RID: 210493
			public const int Toggle = 0;

			// Token: 0x0403363E RID: 210494
			public const int Name = 1;

			// Token: 0x0403363F RID: 210495
			public const int SpriteDone = 2;

			// Token: 0x04033640 RID: 210496
			public const int SpriteLock = 3;

			// Token: 0x04033641 RID: 210497
			public const int RedDot = 4;
		}
	}
}
