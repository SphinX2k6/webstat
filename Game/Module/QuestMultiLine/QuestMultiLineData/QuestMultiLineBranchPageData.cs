using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData
{
	// Token: 0x02005344 RID: 21316
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineBranchPageData
	{
		// Token: 0x060365E3 RID: 222691 RVA: 0x00DB51A0 File Offset: 0x00DB33A0
		public QuestMultiLineBranchPageData(OneQuestBranchPageInfo branchPageInfo)
		{
			this.Config = QuestMultiLineConfig.GetBranchPageConfigById(branchPageInfo.Id);
			this.BranchDataArray = new List<QuestMultiLineBranchData>();
			int[] branch = this.Branch;
			for (int i = 0; i < branch.Length; i++)
			{
				QuestMultiLineBranchData questMultiLineBranchData = new QuestMultiLineBranchData(branch[i]);
				this.BranchDataArray.Add(questMultiLineBranchData);
				if (questMultiLineBranchData.BranchId == branchPageInfo.CurBranch)
				{
					questMultiLineBranchData.State = EBranchState.CurSelected;
				}
				else if (branchPageInfo.CompleteBranches.Contains(questMultiLineBranchData.BranchId))
				{
					questMultiLineBranchData.State = EBranchState.Finish;
				}
			}
		}

		// Token: 0x17008D35 RID: 36149
		// (get) Token: 0x060365E4 RID: 222692 RVA: 0x00DB522C File Offset: 0x00DB342C
		public int Id
		{
			get
			{
				return this.Config.Value.Id;
			}
		}

		// Token: 0x17008D36 RID: 36150
		// (get) Token: 0x060365E5 RID: 222693 RVA: 0x00DB524C File Offset: 0x00DB344C
		public int[] Branch
		{
			get
			{
				return this.Config.Value.Branch();
			}
		}

		// Token: 0x17008D37 RID: 36151
		// (get) Token: 0x060365E6 RID: 222694 RVA: 0x00DB526C File Offset: 0x00DB346C
		public Aki.Config.IntVector2D[] QuestNodes
		{
			get
			{
				return this.Config.Value.QuestNodes();
			}
		}

		// Token: 0x17008D38 RID: 36152
		// (get) Token: 0x060365E7 RID: 222695 RVA: 0x00DB528C File Offset: 0x00DB348C
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<QuestMultiLineBranchData> BranchData
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return this.BranchDataArray;
			}
		}

		// Token: 0x0401F455 RID: 128085
		private readonly QuestBranchPageConfig? Config;

		// Token: 0x0401F456 RID: 128086
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly List<QuestMultiLineBranchData> BranchDataArray;
	}
}
