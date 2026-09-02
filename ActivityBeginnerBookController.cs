using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200124A RID: 4682
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityBeginnerBookController : ActivityControllerBase<ActivityBeginnerBookController>
{
	// Token: 0x06007CCB RID: 31947 RVA: 0x0020D9E1 File Offset: 0x0020BBE1
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06007CCC RID: 31948 RVA: 0x0020D9E4 File Offset: 0x0020BBE4
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06007CCD RID: 31949 RVA: 0x0020D9E6 File Offset: 0x0020BBE6
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_BeginnerBook";
	}

	// Token: 0x06007CCE RID: 31950 RVA: 0x0020D9ED File Offset: 0x0020BBED
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewBeginnerBook();
	}

	// Token: 0x06007CCF RID: 31951 RVA: 0x0020D9F4 File Offset: 0x0020BBF4
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.DataId = data.Id;
		return new ActivityBeginnerBookData();
	}

	// Token: 0x06007CD0 RID: 31952 RVA: 0x0020DA08 File Offset: 0x0020BC08
	public UniTask NewJourneyRequest()
	{
		ActivityBeginnerBookController.<NewJourneyRequest>d__6 <NewJourneyRequest>d__;
		<NewJourneyRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewJourneyRequest>d__.<>4__this = this;
		<NewJourneyRequest>d__.<>1__state = -1;
		<NewJourneyRequest>d__.<>t__builder.Start<ActivityBeginnerBookController.<NewJourneyRequest>d__6>(ref <NewJourneyRequest>d__);
		return <NewJourneyRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06007CD1 RID: 31953 RVA: 0x0020DA4B File Offset: 0x0020BC4B
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06007CD2 RID: 31954 RVA: 0x0020DA4E File Offset: 0x0020BC4E
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x04003BAE RID: 15278
	private int DataId;
}
