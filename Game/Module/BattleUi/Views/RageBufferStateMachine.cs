using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006035 RID: 24629
	public class RageBufferStateMachine
	{
		// Token: 0x0603E20F RID: 254479 RVA: 0x00FDB6C0 File Offset: 0x00FD98C0
		public RageBufferStateMachine()
		{
			this.ConfigHitDelayTimes = ConfigCommonParamById.GetIntConfig("HitDelayTime").Value;
			this.HitRefreshTimes = ConfigCommonParamById.GetIntConfig("HitRefreshTime").Value;
			this.HitBufferDisappearTime = ConfigCommonParamById.GetIntConfig("HitBufferDisappearTime").Value;
			this.HitLargePercent = (float)ConfigCommonParamById.GetIntConfig("HitLargePercent").Value / 10000f;
			this.CurrentTime = (float)this.HitBufferDisappearTime;
		}

		// Token: 0x0603E210 RID: 254480 RVA: 0x00FDB747 File Offset: 0x00FD9947
		[NullableContext(1)]
		public void SetUpdateCallback(RageBufferStateMachine.OnUpdateLittleReduce updateLittleReduce, RageBufferStateMachine.OnUpdateLargeReduce updateLargeReduce, Action notifyEmpty)
		{
			this.UpdateLittleReduce = updateLittleReduce;
			this.UpdateLargeReduce = updateLargeReduce;
			this.NotifyEmpty = notifyEmpty;
		}

		// Token: 0x0603E211 RID: 254481 RVA: 0x00FDB760 File Offset: 0x00FD9960
		public void Update(float delta)
		{
			if (this.CurrentEmptyState == RageBufferStateMachine.EState.Animation)
			{
				this.CurrentEmptyState = RageBufferStateMachine.EState.Origin;
				Action notifyEmpty = this.NotifyEmpty;
				if (notifyEmpty != null)
				{
					notifyEmpty();
				}
			}
			if (this.CurrentLittleState == RageBufferStateMachine.EState.Animation)
			{
				float num = (this.CurrentPercent - this.TargetPercent) / this.CurrentTime;
				this.CurrentPercent -= delta * num;
				this.CurrentTime -= delta;
				if (this.CurrentTime <= 0f)
				{
					this.CurrentLittleState = RageBufferStateMachine.EState.Origin;
					this.CurrentPercent = this.TargetPercent;
				}
				RageBufferStateMachine.OnUpdateLittleReduce updateLittleReduce = this.UpdateLittleReduce;
				if (updateLittleReduce != null)
				{
					updateLittleReduce(this.CurrentPercent, this.TargetPercent, this.IsNewLittleHit);
				}
			}
			else if (this.CurrentLittleState == RageBufferStateMachine.EState.Hit)
			{
				this.BufferCountDown += delta;
				if (this.BufferCountDown > (float)this.ConfigHitDelayTimes)
				{
					this.CurrentLittleState = RageBufferStateMachine.EState.Animation;
				}
				RageBufferStateMachine.OnUpdateLittleReduce updateLittleReduce2 = this.UpdateLittleReduce;
				if (updateLittleReduce2 != null)
				{
					updateLittleReduce2(this.CurrentPercent, this.TargetPercent, this.IsNewLittleHit);
				}
			}
			this.IsNewLittleHit = false;
			if (this.CurrentLargeState == RageBufferStateMachine.EState.Animation)
			{
				this.CurrentLargeTime -= delta;
				if (this.CurrentLargeTime <= 0f)
				{
					this.CurrentLargeState = RageBufferStateMachine.EState.Origin;
					this.CurrentLargePercent = this.TargetLargePercent;
					RageBufferStateMachine.OnUpdateLargeReduce updateLargeReduce = this.UpdateLargeReduce;
					if (updateLargeReduce == null)
					{
						return;
					}
					updateLargeReduce(this.CurrentLargePercent, this.TargetLargePercent);
					return;
				}
			}
			else if (this.CurrentLargeState == RageBufferStateMachine.EState.Hit)
			{
				this.CurrentLargeState = RageBufferStateMachine.EState.Animation;
				this.CurrentLargeTime = 1000f;
				RageBufferStateMachine.OnUpdateLargeReduce updateLargeReduce2 = this.UpdateLargeReduce;
				if (updateLargeReduce2 == null)
				{
					return;
				}
				updateLargeReduce2(this.CurrentLargePercent, this.TargetLargePercent);
			}
		}

		// Token: 0x0603E212 RID: 254482 RVA: 0x00FDB8F4 File Offset: 0x00FD9AF4
		public void GetHit(float curPercent, float oldPercent)
		{
			if (oldPercent < curPercent)
			{
				return;
			}
			if (oldPercent > 0f && curPercent <= 0f)
			{
				this.CurrentEmptyState = RageBufferStateMachine.EState.Animation;
			}
			if (oldPercent - curPercent >= this.HitLargePercent)
			{
				this.CurrentLargeState = RageBufferStateMachine.EState.Hit;
				if (this.CurrentLittleState == RageBufferStateMachine.EState.Hit || this.CurrentLittleState == RageBufferStateMachine.EState.Animation)
				{
					this.CurrentLittleState = RageBufferStateMachine.EState.Animation;
					this.CurrentTime = 0f;
					this.CurrentPercent = curPercent;
					this.TargetPercent = curPercent;
				}
				this.CurrentLargePercent = oldPercent;
				this.TargetLargePercent = curPercent;
				return;
			}
			if (this.CurrentLittleState == RageBufferStateMachine.EState.Origin)
			{
				this.CurrentLittleState = RageBufferStateMachine.EState.Hit;
				this.HitTimes = 1;
				this.BufferCountDown = 0f;
				this.CurrentPercent = oldPercent;
				this.TargetPercent = curPercent;
				this.CurrentTime = (float)this.HitBufferDisappearTime;
			}
			else if (this.CurrentLittleState == RageBufferStateMachine.EState.Hit)
			{
				this.HitTimes++;
				if (this.HitTimes > this.HitRefreshTimes)
				{
					this.CurrentLittleState = RageBufferStateMachine.EState.Animation;
				}
				this.BufferCountDown = 0f;
				this.TargetPercent = curPercent;
			}
			else if (this.CurrentLittleState == RageBufferStateMachine.EState.Animation)
			{
				this.TargetPercent = curPercent;
			}
			this.IsNewLittleHit = true;
		}

		// Token: 0x0603E213 RID: 254483 RVA: 0x00FDBA0A File Offset: 0x00FD9C0A
		public void Reset()
		{
			this.CurrentLittleState = RageBufferStateMachine.EState.Origin;
			this.CurrentLargeState = RageBufferStateMachine.EState.Origin;
			this.CurrentEmptyState = RageBufferStateMachine.EState.Origin;
		}

		// Token: 0x04022D36 RID: 142646
		private const float LARGE_TIME = 1000f;

		// Token: 0x04022D37 RID: 142647
		private RageBufferStateMachine.EState CurrentLittleState;

		// Token: 0x04022D38 RID: 142648
		private RageBufferStateMachine.EState CurrentLargeState;

		// Token: 0x04022D39 RID: 142649
		private RageBufferStateMachine.EState CurrentEmptyState;

		// Token: 0x04022D3A RID: 142650
		private float BufferCountDown;

		// Token: 0x04022D3B RID: 142651
		private int HitTimes;

		// Token: 0x04022D3C RID: 142652
		public float TargetPercent;

		// Token: 0x04022D3D RID: 142653
		public float CurrentPercent;

		// Token: 0x04022D3E RID: 142654
		private float CurrentTime;

		// Token: 0x04022D3F RID: 142655
		private float TargetLargePercent;

		// Token: 0x04022D40 RID: 142656
		private float CurrentLargePercent;

		// Token: 0x04022D41 RID: 142657
		private float CurrentLargeTime;

		// Token: 0x04022D42 RID: 142658
		private bool IsNewLittleHit;

		// Token: 0x04022D43 RID: 142659
		private readonly int ConfigHitDelayTimes;

		// Token: 0x04022D44 RID: 142660
		private readonly int HitRefreshTimes;

		// Token: 0x04022D45 RID: 142661
		private readonly int HitBufferDisappearTime;

		// Token: 0x04022D46 RID: 142662
		private readonly float HitLargePercent;

		// Token: 0x04022D47 RID: 142663
		[Nullable(2)]
		private RageBufferStateMachine.OnUpdateLittleReduce UpdateLittleReduce;

		// Token: 0x04022D48 RID: 142664
		[Nullable(2)]
		private RageBufferStateMachine.OnUpdateLargeReduce UpdateLargeReduce;

		// Token: 0x04022D49 RID: 142665
		[Nullable(2)]
		private Action NotifyEmpty;

		// Token: 0x0200C0E9 RID: 49385
		// (Invoke) Token: 0x0604E44F RID: 320591
		public delegate void OnUpdateLittleReduce(float curPercent, float targetPercent, bool isNewHit);

		// Token: 0x0200C0EA RID: 49386
		// (Invoke) Token: 0x0604E453 RID: 320595
		public delegate void OnUpdateLargeReduce(float curPercent, float targetPercent);

		// Token: 0x0200C0EB RID: 49387
		private enum EState
		{
			// Token: 0x0403B696 RID: 243350
			Origin,
			// Token: 0x0403B697 RID: 243351
			Hit,
			// Token: 0x0403B698 RID: 243352
			Animation
		}
	}
}
