using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006827 RID: 26663
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingNormalTechView : UiTabViewBase
	{
		// Token: 0x060427B5 RID: 272309 RVA: 0x0110F454 File Offset: 0x0110D654
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060427B6 RID: 272310 RVA: 0x0110F5C8 File Offset: 0x0110D7C8
		protected override UniTask OnBeforeStartAsync()
		{
			FishingNormalTechView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingNormalTechView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060427B7 RID: 272311 RVA: 0x0110F60C File Offset: 0x0110D80C
		protected override void OnStart()
		{
			this.NodeAreaOneItem.OnClickToggleBack = new Action<IFishingTechNode, UUIExtendToggle>(this.OnClickItem);
			this.NodeAreaTwoItem.OnClickToggleBack = new Action<IFishingTechNode, UUIExtendToggle>(this.OnClickItem);
			this.NodeAreaThreeItem.OnClickToggleBack = new Action<IFishingTechNode, UUIExtendToggle>(this.OnClickItem);
			foreach (KeyValuePair<int, List<IFishingTechNode>> keyValuePair in ModelBase<FishingModel>.Instance.NormalTechNodeMap)
			{
				int num;
				List<IFishingTechNode> list;
				keyValuePair.Deconstruct(out num, out list);
				int num2 = num;
				List<IFishingTechNode> list2 = list;
				switch (num2)
				{
				case 1:
				{
					FishingTechAreaItem nodeAreaOneItem = this.NodeAreaOneItem;
					if (nodeAreaOneItem != null)
					{
						nodeAreaOneItem.RefreshNodeList(list2.ToArray());
					}
					break;
				}
				case 2:
				{
					FishingTechAreaItem nodeAreaTwoItem = this.NodeAreaTwoItem;
					if (nodeAreaTwoItem != null)
					{
						nodeAreaTwoItem.RefreshNodeList(list2.ToArray());
					}
					break;
				}
				case 3:
				{
					FishingTechAreaItem nodeAreaThreeItem = this.NodeAreaThreeItem;
					if (nodeAreaThreeItem != null)
					{
						nodeAreaThreeItem.RefreshNodeList(list2.ToArray());
					}
					break;
				}
				}
			}
			IFishingTechNode firstNode = ModelBase<FishingModel>.Instance.GetFirstNode();
			FishingTechNodeItem firstNodeItem = this.FirstNodeItem;
			if (firstNodeItem != null)
			{
				firstNodeItem.RefreshNode(firstNode);
			}
			IFishingTechNode lastNode = ModelBase<FishingModel>.Instance.GetLastNode();
			FishingTechNodeItem lastNodeItem = this.LastNodeItem;
			if (lastNodeItem != null)
			{
				lastNodeItem.RefreshNode(lastNode);
			}
			IFishingTechNode fishingTechNode;
			if (this.ExtraParams != null)
			{
				fishingTechNode = ModelBase<FishingModel>.Instance.GetNormalTechNodeById((int)this.ExtraParams);
			}
			else
			{
				fishingTechNode = ModelBase<FishingModel>.Instance.GetFirstUnlockNode();
			}
			if (fishingTechNode == null)
			{
				return;
			}
			if (fishingTechNode.Area == 0)
			{
				this.FirstNodeItem.SelectNode();
			}
			else if (fishingTechNode.Area == 4)
			{
				this.LastNodeItem.SelectNode();
			}
			else
			{
				FishingTechAreaItem nodeAreaOneItem2 = this.NodeAreaOneItem;
				if (nodeAreaOneItem2 != null)
				{
					nodeAreaOneItem2.FindAndSelectNode(fishingTechNode);
				}
				FishingTechAreaItem nodeAreaTwoItem2 = this.NodeAreaTwoItem;
				if (nodeAreaTwoItem2 != null)
				{
					nodeAreaTwoItem2.FindAndSelectNode(fishingTechNode);
				}
				FishingTechAreaItem nodeAreaThreeItem2 = this.NodeAreaThreeItem;
				if (nodeAreaThreeItem2 != null)
				{
					nodeAreaThreeItem2.FindAndSelectNode(fishingTechNode);
				}
			}
			if (fishingTechNode.Area >= 3)
			{
				base.GetScrollViewWithScrollbar(8).OnLateUpdate.Bind(delegate(float _)
				{
					TimerSystem.GameplayTimeInstance.Next(delegate(float _)
					{
						base.GetScrollViewWithScrollbar(8).ScrollTo(this.LastNodeItem.GetRootItem(), false);
					}, null, null);
					base.GetScrollViewWithScrollbar(8).OnLateUpdate.Unbind();
				});
			}
		}

		// Token: 0x060427B8 RID: 272312 RVA: 0x0110F810 File Offset: 0x0110DA10
		protected override void OnBeforeShow()
		{
			this.RefreshView();
		}

		// Token: 0x060427B9 RID: 272313 RVA: 0x0110F818 File Offset: 0x0110DA18
		private void RefreshView()
		{
			GenericLayout<FishingNormalTechCostItem, int> costLayout = this.CostLayout;
			if (costLayout == null)
			{
				return;
			}
			costLayout.RefreshByData(new <>z__ReadOnlyArray<int>(new int[]
			{
				38,
				37,
				29,
				30,
				31
			}), null, false);
		}

		// Token: 0x060427BA RID: 272314 RVA: 0x0110F844 File Offset: 0x0110DA44
		private void OnClickItem(IFishingTechNode node, UUIExtendToggle toggle)
		{
			if (this.LastSelectNodeId != 0)
			{
				if (!ModelBase<FishingModel>.Instance.GetFishingTechUnlock(this.LastSelectNodeId))
				{
					UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
					if (currentSelectToggle != null)
					{
						currentSelectToggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
					}
				}
				else
				{
					UUIExtendToggle currentSelectToggle2 = this.CurrentSelectToggle;
					if (currentSelectToggle2 != null)
					{
						currentSelectToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
					}
				}
			}
			else
			{
				UUIExtendToggle currentSelectToggle3 = this.CurrentSelectToggle;
				if (currentSelectToggle3 != null)
				{
					currentSelectToggle3.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
			}
			this.CurrentSelectToggle = toggle;
			this.LastSelectNodeId = node.ConfigId;
			FishingNormalTechViewLevelUpItem levelUpItem = this.LevelUpItem;
			if (levelUpItem != null)
			{
				levelUpItem.SetUiActive(true);
			}
			FishingNormalTechViewLevelUpItem levelUpItem2 = this.LevelUpItem;
			if (levelUpItem2 == null)
			{
				return;
			}
			levelUpItem2.RefreshView(node);
		}

		// Token: 0x060427BB RID: 272315 RVA: 0x0110F8E7 File Offset: 0x0110DAE7
		private FishingNormalTechCostItem InitItem()
		{
			return new FishingNormalTechCostItem();
		}

		// Token: 0x04025013 RID: 151571
		public const int TECH_NODE_AREA_ONE = 1;

		// Token: 0x04025014 RID: 151572
		public const int TECH_NODE_AREA_TWO = 2;

		// Token: 0x04025015 RID: 151573
		public const int TECH_NODE_AREA_THREE = 3;

		// Token: 0x04025016 RID: 151574
		private FishingTechNodeItem FirstNodeItem;

		// Token: 0x04025017 RID: 151575
		private FishingTechAreaItem NodeAreaOneItem;

		// Token: 0x04025018 RID: 151576
		private FishingTechAreaItem NodeAreaTwoItem;

		// Token: 0x04025019 RID: 151577
		private FishingTechAreaItem NodeAreaThreeItem;

		// Token: 0x0402501A RID: 151578
		private FishingTechNodeItem LastNodeItem;

		// Token: 0x0402501B RID: 151579
		private FishingNormalTechViewLevelUpItem LevelUpItem;

		// Token: 0x0402501C RID: 151580
		private GenericLayout<FishingNormalTechCostItem, int> CostLayout;

		// Token: 0x0402501D RID: 151581
		private UUIExtendToggle CurrentSelectToggle;

		// Token: 0x0402501E RID: 151582
		private int LastSelectNodeId;

		// Token: 0x0200C864 RID: 51300
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DAC4 RID: 252612
			public const int FirstNodeItem = 0;

			// Token: 0x0403DAC5 RID: 252613
			public const int NodeAreaOneItem = 1;

			// Token: 0x0403DAC6 RID: 252614
			public const int NodeAreaTwoItem = 2;

			// Token: 0x0403DAC7 RID: 252615
			public const int NodeAreaThreeItem = 3;

			// Token: 0x0403DAC8 RID: 252616
			public const int LastNodeItem = 4;

			// Token: 0x0403DAC9 RID: 252617
			public const int CostListLayout = 5;

			// Token: 0x0403DACA RID: 252618
			public const int CostItem = 6;

			// Token: 0x0403DACB RID: 252619
			public const int NodeLevelUpItem = 7;

			// Token: 0x0403DACC RID: 252620
			public const int ScrollView = 8;

			// Token: 0x0403DACD RID: 252621
			public const int ScrollViewContentItem = 9;
		}
	}
}
