using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200147B RID: 5243
[NullableContext(1)]
[Nullable(0)]
public class NewPlayerSupportTrialRoleListItem : UiPanelBase
{
	// Token: 0x060092C0 RID: 37568 RVA: 0x0026B776 File Offset: 0x00269976
	public NewPlayerSupportTrialRoleListItem(TrialRoleGroupData trialRoleData)
	{
		this.TrialRoleData = trialRoleData;
	}

	// Token: 0x060092C1 RID: 37569 RVA: 0x0026B788 File Offset: 0x00269988
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnSelectItem))
		};
	}

	// Token: 0x060092C2 RID: 37570 RVA: 0x0026B860 File Offset: 0x00269A60
	protected override void OnStart()
	{
		this.ExtendToggle = base.GetExtendToggle(0);
		this.ExtendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		this.RefreshView();
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotTrialRoleGroup, base.GetItem(6), null, this.TrialRoleData.TrialRoleGroupId);
	}

	// Token: 0x060092C3 RID: 37571 RVA: 0x0026B8BE File Offset: 0x00269ABE
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotTrialRoleGroup, base.GetItem(6), this.TrialRoleData.TrialRoleGroupId);
	}

	// Token: 0x060092C4 RID: 37572 RVA: 0x0026B8E4 File Offset: 0x00269AE4
	private void RefreshView()
	{
		bool flag = this.TrialRoleData.IsLocked();
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		UUIItem item3 = base.GetItem(2);
		if (item3 != null)
		{
			item3.SetUIActive(flag);
		}
		UUIItem item4 = base.GetItem(5);
		if (item4 != null)
		{
			item4.SetUIActive(flag);
		}
		UUITexture texture = base.GetTexture(3);
		UUIItem uuiitem = texture;
		bool bUseChangeColor = flag;
		FColor? fcolor = new FColor?(texture.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		RoleConfig instance = ConfigBase<RoleConfig>.Instance;
		RoleInfo? roleInfo = (instance != null) ? instance.GetRoleConfig(this.TrialRoleData.RealRoleId) : null;
		string path = ((roleInfo != null) ? roleInfo.GetValueOrDefault().FormationRoleCard : null) ?? "";
		base.SetTextureByPath(path, texture, null, null);
	}

	// Token: 0x060092C5 RID: 37573 RVA: 0x0026B9CC File Offset: 0x00269BCC
	public void SetSelectCallback(Action<NewPlayerSupportTrialRoleListItem, int> callback)
	{
		this.OnSelectCallback = callback;
	}

	// Token: 0x060092C6 RID: 37574 RVA: 0x0026B9D8 File Offset: 0x00269BD8
	public void SetSelected(bool selected)
	{
		EToggleState state = selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = this.ExtendToggle;
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(state, false, false, false);
		}
		if (selected)
		{
			ModelBase<TrialRoleModel>.Instance.SaveTrialRoleUnlockRedDotById(this.TrialRoleData.TrialRoleGroupId, false);
		}
	}

	// Token: 0x060092C7 RID: 37575 RVA: 0x0026BA1C File Offset: 0x00269C1C
	public void SelectItem()
	{
		if (this.OnSelectCallback != null)
		{
			this.OnSelectCallback(this, this.TrialRoleData.TrialRoleGroupId);
		}
	}

	// Token: 0x060092C8 RID: 37576 RVA: 0x0026BA3D File Offset: 0x00269C3D
	private void OnSelectItem(EToggleState state)
	{
		this.SelectItem();
	}

	// Token: 0x060092C9 RID: 37577 RVA: 0x0026BA45 File Offset: 0x00269C45
	public void SetCanSelectCallback(Func<bool> callback)
	{
		this.CanSelectCallback = callback;
	}

	// Token: 0x060092CA RID: 37578 RVA: 0x0026BA4E File Offset: 0x00269C4E
	private bool CanExecuteChange()
	{
		return this.CanSelectCallback == null || this.CanSelectCallback();
	}

	// Token: 0x040043E2 RID: 17378
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<NewPlayerSupportTrialRoleListItem, int> OnSelectCallback;

	// Token: 0x040043E3 RID: 17379
	[Nullable(2)]
	private Func<bool> CanSelectCallback;

	// Token: 0x040043E4 RID: 17380
	[Nullable(2)]
	private readonly TrialRoleGroupData TrialRoleData;

	// Token: 0x040043E5 RID: 17381
	[Nullable(2)]
	private UUIExtendToggle ExtendToggle;

	// Token: 0x0200788C RID: 30860
	[NullableContext(0)]
	private static class EComponentType
	{
		// Token: 0x04029741 RID: 169793
		public const int RoleItem = 0;

		// Token: 0x04029742 RID: 169794
		public const int RoleBg = 1;

		// Token: 0x04029743 RID: 169795
		public const int RoleLockBg = 2;

		// Token: 0x04029744 RID: 169796
		public const int RoleTex = 3;

		// Token: 0x04029745 RID: 169797
		public const int NormalItem = 4;

		// Token: 0x04029746 RID: 169798
		public const int LockItem = 5;

		// Token: 0x04029747 RID: 169799
		public const int RedDotItem = 6;
	}
}
