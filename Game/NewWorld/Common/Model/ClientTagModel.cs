using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Common.Model
{
	// Token: 0x020048B7 RID: 18615
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ClientTagModel : ModelBase<ClientTagModel>
	{
		// Token: 0x06030877 RID: 198775 RVA: 0x00BEAA76 File Offset: 0x00BE8C76
		protected override bool OnInit()
		{
			this.ClientModifiedTag = new Dictionary<int, HashSet<int>>();
			return true;
		}

		// Token: 0x06030878 RID: 198776 RVA: 0x00BEAA84 File Offset: 0x00BE8C84
		protected override bool OnClear()
		{
			Dictionary<int, HashSet<int>> clientModifiedTag = this.ClientModifiedTag;
			if (clientModifiedTag != null)
			{
				clientModifiedTag.Clear();
			}
			this.ClientModifiedTag = null;
			return true;
		}

		// Token: 0x06030879 RID: 198777 RVA: 0x00BEAAA0 File Offset: 0x00BE8CA0
		public void ClientAddTagToTarget(int entityId, int tagId)
		{
			HashSet<int> hashSet;
			if (!this.ClientModifiedTag.TryGetValue(entityId, out hashSet))
			{
				hashSet = new HashSet<int>();
				this.ClientModifiedTag.Add(entityId, hashSet);
			}
			hashSet.Add(tagId);
		}

		// Token: 0x0603087A RID: 198778 RVA: 0x00BEAAD8 File Offset: 0x00BE8CD8
		public bool ClearTargetTagAdded(int entityId)
		{
			return this.ClientModifiedTag.Remove(entityId);
		}

		// Token: 0x0603087B RID: 198779 RVA: 0x00BEAAE8 File Offset: 0x00BE8CE8
		public bool ClientRemoveTagFromTarget(int entityId, int tagId)
		{
			HashSet<int> hashSet;
			return this.ClientModifiedTag.TryGetValue(entityId, out hashSet) && hashSet.Remove(tagId);
		}

		// Token: 0x0401BE45 RID: 114245
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, HashSet<int>> ClientModifiedTag;
	}
}
