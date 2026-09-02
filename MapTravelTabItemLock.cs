using System;
using System.Runtime.CompilerServices;

// Token: 0x02001396 RID: 5014
public class MapTravelTabItemLock : MapTravelTabItemBase
{
	// Token: 0x060089DA RID: 35290 RVA: 0x00244218 File Offset: 0x00242418
	protected override void OnStart()
	{
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(true);
		base.GetItem(4).SetUIActive(false);
	}

	// Token: 0x060089DB RID: 35291 RVA: 0x00244241 File Offset: 0x00242441
	[NullableContext(1)]
	public void RefreshByData(SoarChallengePlayData data)
	{
		this.Data = data;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.NameTextId, Array.Empty<object>());
	}

	// Token: 0x02007737 RID: 30519
	private class ETabComponents
	{
		// Token: 0x040290CC RID: 168140
		public const int Toggle = 0;

		// Token: 0x040290CD RID: 168141
		public const int Name = 1;

		// Token: 0x040290CE RID: 168142
		public const int SpriteDone = 2;

		// Token: 0x040290CF RID: 168143
		public const int SpriteLock = 3;

		// Token: 0x040290D0 RID: 168144
		public const int RedDot = 4;

		// Token: 0x040290D1 RID: 168145
		public const int ItemNew = 5;
	}
}
