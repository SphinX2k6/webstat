using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001085 RID: 4229
[NullableContext(1)]
[Nullable(0)]
public class FurnitureDesignView : UiViewBase
{
	// Token: 0x06006E0C RID: 28172 RVA: 0x001C98F8 File Offset: 0x001C7AF8
	public FurnitureDesignView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006E0D RID: 28173 RVA: 0x001C996C File Offset: 0x001C7B6C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIArtText)),
			new ValueTuple<int, Type>(19, typeof(UUIArtText)),
			new ValueTuple<int, Type>(20, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(21, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(22, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(23, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(24, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(25, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickRightBtn)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickLeftBtn)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickSaveBtn)),
			new ValueTuple<int, Delegate>(20, new Action(this.OnClickPresetBtn)),
			new ValueTuple<int, Delegate>(23, new Action(this.OnClickMaskButton)),
			new ValueTuple<int, Delegate>(24, new Action(this.OnClickSaveAndTeleportBtn))
		};
	}

	// Token: 0x06006E0E RID: 28174 RVA: 0x001C9C70 File Offset: 0x001C7E70
	protected override UniTask OnBeforeStartAsync()
	{
		FurnitureDesignView.<OnBeforeStartAsync>d__32 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FurnitureDesignView.<OnBeforeStartAsync>d__32>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006E0F RID: 28175 RVA: 0x001C9CB4 File Offset: 0x001C7EB4
	protected override UniTask OnBeforeShowAsyncImplementImplement()
	{
		FurnitureDesignView.<OnBeforeShowAsyncImplementImplement>d__33 <OnBeforeShowAsyncImplementImplement>d__;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<FurnitureDesignView.<OnBeforeShowAsyncImplementImplement>d__33>(ref <OnBeforeShowAsyncImplementImplement>d__);
		return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06006E10 RID: 28176 RVA: 0x001C9CF7 File Offset: 0x001C7EF7
	protected override void OnBeforeHide()
	{
		this.ResumeTimeDilation();
	}

	// Token: 0x06006E11 RID: 28177 RVA: 0x001C9D00 File Offset: 0x001C7F00
	protected override void OnBeforeDestroy()
	{
		FurnitureEntityVisibleManager furnitureEntityVisibleManager = ModelBase<FurnitureModel>.Instance.FurnitureEntityVisibleManager;
		furnitureEntityVisibleManager.UnlockFurnitureEntity();
		furnitureEntityVisibleManager.EnabledAllEntities();
		FurnitureController instance = ControllerBase<FurnitureController>.Instance;
		instance.DoUnloadNeedUnloadedSceneItem();
		instance.UnloadAllServerFurnitureSceneItem();
		instance.EndEditArea();
		ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitFixSceneSubCamera(null, true);
		this.AtmosphereTween.Destroy();
	}

	// Token: 0x06006E12 RID: 28178 RVA: 0x001C9D5E File Offset: 0x001C7F5E
	protected virtual void PauseTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("FurnitureDesignView");
	}

	// Token: 0x06006E13 RID: 28179 RVA: 0x001C9D6F File Offset: 0x001C7F6F
	protected virtual void ResumeTimeDilation()
	{
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("FurnitureDesignView");
	}

	// Token: 0x06006E14 RID: 28180 RVA: 0x001C9D80 File Offset: 0x001C7F80
	private bool SetSlotSelectedState(int index)
	{
		if (index < 0 || index >= this.SlotDataList.Count)
		{
			return false;
		}
		if (this.SelectedSlotIndex == index)
		{
			return false;
		}
		if (this.SelectedSlotIndex != -1)
		{
			FurnitureSlotScrollItemData furnitureSlotScrollItemData = this.SlotDataList[this.SelectedSlotIndex];
			if (furnitureSlotScrollItemData != null)
			{
				furnitureSlotScrollItemData.IsSelected = false;
			}
		}
		this.SelectedSlotIndex = index;
		FurnitureSlotScrollItemData furnitureSlotScrollItemData2 = this.SlotDataList[index];
		if (furnitureSlotScrollItemData2 != null)
		{
			furnitureSlotScrollItemData2.IsSelected = true;
			this.SelectedSceneSlotEntityId = furnitureSlotScrollItemData2.SceneSlotEntityId;
			this.SelectedSubSlotIndex = furnitureSlotScrollItemData2.SubSlotIndex;
			this.SelectedSlotType = furnitureSlotScrollItemData2.SlotType;
			this.SelectedFurnitureConfigId = furnitureSlotScrollItemData2.PlacedFurnitureId;
		}
		return true;
	}

	// Token: 0x06006E15 RID: 28181 RVA: 0x001C9E20 File Offset: 0x001C8020
	private bool SetFurnitureSelectedState(int index)
	{
		if (index >= this.FurnitureScrollItemDataList.Count)
		{
			return false;
		}
		if (this.SelectedFurnitureIndex == index)
		{
			return false;
		}
		if (this.SelectedFurnitureIndex != -1)
		{
			FurnitureScrollItemData furnitureScrollItemData = this.FurnitureScrollItemDataList[this.SelectedFurnitureIndex];
			if (furnitureScrollItemData != null)
			{
				furnitureScrollItemData.IsSelected = false;
			}
		}
		this.SelectedFurnitureIndex = index;
		if (index == -1)
		{
			this.SelectedFurnitureConfigId = 0;
			return true;
		}
		FurnitureScrollItemData furnitureScrollItemData2 = this.FurnitureScrollItemDataList[index];
		if (furnitureScrollItemData2 != null)
		{
			furnitureScrollItemData2.IsSelected = true;
			this.SelectedFurnitureConfigId = furnitureScrollItemData2.FurnitureConfig.Id;
		}
		return true;
	}

	// Token: 0x06006E16 RID: 28182 RVA: 0x001C9EB0 File Offset: 0x001C80B0
	private void UpdateSlotDataList()
	{
		this.SlotDataList.Clear();
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(this.SelectedAreaId);
		if (furnitureAreaConfig == null)
		{
			return;
		}
		FurnitureAreaData curEditAreaData = this.CurEditAreaData;
		if (curEditAreaData == null)
		{
			return;
		}
		foreach (int slotEntityId in furnitureAreaConfig.Value.SlotEntityIdsIter())
		{
			this.AddSceneSlotData(slotEntityId, curEditAreaData);
			this.AddSubSlotData(slotEntityId, curEditAreaData);
		}
		this.SortSlotDataList();
		this.UpdateSlotTagIndex();
		this.UpdateSlotSelectedState();
		this.UpdateSlotLineState();
	}

	// Token: 0x06006E17 RID: 28183 RVA: 0x001C9F5C File Offset: 0x001C815C
	private void UpdateFurnitureScrollItemDataList()
	{
		if (this.CurEditAreaData == null)
		{
			return;
		}
		this.FurnitureScrollItemDataList.Clear();
		FurnitureSlotScrollItemData furnitureSlotScrollItemData = (this.SlotDataList.Count > this.SelectedSlotIndex && this.SelectedSlotIndex >= 0) ? this.SlotDataList[this.SelectedSlotIndex] : null;
		if (furnitureSlotScrollItemData == null)
		{
			return;
		}
		this.UpdateOriginalPlacedFurnitureId();
		foreach (Furniture furnitureConfig in (ModelBase<FurnitureModel>.Instance.GetFurnitureConfigListBySlotInfo(this.CurEditAreaData, furnitureSlotScrollItemData.SceneSlotEntityId, furnitureSlotScrollItemData.SubSlotIndex) ?? new List<Furniture>()))
		{
			this.FurnitureScrollItemDataList.Add(this.CreateFurnitureScrollItemData(furnitureConfig));
		}
		this.SortFurnitureScrollItemDataList();
		this.SelectedFurnitureIndex = this.FurnitureScrollItemDataList.FindIndex((FurnitureScrollItemData item) => item.FurnitureConfig.Id == this.SelectedFurnitureConfigId);
	}

	// Token: 0x06006E18 RID: 28184 RVA: 0x001CA048 File Offset: 0x001C8248
	private void UpdateAreaPointDataList()
	{
		this.AreaPointDataList.Clear();
		foreach (int num in this.AreaList)
		{
			this.AreaPointDataList.Add(num == this.SelectedAreaId);
		}
	}

	// Token: 0x06006E19 RID: 28185 RVA: 0x001CA0B4 File Offset: 0x001C82B4
	private void SortFurnitureScrollItemDataList()
	{
		this.FurnitureScrollItemDataList.Sort(delegate(FurnitureScrollItemData a, FurnitureScrollItemData b)
		{
			if (a.IsSelected != b.IsSelected)
			{
				if (!a.IsSelected)
				{
					return 1;
				}
				return -1;
			}
			else if (a.IsLock != b.IsLock)
			{
				if (!a.IsLock)
				{
					return -1;
				}
				return 1;
			}
			else
			{
				bool flag = a.FurnitureConfig.LimitCount > 0;
				bool flag2 = b.FurnitureConfig.LimitCount > 0;
				if (flag != flag2)
				{
					if (flag && a.LeftCount == 0)
					{
						return 1;
					}
					if (flag2 && b.LeftCount == 0)
					{
						return -1;
					}
					if (!flag)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (flag && a.LeftCount != b.LeftCount)
					{
						return b.LeftCount - a.LeftCount;
					}
					int num = b.FurnitureConfig.QualityId - a.FurnitureConfig.QualityId;
					if (num != 0)
					{
						return num;
					}
					return b.FurnitureConfig.Id - a.FurnitureConfig.Id;
				}
			}
		});
	}

	// Token: 0x06006E1A RID: 28186 RVA: 0x001CA0E0 File Offset: 0x001C82E0
	private FurnitureScrollItemData CreateFurnitureScrollItemData(Furniture furnitureConfig)
	{
		FurnitureModel instance = ModelBase<FurnitureModel>.Instance;
		int id = furnitureConfig.Id;
		FurnitureScrollItemData furnitureScrollItemData = new FurnitureScrollItemData
		{
			FurnitureConfig = furnitureConfig,
			RedDotShowState = ModelBase<FurnitureModel>.Instance.CheckFurnitureDesignItemRedDotByConfig(furnitureConfig),
			IsSelected = (id == this.SelectedFurnitureConfigId),
			LeftCount = 0,
			IsLock = !instance.GetIsFurnitureUnlockById(id),
			IsCheck = (id == this.OriginalPlacedFurnitureId)
		};
		this.UpdateFurnitureScrollItemDataLeftCount(furnitureScrollItemData);
		return furnitureScrollItemData;
	}

	// Token: 0x06006E1B RID: 28187 RVA: 0x001CA158 File Offset: 0x001C8358
	private void UpdateFurnitureScrollItemDataLeftCount(FurnitureScrollItemData data)
	{
		int limitCount = data.FurnitureConfig.LimitCount;
		int id = data.FurnitureConfig.Id;
		int leftCount = 0;
		if (limitCount > 0)
		{
			int num = 0;
			foreach (FurnitureAreaData furnitureAreaData in this.EditorAreaDataMap.Values)
			{
				num += furnitureAreaData.GetFurnitureUseCount(id);
			}
			leftCount = limitCount - num;
		}
		data.LeftCount = leftCount;
	}

	// Token: 0x06006E1C RID: 28188 RVA: 0x001CA1EC File Offset: 0x001C83EC
	private void UpdateOriginalPlacedFurnitureId()
	{
		FurnitureAreaData areaData = ModelBase<FurnitureModel>.Instance.GetAreaData(this.SelectedAreaId);
		if (areaData == null)
		{
			return;
		}
		FurnitureSlotDataBase slotData = areaData.GetSlotData(this.SelectedSceneSlotEntityId, this.SelectedSubSlotIndex);
		if (slotData == null)
		{
			return;
		}
		this.OriginalPlacedFurnitureId = slotData.GetPlacedFurnitureConfigId();
	}

	// Token: 0x06006E1D RID: 28189 RVA: 0x001CA234 File Offset: 0x001C8434
	private void UpdateSlotTagIndex()
	{
		this.TagCounterMap.Clear();
		foreach (FurnitureSlotScrollItemData furnitureSlotScrollItemData in this.SlotDataList)
		{
			int andIncrementTagIndex = this.GetAndIncrementTagIndex(furnitureSlotScrollItemData.TagId);
			furnitureSlotScrollItemData.TagIndex = andIncrementTagIndex;
			furnitureSlotScrollItemData.ShowTagIndex = (andIncrementTagIndex > 1);
		}
	}

	// Token: 0x06006E1E RID: 28190 RVA: 0x001CA2AC File Offset: 0x001C84AC
	private void UpdateSlotSelectedState()
	{
		this.SelectedSlotIndex = this.SlotDataList.FindIndex(new Predicate<FurnitureSlotScrollItemData>(this.IsSlotMatched));
		for (int i = 0; i < this.SlotDataList.Count; i++)
		{
			this.SlotDataList[i].IsSelected = (i == this.SelectedSlotIndex);
		}
	}

	// Token: 0x06006E1F RID: 28191 RVA: 0x001CA308 File Offset: 0x001C8508
	private void UpdateSlotLineState()
	{
		int count = this.SlotDataList.Count;
		for (int i = 0; i < count; i++)
		{
			this.SlotDataList[i].LineShowState = (i != count - 1);
		}
	}

	// Token: 0x06006E20 RID: 28192 RVA: 0x001CA348 File Offset: 0x001C8548
	private void AddSceneSlotData(int slotEntityId, FurnitureAreaData areaData)
	{
		IFurnitureSlot sceneSlotEntitySlotInfo = ModelBase<FurnitureModel>.Instance.GetSceneSlotEntitySlotInfo(this.MapId, slotEntityId);
		if (sceneSlotEntitySlotInfo == null)
		{
			return;
		}
		FurnitureSceneSlotData sceneSlotData = areaData.GetSceneSlotData(slotEntityId);
		int furnitureTag = sceneSlotEntitySlotInfo.FurnitureTag;
		int placedFurnitureId = (sceneSlotData != null) ? sceneSlotData.GetPlacedFurnitureConfigId() : 0;
		FurnitureSlotScrollItemData item = new FurnitureSlotScrollItemData
		{
			SceneSlotEntityId = slotEntityId,
			PlacedFurnitureId = placedFurnitureId,
			SubSlotIndex = -1,
			SlotType = EFurnitureSlotType.SceneSlot,
			TagId = furnitureTag,
			TagIndex = 0,
			ShowTagIndex = false,
			IsSelected = false,
			LineShowState = false,
			RedDotShowState = ModelBase<FurnitureModel>.Instance.CheckFurnitureSlotRedDot(areaData, slotEntityId, -1)
		};
		this.SlotDataList.Add(item);
	}

	// Token: 0x06006E21 RID: 28193 RVA: 0x001CA3EC File Offset: 0x001C85EC
	private void AddSubSlotData(int slotEntityId, FurnitureAreaData areaData)
	{
		FurnitureSceneSlotData sceneSlotData = areaData.GetSceneSlotData(slotEntityId);
		if (sceneSlotData == null || sceneSlotData.GetPlacedFurnitureConfigId() == 0)
		{
			return;
		}
		int subSlotDataListLength = sceneSlotData.GetSubSlotDataListLength();
		if (subSlotDataListLength <= 0)
		{
			return;
		}
		for (int i = 0; i < subSlotDataListLength; i++)
		{
			FurnitureSubSlotData subSlotData = sceneSlotData.GetSubSlotData(i);
			if (subSlotData != null)
			{
				int slotTagId = subSlotData.GetSlotTagId();
				int andIncrementTagIndex = this.GetAndIncrementTagIndex(slotTagId);
				int placedFurnitureConfigId = subSlotData.GetPlacedFurnitureConfigId();
				FurnitureSlotScrollItemData item = new FurnitureSlotScrollItemData
				{
					SceneSlotEntityId = slotEntityId,
					PlacedFurnitureId = placedFurnitureConfigId,
					SubSlotIndex = i,
					SlotType = EFurnitureSlotType.SubSlot,
					TagId = slotTagId,
					TagIndex = andIncrementTagIndex,
					ShowTagIndex = false,
					IsSelected = false,
					LineShowState = false,
					RedDotShowState = ModelBase<FurnitureModel>.Instance.CheckFurnitureSlotRedDot(areaData, slotEntityId, i)
				};
				this.SlotDataList.Add(item);
			}
		}
	}

	// Token: 0x06006E22 RID: 28194 RVA: 0x001CA4BC File Offset: 0x001C86BC
	private void SortSlotDataList()
	{
		this.SlotDataList.Sort(delegate(FurnitureSlotScrollItemData a, FurnitureSlotScrollItemData b)
		{
			if (a.SceneSlotEntityId != b.SceneSlotEntityId)
			{
				return a.SceneSlotEntityId - b.SceneSlotEntityId;
			}
			return a.SubSlotIndex - b.SubSlotIndex;
		});
	}

	// Token: 0x06006E23 RID: 28195 RVA: 0x001CA4E8 File Offset: 0x001C86E8
	private int GetAndIncrementTagIndex(int tagId)
	{
		int num;
		this.TagCounterMap.TryGetValue(tagId, out num);
		int num2 = num + 1;
		if (this.TagCounterMap.ContainsKey(tagId))
		{
			this.TagCounterMap[tagId] = num2;
		}
		else
		{
			this.TagCounterMap.Add(tagId, num2);
		}
		return num2;
	}

	// Token: 0x06006E24 RID: 28196 RVA: 0x001CA533 File Offset: 0x001C8733
	private bool IsSlotMatched(FurnitureSlotScrollItemData slotData)
	{
		return slotData.SlotType == this.SelectedSlotType && slotData.SceneSlotEntityId == this.SelectedSceneSlotEntityId && slotData.SubSlotIndex == this.SelectedSubSlotIndex;
	}

	// Token: 0x06006E25 RID: 28197 RVA: 0x001CA564 File Offset: 0x001C8764
	public void SelectSlot(int index)
	{
		int selectedSlotIndex = this.SelectedSlotIndex;
		if (!this.SetSlotSelectedState(index))
		{
			return;
		}
		int selectedSlotIndex2 = this.SelectedSlotIndex;
		GenericScrollViewNew<FurnitureSlotScrollItem, FurnitureSlotScrollItemData> furnitureSlotScrollView = this.FurnitureSlotScrollView;
		GenericLayout<FurnitureSlotScrollItem, FurnitureSlotScrollItemData> genericLayout = (furnitureSlotScrollView != null) ? furnitureSlotScrollView.GetGenericLayout() : null;
		if (genericLayout != null)
		{
			FurnitureSlotScrollItem layoutItemByIndex = genericLayout.GetLayoutItemByIndex(selectedSlotIndex);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.RefreshItemToggle();
			}
			FurnitureSlotScrollItem layoutItemByIndex2 = genericLayout.GetLayoutItemByIndex(selectedSlotIndex2);
			if (layoutItemByIndex2 != null)
			{
				layoutItemByIndex2.RefreshItemToggle();
			}
		}
		this.UpdateFurnitureScrollItemDataList();
		this.RefreshFurnitureScrollItemLayout(true);
		this.EnterCurSelectedSceneSlotCamera(true);
	}

	// Token: 0x06006E26 RID: 28198 RVA: 0x001CA5D8 File Offset: 0x001C87D8
	public void SelectFurniture(int index)
	{
		int selectedFurnitureIndex = this.SelectedFurnitureIndex;
		FurnitureScrollItemData furnitureScrollItemData = (this.FurnitureScrollItemDataList.Count > this.SelectedFurnitureIndex && this.SelectedFurnitureIndex >= 0) ? this.FurnitureScrollItemDataList[this.SelectedFurnitureIndex] : null;
		if (!this.SetFurnitureSelectedState(index))
		{
			return;
		}
		int selectedFurnitureIndex2 = this.SelectedFurnitureIndex;
		FurnitureScrollItemData furnitureScrollItemData2 = (this.FurnitureScrollItemDataList.Count > this.SelectedFurnitureIndex && this.SelectedFurnitureIndex >= 0) ? this.FurnitureScrollItemDataList[this.SelectedFurnitureIndex] : null;
		FurnitureAreaData curEditAreaData = this.CurEditAreaData;
		if (curEditAreaData == null)
		{
			return;
		}
		FurnitureController instance = ControllerBase<FurnitureController>.Instance;
		FurnitureSlotContext slotContext = new FurnitureSlotContext
		{
			SlotEntityId = this.SelectedSceneSlotEntityId,
			SubSlotIndex = this.SelectedSubSlotIndex
		};
		FurnitureAreaSlotContext areaSlotContext = new FurnitureAreaSlotContext
		{
			AreaData = curEditAreaData,
			SlotContext = slotContext
		};
		FurnitureSceneItemPlaceContext placeContext = new FurnitureSceneItemPlaceContext
		{
			AreaSlotContext = areaSlotContext,
			FurnitureId = this.SelectedFurnitureConfigId,
			KeepSubFurniture = true
		};
		instance.PlaceFurnitureAsync(placeContext);
		if (this.SelectedSlotType == EFurnitureSlotType.SceneSlot)
		{
			this.UpdateSlotDataList();
			GenericScrollViewNew<FurnitureSlotScrollItem, FurnitureSlotScrollItemData> furnitureSlotScrollView = this.FurnitureSlotScrollView;
			if (furnitureSlotScrollView != null)
			{
				furnitureSlotScrollView.RefreshByData(this.SlotDataList, null, false);
			}
		}
		else
		{
			FurnitureSlotScrollItemData furnitureSlotScrollItemData = (this.SlotDataList.Count > this.SelectedSlotIndex && this.SelectedSlotIndex >= 0) ? this.SlotDataList[this.SelectedSlotIndex] : null;
			if (furnitureSlotScrollItemData != null)
			{
				furnitureSlotScrollItemData.PlacedFurnitureId = this.SelectedFurnitureConfigId;
				GenericScrollViewNew<FurnitureSlotScrollItem, FurnitureSlotScrollItemData> furnitureSlotScrollView2 = this.FurnitureSlotScrollView;
				if (furnitureSlotScrollView2 != null)
				{
					FurnitureSlotScrollItem scrollItemByIndex = furnitureSlotScrollView2.GetScrollItemByIndex(this.SelectedSlotIndex);
					if (scrollItemByIndex != null)
					{
						scrollItemByIndex.RefreshIcon();
					}
				}
			}
		}
		GenericScrollViewNew<FurnitureScrollItem, FurnitureScrollItemData> furnitureScrollItemScrollView = this.FurnitureScrollItemScrollView;
		GenericLayout<FurnitureScrollItem, FurnitureScrollItemData> genericLayout = (furnitureScrollItemScrollView != null) ? furnitureScrollItemScrollView.GetGenericLayout() : null;
		if (genericLayout != null)
		{
			this.RefreshFurnitureScrollItemAfterSelect(selectedFurnitureIndex, genericLayout);
			this.RefreshFurnitureScrollItemAfterSelect(selectedFurnitureIndex2, genericLayout);
		}
		this.RefreshAtmosphereText(true);
		this.RefreshSaveBtn();
		EFurnitureDesignReportOperationType operationType = this.CurEditAreaData.UsePreset ? EFurnitureDesignReportOperationType.ChangeAfterPreset : EFurnitureDesignReportOperationType.OnlyChange;
		int value = (furnitureScrollItemData != null) ? furnitureScrollItemData.FurnitureConfig.Id : 0;
		int value2 = (furnitureScrollItemData2 != null) ? furnitureScrollItemData2.FurnitureConfig.Id : 0;
		FurnitureDesignReportContext context = new FurnitureDesignReportContext
		{
			AreaId = this.CurEditAreaData.GetAreaId(),
			OperationType = operationType,
			SlotContext = slotContext,
			OldFurnitureId = new int?(value),
			NewFurnitureId = new int?(value2)
		};
		ControllerBase<FurnitureController>.Instance.FurnitureDesignReport(context);
	}

	// Token: 0x06006E27 RID: 28199 RVA: 0x001CA828 File Offset: 0x001C8A28
	private void RefreshFurnitureScrollItemAfterSelect(int index, GenericLayout<FurnitureScrollItem, FurnitureScrollItemData> layout)
	{
		if (index == -1)
		{
			return;
		}
		FurnitureScrollItemData furnitureScrollItemData = (this.FurnitureScrollItemDataList.Count > index) ? this.FurnitureScrollItemDataList[index] : null;
		if (furnitureScrollItemData == null)
		{
			return;
		}
		this.UpdateFurnitureScrollItemDataLeftCount(furnitureScrollItemData);
		FurnitureScrollItem layoutItemByIndex = layout.GetLayoutItemByIndex(index);
		if (layoutItemByIndex != null)
		{
			layoutItemByIndex.RefreshCount();
			layoutItemByIndex.RefreshItemToggle(false);
		}
	}

	// Token: 0x06006E28 RID: 28200 RVA: 0x001CA87C File Offset: 0x001C8A7C
	public void RefreshSwitchAreaBtn()
	{
		bool uiactive = this.AreaList.Count > 1;
		base.GetButton(3).RootUIComp.Get().SetUIActive(uiactive);
		base.GetButton(4).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06006E29 RID: 28201 RVA: 0x001CA8CC File Offset: 0x001C8ACC
	public void ResetSlotSelected()
	{
		this.SelectedSlotIndex = -1;
		this.SelectedSceneSlotEntityId = 0;
		this.SelectedSubSlotIndex = -1;
		this.SelectedSlotType = EFurnitureSlotType.SceneSlot;
		this.SelectedFurnitureIndex = -1;
		this.SelectedFurnitureConfigId = 0;
		this.FurnitureScrollItemDataList.Clear();
	}

	// Token: 0x06006E2A RID: 28202 RVA: 0x001CA904 File Offset: 0x001C8B04
	[NullableContext(2)]
	private void ShowConfirm(EConfirmBoxConfigId confirmBoxConfigId, Action leftFunc = null, Action rightFunc = null)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(confirmBoxConfigId);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap.Add(1, leftFunc);
		confirmBoxDataNew.FunctionMap.Add(2, rightFunc);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06006E2B RID: 28203 RVA: 0x001CA948 File Offset: 0x001C8B48
	[NullableContext(2)]
	public void TrySwitchArea(int areaIndex, int slotEntityId = 0, int subSlotIndex = -1, Action afterSwitch = null)
	{
		FurnitureAreaData curEditAreaData = this.CurEditAreaData;
		if (curEditAreaData == null)
		{
			return;
		}
		FurnitureAreaData originalAreaData = ModelBase<FurnitureModel>.Instance.GetAreaData(this.SelectedAreaId);
		if (originalAreaData == null)
		{
			return;
		}
		FurnitureAreaData originalAreaData2 = originalAreaData;
		if (originalAreaData2 == null || !originalAreaData2.Compare(curEditAreaData))
		{
			this.ShowConfirm(EConfirmBoxConfigId.FurnitureSwitchAreaConfirm, delegate
			{
				this.SaveReport(false);
				ControllerBase<FurnitureController>.Instance.ChangeAreaFurnitureSceneItemsAsync(curEditAreaData, originalAreaData);
				FurnitureAreaData furnitureAreaData = new FurnitureAreaData();
				furnitureAreaData.DeepCopy(originalAreaData);
				if (this.EditorAreaDataMap != null)
				{
					if (this.EditorAreaDataMap.ContainsKey(originalAreaData.GetAreaId()))
					{
						this.EditorAreaDataMap[originalAreaData.GetAreaId()] = furnitureAreaData;
					}
					else
					{
						this.EditorAreaDataMap.Add(originalAreaData.GetAreaId(), furnitureAreaData);
					}
				}
				this.SwitchArea(areaIndex, slotEntityId, subSlotIndex);
				Action afterSwitch3 = afterSwitch;
				if (afterSwitch3 == null)
				{
					return;
				}
				afterSwitch3();
			}, delegate
			{
				this.SaveInternalAsync();
				this.SwitchArea(areaIndex, slotEntityId, subSlotIndex);
				Action afterSwitch3 = afterSwitch;
				if (afterSwitch3 == null)
				{
					return;
				}
				afterSwitch3();
			});
			return;
		}
		this.SwitchArea(areaIndex, slotEntityId, subSlotIndex);
		Action afterSwitch2 = afterSwitch;
		if (afterSwitch2 == null)
		{
			return;
		}
		afterSwitch2();
	}

	// Token: 0x06006E2C RID: 28204 RVA: 0x001CAA1C File Offset: 0x001C8C1C
	public void SwitchArea(int areaIndex, int slotEntityId = 0, int subSlotIndex = -1)
	{
		FurnitureDesignView.<>c__DisplayClass62_0 CS$<>8__locals1 = new FurnitureDesignView.<>c__DisplayClass62_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.areaIndex = areaIndex;
		CS$<>8__locals1.slotEntityId = slotEntityId;
		CS$<>8__locals1.subSlotIndex = subSlotIndex;
		UiAsyncTask task = new UiAsyncTask("SwitchArea", delegate()
		{
			FurnitureDesignView.<>c__DisplayClass62_0.<<SwitchArea>b__0>d <<SwitchArea>b__0>d;
			<<SwitchArea>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<SwitchArea>b__0>d.<>4__this = CS$<>8__locals1;
			<<SwitchArea>b__0>d.<>1__state = -1;
			<<SwitchArea>b__0>d.<>t__builder.Start<FurnitureDesignView.<>c__DisplayClass62_0.<<SwitchArea>b__0>d>(ref <<SwitchArea>b__0>d);
			return <<SwitchArea>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06006E2D RID: 28205 RVA: 0x001CAA6C File Offset: 0x001C8C6C
	public UniTask SwitchAreaAsync(int areaIndex, int slotEntityId = 0, int subSlotIndex = -1)
	{
		FurnitureDesignView.<SwitchAreaAsync>d__63 <SwitchAreaAsync>d__;
		<SwitchAreaAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SwitchAreaAsync>d__.<>4__this = this;
		<SwitchAreaAsync>d__.areaIndex = areaIndex;
		<SwitchAreaAsync>d__.slotEntityId = slotEntityId;
		<SwitchAreaAsync>d__.subSlotIndex = subSlotIndex;
		<SwitchAreaAsync>d__.<>1__state = -1;
		<SwitchAreaAsync>d__.<>t__builder.Start<FurnitureDesignView.<SwitchAreaAsync>d__63>(ref <SwitchAreaAsync>d__);
		return <SwitchAreaAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006E2E RID: 28206 RVA: 0x001CAAC8 File Offset: 0x001C8CC8
	public void SelectAreaCameraToggle()
	{
		this.IsInAreaCamera = true;
		UUIExtendToggle extendToggle = base.GetExtendToggle(21);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(true);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(16);
		if (extendToggle2 != null)
		{
			extendToggle2.RootUIComp.Get().SetUIActive(false);
		}
		UUIExtendToggle extendToggle3 = base.GetExtendToggle(22);
		if (extendToggle3 != null)
		{
			extendToggle3.RootUIComp.Get().SetUIActive(true);
		}
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(this.SelectedAreaId);
		this.FurnitureCameraComponent.EnterAreaCamera(furnitureAreaConfig.Value.CameraList(this.CurAreaCameraIndex), null);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DIY_CamEnterSuccess_Tip", Array.Empty<object>());
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlayOrReplaySequenceByName("Hide", true, null);
		}
		this.RefreshAreaCameraSelectionItem();
	}

	// Token: 0x06006E2F RID: 28207 RVA: 0x001CABAC File Offset: 0x001C8DAC
	public void CancelAreaCameraToggle()
	{
		this.IsInAreaCamera = false;
		UUIExtendToggle extendToggle = base.GetExtendToggle(21);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(false);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(16);
		if (extendToggle2 != null)
		{
			extendToggle2.RootUIComp.Get().SetUIActive(true);
		}
		UUIExtendToggle extendToggle3 = base.GetExtendToggle(22);
		if (extendToggle3 != null)
		{
			extendToggle3.RootUIComp.Get().SetUIActive(false);
		}
		this.EnterCurSelectedSceneSlotCamera(true);
		base.GetItem(17).SetUIActive(true);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DIY_CamBackSuccess_Tip", Array.Empty<object>());
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlayOrReplaySequenceByName("Show", false, null);
		}
		this.RefreshAreaCameraSelectionItem();
	}

	// Token: 0x06006E30 RID: 28208 RVA: 0x001CAC74 File Offset: 0x001C8E74
	public void EnterCurSelectedSceneSlotCamera(bool needFade = true)
	{
		if (this.SelectedSceneSlotEntityId == 0)
		{
			return;
		}
		IFurnitureCameraFadeInContext fadeInContext = null;
		if (!needFade)
		{
			fadeInContext = new FurnitureCameraFadeInContext
			{
				FadeInTime = 0f,
				FadeInExp = 0f
			};
		}
		FurnitureSlotContext slotContext = new FurnitureSlotContext
		{
			SlotEntityId = this.SelectedSceneSlotEntityId,
			SubSlotIndex = this.SelectedSubSlotIndex
		};
		this.FurnitureCameraComponent.EnterSlotCamera(slotContext, fadeInContext);
	}

	// Token: 0x06006E31 RID: 28209 RVA: 0x001CACD6 File Offset: 0x001C8ED6
	public void RefreshFurnitureScrollItemLayout(bool bPlayAnimation = false)
	{
		GenericScrollViewNew<FurnitureScrollItem, FurnitureScrollItemData> furnitureScrollItemScrollView = this.FurnitureScrollItemScrollView;
		if (furnitureScrollItemScrollView != null)
		{
			furnitureScrollItemScrollView.RefreshByData(this.FurnitureScrollItemDataList, new Action(this.LateScrollToFurnitureScrollItem), bPlayAnimation);
		}
		this.RefreshFurnitureEmptyItem();
	}

	// Token: 0x06006E32 RID: 28210 RVA: 0x001CAD04 File Offset: 0x001C8F04
	private void LateScrollToFurnitureScrollItem()
	{
		GenericScrollViewNew<FurnitureScrollItem, FurnitureScrollItemData> furnitureScrollItemScrollView = this.FurnitureScrollItemScrollView;
		UUIItem uuiitem = (furnitureScrollItemScrollView != null) ? furnitureScrollItemScrollView.GetItemByIndex(0) : null;
		if (uuiitem != null)
		{
			GenericScrollViewNew<FurnitureScrollItem, FurnitureScrollItemData> furnitureScrollItemScrollView2 = this.FurnitureScrollItemScrollView;
			if (furnitureScrollItemScrollView2 == null)
			{
				return;
			}
			furnitureScrollItemScrollView2.LateScrollTo(uuiitem, null, false);
		}
	}

	// Token: 0x06006E33 RID: 28211 RVA: 0x001CAD3C File Offset: 0x001C8F3C
	public void RefreshAtmosphereText(bool bPlayTween = false)
	{
		if (this.CurEditAreaData == null)
		{
			return;
		}
		int atmosphere = this.CurEditAreaData.GetAtmosphere();
		if (bPlayTween && this.OldAtmosphere != atmosphere)
		{
			UUIArtText artText = base.GetArtText(18);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.OldAtmosphere);
			artText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			this.AtmosphereTween.PlayTween((float)this.OldAtmosphere, (float)atmosphere, 0.35f, null);
		}
		else
		{
			this.AtmosphereTween.KillTween();
			UUIArtText artText2 = base.GetArtText(18);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(atmosphere);
			artText2.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		this.OldAtmosphere = atmosphere;
	}

	// Token: 0x06006E34 RID: 28212 RVA: 0x001CADE8 File Offset: 0x001C8FE8
	public void RefreshAreaNameText()
	{
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(this.SelectedAreaId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), furnitureAreaConfig.Value.AreaName, Array.Empty<object>());
	}

	// Token: 0x06006E35 RID: 28213 RVA: 0x001CAE2B File Offset: 0x001C902B
	public void RefreshFurnitureEmptyItem()
	{
		base.GetItem(15).SetUIActive(this.FurnitureScrollItemDataList.Count == 0);
	}

	// Token: 0x06006E36 RID: 28214 RVA: 0x001CAE48 File Offset: 0x001C9048
	public void RefreshSaveBtn()
	{
		if (this.CurEditAreaData == null)
		{
			return;
		}
		FurnitureAreaData areaData = ModelBase<FurnitureModel>.Instance.GetAreaData(this.SelectedAreaId);
		if (areaData == null)
		{
			return;
		}
		bool selfInteractive = !areaData.Compare(this.CurEditAreaData);
		base.GetButton(11).SetSelfInteractive(selfInteractive);
	}

	// Token: 0x06006E37 RID: 28215 RVA: 0x001CAE94 File Offset: 0x001C9094
	public void RefreshAreaCameraSelectionItem()
	{
		bool flag = this.IsInAreaCamera && !this.IsInPreview;
		FurnitureAreaCameraSelectionItem areaCameraSelectionItem = this.AreaCameraSelectionItem;
		if (areaCameraSelectionItem != null)
		{
			areaCameraSelectionItem.SetUiActive(flag);
		}
		if (!flag)
		{
			return;
		}
		int id = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(this.SelectedAreaId).Value.CameraList(this.CurAreaCameraIndex);
		SpringFestivalAreaCamera? areaCameraConfig = ConfigBase<FurnitureConfig>.Instance.GetAreaCameraConfig(id);
		FurnitureAreaCameraSelectionItem areaCameraSelectionItem2 = this.AreaCameraSelectionItem;
		if (areaCameraSelectionItem2 == null)
		{
			return;
		}
		areaCameraSelectionItem2.Refresh(areaCameraConfig.Value.CameraName);
	}

	// Token: 0x06006E38 RID: 28216 RVA: 0x001CAF20 File Offset: 0x001C9120
	public void RefreshPresetBtn()
	{
		bool furniturePresetFunctionIsUnlocked = ModelBase<FurnitureModel>.Instance.GetFurniturePresetFunctionIsUnlocked();
		base.GetButton(20).RootUIComp.Get().SetUIActive(furniturePresetFunctionIsUnlocked);
	}

	// Token: 0x06006E39 RID: 28217 RVA: 0x001CAF54 File Offset: 0x001C9154
	public void RefreshAllSlotRedDot()
	{
		if (this.CurEditAreaData == null)
		{
			return;
		}
		foreach (FurnitureSlotScrollItemData furnitureSlotScrollItemData in this.SlotDataList)
		{
			furnitureSlotScrollItemData.RedDotShowState = ModelBase<FurnitureModel>.Instance.CheckFurnitureSlotRedDot(this.CurEditAreaData, furnitureSlotScrollItemData.SceneSlotEntityId, furnitureSlotScrollItemData.SubSlotIndex);
		}
		GenericScrollViewNew<FurnitureSlotScrollItem, FurnitureSlotScrollItemData> furnitureSlotScrollView = this.FurnitureSlotScrollView;
		List<FurnitureSlotScrollItem> list = (furnitureSlotScrollView != null) ? furnitureSlotScrollView.GetScrollItemList() : null;
		if (list == null)
		{
			return;
		}
		foreach (FurnitureSlotScrollItem furnitureSlotScrollItem in list)
		{
			furnitureSlotScrollItem.RefreshRedDot();
		}
	}

	// Token: 0x06006E3A RID: 28218 RVA: 0x001CB01C File Offset: 0x001C921C
	private void OnClickCloseBtn()
	{
		if (this.EditorAreaDataMap == null || this.EditorAreaDataMap.Count == 0)
		{
			base.CloseMe(null);
			return;
		}
		List<FurnitureAreaData> diffOriginalAreaDataList = new List<FurnitureAreaData>();
		List<FurnitureAreaData> diffEditorAreaDataList = new List<FurnitureAreaData>();
		foreach (KeyValuePair<int, FurnitureAreaData> keyValuePair in this.EditorAreaDataMap)
		{
			int key = keyValuePair.Key;
			FurnitureAreaData value = keyValuePair.Value;
			FurnitureAreaData areaData = ModelBase<FurnitureModel>.Instance.GetAreaData(key);
			if (areaData != null && !areaData.Compare(value))
			{
				diffOriginalAreaDataList.Add(areaData);
				diffEditorAreaDataList.Add(value);
			}
		}
		if (diffOriginalAreaDataList.Count == 0)
		{
			base.CloseMe(null);
			return;
		}
		Action<bool> <>9__2;
		this.ShowConfirm(EConfirmBoxConfigId.FurnitureExitConfirm, delegate
		{
			this.SaveReport(false);
			for (int i = 0; i < diffOriginalAreaDataList.Count; i++)
			{
				ControllerBase<FurnitureController>.Instance.ChangeAreaFurnitureSceneItemsAsync(diffEditorAreaDataList[i], diffOriginalAreaDataList[i]);
			}
			this.CloseMe(null);
		}, delegate
		{
			UniTask<bool> task = this.SaveInternalAsync();
			Action<bool> continuationFunction;
			if ((continuationFunction = <>9__2) == null)
			{
				continuationFunction = (<>9__2 = delegate(bool _)
				{
					this.CloseMe(null);
				});
			}
			task.ContinueWith(continuationFunction);
		});
	}

	// Token: 0x06006E3B RID: 28219 RVA: 0x001CB128 File Offset: 0x001C9328
	private void OnAreaCameraSelectionPreBtnClick()
	{
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(this.SelectedAreaId);
		int[] array = furnitureAreaConfig.Value.CameraList();
		if (this.CurAreaCameraIndex == 0)
		{
			this.CurAreaCameraIndex = array.Length - 1;
		}
		else
		{
			this.CurAreaCameraIndex--;
		}
		this.FurnitureCameraComponent.EnterAreaCamera(furnitureAreaConfig.Value.CameraList(this.CurAreaCameraIndex), null);
		this.RefreshAreaCameraSelectionItem();
	}

	// Token: 0x06006E3C RID: 28220 RVA: 0x001CB1A0 File Offset: 0x001C93A0
	private void OnAreaCameraSelectionNextBtnClick()
	{
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(this.SelectedAreaId);
		int[] array = furnitureAreaConfig.Value.CameraList();
		if (this.CurAreaCameraIndex == array.Length - 1)
		{
			this.CurAreaCameraIndex = 0;
		}
		else
		{
			this.CurAreaCameraIndex++;
		}
		this.FurnitureCameraComponent.EnterAreaCamera(furnitureAreaConfig.Value.CameraList(this.CurAreaCameraIndex), null);
		this.RefreshAreaCameraSelectionItem();
	}

	// Token: 0x06006E3D RID: 28221 RVA: 0x001CB21C File Offset: 0x001C941C
	private void OnClickRightBtn()
	{
		int num = this.SelectedAreaIndex + 1;
		if (num >= this.AreaList.Count)
		{
			num = 0;
		}
		this.TrySwitchArea(num, 0, -1, null);
	}

	// Token: 0x06006E3E RID: 28222 RVA: 0x001CB24C File Offset: 0x001C944C
	private void OnClickLeftBtn()
	{
		int num = this.SelectedAreaIndex - 1;
		if (num < 0)
		{
			num = this.AreaList.Count - 1;
		}
		this.TrySwitchArea(num, 0, -1, null);
	}

	// Token: 0x06006E3F RID: 28223 RVA: 0x001CB27E File Offset: 0x001C947E
	private void OnClickSaveBtn()
	{
		this.SaveInternalAsync().ContinueWith(delegate(bool result)
		{
			this.RefreshSaveBtn();
			this.UpdateOriginalPlacedFurnitureId();
			foreach (FurnitureScrollItemData furnitureScrollItemData in this.FurnitureScrollItemDataList)
			{
				furnitureScrollItemData.IsCheck = (furnitureScrollItemData.FurnitureConfig.Id == this.OriginalPlacedFurnitureId);
			}
			GenericScrollViewNew<FurnitureScrollItem, FurnitureScrollItemData> furnitureScrollItemScrollView = this.FurnitureScrollItemScrollView;
			List<FurnitureScrollItem> list = (furnitureScrollItemScrollView != null) ? furnitureScrollItemScrollView.GetScrollItemList() : null;
			if (list != null)
			{
				foreach (FurnitureScrollItem furnitureScrollItem in list)
				{
					furnitureScrollItem.RefreshCheckItem();
				}
			}
		});
	}

	// Token: 0x06006E40 RID: 28224 RVA: 0x001CB298 File Offset: 0x001C9498
	[NullableContext(0)]
	private UniTask<bool> SaveInternalAsync()
	{
		FurnitureDesignView.<SaveInternalAsync>d__82 <SaveInternalAsync>d__;
		<SaveInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SaveInternalAsync>d__.<>4__this = this;
		<SaveInternalAsync>d__.<>1__state = -1;
		<SaveInternalAsync>d__.<>t__builder.Start<FurnitureDesignView.<SaveInternalAsync>d__82>(ref <SaveInternalAsync>d__);
		return <SaveInternalAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006E41 RID: 28225 RVA: 0x001CB2DC File Offset: 0x001C94DC
	private UniTask TeleportInternalAsync(bool bSave, bool recover)
	{
		FurnitureDesignView.<TeleportInternalAsync>d__83 <TeleportInternalAsync>d__;
		<TeleportInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TeleportInternalAsync>d__.<>4__this = this;
		<TeleportInternalAsync>d__.bSave = bSave;
		<TeleportInternalAsync>d__.recover = recover;
		<TeleportInternalAsync>d__.<>1__state = -1;
		<TeleportInternalAsync>d__.<>t__builder.Start<FurnitureDesignView.<TeleportInternalAsync>d__83>(ref <TeleportInternalAsync>d__);
		return <TeleportInternalAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006E42 RID: 28226 RVA: 0x001CB330 File Offset: 0x001C9530
	[NullableContext(0)]
	private UniTask<bool> ResetToBattleViewAsync()
	{
		FurnitureDesignView.<ResetToBattleViewAsync>d__84 <ResetToBattleViewAsync>d__;
		<ResetToBattleViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<ResetToBattleViewAsync>d__.<>1__state = -1;
		<ResetToBattleViewAsync>d__.<>t__builder.Start<FurnitureDesignView.<ResetToBattleViewAsync>d__84>(ref <ResetToBattleViewAsync>d__);
		return <ResetToBattleViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006E43 RID: 28227 RVA: 0x001CB36B File Offset: 0x001C956B
	private void OnClickAreaCameraToggle(EToggleState _)
	{
		this.SelectAreaCameraToggle();
	}

	// Token: 0x06006E44 RID: 28228 RVA: 0x001CB374 File Offset: 0x001C9574
	private void OnClickPresetBtn()
	{
		if (this.CurEditAreaData == null)
		{
			return;
		}
		FurniturePresetViewOpenData param = new FurniturePresetViewOpenData
		{
			AreaData = this.CurEditAreaData,
			OnApplyDelegate = new Action<FurnitureAreaData>(this.OnApplyFurniturePreset)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FurniturePresetView, param, null);
	}

	// Token: 0x06006E45 RID: 28229 RVA: 0x001CB3BF File Offset: 0x001C95BF
	private bool CanAreaCameraToggleExecuteChange()
	{
		return false;
	}

	// Token: 0x06006E46 RID: 28230 RVA: 0x001CB3C2 File Offset: 0x001C95C2
	private bool CanBottomCameraToggleExecuteChange()
	{
		return false;
	}

	// Token: 0x06006E47 RID: 28231 RVA: 0x001CB3C5 File Offset: 0x001C95C5
	private bool CanEyeToggleExecuteChange()
	{
		return false;
	}

	// Token: 0x06006E48 RID: 28232 RVA: 0x001CB3C8 File Offset: 0x001C95C8
	private void OnClickEyeToggle(EToggleState _)
	{
		this.IsInPreview = true;
		base.GetButton(23).RootUIComp.Get().SetUIActive(true);
		UUIExtendToggle extendToggle = base.GetExtendToggle(22);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(false);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(21);
		if (extendToggle2 != null)
		{
			extendToggle2.RootUIComp.Get().SetUIActive(false);
		}
		this.RefreshAreaCameraSelectionItem();
	}

	// Token: 0x06006E49 RID: 28233 RVA: 0x001CB440 File Offset: 0x001C9640
	private void OnClickMaskButton()
	{
		this.IsInPreview = false;
		base.GetButton(23).RootUIComp.Get().SetUIActive(false);
		UUIExtendToggle extendToggle = base.GetExtendToggle(22);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(true);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(21);
		if (extendToggle2 != null)
		{
			extendToggle2.RootUIComp.Get().SetUIActive(true);
		}
		this.RefreshAreaCameraSelectionItem();
	}

	// Token: 0x06006E4A RID: 28234 RVA: 0x001CB4B7 File Offset: 0x001C96B7
	private void OnClickBottomCameraToggle(EToggleState _)
	{
		this.CancelAreaCameraToggle();
	}

	// Token: 0x06006E4B RID: 28235 RVA: 0x001CB4C0 File Offset: 0x001C96C0
	private void OnClickSaveAndTeleportBtn()
	{
		if (this.CurEditAreaData == null)
		{
			return;
		}
		FurnitureAreaData areaData = ModelBase<FurnitureModel>.Instance.GetAreaData(this.SelectedAreaId);
		if (areaData == null)
		{
			return;
		}
		if (!areaData.Compare(this.CurEditAreaData))
		{
			Action leftFunc = delegate()
			{
				this.TeleportInternalAsync(false, true);
			};
			Action rightFunc = delegate()
			{
				this.TeleportInternalAsync(true, false);
			};
			this.ShowConfirm(EConfirmBoxConfigId.FurnitureDesignSaveAndTeleportConfirm, leftFunc, rightFunc);
			return;
		}
		Action rightFunc2 = delegate()
		{
			this.TeleportInternalAsync(false, false);
		};
		this.ShowConfirm(EConfirmBoxConfigId.FurnitureTeleportConfirm, null, rightFunc2);
	}

	// Token: 0x06006E4C RID: 28236 RVA: 0x001CB540 File Offset: 0x001C9740
	private void OnApplyFurniturePreset(FurnitureAreaData areaData)
	{
		this.UpdateSlotDataList();
		this.UpdateFurnitureScrollItemDataList();
		GenericScrollViewNew<FurnitureSlotScrollItem, FurnitureSlotScrollItemData> furnitureSlotScrollView = this.FurnitureSlotScrollView;
		if (furnitureSlotScrollView != null)
		{
			furnitureSlotScrollView.RefreshByData(this.SlotDataList, null, false);
		}
		this.RefreshFurnitureScrollItemLayout(false);
		this.RefreshAtmosphereText(true);
		this.RefreshSaveBtn();
		if (this.CurEditAreaData != null)
		{
			this.CurEditAreaData.UsePreset = true;
		}
		EFurnitureDesignReportOperationType operationType = EFurnitureDesignReportOperationType.Preset;
		FurnitureDesignReportContext context = new FurnitureDesignReportContext
		{
			AreaId = this.CurEditAreaData.GetAreaId(),
			OperationType = operationType
		};
		ControllerBase<FurnitureController>.Instance.FurnitureDesignReport(context);
	}

	// Token: 0x06006E4D RID: 28237 RVA: 0x001CB5C5 File Offset: 0x001C97C5
	private void OnClickFurnitureSlotScrollItem(int index)
	{
		this.SelectSlot(index);
	}

	// Token: 0x06006E4E RID: 28238 RVA: 0x001CB5CE File Offset: 0x001C97CE
	private void OnFurnitureItemSelected(int index)
	{
		this.SelectFurniture(index);
	}

	// Token: 0x06006E4F RID: 28239 RVA: 0x001CB5D7 File Offset: 0x001C97D7
	private void OnFurnitureItemUnSelected(int index)
	{
		this.SelectFurniture(-1);
	}

	// Token: 0x06006E50 RID: 28240 RVA: 0x001CB5E0 File Offset: 0x001C97E0
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "Hide")
		{
			base.GetItem(17).SetUIActive(false);
		}
	}

	// Token: 0x06006E51 RID: 28241 RVA: 0x001CB600 File Offset: 0x001C9800
	private EFurnitureCanNotClickReason CheckFurnitureCanClick(int index)
	{
		FurnitureScrollItemData furnitureScrollItemData = (this.FurnitureScrollItemDataList.Count > index) ? this.FurnitureScrollItemDataList[index] : null;
		if (furnitureScrollItemData == null)
		{
			return EFurnitureCanNotClickReason.ConfigNotFound;
		}
		if (furnitureScrollItemData.IsLock)
		{
			return EFurnitureCanNotClickReason.Lock;
		}
		int limitCount = furnitureScrollItemData.FurnitureConfig.LimitCount;
		if (!furnitureScrollItemData.IsSelected && limitCount > 0 && furnitureScrollItemData.LeftCount <= 0)
		{
			return EFurnitureCanNotClickReason.CountLimit;
		}
		int tagId = furnitureScrollItemData.FurnitureConfig.TagId;
		if (tagId <= 0)
		{
			return EFurnitureCanNotClickReason.ConfigNotFound;
		}
		FurnitureDiyTag? furnitureTagConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureTagConfig(tagId);
		if (furnitureTagConfig == null)
		{
			return EFurnitureCanNotClickReason.ConfigNotFound;
		}
		if (furnitureTagConfig.Value.CanUnPlace || !furnitureScrollItemData.IsSelected)
		{
			return EFurnitureCanNotClickReason.None;
		}
		return EFurnitureCanNotClickReason.CanNotUnPlace;
	}

	// Token: 0x06006E52 RID: 28242 RVA: 0x001CB6AB File Offset: 0x001C98AB
	private bool OnFurnitureItemCanToggleChanged(int index)
	{
		return this.CheckFurnitureCanClick(index) == EFurnitureCanNotClickReason.None;
	}

	// Token: 0x06006E53 RID: 28243 RVA: 0x001CB6B8 File Offset: 0x001C98B8
	private void OnFurnitureItemPointUpCallBack(int index)
	{
		EFurnitureCanNotClickReason efurnitureCanNotClickReason = this.CheckFurnitureCanClick(index);
		if (efurnitureCanNotClickReason == EFurnitureCanNotClickReason.None)
		{
			return;
		}
		switch (efurnitureCanNotClickReason)
		{
		case EFurnitureCanNotClickReason.Lock:
			this.HandleLockedFurniture(index);
			return;
		case EFurnitureCanNotClickReason.CountLimit:
			this.HandleCountLimitedFurniture(index);
			return;
		case EFurnitureCanNotClickReason.CanNotUnPlace:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DIY_RemoveBannedTips", Array.Empty<object>());
			return;
		default:
			return;
		}
	}

	// Token: 0x06006E54 RID: 28244 RVA: 0x001CB70C File Offset: 0x001C990C
	private void HandleLockedFurniture(int index)
	{
		Furniture? furniture;
		if (this.FurnitureScrollItemDataList.Count <= index)
		{
			furniture = null;
		}
		else
		{
			FurnitureScrollItemData furnitureScrollItemData = this.FurnitureScrollItemDataList[index];
			furniture = ((furnitureScrollItemData != null) ? new Furniture?(furnitureScrollItemData.FurnitureConfig) : null);
		}
		Furniture? furniture2 = furniture;
		if (furniture2 == null)
		{
			return;
		}
		if (furniture2.Value.SourceType == 1)
		{
			this.HandleShopSourceFurniture(furniture2.Value);
			return;
		}
		if (furniture2.Value.SourceType == 2)
		{
			this.HandleGiftSourceFurniture(furniture2.Value);
			return;
		}
		if (furniture2.Value.SourceType == 3)
		{
			this.HandleAtmosphereSourceFurniture(furniture2.Value);
		}
	}

	// Token: 0x06006E55 RID: 28245 RVA: 0x001CB7C4 File Offset: 0x001C99C4
	private void HandleShopSourceFurniture(Furniture furnitureConfig)
	{
		int goodsId = furnitureConfig.GetWayId;
		if (goodsId <= 0)
		{
			return;
		}
		PayShopGoods payShopGoods = ModelBase<PayShopModel>.Instance.GetPayShopGoods(goodsId);
		if (payShopGoods == null)
		{
			return;
		}
		bool furnitureShopFunctionIsUnlocked = ModelBase<FurnitureModel>.Instance.GetFurnitureShopFunctionIsUnlocked();
		Action jumpFunction = null;
		string lockReasonTextId;
		if (!furnitureShopFunctionIsUnlocked)
		{
			lockReasonTextId = "DIY_Furniture_Obtain_AtmoLockedState";
		}
		else
		{
			lockReasonTextId = (payShopGoods.IfCanBuy() ? "" : payShopGoods.GetConditionTextId());
			jumpFunction = delegate()
			{
				this.JumpToFurnitureShop(goodsId);
			};
		}
		FurnitureGetWayViewData param = new FurnitureGetWayViewData
		{
			FurnitureConfig = furnitureConfig,
			LockReason = EFurnitureLockReason.Shop,
			LockReasonTextId = lockReasonTextId,
			JumpFunction = jumpFunction
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FurnitureGetWayView, param, null);
	}

	// Token: 0x06006E56 RID: 28246 RVA: 0x001CB880 File Offset: 0x001C9A80
	private void HandleGiftSourceFurniture(Furniture furnitureConfig)
	{
		FurnitureGetWayViewData param = new FurnitureGetWayViewData
		{
			FurnitureConfig = furnitureConfig,
			LockReason = EFurnitureLockReason.Gift,
			LockReasonTextId = "",
			JumpFunction = delegate
			{
				this.JumpToFurnitureGift(furnitureConfig);
			}
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FurnitureGetWayView, param, null);
	}

	// Token: 0x06006E57 RID: 28247 RVA: 0x001CB8E8 File Offset: 0x001C9AE8
	private void HandleAtmosphereSourceFurniture(Furniture furnitureConfig)
	{
		FurnitureGetWayViewData param = new FurnitureGetWayViewData
		{
			FurnitureConfig = furnitureConfig,
			LockReason = EFurnitureLockReason.Atmosphere,
			LockReasonTextId = "DIY_Furniture_Gain_AtmoLockedState",
			LockReasonTextParams = new string[]
			{
				furnitureConfig.GetWayId.ToString()
			}
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FurnitureGetWayView, param, null);
	}

	// Token: 0x06006E58 RID: 28248 RVA: 0x001CB948 File Offset: 0x001C9B48
	private void HandleCountLimitedFurniture(int index)
	{
		if (this.EditorAreaDataMap == null || this.CurEditAreaData == null)
		{
			return;
		}
		Furniture? furniture;
		if (this.FurnitureScrollItemDataList.Count <= index)
		{
			furniture = null;
		}
		else
		{
			FurnitureScrollItemData furnitureScrollItemData = this.FurnitureScrollItemDataList[index];
			furniture = ((furnitureScrollItemData != null) ? new Furniture?(furnitureScrollItemData.FurnitureConfig) : null);
		}
		Furniture? furniture2 = furniture;
		if (furniture2 == null)
		{
			return;
		}
		int id = furniture2.Value.Id;
		IFurnitureAreaSlotContext oldAreaSlotContext = ModelBase<FurnitureModel>.Instance.FindFurniturePlacedSlot(id, this.EditorAreaDataMap);
		if (oldAreaSlotContext == null)
		{
			return;
		}
		FurnitureSlotContext slotContext = new FurnitureSlotContext
		{
			SlotEntityId = this.SelectedSceneSlotEntityId,
			SubSlotIndex = this.SelectedSubSlotIndex
		};
		FurnitureAreaSlotContext targetContext = new FurnitureAreaSlotContext
		{
			AreaData = this.CurEditAreaData,
			SlotContext = slotContext
		};
		FurniturePlaceToNewSlotContext placeToNewSlotContext = new FurniturePlaceToNewSlotContext
		{
			SourceContext = oldAreaSlotContext,
			TargetContext = targetContext
		};
		SpringFestivalArea? furnitureAreaConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureAreaConfig(oldAreaSlotContext.AreaData.GetAreaId());
		FurnitureGetWayViewData param = new FurnitureGetWayViewData
		{
			FurnitureConfig = furniture2.Value,
			LockReason = EFurnitureLockReason.Occupied,
			LockReasonTextId = "DIY_OccupiedWindow_OccState_1",
			LockReasonTextParams = new string[]
			{
				ConfigMultiTextLang.GetLocalTextNew(furnitureAreaConfig.Value.AreaName, null)
			},
			JumpFunction = delegate
			{
				this.JumpToSlot(oldAreaSlotContext);
			},
			ConfirmFunction = delegate
			{
				this.ShowFurniturePlaceToNewSlotConfirm(placeToNewSlotContext);
			}
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FurnitureGetWayView, param, null);
	}

	// Token: 0x06006E59 RID: 28249 RVA: 0x001CBAF0 File Offset: 0x001C9CF0
	private void OnFurnitureItemPointerEnter(int index)
	{
		FurnitureScrollItemData furnitureScrollItemData = (this.FurnitureScrollItemDataList.Count > index) ? this.FurnitureScrollItemDataList[index] : null;
		if (furnitureScrollItemData == null)
		{
			return;
		}
		if (!furnitureScrollItemData.RedDotShowState)
		{
			return;
		}
		ControllerBase<FurnitureController>.Instance.SetFurnitureDesignItemRedDotAsRead(furnitureScrollItemData.FurnitureConfig.Id);
		furnitureScrollItemData.RedDotShowState = false;
		GenericScrollViewNew<FurnitureScrollItem, FurnitureScrollItemData> furnitureScrollItemScrollView = this.FurnitureScrollItemScrollView;
		FurnitureScrollItem furnitureScrollItem = (furnitureScrollItemScrollView != null) ? furnitureScrollItemScrollView.GetScrollItemByIndex(index) : null;
		if (furnitureScrollItem != null)
		{
			furnitureScrollItem.RefreshRedDot();
		}
		this.RefreshAllSlotRedDot();
	}

	// Token: 0x06006E5A RID: 28250 RVA: 0x001CBB6C File Offset: 0x001C9D6C
	private void JumpToFurnitureShop(int goodsId)
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.FurnitureGetWayView, delegate(bool result)
		{
			if (result)
			{
				ControllerBase<FurnitureController>.Instance.OpenFurnitureShopViewAsync(goodsId);
			}
		});
	}

	// Token: 0x06006E5B RID: 28251 RVA: 0x001CBBA4 File Offset: 0x001C9DA4
	private void JumpToFurnitureGift(Furniture furnitureConfig)
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.FurnitureGetWayView, delegate(bool result)
		{
			ControllerBase<FurnitureController>.Instance.TryJumpToFurnitureGift(furnitureConfig);
		});
	}

	// Token: 0x06006E5C RID: 28252 RVA: 0x001CBBDC File Offset: 0x001C9DDC
	private void JumpToSlot(IFurnitureAreaSlotContext areaSlotContext)
	{
		Action afterSwitch = delegate()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FurnitureGetWayView, null);
		};
		int areaId = areaSlotContext.AreaData.GetAreaId();
		int num = this.AreaList.IndexOf(areaId);
		if (num == -1)
		{
			return;
		}
		IFurnitureSlotContext slotContext = areaSlotContext.SlotContext;
		int slotEntityId = slotContext.SlotEntityId;
		int subSlotIndex = slotContext.SubSlotIndex;
		this.TrySwitchArea(num, slotEntityId, subSlotIndex, afterSwitch);
	}

	// Token: 0x06006E5D RID: 28253 RVA: 0x001CBC48 File Offset: 0x001C9E48
	private void ShowFurniturePlaceToNewSlotConfirm(IFurniturePlaceToNewSlotContext placeToNewSlotContext)
	{
		Action rightFunc = delegate()
		{
			this.PlaceToNewSlotAsync(placeToNewSlotContext);
		};
		this.ShowConfirm(EConfirmBoxConfigId.FurniturePlaceToNewSlotConfirm, null, rightFunc);
	}

	// Token: 0x06006E5E RID: 28254 RVA: 0x001CBC84 File Offset: 0x001C9E84
	private UniTask PlaceToNewSlotAsync(IFurniturePlaceToNewSlotContext placeToNewSlotContext)
	{
		FurnitureDesignView.<PlaceToNewSlotAsync>d__112 <PlaceToNewSlotAsync>d__;
		<PlaceToNewSlotAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaceToNewSlotAsync>d__.<>4__this = this;
		<PlaceToNewSlotAsync>d__.placeToNewSlotContext = placeToNewSlotContext;
		<PlaceToNewSlotAsync>d__.<>1__state = -1;
		<PlaceToNewSlotAsync>d__.<>t__builder.Start<FurnitureDesignView.<PlaceToNewSlotAsync>d__112>(ref <PlaceToNewSlotAsync>d__);
		return <PlaceToNewSlotAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006E5F RID: 28255 RVA: 0x001CBCCF File Offset: 0x001C9ECF
	private FurnitureSlotScrollItem InitFurnitureSlotScrollItem()
	{
		return new FurnitureSlotScrollItem
		{
			OnItemSelected = new Action<int>(this.OnClickFurnitureSlotScrollItem)
		};
	}

	// Token: 0x06006E60 RID: 28256 RVA: 0x001CBCE8 File Offset: 0x001C9EE8
	private FurnitureScrollItem InitFurnitureItem()
	{
		return new FurnitureScrollItem
		{
			OnItemSelectedDelegate = new Action<int>(this.OnFurnitureItemSelected),
			OnItemUnSelectedDelegate = new Action<int>(this.OnFurnitureItemUnSelected),
			CanToggleChangedDelegate = new Func<int, bool>(this.OnFurnitureItemCanToggleChanged),
			OnPointUpCallBackDelegate = new Action<int>(this.OnFurnitureItemPointUpCallBack),
			OnPointerEnterDelegate = new Action<int>(this.OnFurnitureItemPointerEnter)
		};
	}

	// Token: 0x06006E61 RID: 28257 RVA: 0x001CBD54 File Offset: 0x001C9F54
	private FurnitureAreaPointItem InitAreaPointItem()
	{
		return new FurnitureAreaPointItem();
	}

	// Token: 0x06006E62 RID: 28258 RVA: 0x001CBD5C File Offset: 0x001C9F5C
	private void OnAtmosphereTweenUpdate(float value)
	{
		int value2 = (int)value;
		UUIArtText artText = base.GetArtText(18);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
		artText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x06006E63 RID: 28259 RVA: 0x001CBD94 File Offset: 0x001C9F94
	private void SaveReport(bool bSave)
	{
		FurnitureAreaData areaData = ModelBase<FurnitureModel>.Instance.GetAreaData(this.SelectedAreaId);
		FurnitureAreaData curEditAreaData = this.CurEditAreaData;
		if (areaData == null || curEditAreaData == null)
		{
			return;
		}
		FurnitureSaveReportContext context = new FurnitureSaveReportContext
		{
			AreaId = this.SelectedAreaId,
			OldAreaData = areaData,
			NewAreaData = curEditAreaData,
			IsSave = bSave
		};
		ControllerBase<FurnitureController>.Instance.FurnitureSaveReport(context);
	}

	// Token: 0x06006E64 RID: 28260 RVA: 0x001CBDF4 File Offset: 0x001C9FF4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		string a = configParams[0];
		if (a == "Furniture")
		{
			int index = int.Parse(configParams[1]);
			GenericScrollViewNew<FurnitureScrollItem, FurnitureScrollItemData> furnitureScrollItemScrollView = this.FurnitureScrollItemScrollView;
			FurnitureScrollItem furnitureScrollItem = (furnitureScrollItemScrollView != null) ? furnitureScrollItemScrollView.GetScrollItemByIndex(index) : null;
			UUIItem uuiitem = (furnitureScrollItem != null) ? furnitureScrollItem.GetRootItem() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}
		else
		{
			if (!(a == "FurnitureSlot"))
			{
				return null;
			}
			int index2 = int.Parse(configParams[1]);
			GenericScrollViewNew<FurnitureSlotScrollItem, FurnitureSlotScrollItemData> furnitureSlotScrollView = this.FurnitureSlotScrollView;
			FurnitureSlotScrollItem furnitureSlotScrollItem = (furnitureSlotScrollView != null) ? furnitureSlotScrollView.GetScrollItemByIndex(index2) : null;
			UUIItem uuiitem2 = (furnitureSlotScrollItem != null) ? furnitureSlotScrollItem.GetRootItem() : null;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
	}

	// Token: 0x04003470 RID: 13424
	private int MapId;

	// Token: 0x04003471 RID: 13425
	private List<int> AreaList = new List<int>();

	// Token: 0x04003472 RID: 13426
	private int SelectedAreaIndex = -1;

	// Token: 0x04003473 RID: 13427
	private int SelectedAreaId;

	// Token: 0x04003474 RID: 13428
	private int SelectedSlotIndex = -1;

	// Token: 0x04003475 RID: 13429
	private int SelectedSceneSlotEntityId;

	// Token: 0x04003476 RID: 13430
	private int SelectedSubSlotIndex = -1;

	// Token: 0x04003477 RID: 13431
	private EFurnitureSlotType SelectedSlotType;

	// Token: 0x04003478 RID: 13432
	private int SelectedFurnitureIndex = -1;

	// Token: 0x04003479 RID: 13433
	private int SelectedFurnitureConfigId;

	// Token: 0x0400347A RID: 13434
	private int OriginalPlacedFurnitureId;

	// Token: 0x0400347B RID: 13435
	private int CurAreaCameraIndex;

	// Token: 0x0400347C RID: 13436
	[Nullable(2)]
	private FurnitureAreaData CurEditAreaData;

	// Token: 0x0400347D RID: 13437
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, FurnitureAreaData> EditorAreaDataMap;

	// Token: 0x0400347E RID: 13438
	private readonly List<FurnitureSlotScrollItemData> SlotDataList = new List<FurnitureSlotScrollItemData>();

	// Token: 0x0400347F RID: 13439
	private readonly List<FurnitureScrollItemData> FurnitureScrollItemDataList = new List<FurnitureScrollItemData>();

	// Token: 0x04003480 RID: 13440
	private readonly List<bool> AreaPointDataList = new List<bool>();

	// Token: 0x04003481 RID: 13441
	private readonly Dictionary<int, int> TagCounterMap = new Dictionary<int, int>();

	// Token: 0x04003482 RID: 13442
	private bool IsExchanging;

	// Token: 0x04003483 RID: 13443
	private int OldAtmosphere;

	// Token: 0x04003484 RID: 13444
	private bool IsInAreaCamera;

	// Token: 0x04003485 RID: 13445
	private bool IsInPreview;

	// Token: 0x04003486 RID: 13446
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003487 RID: 13447
	[Nullable(2)]
	private FurnitureAreaCameraSelectionItem AreaCameraSelectionItem;

	// Token: 0x04003488 RID: 13448
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<FurnitureSlotScrollItem, FurnitureSlotScrollItemData> FurnitureSlotScrollView;

	// Token: 0x04003489 RID: 13449
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<FurnitureScrollItem, FurnitureScrollItemData> FurnitureScrollItemScrollView;

	// Token: 0x0400348A RID: 13450
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<FurnitureAreaPointItem, bool> AreaPointLayout;

	// Token: 0x0400348B RID: 13451
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x0400348C RID: 13452
	protected LguiFloatTween AtmosphereTween;

	// Token: 0x0400348D RID: 13453
	private readonly FurnitureCameraComponent FurnitureCameraComponent = new FurnitureCameraComponent();
}
