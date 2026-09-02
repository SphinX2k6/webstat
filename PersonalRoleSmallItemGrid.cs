using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002443 RID: 9283
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PersonalRoleSmallItemGrid : GridProxyAbstract<PlayerHeadData>
{
	// Token: 0x06011F15 RID: 73493 RVA: 0x004EFEB8 File Offset: 0x004EE0B8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIInteractionGroup)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnSelectToggleClick))
		};
	}

	// Token: 0x06011F16 RID: 73494 RVA: 0x004EFF4C File Offset: 0x004EE14C
	public override void Refresh(PlayerHeadData playerHeadData, bool isSelected, int gridIndex)
	{
		this.PlayerHeadData = playerHeadData;
		int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		UUITexture roleTexture = base.GetTexture(0);
		roleTexture.SetUIActive(false);
		base.SetTextureShowUntilLoaded(playerHeadData.GetRoleCardHeadIcon(), roleTexture, delegate(bool _)
		{
			roleTexture.SetUIActive(true);
		});
		base.GetTexture(0).SetIsGray(playerHeadData.Lock);
		UUIItem item = base.GetItem(3);
		int id = playerHeadData.Id;
		int? num = numberPropById;
		item.SetUIActive(id == num.GetValueOrDefault() & num != null);
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state, false, false, false);
	}

	// Token: 0x06011F17 RID: 73495 RVA: 0x004EFFFC File Offset: 0x004EE1FC
	public void RefreshEquipHeadIconItem()
	{
		int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.HeadPhoto);
		UUIItem item = base.GetItem(3);
		int id = this.PlayerHeadData.Id;
		int? num = numberPropById;
		item.SetUIActive(id == num.GetValueOrDefault() & num != null);
	}

	// Token: 0x06011F18 RID: 73496 RVA: 0x004F003F File Offset: 0x004EE23F
	private void OnSelectToggleClick(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		if (this.ToggleClickCallBack != null)
		{
			this.ToggleClickCallBack(this.PlayerHeadData);
		}
	}

	// Token: 0x06011F19 RID: 73497 RVA: 0x004F0061 File Offset: 0x004EE261
	public void BindToggleClickCallBack(Action<PlayerHeadData> toggleClickClickBack)
	{
		this.ToggleClickCallBack = toggleClickClickBack;
	}

	// Token: 0x06011F1A RID: 73498 RVA: 0x004F006A File Offset: 0x004EE26A
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06011F1B RID: 73499 RVA: 0x004F007D File Offset: 0x004EE27D
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04008CA8 RID: 36008
	private PlayerHeadData PlayerHeadData;

	// Token: 0x04008CA9 RID: 36009
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PlayerHeadData> ToggleClickCallBack;
}
