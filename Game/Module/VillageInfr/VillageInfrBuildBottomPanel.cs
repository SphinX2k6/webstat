using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C07 RID: 19463
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrBuildBottomPanel : UiPanelBase
	{
		// Token: 0x06032C91 RID: 208017 RVA: 0x00CB8FD4 File Offset: 0x00CB71D4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
			};
		}

		// Token: 0x06032C92 RID: 208018 RVA: 0x00CB90B4 File Offset: 0x00CB72B4
		private InfrV2TreeBuild GetTreeConfig()
		{
			return ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(this.SelectId).Value;
		}

		// Token: 0x06032C93 RID: 208019 RVA: 0x00CB90DC File Offset: 0x00CB72DC
		private InfrV2Level GetVillageConfig()
		{
			return ConfigBase<VillageInfrConfig>.Instance.GetInfrLevel(this.SelectId).Value;
		}

		// Token: 0x06032C94 RID: 208020 RVA: 0x00CB9104 File Offset: 0x00CB7304
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrBuildBottomPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrBuildBottomPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032C95 RID: 208021 RVA: 0x00CB9148 File Offset: 0x00CB7348
		private void SetOpenParam()
		{
			IVillageInfrBuildInfoParam villageInfrBuildInfoParam = this.OpenParam as IVillageInfrBuildInfoParam;
			this.SelectType = villageInfrBuildInfoParam.SelectType;
			this.SelectId = villageInfrBuildInfoParam.SelectId;
			this.IsDelivery = villageInfrBuildInfoParam.IsDelivery;
		}

		// Token: 0x06032C96 RID: 208022 RVA: 0x00CB9188 File Offset: 0x00CB7388
		private UniTask CreateButton()
		{
			VillageInfrBuildBottomPanel.<CreateButton>d__9 <CreateButton>d__;
			<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButton>d__.<>4__this = this;
			<CreateButton>d__.<>1__state = -1;
			<CreateButton>d__.<>t__builder.Start<VillageInfrBuildBottomPanel.<CreateButton>d__9>(ref <CreateButton>d__);
			return <CreateButton>d__.<>t__builder.Task;
		}

		// Token: 0x06032C97 RID: 208023 RVA: 0x00CB91CB File Offset: 0x00CB73CB
		protected override void OnStart()
		{
			this.Refresh(null);
		}

		// Token: 0x06032C98 RID: 208024 RVA: 0x00CB91D4 File Offset: 0x00CB73D4
		[NullableContext(2)]
		public void Refresh(IVillageInfrBuildInfoParam param = null)
		{
			if (param != null)
			{
				this.OpenParam = param;
				this.SetOpenParam();
			}
			this.RefreshLevel();
			this.RefreshProgress();
			this.RefreshMaxLevel();
			this.RefreshFinishState();
			this.RefreshButton();
		}

		// Token: 0x06032C99 RID: 208025 RVA: 0x00CB9204 File Offset: 0x00CB7404
		private void RefreshLevel()
		{
			if (this.SelectType != EVillageInfrSelectType.Village)
			{
				base.GetItem(0).SetUIActive(false);
				return;
			}
			base.GetItem(0).SetUIActive(true);
			base.GetText(1).ShowTextNew(this.GetVillageConfig().Name);
		}

		// Token: 0x06032C9A RID: 208026 RVA: 0x00CB9250 File Offset: 0x00CB7450
		private void RefreshProgress()
		{
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				if (this.SelectId >= ConfigBase<VillageInfrConfig>.Instance.GetInfrMaxLevel())
				{
					base.GetItem(3).SetUIActive(false);
					return;
				}
				base.GetItem(3).SetUIActive(true);
				Dictionary<int, int>.Enumerator enumerator = this.GetVillageConfig().Requirement().GetEnumerator();
				enumerator.MoveNext();
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(key);
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0);
				base.SetTextureByPath(config.Value.Icon, base.GetTexture(4), null, null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "VillageInfr_Village_Quantityprops", new <>z__ReadOnlyArray<object>(new object[]
				{
					itemCountByConfigId,
					value
				}));
				return;
			}
			else
			{
				VillageInfrModel instance = ModelBase<VillageInfrModel>.Instance;
				if (!instance.GetTreeIsUnlock(this.SelectId) || instance.GetTreeIsComplete(this.SelectId))
				{
					base.GetItem(3).SetUIActive(false);
					return;
				}
				base.GetItem(3).SetUIActive(true);
				Dictionary<int, int>.Enumerator enumerator2 = this.GetTreeConfig().Requirement().GetEnumerator();
				enumerator2.MoveNext();
				KeyValuePair<int, int> keyValuePair2 = enumerator2.Current;
				int key2 = keyValuePair2.Key;
				int value2 = keyValuePair2.Value;
				ItemInfo? config2 = ConfigBase<ItemConfig>.Instance.GetConfig(key2);
				int itemCountByConfigId2 = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key2, 0);
				base.SetTextureByPath(config2.Value.Icon, base.GetTexture(4), null, null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "VillageInfr_Village_Quantityprops", new <>z__ReadOnlyArray<object>(new object[]
				{
					itemCountByConfigId2,
					value2
				}));
				return;
			}
		}

		// Token: 0x06032C9B RID: 208027 RVA: 0x00CB9436 File Offset: 0x00CB7636
		private void RefreshMaxLevel()
		{
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				base.GetItem(6).SetUIActive(this.SelectId >= ConfigBase<VillageInfrConfig>.Instance.GetInfrMaxLevel());
				return;
			}
			base.GetItem(6).SetUIActive(false);
		}

		// Token: 0x06032C9C RID: 208028 RVA: 0x00CB9470 File Offset: 0x00CB7670
		private void RefreshFinishState()
		{
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				base.GetItem(7).SetUIActive(false);
				return;
			}
			IVillageInfrTreeData treeData = ModelBase<VillageInfrModel>.Instance.GetTreeData(this.SelectId);
			base.GetItem(7).SetUIActive(treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusComplete);
		}

		// Token: 0x06032C9D RID: 208029 RVA: 0x00CB94C0 File Offset: 0x00CB76C0
		private void RefreshButton()
		{
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				this.RefreshVillageButton();
				return;
			}
			this.RefreshTreeButton();
		}

		// Token: 0x06032C9E RID: 208030 RVA: 0x00CB94D8 File Offset: 0x00CB76D8
		private void RefreshVillageButton()
		{
			bool canVillageLevelUp = ModelBase<VillageInfrModel>.Instance.GetCanVillageLevelUp();
			this.Button.SetRedDotVisible(canVillageLevelUp);
			this.Button.SetEnableClick(true);
			if (!this.IsDelivery)
			{
				this.Button.SetShowText("VillageInfr_Village_Go");
				return;
			}
			if (canVillageLevelUp)
			{
				this.Button.SetShowText("VillageInfr_Tree_Achieve");
				return;
			}
			this.Button.SetShowText("VillageInfr_Tree_InsufficientItem");
			this.Button.SetEnableClick(false);
		}

		// Token: 0x06032C9F RID: 208031 RVA: 0x00CB9554 File Offset: 0x00CB7754
		private void RefreshTreeButton()
		{
			VillageInfrModel instance = ModelBase<VillageInfrModel>.Instance;
			IVillageInfrTreeData treeData = instance.GetTreeData(this.SelectId);
			this.Button.SetRedDotVisible(instance.GetCanTreeLevelUp(this.SelectId));
			this.Button.SetEnableClick(true);
			if (!instance.GetTreeIsUnlock(this.SelectId))
			{
				this.Button.SetShowText("VillageInfr_Tree_Locking");
				return;
			}
			if (!instance.GetCanTreeLevelUp(this.SelectId))
			{
				if (this.IsDelivery)
				{
					this.Button.SetShowText("VillageInfr_Tree_InsufficientItem");
					this.Button.SetEnableClick(false);
					return;
				}
				this.Button.SetShowText("VillageInfr_Tree_Tobuilt");
				return;
			}
			else
			{
				if (this.IsDelivery)
				{
					this.Button.SetShowText("VillageInfr_Tree_Achieve");
					this.Button.SetEnableClick(treeData == null || treeData.Status != InfrV2StatusPb.InfrV2StatusComplete);
					return;
				}
				this.Button.SetShowText("VillageInfr_Tree_Tobuilt");
				return;
			}
		}

		// Token: 0x06032CA0 RID: 208032 RVA: 0x00CB9640 File Offset: 0x00CB7840
		public void SetBottomBtnClickCb(Action cb)
		{
			this.Button.SetFunction(delegate(int _)
			{
				cb();
			});
		}

		// Token: 0x0401D8D1 RID: 121041
		private int SelectId;

		// Token: 0x0401D8D2 RID: 121042
		private EVillageInfrSelectType SelectType;

		// Token: 0x0401D8D3 RID: 121043
		private bool IsDelivery;

		// Token: 0x0401D8D4 RID: 121044
		private readonly ButtonItem Button = new ButtonItem(null);
	}
}
