using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.Model
{
	// Token: 0x02004842 RID: 18498
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ConnectGamePlayModel : ModelBase<ConnectGamePlayModel>
	{
		// Token: 0x0603020F RID: 197135 RVA: 0x00BAC73C File Offset: 0x00BAA93C
		public void AddConnectedRelation(int scrId, List<int> targetId)
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

		// Token: 0x06030210 RID: 197136 RVA: 0x00BAC7B0 File Offset: 0x00BAA9B0
		public void SetRelationPortalParam(int scrId, PassThroughPortalParam portalParam)
		{
			this.ConnectedRelationPortalParam[scrId] = portalParam;
		}

		// Token: 0x06030211 RID: 197137 RVA: 0x00BAC7C0 File Offset: 0x00BAA9C0
		public void RemoveConnectRelation(int scrId, int targetId)
		{
			HashSet<int> hashSet;
			if (this.ConnectedRelationCache.TryGetValue(scrId, out hashSet))
			{
				hashSet.Remove(targetId);
			}
		}

		// Token: 0x06030212 RID: 197138 RVA: 0x00BAC7E5 File Offset: 0x00BAA9E5
		public void RemoveRelationPortalType(int scrId)
		{
			this.ConnectedRelationPortalParam.Remove(scrId);
		}

		// Token: 0x06030213 RID: 197139 RVA: 0x00BAC7F4 File Offset: 0x00BAA9F4
		[NullableContext(2)]
		public HashSet<int> GetRelationByEntityId(int scrId)
		{
			return this.ConnectedRelationCache.GetValueOrDefault(scrId);
		}

		// Token: 0x06030214 RID: 197140 RVA: 0x00BAC802 File Offset: 0x00BAAA02
		[NullableContext(2)]
		public PassThroughPortalParam GetRelationPassThroughParam(int scrId)
		{
			return this.ConnectedRelationPortalParam.GetValueOrDefault(scrId);
		}

		// Token: 0x0401BA11 RID: 113169
		public readonly int TryConnectInterval = 500;

		// Token: 0x0401BA12 RID: 113170
		private readonly Dictionary<int, HashSet<int>> ConnectedRelationCache = new Dictionary<int, HashSet<int>>();

		// Token: 0x0401BA13 RID: 113171
		private readonly Dictionary<int, PassThroughPortalParam> ConnectedRelationPortalParam = new Dictionary<int, PassThroughPortalParam>();
	}
}
