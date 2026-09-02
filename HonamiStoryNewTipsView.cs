using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F44 RID: 8004
public class HonamiStoryNewTipsView : UiTickViewBase
{
	// Token: 0x0600EF82 RID: 61314 RVA: 0x0041710A File Offset: 0x0041530A
	[NullableContext(1)]
	public HonamiStoryNewTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EF83 RID: 61315 RVA: 0x00417114 File Offset: 0x00415314
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

	// Token: 0x0600EF84 RID: 61316 RVA: 0x004171C8 File Offset: 0x004153C8
	private void ApplyGridItem(int itemId)
	{
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = itemId,
			ItemConfigId = new int?(itemId),
			IconPath = itemConfigData.Icon
		};
		this.GridItem.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0600EF85 RID: 61317 RVA: 0x00417218 File Offset: 0x00415418
	private UniTask CreateGridItem()
	{
		HonamiStoryNewTipsView.<CreateGridItem>d__7 <CreateGridItem>d__;
		<CreateGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateGridItem>d__.<>4__this = this;
		<CreateGridItem>d__.<>1__state = -1;
		<CreateGridItem>d__.<>t__builder.Start<HonamiStoryNewTipsView.<CreateGridItem>d__7>(ref <CreateGridItem>d__);
		return <CreateGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF86 RID: 61318 RVA: 0x0041725C File Offset: 0x0041545C
	private UniTask CreateNiagaraSystem()
	{
		HonamiStoryNewTipsView.<CreateNiagaraSystem>d__8 <CreateNiagaraSystem>d__;
		<CreateNiagaraSystem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateNiagaraSystem>d__.<>4__this = this;
		<CreateNiagaraSystem>d__.<>1__state = -1;
		<CreateNiagaraSystem>d__.<>t__builder.Start<HonamiStoryNewTipsView.<CreateNiagaraSystem>d__8>(ref <CreateNiagaraSystem>d__);
		return <CreateNiagaraSystem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF87 RID: 61319 RVA: 0x004172A0 File Offset: 0x004154A0
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryNewTipsView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryNewTipsView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF88 RID: 61320 RVA: 0x004172E4 File Offset: 0x004154E4
	protected override void OnStart()
	{
		HonamiStoryItemDataBase honamiStoryItemDataBase = this.OpenParam as HonamiStoryItemDataBase;
		if (honamiStoryItemDataBase == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.ZJC, "新物品提示错误, 没有物品数据!", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.CloseMe(null);
			return;
		}
		int itemId = honamiStoryItemDataBase.GetItemId();
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		if (itemConfigData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Item;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "新物品提示错误, 没有物品配置!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.CloseMe(null);
			return;
		}
		TItemQualityConfig itemQualityByConfig = ConfigBase<InventoryConfig>.Instance.GetItemQualityByConfig(itemConfigData);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), itemConfigData.Name, Array.Empty<object>());
		HonamiStoryItem? honamiStoryItem = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItem(itemId);
		if (honamiStoryItem != null && honamiStoryItem.Value.ItemType == 1)
		{
			HonamiStoryEquipItemData honamiStoryEquipItemData = honamiStoryItemDataBase as HonamiStoryEquipItemData;
			if (honamiStoryEquipItemData == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Item;
				ELogAuthor author2 = ELogAuthor.ZJC;
				string message2 = "新物品提示错误, 插件物品数据类型错误!";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("itemId", itemId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.CloseMe(null);
				return;
			}
			int buffId = honamiStoryEquipItemData.GetBuffTempIdList(false)[0].BuffId;
			HonamiStoryBuffTemp? honamiStoryBuffTemp = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryBuffTemp(buffId);
			string[] array = honamiStoryBuffTemp.Value.DescSimpleArgs();
			if (array != null && array.Length != 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), honamiStoryBuffTemp.Value.DescSimple, array);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), honamiStoryBuffTemp.Value.DescSimple, Array.Empty<object>());
			}
		}
		else if (honamiStoryItem != null && honamiStoryItem.Value.ItemType == 2)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), honamiStoryItem.Value.AttributesDescription, Array.Empty<object>());
		}
		base.SetTextureByPath(itemQualityByConfig.TextureAcquireBg, base.GetTexture(4), null, null);
		base.SetTextureByPath(itemQualityByConfig.TextureAcquireFlow, base.GetTexture(7), null, null);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Golden" || sequenceName == "Start01")
			{
				base.CloseMe(null);
			}
		}, false);
		ItemMainType? mainTypeConfig = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetMainTypeConfig((int)itemConfigData.MainTypeId);
		if (!string.IsNullOrEmpty((mainTypeConfig != null) ? mainTypeConfig.GetValueOrDefault().IconFirstAchieve : null))
		{
			base.SetTextureByPath(mainTypeConfig.Value.IconFirstAchieve, base.GetTexture(0), null, null);
		}
		this.ApplyGridItem(itemId);
	}

	// Token: 0x0600EF89 RID: 61321 RVA: 0x0041759C File Offset: 0x0041579C
	protected override void OnAfterShow()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName(this.IsGolden ? "Golden" : "Start01", false, null, false);
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_honamistory_pick_up_normal");
	}

	// Token: 0x0600EF8A RID: 61322 RVA: 0x004175E9 File Offset: 0x004157E9
	protected override void OnBeforeDestroy()
	{
		ModelBase<ItemModel>.Instance.LastCloseTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
	}

	// Token: 0x04007331 RID: 29489
	[Nullable(2)]
	private SmallItemGrid GridItem;

	// Token: 0x04007332 RID: 29490
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04007333 RID: 29491
	private bool IsGolden;

	// Token: 0x020082B9 RID: 33465
	private class ENewItemTipsViewCom
	{
		// Token: 0x0402C53F RID: 181567
		public const int MainTypeIconTexture = 0;

		// Token: 0x0402C540 RID: 181568
		public const int ItemNameText = 1;

		// Token: 0x0402C541 RID: 181569
		public const int GridItem = 2;

		// Token: 0x0402C542 RID: 181570
		public const int ItemDescribeText = 3;

		// Token: 0x0402C543 RID: 181571
		public const int QualityTexture = 4;

		// Token: 0x0402C544 RID: 181572
		public const int QualityNiagara = 5;

		// Token: 0x0402C545 RID: 181573
		public const int FlowTexture = 7;
	}
}
