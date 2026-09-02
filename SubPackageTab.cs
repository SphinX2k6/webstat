using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002ABA RID: 10938
internal class SubPackageTab : GridProxyAbstract<int>
{
	// Token: 0x06015E29 RID: 89641 RVA: 0x006141EC File Offset: 0x006123EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x06015E2A RID: 89642 RVA: 0x00614254 File Offset: 0x00612454
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		if (data == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SubPackageDownLoad_Key_Tab", Array.Empty<object>());
		}
		if (data == 1)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SubPackageDownLoad_Expend_Tab", Array.Empty<object>());
		}
		this.CurrentType = data;
	}

	// Token: 0x06015E2B RID: 89643 RVA: 0x006142A5 File Offset: 0x006124A5
	private void OnToggleClick(EToggleState state)
	{
		Action<UUIExtendToggle, int> onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack == null)
		{
			return;
		}
		onClickCallBack(base.GetExtendToggle(0), this.CurrentType);
	}

	// Token: 0x06015E2C RID: 89644 RVA: 0x006142C4 File Offset: 0x006124C4
	public void SelectToggle()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x0400A80A RID: 43018
	private int CurrentType;

	// Token: 0x0400A80B RID: 43019
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int> OnClickCallBack;
}
