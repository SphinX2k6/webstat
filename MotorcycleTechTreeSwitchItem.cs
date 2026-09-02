using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200229E RID: 8862
public class MotorcycleTechTreeSwitchItem : GridProxyAbstract<int>
{
	// Token: 0x06010C00 RID: 68608 RVA: 0x00497044 File Offset: 0x00495244
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
		};
	}

	// Token: 0x06010C01 RID: 68609 RVA: 0x004970D7 File Offset: 0x004952D7
	protected override void OnStart()
	{
		this.CurTechTreeType = ModelBase<MotorcycleDevelopModel>.Instance.GetCurTreeType();
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06010C02 RID: 68610 RVA: 0x004970FC File Offset: 0x004952FC
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(data);
		if (motorTechTreeConfig == null)
		{
			return;
		}
		this.TechTreeType = data;
		base.SetTextureByPath(motorTechTreeConfig.Value.Icon512, base.GetTexture(1), null, null);
		base.GetItem(2).SetUIActive(data == this.CurTechTreeType);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), motorTechTreeConfig.Value.Name, Array.Empty<object>());
	}

	// Token: 0x06010C03 RID: 68611 RVA: 0x00497186 File Offset: 0x00495386
	public override void OnSelected(bool fireEvent)
	{
		if (this.TechTreeType <= 0)
		{
			return;
		}
		Action<int, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.TechTreeType, base.GetExtendToggle(0));
	}

	// Token: 0x06010C04 RID: 68612 RVA: 0x004971AF File Offset: 0x004953AF
	private void OnClickItem(EToggleState toggleState)
	{
		if (this.TechTreeType <= 0)
		{
			return;
		}
		Action<int, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.TechTreeType, base.GetExtendToggle(0));
	}

	// Token: 0x0400841D RID: 33821
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIExtendToggle> OnClickToggleBack;

	// Token: 0x0400841E RID: 33822
	private int TechTreeType;

	// Token: 0x0400841F RID: 33823
	private int CurTechTreeType;

	// Token: 0x02008574 RID: 34164
	private class EMotorTechTreeSwitchItemComponent
	{
		// Token: 0x0402D28D RID: 184973
		public const int TogItem = 0;

		// Token: 0x0402D28E RID: 184974
		public const int TexIcon = 1;

		// Token: 0x0402D28F RID: 184975
		public const int CurSelectItem = 2;

		// Token: 0x0402D290 RID: 184976
		public const int TxtName = 3;

		// Token: 0x0402D291 RID: 184977
		public const int TxtName2 = 4;
	}
}
