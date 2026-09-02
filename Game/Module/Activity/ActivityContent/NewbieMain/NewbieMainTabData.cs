using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain
{
	// Token: 0x0200664E RID: 26190
	[NullableContext(1)]
	[Nullable(0)]
	public class NewbieMainTabData
	{
		// Token: 0x0604165A RID: 267866 RVA: 0x010C6D9C File Offset: 0x010C4F9C
		public NewbieMainTabData(int tabId)
		{
			this.TabId = tabId;
		}

		// Token: 0x0604165B RID: 267867 RVA: 0x010C6DB6 File Offset: 0x010C4FB6
		public void SetCompletedTaskIds(IEnumerable<int> ids)
		{
			this.CompletedTaskIdsInternal = new HashSet<int>(ids);
		}

		// Token: 0x0604165C RID: 267868 RVA: 0x010C6DC4 File Offset: 0x010C4FC4
		public bool IsTaskCompleted(int taskId)
		{
			return this.CompletedTaskIdsInternal.Contains(taskId);
		}

		// Token: 0x0604165D RID: 267869 RVA: 0x010C6DD2 File Offset: 0x010C4FD2
		public HashSet<int> GetCompletedTaskIds()
		{
			return this.CompletedTaskIdsInternal;
		}

		// Token: 0x0604165E RID: 267870 RVA: 0x010C6DDA File Offset: 0x010C4FDA
		public int GetCompletedTaskCount()
		{
			return this.CompletedTaskIdsInternal.Count;
		}

		// Token: 0x04024923 RID: 149795
		public readonly int TabId;

		// Token: 0x04024924 RID: 149796
		private HashSet<int> CompletedTaskIdsInternal = new HashSet<int>();
	}
}
