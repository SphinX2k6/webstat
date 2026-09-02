using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace
{
	// Token: 0x02006B0C RID: 27404
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SeekTraceModel : ModelBase<SeekTraceModel>
	{
		// Token: 0x04025D9B RID: 155035
		public bool IsGameFinish;

		// Token: 0x04025D9C RID: 155036
		public bool GameFinishResult;

		// Token: 0x04025D9D RID: 155037
		public ITraceTracing Config;

		// Token: 0x04025D9E RID: 155038
		public int AddStep;

		// Token: 0x04025D9F RID: 155039
		public int PanelWidth;

		// Token: 0x04025DA0 RID: 155040
		public int PanelHeight;

		// Token: 0x04025DA1 RID: 155041
		public int ResetTimes;

		// Token: 0x04025DA2 RID: 155042
		public bool RemainUiAfterCompletion;

		// Token: 0x04025DA3 RID: 155043
		public int CurrentInteractEntityId = -1;

		// Token: 0x04025DA4 RID: 155044
		public ETraceTracingImageType IconType = ETraceTracingImageType.Type1;

		// Token: 0x04025DA5 RID: 155045
		public Action<bool> OnSeekTraceFinish;

		// Token: 0x04025DA6 RID: 155046
		public int StepLimit;

		// Token: 0x04025DA7 RID: 155047
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SeekTraceItemData> ItemDataList;

		// Token: 0x04025DA8 RID: 155048
		public List<bool> EnableGridList;

		// Token: 0x04025DA9 RID: 155049
		public SeekTraceItemData SelectedItem;

		// Token: 0x04025DAA RID: 155050
		public int[] SelectedStartPosition;

		// Token: 0x04025DAB RID: 155051
		public HashSet<int> SelectedStartFilledIndexSet;

		// Token: 0x04025DAC RID: 155052
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, SeekTraceItemData> IndexToItemMap;

		// Token: 0x04025DAD RID: 155053
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<int, HashSet<SeekTraceItemData>> PreSelectedIndexToItemsMap;

		// Token: 0x04025DAE RID: 155054
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<SeekTraceItemData, HashSet<int>> ItemToPreSelectedIndexSetMap;

		// Token: 0x04025DAF RID: 155055
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, SeekTraceItemData> MainItemMap;
	}
}
