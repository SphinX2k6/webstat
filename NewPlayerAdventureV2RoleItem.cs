using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001481 RID: 5249
internal class NewPlayerAdventureV2RoleItem : GridProxyAbstract<int>
{
	// Token: 0x060092EC RID: 37612 RVA: 0x0026C0B0 File Offset: 0x0026A2B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x060092ED RID: 37613 RVA: 0x0026C118 File Offset: 0x0026A318
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(data);
		if (roleConfig == null)
		{
			return;
		}
		this.RoleId = data;
		base.SetTextureShowUntilLoaded(roleConfig.Value.RoleHeadIcon, base.GetTexture(1), null);
	}

	// Token: 0x060092EE RID: 37614 RVA: 0x0026C15F File Offset: 0x0026A35F
	public void SelectToggle()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x060092EF RID: 37615 RVA: 0x0026C172 File Offset: 0x0026A372
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<int, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(this.RoleId, base.GetExtendToggle(0));
	}

	// Token: 0x04004404 RID: 17412
	private int RoleId;

	// Token: 0x04004405 RID: 17413
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIExtendToggle> OnClickToggleCallBack;
}
