using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002A0C RID: 10764
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShowerInviteItem : GridProxyAbstract<IShowerInviteItemData>
{
	// Token: 0x060157A9 RID: 87977 RVA: 0x005F4314 File Offset: 0x005F2514
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
	}

	// Token: 0x060157AA RID: 87978 RVA: 0x005F43C8 File Offset: 0x005F25C8
	protected override void OnStart()
	{
		this.ItemGrid = new SmallItemGrid();
		this.ItemGrid.Initialize(base.GetItem(3).GetOwner());
		this.Toggle = base.GetExtendToggle(0);
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return;
		}
		toggle.OnStateChange.Add(new Action<EToggleState>(this.OnClickToggle));
	}

	// Token: 0x060157AB RID: 87979 RVA: 0x005F4428 File Offset: 0x005F2628
	[NullableContext(1)]
	public override void Refresh(IShowerInviteItemData data, bool isSelected, int gridIndex)
	{
		this.RoleInstance = data.RoleInstance;
		this.RoleId = data.RoleInstance.GetRoleId();
		this.IsInFormation = data.IsInFormation;
		this.RefreshState();
		CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
		{
			Data = this.RoleInstance,
			SkinId = new int?(this.RoleInstance.GetRoleSkinId()),
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
			text.SetText(this.RoleInstance.GetRoleRealName(), true);
		}
		int favorLevel = this.RoleInstance.GetFavorData().GetFavorLevel();
		base.GetText(2).SetUIActive(!this.IsInFormation);
		if (this.IsInFormation)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "CannotInviteInFormation", Array.Empty<object>());
			return;
		}
		UUIText text2 = base.GetText(4);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(favorLevel.ToString() ?? "", true);
	}

	// Token: 0x060157AC RID: 87980 RVA: 0x005F457C File Offset: 0x005F277C
	private void RefreshState()
	{
		if (this.IsInFormation)
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIExtendToggle toggle = this.Toggle;
			if (toggle == null)
			{
				return;
			}
			toggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
			return;
		}
		else
		{
			int rolePos = ModelBase<ShowerModel>.Instance.GetRolePos(this.RoleInstance);
			if (rolePos != -1)
			{
				UUIItem item2 = base.GetItem(5);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				UUIText text = base.GetText(6);
				if (text != null)
				{
					text.SetText((rolePos + 1).ToString(), true);
				}
			}
			else
			{
				UUIItem item3 = base.GetItem(5);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
			}
			if (!ModelBase<ShowerModel>.Instance.CheckRoleInCurPos(this.RoleInstance))
			{
				UUIExtendToggle toggle2 = this.Toggle;
				if (toggle2 != null)
				{
					toggle2.SetToggleStateForce(EToggleState.ETT_UnChecked, false, true, false);
				}
				UUIExtendToggle toggle3 = this.Toggle;
				AActor aactor = (toggle3 != null) ? toggle3.GetOwner() : null;
				if (aactor != null)
				{
					aactor.SetActorScale3D(new FVector(1f, 1f, 1f));
				}
				return;
			}
			UUIExtendToggle toggle4 = this.Toggle;
			if (toggle4 == null)
			{
				return;
			}
			toggle4.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
	}

	// Token: 0x060157AD RID: 87981 RVA: 0x005F4681 File Offset: 0x005F2881
	[NullableContext(1)]
	public void BindRoleSelectCallback(Action<RoleInstance> callback)
	{
		this.RoleSelectCallback = callback;
	}

	// Token: 0x060157AE RID: 87982 RVA: 0x005F468A File Offset: 0x005F288A
	private void OnClickToggle(EToggleState state)
	{
		Action<RoleInstance> roleSelectCallback = this.RoleSelectCallback;
		if (roleSelectCallback == null)
		{
			return;
		}
		roleSelectCallback(this.RoleInstance);
	}

	// Token: 0x0400A53F RID: 42303
	private int RoleId;

	// Token: 0x0400A540 RID: 42304
	private RoleInstance RoleInstance;

	// Token: 0x0400A541 RID: 42305
	private bool IsInFormation;

	// Token: 0x0400A542 RID: 42306
	private UUIExtendToggle Toggle;

	// Token: 0x0400A543 RID: 42307
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<RoleInstance> RoleSelectCallback;

	// Token: 0x0400A544 RID: 42308
	private SmallItemGrid ItemGrid;

	// Token: 0x02008D8A RID: 36234
	[NullableContext(0)]
	private class EShowerInviteItemComponents
	{
		// Token: 0x0402F97D RID: 194941
		public const int Toggle = 0;

		// Token: 0x0402F97E RID: 194942
		public const int RoleNameText = 1;

		// Token: 0x0402F97F RID: 194943
		public const int FavorDesText = 2;

		// Token: 0x0402F980 RID: 194944
		public const int RoleItem = 3;

		// Token: 0x0402F981 RID: 194945
		public const int FavorLevelText = 4;

		// Token: 0x0402F982 RID: 194946
		public const int NumItem = 5;

		// Token: 0x0402F983 RID: 194947
		public const int NumText = 6;
	}
}
