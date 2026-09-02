using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002441 RID: 9281
[NullableContext(1)]
[Nullable(0)]
public class PersonalRoleShowView : UiViewBase
{
	// Token: 0x06011F0A RID: 73482 RVA: 0x004EFA0D File Offset: 0x004EDC0D
	public PersonalRoleShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011F0B RID: 73483 RVA: 0x004EFA18 File Offset: 0x004EDC18
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickConfirmButton))
		};
	}

	// Token: 0x06011F0C RID: 73484 RVA: 0x004EFA98 File Offset: 0x004EDC98
	private void OnClickConfirmButton()
	{
		List<RoleShowEntry> roleShowList = ModelBase<PersonalModel>.Instance.GetRoleShowList();
		int count = roleShowList.Count;
		List<int> list = new List<int>();
		if (this.CurRoleShowOpera == ERoleShowOpera.Add)
		{
			for (int i = 0; i < count; i++)
			{
				RoleShowEntry roleShowEntry = roleShowList[i];
				list.Add(roleShowEntry.Proto_RoleId);
			}
			list.Add(this.CurSelectRoleId);
		}
		else if (this.CurRoleShowOpera == ERoleShowOpera.Remove)
		{
			for (int j = 0; j < count; j++)
			{
				RoleShowEntry roleShowEntry2 = roleShowList[j];
				if (roleShowEntry2.Proto_RoleId != this.CurSelectRoleId)
				{
					list.Add(roleShowEntry2.Proto_RoleId);
				}
			}
		}
		else if (this.CurRoleShowOpera == ERoleShowOpera.Replace)
		{
			for (int k = 0; k < count; k++)
			{
				RoleShowEntry roleShowEntry3 = roleShowList[k];
				if (roleShowEntry3.Proto_RoleId == this.CurSelectRoleId)
				{
					list.Add(this.CurInShowRoleId);
				}
				else if (roleShowEntry3.Proto_RoleId == this.CurInShowRoleId)
				{
					list.Add(this.CurSelectRoleId);
				}
				else
				{
					list.Add(roleShowEntry3.Proto_RoleId);
				}
			}
		}
		ControllerBase<PersonalController>.Instance.SendRoleShowListUpdateRequest(list);
		base.CloseMe(null);
	}

	// Token: 0x06011F0D RID: 73485 RVA: 0x004EFBB8 File Offset: 0x004EDDB8
	protected override void OnStart()
	{
		this.CurInShowRoleId = (this.OpenParam as int?).GetValueOrDefault();
		this.ScrollView = new GenericScrollView<PersonalRoleMediumItemGrid>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PersonalRoleMediumItemGrid>(this.InitRoleItem), null);
	}

	// Token: 0x06011F0E RID: 73486 RVA: 0x004EFC04 File Offset: 0x004EDE04
	private ILayoutItem<PersonalRoleMediumItemGrid> InitRoleItem(object roleId, UUIItem uiItem, int index)
	{
		PersonalRoleMediumItemGrid personalRoleMediumItemGrid = new PersonalRoleMediumItemGrid();
		personalRoleMediumItemGrid.Initialize(uiItem.GetOwner());
		personalRoleMediumItemGrid.Refresh((int)roleId, false, index);
		personalRoleMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.RoleItemToggleClick));
		return new LayoutItem<PersonalRoleMediumItemGrid>
		{
			Key = index,
			Value = personalRoleMediumItemGrid
		};
	}

	// Token: 0x06011F0F RID: 73487 RVA: 0x004EFC5C File Offset: 0x004EDE5C
	private void RoleItemToggleClick(MediumItemGridExtendCallback callbackParameter)
	{
		PersonalRoleMediumItemGrid currentSelectedItem = this.CurrentSelectedItem;
		if (currentSelectedItem != null)
		{
			currentSelectedItem.SetSelected(false, false);
		}
		this.CurrentSelectedItem = (callbackParameter.MediumItemGrid as PersonalRoleMediumItemGrid);
		PersonalRoleMediumItemGrid currentSelectedItem2 = this.CurrentSelectedItem;
		if (currentSelectedItem2 != null)
		{
			currentSelectedItem2.SetSelected(true, false);
		}
		int roleId = (int)callbackParameter.Data;
		this.Refresh(roleId);
	}

	// Token: 0x06011F10 RID: 73488 RVA: 0x004EFCB4 File Offset: 0x004EDEB4
	protected void Refresh(int roleId)
	{
		this.CurSelectRoleId = roleId;
		bool flag = this.CurInShowRoleId == this.CurSelectRoleId;
		List<RoleShowEntry> roleShowList = ModelBase<PersonalModel>.Instance.GetRoleShowList();
		base.GetButton(1).RootUIComp.Get().SetUIActive(true);
		bool flag2 = this.IsRoleInShow(this.CurSelectRoleId);
		if (roleShowList.Count == 1 && flag2)
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			return;
		}
		if (this.CurInShowRoleId == 0)
		{
			if (!flag2)
			{
				this.SetConfirmButtonState(ERoleShowOpera.Add);
				return;
			}
			this.SetConfirmButtonState(ERoleShowOpera.Remove);
			return;
		}
		else
		{
			if (flag)
			{
				this.SetConfirmButtonState(ERoleShowOpera.Remove);
				return;
			}
			this.SetConfirmButtonState(ERoleShowOpera.Replace);
			return;
		}
	}

	// Token: 0x06011F11 RID: 73489 RVA: 0x004EFD5C File Offset: 0x004EDF5C
	private void SetConfirmButtonState(ERoleShowOpera state)
	{
		this.CurRoleShowOpera = state;
		UUIText text = base.GetText(2);
		switch (state)
		{
		case ERoleShowOpera.Add:
			Singleton<LguiUtil>.Instance.SetLocalText(text, "JoinText", Array.Empty<object>());
			return;
		case ERoleShowOpera.Replace:
			Singleton<LguiUtil>.Instance.SetLocalText(text, "ChangeText", Array.Empty<object>());
			return;
		case ERoleShowOpera.Remove:
			Singleton<LguiUtil>.Instance.SetLocalText(text, "GoDownText", Array.Empty<object>());
			return;
		default:
			return;
		}
	}

	// Token: 0x06011F12 RID: 73490 RVA: 0x004EFDCC File Offset: 0x004EDFCC
	protected bool IsRoleInShow(int roleId)
	{
		List<RoleShowEntry> roleShowList = ModelBase<PersonalModel>.Instance.GetRoleShowList();
		int count = roleShowList.Count;
		bool result = false;
		for (int i = 0; i < count; i++)
		{
			if (roleShowList[i].Proto_RoleId == this.CurSelectRoleId)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06011F13 RID: 73491 RVA: 0x004EFE14 File Offset: 0x004EE014
	protected override void OnAfterShow()
	{
		this.RoleIdList = ModelBase<RoleModel>.Instance.GetRoleIdList();
		if (this.RoleIdList.Count > 0)
		{
			this.ScrollView.RefreshByData<int>(this.RoleIdList, null);
			this.CurSelectRoleId = this.RoleIdList[0];
			this.CurrentSelectedItem = this.ScrollView.GetScrollItemList()[0];
			this.CurrentSelectedItem.SetSelected(true, false);
			this.Refresh(this.CurSelectRoleId);
		}
	}

	// Token: 0x06011F14 RID: 73492 RVA: 0x004EFE9B File Offset: 0x004EE09B
	protected override void OnBeforeDestroy()
	{
		if (this.ScrollView != null)
		{
			this.ScrollView.ClearChildren();
			this.ScrollView = null;
		}
	}

	// Token: 0x04008C9D RID: 35997
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<PersonalRoleMediumItemGrid> ScrollView;

	// Token: 0x04008C9E RID: 35998
	[Nullable(2)]
	private List<int> RoleIdList;

	// Token: 0x04008C9F RID: 35999
	private int CurSelectRoleId;

	// Token: 0x04008CA0 RID: 36000
	private int CurInShowRoleId;

	// Token: 0x04008CA1 RID: 36001
	private ERoleShowOpera CurRoleShowOpera;

	// Token: 0x04008CA2 RID: 36002
	[Nullable(2)]
	private PersonalRoleMediumItemGrid CurrentSelectedItem;
}
