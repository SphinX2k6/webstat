using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013C2 RID: 5058
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EditTeamItem : GridProxyAbstract<EditTeamData>
{
	// Token: 0x06008B8D RID: 35725 RVA: 0x0024BB68 File Offset: 0x00249D68
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggle))
		};
	}

	// Token: 0x06008B8E RID: 35726 RVA: 0x0024BCC8 File Offset: 0x00249EC8
	private UniTask InitCharacterItem(UUIItem uiItem)
	{
		EditTeamItem.<InitCharacterItem>d__8 <InitCharacterItem>d__;
		<InitCharacterItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCharacterItem>d__.<>4__this = this;
		<InitCharacterItem>d__.uiItem = uiItem;
		<InitCharacterItem>d__.<>1__state = -1;
		<InitCharacterItem>d__.<>t__builder.Start<EditTeamItem.<InitCharacterItem>d__8>(ref <InitCharacterItem>d__);
		return <InitCharacterItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008B8F RID: 35727 RVA: 0x0024BD14 File Offset: 0x00249F14
	protected override UniTask OnBeforeStartAsync()
	{
		EditTeamItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<EditTeamItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B90 RID: 35728 RVA: 0x0024BD58 File Offset: 0x00249F58
	public override void Refresh(EditTeamData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		base.GetItem(8).SetUIActive(!data.IsOwn);
		base.GetItem(10).SetUIActive(data.IsOwn);
		base.GetTexture(2).SetUIActive(!data.IsOwn);
		base.GetTexture(1).SetUIActive(data.IsOwn);
		EntrustRole entrustRoleById = ConfigBase<BusinessConfig>.Instance.GetEntrustRoleById(this.Data.Id);
		EEditTeamDataUnLockState teamDataUnLockState = data.GetTeamDataUnLockState();
		base.GetItem(12).SetUIActive(teamDataUnLockState == EEditTeamDataUnLockState.TaskUnFinish);
		if (!data.IsOwn)
		{
			this.SetToggleState(false, false);
			string unLockConditionDesc = data.GetUnLockConditionDesc();
			base.GetText(9).SetText(unLockConditionDesc, true);
			base.SetTextureByPath(entrustRoleById.Icon, base.GetTexture(2), null, null);
			return;
		}
		TEditTeamItemSelected isItemSelected = this.IsItemSelected;
		bool isSelected2 = (isItemSelected != null) ? isItemSelected(this.Data.Id) : isSelected;
		this.SetToggleState(isSelected2, false);
		List<CharacterData> characterDataList = data.GetCharacterDataList();
		for (int i = 0; i < characterDataList.Count; i++)
		{
			this.CharacterList[i].Refresh(characterDataList[i], false, 0);
		}
		base.SetTextureByPath(entrustRoleById.Icon, base.GetTexture(1), null, null);
		base.GetText(3).SetText(this.Data.Level.ToString(), true);
		base.GetText(4).SetText(this.Data.Name, true);
		this.RefreshRedDot(this.Data.Id);
	}

	// Token: 0x06008B91 RID: 35729 RVA: 0x0024BEF8 File Offset: 0x0024A0F8
	public void RefreshRedDot(int roleId)
	{
		bool flag = ModelBase<MoonChasingModel>.Instance.CheckRoleIdRedDotState(roleId);
		if (this.RedDotState == flag)
		{
			return;
		}
		this.RedDotState = flag;
		base.GetItem(11).SetUIActive(this.RedDotState);
	}

	// Token: 0x06008B92 RID: 35730 RVA: 0x0024BF35 File Offset: 0x0024A135
	private void ReadRedDot()
	{
		if (!this.RedDotState)
		{
			return;
		}
		if (!this.Data.IsOwn)
		{
			return;
		}
		ModelBase<MoonChasingModel>.Instance.ReadRoleIdUnlockFlag(this.Data.Id);
		this.RefreshRedDot(this.Data.Id);
	}

	// Token: 0x06008B93 RID: 35731 RVA: 0x0024BF74 File Offset: 0x0024A174
	private void OnToggle(EToggleState state)
	{
		this.ReadRedDot();
		this.OnClickEvent(this.Data.Id, state == EToggleState.ETT_Checked, base.GridIndex);
	}

	// Token: 0x06008B94 RID: 35732 RVA: 0x0024BF9C File Offset: 0x0024A19C
	private bool OnCanExecuteChange()
	{
		EToggleState toggleState = base.GetExtendToggle(0).ToggleState;
		return this.CanExecuteChange == null || this.CanExecuteChange(this.Data.Id, toggleState);
	}

	// Token: 0x06008B95 RID: 35733 RVA: 0x0024BFD7 File Offset: 0x0024A1D7
	public void SetClickEvent(TEditTeamClick onClickEvent)
	{
		this.OnClickEvent = onClickEvent;
	}

	// Token: 0x06008B96 RID: 35734 RVA: 0x0024BFE0 File Offset: 0x0024A1E0
	[NullableContext(2)]
	public void SetCanExecuteChange(TEditTeamCanExecuteChange canExecuteChange)
	{
		this.CanExecuteChange = canExecuteChange;
	}

	// Token: 0x06008B97 RID: 35735 RVA: 0x0024BFE9 File Offset: 0x0024A1E9
	[NullableContext(2)]
	public void SetIsItemSelected(TEditTeamItemSelected isItemSelected)
	{
		this.IsItemSelected = isItemSelected;
	}

	// Token: 0x06008B98 RID: 35736 RVA: 0x0024BFF2 File Offset: 0x0024A1F2
	public void SetToggleState(bool isSelected, bool bFireEvent = false)
	{
		base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
	}

	// Token: 0x06008B99 RID: 35737 RVA: 0x0024C00B File Offset: 0x0024A20B
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true, fireEvent);
	}

	// Token: 0x06008B9A RID: 35738 RVA: 0x0024C015 File Offset: 0x0024A215
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false, false);
	}

	// Token: 0x0400411D RID: 16669
	protected List<CharacterItem> CharacterList = new List<CharacterItem>();

	// Token: 0x0400411E RID: 16670
	protected TEditTeamClick OnClickEvent;

	// Token: 0x0400411F RID: 16671
	[Nullable(2)]
	protected TEditTeamCanExecuteChange CanExecuteChange;

	// Token: 0x04004120 RID: 16672
	[Nullable(2)]
	protected TEditTeamItemSelected IsItemSelected;

	// Token: 0x04004121 RID: 16673
	protected EditTeamData Data;

	// Token: 0x04004122 RID: 16674
	protected bool RedDotState;

	// Token: 0x0200778A RID: 30602
	[NullableContext(0)]
	private static class EEditTeamItem
	{
		// Token: 0x04029260 RID: 168544
		public const int Toggle = 0;

		// Token: 0x04029261 RID: 168545
		public const int RoleIcon = 1;

		// Token: 0x04029262 RID: 168546
		public const int RoleLockIcon = 2;

		// Token: 0x04029263 RID: 168547
		public const int RoleLevel = 3;

		// Token: 0x04029264 RID: 168548
		public const int RoleName = 4;

		// Token: 0x04029265 RID: 168549
		public const int FirstCharacterItem = 5;

		// Token: 0x04029266 RID: 168550
		public const int SecondCharacterItem = 6;

		// Token: 0x04029267 RID: 168551
		public const int ThirdCharacterItem = 7;

		// Token: 0x04029268 RID: 168552
		public const int LockItem = 8;

		// Token: 0x04029269 RID: 168553
		public const int LockText = 9;

		// Token: 0x0402926A RID: 168554
		public const int UnlockItem = 10;

		// Token: 0x0402926B RID: 168555
		public const int RedDot = 11;

		// Token: 0x0402926C RID: 168556
		public const int TaskTipItem = 12;
	}
}
