using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004776 RID: 18294
	[NullableContext(2)]
	[Nullable(0)]
	public class EffectLifeTimeController
	{
		// Token: 0x170081A4 RID: 33188
		// (get) Token: 0x0602F741 RID: 194369 RVA: 0x00B47983 File Offset: 0x00B45B83
		public float LifeTime
		{
			get
			{
				return this.LifeTimeStamp;
			}
		}

		// Token: 0x170081A5 RID: 33189
		// (get) Token: 0x0602F742 RID: 194370 RVA: 0x00B4798B File Offset: 0x00B45B8B
		public float PassTime
		{
			get
			{
				return this.PassTimeInternal;
			}
		}

		// Token: 0x170081A6 RID: 33190
		// (get) Token: 0x0602F743 RID: 194371 RVA: 0x00B47993 File Offset: 0x00B45B93
		public float TotalPassTime
		{
			get
			{
				return this.TotalPassTimeInternal;
			}
		}

		// Token: 0x170081A7 RID: 33191
		// (get) Token: 0x0602F744 RID: 194372 RVA: 0x00B4799B File Offset: 0x00B45B9B
		public EControllerState State
		{
			get
			{
				return this.StateInternal;
			}
		}

		// Token: 0x170081A8 RID: 33192
		// (get) Token: 0x0602F745 RID: 194373 RVA: 0x00B479A3 File Offset: 0x00B45BA3
		public bool IsFinish
		{
			get
			{
				return this.StateInternal == EControllerState.Finished;
			}
		}

		// Token: 0x170081A9 RID: 33193
		// (get) Token: 0x0602F746 RID: 194374 RVA: 0x00B479AE File Offset: 0x00B45BAE
		public EEffectLifeTimeType Type
		{
			get
			{
				return this.TypeInternal;
			}
		}

		// Token: 0x0602F747 RID: 194375 RVA: 0x00B479B6 File Offset: 0x00B45BB6
		public void SetPassTimeManual(float target, float? speed = null)
		{
			this.ManualTarget = target;
			if (speed != null)
			{
				this.ManualSpeed = speed.Value;
			}
		}

		// Token: 0x0602F748 RID: 194376 RVA: 0x00B479D8 File Offset: 0x00B45BD8
		public EffectLifeTimeController(float startTime, float loopTime, float endTime, EEffectLifeTimeType type, Action finishCallback = null, Func<bool> readyToFinish = null, float defaultManualTime = 0f, float defaultManualSpeed = 1f)
		{
			this.StateInternal = EControllerState.Constructor;
			if (type == EEffectLifeTimeType.Manual)
			{
				this.DefaultPassTime = defaultManualTime;
			}
			this.PassTimeInternal = 0f;
			this.TotalPassTimeInternal = 0f;
			this.TypeInternal = type;
			this.ReadyToFinish = readyToFinish;
			this.FinishCallback = finishCallback;
			this.ManualTarget = defaultManualTime;
			this.ManualSpeed = defaultManualSpeed;
			this.ReInit(startTime, loopTime, endTime);
		}

		// Token: 0x0602F749 RID: 194377 RVA: 0x00B47A51 File Offset: 0x00B45C51
		public void Reset()
		{
			this.PassTimeInternal = this.DefaultPassTime;
			this.TotalPassTimeInternal = 0f;
		}

		// Token: 0x0602F74A RID: 194378 RVA: 0x00B47A6A File Offset: 0x00B45C6A
		public void JumpToEnd()
		{
			this.PassTimeInternal = this.LifeTimeStamp;
			this.TotalPassTimeInternal = this.LifeTimeStamp;
		}

		// Token: 0x0602F74B RID: 194379 RVA: 0x00B47A84 File Offset: 0x00B45C84
		public void ReInit(float startTime, float loopTime, float endTime)
		{
			this.StartTimeInternal = startTime;
			this.LoopTimeInternal = loopTime;
			this.EndTimeInternal = endTime;
			this.LoopTimeStamp = startTime + loopTime;
			this.LifeTimeStamp = startTime + loopTime + endTime;
			this.CalcLoopBehavior();
		}

		// Token: 0x0602F74C RID: 194380 RVA: 0x00B47AB5 File Offset: 0x00B45CB5
		public void SetType(EEffectLifeTimeType type)
		{
			this.TypeInternal = type;
			this.CalcLoopBehavior();
		}

		// Token: 0x0602F74D RID: 194381 RVA: 0x00B47AC4 File Offset: 0x00B45CC4
		public bool LifeTimeCheck(float deltaSecond)
		{
			return false;
		}

		// Token: 0x0602F74E RID: 194382 RVA: 0x00B47AC8 File Offset: 0x00B45CC8
		public void CalcLoopBehavior()
		{
			this.WillLoop = (this.TypeInternal == EEffectLifeTimeType.AlwaysLoop || (this.TypeInternal == EEffectLifeTimeType.Auto && this.LoopTimeInternal > 0f));
			this.WillEverPlay = (this.WillLoop || (this.TypeInternal == EEffectLifeTimeType.Auto && this.LifeTimeStamp <= 0f) || this.TypeInternal == EEffectLifeTimeType.Manual);
		}

		// Token: 0x0602F74F RID: 194383 RVA: 0x00B47B2E File Offset: 0x00B45D2E
		public void SetStateBuild()
		{
			this.StateInternal = EControllerState.Build;
		}

		// Token: 0x0602F750 RID: 194384 RVA: 0x00B47B37 File Offset: 0x00B45D37
		public void SetStateInit()
		{
			this.StateInternal = EControllerState.Init;
		}

		// Token: 0x0602F751 RID: 194385 RVA: 0x00B47B40 File Offset: 0x00B45D40
		public void Play()
		{
			if (this.StateInternal < EControllerState.Constructor)
			{
				return;
			}
			this.StateInternal = EControllerState.Playing;
			this.PassTimeInternal = this.DefaultPassTime;
			this.TotalPassTimeInternal = 0f;
		}

		// Token: 0x0602F752 RID: 194386 RVA: 0x00B47B6C File Offset: 0x00B45D6C
		public void Update(float deltaSecond)
		{
			this.TotalPassTimeInternal += deltaSecond;
			if (this.TypeInternal != EEffectLifeTimeType.Manual)
			{
				this.SeekTo(this.PassTimeInternal + deltaSecond, true);
				return;
			}
			if (this.StateInternal == EControllerState.Stopping)
			{
				this.PrepareFinish();
				return;
			}
			float num = Math.Min(deltaSecond * this.ManualSpeed, Math.Abs(this.ManualTarget - this.PassTimeInternal));
			this.SeekTo(this.PassTimeInternal + num * (float)Math.Sign(this.ManualTarget - this.PassTimeInternal), false);
		}

		// Token: 0x0602F753 RID: 194387 RVA: 0x00B47BF4 File Offset: 0x00B45DF4
		public void SeekTo(float time, bool triggerFinish = false)
		{
			this.PassTimeInternal = time;
			if (this.StateInternal == EControllerState.Playing && this.PassTimeInternal >= this.LoopTimeStamp && this.WillLoop)
			{
				this.MakeLoop();
			}
			if (triggerFinish && (!this.WillEverPlay || this.StateInternal >= EControllerState.Stopping) && this.PassTimeInternal >= this.LifeTimeStamp)
			{
				this.PrepareFinish();
			}
		}

		// Token: 0x0602F754 RID: 194388 RVA: 0x00B47C60 File Offset: 0x00B45E60
		private void MakeLoop()
		{
			if (this.LoopTimeInternal <= 0.01f)
			{
				this.PassTimeInternal = this.StartTimeInternal;
				return;
			}
			if (this.PassTimeInternal >= this.LoopTimeStamp + this.LoopTimeInternal)
			{
				float num = (this.PassTimeInternal - this.StartTimeInternal) % this.LoopTimeInternal;
				this.PassTimeInternal = this.StartTimeInternal + num;
				return;
			}
			this.PassTimeInternal -= this.LoopTimeInternal;
		}

		// Token: 0x0602F755 RID: 194389 RVA: 0x00B47CD3 File Offset: 0x00B45ED3
		public void Stop(bool immediately = false)
		{
			if (this.StateInternal >= EControllerState.Stopping)
			{
				return;
			}
			this.StateInternal = EControllerState.Stopping;
			if (immediately)
			{
				this.PassTimeInternal = this.LoopTimeStamp;
			}
		}

		// Token: 0x0602F756 RID: 194390 RVA: 0x00B47CF5 File Offset: 0x00B45EF5
		protected void PrepareFinish()
		{
			if (this.ReadyToFinish != null && !this.ReadyToFinish())
			{
				return;
			}
			this.StateInternal = EControllerState.Finished;
			Action finishCallback = this.FinishCallback;
			if (finishCallback == null)
			{
				return;
			}
			finishCallback();
		}

		// Token: 0x0602F757 RID: 194391 RVA: 0x00B47D24 File Offset: 0x00B45F24
		public void SetStateFinish()
		{
			this.StateInternal = EControllerState.Finished;
		}

		// Token: 0x0401B1BB RID: 111035
		protected EEffectLifeTimeType TypeInternal;

		// Token: 0x0401B1BC RID: 111036
		protected float DefaultPassTime;

		// Token: 0x0401B1BD RID: 111037
		protected float PassTimeInternal;

		// Token: 0x0401B1BE RID: 111038
		protected float TotalPassTimeInternal;

		// Token: 0x0401B1BF RID: 111039
		protected float StartTimeInternal = -1f;

		// Token: 0x0401B1C0 RID: 111040
		protected float LoopTimeInternal;

		// Token: 0x0401B1C1 RID: 111041
		protected float EndTimeInternal;

		// Token: 0x0401B1C2 RID: 111042
		protected float LoopTimeStamp;

		// Token: 0x0401B1C3 RID: 111043
		protected float LifeTimeStamp;

		// Token: 0x0401B1C4 RID: 111044
		protected EControllerState StateInternal;

		// Token: 0x0401B1C5 RID: 111045
		protected Func<bool> ReadyToFinish;

		// Token: 0x0401B1C6 RID: 111046
		protected Action FinishCallback;

		// Token: 0x0401B1C7 RID: 111047
		protected float ManualTarget;

		// Token: 0x0401B1C8 RID: 111048
		protected float ManualSpeed;

		// Token: 0x0401B1C9 RID: 111049
		public bool WillLoop;

		// Token: 0x0401B1CA RID: 111050
		public bool WillEverPlay;
	}
}
