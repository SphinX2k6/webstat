using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020015AB RID: 5547
[NullableContext(2)]
[Nullable(0)]
public class ActivitySevenDaySignData : ActivityBaseData
{
	// Token: 0x06009C54 RID: 40020 RVA: 0x0028F054 File Offset: 0x0028D254
	[NullableContext(1)]
	protected unsafe override void PhraseEx(ActivityData data)
	{
		this.DayRewardStateList = data.SignActivity.SignStateList.ToList<SignState>();
		this.RewardFreeIsGet = data.SignActivity.RewardFree;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[ActivitySevenDaySign][Phrase]签到活动签到状态打印";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActivityId", base.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SignStateList", this.DayRewardStateList);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, base.Id);
	}

	// Token: 0x06009C55 RID: 40021 RVA: 0x0028F103 File Offset: 0x0028D303
	protected override bool GetExDataFinishShowState()
	{
		return this.IsAllSignRewardReceived();
	}

	// Token: 0x06009C56 RID: 40022 RVA: 0x0028F10B File Offset: 0x0028D30B
	public bool IsAllSignRewardReceived()
	{
		if (this.DayRewardStateList == null)
		{
			return false;
		}
		return !this.DayRewardStateList.Any((SignState state) => state != SignState.IsReceive);
	}

	// Token: 0x06009C57 RID: 40023 RVA: 0x0028F144 File Offset: 0x0028D344
	public override bool GetExDataRedPointShowState()
	{
		using (List<SignState>.Enumerator enumerator = this.DayRewardStateList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == SignState.Unlock)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06009C58 RID: 40024 RVA: 0x0028F19C File Offset: 0x0028D39C
	[NullableContext(1)]
	public unsafe void UpdateActivityData(SignActivitySignStateNotify notify)
	{
		this.DayRewardStateList[notify.Index] = notify.SignState;
		this.CheckGrandRewardRefresh(notify.Index);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[ActivitySevenDaySign][UpdateData]签到活动签到状态改变";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActivityId", base.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SignIndex", notify.Index);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SignState", notify.SignState);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("SignStateList", this.DayRewardStateList);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
	}

	// Token: 0x06009C59 RID: 40025 RVA: 0x0028F278 File Offset: 0x0028D478
	public void CheckGrandRewardRefresh(int day)
	{
		ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(base.Id);
		if (activitySignById == null || activitySignById.Value.GrandRewardIdLength <= 0)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < activitySignById.Value.GrandRewardIdLength; i++)
		{
			ActivitySignGrandReward? byId = ConfigBase<ActivitySignGrandRewardConfig>.Instance.GetById(activitySignById.Value.GrandRewardId(i));
			if (byId != null && byId.Value.GrandRewardIndex - 1 == day)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.ActivitySignGrandRewardRefresh);
		}
	}

	// Token: 0x06009C5A RID: 40026 RVA: 0x0028F320 File Offset: 0x0028D520
	public void SetRewardToGotState(int day)
	{
		this.DayRewardStateList[day] = SignState.IsReceive;
	}

	// Token: 0x06009C5B RID: 40027 RVA: 0x0028F330 File Offset: 0x0028D530
	public OneItemConfig[] GetRewardByDay(int day)
	{
		OneItemConfig? activityRewardByDay = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivityRewardByDay(base.Id, day);
		if (activityRewardByDay == null)
		{
			return null;
		}
		return new OneItemConfig[]
		{
			activityRewardByDay.Value
		};
	}

	// Token: 0x06009C5C RID: 40028 RVA: 0x0028F370 File Offset: 0x0028D570
	public string GetBigRewardIcon(int actId)
	{
		ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(actId);
		if (activitySignById == null)
		{
			return null;
		}
		return activitySignById.GetValueOrDefault().ImportantRewardIcon;
	}

	// Token: 0x06009C5D RID: 40029 RVA: 0x0028F3A3 File Offset: 0x0028D5A3
	public SignState? GetRewardStateByDay(int day)
	{
		return new SignState?(this.DayRewardStateList[day]);
	}

	// Token: 0x06009C5E RID: 40030 RVA: 0x0028F3B8 File Offset: 0x0028D5B8
	public int GetImportantItemIndex()
	{
		ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(base.Id);
		if (activitySignById != null)
		{
			return activitySignById.Value.ImportantRewardIndex;
		}
		return 0;
	}

	// Token: 0x06009C5F RID: 40031 RVA: 0x0028F3F0 File Offset: 0x0028D5F0
	public int GetImportantRewardType()
	{
		ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(base.Id);
		if (activitySignById == null)
		{
			return 0;
		}
		return activitySignById.Value.ImportantRewardType;
	}

	// Token: 0x06009C60 RID: 40032 RVA: 0x0028F428 File Offset: 0x0028D628
	public void SetFreeRewardIsGet(bool value)
	{
		this.RewardFreeIsGet = value;
	}

	// Token: 0x06009C61 RID: 40033 RVA: 0x0028F431 File Offset: 0x0028D631
	public bool GetFreeRewardIsGet()
	{
		return this.RewardFreeIsGet;
	}

	// Token: 0x040047ED RID: 18413
	private List<SignState> DayRewardStateList;

	// Token: 0x040047EE RID: 18414
	private bool RewardFreeIsGet;
}
