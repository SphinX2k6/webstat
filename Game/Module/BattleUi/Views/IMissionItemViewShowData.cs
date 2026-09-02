using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200605F RID: 24671
	[NullableContext(2)]
	public interface IMissionItemViewShowData
	{
		// Token: 0x17009A93 RID: 39571
		// (get) Token: 0x0603E371 RID: 254833
		EMissionItemViewDataSource DataSource { get; }

		// Token: 0x17009A94 RID: 39572
		// (get) Token: 0x0603E372 RID: 254834
		long Id { get; }

		// Token: 0x17009A95 RID: 39573
		// (get) Token: 0x0603E373 RID: 254835
		int ShowPriority { get; }

		// Token: 0x17009A96 RID: 39574
		// (get) Token: 0x0603E374 RID: 254836
		int TrackIconConfigId { get; }

		// Token: 0x17009A97 RID: 39575
		// (get) Token: 0x0603E375 RID: 254837
		string TitleTextKey { get; }

		// Token: 0x17009A98 RID: 39576
		// (get) Token: 0x0603E376 RID: 254838
		MissionViewStepTextInfoBase MainStepInfo { get; }

		// Token: 0x17009A99 RID: 39577
		// (get) Token: 0x0603E377 RID: 254839
		[Nullable(new byte[]
		{
			2,
			1
		})]
		IReadOnlyList<MissionViewStepTextInfoBase> SubStepInfos { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; }

		// Token: 0x17009A9A RID: 39578
		// (get) Token: 0x0603E378 RID: 254840
		long? ParentId { get; }
	}
}
