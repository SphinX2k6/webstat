using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Item.Views
{
	// Token: 0x02005B81 RID: 23425
	public class NewItemTipsView : UiTickViewBase
	{
		// Token: 0x0603B379 RID: 242553 RVA: 0x00EFC057 File Offset: 0x00EFA257
		[NullableContext(1)]
		public NewItemTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B37A RID: 242554 RVA: 0x00EFC060 File Offset: 0x00EFA260
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUINiagara)),
				new ValueTuple<int, Type>(7, typeof(UUITexture))
			};
		}

		// Token: 0x0603B37B RID: 242555 RVA: 0x00EFC114 File Offset: 0x00EFA314
		private UniTask CreateGridItem()
		{
			NewItemTipsView.<CreateGridItem>d__6 <CreateGridItem>d__;
			<CreateGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateGridItem>d__.<>4__this = this;
			<CreateGridItem>d__.<>1__state = -1;
			<CreateGridItem>d__.<>t__builder.Start<NewItemTipsView.<CreateGridItem>d__6>(ref <CreateGridItem>d__);
			return <CreateGridItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B37C RID: 242556 RVA: 0x00EFC158 File Offset: 0x00EFA358
		private void ApplyGridItem(int itemId)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = itemId,
				ItemConfigId = new int?(itemId),
				IconPath = itemConfigData.Icon
			};
			this.GridItem.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x0603B37D RID: 242557 RVA: 0x00EFC1A8 File Offset: 0x00EFA3A8
		private UniTask CreateNiagaraSystem()
		{
			NewItemTipsView.<CreateNiagaraSystem>d__8 <CreateNiagaraSystem>d__;
			<CreateNiagaraSystem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateNiagaraSystem>d__.<>4__this = this;
			<CreateNiagaraSystem>d__.<>1__state = -1;
			<CreateNiagaraSystem>d__.<>t__builder.Start<NewItemTipsView.<CreateNiagaraSystem>d__8>(ref <CreateNiagaraSystem>d__);
			return <CreateNiagaraSystem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B37E RID: 242558 RVA: 0x00EFC1EC File Offset: 0x00EFA3EC
		protected override UniTask OnBeforeStartAsync()
		{
			NewItemTipsView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NewItemTipsView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B37F RID: 242559 RVA: 0x00EFC230 File Offset: 0x00EFA430
		protected override void OnStart()
		{
			object openParam = this.OpenParam;
			int num2;
			if (openParam is int)
			{
				int num = (int)openParam;
				num2 = num;
			}
			else
			{
				num2 = 0;
			}
			int num3 = num2;
			if (num3 == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.ZJC, "新物品提示错误, 没有物品id!", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.CloseMe(null);
				return;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num3);
			if (itemConfigData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Item;
				ELogAuthor author = ELogAuthor.ZJC;
				string message = "新物品提示错误, 没有物品配置!";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", num3);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.CloseMe(null);
				return;
			}
			TItemQualityConfig itemQualityByConfig = ConfigBase<InventoryConfig>.Instance.GetItemQualityByConfig(itemConfigData);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), itemConfigData.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), itemConfigData.ObtainedShowDescription, Array.Empty<object>());
			this.RefreshQualityTexture(itemQualityByConfig.TextureAcquireBg, itemQualityByConfig.TextureAcquireFlow);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
			{
				if (sequenceName == "Golden".ToString() || sequenceName == "Start01".ToString())
				{
					base.CloseMe(null);
				}
			}, false);
			ItemMainType? mainTypeConfig = ConfigBase<ItemConfig>.Instance.GetMainTypeConfig((int)itemConfigData.MainTypeId);
			if (mainTypeConfig != null && !string.IsNullOrEmpty(mainTypeConfig.Value.IconFirstAchieve))
			{
				base.SetTextureByPath(mainTypeConfig.Value.IconFirstAchieve, base.GetTexture(0), null, null);
			}
			this.ApplyGridItem(num3);
		}

		// Token: 0x0603B380 RID: 242560 RVA: 0x00EFC3A8 File Offset: 0x00EFA5A8
		[NullableContext(1)]
		private void RefreshQualityTexture(string bgPath, string flowPath)
		{
			base.SetTextureByPath(bgPath, base.GetTexture(4), null, null);
			base.SetTextureByPath(flowPath, base.GetTexture(7), null, null);
		}

		// Token: 0x0603B381 RID: 242561 RVA: 0x00EFC3E8 File Offset: 0x00EFA5E8
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName(this.IsGolden ? "Golden" : "Start01", false, null, false);
		}

		// Token: 0x0603B382 RID: 242562 RVA: 0x00EFC424 File Offset: 0x00EFA624
		protected override void OnBeforeDestroy()
		{
			ModelBase<ItemModel>.Instance.LastCloseTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		}

		// Token: 0x04021620 RID: 136736
		[Nullable(2)]
		protected SmallItemGrid GridItem;

		// Token: 0x04021621 RID: 136737
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04021622 RID: 136738
		private bool IsGolden;

		// Token: 0x0200BB8C RID: 48012
		private class ENewItemTipsViewCom
		{
			// Token: 0x04039DC4 RID: 236996
			public const int MainTypeIconTexture = 0;

			// Token: 0x04039DC5 RID: 236997
			public const int ItemNameText = 1;

			// Token: 0x04039DC6 RID: 236998
			public const int GridItem = 2;

			// Token: 0x04039DC7 RID: 236999
			public const int ItemDescribeText = 3;

			// Token: 0x04039DC8 RID: 237000
			public const int QualityTexture = 4;

			// Token: 0x04039DC9 RID: 237001
			public const int QualityNiagara = 5;

			// Token: 0x04039DCA RID: 237002
			public const int FlowTexture = 7;
		}
	}
}
