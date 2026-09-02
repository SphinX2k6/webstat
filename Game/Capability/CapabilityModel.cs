using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Capability.Editor;
using UnrealEngine;

namespace CSharpScript.Game.Capability
{
	// Token: 0x02007078 RID: 28792
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class CapabilityModel : ModelBase<CapabilityModel>
	{
		// Token: 0x06045C7D RID: 285821 RVA: 0x01241FB7 File Offset: 0x012401B7
		public void BumpScheduleGeneration()
		{
			this.ScheduleGeneration++;
		}

		// Token: 0x06045C7E RID: 285822 RVA: 0x01241FC7 File Offset: 0x012401C7
		private void ClearDebugger()
		{
			this.Debugger.Clear();
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				CapabilityTimelineDebugger timelineDebugger = this.TimelineDebugger;
				if (timelineDebugger != null)
				{
					timelineDebugger.Hide();
				}
				this.TimelineDebugger = null;
			}
		}

		// Token: 0x06045C7F RID: 285823 RVA: 0x01241FF8 File Offset: 0x012401F8
		protected override bool OnInit()
		{
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				this.TimelineDebugger = new CapabilityTimelineDebugger(this.Debugger);
				this.TimelineDebugger.SetWindowSeconds(20f);
			}
			return true;
		}

		// Token: 0x06045C80 RID: 285824 RVA: 0x01242028 File Offset: 0x01240228
		protected override bool OnLeaveLevel()
		{
			this.ClearDebugger();
			return true;
		}

		// Token: 0x06045C81 RID: 285825 RVA: 0x01242031 File Offset: 0x01240231
		protected override bool OnChangeMode()
		{
			this.ClearDebugger();
			return true;
		}

		// Token: 0x06045C82 RID: 285826 RVA: 0x0124203A File Offset: 0x0124023A
		protected override bool OnClear()
		{
			this.ClearDebugger();
			return true;
		}

		// Token: 0x04027097 RID: 159895
		public readonly HashSet<ICapabilityGameObject> GameObjects = new HashSet<ICapabilityGameObject>();

		// Token: 0x04027098 RID: 159896
		public readonly CapabilityDebugger Debugger = new CapabilityDebugger();

		// Token: 0x04027099 RID: 159897
		[Nullable(2)]
		public CapabilityTimelineDebugger TimelineDebugger;

		// Token: 0x0402709A RID: 159898
		public readonly Dictionary<ETickingGroup, int> RegisteredTickGroups = new Dictionary<ETickingGroup, int>();

		// Token: 0x0402709B RID: 159899
		public int ScheduleGeneration;

		// Token: 0x0402709C RID: 159900
		public readonly Dictionary<ETickingGroup, List<IScheduledEntry>> GroupScheduleCache = new Dictionary<ETickingGroup, List<IScheduledEntry>>();

		// Token: 0x0402709D RID: 159901
		public int GroupScheduleCacheGeneration = -1;

		// Token: 0x0402709E RID: 159902
		public readonly WeakMap<ICapabilityGameObject, HostDefaultScheduleCacheEntry> HostDefaultScheduleCache = new WeakMap<ICapabilityGameObject, HostDefaultScheduleCacheEntry>();
	}
}
