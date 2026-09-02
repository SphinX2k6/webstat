using System;
using System.Runtime.CompilerServices;

// Token: 0x02001395 RID: 5013
public class MapTravelTabItem : MapTravelTabItemBase
{
	// Token: 0x060089D7 RID: 35287 RVA: 0x00244170 File Offset: 0x00242370
	[NullableContext(1)]
	public void RefreshByData(SoarChallengePlayData data)
	{
		this.Data = data;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.NameTextId, Array.Empty<object>());
		base.GetItem(2).SetUIActive(data.IsFinished);
		base.GetItem(3).SetUIActive(!data.IsUnlock);
		base.GetItem(4).SetUIActive(data.HasRedDot);
		base.GetItem(5).SetUIActive(data.IsUnlock && data.IsNew && !data.HasRedDot);
	}

	// Token: 0x060089D8 RID: 35288 RVA: 0x00244201 File Offset: 0x00242401
	public void SetItemNewVisible(bool bVisible)
	{
		base.GetItem(5).SetUIActive(bVisible);
	}

	// Token: 0x02007736 RID: 30518
	private class ETabComponents
	{
		// Token: 0x040290C6 RID: 168134
		public const int Toggle = 0;

		// Token: 0x040290C7 RID: 168135
		public const int Name = 1;

		// Token: 0x040290C8 RID: 168136
		public const int SpriteDone = 2;

		// Token: 0x040290C9 RID: 168137
		public const int SpriteLock = 3;

		// Token: 0x040290CA RID: 168138
		public const int RedDot = 4;

		// Token: 0x040290CB RID: 168139
		public const int ItemNew = 5;
	}
}
