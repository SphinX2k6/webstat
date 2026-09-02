using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063F0 RID: 25584
	public class RoverlikeDetailRoleTabView : UiTabViewBase
	{
		// Token: 0x060403CD RID: 263117 RVA: 0x01076BDC File Offset: 0x01074DDC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060403CE RID: 263118 RVA: 0x01076CEC File Offset: 0x01074EEC
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeDetailRoleTabView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeDetailRoleTabView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060403CF RID: 263119 RVA: 0x01076D30 File Offset: 0x01074F30
		protected override void OnStart()
		{
			this.AttributeLayout = new GenericScrollViewNew<RoverlikeRoleAttributeItem, CSharpScript.Game.Module.Common.AttributeData>(base.GetScrollViewWithScrollbar(5), () => new RoverlikeRoleAttributeItem(), base.GetItem(6).GetOwner() as AUIBaseActor, false, null);
			this.RefreshRoleInfo();
		}

		// Token: 0x060403D0 RID: 263120 RVA: 0x01076D88 File Offset: 0x01074F88
		private void RefreshRoleInfo()
		{
			int mainRoleId = ModelBase<RoverlikeModel>.Instance.GetMainRoleId();
			int roleType = ModelBase<RoverlikeModel>.Instance.InstanceData.RoleType;
			RoverRogueRoleType value = ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfig(roleType).Value;
			ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(value.ElementId);
			if (elementConfig == null)
			{
				return;
			}
			base.GetText(3).SetText(ModelBase<FunctionModel>.Instance.GetPlayerName(), true);
			BigElementItem elementIcon = this.ElementIcon;
			if (elementIcon != null)
			{
				elementIcon.Refresh(value.ElementId);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), elementConfig.Value.Name, Array.Empty<object>());
			FColor color = FColor.FromHex(elementConfig.Value.ElementColor);
			base.GetText(2).SetColor(color);
			this.RefreshAttributeList(mainRoleId);
			this.RefreshLootCard();
		}

		// Token: 0x060403D1 RID: 263121 RVA: 0x01076E68 File Offset: 0x01075068
		private void RefreshAttributeList(int roleId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			int[] array = ((instance != null) ? instance.GetCurrentActivityData() : null).GetParamConfig().Value.AttributeList();
			List<CSharpScript.Game.Module.Common.AttributeData> list = new List<CSharpScript.Game.Module.Common.AttributeData>();
			for (int i = 0; i < array.Length; i++)
			{
				int id = array[i];
				PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(id);
				if (propertyIndexInfo != null)
				{
					CSharpScript.Game.Module.Common.AttributeData item = new CSharpScript.Game.Module.Common.AttributeData
					{
						Id = id,
						IsRatio = propertyIndexInfo.Value.IsPercent,
						CurValue = roleDataById.GetShowAttributeValueById(id),
						BgActive = new bool?(array.Length > 2 && i % 2 == 0)
					};
					list.Add(item);
				}
			}
			this.AttributeLayout.RefreshByData(list, null, true);
		}

		// Token: 0x060403D2 RID: 263122 RVA: 0x01076F44 File Offset: 0x01075144
		private void RefreshLootCard()
		{
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			List<RoverlikeLootGainEntry> list = ((instanceData != null) ? instanceData.GetLootItemList() : null) ?? new List<RoverlikeLootGainEntry>();
			RoverlikeLootGainEntry roverlikeLootGainEntry = (list.Count > 0) ? list[0] : null;
			if (roverlikeLootGainEntry != null)
			{
				RoverlikeLootCardItem lootCard = this.LootCard;
				if (lootCard != null)
				{
					lootCard.Refresh(roverlikeLootGainEntry);
				}
				UUIItem item = base.GetItem(4);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(true);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(4);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x060403D3 RID: 263123 RVA: 0x01076FC0 File Offset: 0x010751C0
		private UniTask RefreshRoleSpineAsync()
		{
			RoverlikeDetailRoleTabView.<RefreshRoleSpineAsync>d__10 <RefreshRoleSpineAsync>d__;
			<RefreshRoleSpineAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleSpineAsync>d__.<>4__this = this;
			<RefreshRoleSpineAsync>d__.<>1__state = -1;
			<RefreshRoleSpineAsync>d__.<>t__builder.Start<RoverlikeDetailRoleTabView.<RefreshRoleSpineAsync>d__10>(ref <RefreshRoleSpineAsync>d__);
			return <RefreshRoleSpineAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04024048 RID: 147528
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoverlikeRoleAttributeItem, CSharpScript.Game.Module.Common.AttributeData> AttributeLayout;

		// Token: 0x04024049 RID: 147529
		[Nullable(2)]
		private BigElementItem ElementIcon;

		// Token: 0x0402404A RID: 147530
		[Nullable(2)]
		private RoverlikeLootCardItem LootCard;

		// Token: 0x0200C456 RID: 50262
		private enum EComponents
		{
			// Token: 0x0403C70E RID: 247566
			SpineRole,
			// Token: 0x0403C70F RID: 247567
			PnlElementBigIcon,
			// Token: 0x0403C710 RID: 247568
			TxtAttributeLabel,
			// Token: 0x0403C711 RID: 247569
			TxtRoleName,
			// Token: 0x0403C712 RID: 247570
			ItemCardSpoils,
			// Token: 0x0403C713 RID: 247571
			AttributeLayout,
			// Token: 0x0403C714 RID: 247572
			AttributeItem
		}
	}
}
