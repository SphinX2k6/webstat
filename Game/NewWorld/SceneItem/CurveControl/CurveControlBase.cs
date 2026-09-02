using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.CurveControl
{
	// Token: 0x02004870 RID: 18544
	[NullableContext(1)]
	[Nullable(0)]
	public class CurveControlBase
	{
		// Token: 0x17008280 RID: 33408
		// (get) Token: 0x0603041B RID: 197659 RVA: 0x00BBD396 File Offset: 0x00BBB596
		public ECurveControlStage CurStage
		{
			get
			{
				return this.Stage;
			}
		}

		// Token: 0x0603041C RID: 197660 RVA: 0x00BBD39E File Offset: 0x00BBB59E
		public void SetAllTime(float startTime, float loopTime, float endTime)
		{
			this.StartTime = startTime;
			this.LoopTime = loopTime;
			this.EndTime = endTime;
		}

		// Token: 0x0603041D RID: 197661 RVA: 0x00BBD3B5 File Offset: 0x00BBB5B5
		public void Init(Entity entity, CurveControlComponent config)
		{
			this.Stage = ECurveControlStage.Start;
			this.CurTime = 0f;
			this.Entity = entity;
			this.OnInit(config);
		}

		// Token: 0x0603041E RID: 197662 RVA: 0x00BBD3D7 File Offset: 0x00BBB5D7
		public void Start()
		{
			this.Stage = ECurveControlStage.Start;
			this.CurTime = 0f;
			this.OnStart();
		}

		// Token: 0x0603041F RID: 197663 RVA: 0x00BBD3F4 File Offset: 0x00BBB5F4
		public unsafe void Stop(bool immediately = false)
		{
			if (immediately)
			{
				this.Stage = ECurveControlStage.Stopped;
				this.CurTime = this.StartTime + this.LoopTime + this.EndTime;
			}
			else
			{
				this.Stage = ECurveControlStage.End;
				this.CurTime = this.StartTime + this.LoopTime;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneItemCurveControl;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[CurveControlBase.Stop]";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Stage", this.Stage);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Time", this.CurTime);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06030420 RID: 197664 RVA: 0x00BBD4AC File Offset: 0x00BBB6AC
		public bool Tick(float delta)
		{
			if (!this.TickStage(delta))
			{
				return false;
			}
			switch (this.Stage)
			{
			case ECurveControlStage.Start:
				this.TickStartStage();
				break;
			case ECurveControlStage.Loop:
				this.TickLoopStage();
				break;
			case ECurveControlStage.End:
				this.TickEndStage();
				break;
			}
			return true;
		}

		// Token: 0x06030421 RID: 197665 RVA: 0x00BBD4FC File Offset: 0x00BBB6FC
		protected unsafe bool TickStage(float delta)
		{
			this.CurTime += delta;
			if (this.CurTime < this.StartTime)
			{
				this.Stage = ECurveControlStage.Start;
			}
			else if (this.CurTime > this.StartTime && this.CurTime < this.StartTime + this.LoopTime)
			{
				this.Stage = ECurveControlStage.Loop;
			}
			else
			{
				if (this.CurTime <= this.StartTime + this.LoopTime || this.CurTime >= this.StartTime + this.LoopTime + this.EndTime)
				{
					this.Stage = ECurveControlStage.Stopped;
					return false;
				}
				this.Stage = ECurveControlStage.End;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneItemCurveControl;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[CurveControlBase.TickStage]";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Stage", this.Stage);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Time", this.CurTime);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return true;
		}

		// Token: 0x06030422 RID: 197666 RVA: 0x00BBD608 File Offset: 0x00BBB808
		protected virtual void TickStartStage()
		{
		}

		// Token: 0x06030423 RID: 197667 RVA: 0x00BBD60A File Offset: 0x00BBB80A
		protected virtual void TickLoopStage()
		{
		}

		// Token: 0x06030424 RID: 197668 RVA: 0x00BBD60C File Offset: 0x00BBB80C
		protected virtual void TickEndStage()
		{
		}

		// Token: 0x06030425 RID: 197669 RVA: 0x00BBD60E File Offset: 0x00BBB80E
		protected virtual void OnInit(CurveControlComponent config)
		{
		}

		// Token: 0x06030426 RID: 197670 RVA: 0x00BBD610 File Offset: 0x00BBB810
		protected virtual void OnStart()
		{
		}

		// Token: 0x06030427 RID: 197671 RVA: 0x00BBD612 File Offset: 0x00BBB812
		public bool IsStop()
		{
			return this.Stage == ECurveControlStage.End || this.Stage == ECurveControlStage.Stopped;
		}

		// Token: 0x0401BB6B RID: 113515
		private ECurveControlStage Stage;

		// Token: 0x0401BB6C RID: 113516
		[Nullable(2)]
		protected Entity Entity;

		// Token: 0x0401BB6D RID: 113517
		protected float StartTime;

		// Token: 0x0401BB6E RID: 113518
		protected float LoopTime;

		// Token: 0x0401BB6F RID: 113519
		protected float EndTime;

		// Token: 0x0401BB70 RID: 113520
		protected float CurTime;
	}
}
