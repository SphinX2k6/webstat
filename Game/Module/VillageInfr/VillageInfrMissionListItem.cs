using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C13 RID: 19475
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VillageInfrMissionListItem : GridProxyAbstract<IVillageInfrBuildQuestParam>
	{
		// Token: 0x06032CDB RID: 208091 RVA: 0x00CBA704 File Offset: 0x00CB8904
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickFunction))
			};
		}

		// Token: 0x06032CDC RID: 208092 RVA: 0x00CBA784 File Offset: 0x00CB8984
		protected override void OnStart()
		{
			this.Item.Initialize(base.GetItem(0).GetOwner());
			this.Item.BindOnCanExecuteChange((object _, bool __, EToggleState ___) => false);
			this.Item.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				TItem? titem = callbackParameter.Data as TItem?;
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(titem.Value.ItemData.ItemId, true, null);
			});
		}

		// Token: 0x06032CDD RID: 208093 RVA: 0x00CBA7FC File Offset: 0x00CB89FC
		public override void Refresh(IVillageInfrBuildQuestParam data, bool isSelected, int gridIndex)
		{
			this.Id = data.Id;
			this.Index = gridIndex;
			this.SelectId = data.SelectId;
			this.RefreshName();
			this.RefreshReward();
			this.RefreshBtn();
		}

		// Token: 0x06032CDE RID: 208094 RVA: 0x00CBA830 File Offset: 0x00CB8A30
		private void RefreshName()
		{
			AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(this.Id);
			base.GetText(1).ShowTextNew(accessPathConfig.Value.Description);
		}

		// Token: 0x06032CDF RID: 208095 RVA: 0x00CBA86C File Offset: 0x00CB8A6C
		private void RefreshReward()
		{
			InfrV2TreeBuild? infrTreeBuild = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(this.SelectId);
			int num = infrTreeBuild.Value.Requirement().Keys.First<int>();
			int item = infrTreeBuild.Value.FinishCondition(this.Index);
			int count = infrTreeBuild.Value.ItemNum(this.Index);
			TItem titem = new TItem(new InventoryDefine.GetItemData(num, 0), count);
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = titem,
				ItemConfigId = new int?(num),
				BottomText = count.ToString(),
				IsReceivedVisible = new bool?(ModelBase<VillageInfrModel>.Instance.GetTreeFinishConditions().Contains(item))
			};
			this.Item.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x06032CE0 RID: 208096 RVA: 0x00CBA938 File Offset: 0x00CB8B38
		private void RefreshBtn()
		{
			int item = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(this.SelectId).Value.FinishCondition(this.Index);
			bool flag = ModelBase<VillageInfrModel>.Instance.GetTreeFinishConditions().Contains(item);
			base.GetButton(2).RootUIComp.Get().SetUIActive(!flag);
		}

		// Token: 0x06032CE1 RID: 208097 RVA: 0x00CBA99C File Offset: 0x00CB8B9C
		private void OnClickFunction()
		{
			SkipTaskManager.RunByConfigId(ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(this.SelectId).Value.GetQuestAccessPathArray()[this.Index], null);
			Singleton<EventSystem>.Instance.Emit(EEventName.VillageInfrMissionItemClick);
		}

		// Token: 0x0401D909 RID: 121097
		private int Id;

		// Token: 0x0401D90A RID: 121098
		private int Index;

		// Token: 0x0401D90B RID: 121099
		private int SelectId;

		// Token: 0x0401D90C RID: 121100
		private readonly SmallItemGrid Item = new SmallItemGrid();
	}
}
