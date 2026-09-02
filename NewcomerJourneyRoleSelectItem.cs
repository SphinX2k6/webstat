using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001457 RID: 5207
[NullableContext(2)]
[Nullable(0)]
public class NewcomerJourneyRoleSelectItem : GridProxyAbstract<int>
{
	// Token: 0x06009133 RID: 37171 RVA: 0x00263A7C File Offset: 0x00261C7C
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

	// Token: 0x06009134 RID: 37172 RVA: 0x00263C4F File Offset: 0x00261E4F
	private void OnToggleClick(EToggleState state)
	{
		Action<int, int> toggleCallBack = this.ToggleCallBack;
		if (toggleCallBack == null)
		{
			return;
		}
		toggleCallBack(base.GridIndex, this.RoleId);
	}

	// Token: 0x06009135 RID: 37173 RVA: 0x00263C70 File Offset: 0x00261E70
	private void OnPreviewBtnClick()
	{
		List<int> previewCharacterList = ControllerBase<ActivityNewcomerJourneyController>.Instance.GetNewcomerJourneyData().GetPreviewCharacterList();
		AdventureRole? roleById = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetRoleById(this.RoleId);
		int selectRoleId = (roleById != null) ? roleById.GetValueOrDefault().TrialRoleId : 0;
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, selectRoleId, previewCharacterList, null, null);
		Action openCallBack = this.OpenCallBack;
		if (openCallBack == null)
		{
			return;
		}
		openCallBack();
	}

	// Token: 0x06009136 RID: 37174 RVA: 0x00263CE4 File Offset: 0x00261EE4
	protected override void OnStart()
	{
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(4));
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Bind(() => this.CanToggleChange == null || this.CanToggleChange(base.GridIndex));
		}
		base.GetText(6).SetUIActive(false);
	}

	// Token: 0x06009137 RID: 37175 RVA: 0x00263D34 File Offset: 0x00261F34
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.RoleId = data;
		AdventureRole value = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetRoleById(this.RoleId).Value;
		base.SetTextureByPath(value.HeadCard, base.GetTexture(1), null, null);
		RoleInfo value2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), value2.Name, Array.Empty<object>());
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		string icon = ConfigBase<CommonConfig>.Instance.GetElementConfig(value2.ElementId).Value.Icon5;
		base.SetElementIcon(icon, base.GetTexture(3), value2.ElementId, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), value.DesText, Array.Empty<object>());
		int qualityId = value2.QualityId;
		SimpleGenericLayout starLayout = this.StarLayout;
		if (starLayout != null)
		{
			starLayout.RebuildLayout(qualityId);
		}
		UUIItem item2 = base.GetItem(9);
		if (item2 != null)
		{
			item2.SetUIActive(isSelected);
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

	// Token: 0x06009138 RID: 37176 RVA: 0x00263E8A File Offset: 0x0026208A
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(true);
	}

	// Token: 0x06009139 RID: 37177 RVA: 0x00263EB6 File Offset: 0x002620B6
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x04004352 RID: 17234
	private int RoleId;

	// Token: 0x04004353 RID: 17235
	private SimpleGenericLayout StarLayout;

	// Token: 0x04004354 RID: 17236
	public Action OpenCallBack;

	// Token: 0x04004355 RID: 17237
	public Action<int, int> ToggleCallBack;

	// Token: 0x04004356 RID: 17238
	public Func<int, bool> CanToggleChange;
}
