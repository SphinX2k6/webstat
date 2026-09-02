using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BattleUiSet
{
	// Token: 0x02006138 RID: 24888
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class BattleUiSetModel : ModelBase<BattleUiSetModel>
	{
		// Token: 0x0603EDA7 RID: 257447 RVA: 0x0101A924 File Offset: 0x01018B24
		protected override bool OnInit()
		{
			for (int i = 0; i < 9; i++)
			{
				IEnumerable<MobileBattleUiSet> mobileBattleUiSetConfigList = BattleUiSetConfig.GetMobileBattleUiSetConfigList(i);
				List<BattleUiSetPanelItemData> list = new List<BattleUiSetPanelItemData>();
				foreach (MobileBattleUiSet mobileBattleUiSet in mobileBattleUiSetConfigList)
				{
					int id = mobileBattleUiSet.Id;
					BattleUiSetPanelItemData battleUiSetPanelItemData = new BattleUiSetPanelItemData(mobileBattleUiSet.ItemIndex, ref mobileBattleUiSet);
					list.Add(battleUiSetPanelItemData);
					this.PanelItemDataMap[id] = battleUiSetPanelItemData;
				}
				BattleUiSetPanelData value = new BattleUiSetPanelData(i, list.ToArray());
				this.PanelDataMap[i] = value;
			}
			this.MinTouchMoveDifference = (float)ConfigCommonParamById.GetIntConfig("MinTouchMoveDifference").Value;
			this.MaxTouchMoveDifference = (float)ConfigCommonParamById.GetIntConfig("MaxTouchMoveDifference").Value;
			this.MaxTouchMoveValue = ConfigCommonParamById.GetFloatConfig("MaxTouchMoveValue").Value;
			this.MinTouchMoveValue = ConfigCommonParamById.GetFloatConfig("MinTouchMoveValue").Value;
			this.ControlScaleRate = ConfigCommonParamById.GetFloatConfig("ControlScaleRate").Value;
			return true;
		}

		// Token: 0x0603EDA8 RID: 257448 RVA: 0x0101AA4C File Offset: 0x01018C4C
		protected override bool OnClear()
		{
			this.PanelDataMap.Clear();
			this.PanelItemDataMap.Clear();
			this.SelectedPanelItemData = null;
			return true;
		}

		// Token: 0x0603EDA9 RID: 257449 RVA: 0x0101AA6C File Offset: 0x01018C6C
		public IReadOnlyDictionary<int, BattleUiSetPanelData> GetPanelDataMap()
		{
			return this.PanelDataMap;
		}

		// Token: 0x0603EDAA RID: 257450 RVA: 0x0101AA74 File Offset: 0x01018C74
		public IReadOnlyDictionary<int, BattleUiSetPanelItemData> GetPanelItemDataMap()
		{
			return this.PanelItemDataMap;
		}

		// Token: 0x0603EDAB RID: 257451 RVA: 0x0101AA7C File Offset: 0x01018C7C
		[NullableContext(2)]
		public BattleUiSetPanelItemData GetPanelItemDataByConfigId(int configId)
		{
			return this.PanelItemDataMap.GetValueOrDefault(configId);
		}

		// Token: 0x0603EDAC RID: 257452 RVA: 0x0101AA8A File Offset: 0x01018C8A
		[NullableContext(2)]
		public void SetPanelItemSelected(BattleUiSetPanelItemData panelItemData)
		{
			if (panelItemData == null)
			{
				return;
			}
			if (!panelItemData.CanEdit)
			{
				return;
			}
			this.SelectedPanelItemData = panelItemData;
			Singleton<EventSystem>.Instance.Emit<BattleUiSetPanelItemData>(EEventName.OnSelectedEditPanelItem, this.SelectedPanelItemData);
		}

		// Token: 0x0603EDAD RID: 257453 RVA: 0x0101AAB8 File Offset: 0x01018CB8
		public void ResetSettings()
		{
			foreach (BattleUiSetPanelItemData battleUiSetPanelItemData in this.GetPanelItemDataMap().Values)
			{
				battleUiSetPanelItemData.EditSize = battleUiSetPanelItemData.SourceSize;
				battleUiSetPanelItemData.EditAlpha = battleUiSetPanelItemData.SourceAlpha;
				battleUiSetPanelItemData.EditOffsetX = battleUiSetPanelItemData.SourceOffsetX;
				battleUiSetPanelItemData.EditOffsetY = battleUiSetPanelItemData.SourceOffsetY;
				battleUiSetPanelItemData.EditorHierarchyIndex = battleUiSetPanelItemData.SourceHierarchyIndex;
			}
		}

		// Token: 0x0603EDAE RID: 257454 RVA: 0x0101AB40 File Offset: 0x01018D40
		public void SaveSettings()
		{
			IReadOnlyDictionary<int, BattleUiSetPanelItemData> panelItemDataMap = this.GetPanelItemDataMap();
			List<MobileButtonSetting> list = new List<MobileButtonSetting>();
			foreach (BattleUiSetPanelItemData battleUiSetPanelItemData in panelItemDataMap.Values)
			{
				float editSize = battleUiSetPanelItemData.EditSize;
				float editAlpha = battleUiSetPanelItemData.EditAlpha;
				float editOffsetX = battleUiSetPanelItemData.EditOffsetX;
				float editOffsetY = battleUiSetPanelItemData.EditOffsetY;
				int editorHierarchyIndex = battleUiSetPanelItemData.EditorHierarchyIndex;
				MobileButtonSetting item = new MobileButtonSetting
				{
					Id = battleUiSetPanelItemData.ConfigId,
					Size = editSize,
					Transparency = editAlpha,
					ScreenX = editOffsetX,
					ScreenY = editOffsetY,
					ButtonLevel = editorHierarchyIndex,
					PanelLevel = 0
				};
				battleUiSetPanelItemData.Size = editSize;
				battleUiSetPanelItemData.Alpha = editAlpha;
				battleUiSetPanelItemData.OffsetX = editOffsetX;
				battleUiSetPanelItemData.OffsetY = editOffsetY;
				battleUiSetPanelItemData.HierarchyIndex = editorHierarchyIndex;
				list.Add(item);
			}
			BattleUiSetController.MobileButtonSettingUpdateRequest(list);
		}

		// Token: 0x0603EDAF RID: 257455 RVA: 0x0101AC34 File Offset: 0x01018E34
		public void ReInitSettings()
		{
			foreach (BattleUiSetPanelItemData battleUiSetPanelItemData in this.GetPanelItemDataMap().Values)
			{
				battleUiSetPanelItemData.ReInit();
			}
		}

		// Token: 0x0603EDB0 RID: 257456 RVA: 0x0101AC84 File Offset: 0x01018E84
		public void AddTouchFingerData(TouchFingerData touchFingerData)
		{
			EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
			this.TouchFingerDataMap[fingerIndex] = touchFingerData;
		}

		// Token: 0x0603EDB1 RID: 257457 RVA: 0x0101ACA8 File Offset: 0x01018EA8
		public void RemoveTouchFingerData(TouchFingerData touchFingerData)
		{
			EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
			this.TouchFingerDataMap.Remove(fingerIndex);
		}

		// Token: 0x0603EDB2 RID: 257458 RVA: 0x0101ACC9 File Offset: 0x01018EC9
		public int GetTouchFingerDataCount()
		{
			return this.TouchFingerDataMap.Count;
		}

		// Token: 0x0603EDB3 RID: 257459 RVA: 0x0101ACD6 File Offset: 0x01018ED6
		[NullableContext(2)]
		public TouchFingerData GetTouchFingerData(EFingerIndex fingerIndex)
		{
			return this.TouchFingerDataMap.GetValueOrDefault(fingerIndex);
		}

		// Token: 0x04023446 RID: 144454
		private readonly Dictionary<int, BattleUiSetPanelData> PanelDataMap = new Dictionary<int, BattleUiSetPanelData>();

		// Token: 0x04023447 RID: 144455
		private readonly Dictionary<int, BattleUiSetPanelItemData> PanelItemDataMap = new Dictionary<int, BattleUiSetPanelItemData>();

		// Token: 0x04023448 RID: 144456
		[Nullable(2)]
		public BattleUiSetPanelItemData SelectedPanelItemData;

		// Token: 0x04023449 RID: 144457
		private readonly Dictionary<EFingerIndex, TouchFingerData> TouchFingerDataMap = new Dictionary<EFingerIndex, TouchFingerData>();

		// Token: 0x0402344A RID: 144458
		public float MinTouchMoveDifference;

		// Token: 0x0402344B RID: 144459
		public float MaxTouchMoveDifference;

		// Token: 0x0402344C RID: 144460
		public float MaxTouchMoveValue;

		// Token: 0x0402344D RID: 144461
		public float MinTouchMoveValue;

		// Token: 0x0402344E RID: 144462
		public float ControlScaleRate;
	}
}
