using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

// Token: 0x02002606 RID: 9734
public class PowerCurrencyItem : CommonCurrencyItem, IWorldMapItemVisibleControlInterface
{
	// Token: 0x170017D7 RID: 6103
	// (get) Token: 0x06013146 RID: 78150 RVA: 0x0054A6D4 File Offset: 0x005488D4
	// (set) Token: 0x06013147 RID: 78151 RVA: 0x0054A6DC File Offset: 0x005488DC
	public EWorldMapShowMode ShowMode { get; set; }

	// Token: 0x06013148 RID: 78152 RVA: 0x0054A6E5 File Offset: 0x005488E5
	protected override void OnStart()
	{
		base.OnStart();
		this.AddOverPowerEventListener();
	}

	// Token: 0x06013149 RID: 78153 RVA: 0x0054A6F3 File Offset: 0x005488F3
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.RemoveOverPowerEventListener();
	}

	// Token: 0x0601314A RID: 78154 RVA: 0x0054A701 File Offset: 0x00548901
	public void AddOverPowerEventListener()
	{
		if (this.OverPowerEventListenerAdded)
		{
			return;
		}
		this.OverPowerEventListenerAdded = true;
		Singleton<EventSystem>.Instance.Add(EEventName.OnPowerChangedWithId, new Action<int>(this.OnPowerChangedWithId));
	}

	// Token: 0x0601314B RID: 78155 RVA: 0x0054A72F File Offset: 0x0054892F
	public void RemoveOverPowerEventListener()
	{
		if (!this.OverPowerEventListenerAdded)
		{
			return;
		}
		this.OverPowerEventListenerAdded = false;
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPowerChangedWithId, new Action<int>(this.OnPowerChangedWithId));
	}

	// Token: 0x0601314C RID: 78156 RVA: 0x0054A75D File Offset: 0x0054895D
	[NullableContext(2)]
	public override void RefreshTemp(int itemId, string countText = null)
	{
		this.ShowWithoutText(itemId);
	}

	// Token: 0x0601314D RID: 78157 RVA: 0x0054A766 File Offset: 0x00548966
	public override void ShowWithoutText(int itemId)
	{
		this.CurrentCurrentId = itemId;
		base.ShowWithoutText(itemId);
		this.OnPowerChangedWithId(itemId);
	}

	// Token: 0x0601314E RID: 78158 RVA: 0x0054A77D File Offset: 0x0054897D
	public override void RefreshAddButtonActive()
	{
		base.SetButtonActive(this.CurrentCurrentId == 5 && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PowerView));
	}

	// Token: 0x0601314F RID: 78159 RVA: 0x0054A7A4 File Offset: 0x005489A4
	private void OnPowerChangedWithId(int itemId)
	{
		if (this.CurrentCurrentId != itemId)
		{
			return;
		}
		PowerData powerDataById = ModelBase<PowerModel>.Instance.GetPowerDataById(itemId);
		int currentPower = powerDataById.GetCurrentPower();
		int powerLimit = powerDataById.GetPowerLimit();
		string powerCurrencyShowTextId = powerDataById.GetPowerCurrencyShowTextId();
		base.SetCountTextNew(powerCurrencyShowTextId, new object[]
		{
			currentPower,
			powerLimit
		});
		bool bActive = powerDataById.IfNeedShowMax() && currentPower >= powerLimit;
		base.RefreshMaxItem(bActive);
	}

	// Token: 0x06013150 RID: 78160 RVA: 0x0054A817 File Offset: 0x00548A17
	public void SetWorldMapSelfShow(EWorldMapShowMode showMode)
	{
		this.ShowMode = showMode;
	}

	// Token: 0x06013151 RID: 78161 RVA: 0x0054A820 File Offset: 0x00548A20
	public void RefreshWorldMapSelfShow(EWorldMapShowMode showMode)
	{
		base.SetUiActive(showMode == EWorldMapShowMode.Default);
	}

	// Token: 0x040094E9 RID: 38121
	private int CurrentCurrentId;

	// Token: 0x040094EA RID: 38122
	private bool OverPowerEventListenerAdded;
}
