using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020012C1 RID: 4801
public class CumulativeShopTaskTabItem : GridProxyAbstract<int>
{
	// Token: 0x060080EE RID: 33006 RVA: 0x0022130C File Offset: 0x0021F50C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnExtendToggleToggle))
		};
	}

	// Token: 0x060080EF RID: 33007 RVA: 0x0022139F File Offset: 0x0021F59F
	private void OnExtendToggleToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.OnClickBack(this.TabIndex, base.GetExtendToggle(1));
		}
	}

	// Token: 0x060080F0 RID: 33008 RVA: 0x002213C0 File Offset: 0x0021F5C0
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TabIndex = data;
		ConsumptiveTaskTab? cumulativeShopTaskTabConfig = ConfigBase<CumulativeShopConfig>.Instance.GetCumulativeShopTaskTabConfig(this.TabIndex);
		this.SetSpriteByPath(cumulativeShopTaskTabConfig.Value.SpriteIcon, base.GetSprite(0), false, null, delegate(bool _)
		{
			(base.GetSprite(0).GetOwner().GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) as UUIExtendToggleSpriteTransition).SetAllStateSprite(base.GetSprite(0).GetSprite());
		});
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), cumulativeShopTaskTabConfig.Value.Title, Array.Empty<object>());
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.CumulativeShopTaskTabRedDot, base.GetItem(2), null, this.TabIndex);
	}

	// Token: 0x060080F1 RID: 33009 RVA: 0x00221459 File Offset: 0x0021F659
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.CumulativeShopTaskTabRedDot, base.GetItem(2), 0);
	}

	// Token: 0x060080F2 RID: 33010 RVA: 0x00221472 File Offset: 0x0021F672
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x04003D96 RID: 15766
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIExtendToggle> OnClickBack;

	// Token: 0x04003D97 RID: 15767
	public int TabIndex;
}
