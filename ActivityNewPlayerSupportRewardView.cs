using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001474 RID: 5236
public class ActivityNewPlayerSupportRewardView : UiViewBase
{
	// Token: 0x06009271 RID: 37489 RVA: 0x00269FC6 File Offset: 0x002681C6
	[NullableContext(1)]
	public ActivityNewPlayerSupportRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009272 RID: 37490 RVA: 0x00269FCF File Offset: 0x002681CF
	public ActivityNewPlayerSupportRewardView() : base(null)
	{
	}

	// Token: 0x06009273 RID: 37491 RVA: 0x00269FD8 File Offset: 0x002681D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnConfirmBtnClick)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnGotoBtnClick))
		};
	}

	// Token: 0x06009274 RID: 37492 RVA: 0x0026A09C File Offset: 0x0026829C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityNewPlayerSupportRewardView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityNewPlayerSupportRewardView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009275 RID: 37493 RVA: 0x0026A0DF File Offset: 0x002682DF
	protected override void OnStart()
	{
		this.RoleLayout = new GenericLayout<ActivityNewPlayerSupportRewardRoleItem, int>(base.GetHorizontalLayout(1), new Func<ActivityNewPlayerSupportRewardRoleItem>(this.CreateLayoutItem), null, false, true);
		this.RefreshRewardView();
	}

	// Token: 0x06009276 RID: 37494 RVA: 0x0026A108 File Offset: 0x00268308
	protected override void OnBeforeDestroy()
	{
		ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
	}

	// Token: 0x06009277 RID: 37495 RVA: 0x0026A114 File Offset: 0x00268314
	protected override void OnBeforePlayCloseSequence()
	{
		this.UiViewSequence.StopSequenceByKey("Switch", true, true);
	}

	// Token: 0x06009278 RID: 37496 RVA: 0x0026A128 File Offset: 0x00268328
	private void RefreshRewardView()
	{
		ActivityNewPlayerSupportRewardViewParam activityNewPlayerSupportRewardViewParam = this.OpenParam as ActivityNewPlayerSupportRewardViewParam;
		List<RewardItemData> itemList = activityNewPlayerSupportRewardViewParam.RewardData.GetItemList();
		if (itemList != null)
		{
			this.RewardItemList.Refresh(itemList, true);
		}
		this.RoleLayout.RefreshByData(new List<int>(activityNewPlayerSupportRewardViewParam.TrialRoleList), null, false);
		this.UiViewSequence.StartSequenceName = "Start01";
	}

	// Token: 0x06009279 RID: 37497 RVA: 0x0026A185 File Offset: 0x00268385
	[NullableContext(1)]
	private ActivityNewPlayerSupportRewardRoleItem CreateLayoutItem()
	{
		return new ActivityNewPlayerSupportRewardRoleItem();
	}

	// Token: 0x0600927A RID: 37498 RVA: 0x0026A18C File Offset: 0x0026838C
	private void OnConfirmBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600927B RID: 37499 RVA: 0x0026A198 File Offset: 0x00268398
	private void OnGotoBtnClick()
	{
		List<int> trialRoleList = (this.OpenParam as ActivityNewPlayerSupportRewardViewParam).TrialRoleList;
		int? trialRoleGroupId = ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleGroupId(trialRoleList[trialRoleList.Count - 1]);
		base.CloseMe(null);
		ActivityNewPlayerSupportController instance = ControllerBase<ActivityNewPlayerSupportController>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.OpenTrialRoleView(trialRoleGroupId);
	}

	// Token: 0x040043CA RID: 17354
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityNewPlayerSupportRewardRoleItem, int> RoleLayout;

	// Token: 0x040043CB RID: 17355
	[Nullable(2)]
	private RewardItemList RewardItemList;

	// Token: 0x02007873 RID: 30835
	private static class EComponentType
	{
		// Token: 0x040296CE RID: 169678
		public const int RewardItemListItem = 0;

		// Token: 0x040296CF RID: 169679
		public const int RoleLayout = 1;

		// Token: 0x040296D0 RID: 169680
		public const int RoleItem = 2;

		// Token: 0x040296D1 RID: 169681
		public const int ConfirmBtn = 3;

		// Token: 0x040296D2 RID: 169682
		public const int GotoBtn = 4;
	}
}
