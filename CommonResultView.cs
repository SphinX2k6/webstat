using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.ItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A0E RID: 6670
[NullableContext(1)]
[Nullable(0)]
public class CommonResultView : UiViewBase
{
	// Token: 0x0600BF32 RID: 48946 RVA: 0x003293FE File Offset: 0x003275FE
	public CommonResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600BF33 RID: 48947 RVA: 0x00329414 File Offset: 0x00327614
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite))
		};
	}

	// Token: 0x0600BF34 RID: 48948 RVA: 0x003294DC File Offset: 0x003276DC
	protected override void OnStart()
	{
		base.GetText(2).SetUIActive(false);
		this.SetResultText("ChallengeGetReward");
		base.GetItem(3).SetUIActive(false);
		this.ButtonMap = new Dictionary<string, CommonResultButton>();
		this.ButtonItemMap = new Dictionary<string, UUIItem>();
		this.SetupButtonFormat();
		this.RewardLayout = new GenericLayoutNew<CommonItemSimpleGrid>(base.GetHorizontalLayout(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonItemSimpleGrid>(this.InitScrollViewItem), null);
		this.InitTimer();
	}

	// Token: 0x0600BF35 RID: 48949 RVA: 0x0032954F File Offset: 0x0032774F
	protected override void OnBeforeDestroy()
	{
		this.ClearTimer();
		this.ResetButtonList();
		this.RewardLayout.ClearChildren();
		this.RewardLayout = null;
	}

	// Token: 0x0600BF36 RID: 48950 RVA: 0x0032956F File Offset: 0x0032776F
	protected virtual void SetupButtonFormat()
	{
	}

	// Token: 0x0600BF37 RID: 48951 RVA: 0x00329574 File Offset: 0x00327774
	private CommonResultButton CreateButtonUsingTemplateButton(CommonResultButtonData data)
	{
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		CommonResultButton commonResultButton = new CommonResultButton(Singleton<LguiUtil>.Instance.CopyItem(item, item2));
		commonResultButton.SetData(data);
		return commonResultButton;
	}

	// Token: 0x0600BF38 RID: 48952 RVA: 0x003295AC File Offset: 0x003277AC
	private void ResetButtonList()
	{
		foreach (CommonResultButton commonResultButton in this.ButtonMap.Values)
		{
			commonResultButton.Destroy(null);
		}
		this.ButtonMap.Clear();
		this.ButtonItemMap.Clear();
	}

	// Token: 0x0600BF39 RID: 48953 RVA: 0x00329618 File Offset: 0x00327818
	public void RefreshButtonList(List<CommonResultButtonData> dataList)
	{
		foreach (CommonResultButton commonResultButton in this.ButtonArray)
		{
			commonResultButton.ResetData();
			commonResultButton.SetActive(false);
		}
		int count = dataList.Count;
		List<CommonResultButton> buttonArray = this.ButtonArray;
		int count2 = buttonArray.Count;
		for (int i = 0; i < count; i++)
		{
			if (i < count2)
			{
				CommonResultButton commonResultButton2 = buttonArray[i];
				commonResultButton2.SetData(dataList[i]);
				commonResultButton2.SetActive(true);
			}
			else
			{
				CommonResultButton commonResultButton3 = this.CreateButtonUsingTemplateButton(dataList[i]);
				this.ButtonArray.Add(commonResultButton3);
				commonResultButton3.SetActive(true);
			}
		}
		foreach (CommonResultButton commonResultButton4 in this.ButtonArray)
		{
			commonResultButton4.DoRefreshCallBack();
		}
	}

	// Token: 0x0600BF3A RID: 48954 RVA: 0x0032971C File Offset: 0x0032791C
	private ILayoutItem<CommonItemSimpleGrid> InitScrollViewItem(object data, UUIItem uiItem, int index)
	{
		CommonItemSimpleGrid commonItemSimpleGrid = new CommonItemSimpleGrid(uiItem.GetOwner());
		commonItemSimpleGrid.RefreshItem(((TItem)data).ItemData.ItemId, ((TItem)data).Count);
		return new LayoutItem<CommonItemSimpleGrid>
		{
			Key = index,
			Value = commonItemSimpleGrid
		};
	}

	// Token: 0x0600BF3B RID: 48955 RVA: 0x0032976E File Offset: 0x0032796E
	public void SetResultText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textId, Array.Empty<object>());
	}

	// Token: 0x0600BF3C RID: 48956 RVA: 0x00329787 File Offset: 0x00327987
	public void SetTipsText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), textId, Array.Empty<object>());
		base.GetText(2).SetUIActive(true);
	}

	// Token: 0x0600BF3D RID: 48957 RVA: 0x003297AD File Offset: 0x003279AD
	private void InitTimer()
	{
		this.CounterTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.Timer), 1000f, 1f, null, null, true);
	}

	// Token: 0x0600BF3E RID: 48958 RVA: 0x003297D8 File Offset: 0x003279D8
	private void Timer(float _)
	{
		foreach (CommonResultButton commonResultButton in this.ButtonArray)
		{
			commonResultButton.DoTimerCallBack(this.HasRunTime);
		}
		this.HasRunTime++;
		this.OnTimer();
	}

	// Token: 0x0600BF3F RID: 48959 RVA: 0x00329844 File Offset: 0x00327A44
	protected virtual void OnTimer()
	{
	}

	// Token: 0x0600BF40 RID: 48960 RVA: 0x00329846 File Offset: 0x00327A46
	private void ClearTimer()
	{
		if (this.CounterTimer != null && TimerSystem.GameplayTimeInstance.Has(this.CounterTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CounterTimer);
		}
		this.CounterTimer = null;
	}

	// Token: 0x040059DA RID: 23002
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected Dictionary<string, CommonResultButton> ButtonMap;

	// Token: 0x040059DB RID: 23003
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected Dictionary<string, UUIItem> ButtonItemMap;

	// Token: 0x040059DC RID: 23004
	private readonly List<CommonResultButton> ButtonArray = new List<CommonResultButton>();

	// Token: 0x040059DD RID: 23005
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<CommonItemSimpleGrid> RewardLayout;

	// Token: 0x040059DE RID: 23006
	[Nullable(2)]
	private TimerHandle CounterTimer;

	// Token: 0x040059DF RID: 23007
	private int HasRunTime;

	// Token: 0x02007CF0 RID: 31984
	[NullableContext(0)]
	public enum ECommonResultView
	{
		// Token: 0x0402A9EB RID: 174571
		PanelContent,
		// Token: 0x0402A9EC RID: 174572
		ResultText,
		// Token: 0x0402A9ED RID: 174573
		TipsText,
		// Token: 0x0402A9EE RID: 174574
		ButtonTemplate,
		// Token: 0x0402A9EF RID: 174575
		ButtonParent,
		// Token: 0x0402A9F0 RID: 174576
		TeamPlayerItem,
		// Token: 0x0402A9F1 RID: 174577
		TeamPlayer1Sprite,
		// Token: 0x0402A9F2 RID: 174578
		TeamPlayer2Sprite
	}
}
