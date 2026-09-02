using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002276 RID: 8822
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MoraleController : UiControllerBase<MoraleController>
{
	// Token: 0x06010AD6 RID: 68310 RVA: 0x00490E08 File Offset: 0x0048F008
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemNotify, new Action<IReadOnlyList<IProto_NormalItem>>(this.EventOnAddCommonItemNotify));
		Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.EventOnCommonItemCountRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnResponseCommonItemFinished, new Action(this.EventCommonItemFinished));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnMoraleActiveChanged, new Action<bool>(this.EventOnMoraleActiveChanged));
		Singleton<EventSystem>.Instance.Add<int, int, int, int>(EEventName.OnMoraleSumLevelChanged, new Action<int, int, int, int>(this.EventOnMoraleSumLevelChanged));
		Singleton<EventSystem>.Instance.Add<int, GameplayCue, bool, int>(EEventName.CharOnBuffAddShowMoraleBuffTips, new Action<int, GameplayCue, bool, int>(this.EventOnShowMoraleBuffTips));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OpenTreasureBox, new Action<int>(this.EventOpenTreasureBox));
	}

	// Token: 0x06010AD7 RID: 68311 RVA: 0x00490EDC File Offset: 0x0048F0DC
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemNotify, new Action<IReadOnlyList<IProto_NormalItem>>(this.EventOnAddCommonItemNotify));
		Singleton<EventSystem>.Instance.Remove<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.EventOnCommonItemCountRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResponseCommonItemFinished, new Action(this.EventCommonItemFinished));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnMoraleActiveChanged, new Action<bool>(this.EventOnMoraleActiveChanged));
		Singleton<EventSystem>.Instance.Remove<int, int, int, int>(EEventName.OnMoraleSumLevelChanged, new Action<int, int, int, int>(this.EventOnMoraleSumLevelChanged));
		Singleton<EventSystem>.Instance.Remove<int, GameplayCue, bool, int>(EEventName.CharOnBuffAddShowMoraleBuffTips, new Action<int, GameplayCue, bool, int>(this.EventOnShowMoraleBuffTips));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OpenTreasureBox, new Action<int>(this.EventOpenTreasureBox));
	}

	// Token: 0x06010AD8 RID: 68312 RVA: 0x00490FB0 File Offset: 0x0048F1B0
	public UniTask RequestProgressReward(int[] ids)
	{
		MoraleController.<RequestProgressReward>d__3 <RequestProgressReward>d__;
		<RequestProgressReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestProgressReward>d__.ids = ids;
		<RequestProgressReward>d__.<>1__state = -1;
		<RequestProgressReward>d__.<>t__builder.Start<MoraleController.<RequestProgressReward>d__3>(ref <RequestProgressReward>d__);
		return <RequestProgressReward>d__.<>t__builder.Task;
	}

	// Token: 0x06010AD9 RID: 68313 RVA: 0x00490FF4 File Offset: 0x0048F1F4
	public UniTask RequestGetPlayerMoraleAreaId()
	{
		MoraleController.<RequestGetPlayerMoraleAreaId>d__4 <RequestGetPlayerMoraleAreaId>d__;
		<RequestGetPlayerMoraleAreaId>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestGetPlayerMoraleAreaId>d__.<>1__state = -1;
		<RequestGetPlayerMoraleAreaId>d__.<>t__builder.Start<MoraleController.<RequestGetPlayerMoraleAreaId>d__4>(ref <RequestGetPlayerMoraleAreaId>d__);
		return <RequestGetPlayerMoraleAreaId>d__.<>t__builder.Task;
	}

	// Token: 0x06010ADA RID: 68314 RVA: 0x00491030 File Offset: 0x0048F230
	public UniTask RequestGetExplorerBoxTrackList(int areaId)
	{
		MoraleController.<RequestGetExplorerBoxTrackList>d__5 <RequestGetExplorerBoxTrackList>d__;
		<RequestGetExplorerBoxTrackList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestGetExplorerBoxTrackList>d__.areaId = areaId;
		<RequestGetExplorerBoxTrackList>d__.<>1__state = -1;
		<RequestGetExplorerBoxTrackList>d__.<>t__builder.Start<MoraleController.<RequestGetExplorerBoxTrackList>d__5>(ref <RequestGetExplorerBoxTrackList>d__);
		return <RequestGetExplorerBoxTrackList>d__.<>t__builder.Task;
	}

	// Token: 0x06010ADB RID: 68315 RVA: 0x00491073 File Offset: 0x0048F273
	private void EventOnMoraleActiveChanged(bool active)
	{
		if (active)
		{
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.InitData();
		}
	}

	// Token: 0x06010ADC RID: 68316 RVA: 0x00491088 File Offset: 0x0048F288
	private void EventOnMoraleSumLevelChanged(int oldLevel, int newLevel, int oldTemp, int newTemp)
	{
		if (oldLevel != newLevel)
		{
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			if (instance != null)
			{
				instance.CheckSumLevelChanged(oldLevel, newLevel);
			}
		}
		if (oldTemp == 0 && newTemp == 0)
		{
			return;
		}
		int num = Math.Max(oldLevel + oldTemp, newLevel);
		int num2 = newLevel + newTemp;
		if (num != num2)
		{
			MoraleModel instance2 = ModelBase<MoraleModel>.Instance;
			if (instance2 == null)
			{
				return;
			}
			instance2.CheckSumLevelChanged(num, num2);
		}
	}

	// Token: 0x06010ADD RID: 68317 RVA: 0x004910D8 File Offset: 0x0048F2D8
	private void EventOnAddCommonItemNotify(IReadOnlyList<IProto_NormalItem> commonItemList)
	{
		IProto_NormalItem proto_NormalItem = null;
		for (int i = 0; i < commonItemList.Count; i++)
		{
			IProto_NormalItem proto_NormalItem2 = commonItemList[i];
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			if (instance != null && instance.IsProgressScoreId(proto_NormalItem2.Id))
			{
				proto_NormalItem = proto_NormalItem2;
				break;
			}
		}
		if (proto_NormalItem != null)
		{
			ModelBase<MoraleModel>.Instance.CheckProgressScoreChange(proto_NormalItem.Id, proto_NormalItem.Count, null);
		}
	}

	// Token: 0x06010ADE RID: 68318 RVA: 0x0049113F File Offset: 0x0048F33F
	private void EventOnCommonItemCountRefresh(IProto_NormalItem item, int count, int lastCount)
	{
		MoraleModel instance = ModelBase<MoraleModel>.Instance;
		if (instance != null && instance.IsProgressScoreId(item.Id))
		{
			ModelBase<MoraleModel>.Instance.CheckProgressScoreChange(item.Id, count - lastCount, new int?(count));
		}
	}

	// Token: 0x06010ADF RID: 68319 RVA: 0x00491173 File Offset: 0x0048F373
	private void EventCommonItemFinished()
	{
		MoraleModel instance = ModelBase<MoraleModel>.Instance;
		if (instance != null && instance.IsInitData)
		{
			ModelBase<MoraleModel>.Instance.UpdateProgressScore();
		}
	}

	// Token: 0x06010AE0 RID: 68320 RVA: 0x00491194 File Offset: 0x0048F394
	private void EventOnShowMoraleBuffTips(int entityId, GameplayCue cue, bool isAdd, int handleId)
	{
		if (!isAdd || cue.Parameters(0) != "0")
		{
			return;
		}
		string text = (cue.ParametersLength > 1) ? cue.Parameters(1) : null;
		int num;
		if (!string.IsNullOrEmpty(text) && int.TryParse(text, out num) && num != 0)
		{
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.TryAddAreaBuffActiveState(num);
		}
	}

	// Token: 0x06010AE1 RID: 68321 RVA: 0x004911F4 File Offset: 0x0048F3F4
	private void EventOpenTreasureBox(int entityId)
	{
		MoraleModel instance = ModelBase<MoraleModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.CheckExplorerBoxOpen(entityId);
	}

	// Token: 0x0400836E RID: 33646
	private const string MORALE_CHARACTER_BUFF_TIPS_PARAM = "0";
}
