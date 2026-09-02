using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200178D RID: 6029
[NullableContext(1)]
[Nullable(0)]
public class AdviceView : UiViewBase
{
	// Token: 0x0600AA26 RID: 43558 RVA: 0x002D6369 File Offset: 0x002D4569
	public AdviceView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600AA27 RID: 43559 RVA: 0x002D6374 File Offset: 0x002D4574
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x0600AA28 RID: 43560 RVA: 0x002D63E4 File Offset: 0x002D45E4
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollView<AdviceItem>(base.GetScrollViewWithScrollbar(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AdviceItem>(this.InitItem), null);
	}

	// Token: 0x0600AA29 RID: 43561 RVA: 0x002D6405 File Offset: 0x002D4605
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnDeleteAdviceSuccess, new Action(this.RefreshScrollerView));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCreateAdviceSuccess, new Action(this.RefreshScrollerView));
	}

	// Token: 0x0600AA2A RID: 43562 RVA: 0x002D643F File Offset: 0x002D463F
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnDeleteAdviceSuccess, new Action(this.RefreshScrollerView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCreateAdviceSuccess, new Action(this.RefreshScrollerView));
	}

	// Token: 0x0600AA2B RID: 43563 RVA: 0x002D6479 File Offset: 0x002D4679
	private void RefreshScrollerView()
	{
		this.RefreshScorller();
		this.RefreshShowItem();
		this.RefreshProgressText();
	}

	// Token: 0x0600AA2C RID: 43564 RVA: 0x002D6490 File Offset: 0x002D4690
	private ILayoutItem<AdviceItem> InitItem(object data, UUIItem uiItem, int index)
	{
		AdviceItem adviceItem = new AdviceItem(uiItem);
		adviceItem.Update((AdviceData)data);
		return new LayoutItem<AdviceItem>
		{
			Key = index,
			Value = adviceItem
		};
	}

	// Token: 0x0600AA2D RID: 43565 RVA: 0x002D64C8 File Offset: 0x002D46C8
	protected override void OnAfterShow()
	{
		this.RefreshScorller();
		this.RefreshShowItem();
		this.RefreshProgressText();
	}

	// Token: 0x0600AA2E RID: 43566 RVA: 0x002D64DC File Offset: 0x002D46DC
	private void RefreshScorller()
	{
		AdviceData[] adviceArray = ModelBase<AdviceModel>.Instance.GetAdviceArray();
		this.AdviceDataArray = new List<AdviceData>();
		if (adviceArray != null)
		{
			List<AdviceData> list = new List<AdviceData>();
			for (int i = adviceArray.Length - 1; i >= 0; i--)
			{
				list.Add(adviceArray[i]);
			}
			this.AdviceDataArray = list;
		}
		this.ScrollView.RefreshByData<AdviceData>(this.AdviceDataArray, null);
		this.ScrollView.UnBindLateUpdate();
		this.ScrollToDirty = true;
		this.WaitingLateUpdateFlag = 0;
		this.ScrollView.BindLateUpdate(new Action<float>(this.LateUpdate));
	}

	// Token: 0x0600AA2F RID: 43567 RVA: 0x002D6574 File Offset: 0x002D4774
	private void RefreshProgressText()
	{
		AdviceData[] adviceArray = ModelBase<AdviceModel>.Instance.GetAdviceArray();
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("AdviceCreateLimit").GetValueOrDefault();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "ReputationNormalValue", new <>z__ReadOnlyArray<object>(new object[]
		{
			(adviceArray != null) ? adviceArray.Length : 0,
			valueOrDefault
		}));
	}

	// Token: 0x0600AA30 RID: 43568 RVA: 0x002D65DC File Offset: 0x002D47DC
	private void LateUpdate(float deltaTime)
	{
		if (this.ScrollToDirty && this.WaitingLateUpdateFlag >= 1)
		{
			this.ScrollToDirty = false;
			float progress = this.GetProgress(this.AdviceDataArray.ToArray());
			base.GetScrollViewWithScrollbar(1).SetScrollProgress(progress);
			this.ScrollView.UnBindLateUpdate();
		}
		this.WaitingLateUpdateFlag++;
	}

	// Token: 0x0600AA31 RID: 43569 RVA: 0x002D663C File Offset: 0x002D483C
	private float GetProgress(AdviceData[] dataArray)
	{
		int num = 0;
		long? adviceViewShowId = ModelBase<AdviceModel>.Instance.AdviceViewShowId;
		for (int i = 0; i < dataArray.Length; i++)
		{
			if (adviceViewShowId != null)
			{
				long? adviceBigId = dataArray[i].GetAdviceBigId();
				long? num2 = adviceViewShowId;
				if (adviceBigId.GetValueOrDefault() == num2.GetValueOrDefault() & adviceBigId != null == (num2 != null))
				{
					num = i;
					break;
				}
			}
		}
		if (dataArray.Length > 1)
		{
			return (float)num / (float)(dataArray.Length - 1);
		}
		return 0f;
	}

	// Token: 0x0600AA32 RID: 43570 RVA: 0x002D66B8 File Offset: 0x002D48B8
	private void RefreshShowItem()
	{
		AdviceData[] adviceArray = ModelBase<AdviceModel>.Instance.GetAdviceArray();
		bool flag = adviceArray == null || adviceArray.Length == 0;
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		UUIItem rootComponent = scrollViewWithScrollbar.GetRootComponent();
		if (rootComponent == null)
		{
			return;
		}
		rootComponent.SetUIActive(!flag);
	}

	// Token: 0x0600AA33 RID: 43571 RVA: 0x002D670E File Offset: 0x002D490E
	protected override void OnBeforeDestroy()
	{
		GenericScrollView<AdviceItem> scrollView = this.ScrollView;
		if (scrollView == null)
		{
			return;
		}
		scrollView.ClearChildren();
	}

	// Token: 0x04005001 RID: 20481
	private const int WAITUPDATECOUNT = 1;

	// Token: 0x04005002 RID: 20482
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<AdviceItem> ScrollView;

	// Token: 0x04005003 RID: 20483
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<AdviceData> AdviceDataArray;

	// Token: 0x04005004 RID: 20484
	private bool ScrollToDirty;

	// Token: 0x04005005 RID: 20485
	private int WaitingLateUpdateFlag;

	// Token: 0x02007AEF RID: 31471
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A191 RID: 172433
		public const int ScorllerItem = 0;

		// Token: 0x0402A192 RID: 172434
		public const int Scroller = 1;

		// Token: 0x0402A193 RID: 172435
		public const int NullObject = 2;

		// Token: 0x0402A194 RID: 172436
		public const int ProgressText = 3;
	}
}
