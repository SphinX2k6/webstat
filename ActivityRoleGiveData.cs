using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001572 RID: 5490
public class ActivityRoleGiveData : ActivityBaseData
{
	// Token: 0x06009A1D RID: 39453 RVA: 0x00285AB4 File Offset: 0x00283CB4
	[NullableContext(1)]
	protected unsafe override void PhraseEx(ActivityData data)
	{
		TraceMoonPhaseData traceMoonPhaseData = data.TraceMoonPhaseData;
		ControllerBase<ActivityRoleGiveController>.Instance.CurrentActivityId = data.Id;
		if (traceMoonPhaseData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.MoonChasing, ELogAuthor.LPH, "ActivityRoleGiveData无数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.MoonChasing;
		ELogAuthor author = ELogAuthor.LPH;
		string message = "ActivityRoleGiveData Refresh:";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsGetReward:", traceMoonPhaseData.Reward);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActivityId:", data.Id);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.IsGetReward = traceMoonPhaseData.Reward;
	}

	// Token: 0x06009A1E RID: 39454 RVA: 0x00285B71 File Offset: 0x00283D71
	public TrackMoonPhaseActivity? GetExtraConfig()
	{
		return ConfigTrackMoonPhaseActivityById.GetConfig(ControllerBase<ActivityRoleGiveController>.Instance.CurrentActivityId, true);
	}

	// Token: 0x06009A1F RID: 39455 RVA: 0x00285B84 File Offset: 0x00283D84
	public override bool GetExDataRedPointShowState()
	{
		TrackMoonPhaseActivity? extraConfig = this.GetExtraConfig();
		MoonChasingModel instance = ModelBase<MoonChasingModel>.Instance;
		int? num = (instance != null) ? new int?(instance.GetPopularityValue()) : null;
		return num != null && extraConfig != null && !this.IsGetReward && num.Value >= extraConfig.Value.PopularityNeed;
	}

	// Token: 0x04004713 RID: 18195
	public bool IsGetReward;
}
