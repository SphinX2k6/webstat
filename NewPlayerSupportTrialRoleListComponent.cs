using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200147A RID: 5242
[NullableContext(1)]
[Nullable(0)]
public class NewPlayerSupportTrialRoleListComponent : UiPanelBase
{
	// Token: 0x060092B7 RID: 37559 RVA: 0x0026B47D File Offset: 0x0026967D
	public NewPlayerSupportTrialRoleListComponent(NewPlayerSupportTrialRoleViewModel viewModel)
	{
		this.ViewModel = viewModel;
	}

	// Token: 0x060092B8 RID: 37560 RVA: 0x0026B498 File Offset: 0x00269698
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
	}

	// Token: 0x060092B9 RID: 37561 RVA: 0x0026B578 File Offset: 0x00269778
	protected override UniTask OnBeforeStartAsync()
	{
		NewPlayerSupportTrialRoleListComponent.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<NewPlayerSupportTrialRoleListComponent.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060092BA RID: 37562 RVA: 0x0026B5BC File Offset: 0x002697BC
	private UniTask CreateRoleItem(UUIItem parent, TrialRoleGroupData trialRoleData)
	{
		NewPlayerSupportTrialRoleListComponent.<CreateRoleItem>d__9 <CreateRoleItem>d__;
		<CreateRoleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRoleItem>d__.<>4__this = this;
		<CreateRoleItem>d__.parent = parent;
		<CreateRoleItem>d__.trialRoleData = trialRoleData;
		<CreateRoleItem>d__.<>1__state = -1;
		<CreateRoleItem>d__.<>t__builder.Start<NewPlayerSupportTrialRoleListComponent.<CreateRoleItem>d__9>(ref <CreateRoleItem>d__);
		return <CreateRoleItem>d__.<>t__builder.Task;
	}

	// Token: 0x060092BB RID: 37563 RVA: 0x0026B610 File Offset: 0x00269810
	private void OnSelectRoleItem(NewPlayerSupportTrialRoleListItem roleItem, int groupId)
	{
		if (this.CurSelectRoleItem != null)
		{
			this.CurSelectRoleItem.SetSelected(false);
		}
		roleItem.SetSelected(true);
		this.CurSelectRoleItem = roleItem;
		Action<int> selectRoleItemCallback = this.SelectRoleItemCallback;
		if (selectRoleItemCallback != null)
		{
			selectRoleItemCallback(groupId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGroupTrialRoleRedDotUpdate);
	}

	// Token: 0x060092BC RID: 37564 RVA: 0x0026B661 File Offset: 0x00269861
	private bool CanSelectRoleItem()
	{
		return this.CanSelectRoleItemCallback == null || this.CanSelectRoleItemCallback();
	}

	// Token: 0x060092BD RID: 37565 RVA: 0x0026B678 File Offset: 0x00269878
	public void RefreshDefaultSelected(int? selectedGroupId = null)
	{
		NewPlayerSupportTrialRoleListComponent.<>c__DisplayClass12_0 CS$<>8__locals1 = new NewPlayerSupportTrialRoleListComponent.<>c__DisplayClass12_0();
		TrialRoleGroupData trialRoleGroupData = this.ViewModel.CurUseTrialRoleGroupData();
		NewPlayerSupportTrialRoleListComponent.<>c__DisplayClass12_0 CS$<>8__locals2 = CS$<>8__locals1;
		int? num = selectedGroupId;
		CS$<>8__locals2.groupId = ((num != null) ? num : ((trialRoleGroupData != null) ? new int?(trialRoleGroupData.TrialRoleGroupId) : null));
		List<TrialRoleGroupData> list = this.ViewModel.GetTrialRoleList() ?? new List<TrialRoleGroupData>();
		int num2 = -1;
		if (CS$<>8__locals1.groupId != null)
		{
			num2 = list.FindIndex((TrialRoleGroupData data) => data.TrialRoleGroupId == CS$<>8__locals1.groupId.Value);
		}
		if (num2 < 0)
		{
			num2 = list.FindIndex((TrialRoleGroupData data) => data.IsUnlocked());
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		NewPlayerSupportTrialRoleListItem newPlayerSupportTrialRoleListItem = (this.RoleItemList != null && num2 >= 0 && num2 < this.RoleItemList.Count) ? this.RoleItemList[num2] : null;
		if (newPlayerSupportTrialRoleListItem != null)
		{
			newPlayerSupportTrialRoleListItem.SelectItem();
		}
	}

	// Token: 0x060092BE RID: 37566 RVA: 0x0026B764 File Offset: 0x00269964
	public void SetSelectRoleItemCallback(Action<int> callback)
	{
		this.SelectRoleItemCallback = callback;
	}

	// Token: 0x060092BF RID: 37567 RVA: 0x0026B76D File Offset: 0x0026996D
	public void SetCanSelectRoleItemCallback(Func<bool> callback)
	{
		this.CanSelectRoleItemCallback = callback;
	}

	// Token: 0x040043DD RID: 17373
	private readonly List<NewPlayerSupportTrialRoleListItem> RoleItemList = new List<NewPlayerSupportTrialRoleListItem>();

	// Token: 0x040043DE RID: 17374
	[Nullable(2)]
	private NewPlayerSupportTrialRoleListItem CurSelectRoleItem;

	// Token: 0x040043DF RID: 17375
	[Nullable(2)]
	private Action<int> SelectRoleItemCallback;

	// Token: 0x040043E0 RID: 17376
	[Nullable(2)]
	private Func<bool> CanSelectRoleItemCallback;

	// Token: 0x040043E1 RID: 17377
	[Nullable(2)]
	private NewPlayerSupportTrialRoleViewModel ViewModel;

	// Token: 0x02007887 RID: 30855
	[NullableContext(0)]
	private static class EComponentType
	{
		// Token: 0x0402972B RID: 169771
		public const int RoleItem1 = 0;

		// Token: 0x0402972C RID: 169772
		public const int RoleItem2 = 1;

		// Token: 0x0402972D RID: 169773
		public const int RoleItem3 = 2;

		// Token: 0x0402972E RID: 169774
		public const int RoleItem4 = 3;

		// Token: 0x0402972F RID: 169775
		public const int RoleItem5 = 4;

		// Token: 0x04029730 RID: 169776
		public const int RoleItem6 = 5;

		// Token: 0x04029731 RID: 169777
		public const int RoleItem7 = 6;

		// Token: 0x04029732 RID: 169778
		public const int RoleItem8 = 7;

		// Token: 0x04029733 RID: 169779
		public const int RoleItem9 = 8;
	}
}
