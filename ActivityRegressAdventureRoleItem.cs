using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020014EB RID: 5355
internal class ActivityRegressAdventureRoleItem : GridProxyAbstract<int>
{
	// Token: 0x060095E1 RID: 38369 RVA: 0x0027174C File Offset: 0x0026F94C
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

	// Token: 0x060095E2 RID: 38370 RVA: 0x002717B4 File Offset: 0x0026F9B4
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

	// Token: 0x060095E3 RID: 38371 RVA: 0x002717FB File Offset: 0x0026F9FB
	public void SelectToggle()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x060095E4 RID: 38372 RVA: 0x0027180E File Offset: 0x0026FA0E
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<int, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(this.RoleId, base.GetExtendToggle(0));
	}

	// Token: 0x0400455C RID: 17756
	private int RoleId;

	// Token: 0x0400455D RID: 17757
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIExtendToggle> OnClickToggleCallBack;
}
