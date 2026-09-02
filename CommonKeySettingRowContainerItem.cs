using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200208B RID: 8331
[NullableContext(1)]
[Nullable(0)]
public class CommonKeySettingRowContainerItem : UiPanelBase, IDynamicScrollItem<KeySettingRowData>
{
	// Token: 0x0600FE28 RID: 65064 RVA: 0x0045BAC0 File Offset: 0x00459CC0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0600FE29 RID: 65065 RVA: 0x0045BB1C File Offset: 0x00459D1C
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnStateChanged));
			extendToggle.OnHover.Add(new Action(this.OnHover));
			extendToggle.OnUnHover.Add(new Action(this.OnUnHover));
		}
		this.SetActive(true);
	}

	// Token: 0x0600FE2A RID: 65066 RVA: 0x0045BB80 File Offset: 0x00459D80
	protected override void OnBeforeDestroy()
	{
		this.KeySettingRowData = null;
		this.KeySettingRowKeyItem = null;
		this.KeySettingRowTypeItem = null;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnStateChanged));
			extendToggle.OnHover.Remove(new Action(this.OnHover));
			extendToggle.OnUnHover.Remove(new Action(this.OnUnHover));
		}
	}

	// Token: 0x0600FE2B RID: 65067 RVA: 0x0045BBF4 File Offset: 0x00459DF4
	public UniTask Init(UUIItem actor)
	{
		CommonKeySettingRowContainerItem.<Init>d__7 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<CommonKeySettingRowContainerItem.<Init>d__7>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600FE2C RID: 65068 RVA: 0x0045BC40 File Offset: 0x00459E40
	public void Update(KeySettingRowData data, int index)
	{
		this.KeySettingRowData = data;
		CSharpScript.Game.Module.Menu.EInputControllerType inputControllerType = KeySettingViewModel.InputControllerType;
		EKeySettingRowType rowType = data.GetRowType();
		if (rowType != EKeySettingRowType.KeyType)
		{
			if (rowType == EKeySettingRowType.KeySetting)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (extendToggle != null)
				{
					extendToggle.SetSelfInteractive(true);
				}
				this.KeySettingRowKeyItem.Refresh(data, inputControllerType);
				base.GetItem(2).SetUIActive(true);
				base.GetItem(1).SetUIActive(false);
			}
		}
		else
		{
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
			if (extendToggle2 != null)
			{
				extendToggle2.SetSelfInteractive(false);
			}
			this.KeySettingRowTypeItem.Refresh(data);
			base.GetItem(2).SetUIActive(false);
			base.GetItem(1).SetUIActive(true);
		}
		this.SetToggleState(data.IsExpandDetail);
	}

	// Token: 0x0600FE2D RID: 65069 RVA: 0x0045BCEA File Offset: 0x00459EEA
	public void ClearItem()
	{
	}

	// Token: 0x0600FE2E RID: 65070 RVA: 0x0045BCEC File Offset: 0x00459EEC
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(KeySettingRowData data)
	{
		EKeySettingRowType rowType = data.GetRowType();
		if (rowType == EKeySettingRowType.KeyType)
		{
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		}
		if (rowType != EKeySettingRowType.KeySetting)
		{
			return null;
		}
		return base.GetItem(2).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600FE2F RID: 65071 RVA: 0x0045BD30 File Offset: 0x00459F30
	private UniTask NewKeySettingRowKeyItem()
	{
		CommonKeySettingRowContainerItem.<NewKeySettingRowKeyItem>d__11 <NewKeySettingRowKeyItem>d__;
		<NewKeySettingRowKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewKeySettingRowKeyItem>d__.<>4__this = this;
		<NewKeySettingRowKeyItem>d__.<>1__state = -1;
		<NewKeySettingRowKeyItem>d__.<>t__builder.Start<CommonKeySettingRowContainerItem.<NewKeySettingRowKeyItem>d__11>(ref <NewKeySettingRowKeyItem>d__);
		return <NewKeySettingRowKeyItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600FE30 RID: 65072 RVA: 0x0045BD74 File Offset: 0x00459F74
	private UniTask NewKeySettingRowTypeItem()
	{
		CommonKeySettingRowContainerItem.<NewKeySettingRowTypeItem>d__12 <NewKeySettingRowTypeItem>d__;
		<NewKeySettingRowTypeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewKeySettingRowTypeItem>d__.<>4__this = this;
		<NewKeySettingRowTypeItem>d__.<>1__state = -1;
		<NewKeySettingRowTypeItem>d__.<>t__builder.Start<CommonKeySettingRowContainerItem.<NewKeySettingRowTypeItem>d__12>(ref <NewKeySettingRowTypeItem>d__);
		return <NewKeySettingRowTypeItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600FE31 RID: 65073 RVA: 0x0045BDB7 File Offset: 0x00459FB7
	private void SetToggleState(bool bChecked)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(bChecked ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600FE32 RID: 65074 RVA: 0x0045BDD5 File Offset: 0x00459FD5
	private void OnStateChanged(EToggleState state)
	{
		if (state == EToggleState.ETT_UnChecked)
		{
			CommonKeySettingRowKeyItem keySettingRowKeyItem = this.KeySettingRowKeyItem;
			if (keySettingRowKeyItem == null)
			{
				return;
			}
			keySettingRowKeyItem.SetDetailItemVisible(false);
			return;
		}
		else
		{
			CommonKeySettingRowKeyItem keySettingRowKeyItem2 = this.KeySettingRowKeyItem;
			if (keySettingRowKeyItem2 == null)
			{
				return;
			}
			keySettingRowKeyItem2.SetDetailItemVisible(true);
			return;
		}
	}

	// Token: 0x0600FE33 RID: 65075 RVA: 0x0045BDFD File Offset: 0x00459FFD
	private void OnHover()
	{
		KeySettingViewModel.HoverKey(this.KeySettingRowData);
	}

	// Token: 0x0600FE34 RID: 65076 RVA: 0x0045BE0A File Offset: 0x0045A00A
	private void OnUnHover()
	{
		KeySettingViewModel.UnHoverKey(this.KeySettingRowData);
	}

	// Token: 0x040079D8 RID: 31192
	[Nullable(2)]
	public KeySettingRowData KeySettingRowData;

	// Token: 0x040079D9 RID: 31193
	[Nullable(2)]
	private CommonKeySettingRowKeyItem KeySettingRowKeyItem;

	// Token: 0x040079DA RID: 31194
	[Nullable(2)]
	private CommonKeySettingRowTypeItem KeySettingRowTypeItem;

	// Token: 0x02008417 RID: 33815
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402CC48 RID: 183368
		public const int Toggle = 0;

		// Token: 0x0402CC49 RID: 183369
		public const int KeyTypeItem = 1;

		// Token: 0x0402CC4A RID: 183370
		public const int KeySettingItem = 2;
	}
}
