using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D3A RID: 11578
public class WeeklyRogueSettleInfoPanel : UiPanelBase
{
	// Token: 0x060175C6 RID: 95686 RVA: 0x0067A0CC File Offset: 0x006782CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout))
		};
	}

	// Token: 0x060175C7 RID: 95687 RVA: 0x0067A0EF File Offset: 0x006782EF
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<WeeklyRogueSettleInfoPanelItem, WeeklyRogueSettleInfoItemData>(base.GetVerticalLayout(0), () => new WeeklyRogueSettleInfoPanelItem(), null, false, true);
	}

	// Token: 0x060175C8 RID: 95688 RVA: 0x0067A128 File Offset: 0x00678328
	[NullableContext(1)]
	public void UpdateData(RogueWeeklyResultNotify data)
	{
		WeeklyRogueSettleInfoPanel.<>c__DisplayClass4_0 CS$<>8__locals1 = new WeeklyRogueSettleInfoPanel.<>c__DisplayClass4_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.dataList = new List<WeeklyRogueSettleInfoItemData>();
		CS$<>8__locals1.dataList.Add(new WeeklyRogueSettleInfoItemData
		{
			Title = "WeeklyRogueSettleProgressTitle",
			Content = data.CurLayer.ToString() + "/" + data.MaxLayer.ToString(),
			IsScoreUp = false
		});
		if (data.ExtraScore != 0)
		{
			CS$<>8__locals1.dataList.Add(new WeeklyRogueSettleInfoItemData
			{
				Title = "WeRogueNewSettleScore",
				Content = data.Score.ToString(),
				IsScoreUp = false
			});
			CS$<>8__locals1.dataList.Add(new WeeklyRogueSettleInfoItemData
			{
				Title = "WeRogueNewSettleExtraRoomScore",
				Content = data.ExtraScore.ToString(),
				IsScoreUp = false
			});
		}
		CS$<>8__locals1.dataList.Add(new WeeklyRogueSettleInfoItemData
		{
			Title = "WeRogueNewSettleTotalScore",
			Content = (data.Score + data.ExtraScore).ToString(),
			IsScoreUp = data.UseRecommendRole
		});
		UiAsyncTask task = new UiAsyncTask("WeeklyRogueSettleInfoPanel.UpdateData", delegate()
		{
			WeeklyRogueSettleInfoPanel.<>c__DisplayClass4_0.<<UpdateData>b__0>d <<UpdateData>b__0>d;
			<<UpdateData>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<UpdateData>b__0>d.<>4__this = CS$<>8__locals1;
			<<UpdateData>b__0>d.<>1__state = -1;
			<<UpdateData>b__0>d.<>t__builder.Start<WeeklyRogueSettleInfoPanel.<>c__DisplayClass4_0.<<UpdateData>b__0>d>(ref <<UpdateData>b__0>d);
			return <<UpdateData>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0400B368 RID: 45928
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WeeklyRogueSettleInfoPanelItem, WeeklyRogueSettleInfoItemData> Layout;

	// Token: 0x02008FFB RID: 36859
	private enum EWeeklyRogueSettleInfoPanelDefine
	{
		// Token: 0x040304F2 RID: 197874
		Layout
	}
}
