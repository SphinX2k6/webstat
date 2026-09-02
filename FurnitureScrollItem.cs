using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010A2 RID: 4258
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FurnitureScrollItem : GridProxyAbstract<FurnitureScrollItemData>
{
	// Token: 0x06006EFC RID: 28412 RVA: 0x001CDF0C File Offset: 0x001CC10C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange))
		};
	}

	// Token: 0x06006EFD RID: 28413 RVA: 0x001CE06C File Offset: 0x001CC26C
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChangeInternal));
		extendToggle.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnPointUpCallBackInternal));
		extendToggle.OnPointEnterCallBack.Bind(new Action<EToggleState>(this.OnPointerEnterInternal));
	}

	// Token: 0x06006EFE RID: 28414 RVA: 0x001CE0C4 File Offset: 0x001CC2C4
	[NullableContext(1)]
	public override void Refresh(FurnitureScrollItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshItemToggle(true);
		this.RefreshCheckItem();
		this.RefreshFurnitureIcon();
		this.RefreshCount();
		this.RefreshAtmosphere();
		this.RefreshLock();
		this.RefreshBan();
		this.RefreshRoleIcon();
		this.RefreshRedDot();
		this.RefreshQuality();
	}

	// Token: 0x06006EFF RID: 28415 RVA: 0x001CE118 File Offset: 0x001CC318
	public void RefreshItemToggle(bool bToEndFrame = false)
	{
		FurnitureScrollItemData data = this.Data;
		EToggleState state = (data != null && data.IsSelected) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleStateForce(state, false, false, bToEndFrame);
	}

	// Token: 0x06006F00 RID: 28416 RVA: 0x001CE150 File Offset: 0x001CC350
	public void RefreshCheckItem()
	{
		FurnitureScrollItemData data = this.Data;
		bool uiactive = data != null && data.IsCheck;
		base.GetItem(4).SetUIActive(uiactive);
	}

	// Token: 0x06006F01 RID: 28417 RVA: 0x001CE180 File Offset: 0x001CC380
	public void RefreshFurnitureIcon()
	{
		FurnitureScrollItemData data = this.Data;
		Furniture? furniture = (data != null) ? new Furniture?(data.FurnitureConfig) : null;
		base.SetTextureByPath(((furniture != null) ? furniture.GetValueOrDefault().Icon : null) ?? "", base.GetTexture(2), null, null);
	}

	// Token: 0x06006F02 RID: 28418 RVA: 0x001CE1E8 File Offset: 0x001CC3E8
	public void RefreshCount()
	{
		FurnitureScrollItemData data = this.Data;
		bool flag = data != null && data.IsLock;
		FurnitureScrollItemData data2 = this.Data;
		int value = (data2 != null) ? data2.LeftCount : 0;
		FurnitureScrollItemData data3 = this.Data;
		int num = (data3 != null) ? data3.FurnitureConfig.LimitCount : 0;
		base.GetItem(6).SetUIActive(!flag && num > 0);
		if (!flag)
		{
			UUIText text = base.GetText(7);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
	}

	// Token: 0x06006F03 RID: 28419 RVA: 0x001CE288 File Offset: 0x001CC488
	public void RefreshBan()
	{
		FurnitureScrollItemData data = this.Data;
		int num = (data != null) ? data.FurnitureConfig.LimitCount : 0;
		FurnitureScrollItemData data2 = this.Data;
		int num2 = (data2 != null) ? data2.LeftCount : 0;
		FurnitureScrollItemData data3 = this.Data;
		bool flag = data3 != null && data3.IsLock;
		FurnitureScrollItemData data4 = this.Data;
		bool flag2 = data4 != null && data4.IsSelected;
		base.GetItem(3).SetUIActive(!flag && !flag2 && num > 0 && num2 <= 0);
	}

	// Token: 0x06006F04 RID: 28420 RVA: 0x001CE30C File Offset: 0x001CC50C
	public void RefreshRoleIcon()
	{
		FurnitureScrollItemData data = this.Data;
		Furniture? furniture = (data != null) ? new Furniture?(data.FurnitureConfig) : null;
		bool flag = furniture != null && furniture.GetValueOrDefault().SourceType == 2;
		base.GetItem(12).SetUIActive(flag);
		if (flag)
		{
			base.SetTextureShowUntilLoaded(((furniture != null) ? furniture.GetValueOrDefault().RoleIconPath : null) ?? "", base.GetTexture(5), null);
		}
	}

	// Token: 0x06006F05 RID: 28421 RVA: 0x001CE39C File Offset: 0x001CC59C
	public void RefreshAtmosphere()
	{
		FurnitureScrollItemData data = this.Data;
		Furniture? furniture = (data != null) ? new Furniture?(data.FurnitureConfig) : null;
		base.GetText(9).SetText(((furniture != null) ? furniture.GetValueOrDefault().Atmosphere.ToString() : null) ?? "", true);
	}

	// Token: 0x06006F06 RID: 28422 RVA: 0x001CE403 File Offset: 0x001CC603
	public void RefreshLock()
	{
		UUIItem item = base.GetItem(10);
		FurnitureScrollItemData data = this.Data;
		item.SetUIActive(data != null && data.IsLock);
	}

	// Token: 0x06006F07 RID: 28423 RVA: 0x001CE424 File Offset: 0x001CC624
	public void RefreshRedDot()
	{
		UUIItem item = base.GetItem(11);
		FurnitureScrollItemData data = this.Data;
		item.SetUIActive(data != null && data.RedDotShowState);
	}

	// Token: 0x06006F08 RID: 28424 RVA: 0x001CE448 File Offset: 0x001CC648
	public void RefreshQuality()
	{
		FurnitureScrollItemData data = this.Data;
		int qualityId = (data != null) ? data.FurnitureConfig.QualityId : 0;
		FurnitureQualityConfig? furnitureQualityConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureQualityConfig(qualityId);
		FColor color = FColor.FromHex(((furnitureQualityConfig != null) ? furnitureQualityConfig.GetValueOrDefault().ScrollItemColor : null) ?? "");
		base.GetSprite(1).SetColor(color);
	}

	// Token: 0x06006F09 RID: 28425 RVA: 0x001CE4B4 File Offset: 0x001CC6B4
	private void OnToggleStateChange(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> onItemSelectedDelegate = this.OnItemSelectedDelegate;
			if (onItemSelectedDelegate == null)
			{
				return;
			}
			onItemSelectedDelegate(base.GridIndex);
			return;
		}
		else
		{
			Action<int> onItemUnSelectedDelegate = this.OnItemUnSelectedDelegate;
			if (onItemUnSelectedDelegate == null)
			{
				return;
			}
			onItemUnSelectedDelegate(base.GridIndex);
			return;
		}
	}

	// Token: 0x06006F0A RID: 28426 RVA: 0x001CE4E7 File Offset: 0x001CC6E7
	private bool CanExecuteChangeInternal()
	{
		return this.CanToggleChangedDelegate == null || this.CanToggleChangedDelegate(base.GridIndex);
	}

	// Token: 0x06006F0B RID: 28427 RVA: 0x001CE504 File Offset: 0x001CC704
	private void OnPointUpCallBackInternal(EToggleState _)
	{
		Action<int> onPointUpCallBackDelegate = this.OnPointUpCallBackDelegate;
		if (onPointUpCallBackDelegate == null)
		{
			return;
		}
		onPointUpCallBackDelegate(base.GridIndex);
	}

	// Token: 0x06006F0C RID: 28428 RVA: 0x001CE51C File Offset: 0x001CC71C
	private void OnPointerEnterInternal(EToggleState _)
	{
		Action<int> onPointerEnterDelegate = this.OnPointerEnterDelegate;
		if (onPointerEnterDelegate == null)
		{
			return;
		}
		onPointerEnterDelegate(base.GridIndex);
	}

	// Token: 0x04003512 RID: 13586
	private FurnitureScrollItemData Data;

	// Token: 0x04003513 RID: 13587
	public Action<int> OnItemSelectedDelegate;

	// Token: 0x04003514 RID: 13588
	public Action<int> OnItemUnSelectedDelegate;

	// Token: 0x04003515 RID: 13589
	public Func<int, bool> CanToggleChangedDelegate;

	// Token: 0x04003516 RID: 13590
	public Action<int> OnPointUpCallBackDelegate;

	// Token: 0x04003517 RID: 13591
	public Action<int> OnPointerEnterDelegate;
}
