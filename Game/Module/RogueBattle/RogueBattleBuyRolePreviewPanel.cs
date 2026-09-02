using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051C3 RID: 20931
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleBuyRolePreviewPanel : UiPanelBase
	{
		// Token: 0x06035CFD RID: 220413 RVA: 0x00D899B1 File Offset: 0x00D87BB1
		public RogueBattleBuyRolePreviewPanel(int incId)
		{
			this.IncId = incId;
		}

		// Token: 0x06035CFE RID: 220414 RVA: 0x00D899C0 File Offset: 0x00D87BC0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnBtnBack))
			};
		}

		// Token: 0x06035CFF RID: 220415 RVA: 0x00D89AAC File Offset: 0x00D87CAC
		private void OnBtnConfirm()
		{
			MapRogueOpSelectView mapRogueOpSelectView = ModelBase<MapRogueModel>.Instance.GetOpData(this.IncId) as MapRogueOpSelectView;
			if (mapRogueOpSelectView == null)
			{
				return;
			}
			RogueResRole rogueResRole = this.Data.RogueResRole;
			if (rogueResRole.CurPrice > ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(rogueResRole.ItemId, 0))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RogueBattle_BuyItemNotEnough", Array.Empty<object>());
				return;
			}
			mapRogueOpSelectView.Select(rogueResRole.Index);
		}

		// Token: 0x06035D00 RID: 220416 RVA: 0x00D89B19 File Offset: 0x00D87D19
		private void OnBtnBack()
		{
			Action backBtnFunc = this.BackBtnFunc;
			if (backBtnFunc == null)
			{
				return;
			}
			backBtnFunc();
		}

		// Token: 0x06035D01 RID: 220417 RVA: 0x00D89B2C File Offset: 0x00D87D2C
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleBuyRolePreviewPanel.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleBuyRolePreviewPanel.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035D02 RID: 220418 RVA: 0x00D89B70 File Offset: 0x00D87D70
		[NullableContext(1)]
		public void Refresh(RogueResGainData data)
		{
			RogueBattleBuyRolePreviewPanel.<>c__DisplayClass12_0 CS$<>8__locals1 = new RogueBattleBuyRolePreviewPanel.<>c__DisplayClass12_0();
			CS$<>8__locals1.<>4__this = this;
			this.Data = data;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(data.RogueResRole.RoleIdOrTrialRoleId, true);
			if (roleDataById == null)
			{
				return;
			}
			RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(data.RogueResRole.RoleIdOrTrialRoleId);
			CS$<>8__locals1.roleConfig = roleDataById.GetRoleConfig();
			CS$<>8__locals1.roleMaxStar = ModelBase<RogueBattleModel>.Instance.MaxRoleStar;
			CS$<>8__locals1.roleUpStar = data.RogueResRole.Level;
			CS$<>8__locals1.roleCurStar = ((roleInfoById != null) ? roleInfoById.Level : 0) + CS$<>8__locals1.roleUpStar;
			this.ElementItem.Refresh(CS$<>8__locals1.roleConfig.ElementId, false, 0);
			base.GetText(1).SetText(roleDataById.GetName(null), true);
			int curPrice = data.RogueResRole.CurPrice;
			int itemId = data.RogueResRole.ItemId;
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(data.RogueResRole.ItemId, 0);
			this.ConfirmButton.SetCostItem(itemId);
			this.ConfirmButton.SetCostText(curPrice.ToString(), new bool?(itemCountByConfigId < curPrice));
			UiAsyncTask task = new UiAsyncTask("RogueBattleBuyRolePreviewPanel.Refresh", delegate()
			{
				RogueBattleBuyRolePreviewPanel.<>c__DisplayClass12_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<RogueBattleBuyRolePreviewPanel.<>c__DisplayClass12_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x06035D03 RID: 220419 RVA: 0x00D89CBC File Offset: 0x00D87EBC
		private void SetStarLayoutSelectOn(bool bOn)
		{
			if (this.Data == null)
			{
				return;
			}
			RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(this.Data.RogueResRole.RoleIdOrTrialRoleId);
			int maxRoleStar = ModelBase<RogueBattleModel>.Instance.MaxRoleStar;
			int level = this.Data.RogueResRole.Level;
			int num = (roleInfoById != null) ? roleInfoById.Level : 0;
			int num2 = Math.Min(num + level, maxRoleStar);
			for (int i = num; i < num2; i++)
			{
				RogueBattleBuyRoleStarItem layoutItemByIndex = this.StarLayout.GetLayoutItemByIndex(i);
				if (layoutItemByIndex != null)
				{
					layoutItemByIndex.SetPreviewAnimOn(bOn);
				}
			}
		}

		// Token: 0x0401EDE6 RID: 126438
		public Action BackBtnFunc;

		// Token: 0x0401EDE7 RID: 126439
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RogueBattleBuyRoleStarItem, bool> StarLayout;

		// Token: 0x0401EDE8 RID: 126440
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RogueBattleFetterLvUpItem, IRogueBattleRoleBondUpdateInfo> FetterLayout;

		// Token: 0x0401EDE9 RID: 126441
		private RogueResGainData Data;

		// Token: 0x0401EDEA RID: 126442
		private RogueBattleShopButton ConfirmButton;

		// Token: 0x0401EDEB RID: 126443
		private RogueBattleTokenElement ElementItem;

		// Token: 0x0401EDEC RID: 126444
		private readonly int IncId;

		// Token: 0x0200B1AA RID: 45482
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403719B RID: 225691
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<IRogueBattleRoleBondUpdateInfo> <0>__SortRogueBattleRoleBondUpdateInfo;
		}
	}
}
