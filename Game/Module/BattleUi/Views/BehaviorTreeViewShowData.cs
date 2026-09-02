using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006060 RID: 24672
	[NullableContext(2)]
	[Nullable(0)]
	public class BehaviorTreeViewShowData : IMissionItemViewShowData
	{
		// Token: 0x17009A9B RID: 39579
		// (get) Token: 0x0603E379 RID: 254841 RVA: 0x00FE2A6D File Offset: 0x00FE0C6D
		public EMissionItemViewDataSource DataSource
		{
			get
			{
				return EMissionItemViewDataSource.BehaviorTree;
			}
		}

		// Token: 0x17009A9C RID: 39580
		// (get) Token: 0x0603E37A RID: 254842 RVA: 0x00FE2A70 File Offset: 0x00FE0C70
		// (set) Token: 0x0603E37B RID: 254843 RVA: 0x00FE2A78 File Offset: 0x00FE0C78
		public long Id { get; private set; }

		// Token: 0x17009A9D RID: 39581
		// (get) Token: 0x0603E37C RID: 254844 RVA: 0x00FE2A81 File Offset: 0x00FE0C81
		// (set) Token: 0x0603E37D RID: 254845 RVA: 0x00FE2A89 File Offset: 0x00FE0C89
		public int TrackIconConfigId { get; private set; }

		// Token: 0x17009A9E RID: 39582
		// (get) Token: 0x0603E37E RID: 254846 RVA: 0x00FE2A92 File Offset: 0x00FE0C92
		// (set) Token: 0x0603E37F RID: 254847 RVA: 0x00FE2A9A File Offset: 0x00FE0C9A
		public int ShowPriority { get; private set; }

		// Token: 0x17009A9F RID: 39583
		// (get) Token: 0x0603E380 RID: 254848 RVA: 0x00FE2AA3 File Offset: 0x00FE0CA3
		// (set) Token: 0x0603E381 RID: 254849 RVA: 0x00FE2AAB File Offset: 0x00FE0CAB
		public string TitleTextKey { get; private set; }

		// Token: 0x17009AA0 RID: 39584
		// (get) Token: 0x0603E382 RID: 254850 RVA: 0x00FE2AB4 File Offset: 0x00FE0CB4
		// (set) Token: 0x0603E383 RID: 254851 RVA: 0x00FE2ABC File Offset: 0x00FE0CBC
		public long? ParentId { get; private set; }

		// Token: 0x17009AA1 RID: 39585
		// (get) Token: 0x0603E384 RID: 254852 RVA: 0x00FE2AC5 File Offset: 0x00FE0CC5
		[Nullable(1)]
		MissionViewStepTextInfoBase IMissionItemViewShowData.MainStepInfo
		{
			[NullableContext(1)]
			get
			{
				return this.MainStepInfo;
			}
		}

		// Token: 0x17009AA2 RID: 39586
		// (get) Token: 0x0603E385 RID: 254853 RVA: 0x00FE2ACD File Offset: 0x00FE0CCD
		[Nullable(1)]
		IReadOnlyList<MissionViewStepTextInfoBase> IMissionItemViewShowData.SubStepInfos
		{
			[NullableContext(1)]
			get
			{
				return this.SubStepInfos;
			}
		}

		// Token: 0x0603E386 RID: 254854 RVA: 0x00FE2AD8 File Offset: 0x00FE0CD8
		[return: Nullable(1)]
		public static BehaviorTreeViewShowData Create(BtType btType, long treeIncId, int treeConfigId, bool bInChallenge, int trackIconConfigId, int showPriority, string titleTextKey, BehaviorTreeStepTextInfo mainStepText, [Nullable(new byte[]
		{
			2,
			1
		})] List<BehaviorTreeStepTextInfo> subStepText, long? parentId)
		{
			return new BehaviorTreeViewShowData
			{
				BtType = btType,
				Id = treeIncId,
				TreeConfigId = treeConfigId,
				IsInChallenge = bInChallenge,
				TrackIconConfigId = trackIconConfigId,
				ShowPriority = showPriority,
				TitleTextKey = titleTextKey,
				MainStepInfo = mainStepText,
				SubStepInfos = subStepText,
				ParentId = parentId
			};
		}

		// Token: 0x04022E11 RID: 142865
		public BtType BtType;

		// Token: 0x04022E13 RID: 142867
		public int TreeConfigId;

		// Token: 0x04022E14 RID: 142868
		public bool IsInChallenge;

		// Token: 0x04022E18 RID: 142872
		public BehaviorTreeStepTextInfo MainStepInfo;

		// Token: 0x04022E19 RID: 142873
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<BehaviorTreeStepTextInfo> SubStepInfos;
	}
}
