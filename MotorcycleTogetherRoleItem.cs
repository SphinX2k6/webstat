using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002288 RID: 8840
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleTogetherRoleItem : GridProxyAbstract<RoleInstance>
{
	// Token: 0x06010B62 RID: 68450 RVA: 0x00493A44 File Offset: 0x00491C44
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06010B63 RID: 68451 RVA: 0x00493AF0 File Offset: 0x00491CF0
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleTogetherRoleItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleTogetherRoleItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010B64 RID: 68452 RVA: 0x00493B34 File Offset: 0x00491D34
	[NullableContext(1)]
	public override void Refresh(RoleInstance data, bool isSelected, int gridIndex)
	{
		this.RoleId = data.GetRoleId();
		CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
		{
			Data = data,
			SkinId = new int?(data.GetRoleSkinId()),
			ItemConfigId = new int?(this.RoleId)
		};
		this.ItemGrid.Apply<CharacterSmallItemGrid>(parameters);
		base.GetText(1).SetText(data.GetRoleRealName(), true);
		int favorLevel = data.GetFavorData().GetFavorLevel();
		base.GetText(4).SetText(favorLevel.ToString(), true);
		Func<int, bool> isToggleSelectOn = this.IsToggleSelectOn;
		bool toggleState = isToggleSelectOn != null && isToggleSelectOn(this.RoleId);
		this.SetToggleState(toggleState);
	}

	// Token: 0x06010B65 RID: 68453 RVA: 0x00493BDB File Offset: 0x00491DDB
	private void OnClickToggle(EToggleState state)
	{
		Action<bool, int, int> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(state == EToggleState.ETT_Checked, this.RoleId, base.GridIndex);
	}

	// Token: 0x06010B66 RID: 68454 RVA: 0x00493C00 File Offset: 0x00491E00
	private void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state2, false, false, false);
	}

	// Token: 0x06010B67 RID: 68455 RVA: 0x00493C2B File Offset: 0x00491E2B
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x06010B68 RID: 68456 RVA: 0x00493C34 File Offset: 0x00491E34
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x06010B69 RID: 68457 RVA: 0x00493C40 File Offset: 0x00491E40
	public UUIItem GetToggleRootItem()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return null;
		}
		return extendToggle.RootUIComp.Get();
	}

	// Token: 0x06010B6A RID: 68458 RVA: 0x00493C67 File Offset: 0x00491E67
	[NullableContext(1)]
	public override object GetKey(RoleInstance data, int displayIndex)
	{
		return this.RoleId;
	}

	// Token: 0x040083E5 RID: 33765
	private int RoleId;

	// Token: 0x040083E6 RID: 33766
	private SmallItemGrid ItemGrid;

	// Token: 0x040083E7 RID: 33767
	public Action<bool, int, int> OnClickToggleCallBack;

	// Token: 0x040083E8 RID: 33768
	public Func<int, bool> IsToggleSelectOn;

	// Token: 0x0200854D RID: 34125
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402D1CF RID: 184783
		public const int Toggle = 0;

		// Token: 0x0402D1D0 RID: 184784
		public const int TxtName = 1;

		// Token: 0x0402D1D1 RID: 184785
		public const int TxtFavorDes = 2;

		// Token: 0x0402D1D2 RID: 184786
		public const int RoleItem = 3;

		// Token: 0x0402D1D3 RID: 184787
		public const int TxtFavorLevel = 4;
	}
}
