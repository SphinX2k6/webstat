using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Model
{
	// Token: 0x02004847 RID: 18503
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SceneItemConnectorModel : ModelBase<SceneItemConnectorModel>
	{
		// Token: 0x06030230 RID: 197168 RVA: 0x00BACD28 File Offset: 0x00BAAF28
		public void AddConnectedRelation(int scrId, int[] targetId)
		{
			HashSet<int> hashSet;
			if (!this.ConnectedRelationCache.TryGetValue(scrId, out hashSet))
			{
				hashSet = new HashSet<int>();
				this.ConnectedRelationCache[scrId] = hashSet;
			}
			foreach (int item in targetId)
			{
				hashSet.Add(item);
			}
		}

		// Token: 0x06030231 RID: 197169 RVA: 0x00BACD74 File Offset: 0x00BAAF74
		public void RemoveConnectRelation(int scrId, int targetId)
		{
			HashSet<int> hashSet;
			if (this.ConnectedRelationCache.TryGetValue(scrId, out hashSet))
			{
				hashSet.Remove(targetId);
			}
		}

		// Token: 0x06030232 RID: 197170 RVA: 0x00BACD99 File Offset: 0x00BAAF99
		[NullableContext(2)]
		public HashSet<int> GetRelationByEntityId(int scrId)
		{
			return this.ConnectedRelationCache.GetValueOrDefault(scrId);
		}

		// Token: 0x0401BA1A RID: 113178
		private readonly Dictionary<int, HashSet<int>> ConnectedRelationCache = new Dictionary<int, HashSet<int>>();
	}
}
