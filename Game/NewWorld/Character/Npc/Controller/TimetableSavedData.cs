using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Npc.Controller
{
	// Token: 0x020048D5 RID: 18645
	[NullableContext(1)]
	[Nullable(0)]
	public class TimetableSavedData
	{
		// Token: 0x06030A67 RID: 199271 RVA: 0x00BFCEF7 File Offset: 0x00BFB0F7
		public TimetableSavedData(TimetableConfigData config)
		{
			this.TimetableConfig = config;
		}

		// Token: 0x06030A68 RID: 199272 RVA: 0x00BFCF11 File Offset: 0x00BFB111
		public TimetableSavedData DeepCopy()
		{
			TimetableSavedData timetableSavedData = new TimetableSavedData(this.TimetableConfig);
			timetableSavedData.BehaviorTreeData = this.BehaviorTreeData.DeepCopy();
			PatrolSavedData patrolData = this.PatrolData;
			timetableSavedData.PatrolData = ((patrolData != null) ? patrolData.DeepCopy() : null);
			return timetableSavedData;
		}

		// Token: 0x06030A69 RID: 199273 RVA: 0x00BFCF48 File Offset: 0x00BFB148
		public bool IsValid()
		{
			if (this.TimetableConfig == null)
			{
				return false;
			}
			if (this.TimetableConfig.BehaviorTreePath != this.BehaviorTreeData.Path)
			{
				return false;
			}
			if (!this.BehaviorTreeData.IsValid())
			{
				PatrolSavedData patrolData = this.PatrolData;
				if (patrolData == null || !patrolData.IsValid())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401BF70 RID: 114544
		[Nullable(2)]
		public TimetableConfigData TimetableConfig;

		// Token: 0x0401BF71 RID: 114545
		public BehaviorTreeSavedData BehaviorTreeData = new BehaviorTreeSavedData();

		// Token: 0x0401BF72 RID: 114546
		[Nullable(2)]
		public PatrolSavedData PatrolData;
	}
}
