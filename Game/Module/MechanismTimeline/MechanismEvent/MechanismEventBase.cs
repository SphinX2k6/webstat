using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.Module.MechanismTimeline.MechanismEvent
{
	// Token: 0x020057E1 RID: 22497
	[NullableContext(1)]
	[Nullable(0)]
	public class MechanismEventBase
	{
		// Token: 0x06039297 RID: 234135 RVA: 0x00E7DCFA File Offset: 0x00E7BEFA
		public MechanismEventBase(IMechanismEventInfo eventInfo, MechanismEventContext context, SceneItemEventListenerComponent eventListenerComponent, bool isServerAction)
		{
		}

		// Token: 0x170091C4 RID: 37316
		// (get) Token: 0x06039298 RID: 234136 RVA: 0x00E7DD1F File Offset: 0x00E7BF1F
		public string Type
		{
			get
			{
				return this.EventInfo.Info.Action.Name.ToEnumString();
			}
		}

		// Token: 0x170091C5 RID: 37317
		// (get) Token: 0x06039299 RID: 234137 RVA: 0x00E7DD3B File Offset: 0x00E7BF3B
		public string SeqGuid
		{
			get
			{
				return this.EventInfo.SeqGuid;
			}
		}

		// Token: 0x170091C6 RID: 37318
		// (get) Token: 0x0603929A RID: 234138 RVA: 0x00E7DD48 File Offset: 0x00E7BF48
		public string EventName
		{
			get
			{
				return this.EventInfo.Info.EventName;
			}
		}

		// Token: 0x170091C7 RID: 37319
		// (get) Token: 0x0603929B RID: 234139 RVA: 0x00E7DD5A File Offset: 0x00E7BF5A
		public int PlayerId
		{
			get
			{
				return this.EventListenerComponent.GetPlayerId();
			}
		}

		// Token: 0x170091C8 RID: 37320
		// (get) Token: 0x0603929C RID: 234140 RVA: 0x00E7DD67 File Offset: 0x00E7BF67
		public long CreatureDataId
		{
			get
			{
				return this.EventListenerComponent.GetCreatureDataId();
			}
		}

		// Token: 0x0603929D RID: 234141 RVA: 0x00E7DD74 File Offset: 0x00E7BF74
		public void Dispose()
		{
			this.OnDispose();
		}

		// Token: 0x0603929E RID: 234142 RVA: 0x00E7DD7C File Offset: 0x00E7BF7C
		public void Trigger()
		{
			this.OnTrigger(this.EventInfo.Info.Action.Params);
			if (this.IsServerAction)
			{
				ControllerBase<MechanismTimelineController>.Instance.RequestSceneItemSequenceFrameStart(this.PlayerId, this.CreatureDataId, this.SeqGuid, this.EventName);
			}
		}

		// Token: 0x0603929F RID: 234143 RVA: 0x00E7DDD0 File Offset: 0x00E7BFD0
		public void Start()
		{
			this.OnStart(this.EventInfo.Info.Action.Params);
			if (this.IsServerAction)
			{
				ControllerBase<MechanismTimelineController>.Instance.RequestSceneItemSequenceFrameStart(this.PlayerId, this.CreatureDataId, this.SeqGuid, this.EventName);
			}
		}

		// Token: 0x060392A0 RID: 234144 RVA: 0x00E7DE22 File Offset: 0x00E7C022
		public void Tick()
		{
			this.OnTick();
		}

		// Token: 0x060392A1 RID: 234145 RVA: 0x00E7DE2C File Offset: 0x00E7C02C
		public void End()
		{
			this.OnEnd(this.EventInfo.Info.Action.Params);
			if (this.IsServerAction)
			{
				ControllerBase<MechanismTimelineController>.Instance.RequestSceneItemSequenceFrameEnd(this.PlayerId, this.CreatureDataId, this.SeqGuid, this.EventName);
			}
		}

		// Token: 0x060392A2 RID: 234146 RVA: 0x00E7DE7E File Offset: 0x00E7C07E
		protected virtual void OnTrigger(ActionParams @params)
		{
		}

		// Token: 0x060392A3 RID: 234147 RVA: 0x00E7DE80 File Offset: 0x00E7C080
		protected virtual void OnStart(ActionParams @params)
		{
		}

		// Token: 0x060392A4 RID: 234148 RVA: 0x00E7DE82 File Offset: 0x00E7C082
		protected virtual void OnTick()
		{
		}

		// Token: 0x060392A5 RID: 234149 RVA: 0x00E7DE84 File Offset: 0x00E7C084
		protected virtual void OnEnd(ActionParams @params)
		{
		}

		// Token: 0x060392A6 RID: 234150 RVA: 0x00E7DE86 File Offset: 0x00E7C086
		protected virtual void OnDispose()
		{
		}

		// Token: 0x04020871 RID: 133233
		public readonly IMechanismEventInfo EventInfo = eventInfo;

		// Token: 0x04020872 RID: 133234
		public readonly MechanismEventContext Context = context;

		// Token: 0x04020873 RID: 133235
		public readonly SceneItemEventListenerComponent EventListenerComponent = eventListenerComponent;

		// Token: 0x04020874 RID: 133236
		public readonly bool IsServerAction = isServerAction;
	}
}
