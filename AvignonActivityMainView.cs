using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011CC RID: 4556
[NullableContext(1)]
[Nullable(0)]
public class AvignonActivityMainView : UiViewBase
{
	// Token: 0x06007831 RID: 30769 RVA: 0x001F7067 File Offset: 0x001F5267
	public AvignonActivityMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007832 RID: 30770 RVA: 0x001F7070 File Offset: 0x001F5270
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnQuestBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007833 RID: 30771 RVA: 0x001F717C File Offset: 0x001F537C
	protected override UniTask OnBeforeStartAsync()
	{
		AvignonActivityMainView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AvignonActivityMainView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007834 RID: 30772 RVA: 0x001F71BF File Offset: 0x001F53BF
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06007835 RID: 30773 RVA: 0x001F71C8 File Offset: 0x001F53C8
	private void OnQuestBtnClick()
	{
		UiManager instance = Singleton<UiManager>.Instance;
		EUiViewName questView = EUiViewName.QuestView;
		AvignonProtocolData avignonProtocolData = this.AvignonProtocolData;
		instance.OpenView(questView, (avignonProtocolData != null) ? avignonProtocolData.GetCurrentLockQuestId() : null, null);
	}

	// Token: 0x04003A13 RID: 14867
	protected AvignonProtocolData AvignonProtocolData;

	// Token: 0x04003A14 RID: 14868
	private PopupCaptionItem CaptionItem;

	// Token: 0x02007523 RID: 29987
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040286F1 RID: 165617
		public const int ItemCaption = 0;

		// Token: 0x040286F2 RID: 165618
		public const int ItemStage1 = 1;

		// Token: 0x040286F3 RID: 165619
		public const int ItemStage2 = 2;

		// Token: 0x040286F4 RID: 165620
		public const int ItemStage3 = 3;

		// Token: 0x040286F5 RID: 165621
		public const int BtnQuest = 4;
	}
}
