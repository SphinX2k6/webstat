using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.GenericPrompt;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x0200700A RID: 28682
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonTouchUiEditDataFacade : ITouchUiEditDataFacade
	{
		// Token: 0x1700A4C0 RID: 42176
		// (get) Token: 0x060456DF RID: 284383 RVA: 0x012270D9 File Offset: 0x012252D9
		// (set) Token: 0x060456E0 RID: 284384 RVA: 0x012270E1 File Offset: 0x012252E1
		public int MinTouchMoveDifference { get; set; }

		// Token: 0x1700A4C1 RID: 42177
		// (get) Token: 0x060456E1 RID: 284385 RVA: 0x012270EA File Offset: 0x012252EA
		// (set) Token: 0x060456E2 RID: 284386 RVA: 0x012270F2 File Offset: 0x012252F2
		public int MaxTouchMoveDifference { get; set; }

		// Token: 0x1700A4C2 RID: 42178
		// (get) Token: 0x060456E3 RID: 284387 RVA: 0x012270FB File Offset: 0x012252FB
		// (set) Token: 0x060456E4 RID: 284388 RVA: 0x01227103 File Offset: 0x01225303
		public float MaxTouchMoveValue { get; set; }

		// Token: 0x1700A4C3 RID: 42179
		// (get) Token: 0x060456E5 RID: 284389 RVA: 0x0122710C File Offset: 0x0122530C
		// (set) Token: 0x060456E6 RID: 284390 RVA: 0x01227114 File Offset: 0x01225314
		public float MinTouchMoveValue { get; set; }

		// Token: 0x1700A4C4 RID: 42180
		// (get) Token: 0x060456E7 RID: 284391 RVA: 0x0122711D File Offset: 0x0122531D
		// (set) Token: 0x060456E8 RID: 284392 RVA: 0x01227125 File Offset: 0x01225325
		public float ControlScaleRate { get; set; }

		// Token: 0x060456E9 RID: 284393 RVA: 0x01227130 File Offset: 0x01225330
		public void Init()
		{
			this.MinTouchMoveDifference = ConfigCommonParamById.GetIntConfig("MinTouchMoveDifference").Value;
			this.MaxTouchMoveDifference = ConfigCommonParamById.GetIntConfig("MaxTouchMoveDifference").Value;
			this.MaxTouchMoveValue = ConfigCommonParamById.GetFloatConfig("MaxTouchMoveValue").Value;
			this.MinTouchMoveValue = ConfigCommonParamById.GetFloatConfig("MinTouchMoveValue").Value;
			this.ControlScaleRate = ConfigCommonParamById.GetFloatConfig("ControlScaleRate").Value;
			Singleton<Net>.Instance.Register<CommonUiSettingNotify>(ENotifyMessageId.CommonUiSettingNotify, new Action<CommonUiSettingNotify, Net.CallbackStatus>(this.OnSettingUpdate));
		}

		// Token: 0x060456EA RID: 284394 RVA: 0x012271D1 File Offset: 0x012253D1
		public void Clear()
		{
			this.DataMap.Clear();
			this.DataMapFromNotify.Clear();
			this.ConfigList = null;
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CommonUiSettingNotify);
		}

		// Token: 0x060456EB RID: 284395 RVA: 0x01227200 File Offset: 0x01225400
		public void SetGroup(int group)
		{
			this.Group = group;
			this.ConfigList = ConfigBase<CommonTouchUiEditConfig>.Instance.GetConfigListByEditGroup(this.Group);
			this.GroupConfig = ConfigBase<CommonTouchUiEditConfig>.Instance.GetGroupConfigById(this.Group);
		}

		// Token: 0x060456EC RID: 284396 RVA: 0x01227235 File Offset: 0x01225435
		public CommonTouchUiEditGroup? GetGroupConfig()
		{
			return this.GroupConfig;
		}

		// Token: 0x060456ED RID: 284397 RVA: 0x01227240 File Offset: 0x01225440
		public string[] GetResIdList()
		{
			HashSet<string> hashSet = new HashSet<string>();
			if (this.ConfigList == null)
			{
				return new string[0];
			}
			for (int i = 0; i < this.ConfigList.Count; i++)
			{
				hashSet.Add(this.ConfigList[i].PanelResId);
			}
			string[] array = new string[hashSet.Count];
			int num = 0;
			foreach (string text in hashSet)
			{
				array[num] = text;
				num++;
			}
			return array;
		}

		// Token: 0x060456EE RID: 284398 RVA: 0x012272E8 File Offset: 0x012254E8
		public int GetStorageId(string resId, int index)
		{
			if (this.ConfigList == null)
			{
				return 0;
			}
			for (int i = 0; i < this.ConfigList.Count; i++)
			{
				CommonTouchUiEdit commonTouchUiEdit = this.ConfigList[i];
				if (commonTouchUiEdit.PanelResId == resId && commonTouchUiEdit.ItemIndex == index)
				{
					return commonTouchUiEdit.Id;
				}
			}
			return 0;
		}

		// Token: 0x060456EF RID: 284399 RVA: 0x01227344 File Offset: 0x01225544
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<string, int>? GetResPair(int storageId)
		{
			CommonTouchUiEdit? configById = ConfigBase<CommonTouchUiEditConfig>.Instance.GetConfigById(storageId);
			if (configById == null)
			{
				return null;
			}
			return new ValueTuple<string, int>?(new ValueTuple<string, int>(configById.Value.PanelResId, configById.Value.ItemIndex));
		}

		// Token: 0x060456F0 RID: 284400 RVA: 0x01227398 File Offset: 0x01225598
		[return: Nullable(2)]
		public ITouchUiEditData GetDefaultData(string resId, int index)
		{
			int storageId = this.GetStorageId(resId, index);
			if (storageId == 0)
			{
				return null;
			}
			CommonTouchUiEdit? configById = ConfigBase<CommonTouchUiEditConfig>.Instance.GetConfigById(storageId);
			if (configById == null)
			{
				return null;
			}
			return new TouchUiEditDataImpl
			{
				StorageId = storageId,
				OffsetX = configById.Value.SourceOffsetX,
				OffsetY = configById.Value.SourceOffsetY,
				Scale = configById.Value.SourceSize,
				Alpha = configById.Value.SourceAlpha,
				HierarchyIndex = configById.Value.SourceHierarchyIndex,
				Editable = configById.Value.Editable,
				DefaultSelect = configById.Value.IsDefaultSelected,
				ShouldCheckOverlap = configById.Value.IsCheckOverlap
			};
		}

		// Token: 0x060456F1 RID: 284401 RVA: 0x01227480 File Offset: 0x01225680
		public void SaveData(ITouchUiEditData[] dataList)
		{
			List<MobileButtonSetting> list = new List<MobileButtonSetting>();
			foreach (ITouchUiEditData touchUiEditData in dataList)
			{
				if (touchUiEditData.StorageId != 0)
				{
					this.DataMap[touchUiEditData.StorageId] = touchUiEditData;
					list.Add(new MobileButtonSetting
					{
						Id = touchUiEditData.StorageId,
						Size = touchUiEditData.Scale,
						ScreenX = touchUiEditData.OffsetX,
						ScreenY = touchUiEditData.OffsetY,
						Transparency = touchUiEditData.Alpha,
						PanelLevel = touchUiEditData.HierarchyIndex,
						ButtonLevel = touchUiEditData.HierarchyIndex
					});
				}
			}
			CommonTouchUiSettingUpdateRequest commonTouchUiSettingUpdateRequest = CommonTouchUiSettingUpdateRequest.Create();
			MobileButtonSetting[] array = new MobileButtonSetting[list.Count];
			for (int j = 0; j < list.Count; j++)
			{
				array[j] = list[j];
			}
			commonTouchUiSettingUpdateRequest.MobileButtonSettings.AddRange(array);
			Singleton<Net>.Instance.Call<CommonTouchUiSettingUpdateResponse>(ERequestMessageId.CommonTouchUiSettingUpdateRequest, commonTouchUiSettingUpdateRequest, delegate(CommonTouchUiSettingUpdateResponse res, Net.CallbackStatus _)
			{
				if (ControllerBase<ErrorCodeController>.Instance.CheckErrorCode((res != null) ? new Aki.Protocol.ErrorCode?(res.ErrorCode) : null, EResponseMessageId.CommonTouchUiSettingUpdateResponse, true))
				{
					return;
				}
				this.DataMapFromNotify.Clear();
				foreach (ITouchUiEditData touchUiEditData2 in dataList)
				{
					TouchUiEditDataImpl value = new TouchUiEditDataImpl
					{
						StorageId = touchUiEditData2.StorageId,
						OffsetX = touchUiEditData2.OffsetX,
						OffsetY = touchUiEditData2.OffsetY,
						Scale = touchUiEditData2.Scale,
						Alpha = touchUiEditData2.Alpha,
						HierarchyIndex = touchUiEditData2.HierarchyIndex,
						Editable = touchUiEditData2.Editable,
						DefaultSelect = touchUiEditData2.DefaultSelect,
						ShouldCheckOverlap = touchUiEditData2.ShouldCheckOverlap
					};
					this.DataMapFromNotify[touchUiEditData2.StorageId.ToString()] = value;
				}
				BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
				bool flag;
				if (instance == null)
				{
					flag = false;
				}
				else
				{
					BattleUiPureModeData pureModeData = instance.PureModeData;
					flag = ((pureModeData != null) ? new bool?(pureModeData.IsOpen) : null).GetValueOrDefault();
				}
				if (flag)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveButtonPureMode", Array.Empty<object>());
					return;
				}
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveButton", Array.Empty<object>());
			}, 0);
		}

		// Token: 0x060456F2 RID: 284402 RVA: 0x012275B0 File Offset: 0x012257B0
		[return: Nullable(2)]
		public ITouchUiEditData GetData(string resId, int index)
		{
			int storageId = this.GetStorageId(resId, index);
			ITouchUiEditData result;
			if (this.DataMap.TryGetValue(storageId, out result))
			{
				return result;
			}
			return this.GetDefaultData(resId, index);
		}

		// Token: 0x060456F3 RID: 284403 RVA: 0x012275E0 File Offset: 0x012257E0
		public void ResetEditData()
		{
			this.DataMap.Clear();
			foreach (ITouchUiEditData touchUiEditData in this.DataMapFromNotify.Values)
			{
				TouchUiEditDataImpl touchUiEditDataImpl = new TouchUiEditDataImpl();
				touchUiEditDataImpl.StorageId = touchUiEditData.StorageId;
				touchUiEditDataImpl.OffsetX = touchUiEditData.OffsetX;
				touchUiEditDataImpl.OffsetY = touchUiEditData.OffsetY;
				touchUiEditDataImpl.Scale = touchUiEditData.Scale;
				touchUiEditDataImpl.Alpha = touchUiEditData.Alpha;
				touchUiEditDataImpl.HierarchyIndex = touchUiEditData.HierarchyIndex;
				touchUiEditDataImpl.Editable = touchUiEditData.Editable;
				touchUiEditDataImpl.DefaultSelect = touchUiEditData.DefaultSelect;
				touchUiEditDataImpl.ShouldCheckOverlap = touchUiEditData.ShouldCheckOverlap;
				this.DataMap[touchUiEditData.StorageId] = touchUiEditDataImpl;
			}
		}

		// Token: 0x060456F4 RID: 284404 RVA: 0x012276C8 File Offset: 0x012258C8
		private void OnSettingUpdate(CommonUiSettingNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify.CommonUiButtonSetting == null)
			{
				return;
			}
			this.DataMap.Clear();
			this.DataMapFromNotify.Clear();
			for (int i = 0; i < notify.CommonUiButtonSetting.Count; i++)
			{
				MobileButtonSetting mobileButtonSetting = notify.CommonUiButtonSetting[i];
				int id = mobileButtonSetting.Id;
				CommonTouchUiEdit? configById = ConfigBase<CommonTouchUiEditConfig>.Instance.GetConfigById(id);
				ITouchUiEditData value = new TouchUiEditDataImpl
				{
					StorageId = id,
					OffsetX = mobileButtonSetting.ScreenX,
					OffsetY = mobileButtonSetting.ScreenY,
					Scale = mobileButtonSetting.Size,
					Alpha = mobileButtonSetting.Transparency,
					HierarchyIndex = mobileButtonSetting.ButtonLevel,
					Editable = configById.Value.Editable,
					DefaultSelect = configById.Value.IsDefaultSelected,
					ShouldCheckOverlap = configById.Value.IsCheckOverlap
				};
				this.DataMap[id] = value;
				this.DataMapFromNotify[mobileButtonSetting.Id.ToString()] = value;
			}
		}

		// Token: 0x04026CDE RID: 158942
		private int Group;

		// Token: 0x04026CDF RID: 158943
		private readonly Dictionary<int, ITouchUiEditData> DataMap = new Dictionary<int, ITouchUiEditData>();

		// Token: 0x04026CE0 RID: 158944
		private readonly Dictionary<string, ITouchUiEditData> DataMapFromNotify = new Dictionary<string, ITouchUiEditData>();

		// Token: 0x04026CE1 RID: 158945
		[Nullable(2)]
		private IReadOnlyList<CommonTouchUiEdit> ConfigList;

		// Token: 0x04026CE2 RID: 158946
		private CommonTouchUiEditGroup? GroupConfig;
	}
}
