using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Npc.Logics;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BCA RID: 27594
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventPlayWalkingOverlayMontage : LevelEventBase
	{
		// Token: 0x0604406A RID: 278634 RVA: 0x011A4205 File Offset: 0x011A2405
		public LevelEventPlayWalkingOverlayMontage(int id) : base(id)
		{
		}

		// Token: 0x0604406B RID: 278635 RVA: 0x011A4210 File Offset: 0x011A2410
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PlayWalkingOverlayMontage playWalkingOverlayMontage = inParams as PlayWalkingOverlayMontage;
			this.EventParam = playWalkingOverlayMontage;
			base.CreateWaitEntityTask(playWalkingOverlayMontage.EntityId);
		}

		// Token: 0x0604406C RID: 278636 RVA: 0x011A4238 File Offset: 0x011A2438
		protected override void ExecuteWhenEntitiesReady()
		{
			if (this.EventParam == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.EventParam.EntityId);
			CharacterAnimationComponent characterAnimationComponent;
			if (entityByPbDataId == null)
			{
				characterAnimationComponent = null;
			}
			else
			{
				WorldEntity entity = entityByPbDataId.Entity;
				characterAnimationComponent = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			CharacterAnimationComponent characterAnimationComponent2 = characterAnimationComponent;
			if (entityByPbDataId == null || characterAnimationComponent2 == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			this.EntityHandle = entityByPbDataId;
			PlayMontageConfig config = new PlayMontageConfig(this.EventParam.RepeatTimes.GetValueOrDefault(), (double)this.EventParam.LoopDuration.GetValueOrDefault(), false, false);
			this.PlayMontageHandle = Singleton<PlayMontageUtils>.Instance.LoadAndPlayMontageByOverlapId(characterAnimationComponent2, this.EventParam.OverlapMontageId, config, null, null, null);
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0604406D RID: 278637 RVA: 0x011A42F8 File Offset: 0x011A24F8
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (this.EntityHandle != handle)
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "实体被移除，PlayRegisteredMontaged保底结束";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", handle.PbDataId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			if (this.PlayMontageHandle != 0)
			{
				Singleton<PlayMontageUtils>.Instance.ClearAndStopMontage(this.PlayMontageHandle, null, 0f);
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0604406E RID: 278638 RVA: 0x011A43AC File Offset: 0x011A25AC
		protected override void OnReset()
		{
			if (this.PlayMontageHandle != 0)
			{
				Singleton<PlayMontageUtils>.Instance.ClearAndEndMontage(this.PlayMontageHandle, true, null);
			}
			this.EventParam = null;
			this.EntityHandle = null;
			this.PlayMontageHandle = 0;
		}

		// Token: 0x04026056 RID: 155734
		[Nullable(2)]
		private PlayWalkingOverlayMontage EventParam;

		// Token: 0x04026057 RID: 155735
		[Nullable(2)]
		private EntityHandle EntityHandle;

		// Token: 0x04026058 RID: 155736
		private int PlayMontageHandle;
	}
}
