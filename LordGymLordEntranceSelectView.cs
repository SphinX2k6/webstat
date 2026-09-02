using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002205 RID: 8709
[NullableContext(1)]
[Nullable(0)]
public class LordGymLordEntranceSelectView : UiViewBase
{
	// Token: 0x17001454 RID: 5204
	// (get) Token: 0x060106F2 RID: 67314 RVA: 0x0047D4E5 File Offset: 0x0047B6E5
	protected virtual string ShopTextId
	{
		get
		{
			return this._shopTextIdOverride ?? "Text_GymShopNew_Text";
		}
	}

	// Token: 0x17001455 RID: 5205
	// (get) Token: 0x060106F3 RID: 67315 RVA: 0x0047D4F6 File Offset: 0x0047B6F6
	protected virtual string ConfirmTextId
	{
		get
		{
			return "NewChallenge_Start";
		}
	}

	// Token: 0x17001456 RID: 5206
	// (get) Token: 0x060106F4 RID: 67316 RVA: 0x0047D4FD File Offset: 0x0047B6FD
	protected virtual int ShopTabIndex
	{
		get
		{
			return this._shopTabIndexOverride.GetValueOrDefault(3);
		}
	}

	// Token: 0x060106F5 RID: 67317 RVA: 0x0047D50B File Offset: 0x0047B70B
	public LordGymLordEntranceSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060106F6 RID: 67318 RVA: 0x0047D514 File Offset: 0x0047B714
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnShopButtonClick))
		};
	}

	// Token: 0x060106F7 RID: 67319 RVA: 0x0047D5D4 File Offset: 0x0047B7D4
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymLordEntranceSelectView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymLordEntranceSelectView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106F8 RID: 67320 RVA: 0x0047D618 File Offset: 0x0047B818
	protected virtual void InitSelect()
	{
		int index = 0;
		int lastChallengeLordEntranceId = ModelBase<LordGymModel>.Instance.LastChallengeLordEntranceId;
		if (lastChallengeLordEntranceId > 0)
		{
			for (int i = 0; i < this.LordEntranceList.Count; i++)
			{
				if (this.LordEntranceList[i] == lastChallengeLordEntranceId)
				{
					index = i;
					break;
				}
			}
		}
		this.SelectLordEntranceByIndex(index);
		this.RefreshLordGymCurrency();
		LordGymModel instance = ModelBase<LordGymModel>.Instance;
		foreach (int entranceId in this.LordEntranceList)
		{
			instance.RecordNewLordGymEntrance(entranceId);
		}
	}

	// Token: 0x060106F9 RID: 67321 RVA: 0x0047D6BC File Offset: 0x0047B8BC
	protected virtual void ReBuildLordEntranceList()
	{
	}

	// Token: 0x060106FA RID: 67322 RVA: 0x0047D6BE File Offset: 0x0047B8BE
	protected override void OnHandleLoadScene()
	{
		Singleton<UiSceneManager>.Instance.InitLordSkeletalHandle();
		ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
		ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceId(this.SelectedEntranceId, true, false);
	}

	// Token: 0x060106FB RID: 67323 RVA: 0x0047D6E7 File Offset: 0x0047B8E7
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiSceneManager>.Instance.DestroyLordSkeletalHandle();
	}

	// Token: 0x060106FC RID: 67324 RVA: 0x0047D6F3 File Offset: 0x0047B8F3
	protected virtual void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060106FD RID: 67325 RVA: 0x0047D6FC File Offset: 0x0047B8FC
	private void OnHelpBtnClick()
	{
		int helpId = ConfigLordGymEntranceSetById.GetConfig(this.EntranceSetId, true).Value.HelpId;
		ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
	}

	// Token: 0x060106FE RID: 67326 RVA: 0x0047D731 File Offset: 0x0047B931
	private LordGymLordEntranceItem CreateLordEntranceLoopItem()
	{
		return this.CreateItem();
	}

	// Token: 0x060106FF RID: 67327 RVA: 0x0047D739 File Offset: 0x0047B939
	protected virtual LordGymLordEntranceItem CreateItem()
	{
		return new LordGymLordEntranceItem
		{
			OnToggleClick = new Action<int>(this.OnLordEntranceToggleClick),
			CanExecuteChangeCallBack = new Func<int, bool>(this.CanLordEntranceToggleChange)
		};
	}

	// Token: 0x06010700 RID: 67328 RVA: 0x0047D764 File Offset: 0x0047B964
	protected void OnLordEntranceToggleClick(int index)
	{
		if (!this.CanLordEntranceToggleChange(index))
		{
			return;
		}
		this.SelectLordEntranceByIndex(index);
	}

	// Token: 0x06010701 RID: 67329 RVA: 0x0047D777 File Offset: 0x0047B977
	public virtual void SelectLordEntranceByIndex(int index)
	{
		GenericScrollViewNew<LordGymLordEntranceItem, int> lordEntranceScrollView = this.LordEntranceScrollView;
		if (lordEntranceScrollView != null)
		{
			GenericLayout<LordGymLordEntranceItem, int> genericLayout = lordEntranceScrollView.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.SelectGridProxy(index, false);
			}
		}
		this.SelectedEntranceId = this.LordEntranceList[index];
		this.OnLordEntranceSelect();
	}

	// Token: 0x06010702 RID: 67330 RVA: 0x0047D7B0 File Offset: 0x0047B9B0
	protected void ScrollEntranceIntoView(int index)
	{
		GenericScrollViewNew<LordGymLordEntranceItem, int> lordEntranceScrollView = this.LordEntranceScrollView;
		UUIItem uuiitem = (lordEntranceScrollView != null) ? lordEntranceScrollView.GetItemByIndex(index) : null;
		if (uuiitem != null)
		{
			this.LordEntranceScrollView.LateScrollTo(uuiitem, null, false);
		}
	}

	// Token: 0x06010703 RID: 67331 RVA: 0x0047D7E2 File Offset: 0x0047B9E2
	private void OnLordEntranceSelect()
	{
		ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceId(this.SelectedEntranceId, true, false);
	}

	// Token: 0x06010704 RID: 67332 RVA: 0x0047D7F8 File Offset: 0x0047B9F8
	public void RefreshLordGymCurrency()
	{
		ValueTuple<int, int> lordGymCurrencyRewardAndTotalCount = ModelBase<LordGymModel>.Instance.GetLordGymCurrencyRewardAndTotalCount(this.EntranceSetId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.ShopTextId, new <>z__ReadOnlyArray<object>(new object[]
		{
			lordGymCurrencyRewardAndTotalCount.Item1,
			lordGymCurrencyRewardAndTotalCount.Item2
		}));
	}

	// Token: 0x06010705 RID: 67333 RVA: 0x0047D854 File Offset: 0x0047BA54
	protected bool CanLordEntranceToggleChange(int index)
	{
		return index != this.LordEntranceScrollView.GetGenericLayout().GetSelectedGridIndex();
	}

	// Token: 0x06010706 RID: 67334 RVA: 0x0047D86C File Offset: 0x0047BA6C
	private void OnShopButtonClick()
	{
		ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab(PayShopDefine.EPayShopTabType.ActivityShop, this.ShopTabIndex);
	}

	// Token: 0x06010707 RID: 67335 RVA: 0x0047D87F File Offset: 0x0047BA7F
	private void OnConfirmButtonClick(int _)
	{
		this.OpenSelectView();
	}

	// Token: 0x06010708 RID: 67336 RVA: 0x0047D888 File Offset: 0x0047BA88
	protected virtual void OpenSelectView()
	{
		LordGymDifficultySelectViewParam param = new LordGymDifficultySelectViewParam
		{
			LordEntranceSetId = this.EntranceSetId,
			LordEntranceId = this.SelectedEntranceId,
			IsPlaySpecialSequence = false
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymDifficultySelectView, param, null);
	}

	// Token: 0x04008177 RID: 33143
	[Nullable(2)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x04008178 RID: 33144
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollViewNew<LordGymLordEntranceItem, int> LordEntranceScrollView;

	// Token: 0x04008179 RID: 33145
	protected int EntranceSetId;

	// Token: 0x0400817A RID: 33146
	protected int SelectedEntranceId;

	// Token: 0x0400817B RID: 33147
	[Nullable(2)]
	protected List<int> LordEntranceList;

	// Token: 0x0400817C RID: 33148
	[Nullable(2)]
	protected ButtonItem ConfirmButtonItem;

	// Token: 0x0400817D RID: 33149
	[Nullable(2)]
	private string _shopTextIdOverride;

	// Token: 0x0400817E RID: 33150
	private int? _shopTabIndexOverride;

	// Token: 0x020084D2 RID: 34002
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402CFF9 RID: 184313
		public const int CaptionItem = 0;

		// Token: 0x0402CFFA RID: 184314
		public const int LordEntranceScrollView = 1;

		// Token: 0x0402CFFB RID: 184315
		public const int LordEntranceLoopItem = 2;

		// Token: 0x0402CFFC RID: 184316
		public const int ShopButton = 3;

		// Token: 0x0402CFFD RID: 184317
		public const int ShopText = 4;

		// Token: 0x0402CFFE RID: 184318
		public const int ConfirmButton = 5;
	}
}
