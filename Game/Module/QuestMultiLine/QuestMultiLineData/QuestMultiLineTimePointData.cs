using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData
{
	// Token: 0x02005346 RID: 21318
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineTimePointData
	{
		// Token: 0x060365FE RID: 222718 RVA: 0x00DB5558 File Offset: 0x00DB3758
		public QuestMultiLineTimePointData(QuestTimePointConfig config)
		{
			this.Config = new QuestTimePointConfig?(config);
			this.ConfigId = config.Id;
		}

		// Token: 0x060365FF RID: 222719 RVA: 0x00DB5590 File Offset: 0x00DB3790
		public void RefreshUnComponentGroups(Dictionary<int, bool> groupIdMap)
		{
			this.UnlockComponentGroups = new List<int>();
			foreach (int num in this.ComponentGroup)
			{
				if (groupIdMap.GetValueOrDefault(num, false))
				{
					this.UnlockComponentGroups.Add(num);
				}
			}
			this.RefreshUnlockComponentAndFightArea();
		}

		// Token: 0x17008D4E RID: 36174
		// (get) Token: 0x06036600 RID: 222720 RVA: 0x00DB55E0 File Offset: 0x00DB37E0
		public List<int> FightAreas
		{
			get
			{
				List<int> list = new List<int>();
				foreach (int item in this.FightAreaMap.Keys)
				{
					list.Add(item);
				}
				return list;
			}
		}

		// Token: 0x17008D4F RID: 36175
		// (get) Token: 0x06036601 RID: 222721 RVA: 0x00DB5640 File Offset: 0x00DB3840
		public List<QuestMultiLineComponentData> UnlockComponentArray
		{
			get
			{
				List<QuestMultiLineComponentData> list = new List<QuestMultiLineComponentData>();
				foreach (QuestMultiLineComponentData item in this.UnlockComponentMap.Values)
				{
					list.Add(item);
				}
				return list;
			}
		}

		// Token: 0x17008D50 RID: 36176
		// (get) Token: 0x06036602 RID: 222722 RVA: 0x00DB56A0 File Offset: 0x00DB38A0
		public Dictionary<int, QuestMultiLineComponentData> UnlockComponent
		{
			get
			{
				return this.UnlockComponentMap;
			}
		}

		// Token: 0x17008D51 RID: 36177
		// (get) Token: 0x06036603 RID: 222723 RVA: 0x00DB56A8 File Offset: 0x00DB38A8
		public List<QuestMultiLineComponentData> UnlockComponents
		{
			get
			{
				return this.UnlockComponentArray;
			}
		}

		// Token: 0x17008D52 RID: 36178
		// (get) Token: 0x06036604 RID: 222724 RVA: 0x00DB56B0 File Offset: 0x00DB38B0
		public Dictionary<int, bool> FightingAreaMap
		{
			get
			{
				return this.FightAreaMap;
			}
		}

		// Token: 0x17008D53 RID: 36179
		// (get) Token: 0x06036605 RID: 222725 RVA: 0x00DB56B8 File Offset: 0x00DB38B8
		// (set) Token: 0x06036606 RID: 222726 RVA: 0x00DB56C0 File Offset: 0x00DB38C0
		public bool IsUnLock
		{
			get
			{
				return this.UnLock;
			}
			set
			{
				this.UnLock = value;
			}
		}

		// Token: 0x17008D54 RID: 36180
		// (get) Token: 0x06036607 RID: 222727 RVA: 0x00DB56C9 File Offset: 0x00DB38C9
		public int Id
		{
			get
			{
				return this.ConfigId;
			}
		}

		// Token: 0x17008D55 RID: 36181
		// (get) Token: 0x06036608 RID: 222728 RVA: 0x00DB56D4 File Offset: 0x00DB38D4
		public string Name
		{
			get
			{
				return this.Config.Value.Name;
			}
		}

		// Token: 0x17008D56 RID: 36182
		// (get) Token: 0x06036609 RID: 222729 RVA: 0x00DB56F4 File Offset: 0x00DB38F4
		public int QuestId
		{
			get
			{
				return this.Config.Value.QuestId;
			}
		}

		// Token: 0x17008D57 RID: 36183
		// (get) Token: 0x0603660A RID: 222730 RVA: 0x00DB5714 File Offset: 0x00DB3914
		public string ScreenEffect
		{
			get
			{
				return this.Config.Value.ScreenEffect;
			}
		}

		// Token: 0x17008D58 RID: 36184
		// (get) Token: 0x0603660B RID: 222731 RVA: 0x00DB5734 File Offset: 0x00DB3934
		public int BranchPage
		{
			get
			{
				return this.Config.Value.BranchPage;
			}
		}

		// Token: 0x17008D59 RID: 36185
		// (get) Token: 0x0603660C RID: 222732 RVA: 0x00DB5754 File Offset: 0x00DB3954
		public int Sort
		{
			get
			{
				return this.Config.Value.Sort;
			}
		}

		// Token: 0x17008D5A RID: 36186
		// (get) Token: 0x0603660D RID: 222733 RVA: 0x00DB5774 File Offset: 0x00DB3974
		public int[] ComponentGroup
		{
			get
			{
				return this.Config.Value.ComponentGroup();
			}
		}

		// Token: 0x17008D5B RID: 36187
		// (get) Token: 0x0603660E RID: 222734 RVA: 0x00DB5794 File Offset: 0x00DB3994
		public bool IsBranchNode
		{
			get
			{
				return this.Config.Value.IsBranchNode;
			}
		}

		// Token: 0x17008D5C RID: 36188
		// (get) Token: 0x0603660F RID: 222735 RVA: 0x00DB57B4 File Offset: 0x00DB39B4
		public string Title
		{
			get
			{
				return this.Config.Value.Title;
			}
		}

		// Token: 0x17008D5D RID: 36189
		// (get) Token: 0x06036610 RID: 222736 RVA: 0x00DB57D4 File Offset: 0x00DB39D4
		public string Desc
		{
			get
			{
				return this.Config.Value.Desc;
			}
		}

		// Token: 0x17008D5E RID: 36190
		// (get) Token: 0x06036611 RID: 222737 RVA: 0x00DB57F4 File Offset: 0x00DB39F4
		public string NameBottom
		{
			get
			{
				return this.Config.Value.NameBottom;
			}
		}

		// Token: 0x06036612 RID: 222738 RVA: 0x00DB5814 File Offset: 0x00DB3A14
		private void RefreshUnlockComponentAndFightArea()
		{
			this.UnlockComponentMap.Clear();
			this.FightAreaMap.Clear();
			if (this.UnlockComponentGroups == null)
			{
				return;
			}
			foreach (int id in this.UnlockComponentGroups)
			{
				QuestBranchComponentGroup? branchComponentGroupConfig = QuestMultiLineConfig.GetBranchComponentGroupConfig(id);
				if (branchComponentGroupConfig != null)
				{
					foreach (int key in branchComponentGroupConfig.Value.ShownArea())
					{
						if (!this.FightAreaMap.GetValueOrDefault(key, false))
						{
							this.FightAreaMap[key] = true;
						}
					}
					foreach (int num in branchComponentGroupConfig.Value.BranchComponents())
					{
						if (!this.UnlockComponentMap.ContainsKey(num))
						{
							this.UnlockComponentMap[num] = new QuestMultiLineComponentData(num);
						}
					}
				}
			}
		}

		// Token: 0x06036613 RID: 222739 RVA: 0x00DB5920 File Offset: 0x00DB3B20
		public void RefreshBranchInfo(Dictionary<int, OneQuestBranchPageInfo> branchPageInfoMap)
		{
			if (this.BranchPage == 0)
			{
				this.BranchPageInfo = null;
				this.QuestMultiLineBranchPageData = null;
				return;
			}
			OneQuestBranchPageInfo oneQuestBranchPageInfo;
			if (!branchPageInfoMap.TryGetValue(this.BranchPage, out oneQuestBranchPageInfo))
			{
				oneQuestBranchPageInfo = OneQuestBranchPageInfo.Create();
				oneQuestBranchPageInfo.Id = this.BranchPage;
				oneQuestBranchPageInfo.CurBranch = 0;
			}
			this.BranchPageInfo = oneQuestBranchPageInfo;
			this.QuestMultiLineBranchPageData = new QuestMultiLineBranchPageData(this.BranchPageInfo);
		}

		// Token: 0x17008D5F RID: 36191
		// (get) Token: 0x06036614 RID: 222740 RVA: 0x00DB5985 File Offset: 0x00DB3B85
		[Nullable(2)]
		public QuestMultiLineBranchPageData BranchPageData
		{
			[NullableContext(2)]
			get
			{
				return this.QuestMultiLineBranchPageData;
			}
		}

		// Token: 0x17008D60 RID: 36192
		// (get) Token: 0x06036615 RID: 222741 RVA: 0x00DB598D File Offset: 0x00DB3B8D
		public bool IsBranchTimePoint
		{
			get
			{
				return this.BranchPage != 0;
			}
		}

		// Token: 0x17008D61 RID: 36193
		// (get) Token: 0x06036616 RID: 222742 RVA: 0x00DB5998 File Offset: 0x00DB3B98
		[Nullable(2)]
		public OneQuestBranchPageInfo BranchPageInfoData
		{
			[NullableContext(2)]
			get
			{
				return this.BranchPageInfo;
			}
		}

		// Token: 0x0401F458 RID: 128088
		private readonly int ConfigId;

		// Token: 0x0401F459 RID: 128089
		private bool UnLock;

		// Token: 0x0401F45A RID: 128090
		[Nullable(2)]
		private List<int> UnlockComponentGroups;

		// Token: 0x0401F45B RID: 128091
		[Nullable(2)]
		private QuestMultiLineBranchPageData QuestMultiLineBranchPageData;

		// Token: 0x0401F45C RID: 128092
		[Nullable(2)]
		private OneQuestBranchPageInfo BranchPageInfo;

		// Token: 0x0401F45D RID: 128093
		private readonly Dictionary<int, QuestMultiLineComponentData> UnlockComponentMap = new Dictionary<int, QuestMultiLineComponentData>();

		// Token: 0x0401F45E RID: 128094
		private readonly Dictionary<int, bool> FightAreaMap = new Dictionary<int, bool>();

		// Token: 0x0401F45F RID: 128095
		private readonly QuestTimePointConfig? Config;
	}
}
