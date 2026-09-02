using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

namespace CSharpScript.Game.Module.QuestMultiLine
{
	// Token: 0x0200531E RID: 21278
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class QuestMultiLineModel : ModelBase<QuestMultiLineModel>
	{
		// Token: 0x060364C4 RID: 222404 RVA: 0x00DAF664 File Offset: 0x00DAD864
		public bool IsBranchTimePoint()
		{
			return this.CurSelectLineId != 0;
		}

		// Token: 0x060364C5 RID: 222405 RVA: 0x00DAF670 File Offset: 0x00DAD870
		public void SetData(QuestBranchInfo branchInfo)
		{
			this.BranchInfoMap.Clear();
			this.UnlockTimePointMap.Clear();
			this.UnlockComponentsGroupMap.Clear();
			if (branchInfo.QuestBranchInfos != null)
			{
				foreach (OneQuestBranchPageInfo oneQuestBranchPageInfo in branchInfo.QuestBranchInfos)
				{
					this.BranchInfoMap[oneQuestBranchPageInfo.Id] = oneQuestBranchPageInfo;
				}
			}
			if (branchInfo.UnlockTimePoints != null)
			{
				foreach (int key in branchInfo.UnlockTimePoints)
				{
					this.UnlockTimePointMap[key] = true;
				}
			}
			if (branchInfo.UnlockBranchComponentsGroup != null)
			{
				foreach (int key2 in branchInfo.UnlockBranchComponentsGroup)
				{
					this.UnlockComponentsGroupMap[key2] = true;
				}
			}
			this.RefreshTimePoints();
			foreach (QuestMultiLineTimePointData questMultiLineTimePointData in this.TimePointDataArray)
			{
				questMultiLineTimePointData.RefreshBranchInfo(this.BranchInfoMap);
			}
		}

		// Token: 0x060364C6 RID: 222406 RVA: 0x00DAF7D4 File Offset: 0x00DAD9D4
		public void AddData(QuestBranchInfo branchInfo)
		{
			if (branchInfo.QuestBranchInfos != null)
			{
				foreach (OneQuestBranchPageInfo oneQuestBranchPageInfo in branchInfo.QuestBranchInfos)
				{
					this.BranchInfoMap[oneQuestBranchPageInfo.Id] = oneQuestBranchPageInfo;
				}
			}
			if (branchInfo.UnlockTimePoints != null)
			{
				foreach (int key in branchInfo.UnlockTimePoints)
				{
					this.UnlockTimePointMap[key] = true;
				}
			}
			if (branchInfo.UnlockBranchComponentsGroup != null)
			{
				foreach (int key2 in branchInfo.UnlockBranchComponentsGroup)
				{
					this.UnlockComponentsGroupMap[key2] = true;
				}
			}
			this.RefreshTimePoints();
			foreach (QuestMultiLineTimePointData questMultiLineTimePointData in this.TimePointDataArray)
			{
				questMultiLineTimePointData.RefreshBranchInfo(this.BranchInfoMap);
			}
		}

		// Token: 0x060364C7 RID: 222407 RVA: 0x00DAF918 File Offset: 0x00DADB18
		private void RefreshTimePoints()
		{
			foreach (QuestMultiLineTimePointData questMultiLineTimePointData in this.TimePointDataArray)
			{
				questMultiLineTimePointData.IsUnLock = this.UnlockTimePointMap.GetValueOrDefault(questMultiLineTimePointData.Id, false);
				questMultiLineTimePointData.RefreshUnComponentGroups(this.UnlockComponentsGroupMap);
			}
		}

		// Token: 0x060364C8 RID: 222408 RVA: 0x00DAF988 File Offset: 0x00DADB88
		public List<QuestMultiLineTimePointData> GetQuestTimePoints()
		{
			return this.TimePointDataArray;
		}

		// Token: 0x060364C9 RID: 222409 RVA: 0x00DAF990 File Offset: 0x00DADB90
		[NullableContext(2)]
		public QuestMultiLineTimePointData GetLastUnlockTimePoint()
		{
			for (int i = this.TimePointDataArray.Count - 1; i >= 0; i--)
			{
				QuestMultiLineTimePointData questMultiLineTimePointData = this.TimePointDataArray[i];
				if (questMultiLineTimePointData.IsUnLock)
				{
					return questMultiLineTimePointData;
				}
			}
			return null;
		}

		// Token: 0x060364CA RID: 222410 RVA: 0x00DAF9D0 File Offset: 0x00DADBD0
		public void RefreshOneBranchPage(OneQuestBranchPageInfo branchPageInfo)
		{
			this.BranchInfoMap[branchPageInfo.Id] = branchPageInfo;
			QuestMultiLineTimePointData questMultiLineTimePointData = this.FindTimePointByBranchPageId(branchPageInfo.Id);
			if (questMultiLineTimePointData != null)
			{
				questMultiLineTimePointData.RefreshBranchInfo(this.BranchInfoMap);
			}
			Singleton<EventSystem>.Instance.Emit<List<QuestMultiLineTimePointData>>(EEventName.QuestMultiLineTimePointChange, this.TimePointDataArray);
		}

		// Token: 0x060364CB RID: 222411 RVA: 0x00DAFA24 File Offset: 0x00DADC24
		[NullableContext(2)]
		private QuestMultiLineTimePointData FindTimePointByBranchPageId(int branchPageId)
		{
			foreach (QuestMultiLineTimePointData questMultiLineTimePointData in this.TimePointDataArray)
			{
				if (questMultiLineTimePointData.BranchPage == branchPageId)
				{
					return questMultiLineTimePointData;
				}
			}
			return null;
		}

		// Token: 0x060364CC RID: 222412 RVA: 0x00DAFA80 File Offset: 0x00DADC80
		private void InitData()
		{
			this.TimePointDataArray = new List<QuestMultiLineTimePointData>();
			IReadOnlyList<QuestTimePointConfig> allTimePointConfigs = QuestMultiLineConfig.GetAllTimePointConfigs();
			if (allTimePointConfigs == null)
			{
				return;
			}
			foreach (QuestTimePointConfig config in allTimePointConfigs)
			{
				QuestMultiLineTimePointData item = new QuestMultiLineTimePointData(config);
				this.TimePointDataArray.Add(item);
			}
			this.TimePointDataArray.Sort((QuestMultiLineTimePointData a, QuestMultiLineTimePointData b) => a.Sort - b.Sort);
		}

		// Token: 0x060364CD RID: 222413 RVA: 0x00DAFB14 File Offset: 0x00DADD14
		protected override bool OnInit()
		{
			this.InitData();
			return true;
		}

		// Token: 0x060364CE RID: 222414 RVA: 0x00DAFB20 File Offset: 0x00DADD20
		public bool GetTimePointRedDot(int configId)
		{
			ServerStorageMap serverStorageMap = (ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.QuestBranchSystem);
			if (!serverStorageMap.Has(configId))
			{
				serverStorageMap.Set(configId, 1);
				return true;
			}
			return serverStorageMap.Get(configId).GetValueOrDefault() == 1;
		}

		// Token: 0x060364CF RID: 222415 RVA: 0x00DAFB64 File Offset: 0x00DADD64
		public void ClearTimePointRedDot(int configId)
		{
			((ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.QuestBranchSystem)).Set(configId, 0);
		}

		// Token: 0x060364D0 RID: 222416 RVA: 0x00DAFB80 File Offset: 0x00DADD80
		public bool GetComponentRedDot(int componentId, EQuestMultiLineRoleType type)
		{
			if (type != EQuestMultiLineRoleType.MainRole)
			{
				return false;
			}
			ServerStorageMap serverStorageMap = (ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.QuestBranchSystem);
			if (!serverStorageMap.Has(componentId))
			{
				serverStorageMap.Set(componentId, 1);
				return true;
			}
			return serverStorageMap.Get(componentId).GetValueOrDefault() == 1;
		}

		// Token: 0x060364D1 RID: 222417 RVA: 0x00DAFBCA File Offset: 0x00DADDCA
		public void ClearComponentRedDot(int componentId)
		{
			((ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.QuestBranchSystem)).Set(componentId, 0);
		}

		// Token: 0x0401F391 RID: 127889
		private List<QuestMultiLineTimePointData> TimePointDataArray = new List<QuestMultiLineTimePointData>();

		// Token: 0x0401F392 RID: 127890
		private readonly Dictionary<int, OneQuestBranchPageInfo> BranchInfoMap = new Dictionary<int, OneQuestBranchPageInfo>();

		// Token: 0x0401F393 RID: 127891
		private readonly Dictionary<int, bool> UnlockTimePointMap = new Dictionary<int, bool>();

		// Token: 0x0401F394 RID: 127892
		private readonly Dictionary<int, bool> UnlockComponentsGroupMap = new Dictionary<int, bool>();

		// Token: 0x0401F395 RID: 127893
		private readonly int CurSelectLineId;
	}
}
