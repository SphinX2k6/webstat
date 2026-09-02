using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001374 RID: 4980
[NullableContext(2)]
[Nullable(0)]
public class LordGymThird5ActivitySubView : ActivitySubViewBase
{
	// Token: 0x17000B83 RID: 2947
	// (get) Token: 0x0600887F RID: 34943 RVA: 0x0023FF34 File Offset: 0x0023E134
	protected new LordGymActivityData ActivityBaseData
	{
		get
		{
			return this.ActivityBaseData as LordGymActivityData;
		}
	}

	// Token: 0x06008880 RID: 34944 RVA: 0x0023FF44 File Offset: 0x0023E144
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06008881 RID: 34945 RVA: 0x0023FFB0 File Offset: 0x0023E1B0
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymThird5ActivitySubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymThird5ActivitySubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008882 RID: 34946 RVA: 0x0023FFF4 File Offset: 0x0023E1F4
	protected override void OnRefreshView()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityBaseData.Id);
		this.CommonInfoPanel.SetFunctionRedDotVisible(this.ActivityBaseData.CheckRedDot());
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.RefreshView();
		}
		List<int> lordGymEntranceWithNewTag = ModelBase<LordGymModel>.Instance.GetLordGymEntranceWithNewTag();
		if (lordGymEntranceWithNewTag.Count == 0)
		{
			base.GetItem(1).SetUIActive(false);
			return;
		}
		LordGymBossCard bossCard = this.BossCard;
		if (bossCard == null)
		{
			return;
		}
		bossCard.Refresh(lordGymEntranceWithNewTag);
	}

	// Token: 0x06008883 RID: 34947 RVA: 0x00240078 File Offset: 0x0023E278
	private void OnConfirmBtnClick(ActivityBaseData _)
	{
		this.ActivityBaseData.ReadRedDot();
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityBaseData.GetUnFinishPreGuideQuestId(), null);
			return;
		}
		if (ModelBase<OnlineModel>.Instance.GetIsTeamModel())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_600064_Text", Array.Empty<object>());
			return;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_200172_Text", Array.Empty<object>());
			return;
		}
		ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(3925, 0, null);
	}

	// Token: 0x04004028 RID: 16424
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x04004029 RID: 16425
	protected LordGymBossCard BossCard;

	// Token: 0x0200771A RID: 30490
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04029045 RID: 168005
		CommonActionInfo,
		// Token: 0x04029046 RID: 168006
		BossCard
	}
}
