using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B90 RID: 7056
public class MapAreaShowCountryItem : CommonTabItem
{
	// Token: 0x0600CD22 RID: 52514 RVA: 0x00369B34 File Offset: 0x00367D34
	[NullableContext(1)]
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		CommonTabData data2 = data.Data;
		base.UpdateTabIcon(((data2 != null) ? data2.GetIcon() : null) ?? "");
		CommonTabData data3 = data.Data;
		this.UpdateRedDot((data3 != null) ? data3.GetTitleData() : null);
	}

	// Token: 0x0600CD23 RID: 52515 RVA: 0x00369B70 File Offset: 0x00367D70
	[NullableContext(2)]
	private void UpdateRedDot(CommonTabTitleData titleData = null)
	{
		object obj;
		if (titleData == null)
		{
			obj = null;
		}
		else
		{
			object[] args = titleData.Args;
			obj = ((args != null) ? args[0] : null);
		}
		ExploreCountryData exploreCountryData = obj as ExploreCountryData;
		bool redDotState = exploreCountryData != null && exploreCountryData.HasCanTakeStageReward();
		base.SetRedDotState(redDotState);
	}
}
