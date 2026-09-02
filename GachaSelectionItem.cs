using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CEE RID: 7406
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GachaSelectionItem : GridProxyAbstract<GachaPoolData>
{
	// Token: 0x0600D95F RID: 55647 RVA: 0x003A47BC File Offset: 0x003A29BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnPreviewBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D960 RID: 55648 RVA: 0x003A498F File Offset: 0x003A2B8F
	private void OnToggleClick(EToggleState toggleState)
	{
		Action<int> toggleCallBack = this.ToggleCallBack;
		if (toggleCallBack == null)
		{
			return;
		}
		toggleCallBack(base.GridIndex);
	}

	// Token: 0x0600D961 RID: 55649 RVA: 0x003A49A8 File Offset: 0x003A2BA8
	private void OnPreviewBtnClick()
	{
		int itemId = this.PoolConfig.Value.ShowIdList()[0];
		GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(itemId);
		if (this.IsRole)
		{
			List<int> roleIdList = new List<int>
			{
				gachaTextureInfo.Value.TrialId
			};
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, roleIdList, null, null);
			return;
		}
		WeaponTrialData weaponTrialData = new WeaponTrialData();
		weaponTrialData.SetTrialId(gachaTextureInfo.Value.TrialId, true);
		WeaponPreviewViewParam weaponPreviewViewParam = new WeaponPreviewViewParam();
		WeaponPreviewViewParam weaponPreviewViewParam2 = weaponPreviewViewParam;
		WeaponDataBase[] weaponDataList = new WeaponTrialData[]
		{
			weaponTrialData
		};
		weaponPreviewViewParam2.WeaponDataList = weaponDataList;
		weaponPreviewViewParam.SelectedIndex = 0;
		WeaponPreviewViewParam param = weaponPreviewViewParam;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
	}

	// Token: 0x0600D962 RID: 55650 RVA: 0x003A4A6E File Offset: 0x003A2C6E
	protected override void OnStart()
	{
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(4));
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(() => this.CanToggleChange == null || this.CanToggleChange(base.GridIndex));
	}

	// Token: 0x0600D963 RID: 55651 RVA: 0x003A4AA4 File Offset: 0x003A2CA4
	[NullableContext(1)]
	public override void Refresh(GachaPoolData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		ProtoGachaInfo gachaInfo = data.GachaInfo;
		int id = data.PoolInfo.Id;
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(gachaInfo.UsePoolId == id);
		}
		GachaViewInfo value = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(id).Value;
		this.PoolConfig = new GachaViewInfo?(value);
		int type = value.Type;
		this.IsRole = ModelBase<GachaModel>.Instance.IsRolePool((GachaDefine.EGachaViewType)type);
		int itemId = value.ShowIdList()[0];
		base.SetTextureByPath(ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(itemId).Value.GachaResultViewTexture, base.GetTexture(1), null, null);
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetText(data.GachaInfo.GetPoolInfo(id).Title, true);
		}
		this.RefreshLeftTime(0f);
		if (this.IsRole)
		{
			this.HandleRole();
		}
		else
		{
			this.HandleWeapon();
		}
		if (isSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		else
		{
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
	}

	// Token: 0x0600D964 RID: 55652 RVA: 0x003A4BD7 File Offset: 0x003A2DD7
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600D965 RID: 55653 RVA: 0x003A4BEF File Offset: 0x003A2DEF
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600D966 RID: 55654 RVA: 0x003A4C08 File Offset: 0x003A2E08
	private void HandleRole()
	{
		int itemId = this.PoolConfig.Value.ShowIdList()[0];
		RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(itemId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), roleInfoById.Value.Name, Array.Empty<object>());
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		string gachaElementTexturePath = ConfigBase<GachaConfig>.Instance.GetGachaElementTexturePath(roleInfoById.Value.ElementId);
		base.SetElementIcon(gachaElementTexturePath, base.GetTexture(3), roleInfoById.Value.ElementId, null);
		int qualityId = roleInfoById.Value.QualityId;
		SimpleGenericLayout starLayout = this.StarLayout;
		if (starLayout == null)
		{
			return;
		}
		starLayout.RebuildLayout(qualityId);
	}

	// Token: 0x0600D967 RID: 55655 RVA: 0x003A4CD8 File Offset: 0x003A2ED8
	private void HandleWeapon()
	{
		GachaViewInfo value = this.PoolConfig.Value;
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		int configId = value.ShowIdList()[0];
		WeaponConf? weaponItemConfig = ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(configId);
		if (weaponItemConfig == null)
		{
			return;
		}
		GachaWeaponTransform? gachaWeaponTransformConfig = ConfigBase<GachaConfig>.Instance.GetGachaWeaponTransformConfig(weaponItemConfig.Value.WeaponType);
		FVector uiitemScale = new FVector(0.6f, 0.6f, 0.6f);
		base.GetTexture(3).SetUIItemScale(uiitemScale);
		base.SetTextureByPath(gachaWeaponTransformConfig.Value.WeaponTypeTexture, base.GetTexture(3), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), weaponItemConfig.Value.WeaponName, Array.Empty<object>());
		int qualityId = weaponItemConfig.Value.QualityId;
		SimpleGenericLayout starLayout = this.StarLayout;
		if (starLayout == null)
		{
			return;
		}
		starLayout.RebuildLayout(qualityId);
	}

	// Token: 0x0600D968 RID: 55656 RVA: 0x003A4DD8 File Offset: 0x003A2FD8
	public void RefreshLeftTime(float delta)
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		UUIText text = base.GetText(6);
		ProtoGachaInfo gachaInfo = this.Data.GachaInfo;
		int id = this.Data.PoolInfo.Id;
		double poolEndTimeByPoolId = gachaInfo.GetPoolEndTimeByPoolId(id);
		if (poolEndTimeByPoolId == 0.0)
		{
			text.SetUIActive(false);
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = poolEndTimeByPoolId - serverTime;
		if (num <= 0.0)
		{
			text.SetUIActive(false);
			return;
		}
		text.SetUIActive(true);
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(num);
		text.SetText(remainTimeDataFormat.CountDownText, true);
		double remainingTime = remainTimeDataFormat.RemainingTime;
		if (remainingTime > 0.0)
		{
			double num2 = remainingTime;
			this.TimerHandle = TimerSystem.RealTimeInstance.Delay(new TTimerAction(this.RefreshLeftTime), (float)(num2 * 1000.0), null, null, false, 1f);
		}
	}

	// Token: 0x0600D969 RID: 55657 RVA: 0x003A4ED7 File Offset: 0x003A30D7
	protected override void OnBeforeDestroy()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x040067C4 RID: 26564
	private SimpleGenericLayout StarLayout;

	// Token: 0x040067C5 RID: 26565
	private GachaPoolData Data;

	// Token: 0x040067C6 RID: 26566
	private TimerHandle TimerHandle;

	// Token: 0x040067C7 RID: 26567
	private GachaViewInfo? PoolConfig;

	// Token: 0x040067C8 RID: 26568
	private bool IsRole;

	// Token: 0x040067C9 RID: 26569
	public Action<int> ToggleCallBack;

	// Token: 0x040067CA RID: 26570
	public Func<int, bool> CanToggleChange;

	// Token: 0x02008056 RID: 32854
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402BA83 RID: 178819
		Toggle,
		// Token: 0x0402BA84 RID: 178820
		MainTexture,
		// Token: 0x0402BA85 RID: 178821
		ElementItem,
		// Token: 0x0402BA86 RID: 178822
		ElementTexture,
		// Token: 0x0402BA87 RID: 178823
		StarLayout,
		// Token: 0x0402BA88 RID: 178824
		PoolTitleText,
		// Token: 0x0402BA89 RID: 178825
		LeftTimeText,
		// Token: 0x0402BA8A RID: 178826
		CardNameText,
		// Token: 0x0402BA8B RID: 178827
		PreviewBtn,
		// Token: 0x0402BA8C RID: 178828
		CurrentItem
	}
}
