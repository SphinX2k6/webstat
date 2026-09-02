using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200134C RID: 4940
public class LifePointDrawEntranceView : UiViewBase
{
	// Token: 0x06008708 RID: 34568 RVA: 0x00238B63 File Offset: 0x00236D63
	[NullableContext(1)]
	public LifePointDrawEntranceView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008709 RID: 34569 RVA: 0x00238B78 File Offset: 0x00236D78
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600870A RID: 34570 RVA: 0x00238CEC File Offset: 0x00236EEC
	protected override UniTask OnBeforeStartAsync()
	{
		LifePointDrawEntranceView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LifePointDrawEntranceView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600870B RID: 34571 RVA: 0x00238D2F File Offset: 0x00236F2F
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600870C RID: 34572 RVA: 0x00238D38 File Offset: 0x00236F38
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		this.RefreshScrollPercentage();
	}

	// Token: 0x0600870D RID: 34573 RVA: 0x00238D48 File Offset: 0x00236F48
	public void RefreshView()
	{
		LifePointEntrance value = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointEntranceById(this.LifePointDrawActivityData.Id).Value;
		int groupListLength = value.GroupListLength;
		int count = this.LifePointItemList.Count;
		for (int i = 0; i < count; i++)
		{
			if (i < groupListLength)
			{
				this.LifePointItemList[i].RefreshView(value.GroupList(i), this.LifePointDrawActivityData);
				this.LifePointItemList[i].SetUiActive(true);
				this.LifePointItemList[i].PlaySequence("Start");
			}
			else
			{
				this.LifePointItemList[i].SetUiActive(false);
			}
		}
		this.RefreshProgressText();
	}

	// Token: 0x0600870E RID: 34574 RVA: 0x00238E04 File Offset: 0x00237004
	private void RefreshScrollPercentage()
	{
		LifePointEntrance value = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointEntranceById(this.LifePointDrawActivityData.Id).Value;
		int groupListLength = value.GroupListLength;
		int num = 0;
		for (int i = 0; i < groupListLength; i++)
		{
			if (!ModelBase<LifePointDrawModel>.Instance.GetGroupRewardState(this.LifePointDrawActivityData.Id, value.GroupList(i)))
			{
				num = i;
				break;
			}
		}
		UUIScrollViewWithScrollbarComponent scrollItem = base.GetScrollViewWithScrollbar(1);
		float percentage = (float)num / (float)groupListLength;
		if (percentage < 0f)
		{
			return;
		}
		Action<float> callback = delegate(float _)
		{
			scrollItem.SetScrollProgress(1f - percentage);
			scrollItem.OnLateUpdate.Unbind();
		};
		scrollItem.OnLateUpdate.Bind(callback);
	}

	// Token: 0x0600870F RID: 34575 RVA: 0x00238EBC File Offset: 0x002370BC
	private void RefreshProgressText()
	{
		string progressByActivityId = ModelBase<LifePointDrawModel>.Instance.GetProgressByActivityId(this.LifePointDrawActivityData.Id, "Colorful_Finish_Progress");
		UUIText text = base.GetText(9);
		if (text == null)
		{
			return;
		}
		text.SetText(progressByActivityId, true);
	}

	// Token: 0x04003FB3 RID: 16307
	[Nullable(2)]
	private LifePointDrawActivityData LifePointDrawActivityData;

	// Token: 0x04003FB4 RID: 16308
	[Nullable(1)]
	private readonly List<LifePointDrawItem> LifePointItemList = new List<LifePointDrawItem>();

	// Token: 0x04003FB5 RID: 16309
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x020076EE RID: 30446
	private class EComponent
	{
		// Token: 0x04028F53 RID: 167763
		public const int CaptionItem = 0;

		// Token: 0x04028F54 RID: 167764
		public const int ItemScroll = 1;

		// Token: 0x04028F55 RID: 167765
		public const int Point1 = 2;

		// Token: 0x04028F56 RID: 167766
		public const int Point2 = 3;

		// Token: 0x04028F57 RID: 167767
		public const int Point3 = 4;

		// Token: 0x04028F58 RID: 167768
		public const int Point4 = 5;

		// Token: 0x04028F59 RID: 167769
		public const int Point5 = 6;

		// Token: 0x04028F5A RID: 167770
		public const int Point6 = 7;

		// Token: 0x04028F5B RID: 167771
		public const int Point7 = 8;

		// Token: 0x04028F5C RID: 167772
		public const int ProgressText = 9;
	}
}
