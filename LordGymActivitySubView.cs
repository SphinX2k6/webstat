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

// Token: 0x0200136E RID: 4974
[NullableContext(2)]
[Nullable(0)]
public class LordGymActivitySubView : ActivitySubViewBase
{
	// Token: 0x17000B82 RID: 2946
	// (get) Token: 0x06008862 RID: 34914 RVA: 0x0023F6DB File Offset: 0x0023D8DB
	protected new LordGymActivityData ActivityBaseData
	{
		get
		{
			return this.ActivityBaseData as LordGymActivityData;
		}
	}

	// Token: 0x06008863 RID: 34915 RVA: 0x0023F6E8 File Offset: 0x0023D8E8
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

	// Token: 0x06008864 RID: 34916 RVA: 0x0023F754 File Offset: 0x0023D954
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymActivitySubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymActivitySubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008865 RID: 34917 RVA: 0x0023F798 File Offset: 0x0023D998
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

	// Token: 0x06008866 RID: 34918 RVA: 0x0023F81C File Offset: 0x0023DA1C
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
		ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(3924, 0, null);
	}

	// Token: 0x04004011 RID: 16401
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x04004012 RID: 16402
	protected LordGymBossCard BossCard;

	// Token: 0x02007716 RID: 30486
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029036 RID: 167990
		public const int CommonActionInfo = 0;

		// Token: 0x04029037 RID: 167991
		public const int BossCard = 1;
	}
}
