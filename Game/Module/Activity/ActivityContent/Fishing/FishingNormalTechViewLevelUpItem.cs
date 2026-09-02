using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006828 RID: 26664
	public class FishingNormalTechViewLevelUpItem : UiPanelBase
	{
		// Token: 0x060427BF RID: 272319 RVA: 0x0110F93C File Offset: 0x0110DB3C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickLevelUpBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060427C0 RID: 272320 RVA: 0x0110FB76 File Offset: 0x0110DD76
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFishingTechNodeRefresh, new Action<int>(this.OnFishingTechNodeRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.FishingTechViewComeBack, new Action(this.FishingTechViewComeBack));
		}

		// Token: 0x060427C1 RID: 272321 RVA: 0x0110FBB0 File Offset: 0x0110DDB0
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFishingTechNodeRefresh, new Action<int>(this.OnFishingTechNodeRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingTechViewComeBack, new Action(this.FishingTechViewComeBack));
		}

		// Token: 0x060427C2 RID: 272322 RVA: 0x0110FBEC File Offset: 0x0110DDEC
		protected override UniTask OnBeforeStartAsync()
		{
			FishingNormalTechViewLevelUpItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingNormalTechViewLevelUpItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060427C3 RID: 272323 RVA: 0x0110FC2F File Offset: 0x0110DE2F
		private void OnFishingTechNodeRefresh(int nodeId)
		{
			IFishingTechNode node = this.Node;
			if (node == null || node.ConfigId != nodeId)
			{
				IFishingTechNode node2 = this.Node;
				if (node2 == null || node2.PreNode != nodeId)
				{
					return;
				}
			}
			this.RefreshView(this.Node);
		}

		// Token: 0x060427C4 RID: 272324 RVA: 0x0110FC6B File Offset: 0x0110DE6B
		private void FishingTechViewComeBack()
		{
			if (this.Node != null)
			{
				this.RefreshView(this.Node);
			}
		}

		// Token: 0x060427C5 RID: 272325 RVA: 0x0110FC84 File Offset: 0x0110DE84
		[NullableContext(1)]
		public void RefreshView(IFishingTechNode node)
		{
			FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(node.ConfigId);
			this.Node = node;
			base.SetTextureByPath(fishingTechById.Icon, base.GetTexture(2), null, null);
			bool flag = this.Node.NodeType == EFishingTechNodeType.Core;
			base.GetItem(0).SetUIActive(flag);
			base.GetItem(1).SetUIActive(!flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), FishingDefine.fishingNodeTypeText[(int)node.NodeType], Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), fishingTechById.Name, Array.Empty<object>());
			int techNodeCurrentLevel = ModelBase<FishingModel>.Instance.GetTechNodeCurrentLevel(node.ConfigId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "PrefabTextItem_3692737534_Text", new <>z__ReadOnlySingleElementList<object>(techNodeCurrentLevel));
			int effectLength = fishingTechById.EffectLength;
			if (techNodeCurrentLevel >= effectLength)
			{
				base.GetItem(13).SetUIActive(false);
				base.GetItem(11).SetUIActive(true);
				base.GetItem(10).SetUIActive(false);
				base.GetButton(9).RootUIComp.Get().SetUIActive(false);
				int techEffectId = fishingTechById.Effect(effectLength - 1);
				FishingTechEffect fishingTechEffectById = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), fishingTechEffectById.Desc, fishingTechEffectById.ShowParams());
				FishingTechCostItem costItem = this.CostItem;
				if (costItem == null)
				{
					return;
				}
				costItem.SetUiActive(false);
				return;
			}
			else
			{
				base.GetItem(13).SetUIActive(true);
				base.GetItem(11).SetUIActive(false);
				bool nodePreNodeUnlock = ModelBase<FishingModel>.Instance.GetNodePreNodeUnlock(node.ConfigId);
				bool nodeLevelUpItemEnough = ModelBase<FishingModel>.Instance.GetNodeLevelUpItemEnough(node.ConfigId);
				base.GetItem(10).SetUIActive(!nodePreNodeUnlock || !nodeLevelUpItemEnough);
				if (!nodePreNodeUnlock)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "FishingTechLevelUpNotPreNodeLock", Array.Empty<object>());
				}
				else if (!nodeLevelUpItemEnough)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "FishingTechLevelUpNotEnough", Array.Empty<object>());
				}
				base.GetButton(9).RootUIComp.Get().SetUIActive(nodePreNodeUnlock && nodeLevelUpItemEnough);
				base.GetItem(11).SetUIActive(false);
				int techEffectId2 = fishingTechById.Effect(techNodeCurrentLevel);
				FishingTechEffect fishingTechEffectById2 = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId2);
				List<IFishingTechLevelUpItem> list = new List<IFishingTechLevelUpItem>();
				Dictionary<int, int> dictionary = fishingTechEffectById2.Consume();
				bool uiActive = false;
				foreach (KeyValuePair<int, int> keyValuePair in dictionary)
				{
					if (keyValuePair.Key == 27)
					{
						FishingTechCostItem costItem2 = this.CostItem;
						if (costItem2 != null)
						{
							costItem2.RefreshCost(keyValuePair.Key, keyValuePair.Value, true);
						}
						uiActive = true;
					}
					else
					{
						FishingTechLevelUpItemData item = new FishingTechLevelUpItemData
						{
							ItemId = keyValuePair.Key,
							ItemNeedNum = keyValuePair.Value
						};
						list.Add(item);
					}
				}
				GenericLayout<FishingTechLevelUpItem, IFishingTechLevelUpItem> itemLayout = this.ItemLayout;
				if (itemLayout != null)
				{
					itemLayout.RefreshByData(list, null, false);
				}
				FishingTechCostItem costItem3 = this.CostItem;
				if (costItem3 != null)
				{
					costItem3.SetUiActive(uiActive);
				}
				if (techNodeCurrentLevel == 0)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), fishingTechEffectById2.Desc, fishingTechEffectById2.ShowParams());
					return;
				}
				int techEffectId3 = fishingTechById.Effect(techNodeCurrentLevel - 1);
				FishingTechEffect fishingTechEffectById3 = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId3);
				List<string> list2 = new List<string>();
				int showParamsLength = fishingTechEffectById3.ShowParamsLength;
				for (int i = 0; i < showParamsLength; i++)
				{
					string item2 = fishingTechEffectById3.ShowParams(i) + "->" + fishingTechEffectById2.ShowParams(i);
					list2.Add(item2);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), fishingTechEffectById2.Desc, list2.ToArray());
				return;
			}
		}

		// Token: 0x060427C6 RID: 272326 RVA: 0x01110060 File Offset: 0x0110E260
		[NullableContext(1)]
		private FishingTechLevelUpItem InitItem()
		{
			return new FishingTechLevelUpItem();
		}

		// Token: 0x060427C7 RID: 272327 RVA: 0x01110067 File Offset: 0x0110E267
		private void OnClickLevelUpBtn()
		{
			if (this.Node != null)
			{
				ControllerBase<FishingController>.Instance.RequestFishingTechLevelUp(this.Node.ConfigId);
			}
		}

		// Token: 0x0402501F RID: 151583
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<FishingTechLevelUpItem, IFishingTechLevelUpItem> ItemLayout;

		// Token: 0x04025020 RID: 151584
		[Nullable(2)]
		private FishingTechCostItem CostItem;

		// Token: 0x04025021 RID: 151585
		[Nullable(2)]
		private IFishingTechNode Node;

		// Token: 0x0200C866 RID: 51302
		private class EComponentDefine
		{
			// Token: 0x0403DAD2 RID: 252626
			public const int CubeBgItem = 0;

			// Token: 0x0403DAD3 RID: 252627
			public const int CircleBgItem = 1;

			// Token: 0x0403DAD4 RID: 252628
			public const int TechTexture = 2;

			// Token: 0x0403DAD5 RID: 252629
			public const int TechTitleText = 3;

			// Token: 0x0403DAD6 RID: 252630
			public const int TechLevelText = 4;

			// Token: 0x0403DAD7 RID: 252631
			public const int TechDesText = 5;

			// Token: 0x0403DAD8 RID: 252632
			public const int LevelUpItemLayout = 6;

			// Token: 0x0403DAD9 RID: 252633
			public const int LevelUpItem = 7;

			// Token: 0x0403DADA RID: 252634
			public const int CostItem = 8;

			// Token: 0x0403DADB RID: 252635
			public const int LevelUpBtn = 9;

			// Token: 0x0403DADC RID: 252636
			public const int NotEnoughItem = 10;

			// Token: 0x0403DADD RID: 252637
			public const int MaxLevelItem = 11;

			// Token: 0x0403DADE RID: 252638
			public const int LevelDesText = 12;

			// Token: 0x0403DADF RID: 252639
			public const int CostPanelItem = 13;

			// Token: 0x0403DAE0 RID: 252640
			public const int CannotLevelUpReasonText = 14;
		}
	}
}
