using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200167D RID: 5757
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerTeamInfoPanel : UiPanelBase
{
	// Token: 0x17000D84 RID: 3460
	// (get) Token: 0x0600A0DC RID: 41180 RVA: 0x002A2BE6 File Offset: 0x002A0DE6
	// (set) Token: 0x0600A0DD RID: 41181 RVA: 0x002A2BEE File Offset: 0x002A0DEE
	public Action ClickCallback { get; set; }

	// Token: 0x0600A0DE RID: 41182 RVA: 0x002A2BF8 File Offset: 0x002A0DF8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnRecommendBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A0DF RID: 41183 RVA: 0x002A2DAC File Offset: 0x002A0FAC
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerTeamInfoPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerTeamInfoPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A0E0 RID: 41184 RVA: 0x002A2DF0 File Offset: 0x002A0FF0
	[NullableContext(1)]
	public void RefreshRoleList(List<RoleDataWithBranch> roleDataList)
	{
		GenericLayout<WheelTowerRoleItem, RoleDataWithBranch> roleIconLayout = this.RoleIconLayout;
		if (roleIconLayout != null)
		{
			roleIconLayout.RefreshByData(roleDataList, null, false);
		}
		List<IConflictInfo> list = ModelBase<WheelTowerModel>.Instance.CheckCurrentSelectConflict();
		bool uiactive = false;
		foreach (IConflictInfo conflictInfo in list)
		{
			if (ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo.GetRoleEnergy(conflictInfo.RoleId) > 0)
			{
				uiactive = true;
				break;
			}
		}
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600A0E1 RID: 41185 RVA: 0x002A2E84 File Offset: 0x002A1084
	public void RefreshBuff(int buffId)
	{
		WheelTowerSmallBuffItem buffItem = this.BuffItem;
		if (buffItem == null)
		{
			return;
		}
		buffItem.Refresh(buffId);
	}

	// Token: 0x0600A0E2 RID: 41186 RVA: 0x002A2E98 File Offset: 0x002A1098
	protected override void OnBeforeShow()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		int num = ModelBase<WheelTowerModel>.Instance.SelectedRound + 1;
		string text;
		if (num / 10 <= 0)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			text = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			text = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		string newText = text;
		UUIText text2 = base.GetText(3);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(newText, true);
	}

	// Token: 0x0600A0E3 RID: 41187 RVA: 0x002A2F1E File Offset: 0x002A111E
	private void OnClick()
	{
		Action clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback();
	}

	// Token: 0x0600A0E4 RID: 41188 RVA: 0x002A2F30 File Offset: 0x002A1130
	private void OnRecommendBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerRecommendView, null, null);
	}

	// Token: 0x04004AAD RID: 19117
	private WheelTowerSmallBuffItem BuffItem;

	// Token: 0x04004AAE RID: 19118
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerRoleItem, RoleDataWithBranch> RoleIconLayout;
}
