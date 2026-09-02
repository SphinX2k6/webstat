using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033C3 RID: 13251
public class RedDotFlySkinChildTab : RedDotBase
{
	// Token: 0x0601B903 RID: 112899 RVA: 0x0083BCE5 File Offset: 0x00839EE5
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B904 RID: 112900 RVA: 0x0083BCE8 File Offset: 0x00839EE8
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FlySkinTab);
	}

	// Token: 0x0601B905 RID: 112901 RVA: 0x0083BCF1 File Offset: 0x00839EF1
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<EFlySkinType>(EEventName.RefreshFlySkinChildTabRed, new Action<EFlySkinType>(this.OnRefreshFlySkinChildTabRed));
	}

	// Token: 0x0601B906 RID: 112902 RVA: 0x0083BD0F File Offset: 0x00839F0F
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<EFlySkinType>(EEventName.RefreshFlySkinChildTabRed, new Action<EFlySkinType>(this.OnRefreshFlySkinChildTabRed));
	}

	// Token: 0x0601B907 RID: 112903 RVA: 0x0083BD2D File Offset: 0x00839F2D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FlySkinModel>.Instance.CheckFlySkinHasRedDotBySkinType((EFlySkinType)uId);
	}

	// Token: 0x0601B908 RID: 112904 RVA: 0x0083BD3A File Offset: 0x00839F3A
	private void OnRefreshFlySkinChildTabRed(EFlySkinType skinType)
	{
		base.EventCheckWithUid((int)skinType);
	}
}
