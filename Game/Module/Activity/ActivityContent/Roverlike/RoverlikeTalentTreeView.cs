using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200646E RID: 25710
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeTalentTreeView : UiViewBase
	{
		// Token: 0x060407DF RID: 264159 RVA: 0x01087070 File Offset: 0x01085270
		public RoverlikeTalentTreeView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060407E0 RID: 264160 RVA: 0x0108707C File Offset: 0x0108527C
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060407E1 RID: 264161 RVA: 0x01087148 File Offset: 0x01085348
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeTalentTreeView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeTalentTreeView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060407E2 RID: 264162 RVA: 0x0108718C File Offset: 0x0108538C
		protected override void OnStart()
		{
			if (this.TreeData == null)
			{
				return;
			}
			RoverlikeTalentNodeData defaultSelectNode = this.TreeData.GetDefaultSelectNode();
			if (defaultSelectNode != null)
			{
				this.OnClickNode(true, defaultSelectNode);
				this.ScrollToNode(defaultSelectNode, true).Forget();
			}
		}

		// Token: 0x060407E3 RID: 264163 RVA: 0x010871C6 File Offset: 0x010853C6
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeTalentUnlockDataUpdate, new Action(this.OnTalentUnlockDataUpdate));
		}

		// Token: 0x060407E4 RID: 264164 RVA: 0x010871E4 File Offset: 0x010853E4
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeTalentUnlockDataUpdate, new Action(this.OnTalentUnlockDataUpdate));
		}

		// Token: 0x060407E5 RID: 264165 RVA: 0x01087202 File Offset: 0x01085402
		protected override void OnBeforeDestroy()
		{
			RoverlikeTalentTreeData treeData = this.TreeData;
			if (treeData != null)
			{
				treeData.Reset();
			}
			this.TreeData = null;
		}

		// Token: 0x060407E6 RID: 264166 RVA: 0x0108721C File Offset: 0x0108541C
		private RoverlikeTalentTreeNodeRowItem CreateRowItem()
		{
			return new RoverlikeTalentTreeNodeRowItem();
		}

		// Token: 0x060407E7 RID: 264167 RVA: 0x01087224 File Offset: 0x01085424
		private UniTask ScrollToNode(RoverlikeTalentNodeData node, bool tween = false)
		{
			RoverlikeTalentTreeView.<ScrollToNode>d__13 <ScrollToNode>d__;
			<ScrollToNode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ScrollToNode>d__.<>4__this = this;
			<ScrollToNode>d__.node = node;
			<ScrollToNode>d__.tween = tween;
			<ScrollToNode>d__.<>1__state = -1;
			<ScrollToNode>d__.<>t__builder.Start<RoverlikeTalentTreeView.<ScrollToNode>d__13>(ref <ScrollToNode>d__);
			return <ScrollToNode>d__.<>t__builder.Task;
		}

		// Token: 0x060407E8 RID: 264168 RVA: 0x01087278 File Offset: 0x01085478
		private void OnClickNode(bool isSelect, RoverlikeTalentNodeData data)
		{
			if (!isSelect || this.TreeData == null)
			{
				return;
			}
			if (this.TreeData.CurSelectNode != null)
			{
				Action<bool, bool> setNodeToggleState = this.TreeData.CurSelectNode.SetNodeToggleState;
				if (setNodeToggleState != null)
				{
					setNodeToggleState(false, false);
				}
			}
			this.TreeData.SelectNode(data);
			Action<bool, bool> setNodeToggleState2 = data.SetNodeToggleState;
			if (setNodeToggleState2 != null)
			{
				setNodeToggleState2(true, false);
			}
			RoverlikeTalentTreeDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel == null)
			{
				return;
			}
			detailPanel.Refresh(data);
		}

		// Token: 0x060407E9 RID: 264169 RVA: 0x010872EB File Offset: 0x010854EB
		private void OnUnlockSuccess(RoverlikeTalentNodeData data)
		{
			if (this.TreeData == null)
			{
				return;
			}
			GenericScrollViewNew<RoverlikeTalentTreeNodeRowItem, RoverlikeTalentTreeNodeRowData> scrollView = this.ScrollView;
			if (scrollView == null)
			{
				return;
			}
			scrollView.RefreshByDataAsync(this.TreeData.RowDataList, false).Forget();
		}

		// Token: 0x060407EA RID: 264170 RVA: 0x01087318 File Offset: 0x01085518
		private void OnTalentUnlockDataUpdate()
		{
			if (this.TreeData == null)
			{
				return;
			}
			GenericScrollViewNew<RoverlikeTalentTreeNodeRowItem, RoverlikeTalentTreeNodeRowData> scrollView = this.ScrollView;
			if (scrollView != null)
			{
				scrollView.RefreshByDataAsync(this.TreeData.RowDataList, false).Forget();
			}
			if (this.TreeData.CurSelectNode != null)
			{
				RoverlikeTalentTreeDetailPanel detailPanel = this.DetailPanel;
				if (detailPanel == null)
				{
					return;
				}
				detailPanel.Refresh(this.TreeData.CurSelectNode);
			}
		}

		// Token: 0x04024198 RID: 147864
		[Nullable(2)]
		private RoverlikeTalentTreeData TreeData;

		// Token: 0x04024199 RID: 147865
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402419A RID: 147866
		[Nullable(2)]
		private RoverlikeTalentTreeDetailPanel DetailPanel;

		// Token: 0x0402419B RID: 147867
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoverlikeTalentTreeNodeRowItem, RoverlikeTalentTreeNodeRowData> ScrollView;

		// Token: 0x0200C4CA RID: 50378
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403C94A RID: 248138
			public const int CaptionItem = 0;

			// Token: 0x0403C94B RID: 248139
			public const int DetailPanelItem = 1;

			// Token: 0x0403C94C RID: 248140
			public const int ScrollView = 2;

			// Token: 0x0403C94D RID: 248141
			public const int TalentRowTemplateItem = 3;

			// Token: 0x0403C94E RID: 248142
			public const int BtnMask = 4;
		}
	}
}
