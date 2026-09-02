using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C2B RID: 27691
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventWaitSceneRefEntityPlaySequence : LevelEventBase
	{
		// Token: 0x060441D0 RID: 278992 RVA: 0x011B0665 File Offset: 0x011AE865
		public LevelEventWaitSceneRefEntityPlaySequence(int id) : base(id)
		{
		}

		// Token: 0x060441D1 RID: 278993 RVA: 0x011B067C File Offset: 0x011AE87C
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			WaitUntilLevelSequenceReachMark waitUntilLevelSequenceReachMark = inParams as WaitUntilLevelSequenceReachMark;
			if (waitUntilLevelSequenceReachMark == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventWaitSceneRefEntityPlaySequence失败，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.PbDataId = waitUntilLevelSequenceReachMark.EntityId;
			this.Mark = waitUntilLevelSequenceReachMark.Mark;
			this.EntityReady = false;
			base.CreateWaitEntityTask(waitUntilLevelSequenceReachMark.EntityId);
			if (this.CheckEntityPlaySequenceFinished(waitUntilLevelSequenceReachMark.EntityId, waitUntilLevelSequenceReachMark.Mark))
			{
				base.FinishExecute(true, false, true);
			}
		}

		// Token: 0x060441D2 RID: 278994 RVA: 0x011B06F8 File Offset: 0x011AE8F8
		protected override void ExecuteWhenEntitiesReady()
		{
			this.EntityReady = true;
		}

		// Token: 0x060441D3 RID: 278995 RVA: 0x011B0701 File Offset: 0x011AE901
		protected override void OnTick(float deltaTime)
		{
			if (this.CheckEntityPlaySequenceFinished(this.PbDataId, this.Mark))
			{
				base.FinishExecute(true, false, true);
			}
		}

		// Token: 0x060441D4 RID: 278996 RVA: 0x011B0720 File Offset: 0x011AE920
		private bool CheckEntityPlaySequenceFinished(int pbDataId, string mark)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
			bool flag;
			if (entityByPbDataId == null)
			{
				flag = true;
			}
			else
			{
				WorldEntity entity = entityByPbDataId.Entity;
				flag = !((entity != null) ? new bool?(entity.Valid) : null).GetValueOrDefault();
			}
			if (flag || !this.EntityReady)
			{
				return true;
			}
			SceneItemReferenceComponent component = entityByPbDataId.Entity.GetComponent<SceneItemReferenceComponent>();
			if (component == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "LevelEventWaitSceneRefEntityPlaySequence:找不到实体身上的SceneItemReferenceComponent组件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", pbDataId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return true;
			}
			return component.IsPlayToMarkFinished(mark);
		}

		// Token: 0x0402609F RID: 155807
		private int PbDataId;

		// Token: 0x040260A0 RID: 155808
		private string Mark = "";

		// Token: 0x040260A1 RID: 155809
		private bool EntityReady;
	}
}
