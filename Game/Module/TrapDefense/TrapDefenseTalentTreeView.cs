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

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E57 RID: 20055
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseTalentTreeView : UiTickViewBase
	{
		// Token: 0x06033D29 RID: 212265 RVA: 0x00CF56E6 File Offset: 0x00CF38E6
		public TrapDefenseTalentTreeView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06033D2A RID: 212266 RVA: 0x00CF56F0 File Offset: 0x00CF38F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033D2B RID: 212267 RVA: 0x00CF5864 File Offset: 0x00CF3A64
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseTalentTreeView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseTalentTreeView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D2C RID: 212268 RVA: 0x00CF58A8 File Offset: 0x00CF3AA8
		protected override void OnTick(float deltaTime)
		{
			if (!this.TryingScrollToNode)
			{
				return;
			}
			TrapDefenseTalentTreeNodeData selectedNode = ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.SelectedNode;
			if (selectedNode == null)
			{
				return;
			}
			if (this.CanScrollToNodeNow(selectedNode))
			{
				this.TryingScrollToNode = false;
				this.ScrollToNode(selectedNode, false);
			}
		}

		// Token: 0x06033D2D RID: 212269 RVA: 0x00CF58EC File Offset: 0x00CF3AEC
		protected override void OnStart()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.AddDelegateOnNodeSelect(new Action<TrapDefenseTalentTreeNodeData, bool>(this.OnNodeSelect));
			TrapDefenseTalentTreeNodeData defaultSelectNode = this.GetDefaultSelectNode();
			ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.SelectNode(defaultSelectNode, true);
		}

		// Token: 0x06033D2E RID: 212270 RVA: 0x00CF592C File Offset: 0x00CF3B2C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseTalentTreeUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x06033D2F RID: 212271 RVA: 0x00CF594A File Offset: 0x00CF3B4A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseTalentTreeUpdate, new Action(this.OnDataUpdate));
		}

		// Token: 0x06033D30 RID: 212272 RVA: 0x00CF5968 File Offset: 0x00CF3B68
		protected override void OnBeforeDestroy()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.RemoveDelegateOnNodeSelect(new Action<TrapDefenseTalentTreeNodeData, bool>(this.OnNodeSelect));
			ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.OnViewClose();
		}

		// Token: 0x06033D31 RID: 212273 RVA: 0x00CF5994 File Offset: 0x00CF3B94
		private UniTask RefreshTree()
		{
			TrapDefenseTalentTreeView.<RefreshTree>d__19 <RefreshTree>d__;
			<RefreshTree>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTree>d__.<>4__this = this;
			<RefreshTree>d__.<>1__state = -1;
			<RefreshTree>d__.<>t__builder.Start<TrapDefenseTalentTreeView.<RefreshTree>d__19>(ref <RefreshTree>d__);
			return <RefreshTree>d__.<>t__builder.Task;
		}

		// Token: 0x06033D32 RID: 212274 RVA: 0x00CF59D8 File Offset: 0x00CF3BD8
		private void RefreshBottomPanel()
		{
			TrapDefenseTalentTreeNodeData selectedNode = ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.SelectedNode;
			if (selectedNode == null)
			{
				this.ConfirmBtn.SetActive(false);
				base.GetItem(4).SetUIActive(false);
				base.GetItem(5).SetUIActive(false);
				return;
			}
			bool flag = ModelBase<TrapDefenseModel>.Instance.TalentTreeData.CanNodeUnlock(selectedNode);
			bool flag2 = ModelBase<TrapDefenseModel>.Instance.TalentTreeData.CanNodeAfford(selectedNode);
			base.GetItem(4).SetUIActive(!flag && !selectedNode.IsUnlock);
			base.GetItem(5).SetUIActive(selectedNode.IsUnlock);
			List<ICostData> costData = selectedNode.GetCostData();
			this.ConfirmBtn.SetEnableClick(flag2);
			this.ConfirmBtn.SetActive(!selectedNode.IsUnlock && flag);
			if (costData.Count > 0)
			{
				base.GetText(2).SetText(costData[0].Cost.ToString(), true);
			}
			UUIText text = base.GetText(2);
			UUIItem uuiitem = text;
			bool bUseChangeColor = !flag2;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x06033D33 RID: 212275 RVA: 0x00CF5AE8 File Offset: 0x00CF3CE8
		private void RefreshDetailPanel(bool playSeq = true)
		{
			this.SeqPlayer.StopSequenceByKey("Switch", false, false);
			if (playSeq)
			{
				this.SeqPlayer.PlayLevelSequenceByName("Switch", false, null, false);
			}
			this.NodeDetailPanel.Refresh();
		}

		// Token: 0x06033D34 RID: 212276 RVA: 0x00CF5B30 File Offset: 0x00CF3D30
		private void RefreshCurrency()
		{
			int talentTreeCurrencyItemId = ConfigBase<TrapDefenseConfig>.Instance.GetTalentTreeCurrencyItemId();
			int remainPoints = ModelBase<TrapDefenseModel>.Instance.TalentTreeData.RemainPoints;
			this.CostBtn.RefreshTemp(talentTreeCurrencyItemId, remainPoints.ToString());
		}

		// Token: 0x06033D35 RID: 212277 RVA: 0x00CF5B6C File Offset: 0x00CF3D6C
		private UniTask ScrollToNode(TrapDefenseTalentTreeNodeData node, bool tween = false)
		{
			TrapDefenseTalentTreeView.<ScrollToNode>d__23 <ScrollToNode>d__;
			<ScrollToNode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ScrollToNode>d__.<>4__this = this;
			<ScrollToNode>d__.node = node;
			<ScrollToNode>d__.tween = tween;
			<ScrollToNode>d__.<>1__state = -1;
			<ScrollToNode>d__.<>t__builder.Start<TrapDefenseTalentTreeView.<ScrollToNode>d__23>(ref <ScrollToNode>d__);
			return <ScrollToNode>d__.<>t__builder.Task;
		}

		// Token: 0x06033D36 RID: 212278 RVA: 0x00CF5BC0 File Offset: 0x00CF3DC0
		private TrapDefenseTalentTreeNodeData GetDefaultSelectNode()
		{
			ITrapDefenseTalentTreeViewParam trapDefenseTalentTreeViewParam = this.OpenParam as ITrapDefenseTalentTreeViewParam;
			TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData = null;
			if (trapDefenseTalentTreeViewParam != null && trapDefenseTalentTreeViewParam.TalentFuncType != null)
			{
				trapDefenseTalentTreeNodeData = ModelBase<TrapDefenseModel>.Instance.TalentTreeData.GetDefaultSelectNodeByFuncType(trapDefenseTalentTreeViewParam.TalentFuncType.Value);
			}
			if (trapDefenseTalentTreeViewParam == null || trapDefenseTalentTreeNodeData == null)
			{
				trapDefenseTalentTreeNodeData = ModelBase<TrapDefenseModel>.Instance.TalentTreeData.GetDefaultSelectNode();
			}
			return trapDefenseTalentTreeNodeData;
		}

		// Token: 0x06033D37 RID: 212279 RVA: 0x00CF5C24 File Offset: 0x00CF3E24
		private bool CanScrollToNodeNow(TrapDefenseTalentTreeNodeData node)
		{
			int num = Math.Max(node.Row - 1, 1);
			UUIItem itemByKey = this.ScrollTalents.GetItemByKey(num);
			return itemByKey != null && itemByKey.IsValid() && (num <= 1 || itemByKey.RelativeLocation.Y < -162f);
		}

		// Token: 0x06033D38 RID: 212280 RVA: 0x00CF5C78 File Offset: 0x00CF3E78
		private void OnConfirmUnlock(int index)
		{
			TrapDefenseTalentTreeNodeData selectedNode = ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.SelectedNode;
			if (selectedNode == null)
			{
				return;
			}
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseTechUnlock(selectedNode.Id);
		}

		// Token: 0x06033D39 RID: 212281 RVA: 0x00CF5CAA File Offset: 0x00CF3EAA
		private void OnNodeSelect(TrapDefenseTalentTreeNodeData node, bool shouldScroll)
		{
			this.RefreshBottomPanel();
			this.RefreshDetailPanel(true);
			if (shouldScroll)
			{
				this.TryingScrollToNode = true;
			}
		}

		// Token: 0x06033D3A RID: 212282 RVA: 0x00CF5CC3 File Offset: 0x00CF3EC3
		private void OnDataUpdate()
		{
			this.RefreshTree();
			this.RefreshBottomPanel();
			this.RefreshDetailPanel(false);
			this.RefreshCurrency();
		}

		// Token: 0x0401DFB0 RID: 122800
		private const int GRID_START_POS = -162;

		// Token: 0x0401DFB1 RID: 122801
		private PopupCaptionItem Caption;

		// Token: 0x0401DFB2 RID: 122802
		private ButtonItem ConfirmBtn;

		// Token: 0x0401DFB3 RID: 122803
		private TrapDefenseTalentTreeDetailPanel NodeDetailPanel;

		// Token: 0x0401DFB4 RID: 122804
		private CommonCurrencyItem CostBtn;

		// Token: 0x0401DFB5 RID: 122805
		private GenericScrollViewNew<TrapDefenseTalentTreeRowItem, TrapDefenseTalentTreeRowData> ScrollTalents;

		// Token: 0x0401DFB6 RID: 122806
		private TrapDefenseTalentLockItem LockPanel;

		// Token: 0x0401DFB7 RID: 122807
		private TrapDefenseTalentUnlockItem UnlockPanel;

		// Token: 0x0401DFB8 RID: 122808
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0401DFB9 RID: 122809
		private bool TryingScrollToNode;

		// Token: 0x0200ADF6 RID: 44534
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04036067 RID: 221287
			public const int ItemCaption = 0;

			// Token: 0x04036068 RID: 221288
			public const int ItemDetailPanel = 1;

			// Token: 0x04036069 RID: 221289
			public const int TextCost = 2;

			// Token: 0x0403606A RID: 221290
			public const int ItemConfirmBtn = 3;

			// Token: 0x0403606B RID: 221291
			public const int ItemLockPanel = 4;

			// Token: 0x0403606C RID: 221292
			public const int ItemUnlockPanel = 5;

			// Token: 0x0403606D RID: 221293
			public const int LayoutContent = 6;

			// Token: 0x0403606E RID: 221294
			public const int ItemRow = 7;

			// Token: 0x0403606F RID: 221295
			public const int ScrollTalents = 8;

			// Token: 0x04036070 RID: 221296
			public const int TextUpgrade = 9;
		}
	}
}
