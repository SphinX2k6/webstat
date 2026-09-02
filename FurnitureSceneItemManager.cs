using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001071 RID: 4209
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSceneItemManager
{
	// Token: 0x06006D86 RID: 28038 RVA: 0x001C7BDC File Offset: 0x001C5DDC
	[NullableContext(2)]
	public ISceneSlotItemInfo GetSceneSlotItemInfo(int slotEntityId)
	{
		ISceneSlotItemInfo result;
		if (!this.SceneSlotItemInfoMap.TryGetValue(slotEntityId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06006D87 RID: 28039 RVA: 0x001C7BFC File Offset: 0x001C5DFC
	public ISceneSlotItemInfo GetOrCreateSceneSlotItemInfo(int slotEntityId)
	{
		ISceneSlotItemInfo sceneSlotItemInfo = this.GetSceneSlotItemInfo(slotEntityId);
		if (sceneSlotItemInfo == null)
		{
			sceneSlotItemInfo = new SceneSlotItemInfo
			{
				SlotEntityId = slotEntityId,
				RootFurnitureSceneItem = null,
				SubFurnitureSceneItemMap = new Dictionary<int, FurnitureSceneItemBase>()
			};
			this.SceneSlotItemInfoMap[slotEntityId] = sceneSlotItemInfo;
		}
		return sceneSlotItemInfo;
	}

	// Token: 0x06006D88 RID: 28040 RVA: 0x001C7C41 File Offset: 0x001C5E41
	public Dictionary<int, ISceneSlotItemInfo> GetSceneSlotItemInfoMap()
	{
		return this.SceneSlotItemInfoMap;
	}

	// Token: 0x06006D89 RID: 28041 RVA: 0x001C7C4C File Offset: 0x001C5E4C
	private FurnitureSceneItemBase CreateFurnitureSceneItem(int furnitureConfigId)
	{
		switch (ModelBase<FurnitureModel>.Instance.GetFurnitureSceneItemType(furnitureConfigId))
		{
		case EFurnitureSceneItemType.SingleLevel:
			return new FurnitureSingleLevelItem(furnitureConfigId);
		case EFurnitureSceneItemType.SingleEntity:
			return new FurnitureSingleEntityItem(furnitureConfigId);
		case EFurnitureSceneItemType.GroupEntity:
			return new FurnitureGroupEntityItem(furnitureConfigId);
		default:
			return new FurnitureSingleLevelItem(furnitureConfigId);
		}
	}

	// Token: 0x06006D8A RID: 28042 RVA: 0x001C7C94 File Offset: 0x001C5E94
	public bool HasRootFurnitureSceneItem(int slotEntityId)
	{
		ISceneSlotItemInfo sceneSlotItemInfo = this.GetSceneSlotItemInfo(slotEntityId);
		return ((sceneSlotItemInfo != null) ? sceneSlotItemInfo.RootFurnitureSceneItem : null) != null;
	}

	// Token: 0x06006D8B RID: 28043 RVA: 0x001C7CAC File Offset: 0x001C5EAC
	public bool HasSubFurnitureSceneItem(int slotEntityId, int slotIndex)
	{
		ISceneSlotItemInfo sceneSlotItemInfo = this.GetSceneSlotItemInfo(slotEntityId);
		return sceneSlotItemInfo != null && sceneSlotItemInfo.SubFurnitureSceneItemMap.ContainsKey(slotIndex);
	}

	// Token: 0x06006D8C RID: 28044 RVA: 0x001C7CC8 File Offset: 0x001C5EC8
	[NullableContext(0)]
	public UniTask<bool> LoadRootFurnitureSceneItemAsync(int slotEntityId, int furnitureConfigId, [Nullable(1)] Transform transform, bool bShow)
	{
		FurnitureSceneItemManager.<LoadRootFurnitureSceneItemAsync>d__8 <LoadRootFurnitureSceneItemAsync>d__;
		<LoadRootFurnitureSceneItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadRootFurnitureSceneItemAsync>d__.<>4__this = this;
		<LoadRootFurnitureSceneItemAsync>d__.slotEntityId = slotEntityId;
		<LoadRootFurnitureSceneItemAsync>d__.furnitureConfigId = furnitureConfigId;
		<LoadRootFurnitureSceneItemAsync>d__.transform = transform;
		<LoadRootFurnitureSceneItemAsync>d__.bShow = bShow;
		<LoadRootFurnitureSceneItemAsync>d__.<>1__state = -1;
		<LoadRootFurnitureSceneItemAsync>d__.<>t__builder.Start<FurnitureSceneItemManager.<LoadRootFurnitureSceneItemAsync>d__8>(ref <LoadRootFurnitureSceneItemAsync>d__);
		return <LoadRootFurnitureSceneItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006D8D RID: 28045 RVA: 0x001C7D2C File Offset: 0x001C5F2C
	public void UnloadRootFurnitureSceneItem(int slotEntityId)
	{
		ISceneSlotItemInfo sceneSlotItemInfo = this.GetSceneSlotItemInfo(slotEntityId);
		if (sceneSlotItemInfo != null)
		{
			this.UnloadRootFurnitureSceneItemInternal(sceneSlotItemInfo);
		}
	}

	// Token: 0x06006D8E RID: 28046 RVA: 0x001C7D4C File Offset: 0x001C5F4C
	private void UnloadRootFurnitureSceneItemInternal(ISceneSlotItemInfo sceneSlotItemInfo)
	{
		FurnitureSceneItemBase rootFurnitureSceneItem = sceneSlotItemInfo.RootFurnitureSceneItem;
		if (rootFurnitureSceneItem != null)
		{
			rootFurnitureSceneItem.Unload();
			sceneSlotItemInfo.RootFurnitureSceneItem = null;
		}
	}

	// Token: 0x06006D8F RID: 28047 RVA: 0x001C7D70 File Offset: 0x001C5F70
	[NullableContext(0)]
	public UniTask<bool> LoadSubFurnitureSceneItemAsync(int slotEntityId, int furnitureConfigId, int slotIndex, [Nullable(1)] Transform transform, bool bShow)
	{
		FurnitureSceneItemManager.<LoadSubFurnitureSceneItemAsync>d__11 <LoadSubFurnitureSceneItemAsync>d__;
		<LoadSubFurnitureSceneItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadSubFurnitureSceneItemAsync>d__.<>4__this = this;
		<LoadSubFurnitureSceneItemAsync>d__.slotEntityId = slotEntityId;
		<LoadSubFurnitureSceneItemAsync>d__.furnitureConfigId = furnitureConfigId;
		<LoadSubFurnitureSceneItemAsync>d__.slotIndex = slotIndex;
		<LoadSubFurnitureSceneItemAsync>d__.transform = transform;
		<LoadSubFurnitureSceneItemAsync>d__.bShow = bShow;
		<LoadSubFurnitureSceneItemAsync>d__.<>1__state = -1;
		<LoadSubFurnitureSceneItemAsync>d__.<>t__builder.Start<FurnitureSceneItemManager.<LoadSubFurnitureSceneItemAsync>d__11>(ref <LoadSubFurnitureSceneItemAsync>d__);
		return <LoadSubFurnitureSceneItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006D90 RID: 28048 RVA: 0x001C7DE0 File Offset: 0x001C5FE0
	public void ShowRootFurnitureSceneItem(int slotEntityId)
	{
		ISceneSlotItemInfo sceneSlotItemInfo = this.GetSceneSlotItemInfo(slotEntityId);
		if (sceneSlotItemInfo != null)
		{
			FurnitureSceneItemBase rootFurnitureSceneItem = sceneSlotItemInfo.RootFurnitureSceneItem;
			if (rootFurnitureSceneItem == null)
			{
				return;
			}
			rootFurnitureSceneItem.Show();
		}
	}

	// Token: 0x06006D91 RID: 28049 RVA: 0x001C7E0C File Offset: 0x001C600C
	public void ShowSubFurnitureSceneItem(int slotEntityId, int slotIndex)
	{
		ISceneSlotItemInfo sceneSlotItemInfo = this.GetSceneSlotItemInfo(slotEntityId);
		FurnitureSceneItemBase furnitureSceneItemBase;
		if (sceneSlotItemInfo != null && sceneSlotItemInfo.SubFurnitureSceneItemMap.TryGetValue(slotIndex, out furnitureSceneItemBase))
		{
			furnitureSceneItemBase.Show();
		}
	}

	// Token: 0x06006D92 RID: 28050 RVA: 0x001C7E3C File Offset: 0x001C603C
	public void UnloadSubFurnitureSceneItem(int slotEntityId, int slotIndex)
	{
		ISceneSlotItemInfo sceneSlotItemInfo = this.GetSceneSlotItemInfo(slotEntityId);
		if (sceneSlotItemInfo != null)
		{
			this.UnloadSubFurnitureSceneItemInternal(sceneSlotItemInfo, slotIndex);
		}
	}

	// Token: 0x06006D93 RID: 28051 RVA: 0x001C7E5C File Offset: 0x001C605C
	private void UnloadSubFurnitureSceneItemInternal(ISceneSlotItemInfo sceneSlotItemInfo, int slotIndex)
	{
		Dictionary<int, FurnitureSceneItemBase> subFurnitureSceneItemMap = sceneSlotItemInfo.SubFurnitureSceneItemMap;
		if (subFurnitureSceneItemMap.ContainsKey(slotIndex))
		{
			FurnitureSceneItemBase furnitureSceneItemBase;
			if (subFurnitureSceneItemMap.TryGetValue(slotIndex, out furnitureSceneItemBase))
			{
				furnitureSceneItemBase.Unload();
			}
			subFurnitureSceneItemMap.Remove(slotIndex);
		}
	}

	// Token: 0x06006D94 RID: 28052 RVA: 0x001C7E94 File Offset: 0x001C6094
	public void UnloadAllSubFurnitureSceneItem(int slotEntityId)
	{
		ISceneSlotItemInfo sceneSlotItemInfo = this.GetSceneSlotItemInfo(slotEntityId);
		if (sceneSlotItemInfo == null)
		{
			return;
		}
		Dictionary<int, FurnitureSceneItemBase> subFurnitureSceneItemMap = sceneSlotItemInfo.SubFurnitureSceneItemMap;
		foreach (FurnitureSceneItemBase furnitureSceneItemBase in subFurnitureSceneItemMap.Values)
		{
			furnitureSceneItemBase.Unload();
		}
		subFurnitureSceneItemMap.Clear();
	}

	// Token: 0x06006D95 RID: 28053 RVA: 0x001C7F00 File Offset: 0x001C6100
	public void UnloadAllFurnitureSceneItem()
	{
		if (this.SceneSlotItemInfoMap.Count == 0)
		{
			return;
		}
		foreach (ISceneSlotItemInfo sceneSlotItemInfo in this.SceneSlotItemInfoMap.Values)
		{
			FurnitureSceneItemBase rootFurnitureSceneItem = sceneSlotItemInfo.RootFurnitureSceneItem;
			if (rootFurnitureSceneItem != null)
			{
				rootFurnitureSceneItem.Unload();
			}
			foreach (FurnitureSceneItemBase furnitureSceneItemBase in sceneSlotItemInfo.SubFurnitureSceneItemMap.Values)
			{
				furnitureSceneItemBase.Unload();
			}
		}
		this.DoUnloadNeedUnloadedSceneItem();
		this.SceneSlotItemInfoMap.Clear();
		this.NeedUnloadedSceneItem.Clear();
	}

	// Token: 0x06006D96 RID: 28054 RVA: 0x001C7FD0 File Offset: 0x001C61D0
	public void MarkFurnitureSceneItemAsNeedUnload(int slotEntityId, int slotIndex)
	{
		ISceneSlotItemInfo orCreateSceneSlotItemInfo = this.GetOrCreateSceneSlotItemInfo(slotEntityId);
		FurnitureSceneItemBase sceneItem;
		if (slotIndex == -1)
		{
			if (orCreateSceneSlotItemInfo.RootFurnitureSceneItem != null)
			{
				this.MarkSceneItemAsNeedUnloadInternal(orCreateSceneSlotItemInfo.RootFurnitureSceneItem);
				orCreateSceneSlotItemInfo.RootFurnitureSceneItem = null;
				return;
			}
		}
		else if (orCreateSceneSlotItemInfo.SubFurnitureSceneItemMap.TryGetValue(slotIndex, out sceneItem))
		{
			this.MarkSceneItemAsNeedUnloadInternal(sceneItem);
			orCreateSceneSlotItemInfo.SubFurnitureSceneItemMap.Remove(slotIndex);
		}
	}

	// Token: 0x06006D97 RID: 28055 RVA: 0x001C8029 File Offset: 0x001C6229
	private void MarkSceneItemAsNeedUnloadInternal(FurnitureSceneItemBase sceneItem)
	{
		if (sceneItem != null && !this.NeedUnloadedSceneItem.Contains(sceneItem))
		{
			sceneItem.MarkAsNeedUnload();
			this.NeedUnloadedSceneItem.Add(sceneItem);
		}
	}

	// Token: 0x06006D98 RID: 28056 RVA: 0x001C8050 File Offset: 0x001C6250
	public void DoUnloadNeedUnloadedSceneItem()
	{
		if (this.NeedUnloadedSceneItem.Count == 0)
		{
			return;
		}
		foreach (FurnitureSceneItemBase furnitureSceneItemBase in this.NeedUnloadedSceneItem)
		{
			furnitureSceneItemBase.Unload();
		}
		this.NeedUnloadedSceneItem.Clear();
	}

	// Token: 0x040033F2 RID: 13298
	private readonly Dictionary<int, ISceneSlotItemInfo> SceneSlotItemInfoMap = new Dictionary<int, ISceneSlotItemInfo>();

	// Token: 0x040033F3 RID: 13299
	private readonly List<FurnitureSceneItemBase> NeedUnloadedSceneItem = new List<FurnitureSceneItemBase>();
}
