using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD3 RID: 27603
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventRemoveBuffFromCreature : LevelEventBase
	{
		// Token: 0x06044088 RID: 278664 RVA: 0x011A5753 File Offset: 0x011A3953
		public LevelEventRemoveBuffFromCreature(int id) : base(id)
		{
		}

		// Token: 0x06044089 RID: 278665 RVA: 0x011A575C File Offset: 0x011A395C
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			RemoveBuffFromEntity removeBuffFromEntity = inParams as RemoveBuffFromEntity;
			if (removeBuffFromEntity == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.ZS, "参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			this.EventParam = removeBuffFromEntity;
			this.EntityIds = new List<int>();
			if (removeBuffFromEntity.EntityId != null)
			{
				this.EntityIds.Add(removeBuffFromEntity.EntityId.Value);
			}
			List<int> entityIds = removeBuffFromEntity.EntityIds;
			if (entityIds != null && entityIds.Count > 0)
			{
				foreach (int item in removeBuffFromEntity.EntityIds)
				{
					this.EntityIds.Add(item);
				}
			}
			base.CreateWaitEntityTask(this.EntityIds);
		}

		// Token: 0x0604408A RID: 278666 RVA: 0x011A5844 File Offset: 0x011A3A44
		protected override void ExecuteWhenEntitiesReady()
		{
			foreach (int pbDataId in this.EntityIds)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
				if (entityByPbDataId != null && entityByPbDataId.IsInit)
				{
					CharacterBuffComponent component = entityByPbDataId.Entity.GetComponent<CharacterBuffComponent>();
					foreach (long buffId in this.EventParam.BuffIds)
					{
						component.RemoveBuff(buffId, -1, "LevelEventRemoveBuffFromCreature", null, null, null);
					}
				}
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0604408B RID: 278667 RVA: 0x011A5938 File Offset: 0x011A3B38
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			RemoveBuffFromEntity removeBuffFromEntity = inParams as RemoveBuffFromEntity;
			if (removeBuffFromEntity == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.ZS;
				string message = "执行行为时:参数类型错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EventType", this.Type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false, false, true);
				return;
			}
			this.EventParam = removeBuffFromEntity;
			this.EntityIds = new List<int>();
			if (removeBuffFromEntity.EntityId != null)
			{
				this.EntityIds.Add(removeBuffFromEntity.EntityId.Value);
			}
			List<int> entityIds = removeBuffFromEntity.EntityIds;
			if (entityIds != null && entityIds.Count > 0)
			{
				foreach (int item in removeBuffFromEntity.EntityIds)
				{
					this.EntityIds.Add(item);
				}
			}
			this.ExecuteWhenEntitiesReady();
		}

		// Token: 0x0402605F RID: 155743
		[Nullable(2)]
		private RemoveBuffFromEntity EventParam;

		// Token: 0x04026060 RID: 155744
		[Nullable(2)]
		private List<int> EntityIds;
	}
}
