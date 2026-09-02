using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006061 RID: 24673
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingEntrustViewShowData : IMissionItemViewShowData
	{
		// Token: 0x17009AA3 RID: 39587
		// (get) Token: 0x0603E388 RID: 254856 RVA: 0x00FE2B3E File Offset: 0x00FE0D3E
		public EMissionItemViewDataSource DataSource
		{
			get
			{
				return EMissionItemViewDataSource.FishingEntrust;
			}
		}

		// Token: 0x17009AA4 RID: 39588
		// (get) Token: 0x0603E389 RID: 254857 RVA: 0x00FE2B41 File Offset: 0x00FE0D41
		// (set) Token: 0x0603E38A RID: 254858 RVA: 0x00FE2B49 File Offset: 0x00FE0D49
		public int ShowPriority { get; private set; }

		// Token: 0x17009AA5 RID: 39589
		// (get) Token: 0x0603E38B RID: 254859 RVA: 0x00FE2B52 File Offset: 0x00FE0D52
		public long? ParentId
		{
			get
			{
				return new long?(0L);
			}
		}

		// Token: 0x17009AA6 RID: 39590
		// (get) Token: 0x0603E38C RID: 254860 RVA: 0x00FE2B5B File Offset: 0x00FE0D5B
		// (set) Token: 0x0603E38D RID: 254861 RVA: 0x00FE2B63 File Offset: 0x00FE0D63
		public long Id { get; private set; }

		// Token: 0x17009AA7 RID: 39591
		// (get) Token: 0x0603E38E RID: 254862 RVA: 0x00FE2B6C File Offset: 0x00FE0D6C
		// (set) Token: 0x0603E38F RID: 254863 RVA: 0x00FE2B74 File Offset: 0x00FE0D74
		public int TrackIconConfigId { get; private set; }

		// Token: 0x17009AA8 RID: 39592
		// (get) Token: 0x0603E390 RID: 254864 RVA: 0x00FE2B7D File Offset: 0x00FE0D7D
		// (set) Token: 0x0603E391 RID: 254865 RVA: 0x00FE2B85 File Offset: 0x00FE0D85
		public string TitleTextKey { get; private set; }

		// Token: 0x17009AA9 RID: 39593
		// (get) Token: 0x0603E392 RID: 254866 RVA: 0x00FE2B8E File Offset: 0x00FE0D8E
		// (set) Token: 0x0603E393 RID: 254867 RVA: 0x00FE2B96 File Offset: 0x00FE0D96
		[Nullable(2)]
		public FishingEntrustStepTextInfo MainStepInfo { [NullableContext(2)] get; [NullableContext(2)] private set; }

		// Token: 0x17009AAA RID: 39594
		// (get) Token: 0x0603E394 RID: 254868 RVA: 0x00FE2B9F File Offset: 0x00FE0D9F
		// (set) Token: 0x0603E395 RID: 254869 RVA: 0x00FE2BA7 File Offset: 0x00FE0DA7
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<FishingEntrustStepTextInfo> SubStepInfos { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] private set; }

		// Token: 0x17009AAB RID: 39595
		// (get) Token: 0x0603E396 RID: 254870 RVA: 0x00FE2BB0 File Offset: 0x00FE0DB0
		MissionViewStepTextInfoBase IMissionItemViewShowData.MainStepInfo
		{
			get
			{
				return this.MainStepInfo;
			}
		}

		// Token: 0x17009AAC RID: 39596
		// (get) Token: 0x0603E397 RID: 254871 RVA: 0x00FE2BB8 File Offset: 0x00FE0DB8
		IReadOnlyList<MissionViewStepTextInfoBase> IMissionItemViewShowData.SubStepInfos
		{
			get
			{
				return this.SubStepInfos;
			}
		}

		// Token: 0x0603E398 RID: 254872 RVA: 0x00FE2BC0 File Offset: 0x00FE0DC0
		public static FishingEntrustViewShowData Create(int id, int trackIconConfigId, string titleTextKey, [Nullable(2)] FishingEntrustStepTextInfo mainStepText, [Nullable(new byte[]
		{
			2,
			1
		})] List<FishingEntrustStepTextInfo> subStepTexts)
		{
			return new FishingEntrustViewShowData
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
