using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002691 RID: 9873
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewTipsView : UiTickViewBase
{
	// Token: 0x0601378A RID: 79754 RVA: 0x0056D517 File Offset: 0x0056B717
	public QuestReviewTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601378B RID: 79755 RVA: 0x0056D520 File Offset: 0x0056B720
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601378C RID: 79756 RVA: 0x0056D62C File Offset: 0x0056B82C
	protected override UniTask OnBeforeStartAsync()
	{
		QuestReviewTipsView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestReviewTipsView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601378D RID: 79757 RVA: 0x0056D670 File Offset: 0x0056B870
	protected override void OnStart()
	{
		IQuestReviewTipsParam questReviewTipsParam = this.OpenParam as IQuestReviewTipsParam;
		this.EntryData = ((questReviewTipsParam == null) ? null : ModelBase<QuestReviewModel>.Instance.GetQuestReviewEntryDataById(questReviewTipsParam.EntryId));
		this.CountDownTime = 0f;
		this.StartTick = false;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "StoryReview_Tips_Content", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "StoryReview_Tips_Title", Array.Empty<object>());
		this.UiViewSequence.AddSequenceFinishEvent("StartTips", new Action<string>(this.OnStartSeqFinish), false);
		this.UiViewSequence.AddSequenceFinishEvent("CloseTips", new Action<string>(this.OnCloseSeqFinish), false);
	}

	// Token: 0x0601378E RID: 79758 RVA: 0x0056D728 File Offset: 0x0056B928
	protected override void OnAfterShow()
	{
		this.UiViewSequence.PlaySequence("StartTips", false, null);
	}

	// Token: 0x0601378F RID: 79759 RVA: 0x0056D750 File Offset: 0x0056B950
	protected override void OnTick(float delta)
	{
		if (this.EntryData == null || !this.StartTick)
		{
			return;
		}
		if (this.CountDownTime >= this.EntryData.TimerDurationMs)
		{
			this.UiViewSequence.PlaySequence("CloseTips", true, null);
			this.StartTick = false;
			return;
		}
		UUISprite sprite = base.GetSprite(3);
		this.CountDownTime += delta;
		float num = Math.Max(this.EntryData.TimerDurationMs - this.CountDownTime, 0f);
		if (sprite == null)
		{
			return;
		}
		sprite.SetFillAmount(num / this.EntryData.TimerDurationMs);
	}

	// Token: 0x06013790 RID: 79760 RVA: 0x0056D7EC File Offset: 0x0056B9EC
	private void OnClick()
	{
		if (this.EntryData == null)
		{
			return;
		}
		ControllerBase<QuestReviewController>.Instance.OpenQuestReview(this.EntryData.Id, true);
		this.UiViewSequence.PlaySequence("CloseTips", true, null);
	}

	// Token: 0x06013791 RID: 79761 RVA: 0x0056D834 File Offset: 0x0056BA34
	private void OnStartSeqFinish(string _)
	{
		this.UiViewSequence.PlaySequence("StartAtOnce", false, null);
		this.StartTick = true;
	}

	// Token: 0x06013792 RID: 79762 RVA: 0x0056D862 File Offset: 0x0056BA62
	private void OnCloseSeqFinish(string _)
	{
		this.StartTick = false;
		base.CloseMe(null);
	}

	// Token: 0x040097BB RID: 38843
	[Nullable(2)]
	private QuestReviewEntryData EntryData;

	// Token: 0x040097BC RID: 38844
	private float CountDownTime;

	// Token: 0x040097BD RID: 38845
	private bool StartTick;

	// Token: 0x02008A38 RID: 35384
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402E9B9 RID: 190905
		public const int TextName = 0;

		// Token: 0x0402E9BA RID: 190906
		public const int SpriteIcon = 1;

		// Token: 0x0402E9BB RID: 190907
		public const int ButtonTips = 2;

		// Token: 0x0402E9BC RID: 190908
		public const int SpriteTimeBar = 3;

		// Token: 0x0402E9BD RID: 190909
		public const int TextTitle = 4;
	}
}
