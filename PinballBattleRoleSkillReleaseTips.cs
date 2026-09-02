using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D6D RID: 7533
[NullableContext(1)]
[Nullable(0)]
public class PinballBattleRoleSkillReleaseTips : PinballBattleTipsBase
{
	// Token: 0x0600DD9C RID: 56732 RVA: 0x003B96DA File Offset: 0x003B78DA
	public PinballBattleRoleSkillReleaseTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DD9D RID: 56733 RVA: 0x003B96F0 File Offset: 0x003B78F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DD9E RID: 56734 RVA: 0x003B975C File Offset: 0x003B795C
	protected override UniTask OnBeforeStartAsync()
	{
		PinballBattleRoleSkillReleaseTips.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PinballBattleRoleSkillReleaseTips.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DD9F RID: 56735 RVA: 0x003B979F File Offset: 0x003B799F
	public void AddNewRole(int roleId)
	{
		if (!this.TryAddRoleId(roleId))
		{
			return;
		}
		if (this.RootItem == null)
		{
			return;
		}
		GenericLayout<PinballBattleRoleSkillTipsItem, int> roleSkillItemLayout = this.RoleSkillItemLayout;
		if (roleSkillItemLayout != null)
		{
			roleSkillItemLayout.RefreshByData(this.RoleIdList, null, false);
		}
		base.ResetCloseTimer();
	}

	// Token: 0x0600DDA0 RID: 56736 RVA: 0x003B97D3 File Offset: 0x003B79D3
	private bool TryAddRoleId(int roleId)
	{
		if (this.RoleIdList.Contains(roleId))
		{
			return false;
		}
		this.RoleIdList.Add(roleId);
		return true;
	}

	// Token: 0x0600DDA1 RID: 56737 RVA: 0x003B97F4 File Offset: 0x003B79F4
	protected override UniTask OnBeforeHideAsync()
	{
		PinballBattleRoleSkillReleaseTips.<OnBeforeHideAsync>d__7 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<PinballBattleRoleSkillReleaseTips.<OnBeforeHideAsync>d__7>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DDA2 RID: 56738 RVA: 0x003B9838 File Offset: 0x003B7A38
	protected override void OnBeforeHide()
	{
		PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
		PinballBattleSubModel model = pinballBattleSubController.GetModel();
		foreach (int roleId in this.RoleIdList)
		{
			int? roleSlotIndex = model.GetRoleSlotIndex(roleId);
			if (roleSlotIndex != null)
			{
				pinballBattleSubController.OnInputUseSkill(roleSlotIndex.Value, 0);
			}
		}
	}

	// Token: 0x04006A68 RID: 27240
	private readonly List<int> RoleIdList = new List<int>();

	// Token: 0x04006A69 RID: 27241
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PinballBattleRoleSkillTipsItem, int> RoleSkillItemLayout;
}
