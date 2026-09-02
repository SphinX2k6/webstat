using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006614 RID: 26132
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballItemView : UiPanelBase
	{
		// Token: 0x060414C2 RID: 267458 RVA: 0x010BFE2C File Offset: 0x010BE02C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060414C3 RID: 267459 RVA: 0x010BFFA0 File Offset: 0x010BE1A0
		protected override void OnStart()
		{
			this.SpriteQualityList = new UUISprite[]
			{
				base.GetSprite(1),
				base.GetSprite(2),
				base.GetSprite(3),
				base.GetSprite(4)
			};
			this.BindToggle();
			UUIExtendToggle itemToggle = this.GetItemToggle();
			if (itemToggle != null)
			{
				this.LongPressButton = new LongPressButtonItem(null, null, null);
				this.LongPressButton.Initialize(itemToggle, new Action<bool>(this.OnLongPressActivate), new Action(this.ExtendTogglePress), new Action(this.ExtendToggleRelease), null);
				this.LongPressButton.SetTickConditionDelegate(new Func<bool>(this.CanItemLongPressClick));
			}
		}

		// Token: 0x060414C4 RID: 267460 RVA: 0x010C005C File Offset: 0x010BE25C
		protected override void OnBeforeDestroy()
		{
			PinballShopItemNewTagView shopNewTagView = this.ShopNewTagView;
			if (shopNewTagView != null)
			{
				shopNewTagView.DestroyAsync().Forget<bool>();
			}
			this.ShopNewTagView = null;
			this.UnBindToggle();
			LongPressButtonItem longPressButton = this.LongPressButton;
			if (longPressButton != null)
			{
				longPressButton.Clear();
			}
			this.LongPressButton = null;
		}

		// Token: 0x060414C5 RID: 267461 RVA: 0x010C009C File Offset: 0x010BE29C
		public UniTask Apply(object data)
		{
			PinballItemView.<Apply>d__24 <Apply>d__;
			<Apply>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Apply>d__.<>4__this = this;
			<Apply>d__.data = data;
			<Apply>d__.<>1__state = -1;
			<Apply>d__.<>t__builder.Start<PinballItemView.<Apply>d__24>(ref <Apply>d__);
			return <Apply>d__.<>t__builder.Task;
		}

		// Token: 0x060414C6 RID: 267462 RVA: 0x010C00E8 File Offset: 0x010BE2E8
		public void RefreshByShopData(object data)
		{
			CommonGameplayShopItemProxy commonGameplayShopItemProxy = data as CommonGameplayShopItemProxy;
			if (commonGameplayShopItemProxy == null)
			{
				return;
			}
			this.RefreshShopItemIcon(commonGameplayShopItemProxy);
			this.RefreshShopItemName(commonGameplayShopItemProxy);
			this.RefreshShopQualityColor(commonGameplayShopItemProxy);
			PayShopGoods goodsData = commonGameplayShopItemProxy.GoodsData;
			int? num;
			if (goodsData == null)
			{
				num = null;
			}
			else
			{
				CSharpScript.Game.Module.PayShop.IItemData itemData = goodsData.GetItemData();
				num = ((itemData != null) ? new int?(itemData.Quality) : null);
			}
			int? num2 = num;
			this.RefreshRainbow(num2.GetValueOrDefault() == 5);
			this.RefreshShopContentText(commonGameplayShopItemProxy);
			this.SyncShopNewTagAsync(commonGameplayShopItemProxy).Forget();
		}

		// Token: 0x060414C7 RID: 267463 RVA: 0x010C016C File Offset: 0x010BE36C
		private void RefreshShopItemIcon(CommonGameplayShopItemProxy proxy)
		{
			UUITexture texture = base.GetTexture(6);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(proxy.ItemTextureVisible);
			if (proxy.ItemTextureVisible)
			{
				if (proxy.ItemId > 0)
				{
					base.SetItemIcon(texture, proxy.ItemId, null, null);
					return;
				}
				if (proxy.ItemTexturePath != null)
				{
					base.SetTextureByPath(proxy.ItemTexturePath, texture, null, null);
				}
			}
		}

		// Token: 0x060414C8 RID: 267464 RVA: 0x010C01DC File Offset: 0x010BE3DC
		private void RefreshShopItemName(CommonGameplayShopItemProxy proxy)
		{
			UUIText text = base.GetText(7);
			if (text != null)
			{
				GameplayShopUtil.SetText(text, proxy.ItemNameTextData);
			}
		}

		// Token: 0x060414C9 RID: 267465 RVA: 0x010C0200 File Offset: 0x010BE400
		private void RefreshShopQualityColor(CommonGameplayShopItemProxy proxy)
		{
			PayShopGoods goodsData = proxy.GoodsData;
			int? num;
			if (goodsData == null)
			{
				num = null;
			}
			else
			{
				CSharpScript.Game.Module.PayShop.IItemData itemData = goodsData.GetItemData();
				num = ((itemData != null) ? new int?(itemData.Quality) : null);
			}
			int? num2 = num;
			if (num2 == null)
			{
				return;
			}
			string[] colorList;
			if (!PinballItemView.qualityColorListMap.TryGetValue(num2.Value, out colorList))
			{
				return;
			}
			this.RefreshColor(colorList);
		}

		// Token: 0x060414CA RID: 267466 RVA: 0x010C0268 File Offset: 0x010BE468
		private void RefreshShopContentText(CommonGameplayShopItemProxy proxy)
		{
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				PayShopGoods goodsData = proxy.GoodsData;
				int num = (goodsData != null) ? goodsData.GetGoodsId() : 0;
				bool flag = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, num);
				bool flag2 = num > 0 && !flag;
				item.SetUIActive(proxy.BuyLimitCountTextVisible || flag2);
			}
		}

		// Token: 0x060414CB RID: 267467 RVA: 0x010C02BC File Offset: 0x010BE4BC
		private UniTask ClearShopNewTagAsync()
		{
			PinballItemView.<ClearShopNewTagAsync>d__30 <ClearShopNewTagAsync>d__;
			<ClearShopNewTagAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearShopNewTagAsync>d__.<>4__this = this;
			<ClearShopNewTagAsync>d__.<>1__state = -1;
			<ClearShopNewTagAsync>d__.<>t__builder.Start<PinballItemView.<ClearShopNewTagAsync>d__30>(ref <ClearShopNewTagAsync>d__);
			return <ClearShopNewTagAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060414CC RID: 267468 RVA: 0x010C0300 File Offset: 0x010BE500
		private UniTask SyncShopNewTagAsync(CommonGameplayShopItemProxy proxy)
		{
			PinballItemView.<SyncShopNewTagAsync>d__31 <SyncShopNewTagAsync>d__;
			<SyncShopNewTagAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SyncShopNewTagAsync>d__.<>4__this = this;
			<SyncShopNewTagAsync>d__.proxy = proxy;
			<SyncShopNewTagAsync>d__.<>1__state = -1;
			<SyncShopNewTagAsync>d__.<>t__builder.Start<PinballItemView.<SyncShopNewTagAsync>d__31>(ref <SyncShopNewTagAsync>d__);
			return <SyncShopNewTagAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060414CD RID: 267469 RVA: 0x010C034C File Offset: 0x010BE54C
		protected void ApplyTypeItem(IPinballItemDataItem data)
		{
			this.ApplyBase();
			ItemConfig instance = ConfigBase<ItemConfig>.Instance;
			ItemInfo? itemInfo = (instance != null) ? instance.GetConfig(data.Item.ItemData.ItemId) : null;
			if (itemInfo == null)
			{
				return;
			}
			base.TrySetTextureByPath(itemInfo.Value.Icon, base.GetTexture(6), null, null);
			this.RefreshTxt(data.Item.Count.ToString());
			string[] colorList;
			if (!PinballItemView.qualityColorListMap.TryGetValue(itemInfo.Value.QualityId, out colorList))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "没有对应品质颜色列表";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("qualityId", itemInfo.Value.QualityId);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.RefreshColor(colorList);
			this.RefreshRainbow(itemInfo.Value.QualityId == 5);
		}

		// Token: 0x060414CE RID: 267470 RVA: 0x010C0454 File Offset: 0x010BE654
		protected UniTask ApplyTypeRole(IPinballItemDataRole data)
		{
			PinballItemView.<ApplyTypeRole>d__33 <ApplyTypeRole>d__;
			<ApplyTypeRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ApplyTypeRole>d__.<>4__this = this;
			<ApplyTypeRole>d__.data = data;
			<ApplyTypeRole>d__.<>1__state = -1;
			<ApplyTypeRole>d__.<>t__builder.Start<PinballItemView.<ApplyTypeRole>d__33>(ref <ApplyTypeRole>d__);
			return <ApplyTypeRole>d__.<>t__builder.Task;
		}

		// Token: 0x060414CF RID: 267471 RVA: 0x010C04A0 File Offset: 0x010BE6A0
		protected UniTask ApplyTypeWeapon(IPinballItemDataWeapon data)
		{
			PinballItemView.<ApplyTypeWeapon>d__34 <ApplyTypeWeapon>d__;
			<ApplyTypeWeapon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ApplyTypeWeapon>d__.<>4__this = this;
			<ApplyTypeWeapon>d__.data = data;
			<ApplyTypeWeapon>d__.<>1__state = -1;
			<ApplyTypeWeapon>d__.<>t__builder.Start<PinballItemView.<ApplyTypeWeapon>d__34>(ref <ApplyTypeWeapon>d__);
			return <ApplyTypeWeapon>d__.<>t__builder.Task;
		}

		// Token: 0x060414D0 RID: 267472 RVA: 0x010C04EC File Offset: 0x010BE6EC
		protected void ApplyTypeMonster(IPinballItemDataMonster data)
		{
			this.ApplyBase();
			PinballConfig instance = ConfigBase<PinballConfig>.Instance;
			PinballMonsterType? pinballMonsterType = (instance != null) ? instance.GetPinballMonsterTypeConfigById(data.Id) : null;
			if (pinballMonsterType == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "没有对应怪物配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", data.Id);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int key = 1;
			switch (pinballMonsterType.Value.RiskType)
			{
			case 1:
				key = 2;
				break;
			case 2:
				key = 3;
				break;
			case 3:
				key = 4;
				break;
			}
			string[] colorList;
			PinballItemView.qualityColorListMap.TryGetValue(key, out colorList);
			this.RefreshColor(colorList);
			this.RefreshRainbow(false);
			this.RefreshTxtByTextId(pinballMonsterType.Value.Name);
			base.TrySetTextureByPath(pinballMonsterType.Value.Icon, base.GetTexture(6), null, null);
		}

		// Token: 0x060414D1 RID: 267473 RVA: 0x010C05F0 File Offset: 0x010BE7F0
		protected void ApplyBase()
		{
			base.TrySetSpriteByPath("/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/CatapultStory/ComItem/SP_ComItemBg3.SP_ComItemBg3", base.GetSprite(3), false, null, null);
			this.RefreshRainbow(false);
		}

		// Token: 0x060414D2 RID: 267474 RVA: 0x010C0624 File Offset: 0x010BE824
		protected void RefreshColor(string[] colorList)
		{
			for (int i = 0; i < colorList.Length; i++)
			{
				this.SpriteQualityList[i].SetColor(FColor.FromHex(colorList[i]));
			}
		}

		// Token: 0x060414D3 RID: 267475 RVA: 0x010C0654 File Offset: 0x010BE854
		protected void RefreshRainbow(bool bShow)
		{
			UUISprite sprite = base.GetSprite(5);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(bShow);
		}

		// Token: 0x060414D4 RID: 267476 RVA: 0x010C0668 File Offset: 0x010BE868
		protected void RefreshTxt(string txt)
		{
			UUIText text = base.GetText(7);
			if (text == null)
			{
				return;
			}
			text.SetText(txt, true);
		}

		// Token: 0x060414D5 RID: 267477 RVA: 0x010C067D File Offset: 0x010BE87D
		protected void RefreshTxtByTextId(string textId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(7), textId, Array.Empty<object>());
		}

		// Token: 0x060414D6 RID: 267478 RVA: 0x010C0696 File Offset: 0x010BE896
		protected void RefreshTxtByTableTextArgNew(TableTextArgNew bottomText)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(7), bottomText.TextKey, bottomText.Params);
		}

		// Token: 0x060414D7 RID: 267479 RVA: 0x010C06B8 File Offset: 0x010BE8B8
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		protected UniTask<PinballItemGridComponentBase> RefreshComponent(Type gridClass, bool bNewIfNull, EPinballItemComponentLayer layer, params object[] args)
		{
			PinballItemView.<RefreshComponent>d__44 <RefreshComponent>d__;
			<RefreshComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder<PinballItemGridComponentBase>.Create();
			<RefreshComponent>d__.<>4__this = this;
			<RefreshComponent>d__.gridClass = gridClass;
			<RefreshComponent>d__.bNewIfNull = bNewIfNull;
			<RefreshComponent>d__.layer = layer;
			<RefreshComponent>d__.args = args;
			<RefreshComponent>d__.<>1__state = -1;
			<RefreshComponent>d__.<>t__builder.Start<PinballItemView.<RefreshComponent>d__44>(ref <RefreshComponent>d__);
			return <RefreshComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060414D8 RID: 267480 RVA: 0x010C071C File Offset: 0x010BE91C
		[return: Nullable(2)]
		private PinballItemGridComponentBase GetComponentByType(Type ctor)
		{
			PinballItemGridComponentBase result;
			if (!this.ComponentMap.TryGetValue(ctor, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060414D9 RID: 267481 RVA: 0x010C073C File Offset: 0x010BE93C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<PinballItemGridComponentBase> CreateComponent(Type componentClass, EPinballItemComponentLayer layer = EPinballItemComponentLayer.Normal)
		{
			PinballItemView.<CreateComponent>d__46 <CreateComponent>d__;
			<CreateComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder<PinballItemGridComponentBase>.Create();
			<CreateComponent>d__.<>4__this = this;
			<CreateComponent>d__.componentClass = componentClass;
			<CreateComponent>d__.layer = layer;
			<CreateComponent>d__.<>1__state = -1;
			<CreateComponent>d__.<>t__builder.Start<PinballItemView.<CreateComponent>d__46>(ref <CreateComponent>d__);
			return <CreateComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060414DA RID: 267482 RVA: 0x010C078F File Offset: 0x010BE98F
		private UUIItem GetParentItem(EPinballItemComponentLayer layer)
		{
			if (layer == EPinballItemComponentLayer.Normal)
			{
				return base.GetItem(8);
			}
			if (layer != EPinballItemComponentLayer.Top)
			{
				return base.GetItem(8);
			}
			return base.GetItem(9);
		}

		// Token: 0x060414DB RID: 267483 RVA: 0x010C07B2 File Offset: 0x010BE9B2
		private void OnComponentVisibleChanged(PinballItemGridComponentBase component, bool bVisible)
		{
			if (bVisible)
			{
				this.VisibleComponents.Add(component);
				return;
			}
			this.VisibleComponents.Remove(component);
		}

		// Token: 0x060414DC RID: 267484 RVA: 0x010C07D2 File Offset: 0x010BE9D2
		private void ClearVisibleComponent()
		{
			this.VisibleComponents.Clear();
		}

		// Token: 0x060414DD RID: 267485 RVA: 0x010C07E0 File Offset: 0x010BE9E0
		protected void RefreshComponentVisible()
		{
			foreach (PinballItemGridComponentBase pinballItemGridComponentBase in this.ComponentMap.Values)
			{
				if (!this.VisibleComponents.Contains(pinballItemGridComponentBase))
				{
					pinballItemGridComponentBase.SetActive(false);
				}
			}
		}

		// Token: 0x060414DE RID: 267486 RVA: 0x010C0848 File Offset: 0x010BEA48
		public UniTask RefreshReduceBtnComponent(bool isVisible)
		{
			PinballItemView.<RefreshReduceBtnComponent>d__51 <RefreshReduceBtnComponent>d__;
			<RefreshReduceBtnComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshReduceBtnComponent>d__.<>4__this = this;
			<RefreshReduceBtnComponent>d__.isVisible = isVisible;
			<RefreshReduceBtnComponent>d__.<>1__state = -1;
			<RefreshReduceBtnComponent>d__.<>t__builder.Start<PinballItemView.<RefreshReduceBtnComponent>d__51>(ref <RefreshReduceBtnComponent>d__);
			return <RefreshReduceBtnComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060414DF RID: 267487 RVA: 0x010C0894 File Offset: 0x010BEA94
		public UniTask RefreshFormationNumberComponent(bool isVisible, int formationId = 0)
		{
			PinballItemView.<RefreshFormationNumberComponent>d__52 <RefreshFormationNumberComponent>d__;
			<RefreshFormationNumberComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshFormationNumberComponent>d__.<>4__this = this;
			<RefreshFormationNumberComponent>d__.isVisible = isVisible;
			<RefreshFormationNumberComponent>d__.formationId = formationId;
			<RefreshFormationNumberComponent>d__.<>1__state = -1;
			<RefreshFormationNumberComponent>d__.<>t__builder.Start<PinballItemView.<RefreshFormationNumberComponent>d__52>(ref <RefreshFormationNumberComponent>d__);
			return <RefreshFormationNumberComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060414E0 RID: 267488 RVA: 0x010C08E7 File Offset: 0x010BEAE7
		[NullableContext(2)]
		public UUIExtendToggle GetItemToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x060414E1 RID: 267489 RVA: 0x010C08F0 File Offset: 0x010BEAF0
		private void BindToggle()
		{
			UUIExtendToggle itemToggle = this.GetItemToggle();
			if (itemToggle == null)
			{
				return;
			}
			itemToggle.OnStateChange.Add(new Action<EToggleState>(this.ExtendToggleStateChanged));
			itemToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
			itemToggle.FocusListenerDelegate.Bind(new Action(this.FocusListenerDelegateHandler));
		}

		// Token: 0x060414E2 RID: 267490 RVA: 0x010C0950 File Offset: 0x010BEB50
		private void UnBindToggle()
		{
			UUIExtendToggle itemToggle = this.GetItemToggle();
			if (itemToggle == null)
			{
				return;
			}
			itemToggle.OnStateChange.Remove(new Action<EToggleState>(this.ExtendToggleStateChanged));
			itemToggle.CanExecuteChange.Unbind();
			itemToggle.FocusListenerDelegate.Unbind();
		}

		// Token: 0x060414E3 RID: 267491 RVA: 0x010C0995 File Offset: 0x010BEB95
		private void ExtendToggleStateChanged(EToggleState state)
		{
			this.OnExtendToggleStateChanged(state);
			if (this.OnStateChangedCallback != null)
			{
				this.OnStateChangedCallback(new PinballItemToggleCallbackData
				{
					View = this,
					State = state,
					Data = this.Data
				});
			}
		}

		// Token: 0x060414E4 RID: 267492 RVA: 0x010C09D0 File Offset: 0x010BEBD0
		protected virtual void OnExtendToggleStateChanged(EToggleState state)
		{
		}

		// Token: 0x060414E5 RID: 267493 RVA: 0x010C09D2 File Offset: 0x010BEBD2
		private bool CanExecuteChange()
		{
			return this.OnCanExecuteChangeCallback == null || this.OnCanExecuteChangeCallback(new PinballItemToggleCallbackData
			{
				View = this,
				State = this.GetItemToggle().GetToggleState(),
				Data = this.Data
			});
		}

		// Token: 0x060414E6 RID: 267494 RVA: 0x010C0A12 File Offset: 0x010BEC12
		public void BindOnStateChangeCallback(Action<IPinballItemToggleCallback> onStateChangeCallback)
		{
			this.OnStateChangedCallback = onStateChangeCallback;
		}

		// Token: 0x060414E7 RID: 267495 RVA: 0x010C0A1B File Offset: 0x010BEC1B
		public void UnBindOnStateChangeCallback()
		{
			this.OnStateChangedCallback = null;
		}

		// Token: 0x060414E8 RID: 267496 RVA: 0x010C0A24 File Offset: 0x010BEC24
		public void BindOnCanExecuteChangeCallback(Func<IPinballItemToggleCallback, bool> onCanExecuteChangeCallback)
		{
			this.OnCanExecuteChangeCallback = onCanExecuteChangeCallback;
		}

		// Token: 0x060414E9 RID: 267497 RVA: 0x010C0A2D File Offset: 0x010BEC2D
		public void BindReduceButtonCallback(Action<IPinballItemButtonCallback> onClickedReduceButton)
		{
			this.OnClickedReduceButtonCallback = onClickedReduceButton;
		}

		// Token: 0x060414EA RID: 267498 RVA: 0x010C0A36 File Offset: 0x010BEC36
		public void UnBindReduceButtonCallback()
		{
			this.OnClickedReduceButtonCallback = null;
		}

		// Token: 0x060414EB RID: 267499 RVA: 0x010C0A40 File Offset: 0x010BEC40
		protected void OnClickedReduceButton()
		{
			if (this.OnClickedReduceButtonCallback != null)
			{
				PinballItemButtonCallbackData obj = new PinballItemButtonCallbackData
				{
					View = this,
					Data = this.Data
				};
				this.OnClickedReduceButtonCallback(obj);
			}
		}

		// Token: 0x060414EC RID: 267500 RVA: 0x010C0A7A File Offset: 0x010BEC7A
		public void BindLongPress(LongPressButtonItem.ELongPressConfigId longPressConfigId, [Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<bool, PinballItemView, object> callback, [Nullable(new byte[]
		{
			2,
			1,
			2
		})] Func<PinballItemView, object, bool> canLongPressCallBack = null)
		{
			LongPressButtonItem longPressButton = this.LongPressButton;
			if (longPressButton != null)
			{
				longPressButton.Deactivate();
			}
			LongPressButtonItem longPressButton2 = this.LongPressButton;
			if (longPressButton2 != null)
			{
				longPressButton2.Activate(longPressConfigId);
			}
			this.OnLongPressActiveCallback = callback;
			this.CanItemLongPressCallback = canLongPressCallBack;
		}

		// Token: 0x060414ED RID: 267501 RVA: 0x010C0AAD File Offset: 0x010BECAD
		public void UnBindLongPress()
		{
			this.OnLongPressActiveCallback = null;
			this.CanItemLongPressCallback = null;
		}

		// Token: 0x060414EE RID: 267502 RVA: 0x010C0ABD File Offset: 0x010BECBD
		protected void OnLongPressActivate(bool isShortPress)
		{
			if (this.OnLongPressActiveCallback != null)
			{
				this.OnLongPressActiveCallback(isShortPress, this, this.Data);
			}
		}

		// Token: 0x060414EF RID: 267503 RVA: 0x010C0ADA File Offset: 0x010BECDA
		protected bool CanItemLongPressClick()
		{
			return this.CanItemLongPressCallback == null || this.CanItemLongPressCallback(this, this.Data);
		}

		// Token: 0x060414F0 RID: 267504 RVA: 0x010C0AF8 File Offset: 0x010BECF8
		private void ExtendTogglePress()
		{
			if (this.OnExtendTogglePressCallback != null)
			{
				PinballItemToggleCallbackData obj = new PinballItemToggleCallbackData
				{
					View = this,
					State = this.GetItemToggle().GetToggleState(),
					Data = this.Data
				};
				this.OnExtendTogglePressCallback(obj);
			}
		}

		// Token: 0x060414F1 RID: 267505 RVA: 0x010C0B44 File Offset: 0x010BED44
		private void ExtendToggleRelease()
		{
			if (this.OnExtendToggleReleaseCallback != null)
			{
				PinballItemToggleCallbackData obj = new PinballItemToggleCallbackData
				{
					View = this,
					State = this.GetItemToggle().GetToggleState(),
					Data = this.Data
				};
				this.OnExtendToggleReleaseCallback(obj);
			}
			if (this.OnExtendToggleClickedCallback != null)
			{
				PinballItemToggleCallbackData obj2 = new PinballItemToggleCallbackData
				{
					View = this,
					State = this.GetItemToggle().GetToggleState(),
					Data = this.Data
				};
				this.OnExtendToggleClickedCallback(obj2);
			}
		}

		// Token: 0x060414F2 RID: 267506 RVA: 0x010C0BCD File Offset: 0x010BEDCD
		public void BindReduceLongPress([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<bool, PinballItemView, object> callback)
		{
			this.OnReduceButtonLongActiveCallback = callback;
		}

		// Token: 0x060414F3 RID: 267507 RVA: 0x010C0BD6 File Offset: 0x010BEDD6
		public void UnBindReduceLongPress()
		{
			this.OnReduceButtonLongActiveCallback = null;
		}

		// Token: 0x060414F4 RID: 267508 RVA: 0x010C0BDF File Offset: 0x010BEDDF
		private void OnReduceButtonLongPressActive(bool isShortPress)
		{
			if (this.OnReduceButtonLongActiveCallback != null)
			{
				this.OnReduceButtonLongActiveCallback(isShortPress, this, this.Data);
			}
		}

		// Token: 0x060414F5 RID: 267509 RVA: 0x010C0BFC File Offset: 0x010BEDFC
		public void BindOnExtendToggleClicked(Action<IPinballItemToggleCallback> onExtendToggleClickedCallback)
		{
			this.OnExtendToggleClickedCallback = onExtendToggleClickedCallback;
		}

		// Token: 0x060414F6 RID: 267510 RVA: 0x010C0C05 File Offset: 0x010BEE05
		public void UnBindOnExtendToggleClicked()
		{
			this.OnExtendToggleClickedCallback = null;
		}

		// Token: 0x060414F7 RID: 267511 RVA: 0x010C0C0E File Offset: 0x010BEE0E
		public void BindFocusFocusListenerDelegate(Action<IPinballItemToggleCallback> onFocusListenerDelegate)
		{
			this.OnFocusListenerDelegate = onFocusListenerDelegate;
		}

		// Token: 0x060414F8 RID: 267512 RVA: 0x010C0C17 File Offset: 0x010BEE17
		private void FocusListenerDelegateHandler()
		{
			Action<IPinballItemToggleCallback> onFocusListenerDelegate = this.OnFocusListenerDelegate;
			if (onFocusListenerDelegate == null)
			{
				return;
			}
			onFocusListenerDelegate(new PinballItemToggleCallbackData
			{
				View = this,
				State = this.GetItemToggle().GetToggleState(),
				Data = this.Data
			});
		}

		// Token: 0x04024897 RID: 149655
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, string[]> qualityColorListMap = new Dictionary<int, string[]>
		{
			{
				1,
				new string[]
				{
					"5B9D94FF",
					"94C5B2FF",
					"FFFCE7FF",
					"5B9D94FF"
				}
			},
			{
				2,
				new string[]
				{
					"6B8BBEFF",
					"8EB7DEFF",
					"FFFCE7FF",
					"6B8BBEFF"
				}
			},
			{
				3,
				new string[]
				{
					"9232F5FF",
					"B695D8FF",
					"FFFCE7FF",
					"9232F5FF"
				}
			},
			{
				4,
				new string[]
				{
					"E47C62FF",
					"F7C95AFF",
					"FFFCE7FF",
					"E47C62FF"
				}
			},
			{
				5,
				new string[]
				{
					"D80C59FF",
					"FF5D65FF",
					"FFFCE7FF",
					"D80C59FF"
				}
			}
		};

		// Token: 0x04024898 RID: 149656
		[StaticVariableRuleIgnore]
		private static readonly string[] roleColorList = new string[]
		{
			"D1AA78FF",
			"FEF6E1FF",
			"FFFFFFFF",
			"DCAF88FF"
		};

		// Token: 0x04024899 RID: 149657
		private const string COMMON_SPRITE_QUALITY_PATH = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/CatapultStory/ComItem/SP_ComItemBg3.SP_ComItemBg3";

		// Token: 0x0402489A RID: 149658
		private const string ROLE_SPRITE_QUALITY_PATH = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/CatapultStory/ComItem/SP_ComItemBg3Role.SP_ComItemBg3Role";

		// Token: 0x0402489B RID: 149659
		private const int MAX_QUALITY_ID = 5;

		// Token: 0x0402489C RID: 149660
		[Nullable(2)]
		protected object Data;

		// Token: 0x0402489D RID: 149661
		private UUISprite[] SpriteQualityList = Array.Empty<UUISprite>();

		// Token: 0x0402489E RID: 149662
		[Nullable(2)]
		private PinballShopItemNewTagView ShopNewTagView;

		// Token: 0x0402489F RID: 149663
		private int ShopNewTagSyncGeneration;

		// Token: 0x040248A0 RID: 149664
		[Nullable(2)]
		protected LongPressButtonItem LongPressButton;

		// Token: 0x040248A1 RID: 149665
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IPinballItemButtonCallback> OnClickedReduceButtonCallback;

		// Token: 0x040248A2 RID: 149666
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<IPinballItemToggleCallback, bool> OnCanExecuteChangeCallback;

		// Token: 0x040248A3 RID: 149667
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IPinballItemToggleCallback> OnStateChangedCallback;

		// Token: 0x040248A4 RID: 149668
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IPinballItemToggleCallback> OnFocusListenerDelegate;

		// Token: 0x040248A5 RID: 149669
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly Action<IPinballItemToggleCallback> OnExtendTogglePressCallback;

		// Token: 0x040248A6 RID: 149670
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly Action<IPinballItemToggleCallback> OnExtendToggleReleaseCallback;

		// Token: 0x040248A7 RID: 149671
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IPinballItemToggleCallback> OnExtendToggleClickedCallback;

		// Token: 0x040248A8 RID: 149672
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Action<bool, PinballItemView, object> OnLongPressActiveCallback;

		// Token: 0x040248A9 RID: 149673
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Func<PinballItemView, object, bool> CanItemLongPressCallback;

		// Token: 0x040248AA RID: 149674
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Action<bool, PinballItemView, object> OnReduceButtonLongActiveCallback;

		// Token: 0x040248AB RID: 149675
		private readonly HashSet<PinballItemGridComponentBase> VisibleComponents = new HashSet<PinballItemGridComponentBase>();

		// Token: 0x040248AC RID: 149676
		private readonly Dictionary<Type, PinballItemGridComponentBase> ComponentMap = new Dictionary<Type, PinballItemGridComponentBase>();

		// Token: 0x0200C63B RID: 50747
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D04D RID: 249933
			public const int ItemToggle = 0;

			// Token: 0x0403D04E RID: 249934
			public const int SpriteQualityBgOne = 1;

			// Token: 0x0403D04F RID: 249935
			public const int SpriteQualityBgTwo = 2;

			// Token: 0x0403D050 RID: 249936
			public const int SpriteQualityBgThree = 3;

			// Token: 0x0403D051 RID: 249937
			public const int SpriteQualityBgFour = 4;

			// Token: 0x0403D052 RID: 249938
			public const int SpriteRainbow = 5;

			// Token: 0x0403D053 RID: 249939
			public const int TexIcon = 6;

			// Token: 0x0403D054 RID: 249940
			public const int TextName = 7;

			// Token: 0x0403D055 RID: 249941
			public const int Content = 8;

			// Token: 0x0403D056 RID: 249942
			public const int TopContent = 9;
		}
	}
}
