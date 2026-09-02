using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x020022F1 RID: 8945
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MotorcycleDiyModel : ModelBase<MotorcycleDiyModel>
{
	// Token: 0x06010E7A RID: 69242 RVA: 0x004A0B74 File Offset: 0x0049ED74
	protected override bool OnInit()
	{
		this.CurUsingStickerDict[EStickerParts.AleftPart] = 0;
		this.CurUsingStickerDict[EStickerParts.ArightPart] = 0;
		this.CurUsingStickerDict[EStickerParts.BPart] = 0;
		this.CurUsingDecorationDict[EDecorationParts.HeadPart] = 0;
		this.InitSceneData();
		return true;
	}

	// Token: 0x06010E7B RID: 69243 RVA: 0x004A0BB4 File Offset: 0x0049EDB4
	private void InitSceneData()
	{
		foreach (MotorScene motorScene in ConfigBase<MotorDiyConfig>.Instance.GetAllMotorSceneList())
		{
			this.SceneIdList.Add(motorScene.Id);
			if (motorScene.DefaultFlag)
			{
				this.DefaultSceneId = motorScene.Id;
			}
			else
			{
				this.SceneItemIdSet.Add(motorScene.UnlockItem);
			}
		}
		this.CurSceneId = this.DefaultSceneId;
	}

	// Token: 0x06010E7C RID: 69244 RVA: 0x004A0C48 File Offset: 0x0049EE48
	private void AddMotorOutlookItemList(Dictionary<int, int> dataMap)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		foreach (KeyValuePair<int, int> keyValuePair in dataMap)
		{
			AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
			addCountItemInfo.Id = keyValuePair.Key;
			addCountItemInfo.Count = keyValuePair.Value;
			addCountItemInfo.IncrId = 0;
			list.Add(addCountItemInfo);
		}
		ModelBase<ItemHintModel>.Instance.MainInterfaceInsertItemRewardInfo(list.ToArray());
	}

	// Token: 0x06010E7D RID: 69245 RVA: 0x004A0CD4 File Offset: 0x0049EED4
	private void InitRedDotInfo()
	{
		if (this.RedDotCache != null)
		{
			return;
		}
		this.RedDotCache = (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.MotorDiyNewUnlockId) as ServerStorageSet);
	}

	// Token: 0x06010E7E RID: 69246 RVA: 0x004A0CF6 File Offset: 0x0049EEF6
	private void TryInitSceneRedDotInfo()
	{
		if (this.SceneRedDotCache != null)
		{
			return;
		}
		this.SceneRedDotCache = (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.MotorSceneHadCheck) as ServerStorageSet);
	}

	// Token: 0x06010E7F RID: 69247 RVA: 0x004A0D18 File Offset: 0x0049EF18
	private void CheckLocalSaveItemIds(EOutlookType outlookType, List<int> itemIds, bool isSkin = false)
	{
		object obj = null;
		bool? flag = null;
		foreach (int num in itemIds)
		{
			if (!this.ProcessedItemIds.Contains(num) && num != 0)
			{
				if (outlookType == EOutlookType.Frame)
				{
					MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(num);
					obj = motorFrameConfig;
					flag = new bool?(motorFrameConfig != null && motorFrameConfig.Value.DefaultFlag);
				}
				else if (outlookType == EOutlookType.Sticker)
				{
					MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
					obj = motorStickerConfig;
					flag = new bool?(motorStickerConfig != null && motorStickerConfig.Value.FreeFlag);
				}
				else if (outlookType == EOutlookType.Decoration)
				{
					MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num);
					obj = motorDecorationConfig;
					flag = new bool?(motorDecorationConfig != null && motorDecorationConfig.Value.FreeFlag);
				}
				else if (isSkin)
				{
					MotorSkin? motorSkinConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSkinConfig(num);
					obj = motorSkinConfig;
					flag = new bool?(motorSkinConfig != null && motorSkinConfig.Value.DefaultFlag);
				}
				if (obj != null)
				{
					this.ProcessedItemIds.Add(num);
					bool flag2 = this.RedDotCache.Has(num);
					if (flag.GetValueOrDefault())
					{
						if (flag2)
						{
							this.RedDotCache.Remove(num);
						}
					}
					else if (!flag2)
					{
						this.RedDotCache.Add(num);
					}
				}
			}
		}
	}

	// Token: 0x06010E80 RID: 69248 RVA: 0x004A0ED0 File Offset: 0x0049F0D0
	private void UpdateOwnedOutlookInfo(MotorOutlookOwnedPb ownedOutlookData)
	{
		if (ownedOutlookData.SkinOwned != null)
		{
			this.OwnedSkinIds = new List<int>(ownedOutlookData.SkinOwned);
		}
		if (ownedOutlookData.StickerOwned != null)
		{
			this.OwnedStickerIds = new List<int>(ownedOutlookData.StickerOwned);
		}
		if (ownedOutlookData.FrameOwned != null)
		{
			this.OwnedFrameIds = new List<int>(ownedOutlookData.FrameOwned);
		}
		if (ownedOutlookData.DecorationsOwned != null)
		{
			this.OwnedDecorationsIds = new List<int>(ownedOutlookData.DecorationsOwned);
		}
	}

	// Token: 0x06010E81 RID: 69249 RVA: 0x004A0F44 File Offset: 0x0049F144
	[NullableContext(2)]
	private void UpdateRedDotInfo(IList<int> skinOwned, IList<int> stickerOwned, IList<int> frameOwned, IList<int> decorationsOwned)
	{
		if (skinOwned != null && skinOwned.Count > 0)
		{
			this.CheckLocalSaveItemIds(EOutlookType.None, new List<int>(skinOwned), true);
		}
		if (stickerOwned != null && stickerOwned.Count > 0)
		{
			this.CheckLocalSaveItemIds(EOutlookType.Sticker, new List<int>(stickerOwned), false);
		}
		if (frameOwned != null && frameOwned.Count > 0)
		{
			this.CheckLocalSaveItemIds(EOutlookType.Frame, new List<int>(frameOwned), false);
		}
		if (decorationsOwned != null && decorationsOwned.Count > 0)
		{
			this.CheckLocalSaveItemIds(EOutlookType.Decoration, new List<int>(decorationsOwned), false);
		}
	}

	// Token: 0x06010E82 RID: 69250 RVA: 0x004A0FBC File Offset: 0x0049F1BC
	private void UpdateEquippedOutlookInfo(MotorOutlookEquippedPb equippedOutlookData)
	{
		this.CurSkinId = equippedOutlookData.SkinEquipped;
		RepeatedField<int> stickerEquipped = equippedOutlookData.StickerEquipped;
		if (stickerEquipped != null)
		{
			for (int i = 0; i < stickerEquipped.Count; i++)
			{
				int value = stickerEquipped[i];
				EStickerParts key = i + EStickerParts.AleftPart;
				this.CurUsingStickerDict[key] = value;
			}
		}
		this.CurFrameId = equippedOutlookData.FrameEquipped;
		RepeatedField<int> decorationsEquipped = equippedOutlookData.DecorationsEquipped;
		if (decorationsEquipped != null)
		{
			for (int j = 0; j < decorationsEquipped.Count; j++)
			{
				int value2 = decorationsEquipped[j];
				EDecorationParts key2 = j + EDecorationParts.HeadPart;
				this.CurUsingDecorationDict[key2] = value2;
			}
		}
		if (!this.HasInitSelectedInfo)
		{
			this.ResetSelectedItemInfo();
			this.HasInitSelectedInfo = true;
		}
	}

	// Token: 0x06010E83 RID: 69251 RVA: 0x004A106C File Offset: 0x0049F26C
	public void UpdateSkinSuitInfo(IList<MotorOutlookEquippedPb> skinSuitDataList)
	{
		foreach (MotorOutlookEquippedPb motorOutlookEquippedPb in skinSuitDataList)
		{
			if (motorOutlookEquippedPb != null)
			{
				int skinEquipped = motorOutlookEquippedPb.SkinEquipped;
				MotorcycleDiySkinEquipRecord motorcycleDiySkinEquipRecord = new MotorcycleDiySkinEquipRecord();
				motorcycleDiySkinEquipRecord.FrameId = motorOutlookEquippedPb.FrameEquipped;
				RepeatedField<int> stickerEquipped = motorOutlookEquippedPb.StickerEquipped;
				motorcycleDiySkinEquipRecord.StickerIds = (((stickerEquipped != null) ? stickerEquipped.ToArray<int>() : null) ?? Array.Empty<int>());
				RepeatedField<int> decorationsEquipped = motorOutlookEquippedPb.DecorationsEquipped;
				motorcycleDiySkinEquipRecord.DecorateIds = (((decorationsEquipped != null) ? decorationsEquipped.ToArray<int>() : null) ?? Array.Empty<int>());
				MotorcycleDiySkinEquipRecord value = motorcycleDiySkinEquipRecord;
				this.SkinSuitDict[skinEquipped] = value;
			}
		}
	}

	// Token: 0x06010E84 RID: 69252 RVA: 0x004A1118 File Offset: 0x0049F318
	public void InitCustomPresetInfo(MotorOutlookPlayerPresetPb playerPreset)
	{
		this.CustomPresetDataList.Clear();
		this.UpdateCustomPresetInfo(playerPreset);
	}

	// Token: 0x06010E85 RID: 69253 RVA: 0x004A112C File Offset: 0x0049F32C
	public void UpdateCustomPresetInfo(MotorOutlookPlayerPresetPb playerPreset)
	{
		RepeatedField<MotorOutlookPresetPlanPb> plan = playerPreset.Plan;
		if (plan == null)
		{
			return;
		}
		foreach (MotorOutlookPresetPlanPb presetPlan in plan)
		{
			this.UpdateSingleCustomPresetInfo(presetPlan);
		}
	}

	// Token: 0x06010E86 RID: 69254 RVA: 0x004A1180 File Offset: 0x0049F380
	public void RemoveSingleCustomPresetInfo(int presetId)
	{
		this.CustomPresetDataList.RemoveAll((MotorcycleDiyPresetData preset) => preset.CustomId == presetId);
	}

	// Token: 0x06010E87 RID: 69255 RVA: 0x004A11B4 File Offset: 0x0049F3B4
	public void UpdateSingleCustomPresetInfo(MotorOutlookPresetPlanPb presetPlan)
	{
		int customPresetId = presetPlan.Id;
		MotorcycleDiyPresetData motorcycleDiyPresetData = this.CustomPresetDataList.Find((MotorcycleDiyPresetData preset) => preset.CustomId == customPresetId);
		if (motorcycleDiyPresetData == null)
		{
			motorcycleDiyPresetData = new MotorcycleDiyPresetData
			{
				CustomId = customPresetId
			};
			this.CustomPresetDataList.Add(motorcycleDiyPresetData);
		}
		motorcycleDiyPresetData.Name = (presetPlan.Name ?? string.Empty);
		MotorOutlookEquippedPb preset2 = presetPlan.Preset;
		if (preset2 != null)
		{
			motorcycleDiyPresetData.SkinId = preset2.SkinEquipped;
			MotorcycleDiyPresetData motorcycleDiyPresetData2 = motorcycleDiyPresetData;
			RepeatedField<int> stickerEquipped = preset2.StickerEquipped;
			motorcycleDiyPresetData2.StickerIds = (((stickerEquipped != null) ? stickerEquipped.ToArray<int>() : null) ?? Array.Empty<int>());
			MotorcycleDiyPresetData motorcycleDiyPresetData3 = motorcycleDiyPresetData;
			RepeatedField<int> decorationsEquipped = preset2.DecorationsEquipped;
			motorcycleDiyPresetData3.DecorateIds = (((decorationsEquipped != null) ? decorationsEquipped.ToArray<int>() : null) ?? Array.Empty<int>());
			motorcycleDiyPresetData.FrameId = preset2.FrameEquipped;
		}
	}

	// Token: 0x06010E88 RID: 69256 RVA: 0x004A1288 File Offset: 0x0049F488
	public void UpdateMotorCanUseOutlookInfo(MotorOutlookRegionInfoNotify message)
	{
		if (message != null && message.MotorOutlookRegion != null)
		{
			MotorOutlookRegionPb motorOutlookRegion = message.MotorOutlookRegion;
			this.CurCanUseFrameIds = new List<int>();
			this.CurCanUseStickerIds = new List<int>();
			this.CurCanUseDecorationsIds = new List<int>();
			if (motorOutlookRegion.MotorFrame != null)
			{
				foreach (MotorOutlookIdTimePairPb motorOutlookIdTimePairPb in motorOutlookRegion.MotorFrame)
				{
					this.CurCanUseFrameIds.Add(motorOutlookIdTimePairPb.Id);
					this.CanUseIdsTimeStamp[motorOutlookIdTimePairPb.Id] = motorOutlookIdTimePairPb.OpenTime;
				}
			}
			if (motorOutlookRegion.MotorSticker != null)
			{
				foreach (MotorOutlookIdTimePairPb motorOutlookIdTimePairPb2 in motorOutlookRegion.MotorSticker)
				{
					this.CurCanUseStickerIds.Add(motorOutlookIdTimePairPb2.Id);
					this.CanUseIdsTimeStamp[motorOutlookIdTimePairPb2.Id] = motorOutlookIdTimePairPb2.OpenTime;
				}
			}
			if (motorOutlookRegion.MotorDecoration != null)
			{
				foreach (MotorOutlookIdTimePairPb motorOutlookIdTimePairPb3 in motorOutlookRegion.MotorDecoration)
				{
					this.CurCanUseDecorationsIds.Add(motorOutlookIdTimePairPb3.Id);
					this.CanUseIdsTimeStamp[motorOutlookIdTimePairPb3.Id] = motorOutlookIdTimePairPb3.OpenTime;
				}
			}
		}
	}

	// Token: 0x06010E89 RID: 69257 RVA: 0x004A1408 File Offset: 0x0049F608
	private void UpdateSceneInUse(int? sceneInUse)
	{
		if (sceneInUse != null && sceneInUse.Value > 0)
		{
			this.CurSceneId = sceneInUse.Value;
		}
	}

	// Token: 0x06010E8A RID: 69258 RVA: 0x004A142C File Offset: 0x0049F62C
	public void UpdateMotorOutlookInfo(MotorOutlookInfoResponse message)
	{
		if (message != null && message.MotorOutlook != null)
		{
			MotorOutlookPb motorOutlook = message.MotorOutlook;
			MotorOutlookOwnedPb motorOutlookOwned = motorOutlook.MotorOutlookOwned;
			MotorOutlookEquippedPb motorOutlookEquipped = motorOutlook.MotorOutlookEquipped;
			MotorOutlookPlayerPresetPb motorOutlookPreset = motorOutlook.MotorOutlookPreset;
			RepeatedField<MotorOutlookEquippedPb> latestMotorSkinSuit = motorOutlook.LatestMotorSkinSuit;
			if (motorOutlookOwned != null)
			{
				this.InitRedDotInfo();
				this.UpdateOwnedOutlookInfo(motorOutlookOwned);
			}
			if (motorOutlookEquipped != null)
			{
				this.UpdateEquippedOutlookInfo(motorOutlookEquipped);
			}
			if (motorOutlookPreset != null)
			{
				this.InitCustomPresetInfo(motorOutlookPreset);
			}
			if (latestMotorSkinSuit != null)
			{
				this.UpdateSkinSuitInfo(latestMotorSkinSuit);
			}
			this.UpdateSceneInUse(new int?(motorOutlook.SceneInUse));
		}
	}

	// Token: 0x06010E8B RID: 69259 RVA: 0x004A14AC File Offset: 0x0049F6AC
	public void AddMotorOutlookInfo(MotorOutlookAddNotify message)
	{
		if (message != null)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			if (message.MotorSkin != null)
			{
				foreach (int num in message.MotorSkin)
				{
					if (this.IsRegionItemInOpenTime(num))
					{
						dictionary[num] = 1;
					}
				}
			}
			if (message.MotorSticker != null)
			{
				foreach (int num2 in message.MotorSticker)
				{
					if (this.IsRegionItemInOpenTime(num2))
					{
						dictionary[num2] = 1;
					}
				}
			}
			if (message.MotorFrame != null)
			{
				foreach (int num3 in message.MotorFrame)
				{
					if (this.IsRegionItemInOpenTime(num3))
					{
						dictionary[num3] = 1;
					}
				}
			}
			if (message.MotorDecoration != null)
			{
				foreach (int num4 in message.MotorDecoration)
				{
					if (this.IsRegionItemInOpenTime(num4))
					{
						dictionary[num4] = 1;
					}
				}
			}
			this.AddMotorOutlookItemList(dictionary);
			this.InitRedDotInfo();
			this.UpdateRedDotInfo(message.MotorSkin, message.MotorSticker, message.MotorFrame, message.MotorDecoration);
		}
	}

	// Token: 0x06010E8C RID: 69260 RVA: 0x004A1634 File Offset: 0x0049F834
	public void UpdateMotorOutlookOwnedChange(MotorOutlookOwnedChangeNotify message)
	{
		MotorOutlookOwnedPb motorOutlookOwned = message.MotorOutlookOwned;
		if (motorOutlookOwned != null)
		{
			this.UpdateOwnedOutlookInfo(motorOutlookOwned);
		}
	}

	// Token: 0x06010E8D RID: 69261 RVA: 0x004A1654 File Offset: 0x0049F854
	public void UpdateMotorOutlookEquippedChange(MotorOutlookEquippedChangeNotify message)
	{
		MotorOutlookEquippedPb motorOutlookEquipped = message.MotorOutlookEquipped;
		if (motorOutlookEquipped != null)
		{
			this.UpdateEquippedOutlookInfo(motorOutlookEquipped);
		}
		RepeatedField<MotorOutlookEquippedPb> latestMotorSkinSuit = message.LatestMotorSkinSuit;
		if (latestMotorSkinSuit != null)
		{
			this.UpdateSkinSuitInfo(latestMotorSkinSuit);
		}
	}

	// Token: 0x06010E8E RID: 69262 RVA: 0x004A1684 File Offset: 0x0049F884
	public void UpdateMotorOutlookFullChange(MotorOutlookFullChangeNotify message)
	{
		MotorOutlookPb motorOutlook = message.MotorOutlook;
		if (motorOutlook != null)
		{
			if (motorOutlook.MotorOutlookEquipped != null)
			{
				this.UpdateEquippedOutlookInfo(motorOutlook.MotorOutlookEquipped);
			}
			if (motorOutlook.MotorOutlookOwned != null)
			{
				this.UpdateOwnedOutlookInfo(motorOutlook.MotorOutlookOwned);
			}
			if (motorOutlook.MotorOutlookPreset != null)
			{
				this.InitCustomPresetInfo(motorOutlook.MotorOutlookPreset);
			}
			if (motorOutlook.LatestMotorSkinSuit != null)
			{
				this.UpdateSkinSuitInfo(motorOutlook.LatestMotorSkinSuit);
			}
			this.UpdateSceneInUse(new int?(motorOutlook.SceneInUse));
		}
	}

	// Token: 0x06010E8F RID: 69263 RVA: 0x004A16FC File Offset: 0x0049F8FC
	public List<UiDynamicTab> GetMotorDiyTabList(EUiViewName viewName)
	{
		List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(viewName);
		int count = viewTabList.Count;
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		for (int i = 0; i < count; i++)
		{
			UiDynamicTab item = viewTabList[i];
			if (ModelBase<FunctionModel>.Instance.IsOpen(item.FunctionId))
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06010E90 RID: 69264 RVA: 0x004A1758 File Offset: 0x0049F958
	public int GetDefaultFrameId()
	{
		if (this.DefaultFrameId == 0)
		{
			foreach (int num in this.OwnedFrameIds)
			{
				MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(num);
				if (motorFrameConfig != null && motorFrameConfig.Value.DefaultFlag)
				{
					this.DefaultFrameId = num;
					break;
				}
			}
		}
		return this.DefaultFrameId;
	}

	// Token: 0x06010E91 RID: 69265 RVA: 0x004A17E4 File Offset: 0x0049F9E4
	public List<int> GetDefaultStickerIdList()
	{
		List<int> list = new List<int>();
		foreach (int num in MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART)
		{
			list.Add(0);
		}
		return list;
	}

	// Token: 0x06010E92 RID: 69266 RVA: 0x004A1818 File Offset: 0x0049FA18
	public List<int> GetDefaultDecorationIdList()
	{
		List<int> list = new List<int>();
		foreach (int num in MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART)
		{
			list.Add(0);
		}
		return list;
	}

	// Token: 0x06010E93 RID: 69267 RVA: 0x004A184C File Offset: 0x0049FA4C
	public List<MotorcycleDiyPresetData> GetAllPresetDataList(bool isCustom = false)
	{
		List<MotorcycleDiyPresetData> list = new List<MotorcycleDiyPresetData>();
		if (isCustom)
		{
			list.AddRange(this.CustomPresetDataList);
		}
		else
		{
			foreach (MotorLoadProject motorLoadProject in ConfigBase<MotorDiyConfig>.Instance.GetAllMotorPresetList())
			{
				if (motorLoadProject.Show)
				{
					int frame = motorLoadProject.Frame;
					List<int> list2 = (motorLoadProject.GetStickerArray() ?? Array.Empty<int>()).ToList<int>();
					List<int> list3 = (motorLoadProject.GetDecorationsArray() ?? Array.Empty<int>()).ToList<int>();
					if (list2.Count == 0)
					{
						list2 = this.GetDefaultStickerIdList();
					}
					if (list3.Count == 0)
					{
						list3 = this.GetDefaultDecorationIdList();
					}
					if (this.HasFrame(frame))
					{
						bool flag = true;
						foreach (int stickerId in list2)
						{
							if (!this.HasSticker(stickerId))
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							bool flag2 = true;
							foreach (int decorationId in list3)
							{
								if (!this.HasDecoration(decorationId))
								{
									flag2 = false;
									break;
								}
							}
							if (flag2)
							{
								list.Add(new MotorcycleDiyPresetData
								{
									OfficialId = motorLoadProject.Id,
									CustomId = 0,
									Name = (ConfigMultiTextLang.GetLocalTextNew(motorLoadProject.Name, null) ?? string.Empty),
									StickerIds = list2.ToArray(),
									DecorateIds = list3.ToArray(),
									FrameId = frame
								});
							}
						}
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06010E94 RID: 69268 RVA: 0x004A1A54 File Offset: 0x0049FC54
	public EOutLookState GetItemState(EOutlookType outlookType, int itemId)
	{
		List<int> list = new List<int>();
		int num = 0;
		ICollection<int> collection = new List<int>();
		List<int> list2 = new List<int>();
		Func<int, bool> func = (int id) => false;
		switch (outlookType)
		{
		case EOutlookType.Frame:
			list = this.CurCanUseFrameIds;
			num = this.CurFrameId;
			list2 = this.OwnedFrameIds;
			func = new Func<int, bool>(this.IsBanFrame);
			break;
		case EOutlookType.Sticker:
			list = this.CurCanUseStickerIds;
			collection = this.CurUsingStickerDict.Values;
			list2 = this.OwnedStickerIds;
			func = new Func<int, bool>(this.IsBanSticker);
			break;
		case EOutlookType.Decoration:
			list = this.CurCanUseDecorationsIds;
			collection = this.CurUsingDecorationDict.Values;
			list2 = this.OwnedDecorationsIds;
			func = new Func<int, bool>(this.IsBanDecoration);
			break;
		}
		if (outlookType == EOutlookType.Frame)
		{
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(itemId);
			if (motorFrameConfig != null && !motorFrameConfig.Value.Show)
			{
				return EOutLookState.IsHide;
			}
		}
		if (!list.Contains(itemId) || !this.IsRegionItemInOpenTime(itemId))
		{
			return EOutLookState.IsHide;
		}
		if (func(itemId))
		{
			return EOutLookState.IsBan;
		}
		if (collection.Contains(itemId) || num == itemId)
		{
			return EOutLookState.IsEquipped;
		}
		if (!list2.Contains(itemId))
		{
			return EOutLookState.IsLock;
		}
		return EOutLookState.CanEquipped;
	}

	// Token: 0x06010E95 RID: 69269 RVA: 0x004A1B90 File Offset: 0x0049FD90
	public void CollectRedDotOnViewOpen(EOutlookType outlookType, int? part = null)
	{
		this.RedDotOnViewOpenCache.Clear();
		List<int> list = new List<int>();
		if (outlookType == EOutlookType.Frame)
		{
			list = this.OwnedFrameIds;
		}
		else
		{
			if (outlookType == EOutlookType.Sticker)
			{
				using (List<int>.Enumerator enumerator = this.OwnedStickerIds.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int num = enumerator.Current;
						MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
						if (motorStickerConfig != null)
						{
							int partId = motorStickerConfig.Value.PartId;
							int? num2 = part;
							if (partId == num2.GetValueOrDefault() & num2 != null)
							{
								list.Add(num);
							}
						}
					}
					goto IL_112;
				}
			}
			if (outlookType == EOutlookType.Decoration)
			{
				foreach (int num3 in this.OwnedDecorationsIds)
				{
					MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num3);
					if (motorDecorationConfig != null)
					{
						int partId2 = motorDecorationConfig.Value.PartId;
						int? num2 = part;
						if (partId2 == num2.GetValueOrDefault() & num2 != null)
						{
							list.Add(num3);
						}
					}
				}
			}
		}
		IL_112:
		foreach (int num4 in list)
		{
			if (this.RedDotCache.Has(num4))
			{
				this.RedDotOnViewOpenCache.Add(num4);
				this.RedDotCache.Remove(num4);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoRedDotUpdate);
	}

	// Token: 0x06010E96 RID: 69270 RVA: 0x004A1D3C File Offset: 0x0049FF3C
	public void CheckRedDotForAnyItem(int itemId)
	{
		if (this.RedDotCache.Has(itemId))
		{
			this.RedDotCache.Remove(itemId);
			Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoRedDotUpdate);
		}
	}

	// Token: 0x06010E97 RID: 69271 RVA: 0x004A1D68 File Offset: 0x0049FF68
	public bool CheckRedDotInViewOpenCache(int id)
	{
		return this.RedDotOnViewOpenCache.Contains(id);
	}

	// Token: 0x06010E98 RID: 69272 RVA: 0x004A1D76 File Offset: 0x0049FF76
	public void RemoveRedDotInViewOpenCache(int id)
	{
		this.RedDotOnViewOpenCache.Remove(id);
	}

	// Token: 0x06010E99 RID: 69273 RVA: 0x004A1D88 File Offset: 0x0049FF88
	private IMotorDiyItemGroupConfigInfo GetItemGroupConfigInfo(EOutlookType outlookType, int itemId)
	{
		MotorDiyItemGroupConfigInfo motorDiyItemGroupConfigInfo = new MotorDiyItemGroupConfigInfo();
		if (itemId == 0)
		{
			return motorDiyItemGroupConfigInfo;
		}
		switch (outlookType)
		{
		case EOutlookType.Frame:
		{
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(itemId);
			if (motorFrameConfig != null)
			{
				motorDiyItemGroupConfigInfo.GroupId = new int?(motorFrameConfig.Value.GroupId);
			}
			break;
		}
		case EOutlookType.Sticker:
		{
			MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(itemId);
			if (motorStickerConfig != null)
			{
				motorDiyItemGroupConfigInfo.GroupId = new int?(motorStickerConfig.Value.GroupId);
				motorDiyItemGroupConfigInfo.PartId = new int?(motorStickerConfig.Value.PartId);
			}
			break;
		}
		case EOutlookType.Decoration:
		{
			MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(itemId);
			if (motorDecorationConfig != null)
			{
				motorDiyItemGroupConfigInfo.GroupId = new int?(motorDecorationConfig.Value.GroupId);
				motorDiyItemGroupConfigInfo.PartId = new int?(motorDecorationConfig.Value.PartId);
			}
			break;
		}
		}
		return motorDiyItemGroupConfigInfo;
	}

	// Token: 0x06010E9A RID: 69274 RVA: 0x004A1E88 File Offset: 0x004A0088
	private bool CheckIsBan(EOutlookType outlookType, int itemId)
	{
		MotorcycleDiyModel.<>c__DisplayClass59_0 CS$<>8__locals1;
		CS$<>8__locals1.outlookType = outlookType;
		CS$<>8__locals1.<>4__this = this;
		IMotorDiyItemGroupConfigInfo itemGroupConfigInfo = this.GetItemGroupConfigInfo(CS$<>8__locals1.outlookType, itemId);
		int? groupId = itemGroupConfigInfo.GroupId;
		CS$<>8__locals1.targetPartId = itemGroupConfigInfo.PartId;
		if (groupId == null)
		{
			return false;
		}
		MotorComponentGroup? motorComponentGroupConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorComponentGroupConfig(groupId.Value);
		if (motorComponentGroupConfig == null || motorComponentGroupConfig.Value.GetConflictGroupArray() == null || motorComponentGroupConfig.Value.GetConflictGroupArray().Length == 0)
		{
			return false;
		}
		CS$<>8__locals1.conflictGroupIds = motorComponentGroupConfig.Value.GetConflictGroupArray();
		foreach (KeyValuePair<EStickerParts, int> keyValuePair in this.SelectedStickerDict)
		{
			if (this.<CheckIsBan>g__isConflict|59_0(EOutlookType.Sticker, keyValuePair.Value, new int?((int)keyValuePair.Key), ref CS$<>8__locals1))
			{
				return true;
			}
		}
		foreach (KeyValuePair<EDecorationParts, int> keyValuePair2 in this.SelectedDecorationDict)
		{
			if (this.<CheckIsBan>g__isConflict|59_0(EOutlookType.Decoration, keyValuePair2.Value, new int?((int)keyValuePair2.Key), ref CS$<>8__locals1))
			{
				return true;
			}
		}
		return this.<CheckIsBan>g__isConflict|59_0(EOutlookType.Frame, this.SelectedFrameId, null, ref CS$<>8__locals1);
	}

	// Token: 0x06010E9B RID: 69275 RVA: 0x004A2014 File Offset: 0x004A0214
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<string, string>? GetBanTips(EOutlookType outlookType, int itemId)
	{
		MotorcycleDiyModel.<>c__DisplayClass60_0 CS$<>8__locals1;
		CS$<>8__locals1.outlookType = outlookType;
		CS$<>8__locals1.<>4__this = this;
		IMotorDiyItemGroupConfigInfo itemGroupConfigInfo = this.GetItemGroupConfigInfo(CS$<>8__locals1.outlookType, itemId);
		int? groupId = itemGroupConfigInfo.GroupId;
		CS$<>8__locals1.targetPartId = itemGroupConfigInfo.PartId;
		if (groupId == null)
		{
			return null;
		}
		MotorComponentGroup? motorComponentGroupConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorComponentGroupConfig(groupId.Value);
		if (motorComponentGroupConfig == null || motorComponentGroupConfig.Value.GetConflictGroupArray() == null || motorComponentGroupConfig.Value.GetConflictGroupArray().Length == 0)
		{
			return null;
		}
		CS$<>8__locals1.conflictGroupIds = motorComponentGroupConfig.Value.GetConflictGroupArray();
		string item = "";
		CS$<>8__locals1.banItemName = "";
		item = MotorcycleDiyModel.<GetBanTips>g__getItemName|60_0(CS$<>8__locals1.outlookType, itemId);
		CS$<>8__locals1.addedGroupIds = new List<int>
		{
			groupId.Value
		};
		foreach (KeyValuePair<EStickerParts, int> keyValuePair in this.SelectedStickerDict)
		{
			this.<GetBanTips>g__checkAndAdd|60_1(EOutlookType.Sticker, keyValuePair.Value, new int?((int)keyValuePair.Key), ref CS$<>8__locals1);
		}
		foreach (KeyValuePair<EDecorationParts, int> keyValuePair2 in this.SelectedDecorationDict)
		{
			this.<GetBanTips>g__checkAndAdd|60_1(EOutlookType.Decoration, keyValuePair2.Value, new int?((int)keyValuePair2.Key), ref CS$<>8__locals1);
		}
		this.<GetBanTips>g__checkAndAdd|60_1(EOutlookType.Frame, this.SelectedFrameId, null, ref CS$<>8__locals1);
		return new ValueTuple<string, string>?(new ValueTuple<string, string>(item, CS$<>8__locals1.banItemName));
	}

	// Token: 0x06010E9C RID: 69276 RVA: 0x004A21E4 File Offset: 0x004A03E4
	public List<int> GetSelectedItemIdList(EOutlookType outlookType, bool checkHasItem = false)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		Func<int, bool> func = (int id) => false;
		switch (outlookType)
		{
		case EOutlookType.Sticker:
			list2 = MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART.ToList<int>();
			dictionary = this.SelectedStickerDict.ToDictionary((KeyValuePair<EStickerParts, int> kvp) => (int)kvp.Key, (KeyValuePair<EStickerParts, int> kvp) => kvp.Value);
			dictionary2 = this.CurUsingStickerDict.ToDictionary((KeyValuePair<EStickerParts, int> kvp) => (int)kvp.Key, (KeyValuePair<EStickerParts, int> kvp) => kvp.Value);
			func = new Func<int, bool>(this.HasSticker);
			break;
		case EOutlookType.Decoration:
			list2 = MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART.ToList<int>();
			dictionary = this.SelectedDecorationDict.ToDictionary((KeyValuePair<EDecorationParts, int> kvp) => (int)kvp.Key, (KeyValuePair<EDecorationParts, int> kvp) => kvp.Value);
			dictionary2 = this.CurUsingDecorationDict.ToDictionary((KeyValuePair<EDecorationParts, int> kvp) => (int)kvp.Key, (KeyValuePair<EDecorationParts, int> kvp) => kvp.Value);
			func = new Func<int, bool>(this.HasDecoration);
			break;
		}
		foreach (int key in list2)
		{
			int valueOrDefault = dictionary.GetValueOrDefault(key, 0);
			if (checkHasItem)
			{
				if (func(valueOrDefault))
				{
					list.Add(valueOrDefault);
				}
				else
				{
					int valueOrDefault2 = dictionary2.GetValueOrDefault(key, 0);
					list.Add(valueOrDefault2);
				}
			}
			else
			{
				list.Add(valueOrDefault);
			}
		}
		return list;
	}

	// Token: 0x06010E9D RID: 69277 RVA: 0x004A2424 File Offset: 0x004A0624
	private List<int> GetEquippedItemIdList(EOutlookType outlookType)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		switch (outlookType)
		{
		case EOutlookType.Sticker:
			list2 = MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART.ToList<int>();
			dictionary = this.CurUsingStickerDict.ToDictionary((KeyValuePair<EStickerParts, int> kvp) => (int)kvp.Key, (KeyValuePair<EStickerParts, int> kvp) => kvp.Value);
			break;
		case EOutlookType.Decoration:
			list2 = MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART.ToList<int>();
			dictionary = this.CurUsingDecorationDict.ToDictionary((KeyValuePair<EDecorationParts, int> kvp) => (int)kvp.Key, (KeyValuePair<EDecorationParts, int> kvp) => kvp.Value);
			break;
		}
		foreach (int key in list2)
		{
			int item = dictionary.ContainsKey(key) ? dictionary[key] : 0;
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06010E9E RID: 69278 RVA: 0x004A2568 File Offset: 0x004A0768
	public int GetSelectedItemId(EOutlookType outlookType, int? part = null)
	{
		int result = 0;
		switch (outlookType)
		{
		case EOutlookType.Frame:
			result = this.SelectedFrameId;
			break;
		case EOutlookType.Sticker:
			result = ((part != null && this.SelectedStickerDict.ContainsKey((EStickerParts)part.Value)) ? this.SelectedStickerDict[(EStickerParts)part.Value] : 0);
			break;
		case EOutlookType.Decoration:
			result = ((part != null && this.SelectedDecorationDict.ContainsKey((EDecorationParts)part.Value)) ? this.SelectedDecorationDict[(EDecorationParts)part.Value] : 0);
			break;
		}
		return result;
	}

	// Token: 0x06010E9F RID: 69279 RVA: 0x004A2604 File Offset: 0x004A0804
	public int GetEquippedItemId(EOutlookType outlookType, int part)
	{
		int result = 0;
		switch (outlookType)
		{
		case EOutlookType.Sticker:
			result = (this.CurUsingStickerDict.ContainsKey((EStickerParts)part) ? this.CurUsingStickerDict[(EStickerParts)part] : 0);
			break;
		case EOutlookType.Decoration:
			result = (this.CurUsingDecorationDict.ContainsKey((EDecorationParts)part) ? this.CurUsingDecorationDict[(EDecorationParts)part] : 0);
			break;
		}
		return result;
	}

	// Token: 0x06010EA0 RID: 69280 RVA: 0x004A266C File Offset: 0x004A086C
	public void ResetSelectedItemInfo()
	{
		this.SelectedStickerDict.Clear();
		this.SelectedDecorationDict.Clear();
		foreach (KeyValuePair<EStickerParts, int> keyValuePair in this.CurUsingStickerDict)
		{
			this.SelectedStickerDict[keyValuePair.Key] = keyValuePair.Value;
		}
		foreach (KeyValuePair<EDecorationParts, int> keyValuePair2 in this.CurUsingDecorationDict)
		{
			this.SelectedDecorationDict[keyValuePair2.Key] = keyValuePair2.Value;
		}
		this.SelectedFrameId = this.CurFrameId;
	}

	// Token: 0x06010EA1 RID: 69281 RVA: 0x004A2748 File Offset: 0x004A0948
	public bool RedDotHasNewItemByAnyPart(EOutlookType outlookType)
	{
		List<int> list = new List<int>();
		switch (outlookType)
		{
		case EOutlookType.Sticker:
			list = MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART.ToList<int>();
			break;
		case EOutlookType.Decoration:
			list = MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART.ToList<int>();
			break;
		}
		foreach (int part in list)
		{
			if (this.RedDotHasNewItemByPart(outlookType, part))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010EA2 RID: 69282 RVA: 0x004A27D8 File Offset: 0x004A09D8
	public bool RedDotHasNewItemByPart(EOutlookType outlookType, int part)
	{
		List<int> list = new List<int>();
		Func<int, bool> func = (int id) => false;
		switch (outlookType)
		{
		case EOutlookType.Sticker:
			list = this.CurCanUseStickerIds;
			func = new Func<int, bool>(this.HasSticker);
			break;
		case EOutlookType.Decoration:
			list = this.CurCanUseDecorationsIds;
			func = new Func<int, bool>(this.HasDecoration);
			break;
		}
		foreach (int num in list)
		{
			int? num2 = null;
			if (outlookType == EOutlookType.Sticker)
			{
				MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
				if (motorStickerConfig != null)
				{
					num2 = new int?(motorStickerConfig.GetValueOrDefault().PartId);
				}
			}
			else if (outlookType == EOutlookType.Decoration)
			{
				MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num);
				if (motorDecorationConfig != null)
				{
					num2 = new int?(motorDecorationConfig.GetValueOrDefault().PartId);
				}
			}
			EOutLookState itemState = this.GetItemState(outlookType, num);
			bool flag = num2 != null && num2.Value == part;
			bool flag2 = func(num);
			bool flag3 = itemState == EOutLookState.CanEquipped || itemState == EOutLookState.IsEquipped;
			if (flag && flag2 && flag3 && this.RedDotHasNewItem(num))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010EA3 RID: 69283 RVA: 0x004A294C File Offset: 0x004A0B4C
	public List<int> GetCanUseStickerIdsInRegion()
	{
		return this.CurCanUseStickerIds;
	}

	// Token: 0x06010EA4 RID: 69284 RVA: 0x004A2954 File Offset: 0x004A0B54
	public List<int> GetCanUseFrameIdsInRegion()
	{
		return this.CurCanUseFrameIds;
	}

	// Token: 0x06010EA5 RID: 69285 RVA: 0x004A295C File Offset: 0x004A0B5C
	public List<int> GetCanUseDecorationsIdsInRegion()
	{
		return this.CurCanUseDecorationsIds;
	}

	// Token: 0x06010EA6 RID: 69286 RVA: 0x004A2964 File Offset: 0x004A0B64
	public bool IsRegionItemInOpenTime(int itemId)
	{
		long num2;
		long num = this.CanUseIdsTimeStamp.TryGetValue(itemId, out num2) ? num2 : 0L;
		return (long)Singleton<TimeUtil>.Instance.GetServerTime() >= num;
	}

	// Token: 0x06010EA7 RID: 69287 RVA: 0x004A2998 File Offset: 0x004A0B98
	public int GetEquippedSkinId()
	{
		return this.CurSkinId;
	}

	// Token: 0x06010EA8 RID: 69288 RVA: 0x004A29A0 File Offset: 0x004A0BA0
	public int GetCurrentSceneId()
	{
		return this.CurSceneId;
	}

	// Token: 0x06010EA9 RID: 69289 RVA: 0x004A29A8 File Offset: 0x004A0BA8
	public void SetCurrentSceneId(int sceneId)
	{
		this.CurSceneId = sceneId;
	}

	// Token: 0x06010EAA RID: 69290 RVA: 0x004A29B1 File Offset: 0x004A0BB1
	public List<int> GetMotorSceneIdList()
	{
		return this.SceneIdList;
	}

	// Token: 0x06010EAB RID: 69291 RVA: 0x004A29BC File Offset: 0x004A0BBC
	public bool HasScene(int sceneId)
	{
		if (sceneId <= 0)
		{
			return false;
		}
		if (sceneId == this.DefaultSceneId)
		{
			return true;
		}
		MotorScene? motorSceneConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSceneConfig(sceneId);
		return motorSceneConfig != null && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(motorSceneConfig.Value.UnlockItem, 0) > 0;
	}

	// Token: 0x06010EAC RID: 69292 RVA: 0x004A2A0E File Offset: 0x004A0C0E
	public bool RedDotHasNewScene(int sceneId)
	{
		if (sceneId == this.DefaultSceneId)
		{
			return false;
		}
		if (!this.HasScene(sceneId))
		{
			return false;
		}
		this.TryInitSceneRedDotInfo();
		return this.SceneRedDotCache == null || !this.SceneRedDotCache.Has(sceneId);
	}

	// Token: 0x06010EAD RID: 69293 RVA: 0x004A2A48 File Offset: 0x004A0C48
	public bool RedDotHasAnyNewScene()
	{
		foreach (int sceneId in this.SceneIdList)
		{
			if (this.RedDotHasNewScene(sceneId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010EAE RID: 69294 RVA: 0x004A2AA4 File Offset: 0x004A0CA4
	public void RecordHadCheckNewScene(int sceneId)
	{
		if (sceneId == this.DefaultSceneId)
		{
			return;
		}
		if (!this.HasScene(sceneId))
		{
			return;
		}
		this.TryInitSceneRedDotInfo();
		ServerStorageSet sceneRedDotCache = this.SceneRedDotCache;
		if (sceneRedDotCache != null)
		{
			sceneRedDotCache.Add(sceneId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiySceneItemUpdate);
	}

	// Token: 0x06010EAF RID: 69295 RVA: 0x004A2AE2 File Offset: 0x004A0CE2
	public bool IsSceneItemId(int itemId)
	{
		return this.SceneItemIdSet.Contains(itemId);
	}

	// Token: 0x06010EB0 RID: 69296 RVA: 0x004A2AF0 File Offset: 0x004A0CF0
	public bool IsEquipDefaultSkin()
	{
		bool result = false;
		MotorSkin? motorSkinConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSkinConfig(this.CurSkinId);
		if (motorSkinConfig != null && motorSkinConfig.Value.DefaultFlag)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06010EB1 RID: 69297 RVA: 0x004A2B30 File Offset: 0x004A0D30
	[NullableContext(2)]
	public MotorcycleDiySkinEquipRecord GetSkinSuitRecord(int skinId)
	{
		MotorcycleDiySkinEquipRecord motorcycleDiySkinEquipRecord;
		if (this.SkinSuitDict.TryGetValue(skinId, out motorcycleDiySkinEquipRecord))
		{
			return motorcycleDiySkinEquipRecord;
		}
		MotorSkin? motorSkinConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSkinConfig(skinId);
		if (motorSkinConfig == null)
		{
			return null;
		}
		motorcycleDiySkinEquipRecord = new MotorcycleDiySkinEquipRecord
		{
			FrameId = motorSkinConfig.Value.BindFrame,
			StickerIds = motorSkinConfig.Value.BindSticker(),
			DecorateIds = motorSkinConfig.Value.BindDecorations()
		};
		this.SkinSuitDict[skinId] = motorcycleDiySkinEquipRecord;
		return motorcycleDiySkinEquipRecord;
	}

	// Token: 0x06010EB2 RID: 69298 RVA: 0x004A2BB9 File Offset: 0x004A0DB9
	public bool HasSkin(int skinId)
	{
		return this.OwnedSkinIds.Contains(skinId);
	}

	// Token: 0x06010EB3 RID: 69299 RVA: 0x004A2BC7 File Offset: 0x004A0DC7
	public EOutLookState GetFrameState(int frameId)
	{
		return this.GetItemState(EOutlookType.Frame, frameId);
	}

	// Token: 0x06010EB4 RID: 69300 RVA: 0x004A2BD1 File Offset: 0x004A0DD1
	public int GetSelectedFrameId()
	{
		return this.SelectedFrameId;
	}

	// Token: 0x06010EB5 RID: 69301 RVA: 0x004A2BD9 File Offset: 0x004A0DD9
	public int GetEquippedFrameId()
	{
		return this.CurFrameId;
	}

	// Token: 0x06010EB6 RID: 69302 RVA: 0x004A2BE1 File Offset: 0x004A0DE1
	public void SetSelectFrame(int frameId)
	{
		this.SelectedFrameId = frameId;
	}

	// Token: 0x06010EB7 RID: 69303 RVA: 0x004A2BEA File Offset: 0x004A0DEA
	public bool HasFrame(int frameId)
	{
		return this.OwnedFrameIds.Contains(frameId);
	}

	// Token: 0x06010EB8 RID: 69304 RVA: 0x004A2BF8 File Offset: 0x004A0DF8
	public bool IsBanFrame(int frameId)
	{
		return this.CheckIsBan(EOutlookType.Frame, frameId);
	}

	// Token: 0x06010EB9 RID: 69305 RVA: 0x004A2C04 File Offset: 0x004A0E04
	public bool IsEquipFrameLockedByPlayer()
	{
		BaseTagComponent component = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		bool flag = component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.驾驶期间"]);
		bool flag2 = component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.下车"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.退场技"]);
		return flag || flag2;
	}

	// Token: 0x06010EBA RID: 69306 RVA: 0x004A2C6D File Offset: 0x004A0E6D
	public EOutLookState GetStickerState(int stickerId)
	{
		return this.GetItemState(EOutlookType.Sticker, stickerId);
	}

	// Token: 0x06010EBB RID: 69307 RVA: 0x004A2C77 File Offset: 0x004A0E77
	public List<int> GetSelectedStickerIdList(bool checkHasSticker = false)
	{
		return this.GetSelectedItemIdList(EOutlookType.Sticker, checkHasSticker);
	}

	// Token: 0x06010EBC RID: 69308 RVA: 0x004A2C81 File Offset: 0x004A0E81
	public int GetSelectedStickerId(int stickerPart)
	{
		if (!this.SelectedStickerDict.ContainsKey((EStickerParts)stickerPart))
		{
			return 0;
		}
		return this.SelectedStickerDict[(EStickerParts)stickerPart];
	}

	// Token: 0x06010EBD RID: 69309 RVA: 0x004A2C9F File Offset: 0x004A0E9F
	public List<int> GetEquippedStickerIdList()
	{
		return this.GetEquippedItemIdList(EOutlookType.Sticker);
	}

	// Token: 0x06010EBE RID: 69310 RVA: 0x004A2CA8 File Offset: 0x004A0EA8
	public int GetEquippedStickerId(int stickerPart)
	{
		if (!this.CurUsingStickerDict.ContainsKey((EStickerParts)stickerPart))
		{
			return 0;
		}
		return this.CurUsingStickerDict[(EStickerParts)stickerPart];
	}

	// Token: 0x06010EBF RID: 69311 RVA: 0x004A2CC6 File Offset: 0x004A0EC6
	public void SetSelectStickerInfo(int stickerPart, int stickerId)
	{
		this.SelectedStickerDict[(EStickerParts)stickerPart] = stickerId;
	}

	// Token: 0x06010EC0 RID: 69312 RVA: 0x004A2CD5 File Offset: 0x004A0ED5
	public bool IsEquipDefaultSticker(int stickerPart)
	{
		return this.CurUsingStickerDict.ContainsKey((EStickerParts)stickerPart) && this.CurUsingStickerDict[(EStickerParts)stickerPart] == 0;
	}

	// Token: 0x06010EC1 RID: 69313 RVA: 0x004A2CF6 File Offset: 0x004A0EF6
	public bool IsBanSticker(int stickerId)
	{
		return this.CheckIsBan(EOutlookType.Sticker, stickerId);
	}

	// Token: 0x06010EC2 RID: 69314 RVA: 0x004A2D00 File Offset: 0x004A0F00
	public bool HasSticker(int stickerId)
	{
		return stickerId <= 0 || this.OwnedStickerIds.Contains(stickerId);
	}

	// Token: 0x06010EC3 RID: 69315 RVA: 0x004A2D14 File Offset: 0x004A0F14
	public EOutLookState GetDecorationState(int decorationId)
	{
		return this.GetItemState(EOutlookType.Decoration, decorationId);
	}

	// Token: 0x06010EC4 RID: 69316 RVA: 0x004A2D1E File Offset: 0x004A0F1E
	public List<int> GetSelectedDecorationIdList(bool checkHasDecoration = false)
	{
		return this.GetSelectedItemIdList(EOutlookType.Decoration, checkHasDecoration);
	}

	// Token: 0x06010EC5 RID: 69317 RVA: 0x004A2D28 File Offset: 0x004A0F28
	public int GetSelectedDecorationId(int decorationPart)
	{
		if (!this.SelectedDecorationDict.ContainsKey((EDecorationParts)decorationPart))
		{
			return 0;
		}
		return this.SelectedDecorationDict[(EDecorationParts)decorationPart];
	}

	// Token: 0x06010EC6 RID: 69318 RVA: 0x004A2D46 File Offset: 0x004A0F46
	public List<int> GetEquippedDecorationIdList()
	{
		return this.GetEquippedItemIdList(EOutlookType.Decoration);
	}

	// Token: 0x06010EC7 RID: 69319 RVA: 0x004A2D4F File Offset: 0x004A0F4F
	public int GetEquippedDecorationId(int decorationPart)
	{
		if (!this.CurUsingDecorationDict.ContainsKey((EDecorationParts)decorationPart))
		{
			return 0;
		}
		return this.CurUsingDecorationDict[(EDecorationParts)decorationPart];
	}

	// Token: 0x06010EC8 RID: 69320 RVA: 0x004A2D6D File Offset: 0x004A0F6D
	public void SetSelectDecorationInfo(int decorationPart, int decorationId)
	{
		this.SelectedDecorationDict[(EDecorationParts)decorationPart] = decorationId;
	}

	// Token: 0x06010EC9 RID: 69321 RVA: 0x004A2D7C File Offset: 0x004A0F7C
	public bool IsEquipDefaultDecoration(int decorationPart)
	{
		return this.CurUsingDecorationDict.ContainsKey((EDecorationParts)decorationPart) && this.CurUsingDecorationDict[(EDecorationParts)decorationPart] == 0;
	}

	// Token: 0x06010ECA RID: 69322 RVA: 0x004A2D9D File Offset: 0x004A0F9D
	public bool IsBanDecoration(int decorationId)
	{
		return this.CheckIsBan(EOutlookType.Decoration, decorationId);
	}

	// Token: 0x06010ECB RID: 69323 RVA: 0x004A2DA7 File Offset: 0x004A0FA7
	public bool HasDecoration(int decorationId)
	{
		return decorationId <= 0 || this.OwnedDecorationsIds.Contains(decorationId);
	}

	// Token: 0x06010ECC RID: 69324 RVA: 0x004A2DBB File Offset: 0x004A0FBB
	public bool CanShowDiyPartRedDot()
	{
		return this.IsEquipDefaultSkin();
	}

	// Token: 0x06010ECD RID: 69325 RVA: 0x004A2DC3 File Offset: 0x004A0FC3
	public bool RedDotHasAnyNewItem()
	{
		return this.RedDotHasNewFrame() || this.RedDotHasNewStickerByAnyPart() || this.RedDotHasNewDecorationByAnyPart() || this.RedDotHasNewSkin();
	}

	// Token: 0x06010ECE RID: 69326 RVA: 0x004A2DE5 File Offset: 0x004A0FE5
	public bool RedDotHasAnyNewItemVisible()
	{
		return this.CanShowDiyPartRedDot() && this.RedDotHasAnyNewItem();
	}

	// Token: 0x06010ECF RID: 69327 RVA: 0x004A2DF7 File Offset: 0x004A0FF7
	public bool RedDotForDiyTab()
	{
		return this.RedDotHasAnyNewItemVisible() || this.RedDotHasAnyNewScene();
	}

	// Token: 0x06010ED0 RID: 69328 RVA: 0x004A2E09 File Offset: 0x004A1009
	public bool RedDotHasNewFrameVisible()
	{
		return this.CanShowDiyPartRedDot() && this.RedDotHasNewFrame();
	}

	// Token: 0x06010ED1 RID: 69329 RVA: 0x004A2E1B File Offset: 0x004A101B
	public bool RedDotHasNewStickerByAnyPartVisible()
	{
		return this.CanShowDiyPartRedDot() && this.RedDotHasNewStickerByAnyPart();
	}

	// Token: 0x06010ED2 RID: 69330 RVA: 0x004A2E2D File Offset: 0x004A102D
	public bool RedDotHasNewDecorationByAnyPartVisible()
	{
		return this.CanShowDiyPartRedDot() && this.RedDotHasNewDecorationByAnyPart();
	}

	// Token: 0x06010ED3 RID: 69331 RVA: 0x004A2E40 File Offset: 0x004A1040
	public bool RedDotHasNewFrame()
	{
		foreach (int itemId in this.OwnedFrameIds)
		{
			if (this.RedDotHasNewItem(itemId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010ED4 RID: 69332 RVA: 0x004A2E9C File Offset: 0x004A109C
	public bool RedDotHasNewStickerByAnyPart()
	{
		return this.RedDotHasNewItemByAnyPart(EOutlookType.Sticker);
	}

	// Token: 0x06010ED5 RID: 69333 RVA: 0x004A2EA5 File Offset: 0x004A10A5
	public bool RedDotHasNewStickerByPart(int stickerPart)
	{
		return this.RedDotHasNewItemByPart(EOutlookType.Sticker, stickerPart);
	}

	// Token: 0x06010ED6 RID: 69334 RVA: 0x004A2EAF File Offset: 0x004A10AF
	public bool RedDotHasNewDecorationByAnyPart()
	{
		return this.RedDotHasNewItemByAnyPart(EOutlookType.Decoration);
	}

	// Token: 0x06010ED7 RID: 69335 RVA: 0x004A2EB8 File Offset: 0x004A10B8
	public bool RedDotHasNewDecorationByPart(int decorationPart)
	{
		return this.RedDotHasNewItemByPart(EOutlookType.Decoration, decorationPart);
	}

	// Token: 0x06010ED8 RID: 69336 RVA: 0x004A2EC4 File Offset: 0x004A10C4
	public bool RedDotHasNewSkin()
	{
		foreach (int itemId in this.OwnedSkinIds)
		{
			if (this.RedDotHasNewItem(itemId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010ED9 RID: 69337 RVA: 0x004A2F20 File Offset: 0x004A1120
	public bool RedDotHasNewItem(int itemId)
	{
		ServerStorageSet redDotCache = this.RedDotCache;
		return redDotCache != null && redDotCache.Has(itemId);
	}

	// Token: 0x06010EDA RID: 69338 RVA: 0x004A2F34 File Offset: 0x004A1134
	public bool RedDotIsPreviewInAnyPart(EOutlookType outlookType)
	{
		List<int> list = new List<int>();
		if (outlookType == EOutlookType.Sticker)
		{
			list = MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART.ToList<int>();
		}
		else if (outlookType == EOutlookType.Decoration)
		{
			list = MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART.ToList<int>();
		}
		foreach (int value in list)
		{
			if (this.RedDotIsPreview(outlookType, new int?(value)))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010EDB RID: 69339 RVA: 0x004A2FB8 File Offset: 0x004A11B8
	public bool RedDotIsPreview(EOutlookType outlookType, int? part = null)
	{
		int selectedItemId = this.GetSelectedItemId(outlookType, part);
		return this.GetItemState(outlookType, selectedItemId) == EOutLookState.IsLock;
	}

	// Token: 0x06010EDD RID: 69341 RVA: 0x004A30B8 File Offset: 0x004A12B8
	[CompilerGenerated]
	private bool <CheckIsBan>g__isConflict|59_0(EOutlookType type, int id, int? part = null, ref MotorcycleDiyModel.<>c__DisplayClass59_0 A_4)
	{
		if (id != 0)
		{
			if (type == A_4.outlookType)
			{
				int? num = part;
				int? targetPartId = A_4.targetPartId;
				if (num.GetValueOrDefault() == targetPartId.GetValueOrDefault() & num != null == (targetPartId != null))
				{
					return false;
				}
			}
			int? groupId = this.GetItemGroupConfigInfo(type, id).GroupId;
			return groupId != null && A_4.conflictGroupIds.Contains(groupId.Value);
		}
		return false;
	}

	// Token: 0x06010EDE RID: 69342 RVA: 0x004A3130 File Offset: 0x004A1330
	[CompilerGenerated]
	internal static string <GetBanTips>g__getItemName|60_0(EOutlookType type, int id)
	{
		string id2 = "";
		switch (type)
		{
		case EOutlookType.Frame:
		{
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(id);
			id2 = ((motorFrameConfig != null) ? motorFrameConfig.Value.Title : "");
			break;
		}
		case EOutlookType.Sticker:
		{
			MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(id);
			id2 = ((motorStickerConfig != null) ? motorStickerConfig.Value.Title : "");
			break;
		}
		case EOutlookType.Decoration:
		{
			MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(id);
			id2 = ((motorDecorationConfig != null) ? motorDecorationConfig.Value.Title : "");
			break;
		}
		}
		return ConfigMultiTextLang.GetLocalTextNew(id2, null) ?? "";
	}

	// Token: 0x06010EDF RID: 69343 RVA: 0x004A31FC File Offset: 0x004A13FC
	[CompilerGenerated]
	private void <GetBanTips>g__checkAndAdd|60_1(EOutlookType type, int id, int? part = null, ref MotorcycleDiyModel.<>c__DisplayClass60_0 A_4)
	{
		if (id != 0)
		{
			if (type == A_4.outlookType)
			{
				int? num = part;
				int? targetPartId = A_4.targetPartId;
				if (num.GetValueOrDefault() == targetPartId.GetValueOrDefault() & num != null == (targetPartId != null))
				{
					return;
				}
			}
			IMotorDiyItemGroupConfigInfo itemGroupConfigInfo = this.GetItemGroupConfigInfo(type, id);
			if (itemGroupConfigInfo.GroupId != null && A_4.conflictGroupIds.Contains(itemGroupConfigInfo.GroupId.Value) && !A_4.addedGroupIds.Contains(itemGroupConfigInfo.GroupId.Value))
			{
				A_4.addedGroupIds.Add(itemGroupConfigInfo.GroupId.Value);
				string text = MotorcycleDiyModel.<GetBanTips>g__getItemName|60_0(type, id);
				if (text.Length > 0)
				{
					A_4.banItemName = text;
				}
			}
			return;
		}
	}

	// Token: 0x04008542 RID: 34114
	private List<int> CurCanUseStickerIds = new List<int>();

	// Token: 0x04008543 RID: 34115
	private List<int> CurCanUseFrameIds = new List<int>();

	// Token: 0x04008544 RID: 34116
	private List<int> CurCanUseDecorationsIds = new List<int>();

	// Token: 0x04008545 RID: 34117
	private readonly Dictionary<int, long> CanUseIdsTimeStamp = new Dictionary<int, long>();

	// Token: 0x04008546 RID: 34118
	private List<int> OwnedSkinIds = new List<int>();

	// Token: 0x04008547 RID: 34119
	private List<int> OwnedStickerIds = new List<int>();

	// Token: 0x04008548 RID: 34120
	private List<int> OwnedFrameIds = new List<int>();

	// Token: 0x04008549 RID: 34121
	private List<int> OwnedDecorationsIds = new List<int>();

	// Token: 0x0400854A RID: 34122
	private int CurSkinId;

	// Token: 0x0400854B RID: 34123
	private int CurFrameId;

	// Token: 0x0400854C RID: 34124
	private readonly Dictionary<EStickerParts, int> CurUsingStickerDict = new Dictionary<EStickerParts, int>();

	// Token: 0x0400854D RID: 34125
	private readonly Dictionary<EDecorationParts, int> CurUsingDecorationDict = new Dictionary<EDecorationParts, int>();

	// Token: 0x0400854E RID: 34126
	private readonly Dictionary<int, MotorcycleDiySkinEquipRecord> SkinSuitDict = new Dictionary<int, MotorcycleDiySkinEquipRecord>();

	// Token: 0x0400854F RID: 34127
	private List<MotorcycleDiyPresetData> CustomPresetDataList = new List<MotorcycleDiyPresetData>();

	// Token: 0x04008550 RID: 34128
	private int SelectedFrameId;

	// Token: 0x04008551 RID: 34129
	private readonly Dictionary<EStickerParts, int> SelectedStickerDict = new Dictionary<EStickerParts, int>();

	// Token: 0x04008552 RID: 34130
	private readonly Dictionary<EDecorationParts, int> SelectedDecorationDict = new Dictionary<EDecorationParts, int>();

	// Token: 0x04008553 RID: 34131
	private int DefaultFrameId;

	// Token: 0x04008554 RID: 34132
	private readonly HashSet<int> ProcessedItemIds = new HashSet<int>();

	// Token: 0x04008555 RID: 34133
	[Nullable(2)]
	private ServerStorageSet RedDotCache;

	// Token: 0x04008556 RID: 34134
	private bool HasInitSelectedInfo;

	// Token: 0x04008557 RID: 34135
	private readonly HashSet<int> RedDotOnViewOpenCache = new HashSet<int>();

	// Token: 0x04008558 RID: 34136
	private int CurSceneId;

	// Token: 0x04008559 RID: 34137
	private int DefaultSceneId;

	// Token: 0x0400855A RID: 34138
	private readonly List<int> SceneIdList = new List<int>();

	// Token: 0x0400855B RID: 34139
	private readonly HashSet<int> SceneItemIdSet = new HashSet<int>();

	// Token: 0x0400855C RID: 34140
	[Nullable(2)]
	private ServerStorageSet SceneRedDotCache;
}
