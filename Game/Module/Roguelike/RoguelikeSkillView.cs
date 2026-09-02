using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051AA RID: 20906
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeSkillView : UiViewBase
	{
		// Token: 0x06035C1E RID: 220190 RVA: 0x00D84DCF File Offset: 0x00D82FCF
		public RoguelikeSkillView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035C1F RID: 220191 RVA: 0x00D84DD8 File Offset: 0x00D82FD8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnSkillOverViewClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035C20 RID: 220192 RVA: 0x00D84F04 File Offset: 0x00D83104
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeSkillView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeSkillView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035C21 RID: 220193 RVA: 0x00D84F48 File Offset: 0x00D83148
		protected override void OnStart()
		{
			RoguelikeTalentTreeNodeData defaultSelectNode = this.Vm.GetDefaultSelectNode();
			this.OnClickNode(true, defaultSelectNode);
			this.ScrollToNode(defaultSelectNode, true);
		}

		// Token: 0x06035C22 RID: 220194 RVA: 0x00D84F72 File Offset: 0x00D83172
		protected override void OnBeforeDestroy()
		{
			ModelBase<RoguelikeModel>.Instance.ClearTalentTreeViewModel();
		}

		// Token: 0x06035C23 RID: 220195 RVA: 0x00D84F7E File Offset: 0x00D8317E
		protected RoguelikeTalentTreeNodeRowItem CreateRowItem()
		{
			return new RoguelikeTalentTreeNodeRowItem();
		}

		// Token: 0x06035C24 RID: 220196 RVA: 0x00D84F85 File Offset: 0x00D83185
		protected void OnBtnSkillOverViewClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeSkillOverView, null, null);
		}

		// Token: 0x06035C25 RID: 220197 RVA: 0x00D84F98 File Offset: 0x00D83198
		private UniTask ScrollToNode(RoguelikeTalentTreeNodeData node, bool tween = false)
		{
			RoguelikeSkillView.<ScrollToNode>d__12 <ScrollToNode>d__;
			<ScrollToNode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ScrollToNode>d__.<>4__this = this;
			<ScrollToNode>d__.node = node;
			<ScrollToNode>d__.tween = tween;
			<ScrollToNode>d__.<>1__state = -1;
			<ScrollToNode>d__.<>t__builder.Start<RoguelikeSkillView.<ScrollToNode>d__12>(ref <ScrollToNode>d__);
			return <ScrollToNode>d__.<>t__builder.Task;
		}

		// Token: 0x06035C26 RID: 220198 RVA: 0x00D84FEC File Offset: 0x00D831EC
		private void OnClickNode(bool isSelect, RoguelikeTalentTreeNodeData data)
		{
			if (!isSelect)
			{
				return;
			}
			if (this.Vm.CurSelectNode != null)
			{
				Action<bool, bool> setNodeToggleState = this.Vm.CurSelectNode.SetNodeToggleState;
				if (setNodeToggleState != null)
				{
					setNodeToggleState(false, false);
				}
			}
			this.Vm.SelectNode(data);
			Action<bool, bool> setNodeToggleState2 = data.SetNodeToggleState;
			if (setNodeToggleState2 != null)
			{
				setNodeToggleState2(true, false);
			}
			this.SkillDetailPanel.Refresh(data.Config);
		}

		// Token: 0x0401ED8F RID: 126351
		private RoguelikeTalentTreeViewModel Vm;

		// Token: 0x0401ED90 RID: 126352
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401ED91 RID: 126353
		[Nullable(2)]
		private RoguelikeSkillDetail SkillDetailPanel;

		// Token: 0x0401ED92 RID: 126354
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoguelikeTalentTreeNodeRowItem, RoguelikeTalentTreeNodeRowData> ScrollView;

		// Token: 0x0200B187 RID: 45447
		[NullableContext(0)]
		private class ERoguelikeSkillViewDefine
		{
			// Token: 0x040370DE RID: 225502
			public const int CaptionItem = 0;

			// Token: 0x040370DF RID: 225503
			public const int SkillDetailPanelItem = 1;

			// Token: 0x040370E0 RID: 225504
			public const int BtnSkillOverView = 2;

			// Token: 0x040370E1 RID: 225505
			public const int ScrollView = 3;

			// Token: 0x040370E2 RID: 225506
			public const int TalentContentItem = 4;

			// Token: 0x040370E3 RID: 225507
			public const int BtnMask = 5;
		}
	}
}
