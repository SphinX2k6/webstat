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
	// Token: 0x0200682B RID: 26667
	[NullableContext(2)]
	[Nullable(0)]
	public class FishingRoleTechView : UiTabViewBase
	{
		// Token: 0x060427D1 RID: 272337 RVA: 0x01110524 File Offset: 0x0110E724
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickLevelUpBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060427D2 RID: 272338 RVA: 0x01110780 File Offset: 0x0110E980
		protected override UniTask OnBeforeStartAsync()
		{
			FishingRoleTechView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingRoleTechView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060427D3 RID: 272339 RVA: 0x011107C4 File Offset: 0x0110E9C4
		protected override void OnStart()
		{
			RoleTechToggle rightToggle = this.RightToggle;
			if (rightToggle != null)
			{
				rightToggle.RefreshItem(5);
			}
			RoleTechToggle leftToggle = this.LeftToggle;
			if (leftToggle != null)
			{
				leftToggle.RefreshItem(4);
			}
			int? num = this.ExtraParams as int?;
			if (num != null)
			{
				this.TargetNodeId = num.Value;
				List<IFishingTechNode> list = ModelBase<FishingModel>.Instance.RoleTechNodeMap[5];
				bool flag = false;
				foreach (IFishingTechNode fishingTechNode in list)
				{
					int configId = fishingTechNode.ConfigId;
					int? num2 = num;
					if (configId == num2.GetValueOrDefault() & num2 != null)
					{
						RoleTechToggle rightToggle2 = this.RightToggle;
						if (rightToggle2 != null)
						{
							rightToggle2.SelectToggle();
						}
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					RoleTechToggle leftToggle2 = this.LeftToggle;
					if (leftToggle2 != null)
					{
						leftToggle2.SelectToggle();
					}
				}
			}
			else
			{
				RoleTechToggle leftToggle3 = this.LeftToggle;
				if (leftToggle3 != null)
				{
					leftToggle3.SelectToggle();
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.FishingRoleTechViewOpened);
			if (!ModelBase<FunctionModel>.Instance.IsOpen(100781))
			{
				base.GetItem(13).SetUIActive(false);
			}
		}

		// Token: 0x060427D4 RID: 272340 RVA: 0x011108F0 File Offset: 0x0110EAF0
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingRoleToggleTech, base.GetItem(12), 5);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingRoleToggleTech, base.GetItem(11), 4);
		}

		// Token: 0x060427D5 RID: 272341 RVA: 0x01110924 File Offset: 0x0110EB24
		protected override void OnBeforeShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x060427D6 RID: 272342 RVA: 0x01110951 File Offset: 0x0110EB51
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFishingTechNodeRefresh, new Action<int>(this.OnFishingTechNodeRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.FishingTechViewComeBack, new Action(this.FishingTechViewComeBack));
		}

		// Token: 0x060427D7 RID: 272343 RVA: 0x0111098B File Offset: 0x0110EB8B
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFishingTechNodeRefresh, new Action<int>(this.OnFishingTechNodeRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingTechViewComeBack, new Action(this.FishingTechViewComeBack));
		}

		// Token: 0x060427D8 RID: 272344 RVA: 0x011109C5 File Offset: 0x0110EBC5
		private void OnFishingTechNodeRefresh(int nodeId)
		{
			this.CurrentSelectToggle = null;
			this.RefreshView(this.CurrentRole);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRedDotRefresh, nodeId);
			Singleton<EventSystem>.Instance.Emit<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, (EFishingTechNodeType)this.CurrentRole);
		}

		// Token: 0x060427D9 RID: 272345 RVA: 0x01110A01 File Offset: 0x0110EC01
		private void FishingTechViewComeBack()
		{
			if (this.CurrentRole != 0)
			{
				this.RefreshView(this.CurrentRole);
			}
		}

		// Token: 0x060427DA RID: 272346 RVA: 0x01110A18 File Offset: 0x0110EC18
		private void RefreshView(int roleType)
		{
			this.CurrentRole = roleType;
			int currentRole = this.CurrentRole;
			string resourceId;
			if (currentRole != 4)
			{
				if (currentRole != 5)
				{
					resourceId = "T_NavigationRoleFeibi";
				}
				else
				{
					resourceId = "T_NavigationRoleFeibi";
				}
			}
			else
			{
				resourceId = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "T_NavigationRoleFemale" : "T_NavigationRoleMale");
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
			List<IFishingTechNode> list;
			List<IFishingTechNode> data = ModelBase<FishingModel>.Instance.RoleTechNodeMap.TryGetValue(roleType, out list) ? list : new List<IFishingTechNode>();
			GenericLayout<FishingRoleTechItem, IFishingTechNode> roleTechNodeLayout = this.RoleTechNodeLayout;
			if (roleTechNodeLayout == null)
			{
				return;
			}
			roleTechNodeLayout.RefreshByData(data, delegate
			{
				GenericLayout<FishingRoleTechItem, IFishingTechNode> roleTechNodeLayout2 = this.RoleTechNodeLayout;
				if (roleTechNodeLayout2 != null)
				{
					UUIInturnAnimController uiAnimController = roleTechNodeLayout2.GetUiAnimController();
					if (uiAnimController != null)
					{
						uiAnimController.Play("", -1, false);
					}
				}
				GenericLayout<FishingRoleTechItem, IFishingTechNode> roleTechNodeLayout3 = this.RoleTechNodeLayout;
				foreach (FishingRoleTechItem fishingRoleTechItem in ((roleTechNodeLayout3 != null) ? roleTechNodeLayout3.GetLayoutItemList() : null))
				{
					if (this.TargetNodeId == 0 || fishingRoleTechItem.Node != this.CurrentNode)
					{
						IFishingTechNode node = fishingRoleTechItem.Node;
						int? num = (node != null) ? new int?(node.ConfigId) : null;
						int targetNodeId = this.TargetNodeId;
						if (!(num.GetValueOrDefault() == targetNodeId & num != null))
						{
							continue;
						}
					}
					this.TargetNodeId = 0;
					fishingRoleTechItem.SelectToggle();
					return;
				}
				GenericLayout<FishingRoleTechItem, IFishingTechNode> roleTechNodeLayout4 = this.RoleTechNodeLayout;
				if (roleTechNodeLayout4 == null)
				{
					return;
				}
				FishingRoleTechItem layoutItemByIndex = roleTechNodeLayout4.GetLayoutItemByIndex(0);
				if (layoutItemByIndex == null)
				{
					return;
				}
				layoutItemByIndex.SelectToggle();
			}, false);
		}

		// Token: 0x060427DB RID: 272347 RVA: 0x01110ACF File Offset: 0x0110ECCF
		[NullableContext(1)]
		private void OnClickRightToggle(UUIExtendToggle toggle)
		{
			if (this.CurrentRole != 5)
			{
				this.RefreshView(5);
				UUIExtendToggle currentSelectRoleToggle = this.CurrentSelectRoleToggle;
				if (currentSelectRoleToggle != null)
				{
					currentSelectRoleToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				this.CurrentSelectRoleToggle = toggle;
			}
		}

		// Token: 0x060427DC RID: 272348 RVA: 0x01110AFE File Offset: 0x0110ECFE
		[NullableContext(1)]
		private void OnClickLeftToggle(UUIExtendToggle toggle)
		{
			if (this.CurrentRole != 4)
			{
				this.RefreshView(4);
				UUIExtendToggle currentSelectRoleToggle = this.CurrentSelectRoleToggle;
				if (currentSelectRoleToggle != null)
				{
					currentSelectRoleToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				this.CurrentSelectRoleToggle = toggle;
			}
		}

		// Token: 0x060427DD RID: 272349 RVA: 0x01110B2D File Offset: 0x0110ED2D
		private void OnClickLevelUpBtn()
		{
			if (this.CurrentNode != null)
			{
				ControllerBase<FishingController>.Instance.RequestFishingTechLevelUp(this.CurrentNode.ConfigId);
			}
		}

		// Token: 0x060427DE RID: 272350 RVA: 0x01110B4C File Offset: 0x0110ED4C
		[NullableContext(1)]
		private FishingTechLevelUpItem InitItem()
		{
			return new FishingTechLevelUpItem();
		}

		// Token: 0x060427DF RID: 272351 RVA: 0x01110B53 File Offset: 0x0110ED53
		[NullableContext(1)]
		private FishingRoleTechItem InitRoleTech()
		{
			return new FishingRoleTechItem
			{
				OnClickToggleBack = new Action<IFishingTechNode, UUIExtendToggle>(this.OnClickFishingRoleTechItem)
			};
		}

		// Token: 0x060427E0 RID: 272352 RVA: 0x01110B6C File Offset: 0x0110ED6C
		[NullableContext(1)]
		private void OnClickFishingRoleTechItem(IFishingTechNode node, UUIExtendToggle toggle)
		{
			UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
			if (currentSelectToggle != null)
			{
				currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentSelectToggle = toggle;
			this.CurrentNode = node;
			FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(node.ConfigId);
			int techNodeCurrentLevel = ModelBase<FishingModel>.Instance.GetTechNodeCurrentLevel(node.ConfigId);
			int effectLength = fishingTechById.EffectLength;
			if (techNodeCurrentLevel >= effectLength)
			{
				base.GetHorizontalLayout(6).RootUIComp.Get().SetUIActive(false);
				base.GetItem(10).SetUIActive(true);
				base.GetButton(8).RootUIComp.Get().SetUIActive(false);
				FishingTechCostItem costItem = this.CostItem;
				if (costItem != null)
				{
					costItem.SetUiActive(false);
				}
				base.GetItem(14).SetUIActive(false);
				return;
			}
			base.GetItem(14).SetUIActive(true);
			base.GetHorizontalLayout(6).RootUIComp.Get().SetUIActive(true);
			base.GetItem(10).SetUIActive(false);
			int techEffectId = fishingTechById.Effect(techNodeCurrentLevel);
			FishingTechEffect fishingTechEffectById = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId);
			List<IFishingTechLevelUpItem> list = new List<IFishingTechLevelUpItem>();
			Dictionary<int, int> dictionary = fishingTechEffectById.Consume();
			bool uiActive = false;
			bool flag = true;
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0);
				flag = (flag && itemCountByConfigId >= keyValuePair.Value);
				uiActive = true;
				if (keyValuePair.Key == 27)
				{
					FishingTechCostItem costItem2 = this.CostItem;
					if (costItem2 != null)
					{
						costItem2.RefreshCost(keyValuePair.Key, keyValuePair.Value, false);
					}
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
			base.GetButton(8).RootUIComp.Get().SetUIActive(flag);
			base.GetItem(9).SetUIActive(!flag);
			GenericLayout<FishingTechLevelUpItem, IFishingTechLevelUpItem> itemLayout = this.ItemLayout;
			if (itemLayout != null)
			{
				itemLayout.RefreshByData(list, null, false);
			}
			FishingTechCostItem costItem3 = this.CostItem;
			if (costItem3 == null)
			{
				return;
			}
			costItem3.SetUiActive(uiActive);
		}

		// Token: 0x04025027 RID: 151591
		private int CurrentRole;

		// Token: 0x04025028 RID: 151592
		private IFishingTechNode CurrentNode;

		// Token: 0x04025029 RID: 151593
		private RoleTechToggle RightToggle;

		// Token: 0x0402502A RID: 151594
		private RoleTechToggle LeftToggle;

		// Token: 0x0402502B RID: 151595
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<FishingRoleTechItem, IFishingTechNode> RoleTechNodeLayout;

		// Token: 0x0402502C RID: 151596
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<FishingTechLevelUpItem, IFishingTechLevelUpItem> ItemLayout;

		// Token: 0x0402502D RID: 151597
		private UUIExtendToggle CurrentSelectToggle;

		// Token: 0x0402502E RID: 151598
		private UUIExtendToggle CurrentSelectRoleToggle;

		// Token: 0x0402502F RID: 151599
		private FishingTechCostItem CostItem;

		// Token: 0x04025030 RID: 151600
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04025031 RID: 151601
		private int TargetNodeId;

		// Token: 0x0200C869 RID: 51305
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DAEF RID: 252655
			public const int RoleTexture = 0;

			// Token: 0x0403DAF0 RID: 252656
			public const int LeftToggleItem = 1;

			// Token: 0x0403DAF1 RID: 252657
			public const int RightToggleItem = 2;

			// Token: 0x0403DAF2 RID: 252658
			public const int RoleTechNodeItemLayout = 3;

			// Token: 0x0403DAF3 RID: 252659
			public const int RoleTechNodeItem = 4;

			// Token: 0x0403DAF4 RID: 252660
			public const int CostItem = 5;

			// Token: 0x0403DAF5 RID: 252661
			public const int NeedItemLayout = 6;

			// Token: 0x0403DAF6 RID: 252662
			public const int NeedItem = 7;

			// Token: 0x0403DAF7 RID: 252663
			public const int LevelUpBtn = 8;

			// Token: 0x0403DAF8 RID: 252664
			public const int NotEnoughItem = 9;

			// Token: 0x0403DAF9 RID: 252665
			public const int MaxLevelItem = 10;

			// Token: 0x0403DAFA RID: 252666
			public const int LeftToggleRedDotItem = 11;

			// Token: 0x0403DAFB RID: 252667
			public const int RightToggleRedDotItem = 12;

			// Token: 0x0403DAFC RID: 252668
			public const int RoleTypeRootItem = 13;

			// Token: 0x0403DAFD RID: 252669
			public const int CostDesItem = 14;
		}
	}
}
