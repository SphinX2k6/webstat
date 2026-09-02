using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002728 RID: 10024
public class RacingBetsPreviewViewOrganItem : GridProxyAbstract<int>
{
	// Token: 0x06013C51 RID: 80977 RVA: 0x005800AA File Offset: 0x0057E2AA
	protected override void OnStart()
	{
		base.GetExtendToggle(0).bLockStateOnSelect = true;
	}

	// Token: 0x06013C52 RID: 80978 RVA: 0x005800BC File Offset: 0x0057E2BC
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

	// Token: 0x06013C53 RID: 80979 RVA: 0x00580124 File Offset: 0x0057E324
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.Id = data;
		base.SetTextureByPath(ConfigBase<RacingBetsConfig>.Instance.GetOrganConfig(this.Id).Value.IconPath, base.GetTexture(1), null, null);
	}

	// Token: 0x06013C54 RID: 80980 RVA: 0x00580170 File Offset: 0x0057E370
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
	}

	// Token: 0x06013C55 RID: 80981 RVA: 0x00580196 File Offset: 0x0057E396
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x06013C56 RID: 80982 RVA: 0x0058019F File Offset: 0x0057E39F
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x06013C57 RID: 80983 RVA: 0x005801A8 File Offset: 0x0057E3A8
	private void OnClickToggle(EToggleState state)
	{
		Action<int, int> onToggleCallBack = this.OnToggleCallBack;
		if (onToggleCallBack == null)
		{
			return;
		}
		onToggleCallBack(base.GridIndex, this.Id);
	}

	// Token: 0x040099EE RID: 39406
	public int Id;

	// Token: 0x040099EF RID: 39407
	[Nullable(2)]
	public Action<int, int> OnToggleCallBack;

	// Token: 0x02008ACD RID: 35533
	private class EComponent
	{
		// Token: 0x0402ECBA RID: 191674
		public const int ToggleRoot = 0;

		// Token: 0x0402ECBB RID: 191675
		public const int TextureIcon = 1;
	}
}
