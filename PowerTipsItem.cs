using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002608 RID: 9736
[NullableContext(2)]
[Nullable(0)]
public class PowerTipsItem : UiPanelBase, IItemTipsUiProxy
{
	// Token: 0x0601315A RID: 78170 RVA: 0x0054AAFC File Offset: 0x00548CFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.ClickBackBtn))
		};
	}

	// Token: 0x0601315B RID: 78171 RVA: 0x0054ABFD File Offset: 0x00548DFD
	[NullableContext(1)]
	public void SetBackBackCallBack(Action callBack)
	{
		this.BackBtnCallBack = callBack;
	}

	// Token: 0x0601315C RID: 78172 RVA: 0x0054AC06 File Offset: 0x00548E06
	private void ClickBackBtn()
	{
		Action backBtnCallBack = this.BackBtnCallBack;
		if (backBtnCallBack == null)
		{
			return;
		}
		backBtnCallBack();
	}

	// Token: 0x0601315D RID: 78173 RVA: 0x0054AC18 File Offset: 0x00548E18
	protected override void OnStart()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Energy_Title", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Energy_Text", Array.Empty<object>());
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		UUIItem item = base.GetItem(2);
		this.ShowItem.GetOriginalItem().SetUIParent(item, false);
		this.AddEventListener();
	}

	// Token: 0x0601315E RID: 78174 RVA: 0x0054AC8C File Offset: 0x00548E8C
	private void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPowerChanged, new Action(this.OnPowerChanged));
	}

	// Token: 0x0601315F RID: 78175 RVA: 0x0054ACAA File Offset: 0x00548EAA
	private void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPowerChanged, new Action(this.OnPowerChanged));
	}

	// Token: 0x06013160 RID: 78176 RVA: 0x0054ACC8 File Offset: 0x00548EC8
	private void OnPowerChanged()
	{
		this.RefreshTitle();
		this.RefreshRecoveryText();
	}

	// Token: 0x06013161 RID: 78177 RVA: 0x0054ACD6 File Offset: 0x00548ED6
	protected override void OnBeforeShow()
	{
		this.PlayStartSequence();
	}

	// Token: 0x06013162 RID: 78178 RVA: 0x0054ACE0 File Offset: 0x00548EE0
	public void PlayStartSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x06013163 RID: 78179 RVA: 0x0054AD10 File Offset: 0x00548F10
	public UniTask PlayCloseSequence()
	{
		PowerTipsItem.<PlayCloseSequence>d__18 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<PowerTipsItem.<PlayCloseSequence>d__18>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06013164 RID: 78180 RVA: 0x0054AD54 File Offset: 0x00548F54
	protected override UniTask OnCreateAsync()
	{
		PowerTipsItem.<OnCreateAsync>d__19 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<PowerTipsItem.<OnCreateAsync>d__19>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013165 RID: 78181 RVA: 0x0054AD98 File Offset: 0x00548F98
	[NullableContext(1)]
	public void Refresh(ItemTipsData data)
	{
		this.CurrentData = (data as TipsOverPowerData);
		this.CurrentDataItemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.CurrentData.ConfigId);
		this.CurrentPowerData = ModelBase<PowerModel>.Instance.GetPowerDataById(this.CurrentData.ConfigId);
		this.ShowItem.HideExchangePopViewElement();
		PayShopGoods data2 = this.ConvertToPayShopGoods(this.CurrentData);
		this.ShowItem.Refresh(data2, false, 0);
		this.TimeHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.OnTimer();
		}, 1000f, 1f, null, null, true);
		this.RefreshView();
	}

	// Token: 0x06013166 RID: 78182 RVA: 0x0054AE3C File Offset: 0x0054903C
	private void RefreshView()
	{
		this.RefreshTitle();
		this.RefreshDesc();
		this.RefreshBgDesc();
		this.RefreshRecoveryText();
	}

	// Token: 0x06013167 RID: 78183 RVA: 0x0054AE58 File Offset: 0x00549058
	private void RefreshRecoveryText()
	{
		EPowerRecoveryMode powerRecoveryMode = this.CurrentPowerData.GetPowerRecoveryMode();
		if (powerRecoveryMode == EPowerRecoveryMode.Full)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "PowerMax", Array.Empty<object>());
			return;
		}
		if (powerRecoveryMode == EPowerRecoveryMode.Stop)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "PowerStopRecovery", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "PowerNextRecovery", new <>z__ReadOnlySingleElementList<object>(this.CurrentPowerData.GetNextTimerRecoverText()));
	}

	// Token: 0x06013168 RID: 78184 RVA: 0x0054AED8 File Offset: 0x005490D8
	private void RefreshTitle()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Energy_Number", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.CurrentPowerData.GetCurrentPower(),
			this.CurrentPowerData.GetPowerLimit()
		}));
	}

	// Token: 0x06013169 RID: 78185 RVA: 0x0054AF2C File Offset: 0x0054912C
	private void RefreshDesc()
	{
		string attributesDescription = this.CurrentDataItemConfig.AttributesDescription;
		base.GetText(3).ShowTextNew(attributesDescription);
	}

	// Token: 0x0601316A RID: 78186 RVA: 0x0054AF54 File Offset: 0x00549154
	private void RefreshBgDesc()
	{
		string bgDescription = this.CurrentDataItemConfig.BgDescription;
		if (bgDescription != null && bgDescription.Length > 0)
		{
			base.GetText(8).ShowTextNew(bgDescription);
		}
	}

	// Token: 0x0601316B RID: 78187 RVA: 0x0054AF86 File Offset: 0x00549186
	private void RefreshTime()
	{
		this.RefreshRecoveryText();
	}

	// Token: 0x0601316C RID: 78188 RVA: 0x0054AF8E File Offset: 0x0054918E
	private void OnTimer()
	{
		this.RefreshTime();
	}

	// Token: 0x0601316D RID: 78189 RVA: 0x0054AF96 File Offset: 0x00549196
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
		if (this.TimeHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimeHandle);
			this.TimeHandle = null;
		}
	}

	// Token: 0x0601316E RID: 78190 RVA: 0x0054AFBE File Offset: 0x005491BE
	public override void SetActive(bool visibility)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(visibility);
	}

	// Token: 0x0601316F RID: 78191 RVA: 0x0054AFD4 File Offset: 0x005491D4
	[NullableContext(1)]
	private PayShopGoods ConvertToPayShopGoods(TipsOverPowerData data)
	{
		PayShopGoodsData payShopGoodsData = new PayShopGoodsData();
		payShopGoodsData.PhraseFromTempData(data.ConfigId, 0);
		PayShopGoods payShopGoods = new PayShopGoods(PayShopDefine.EPayShopTabType.None);
		payShopGoods.SetGoodsData(payShopGoodsData);
		return payShopGoods;
	}

	// Token: 0x040094EE RID: 38126
	private const int GAP = 1000;

	// Token: 0x040094EF RID: 38127
	private PayShopItem ShowItem;

	// Token: 0x040094F0 RID: 38128
	private TimerHandle TimeHandle;

	// Token: 0x040094F1 RID: 38129
	private TipsOverPowerData CurrentData;

	// Token: 0x040094F2 RID: 38130
	private PowerData CurrentPowerData;

	// Token: 0x040094F3 RID: 38131
	private ItemConfig CurrentDataItemConfig;

	// Token: 0x040094F4 RID: 38132
	private Action BackBtnCallBack;

	// Token: 0x040094F5 RID: 38133
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008994 RID: 35220
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E6BA RID: 190138
		BgItem,
		// Token: 0x0402E6BB RID: 190139
		TitleText,
		// Token: 0x0402E6BC RID: 190140
		ShopItemPanel,
		// Token: 0x0402E6BD RID: 190141
		DetailText,
		// Token: 0x0402E6BE RID: 190142
		TimeText,
		// Token: 0x0402E6BF RID: 190143
		BackBtn,
		// Token: 0x0402E6C0 RID: 190144
		WindowNameText,
		// Token: 0x0402E6C1 RID: 190145
		PowerDesc,
		// Token: 0x0402E6C2 RID: 190146
		BgDesc
	}
}
