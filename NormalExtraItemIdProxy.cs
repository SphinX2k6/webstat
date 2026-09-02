using System;
using System.Runtime.CompilerServices;

// Token: 0x02002909 RID: 10505
public class NormalExtraItemIdProxy : IExtraItemIdProxy
{
	// Token: 0x06014DC5 RID: 85445 RVA: 0x005C76C5 File Offset: 0x005C58C5
	[NullableContext(1)]
	public NormalExtraItemIdProxy(RouletteListDataExplore Owner)
	{
		this.Owner = Owner;
	}

	// Token: 0x06014DC6 RID: 85446 RVA: 0x005C76D4 File Offset: 0x005C58D4
	public int GetExtraItemId()
	{
		return this.CurrentItemId;
	}

	// Token: 0x06014DC7 RID: 85447 RVA: 0x005C76DC File Offset: 0x005C58DC
	[NullableContext(2)]
	public void SetExtraItemId(int itemId, Action<bool> callback = null)
	{
		IRouletteListSaveData rouletteListSaveData = this.Owner.GetRouletteListSaveData();
		rouletteListSaveData.ExtraItemId = itemId;
		ControllerBase<RouletteController>.Instance.SaveRouletteDataRequest(rouletteListSaveData, callback);
	}

	// Token: 0x06014DC8 RID: 85448 RVA: 0x005C7708 File Offset: 0x005C5908
	public void ApplyServerSnapshot(int itemId)
	{
		this.CurrentItemId = itemId;
	}

	// Token: 0x0400A08B RID: 41099
	private int CurrentItemId;

	// Token: 0x0400A08C RID: 41100
	[Nullable(1)]
	private readonly RouletteListDataExplore Owner;
}
