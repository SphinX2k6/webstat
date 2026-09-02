using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FlagChallenge;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FlagChallenge
{
	// Token: 0x0200677D RID: 26493
	public class ActivityFlagChallengeData : ActivityBaseData
	{
		// Token: 0x060420B5 RID: 270517 RVA: 0x010F20E0 File Offset: 0x010F02E0
		[NullableContext(1)]
		protected unsafe override void PhraseEx(ActivityData data)
		{
			FlagChallengeActivityInfo flagChallengeActivityInfo = data.FlagChallengeActivityInfo;
			if (flagChallengeActivityInfo == null)
			{
				return;
			}
			int id = data.Id;
			ModelBase<FlagChallengeModel>.Instance.ParseActivityData(id, flagChallengeActivityInfo);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, id);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FlagChallenge;
			ELogAuthor author = ELogAuthor.LJS;
			string message = "Activity Data PhraseEx";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", data.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("data", flagChallengeActivityInfo);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x060420B6 RID: 270518 RVA: 0x010F217C File Offset: 0x010F037C
		public override bool GetExDataRedPointShowState()
		{
			return ModelBase<FlagChallengeModel>.Instance.CheckActivityTabRedoDotState(base.Id);
		}

		// Token: 0x060420B7 RID: 270519 RVA: 0x010F2190 File Offset: 0x010F0390
		protected override bool GetExDataFinishShowState()
		{
			if (!base.IsUnLock())
			{
				return false;
			}
			FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(base.Id);
			return flagChallengeData.IsAllTaskReceived() && flagChallengeData.IsAllLevelPass();
		}
	}
}
