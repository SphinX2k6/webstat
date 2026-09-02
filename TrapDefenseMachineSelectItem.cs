using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D90 RID: 7568
[NullableContext(2)]
[Nullable(0)]
public class TrapDefenseMachineSelectItem : UiPanelBase
{
	// Token: 0x0600DF07 RID: 57095 RVA: 0x003C0174 File Offset: 0x003BE374
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnMachineToggleClicked))
		};
	}

	// Token: 0x0600DF08 RID: 57096 RVA: 0x003C0278 File Offset: 0x003BE478
	protected override void OnStart()
	{
		this.CdText = base.GetText(6);
		this.CdSprite = base.GetSprite(7);
		this.CdActiveState = false;
		this.Toggle = base.GetExtendToggle(0);
		this.Toggle.CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x0600DF09 RID: 57097 RVA: 0x003C02CF File Offset: 0x003BE4CF
	private bool OnCanExecuteChange()
	{
		return this.Toggle.GetToggleState() != EToggleState.ETT_Checked;
	}

	// Token: 0x0600DF0A RID: 57098 RVA: 0x003C02E2 File Offset: 0x003BE4E2
	private void OnMachineToggleClicked(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ToggleClick(this);
		}
	}

	// Token: 0x0600DF0B RID: 57099 RVA: 0x003C02F4 File Offset: 0x003BE4F4
	private void SetCdState(bool state)
	{
		if (this.CdActiveState == state)
		{
			return;
		}
		this.CdActiveState = state;
		base.GetItem(5).SetUIActive(state);
	}

	// Token: 0x0600DF0C RID: 57100 RVA: 0x003C0314 File Offset: 0x003BE514
	private void RefreshCdText()
	{
		string newText = (this.CdTime / (float)Singleton<TimeUtil>.Instance.InverseMillisecond).ToString("F1");
		UUIText cdText = this.CdText;
		if (cdText == null)
		{
			return;
		}
		cdText.SetText(newText, true);
	}

	// Token: 0x0600DF0D RID: 57101 RVA: 0x003C0353 File Offset: 0x003BE553
	private void RefreshCdSprite()
	{
		if (this.Data != null)
		{
			UUISprite cdSprite = this.CdSprite;
			if (cdSprite == null)
			{
				return;
			}
			cdSprite.SetFillAmount(this.CdTime / this.Data.GetCoolDown());
		}
	}

	// Token: 0x0600DF0E RID: 57102 RVA: 0x003C037F File Offset: 0x003BE57F
	public void Refresh(TrapDefenseBuildingDevelopItemData data)
	{
		this.Data = data;
		this.RefreshSelf();
	}

	// Token: 0x0600DF0F RID: 57103 RVA: 0x003C0390 File Offset: 0x003BE590
	public void RefreshSelf()
	{
		bool isCanBuildMachine = ModelBase<TrapDefenseModel>.Instance.BattleData.IsCanBuildMachine;
		UUIItem item = base.GetItem(3);
		UUITexture texture = base.GetTexture(1);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		item.SetUIActive(this.Data == null);
		texture.SetUIActive(this.Data != null);
		extendToggle.SetSelfInteractive(this.Data != null || isCanBuildMachine);
		this.RefreshCd();
		this.RefreshCoin();
		if (this.Data != null)
		{
			string iconPath = this.Data.GetIconPath();
			if (iconPath != null)
			{
				base.SetTextureAsync(iconPath, texture);
			}
		}
	}

	// Token: 0x0600DF10 RID: 57104 RVA: 0x003C0420 File Offset: 0x003BE620
	public void RefreshCoin()
	{
		UUIItem item = base.GetItem(8);
		if (this.Data != null && this.Data.IsBuilding)
		{
			long goldNum = ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum();
			item.SetUIActive(true);
			UUIText text = base.GetText(2);
			text.SetText(this.Data.GetBuildingCost(true).ToString(), true);
			UUIItem uuiitem = text;
			bool bUseChangeColor = goldNum < (long)this.Data.GetBuildingCost(true);
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600DF11 RID: 57105 RVA: 0x003C04B4 File Offset: 0x003BE6B4
	public void RefreshCd()
	{
		if (this.Data != null && this.Data.GetRemainCd() > 0f)
		{
			this.CdTime = this.Data.GetRemainCd() * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.SetCdState(this.CdTime > 0f);
			this.RefreshCdText();
			this.RefreshCdSprite();
			return;
		}
		this.CdTime = 0f;
		this.SetCdState(false);
	}

	// Token: 0x0600DF12 RID: 57106 RVA: 0x003C052A File Offset: 0x003BE72A
	public void SetToggleState(EToggleState state, bool bFire = false)
	{
		base.GetExtendToggle(0).SetToggleStateForce(state, bFire, false, false);
	}

	// Token: 0x0600DF13 RID: 57107 RVA: 0x003C053C File Offset: 0x003BE73C
	public void Tick(float delta)
	{
		if (this.Data == null || this.Data.IsBuilding)
		{
			return;
		}
		if (this.CdTime <= 0f)
		{
			return;
		}
		this.CdTime -= delta * Singleton<Time>.Instance.TimeDilation;
		this.SetCdState(this.CdTime > 0f);
		this.RefreshCdText();
		this.RefreshCdSprite();
	}

	// Token: 0x04006B3C RID: 27452
	[Nullable(1)]
	protected UUIExtendToggle Toggle;

	// Token: 0x04006B3D RID: 27453
	[Nullable(1)]
	public Action<TrapDefenseMachineSelectItem> ToggleClick;

	// Token: 0x04006B3E RID: 27454
	public TrapDefenseBuildingDevelopItemData Data;

	// Token: 0x04006B3F RID: 27455
	public int Index;

	// Token: 0x04006B40 RID: 27456
	protected UUIText CdText;

	// Token: 0x04006B41 RID: 27457
	protected UUISprite CdSprite;

	// Token: 0x04006B42 RID: 27458
	protected float CdTime;

	// Token: 0x04006B43 RID: 27459
	protected bool CdActiveState;

	// Token: 0x02008124 RID: 33060
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BE71 RID: 179825
		public const int WeaponToggle = 0;

		// Token: 0x0402BE72 RID: 179826
		public const int MachineIcon = 1;

		// Token: 0x0402BE73 RID: 179827
		public const int MachineNum = 2;

		// Token: 0x0402BE74 RID: 179828
		public const int EmptyItem = 3;

		// Token: 0x0402BE75 RID: 179829
		public const int MachineItem = 4;

		// Token: 0x0402BE76 RID: 179830
		public const int CdItem = 5;

		// Token: 0x0402BE77 RID: 179831
		public const int CdText = 6;

		// Token: 0x0402BE78 RID: 179832
		public const int CdSprite = 7;

		// Token: 0x0402BE79 RID: 179833
		public const int MachineMoneyItem = 8;
	}
}
