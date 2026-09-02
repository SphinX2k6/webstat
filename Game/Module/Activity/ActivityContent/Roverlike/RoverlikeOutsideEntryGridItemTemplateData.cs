using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E8 RID: 25576
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeOutsideEntryGridItemTemplateData : IMultiTemplateGridData<RoverlikeGainEntry, RoverlikeOutsideEntryGridItem>, IMultiTemplateGridData
	{
		// Token: 0x17009DC8 RID: 40392
		// (get) Token: 0x06040390 RID: 263056 RVA: 0x0107561C File Offset: 0x0107381C
		// (set) Token: 0x06040391 RID: 263057 RVA: 0x01075624 File Offset: 0x01073824
		public RoverlikeGainEntry Data { get; set; }

		// Token: 0x17009DC9 RID: 40393
		// (get) Token: 0x06040392 RID: 263058 RVA: 0x0107562D File Offset: 0x0107382D
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x06040393 RID: 263059 RVA: 0x01075635 File Offset: 0x01073835
		public int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x06040394 RID: 263060 RVA: 0x01075638 File Offset: 0x01073838
		public RoverlikeOutsideEntryGridItem CreateProxy()
		{
			return new RoverlikeOutsideEntryGridItem
			{
				OnClickCb = this.OnClickCb,
				IsGridSelected = this.IsSelected,
				GetLockState = this.GetLockState
			};
		}

		// Token: 0x06040395 RID: 263061 RVA: 0x01075663 File Offset: 0x01073863
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}

		// Token: 0x04024031 RID: 147505
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoverlikeGainEntry, int> OnClickCb;

		// Token: 0x04024032 RID: 147506
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeGainEntry, int, bool> IsSelected;

		// Token: 0x04024033 RID: 147507
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeGainEntry, int, bool> GetLockState;
	}
}
