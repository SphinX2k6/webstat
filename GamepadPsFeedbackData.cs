using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001DB5 RID: 7605
[NullableContext(1)]
[Nullable(0)]
public class GamepadPsFeedbackData
{
	// Token: 0x0600E070 RID: 57456 RVA: 0x003C568C File Offset: 0x003C388C
	public unsafe void AddFeedbackReason(EGamepadPsFeedbackReason reason, ETriggerEffectSide mode, string path)
	{
		GamepadPsFeedbackData.FeedbackInfo feedbackInfo;
		if (!this.FeedbackReasonSet.TryGetValue(reason, out feedbackInfo))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PsGamepadFeedback;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加Ps5手柄高级震动";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mode", mode.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("path", path);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			feedbackInfo = new GamepadPsFeedbackData.FeedbackInfo(reason, mode, path);
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.PsGamepadFeedback;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "刷新Ps5手柄高级震动";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("reason", reason.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("mode", mode.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("path", path);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			feedbackInfo.Mode = mode;
			feedbackInfo.Path = path;
		}
		this.FeedbackReasonSet[reason] = feedbackInfo;
	}

	// Token: 0x0600E071 RID: 57457 RVA: 0x003C57E4 File Offset: 0x003C39E4
	public bool RemoveFeedbackReason(EGamepadPsFeedbackReason reason)
	{
		bool flag = this.FeedbackReasonSet.Remove(reason);
		if (flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PsGamepadFeedback;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "移除Ps5手柄高级震动";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason.ToString());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return flag;
	}

	// Token: 0x0600E072 RID: 57458 RVA: 0x003C5838 File Offset: 0x003C3A38
	public void ClearFeedbackReason()
	{
		Singleton<Log>.Instance.Info(ELogModule.PsGamepadFeedback, ELogAuthor.XXJ, "清除Ps5手柄高级震动", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.FeedbackReasonSet.Clear();
	}

	// Token: 0x0600E073 RID: 57459 RVA: 0x003C586F File Offset: 0x003C3A6F
	[NullableContext(2)]
	public GamepadPsFeedbackData.FeedbackInfo GetLastFeedbackInfo()
	{
		if (this.FeedbackReasonSet.Count > 0)
		{
			return this.FeedbackReasonSet.Values.LastOrDefault<GamepadPsFeedbackData.FeedbackInfo>();
		}
		return null;
	}

	// Token: 0x04006BB3 RID: 27571
	private readonly SortedDictionary<EGamepadPsFeedbackReason, GamepadPsFeedbackData.FeedbackInfo> FeedbackReasonSet = new SortedDictionary<EGamepadPsFeedbackReason, GamepadPsFeedbackData.FeedbackInfo>();

	// Token: 0x0200815B RID: 33115
	[Nullable(0)]
	public class FeedbackInfo
	{
		// Token: 0x1700A834 RID: 43060
		// (get) Token: 0x06048486 RID: 296070 RVA: 0x0135DDA6 File Offset: 0x0135BFA6
		// (set) Token: 0x06048487 RID: 296071 RVA: 0x0135DDAE File Offset: 0x0135BFAE
		public EGamepadPsFeedbackReason Reason { get; set; }

		// Token: 0x1700A835 RID: 43061
		// (get) Token: 0x06048488 RID: 296072 RVA: 0x0135DDB7 File Offset: 0x0135BFB7
		// (set) Token: 0x06048489 RID: 296073 RVA: 0x0135DDBF File Offset: 0x0135BFBF
		public ETriggerEffectSide Mode { get; set; }

		// Token: 0x1700A836 RID: 43062
		// (get) Token: 0x0604848A RID: 296074 RVA: 0x0135DDC8 File Offset: 0x0135BFC8
		// (set) Token: 0x0604848B RID: 296075 RVA: 0x0135DDD0 File Offset: 0x0135BFD0
		public string Path { get; set; }

		// Token: 0x0604848C RID: 296076 RVA: 0x0135DDD9 File Offset: 0x0135BFD9
		public FeedbackInfo(EGamepadPsFeedbackReason reason, ETriggerEffectSide mode, string path)
		{
			this.Reason = reason;
			this.Mode = mode;
			this.Path = path;
		}
	}
}
