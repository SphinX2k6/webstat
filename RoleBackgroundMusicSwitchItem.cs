using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020027A3 RID: 10147
public class RoleBackgroundMusicSwitchItem : UiPanelBase
{
	// Token: 0x0601408B RID: 82059 RVA: 0x00597BBC File Offset: 0x00595DBC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601408C RID: 82060 RVA: 0x00597C48 File Offset: 0x00595E48
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.SetSelfInteractive(false);
		extendToggle.SetCanClickWhenDisable(true);
		extendToggle.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnPointUpCallBackInternal));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnRoleBackgroundMusicEnabledChanged, new Action<int, bool>(this.OnRoleBackgroundMusicEnabledChanged));
	}

	// Token: 0x0601408D RID: 82061 RVA: 0x00597C9C File Offset: 0x00595E9C
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.OnRoleBackgroundMusicEnabledChanged, new Action<int, bool>(this.OnRoleBackgroundMusicEnabledChanged));
	}

	// Token: 0x0601408E RID: 82062 RVA: 0x00597CBA File Offset: 0x00595EBA
	[NullableContext(1)]
	public void RefreshByRoleData(RoleDataBase roleData)
	{
		this.RoleData = roleData;
		this.Refresh();
	}

	// Token: 0x0601408F RID: 82063 RVA: 0x00597CCC File Offset: 0x00595ECC
	public void Refresh()
	{
		if (this.RoleData == null)
		{
			return;
		}
		base.SetRoleIcon("", base.GetTexture(2), this.RoleData.GetRoleId(), null, null);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		EToggleState state = this.RoleData.GetBackgroundMusicEnabled() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x06014090 RID: 82064 RVA: 0x00597D2C File Offset: 0x00595F2C
	private void OnPointUpCallBackInternal(EToggleState state)
	{
		if (this.RoleData == null || this.RoleData.IsTrialRole())
		{
			return;
		}
		if (state == EToggleState.ETT_Checked)
		{
			ControllerBase<RoleController>.Instance.RoleOperateSelfBgmRequest(this.RoleData.GetDataId(), false, null);
			return;
		}
		if (state == EToggleState.ETT_UnChecked)
		{
			ControllerBase<RoleController>.Instance.RoleOperateSelfBgmRequest(this.RoleData.GetDataId(), true, null);
		}
	}

	// Token: 0x06014091 RID: 82065 RVA: 0x00597D85 File Offset: 0x00595F85
	private void OnRoleBackgroundMusicEnabledChanged(int roleDataId, bool _)
	{
		if (this.RoleData == null || this.RoleData.GetDataId() != roleDataId)
		{
			return;
		}
		this.Refresh();
	}

	// Token: 0x04009C24 RID: 39972
	[Nullable(2)]
	public RoleDataBase RoleData;

	// Token: 0x02008B5C RID: 35676
	private enum EComponentDefine
	{
		// Token: 0x0402EFAE RID: 192430
		SwitchToggle,
		// Token: 0x0402EFAF RID: 192431
		DescText,
		// Token: 0x0402EFB0 RID: 192432
		RoleIconTexture
	}
}
