using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200243D RID: 9277
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PersonalRoleDisplayMediumItem : GridProxyAbstract<PersonalRoleDisplayContentData>
{
	// Token: 0x06011F00 RID: 73472 RVA: 0x004EF791 File Offset: 0x004ED991
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06011F01 RID: 73473 RVA: 0x004EF7CC File Offset: 0x004ED9CC
	protected override void OnStart()
	{
		this.ItemBaseItem = new MediumItemGrid();
		this.ItemBaseItem.Initialize(base.GetItem(1).GetOwner());
		this.ItemBaseItem.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		this.ItemBaseItem.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnClickItemBaseItem));
	}

	// Token: 0x06011F02 RID: 73474 RVA: 0x004EF83C File Offset: 0x004EDA3C
	public override void Refresh(PersonalRoleDisplayContentData data, bool isSelected, int gridIndex)
	{
		base.GridIndex = gridIndex;
		this.RoleId = data.RoleId;
		if (this.RoleId < 0)
		{
			base.GetItem(0).SetUIActive(true);
			this.ItemBaseItem.SetUiActive(false);
			return;
		}
		base.GetItem(0).SetUIActive(false);
		this.ItemBaseItem.SetUiActive(true);
		RoleSkinData roleOriginalSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleOriginalSkinData(this.RoleId, !data.IfOtherData);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			Data = this.RoleId,
			SkinId = roleOriginalSkinData.GetItemId(),
			ItemConfigId = new int?(this.RoleId),
			BottomText = ConfigBase<RoleConfig>.Instance.GetRoleName(roleOriginalSkinData.GetName())
		};
		this.ItemBaseItem.Apply<CharacterMediumItemGrid>(parameters);
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		this.ItemBaseItem.GetItemGridExtendToggle().SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x06011F03 RID: 73475 RVA: 0x004EF924 File Offset: 0x004EDB24
	public void BindClickItemCallBack(Action<int> callback)
	{
		this.ClickItemCallBack = callback;
	}

	// Token: 0x06011F04 RID: 73476 RVA: 0x004EF92D File Offset: 0x004EDB2D
	private void OnClickItemBaseItem(MediumItemGridExtendCallback _)
	{
		if (this.ClickItemCallBack != null)
		{
			this.ClickItemCallBack(this.RoleId);
		}
	}

	// Token: 0x06011F05 RID: 73477 RVA: 0x004EF948 File Offset: 0x004EDB48
	public override void OnSelected(bool fireEvent)
	{
		this.ItemBaseItem.GetItemGridExtendToggle().SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06011F06 RID: 73478 RVA: 0x004EF95E File Offset: 0x004EDB5E
	public override void OnDeselected(bool fireEvent)
	{
		this.ItemBaseItem.GetItemGridExtendToggle().SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04008C90 RID: 35984
	private int RoleId;

	// Token: 0x04008C91 RID: 35985
	[Nullable(2)]
	private MediumItemGrid ItemBaseItem;

	// Token: 0x04008C92 RID: 35986
	[Nullable(2)]
	private Action<int> ClickItemCallBack;

	// Token: 0x02008775 RID: 34677
	[NullableContext(0)]
	public enum EComponent
	{
		// Token: 0x0402DCC5 RID: 187589
		EmptyItem,
		// Token: 0x0402DCC6 RID: 187590
		ItemBaseItem
	}
}
