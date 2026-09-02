using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EB4 RID: 7860
public class ActivityTagInfoHelpView : UiViewBase, IExtraUiPopFrameType
{
	// Token: 0x170011D6 RID: 4566
	// (get) Token: 0x0600E87C RID: 59516 RVA: 0x003EDD7B File Offset: 0x003EBF7B
	[Nullable(1)]
	private new int[] OpenParam
	{
		[NullableContext(1)]
		get
		{
			return this.OpenParam as int[];
		}
	}

	// Token: 0x0600E87D RID: 59517 RVA: 0x003EDD88 File Offset: 0x003EBF88
	[NullableContext(1)]
	public ActivityTagInfoHelpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E87E RID: 59518 RVA: 0x003EDD94 File Offset: 0x003EBF94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E87F RID: 59519 RVA: 0x003EDE40 File Offset: 0x003EC040
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityTagInfoHelpView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityTagInfoHelpView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E880 RID: 59520 RVA: 0x003EDE83 File Offset: 0x003EC083
	protected override void OnStart()
	{
		this.Init();
	}

	// Token: 0x0600E881 RID: 59521 RVA: 0x003EDE8B File Offset: 0x003EC08B
	[NullableContext(2)]
	public EUiBehaviourPopType? GetExtraPopFrameType(object param)
	{
		return new EUiBehaviourPopType?(EUiBehaviourPopType.Middle);
	}

	// Token: 0x0600E882 RID: 59522 RVA: 0x003EDE94 File Offset: 0x003EC094
	private void Init()
	{
		int[] openParam = this.OpenParam;
		if (openParam == null || openParam.Length != 2)
		{
			Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.YYZ, "ActivityTagInfoHelpView.Init.OpenParams.Length != 2", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int num = openParam[0];
		int num2 = openParam[1];
		if (num <= 0)
		{
			base.GetItem(2).SetUIActive(false);
		}
		else
		{
			ActivityTitleTags? activityTitleTags = ConfigBase<ActivityConfig>.Instance.GetActivityTitleTags(num);
			if (activityTitleTags == null || string.IsNullOrEmpty(activityTitleTags.Value.DescInTip))
			{
				base.GetItem(2).SetUIActive(false);
				return;
			}
			base.GetItem(2).SetUIActive(true);
			this.InfoItem1.SetView(activityTitleTags.Value);
		}
		if (num2 <= 0)
		{
			base.GetItem(3).SetUIActive(false);
			return;
		}
		ActivityTitleTags? activityTitleTags2 = ConfigBase<ActivityConfig>.Instance.GetActivityTitleTags(num2);
		if (activityTitleTags2 == null || string.IsNullOrEmpty(activityTitleTags2.Value.DescInTip))
		{
			base.GetItem(3).SetUIActive(false);
			return;
		}
		base.GetItem(3).SetUIActive(true);
		this.InfoItem2.SetView(activityTitleTags2.Value);
	}

	// Token: 0x04007003 RID: 28675
	[Nullable(2)]
	private ActivityTagInfoItem InfoItem1;

	// Token: 0x04007004 RID: 28676
	[Nullable(2)]
	private ActivityTagInfoItem InfoItem2;

	// Token: 0x020081F9 RID: 33273
	private enum EComponents
	{
		// Token: 0x0402C17A RID: 180602
		ScrollView,
		// Token: 0x0402C17B RID: 180603
		Content,
		// Token: 0x0402C17C RID: 180604
		ExplanationItem1,
		// Token: 0x0402C17D RID: 180605
		ExplanationItem2
	}
}
