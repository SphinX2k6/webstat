using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200144F RID: 5199
[NullableContext(1)]
[Nullable(0)]
public class NewbieCourseV2Item : GridProxyAbstract<NewbieCourseV2>
{
	// Token: 0x060090C7 RID: 37063 RVA: 0x0026104C File Offset: 0x0025F24C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITextureTransitionComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickReward));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060090C8 RID: 37064 RVA: 0x002611B8 File Offset: 0x0025F3B8
	protected override void OnStart()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
		UUIItem item = base.GetItem(6);
		if (scrollViewWithScrollbar == null || item == null)
		{
			return;
		}
		scrollViewWithScrollbar.AllowEventBubbleUp = true;
		UUILayoutBase layout = scrollViewWithScrollbar.GetContent().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase;
		this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(layout, new Func<CommonItemSmallItemGrid>(this.InitRewardItem), item.GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x060090C9 RID: 37065 RVA: 0x00261224 File Offset: 0x0025F424
	protected override void OnBeforeDestroy()
	{
		this.CancelDigitMaterialLoad();
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		foreach (CommonItemSmallItemGrid child in (((rewardLayout != null) ? rewardLayout.GetLayoutItemList() : null) ?? new List<CommonItemSmallItemGrid>()))
		{
			base.AddChild(child);
		}
	}

	// Token: 0x060090CA RID: 37066 RVA: 0x00261294 File Offset: 0x0025F494
	public void SetActivityData(ActivityNewbieCourseV2Data activityData)
	{
		this.ActivityData = activityData;
	}

	// Token: 0x060090CB RID: 37067 RVA: 0x0026129D File Offset: 0x0025F49D
	public override void Refresh(NewbieCourseV2 config, bool isSelected, int gridIndex)
	{
		this.Config = new NewbieCourseV2?(config);
		this.RefreshLevelDisplay(NewbieCourseV2Item.ReadTargetLevel(config));
		this.RefreshCurrentState();
	}

	// Token: 0x060090CC RID: 37068 RVA: 0x002612BD File Offset: 0x0025F4BD
	public override object GetKey(NewbieCourseV2 data, int displayIndex)
	{
		return NewbieCourseV2Item.ReadId(data);
	}

	// Token: 0x060090CD RID: 37069 RVA: 0x002612CC File Offset: 0x0025F4CC
	public void RefreshCurrentState()
	{
		if (this.Config == null || this.ActivityData == null)
		{
			return;
		}
		NewbieCourseV2 value = this.Config.Value;
		this.CurrentState = this.ActivityData.GetRewardState(NewbieCourseV2Item.ReadTargetLevel(value));
		this.RefreshLevelPrefix();
		this.RefreshRewardBackground();
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(this.CurrentState == ENewbieCourseV2ItemState.CanReceive);
		}
		this.RefreshDigitMaterial();
		this.RefreshRewardList();
	}

	// Token: 0x060090CE RID: 37070 RVA: 0x00261345 File Offset: 0x0025F545
	private CommonItemSmallItemGrid InitRewardItem()
	{
		CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
		commonItemSmallItemGrid.SetAllowClickBack(true);
		commonItemSmallItemGrid.ShowReceivedCallBack = delegate(TItem _)
		{
			if (this.ActivityData == null || this.Config == null)
			{
				return false;
			}
			NewbieCourseV2 value = this.Config.Value;
			return this.ActivityData.GetRewardState(NewbieCourseV2Item.ReadTargetLevel(value)) == ENewbieCourseV2ItemState.HasReceived;
		};
		return commonItemSmallItemGrid;
	}

	// Token: 0x060090CF RID: 37071 RVA: 0x00261368 File Offset: 0x0025F568
	private void RefreshRewardList()
	{
		if (this.Config == null || this.RewardLayout == null)
		{
			return;
		}
		NewbieCourseV2 value = this.Config.Value;
		ItemData[] rewardList = ConfigBase<ActivityNewbieCourseV2Config>.Instance.GetRewardList(NewbieCourseV2Item.ReadRewardId(value));
		TItem[] rewardItems = (from reward in rewardList
		select new TItem
		{
			ItemData = new InventoryDefine.GetItemData(reward.ItemId, 0),
			Count = reward.Count
		}).ToArray<TItem>();
		bool showReceivable = this.CurrentState == ENewbieCourseV2ItemState.CanReceive;
		bool isClaimedDim = this.CurrentState == ENewbieCourseV2ItemState.HasReceived;
		this.RewardLayout.RefreshByData(rewardItems, delegate
		{
			for (int i = 0; i < rewardItems.Length; i++)
			{
				CommonItemSmallItemGrid layoutItemByIndex = this.RewardLayout.GetLayoutItemByIndex(i);
				if (layoutItemByIndex != null)
				{
					this.ApplySmallGridRewardOverlay(layoutItemByIndex, rewardItems[i].ItemData.ItemId, showReceivable, isClaimedDim);
				}
			}
		}, false);
	}

	// Token: 0x060090D0 RID: 37072 RVA: 0x00261424 File Offset: 0x0025F624
	private void ApplySmallGridRewardOverlay(CommonItemSmallItemGrid item, int itemConfigId, bool showReceivable, bool isClaimedDim)
	{
		int itemDataTypeByConfigId = (int)ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemConfigId));
		item.SetReceivableVisible(showReceivable);
		item.SetLockVisible(false);
		item.SetLockBlackVisible(false);
		if (itemDataTypeByConfigId == 1)
		{
			item.SetIsBlack(isClaimedDim);
			item.SetIsDisable(new bool?(false));
			return;
		}
		item.SetIsBlack(false);
		item.SetIsDisable(new bool?(isClaimedDim));
	}

	// Token: 0x060090D1 RID: 37073 RVA: 0x00261484 File Offset: 0x0025F684
	private void RefreshLevelDisplay(int targetLevel)
	{
		UUITexture texture = base.GetTexture(3);
		UUITexture texture2 = base.GetTexture(4);
		string text = Math.Max(0, targetLevel).ToString("D2");
		char digit = text[0];
		char digit2 = text[1];
		if (texture != null)
		{
			string digitTexturePath = this.GetDigitTexturePath(digit, true);
			texture.SetUIActive(!string.IsNullOrEmpty(digitTexturePath));
			if (!string.IsNullOrEmpty(digitTexturePath))
			{
				base.SetTextureByPath(digitTexturePath, texture, null, null);
			}
		}
		if (texture2 != null)
		{
			string digitTexturePath2 = this.GetDigitTexturePath(digit2, false);
			texture2.SetUIActive(!string.IsNullOrEmpty(digitTexturePath2));
			if (!string.IsNullOrEmpty(digitTexturePath2))
			{
				base.SetTextureByPath(digitTexturePath2, texture2, null, null);
			}
		}
	}

	// Token: 0x060090D2 RID: 37074 RVA: 0x0026153C File Offset: 0x0025F73C
	private string GetDigitTexturePath(char digit, bool isLeftDigit)
	{
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted(isLeftDigit ? "T_NumL" : "T_NumR");
		defaultInterpolatedStringHandler.AppendFormatted<char>(digit);
		return instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x060090D3 RID: 37075 RVA: 0x00261584 File Offset: 0x0025F784
	private void RefreshLevelPrefix()
	{
		UUISprite sprite = base.GetSprite(2);
		if (sprite == null)
		{
			return;
		}
		string resourceId;
		if (!NewbieCourseV2Define.LevelPrefixSpriteIds.TryGetValue(this.CurrentState, out resourceId))
		{
			resourceId = NewbieCourseV2Define.LevelPrefixSpriteIds[ENewbieCourseV2ItemState.Unaccomplished];
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		sprite.SetUIActive(!string.IsNullOrEmpty(resourcePath));
		if (!string.IsNullOrEmpty(resourcePath))
		{
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}
	}

	// Token: 0x060090D4 RID: 37076 RVA: 0x002615F3 File Offset: 0x0025F7F3
	private void RefreshRewardBackground()
	{
		this.RefreshRewardBackgroundTransition();
	}

	// Token: 0x060090D5 RID: 37077 RVA: 0x002615FC File Offset: 0x0025F7FC
	private UniTask RefreshRewardBackgroundTransition()
	{
		NewbieCourseV2Item.<RefreshRewardBackgroundTransition>d__21 <RefreshRewardBackgroundTransition>d__;
		<RefreshRewardBackgroundTransition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRewardBackgroundTransition>d__.<>4__this = this;
		<RefreshRewardBackgroundTransition>d__.<>1__state = -1;
		<RefreshRewardBackgroundTransition>d__.<>t__builder.Start<NewbieCourseV2Item.<RefreshRewardBackgroundTransition>d__21>(ref <RefreshRewardBackgroundTransition>d__);
		return <RefreshRewardBackgroundTransition>d__.<>t__builder.Task;
	}

	// Token: 0x060090D6 RID: 37078 RVA: 0x00261640 File Offset: 0x0025F840
	private void RefreshDigitMaterial()
	{
		UUITexture texture = base.GetTexture(3);
		UUITexture texture2 = base.GetTexture(4);
		if (texture == null || texture2 == null)
		{
			return;
		}
		string text;
		string materialId = NewbieCourseV2Define.LeftDigitMaterialIds.TryGetValue(this.CurrentState, out text) ? text : NewbieCourseV2Define.LeftDigitMaterialIds[ENewbieCourseV2ItemState.Unaccomplished];
		string text2;
		string materialId2 = NewbieCourseV2Define.RightDigitMaterialIds.TryGetValue(this.CurrentState, out text2) ? text2 : NewbieCourseV2Define.RightDigitMaterialIds[ENewbieCourseV2ItemState.Unaccomplished];
		this.LoadDigitMaterial(materialId, texture, true);
		this.LoadDigitMaterial(materialId2, texture2, false);
	}

	// Token: 0x060090D7 RID: 37079 RVA: 0x002616C0 File Offset: 0x0025F8C0
	private void LoadDigitMaterial(string materialId, UUITexture texture, bool isLeft)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(materialId);
		if (string.IsNullOrEmpty(resourcePath))
		{
			texture.SetCustomUIMaterial(null);
			return;
		}
		if (isLeft)
		{
			if (this.LeftMaterialHandleId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LeftMaterialHandleId);
			}
			this.LeftMaterialHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInterface>(resourcePath, delegate([Nullable(2)] UMaterialInterface materialInterface, string _)
			{
				texture.SetCustomUIMaterial(materialInterface);
			}, ResourceSystem.EResourceLoadPriority.Ui, this.MemoryTag);
			return;
		}
		if (this.RightMaterialHandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.RightMaterialHandleId);
		}
		this.RightMaterialHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInterface>(resourcePath, delegate([Nullable(2)] UMaterialInterface materialInterface, string _)
		{
			texture.SetCustomUIMaterial(materialInterface);
		}, ResourceSystem.EResourceLoadPriority.Ui, this.MemoryTag);
	}

	// Token: 0x060090D8 RID: 37080 RVA: 0x0026177C File Offset: 0x0025F97C
	private void CancelDigitMaterialLoad()
	{
		if (this.LeftMaterialHandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LeftMaterialHandleId);
			this.LeftMaterialHandleId = -1;
		}
		if (this.RightMaterialHandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.RightMaterialHandleId);
			this.RightMaterialHandleId = -1;
		}
	}

	// Token: 0x060090D9 RID: 37081 RVA: 0x002617CC File Offset: 0x0025F9CC
	private void OnClickReward()
	{
		if (this.Config == null || this.ActivityData == null)
		{
			return;
		}
		if (this.CurrentState != ENewbieCourseV2ItemState.CanReceive)
		{
			return;
		}
		ActivityNewbieCourseV2Controller activityNewbieCourseV2Controller = ActivityManager.GetActivityController(this.ActivityData.Type) as ActivityNewbieCourseV2Controller;
		if (activityNewbieCourseV2Controller == null)
		{
			return;
		}
		activityNewbieCourseV2Controller.RequestAllClaimableRewards(new int?(this.ActivityData.Id));
	}

	// Token: 0x060090DA RID: 37082 RVA: 0x00261828 File Offset: 0x0025FA28
	private static int ReadId(NewbieCourseV2 config)
	{
		Type type = config.GetType();
		PropertyInfo property = type.GetProperty("Id");
		object obj = (property != null) ? property.GetValue(config) : null;
		if (obj is int)
		{
			return (int)obj;
		}
		MethodInfo methodInfo = type.GetMethod("Id", Type.EmptyTypes) ?? type.GetMethod("id", Type.EmptyTypes);
		obj = ((methodInfo != null) ? methodInfo.Invoke(config, null) : null);
		if (obj is int)
		{
			return (int)obj;
		}
		return 0;
	}

	// Token: 0x060090DB RID: 37083 RVA: 0x002618BC File Offset: 0x0025FABC
	private static int ReadTargetLevel(NewbieCourseV2 config)
	{
		Type type = config.GetType();
		PropertyInfo property = type.GetProperty("TargetLevel");
		object obj = (property != null) ? property.GetValue(config) : null;
		if (obj is int)
		{
			return (int)obj;
		}
		MethodInfo methodInfo = type.GetMethod("TargetLevel", Type.EmptyTypes) ?? type.GetMethod("targetlevel", Type.EmptyTypes);
		obj = ((methodInfo != null) ? methodInfo.Invoke(config, null) : null);
		if (obj is int)
		{
			return (int)obj;
		}
		return 0;
	}

	// Token: 0x060090DC RID: 37084 RVA: 0x00261950 File Offset: 0x0025FB50
	private static int ReadRewardId(NewbieCourseV2 config)
	{
		Type type = config.GetType();
		PropertyInfo property = type.GetProperty("Reward");
		object obj = (property != null) ? property.GetValue(config) : null;
		if (obj is int)
		{
			return (int)obj;
		}
		MethodInfo methodInfo = type.GetMethod("Reward", Type.EmptyTypes) ?? type.GetMethod("reward", Type.EmptyTypes);
		obj = ((methodInfo != null) ? methodInfo.Invoke(config, null) : null);
		if (obj is int)
		{
			return (int)obj;
		}
		return 0;
	}

	// Token: 0x0400432E RID: 17198
	private NewbieCourseV2? Config;

	// Token: 0x0400432F RID: 17199
	[Nullable(2)]
	private ActivityNewbieCourseV2Data ActivityData;

	// Token: 0x04004330 RID: 17200
	private ENewbieCourseV2ItemState CurrentState;

	// Token: 0x04004331 RID: 17201
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04004332 RID: 17202
	private int LeftMaterialHandleId = -1;

	// Token: 0x04004333 RID: 17203
	private int RightMaterialHandleId = -1;

	// Token: 0x02007849 RID: 30793
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040295E1 RID: 169441
		public const int StripButton = 0;

		// Token: 0x040295E2 RID: 169442
		public const int RedPointPanel = 1;

		// Token: 0x040295E3 RID: 169443
		public const int LevelSprite = 2;

		// Token: 0x040295E4 RID: 169444
		public const int NumberLeft = 3;

		// Token: 0x040295E5 RID: 169445
		public const int NumberRight = 4;

		// Token: 0x040295E6 RID: 169446
		public const int RewardListLayout = 5;

		// Token: 0x040295E7 RID: 169447
		public const int RewardItemTemplate = 6;

		// Token: 0x040295E8 RID: 169448
		public const int BackgroundTexture = 7;
	}
}
