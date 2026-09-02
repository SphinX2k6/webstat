using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001251 RID: 4689
[NullableContext(2)]
[Nullable(0)]
public class RoleSelectItem : GridProxyAbstract<int>
{
	// Token: 0x06007CF4 RID: 31988 RVA: 0x0020E9F4 File Offset: 0x0020CBF4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnPreviewBtnClick)),
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x06007CF5 RID: 31989 RVA: 0x0020EB24 File Offset: 0x0020CD24
	private void OnToggleClick(EToggleState _)
	{
		Action<int, int> toggleCallBack = this.ToggleCallBack;
		if (toggleCallBack == null)
		{
			return;
		}
		toggleCallBack(base.GridIndex, this.RoleId);
	}

	// Token: 0x06007CF6 RID: 31990 RVA: 0x0020EB44 File Offset: 0x0020CD44
	private void OnPreviewBtnClick()
	{
		NewbieCarnivalRole? newbieCarnivalRole = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalRole(this.RoleId);
		List<int> roleIdList = new List<int>
		{
			(newbieCarnivalRole != null) ? newbieCarnivalRole.GetValueOrDefault().TrialRoleId : 0
		};
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, roleIdList, null, null);
	}

	// Token: 0x06007CF7 RID: 31991 RVA: 0x0020EBA0 File Offset: 0x0020CDA0
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

	// Token: 0x06007CF8 RID: 31992 RVA: 0x0020EBF0 File Offset: 0x0020CDF0
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.RoleId = data;
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(this.RoleId == ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData().ChoseRoleId);
		}
		NewbieCarnivalRole value = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalRole(this.RoleId).Value;
		base.SetTextureByPath(value.HeadCard, base.GetTexture(1), null, null);
		RoleInfo value2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), value2.Name, Array.Empty<object>());
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(true);
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

	// Token: 0x06007CF9 RID: 31993 RVA: 0x0020ED5C File Offset: 0x0020CF5C
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06007CFA RID: 31994 RVA: 0x0020ED74 File Offset: 0x0020CF74
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04003BD1 RID: 15313
	private int RoleId;

	// Token: 0x04003BD2 RID: 15314
	private SimpleGenericLayout StarLayout;

	// Token: 0x04003BD3 RID: 15315
	public Action<int, int> ToggleCallBack;

	// Token: 0x04003BD4 RID: 15316
	public Func<int, bool> CanToggleChange;
}
