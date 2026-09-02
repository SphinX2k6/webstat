using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028E9 RID: 10473
public class RoleResonanceTabViewNew : UiTabViewBase
{
	// Token: 0x06014CCD RID: 85197 RVA: 0x005C2EA4 File Offset: 0x005C10A4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014CCE RID: 85198 RVA: 0x005C2F0D File Offset: 0x005C110D
	protected void UnBindRedDot()
	{
		if (this.RoleInstance.IsTrialRole())
		{
			return;
		}
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RoleResonanceTabHole);
	}

	// Token: 0x06014CCF RID: 85199 RVA: 0x005C2F29 File Offset: 0x005C1129
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.ChangeRoleEvent));
	}

	// Token: 0x06014CD0 RID: 85200 RVA: 0x005C2F48 File Offset: 0x005C1148
	protected override void OnStart()
	{
		this.RoleViewAgent = (this.OpenParam as RoleViewAgent);
		if (this.RoleViewAgent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RoleViewAgent为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("界面名称", "RoleResonanceTabViewNew");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.RoleInstance = this.RoleViewAgent.GetCurSelectRoleData();
		this.PlayMontageStart();
	}

	// Token: 0x06014CD1 RID: 85201 RVA: 0x005C2FB1 File Offset: 0x005C11B1
	protected void PlayMontageStart()
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Resonance, false, false, false);
	}

	// Token: 0x06014CD2 RID: 85202 RVA: 0x005C2FC1 File Offset: 0x005C11C1
	protected override void OnBeforeShow()
	{
		this.UpdateView();
	}

	// Token: 0x06014CD3 RID: 85203 RVA: 0x005C2FCC File Offset: 0x005C11CC
	private void UpdateView()
	{
		RoleInfo roleConfig = this.RoleInstance.GetRoleConfig();
		UUIText text = base.GetText(0);
		List<ResonantChain> roleResonanceList = ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceList(roleConfig.ResonantChainGroupId);
		UUIText uuitext = text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.RoleInstance.GetResonanceData().GetResonantChainGroupIndex());
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(roleResonanceList.Count);
		uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetItem(1).SetUIActive(!this.RoleInstance.IsTrialRole());
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.RoleHandBookRootView))
		{
			(text.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(false);
		}
	}

	// Token: 0x06014CD4 RID: 85204 RVA: 0x005C3091 File Offset: 0x005C1291
	private void ChangeRoleEvent(int roleId)
	{
		this.RoleInstance = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		this.PlayMontageStart();
		this.UpdateView();
	}

	// Token: 0x06014CD5 RID: 85205 RVA: 0x005C30B1 File Offset: 0x005C12B1
	protected override void OnBeforeHide()
	{
		this.UnBindRedDot();
	}

	// Token: 0x06014CD6 RID: 85206 RVA: 0x005C30B9 File Offset: 0x005C12B9
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleSystemChangeRole, new Action<int>(this.ChangeRoleEvent));
	}

	// Token: 0x0400A020 RID: 40992
	[Nullable(2)]
	private RoleViewAgent RoleViewAgent;

	// Token: 0x0400A021 RID: 40993
	[Nullable(2)]
	private RoleDataBase RoleInstance;

	// Token: 0x02008C3C RID: 35900
	private enum ERoleResonanceTabViewDefine
	{
		// Token: 0x0402F3CA RID: 193482
		UnlockText,
		// Token: 0x0402F3CB RID: 193483
		UnLockRootItem
	}
}
