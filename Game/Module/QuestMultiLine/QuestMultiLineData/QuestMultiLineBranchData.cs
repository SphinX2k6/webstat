using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData
{
	// Token: 0x02005343 RID: 21315
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineBranchData
	{
		// Token: 0x060365D9 RID: 222681 RVA: 0x00DB5060 File Offset: 0x00DB3260
		public QuestMultiLineBranchData(int configId)
		{
			this.Config = QuestMultiLineConfig.GetQuestBranchConfig(configId);
			int[] array = this.Config.Value.Component();
			for (int i = 0; i < array.Length; i++)
			{
				QuestMultiLineComponentData item = new QuestMultiLineComponentData(array[i]);
				this.QuestMultiLineComponentDataList.Add(item);
			}
		}

		// Token: 0x17008D2D RID: 36141
		// (get) Token: 0x060365DA RID: 222682 RVA: 0x00DB50C4 File Offset: 0x00DB32C4
		public int BranchId
		{
			get
			{
				return this.Config.Value.Id;
			}
		}

		// Token: 0x17008D2E RID: 36142
		// (get) Token: 0x060365DB RID: 222683 RVA: 0x00DB50E4 File Offset: 0x00DB32E4
		public string Name
		{
			get
			{
				return this.Config.Value.Name;
			}
		}

		// Token: 0x17008D2F RID: 36143
		// (get) Token: 0x060365DC RID: 222684 RVA: 0x00DB5104 File Offset: 0x00DB3304
		public string Icon
		{
			get
			{
				return this.Config.Value.Icon;
			}
		}

		// Token: 0x17008D30 RID: 36144
		// (get) Token: 0x060365DD RID: 222685 RVA: 0x00DB5124 File Offset: 0x00DB3324
		public string[] Icons
		{
			get
			{
				return this.Config.Value.Icons();
			}
		}

		// Token: 0x17008D31 RID: 36145
		// (get) Token: 0x060365DE RID: 222686 RVA: 0x00DB5144 File Offset: 0x00DB3344
		public string Desc
		{
			get
			{
				return this.Config.Value.Desc;
			}
		}

		// Token: 0x17008D32 RID: 36146
		// (get) Token: 0x060365DF RID: 222687 RVA: 0x00DB5164 File Offset: 0x00DB3364
		public int[] FightingAreas
		{
			get
			{
				return this.Config.Value.ShownAreaRoute();
			}
		}

		// Token: 0x17008D33 RID: 36147
		// (get) Token: 0x060365E0 RID: 222688 RVA: 0x00DB5184 File Offset: 0x00DB3384
		public List<QuestMultiLineComponentData> Components
		{
			get
			{
				return this.QuestMultiLineComponentDataList;
			}
		}

		// Token: 0x17008D34 RID: 36148
		// (get) Token: 0x060365E1 RID: 222689 RVA: 0x00DB518C File Offset: 0x00DB338C
		// (set) Token: 0x060365E2 RID: 222690 RVA: 0x00DB5194 File Offset: 0x00DB3394
		public EBranchState State
		{
			get
			{
				return this.BranchState;
			}
			set
			{
				this.BranchState = value;
			}
		}

		// Token: 0x0401F452 RID: 128082
		private EBranchState BranchState;

		// Token: 0x0401F453 RID: 128083
		private readonly QuestBranchConfig? Config;

		// Token: 0x0401F454 RID: 128084
		private readonly List<QuestMultiLineComponentData> QuestMultiLineComponentDataList = new List<QuestMultiLineComponentData>();
	}
}
