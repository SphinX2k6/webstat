using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020029F1 RID: 10737
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTogetherRoleItem : GridProxyAbstract<IShipTogetherRoleItemData>
{
	// Token: 0x060156C0 RID: 87744 RVA: 0x005EF6DC File Offset: 0x005ED8DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x060156C1 RID: 87745 RVA: 0x005EF764 File Offset: 0x005ED964
	protected override void OnStart()
	{
		this.ItemGrid = new SmallItemGrid();
		this.ItemGrid.Initialize(base.GetItem(4).GetOwner());
		this.Toggle = base.GetExtendToggle(0);
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return;
		}
		toggle.OnStateChange.Add(new Action<EToggleState>(this.OnClickToggle));
	}

	// Token: 0x060156C2 RID: 87746 RVA: 0x005EF7C4 File Offset: 0x005ED9C4
	[NullableContext(1)]
	public override void Refresh(IShipTogetherRoleItemData data, bool isSelected, int gridIndex)
	{
		RoleInstance roleInstance = data.RoleInstance;
		this.RoleId = roleInstance.GetRoleId();
		this.IsInFormation = data.IsInFormation;
		this.RefreshState();
		CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
		{
			Data = data,
			SkinId = new int?(roleInstance.GetRoleSkinId()),
			ItemConfigId = new int?(this.RoleId),
			IsBlack = new bool?(this.IsInFormation)
		};
		SmallItemGrid itemGrid = this.ItemGrid;
		if (itemGrid != null)
		{
			itemGrid.Apply<CharacterSmallItemGrid>(parameters);
		}
		SmallItemGrid itemGrid2 = this.ItemGrid;
		if (itemGrid2 != null)
		{
			itemGrid2.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(roleInstance.GetRoleRealName(), true);
		}
		int favorLevel = roleInstance.GetFavorData().GetFavorLevel();
		base.GetText(2).SetUIActive(!this.IsInFormation);
		if (this.IsInFormation)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "CannotInviteInFormation", Array.Empty<object>());
			return;
		}
		UUIText text2 = base.GetText(3);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(favorLevel.ToString() ?? "", true);
	}

	// Token: 0x060156C3 RID: 87747 RVA: 0x005EF8F8 File Offset: 0x005EDAF8
	public void BindOnClickToggleCallBack([Nullable(new byte[]
	{
		1,
		2
	})] Action<UUIExtendToggle, int> func)
	{
		this.OnClickToggleCallBack = func;
	}

	// Token: 0x060156C4 RID: 87748 RVA: 0x005EF901 File Offset: 0x005EDB01
	private void OnClickToggle(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			if (state == EToggleState.ETT_UnChecked)
			{
				Action<UUIExtendToggle, int> onClickToggleCallBack = this.OnClickToggleCallBack;
				if (onClickToggleCallBack == null)
				{
					return;
				}
				onClickToggleCallBack(null, 0);
			}
			return;
		}
		Action<UUIExtendToggle, int> onClickToggleCallBack2 = this.OnClickToggleCallBack;
		if (onClickToggleCallBack2 == null)
		{
			return;
		}
		onClickToggleCallBack2(this.Toggle, this.RoleId);
	}

	// Token: 0x060156C5 RID: 87749 RVA: 0x005EF93C File Offset: 0x005EDB3C
	private void RefreshState()
	{
		if (this.IsInFormation)
		{
			UUIExtendToggle toggle = this.Toggle;
			if (toggle == null)
			{
				return;
			}
			toggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
			return;
		}
		else if (this.RoleId == ModelBase<ShipTogetherModel>.Instance.CurrentSelectTogetherRoleId)
		{
			UUIExtendToggle toggle2 = this.Toggle;
			if (toggle2 == null)
			{
				return;
			}
			toggle2.SetToggleStateForce(EToggleState.ETT_Checked, true, false, false);
			return;
		}
		else
		{
			UUIExtendToggle toggle3 = this.Toggle;
			if (toggle3 == null)
			{
				return;
			}
			toggle3.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
	}

	// Token: 0x0400A4D9 RID: 42201
	private int RoleId;

	// Token: 0x0400A4DA RID: 42202
	private SmallItemGrid ItemGrid;

	// Token: 0x0400A4DB RID: 42203
	private UUIExtendToggle Toggle;

	// Token: 0x0400A4DC RID: 42204
	private Action<UUIExtendToggle, int> OnClickToggleCallBack;

	// Token: 0x0400A4DD RID: 42205
	private bool IsInFormation;

	// Token: 0x02008D6E RID: 36206
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402F8E4 RID: 194788
		public const int Toggle = 0;

		// Token: 0x0402F8E5 RID: 194789
		public const int NameText = 1;

		// Token: 0x0402F8E6 RID: 194790
		public const int FavorDesText = 2;

		// Token: 0x0402F8E7 RID: 194791
		public const int FavorLevelText = 3;

		// Token: 0x0402F8E8 RID: 194792
		public const int RoleItem = 4;
	}
}
