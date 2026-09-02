using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ActorFxEmote
{
	// Token: 0x020061C5 RID: 25029
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ActorFxEmoteModel : ModelBase<ActorFxEmoteModel>
	{
		// Token: 0x0603F2A4 RID: 258724 RVA: 0x01036C33 File Offset: 0x01034E33
		protected override bool OnClear()
		{
			this.EntityDataMap.Clear();
			return true;
		}

		// Token: 0x0603F2A5 RID: 258725 RVA: 0x01036C41 File Offset: 0x01034E41
		[NullableContext(2)]
		public ActorFxEmoteData GetEntityData(int entityId)
		{
			return this.EntityDataMap.GetValueOrDefault(entityId);
		}

		// Token: 0x0603F2A6 RID: 258726 RVA: 0x01036C50 File Offset: 0x01034E50
		public ActorFxEmoteData GetOrCreateEntityData(int entityId)
		{
			ActorFxEmoteData actorFxEmoteData;
			if (!this.EntityDataMap.TryGetValue(entityId, out actorFxEmoteData))
			{
				actorFxEmoteData = new ActorFxEmoteData();
				this.EntityDataMap[entityId] = actorFxEmoteData;
			}
			return actorFxEmoteData;
		}

		// Token: 0x0603F2A7 RID: 258727 RVA: 0x01036C81 File Offset: 0x01034E81
		public void RemoveEntityData(int entityId)
		{
			this.EntityDataMap.Remove(entityId);
		}

		// Token: 0x0603F2A8 RID: 258728 RVA: 0x01036C90 File Offset: 0x01034E90
		public void ForEachEntityData(Action<int, ActorFxEmoteData> callback)
		{
			foreach (KeyValuePair<int, ActorFxEmoteData> keyValuePair in this.EntityDataMap)
			{
				int num;
				ActorFxEmoteData actorFxEmoteData;
				keyValuePair.Deconstruct(out num, out actorFxEmoteData);
				int arg = num;
				ActorFxEmoteData arg2 = actorFxEmoteData;
				callback(arg, arg2);
			}
		}

		// Token: 0x040237B1 RID: 145329
		public const string DEFAULT_SOCKET_KEY = "__default";

		// Token: 0x040237B2 RID: 145330
		private Dictionary<int, ActorFxEmoteData> EntityDataMap = new Dictionary<int, ActorFxEmoteData>();
	}
}
