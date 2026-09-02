using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006062 RID: 24674
	[NullableContext(1)]
	[Nullable(0)]
	public class LackResourceQuestViewShowData : IMissionItemViewShowData
	{
		// Token: 0x17009AAD RID: 39597
		// (get) Token: 0x0603E39A RID: 254874 RVA: 0x00FE2BFB File Offset: 0x00FE0DFB
		public EMissionItemViewDataSource DataSource
		{
			get
			{
				return EMissionItemViewDataSource.LackResourceQuest;
			}
		}

		// Token: 0x17009AAE RID: 39598
		// (get) Token: 0x0603E39B RID: 254875 RVA: 0x00FE2BFE File Offset: 0x00FE0DFE
		// (set) Token: 0x0603E39C RID: 254876 RVA: 0x00FE2C06 File Offset: 0x00FE0E06
		public int ShowPriority { get; private set; }

		// Token: 0x17009AAF RID: 39599
		// (get) Token: 0x0603E39D RID: 254877 RVA: 0x00FE2C0F File Offset: 0x00FE0E0F
		public long? ParentId
		{
			get
			{
				return new long?(0L);
			}
		}

		// Token: 0x17009AB0 RID: 39600
		// (get) Token: 0x0603E39E RID: 254878 RVA: 0x00FE2C18 File Offset: 0x00FE0E18
		// (set) Token: 0x0603E39F RID: 254879 RVA: 0x00FE2C20 File Offset: 0x00FE0E20
		public long Id { get; private set; }

		// Token: 0x17009AB1 RID: 39601
		// (get) Token: 0x0603E3A0 RID: 254880 RVA: 0x00FE2C29 File Offset: 0x00FE0E29
		// (set) Token: 0x0603E3A1 RID: 254881 RVA: 0x00FE2C31 File Offset: 0x00FE0E31
		public int TrackIconConfigId { get; private set; }

		// Token: 0x17009AB2 RID: 39602
		// (get) Token: 0x0603E3A2 RID: 254882 RVA: 0x00FE2C3A File Offset: 0x00FE0E3A
		// (set) Token: 0x0603E3A3 RID: 254883 RVA: 0x00FE2C42 File Offset: 0x00FE0E42
		public string TitleTextKey { get; private set; }

		// Token: 0x17009AB3 RID: 39603
		// (get) Token: 0x0603E3A4 RID: 254884 RVA: 0x00FE2C4B File Offset: 0x00FE0E4B
		// (set) Token: 0x0603E3A5 RID: 254885 RVA: 0x00FE2C53 File Offset: 0x00FE0E53
		[Nullable(2)]
		public LackResourceQuestTextInfo MainStepInfo { [NullableContext(2)] get; [NullableContext(2)] private set; }

		// Token: 0x17009AB4 RID: 39604
		// (get) Token: 0x0603E3A6 RID: 254886 RVA: 0x00FE2C5C File Offset: 0x00FE0E5C
		// (set) Token: 0x0603E3A7 RID: 254887 RVA: 0x00FE2C64 File Offset: 0x00FE0E64
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<LackResourceQuestTextInfo> SubStepInfos { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] private set; }

		// Token: 0x17009AB5 RID: 39605
		// (get) Token: 0x0603E3A8 RID: 254888 RVA: 0x00FE2C6D File Offset: 0x00FE0E6D
		MissionViewStepTextInfoBase IMissionItemViewShowData.MainStepInfo
		{
			get
			{
				return this.MainStepInfo;
			}
		}

		// Token: 0x17009AB6 RID: 39606
		// (get) Token: 0x0603E3A9 RID: 254889 RVA: 0x00FE2C75 File Offset: 0x00FE0E75
		IReadOnlyList<MissionViewStepTextInfoBase> IMissionItemViewShowData.SubStepInfos
		{
			get
			{
				return this.SubStepInfos;
			}
		}

		// Token: 0x0603E3AA RID: 254890 RVA: 0x00FE2C7D File Offset: 0x00FE0E7D
		public static LackResourceQuestViewShowData Create(int id, int trackIconConfigId, string titleTextKey, [Nullable(2)] LackResourceQuestTextInfo mainStepText, [Nullable(new byte[]
		{
			2,
			1
		})] List<LackResourceQuestTextInfo> subStepTexts)
		{
			return new LackResourceQuestViewShowData
			{
				Id = (long)id,
				TrackIconConfigId = trackIconConfigId,
				TitleTextKey = titleTextKey,
				MainStepInfo = mainStepText,
				SubStepInfos = subStepTexts,
				ShowPriority = id
			};
		}
	}
}
