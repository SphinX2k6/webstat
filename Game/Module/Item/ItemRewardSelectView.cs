using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B70 RID: 23408
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemRewardSelectView : UiViewBase
	{
		// Token: 0x0603B300 RID: 242432 RVA: 0x00EF9F20 File Offset: 0x00EF8120
		public ItemRewardSelectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B301 RID: 242433 RVA: 0x00EF9F40 File Offset: 0x00EF8140
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B302 RID: 242434 RVA: 0x00EF9FAC File Offset: 0x00EF81AC
		protected override UniTask OnBeforeStartAsync()
		{
			ItemRewardSelectView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ItemRewardSelectView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B303 RID: 242435 RVA: 0x00EF9FF0 File Offset: 0x00EF81F0
		private UniTask InitBgPrefabs()
		{
			ItemRewardSelectView.<InitBgPrefabs>d__10 <InitBgPrefabs>d__;
			<InitBgPrefabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBgPrefabs>d__.<>4__this = this;
			<InitBgPrefabs>d__.<>1__state = -1;
			<InitBgPrefabs>d__.<>t__builder.Start<ItemRewardSelectView.<InitBgPrefabs>d__10>(ref <InitBgPrefabs>d__);
			return <InitBgPrefabs>d__.<>t__builder.Task;
		}

		// Token: 0x0603B304 RID: 242436 RVA: 0x00EFA034 File Offset: 0x00EF8234
		private UniTask LoadBgPrefabAsync(int itemId, string path)
		{
			ItemRewardSelectView.<LoadBgPrefabAsync>d__11 <LoadBgPrefabAsync>d__;
			<LoadBgPrefabAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadBgPrefabAsync>d__.<>4__this = this;
			<LoadBgPrefabAsync>d__.itemId = itemId;
			<LoadBgPrefabAsync>d__.path = path;
			<LoadBgPrefabAsync>d__.<>1__state = -1;
			<LoadBgPrefabAsync>d__.<>t__builder.Start<ItemRewardSelectView.<LoadBgPrefabAsync>d__11>(ref <LoadBgPrefabAsync>d__);
			return <LoadBgPrefabAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B305 RID: 242437 RVA: 0x00EFA087 File Offset: 0x00EF8287
		private void OnClickBackButton()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemRewardSelectView, delegate(bool _)
			{
				int accumulateSourceId = this.ItemData.AccumulateSourceId;
				if (accumulateSourceId > 0)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaAccumulateBonusView, accumulateSourceId, null);
				}
			});
		}

		// Token: 0x0603B306 RID: 242438 RVA: 0x00EFA0A4 File Offset: 0x00EF82A4
		private void OnConfirmButton(int index, int itemId)
		{
			int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(itemId);
			if (resonantItemRoleId == null || resonantItemRoleId.Length == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Inventory;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "找不到角色配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (!this.CheckSelectItemIfResonant(itemId))
			{
				this.DoSelectItemCallBackAndClose(index, itemId);
				return;
			}
			if (ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(resonantItemRoleId[0]) <= 0)
			{
				ItemConvertTipsParam itemConvertTipsParam = new ItemConvertTipsParam();
				List<TItem> resonantItemConvertItemResult = ModelBase<RoleModel>.Instance.GetResonantItemConvertItemResult(itemId);
				TItem value = new TItem(new InventoryDefine.GetItemData(itemId, 0), 1);
				TItem titem = resonantItemConvertItemResult[0];
				itemConvertTipsParam.BeforeItemData = new TItem?(value);
				itemConvertTipsParam.AfterItemData = new TItem?(titem);
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(titem.ItemData.ItemId).Name, null);
				itemConvertTipsParam.ShowText = string.Format(ConfigMultiTextLang.GetLocalTextNew("WavebandChooseTest_1", null), localTextNew);
				itemConvertTipsParam.OnConfirmCallBack = delegate()
				{
					this.DoSelectItemCallBackAndClose(index, itemId);
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemConvertTipsView, itemConvertTipsParam, null);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ResonantItemConvertConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.DoSelectItemCallBackAndClose(index, itemId);
			};
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData != null)
			{
				string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null);
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					localTextNew2
				});
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ConfirmBoxView, confirmBoxDataNew, null);
		}

		// Token: 0x0603B307 RID: 242439 RVA: 0x00EFA266 File Offset: 0x00EF8466
		private void DoSelectItemCallBackAndClose(int index, int itemId)
		{
			Action<int, int> onSelectItemCallBack = this.ItemData.OnSelectItemCallBack;
			if (onSelectItemCallBack != null)
			{
				onSelectItemCallBack(index, itemId);
			}
			base.CloseMe(null);
		}

		// Token: 0x0603B308 RID: 242440 RVA: 0x00EFA288 File Offset: 0x00EF8488
		private bool CheckSelectItemIfResonant(int itemId)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData == null)
			{
				return false;
			}
			int[] showTypes = itemConfigData.ShowTypes;
			return showTypes != null && showTypes.Contains(30);
		}

		// Token: 0x0603B309 RID: 242441 RVA: 0x00EFA2C2 File Offset: 0x00EF84C2
		private void OnSelectItem(int itemId, int index)
		{
			this.RefreshBgRoot(itemId).Forget();
			this.CurrentSelectItemId = itemId;
		}

		// Token: 0x0603B30A RID: 242442 RVA: 0x00EFA2D7 File Offset: 0x00EF84D7
		protected override void OnBeforeShow()
		{
			this.ItemRewardSelectContent.Refresh(this.ItemData.GiftPackageId);
		}

		// Token: 0x0603B30B RID: 242443 RVA: 0x00EFA2F0 File Offset: 0x00EF84F0
		private UniTask RefreshBgRoot(int itemId)
		{
			ItemRewardSelectView.<RefreshBgRoot>d__18 <RefreshBgRoot>d__;
			<RefreshBgRoot>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshBgRoot>d__.<>4__this = this;
			<RefreshBgRoot>d__.itemId = itemId;
			<RefreshBgRoot>d__.<>1__state = -1;
			<RefreshBgRoot>d__.<>t__builder.Start<ItemRewardSelectView.<RefreshBgRoot>d__18>(ref <RefreshBgRoot>d__);
			return <RefreshBgRoot>d__.<>t__builder.Task;
		}

		// Token: 0x0603B30C RID: 242444 RVA: 0x00EFA33C File Offset: 0x00EF853C
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			ItemRewardSelectView.<OnPlayingStartSequenceAsync>d__19 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<ItemRewardSelectView.<OnPlayingStartSequenceAsync>d__19>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B30D RID: 242445 RVA: 0x00EFA380 File Offset: 0x00EF8580
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			ItemRewardSelectView.<OnPlayingCloseSequenceAsync>d__20 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<ItemRewardSelectView.<OnPlayingCloseSequenceAsync>d__20>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040215CB RID: 136651
		[Nullable(2)]
		private ItemRewardSelectViewOpenParam ItemData;

		// Token: 0x040215CC RID: 136652
		[Nullable(2)]
		private ItemRewardSelectContent ItemRewardSelectContent;

		// Token: 0x040215CD RID: 136653
		private int CurrentSelectItemId;

		// Token: 0x040215CE RID: 136654
		private readonly Dictionary<int, UUIItem> RootPrefabMap = new Dictionary<int, UUIItem>();

		// Token: 0x040215CF RID: 136655
		private readonly Dictionary<int, UiSequencePlayer> BgSequencePlayerMap = new Dictionary<int, UiSequencePlayer>();

		// Token: 0x040215D0 RID: 136656
		[Nullable(2)]
		private ResonantChainOptionLimitInfo LimitInfo;

		// Token: 0x040215D1 RID: 136657
		[Nullable(2)]
		private UUIItem CurrentShowItem;
	}
}
