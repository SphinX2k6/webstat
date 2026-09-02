using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.UiComponent.UiHomeButton;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026C9 RID: 9929
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeMainView : UiTickViewBase
{
	// Token: 0x06013964 RID: 80228 RVA: 0x005774A5 File Offset: 0x005756A5
	public QuestTreeMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06013965 RID: 80229 RVA: 0x005774B0 File Offset: 0x005756B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickBtnPickUp));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickBtnTracking));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013966 RID: 80230 RVA: 0x00577640 File Offset: 0x00575840
	protected override UniTask OnBeforeStartAsync()
	{
		QuestTreeMainView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestTreeMainView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013967 RID: 80231 RVA: 0x00577684 File Offset: 0x00575884
	protected override void OnStart()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
		scrollViewWithScrollbar.OnScrollValueChange.Bind(new Action<FVector2D>(this.OnScrollValueChange));
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(0);
		if (scrollViewWithScrollbar2 != null)
		{
			scrollViewWithScrollbar2.SetCanScroll(false);
		}
		ModelBase<QuestTreeModel>.Instance.ViewModelMain.InitLocatingHelper(scrollViewWithScrollbar);
		base.GetButton(6).GetRootComponent().SetUIActive(false);
		this.RefreshTrackBtn();
		QuestTreeEnterLogEvent logData = new QuestTreeEnterLogEvent();
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x06013968 RID: 80232 RVA: 0x005776FC File Offset: 0x005758FC
	protected override void OnBeforeShow()
	{
		this.TickDefaultLocate = true;
		this.ScrollChapter.RefreshByData(ModelBase<QuestTreeModel>.Instance.ViewModelMain.GetViewDataList(), null, false);
		this.RefreshTrackBtn();
	}

	// Token: 0x06013969 RID: 80233 RVA: 0x00577727 File Offset: 0x00575927
	protected override void OnAfterShow()
	{
		this.LocateToDefaultNode(true);
		this.TickDefaultLocate = false;
	}

	// Token: 0x0601396A RID: 80234 RVA: 0x00577737 File Offset: 0x00575937
	protected override void OnBeforeDestroy()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.OnScrollValueChange.Unbind();
		}
		ModelBase<QuestTreeModel>.Instance.ViewModelMain.SetShouldLocateToDefaultNode(true);
		ModelBase<QuestTreeModel>.Instance.ViewModelMain.OnViewClose();
	}

	// Token: 0x0601396B RID: 80235 RVA: 0x0057776F File Offset: 0x0057596F
	protected override void OnTick(float delta)
	{
		if (!this.TickDefaultLocate)
		{
			return;
		}
		this.LocateToDefaultNode(false);
	}

	// Token: 0x0601396C RID: 80236 RVA: 0x00577781 File Offset: 0x00575981
	private void RefreshTrackBtn()
	{
		base.GetButton(7).GetRootComponent().SetUIActive(ModelBase<QuestTreeModel>.Instance.GetCurTrackingChapterData() != null);
	}

	// Token: 0x0601396D RID: 80237 RVA: 0x005777A4 File Offset: 0x005759A4
	private void LocateToDefaultNode(bool tween = true)
	{
		QuestTreeChapterData defaultLocatingNode = ModelBase<QuestTreeModel>.Instance.ViewModelMain.GetDefaultLocatingNode();
		if (defaultLocatingNode != null && ModelBase<QuestTreeModel>.Instance.ViewModelMain.ShouldLocateToDefaultNode)
		{
			ModelBase<QuestTreeModel>.Instance.ViewModelMain.LocateNode(defaultLocatingNode, tween);
		}
	}

	// Token: 0x0601396E RID: 80238 RVA: 0x005777E8 File Offset: 0x005759E8
	private void OnScrollValueChange(FVector2D value)
	{
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(4);
		float? num;
		if (horizontalLayout == null)
		{
			num = null;
		}
		else
		{
			UUIItem rootComponent = horizontalLayout.GetRootComponent();
			num = ((rootComponent != null) ? new float?(rootComponent.GetAnchorOffsetX()) : null);
		}
		float? num2 = num;
		float valueOrDefault = num2.GetValueOrDefault();
		float num3 = valueOrDefault - this.LastScrollOffsetX;
		this.LastScrollOffsetX = valueOrDefault;
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(0);
		TWeakObjectPtr<UUIItem>? tweakObjectPtr = (scrollViewWithScrollbar != null) ? new TWeakObjectPtr<UUIItem>?(scrollViewWithScrollbar.ContentUIItem) : null;
		float? num4;
		if (tweakObjectPtr == null)
		{
			num4 = null;
		}
		else
		{
			UUIItem uuiitem = tweakObjectPtr.GetValueOrDefault().Get();
			num4 = ((uuiitem != null) ? new float?(uuiitem.GetAnchorOffsetX()) : null);
		}
		num2 = num4;
		float valueOrDefault2 = num2.GetValueOrDefault();
		if (tweakObjectPtr != null)
		{
			UUIItem uuiitem2 = tweakObjectPtr.GetValueOrDefault().Get();
			if (uuiitem2 == null)
			{
				return;
			}
			uuiitem2.SetAnchorOffsetX(valueOrDefault2 + num3 * 0.2f);
		}
	}

	// Token: 0x0601396F RID: 80239 RVA: 0x005778DC File Offset: 0x00575ADC
	private void OnClickBtnPickUp()
	{
		List<QuestTreeNodeData> allAcceptableNodeList = ModelBase<QuestTreeModel>.Instance.GetAllAcceptableNodeList();
		if (allAcceptableNodeList.Count == 0)
		{
			return;
		}
		ControllerBase<QuestTreeController>.Instance.OpenAvailableListView(allAcceptableNodeList);
	}

	// Token: 0x06013970 RID: 80240 RVA: 0x00577908 File Offset: 0x00575B08
	private void OnClickBtnTracking()
	{
		QuestTreeChapterData curTrackingChapterData = ModelBase<QuestTreeModel>.Instance.GetCurTrackingChapterData();
		if (curTrackingChapterData != null)
		{
			ModelBase<QuestTreeModel>.Instance.ViewModelMain.LocateNode(curTrackingChapterData, true);
		}
	}

	// Token: 0x0400987D RID: 39037
	private GenericScrollViewNew<QuestTreeChapterGroupItem, List<QuestTreeChapterData>> ScrollChapter;

	// Token: 0x0400987E RID: 39038
	private PopupCaptionItem Caption;

	// Token: 0x0400987F RID: 39039
	private HomeBtnItem HomeBtn;

	// Token: 0x04009880 RID: 39040
	private float LastScrollOffsetX;

	// Token: 0x04009881 RID: 39041
	private const float BG_MOVEMENT_RATE = 0.2f;

	// Token: 0x04009882 RID: 39042
	private bool TickDefaultLocate;

	// Token: 0x02008A7D RID: 35453
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EB6B RID: 191339
		public const int ScrollBackground = 0;

		// Token: 0x0402EB6C RID: 191340
		public const int TextureBackground = 1;

		// Token: 0x0402EB6D RID: 191341
		public const int ItemCaption = 2;

		// Token: 0x0402EB6E RID: 191342
		public const int ScrollChapter = 3;

		// Token: 0x0402EB6F RID: 191343
		public const int LayoutContent = 4;

		// Token: 0x0402EB70 RID: 191344
		public const int ItemChapterGroup = 5;

		// Token: 0x0402EB71 RID: 191345
		public const int BtnPickUp = 6;

		// Token: 0x0402EB72 RID: 191346
		public const int BtnTracking = 7;
	}
}
