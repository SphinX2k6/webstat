using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Condition
{
	// Token: 0x02006F80 RID: 28544
	public class LevelFlowConditionBase
	{
		// Token: 0x0604513E RID: 282942 RVA: 0x0120358D File Offset: 0x0120178D
		public void Enter()
		{
			this.IsFinished = false;
			this.OnEnter();
		}

		// Token: 0x0604513F RID: 282943 RVA: 0x0120359C File Offset: 0x0120179C
		public void Exit()
		{
			this.OnExit();
			this.IsFinished = true;
		}

		// Token: 0x06045140 RID: 282944 RVA: 0x012035AB File Offset: 0x012017AB
		public void Tick(float delta)
		{
			if (this.IsFinished)
			{
				return;
			}
			this.OnTick(delta);
		}

		// Token: 0x06045141 RID: 282945 RVA: 0x012035BD File Offset: 0x012017BD
		public void Reset()
		{
			this.IsFinished = false;
			this.OnReset();
		}

		// Token: 0x06045142 RID: 282946 RVA: 0x012035CC File Offset: 0x012017CC
		protected void FinishExecute(bool isSuccess)
		{
			this.Exit();
			this.CompleteCallBack(isSuccess);
		}

		// Token: 0x06045143 RID: 282947 RVA: 0x012035E0 File Offset: 0x012017E0
		[NullableContext(1)]
		public void BindCompleteCallBack(Action<bool> completeCallBack)
		{
			this.CompleteCallBack = completeCallBack;
		}

		// Token: 0x06045144 RID: 282948 RVA: 0x012035E9 File Offset: 0x012017E9
		protected virtual void OnEnter()
		{
		}

		// Token: 0x06045145 RID: 282949 RVA: 0x012035EB File Offset: 0x012017EB
		protected virtual void OnTick(float delta)
		{
		}

		// Token: 0x06045146 RID: 282950 RVA: 0x012035ED File Offset: 0x012017ED
		protected virtual void OnExit()
		{
		}

		// Token: 0x06045147 RID: 282951 RVA: 0x012035EF File Offset: 0x012017EF
		protected virtual void OnReset()
		{
		}

		// Token: 0x040268C0 RID: 157888
		private bool IsFinished;

		// Token: 0x040268C1 RID: 157889
		[Nullable(2)]
		private Action<bool> CompleteCallBack;
	}
}
