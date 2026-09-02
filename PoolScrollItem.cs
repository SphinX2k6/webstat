using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020014F8 RID: 5368
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class PoolScrollItem : GridProxyAbstract<ProtoGachaPoolInfo>
{
	// Token: 0x06009642 RID: 38466 RVA: 0x00274484 File Offset: 0x00272684
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06009643 RID: 38467 RVA: 0x00274518 File Offset: 0x00272718
	public override void Refresh(ProtoGachaPoolInfo data, bool isSelected, int gridIndex)
	{
		GachaViewInfo? gachaViewInfo = ConfigBase<GachaConfig>.Instance.GetGachaViewInfo(data.Id);
		if (gachaViewInfo == null)
		{
			return;
		}
		GachaViewInfo value = gachaViewInfo.Value;
		this.PoolInfo = data;
		this.SetSpriteByPath(value.TagNotSelectedSpritePath, base.GetSprite(1), true, null, null);
		base.GetText(2).SetText(data.Title, true);
	}

	// Token: 0x06009644 RID: 38468 RVA: 0x00274581 File Offset: 0x00272781
	public void SelectedToggle()
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x06009645 RID: 38469 RVA: 0x00274593 File Offset: 0x00272793
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<ProtoGachaPoolInfo, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(this.PoolInfo, base.GetExtendToggle(0));
	}

	// Token: 0x040045A0 RID: 17824
	[Nullable(2)]
	private ProtoGachaPoolInfo PoolInfo;

	// Token: 0x040045A1 RID: 17825
	[Nullable(new byte[]
	{
		2,
		2,
		1
	})]
	public Action<ProtoGachaPoolInfo, UUIExtendToggle> OnClickToggleCallBack;
}
