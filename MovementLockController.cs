using System;
using System.Runtime.CompilerServices;

// Token: 0x02002328 RID: 9000
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MovementLockController : ControllerBase<MovementLockController>
{
	// Token: 0x060111ED RID: 70125 RVA: 0x004B4212 File Offset: 0x004B2412
	protected override bool OnLeaveLevel()
	{
		if (this.LockMode != EMovementLockMode.None)
		{
			this.Unlock();
		}
		return true;
	}

	// Token: 0x060111EE RID: 70126 RVA: 0x004B4223 File Offset: 0x004B2423
	public void Lock(EMovementLockMode lockMode)
	{
		if (this.LockMode != EMovementLockMode.None)
		{
			this.Unlock();
		}
		if (lockMode == EMovementLockMode.All)
		{
			UeMovementTickController.SetTickManageMode(EMovementManageMode.None);
		}
		else if (lockMode == EMovementLockMode.StreamingSource)
		{
			UeMovementTickController.SetTickManageMode(EMovementManageMode.TickWithDistance);
			ControllerBase<GameBudgetController>.Instance.OpenStreamingSourceMode();
		}
		this.LockMode = lockMode;
	}

	// Token: 0x060111EF RID: 70127 RVA: 0x004B425A File Offset: 0x004B245A
	public void Unlock()
	{
		if (this.LockMode == EMovementLockMode.None)
		{
			return;
		}
		if (this.LockMode == EMovementLockMode.StreamingSource)
		{
			ControllerBase<GameBudgetController>.Instance.CloseStreamingSourceMode();
		}
		UeMovementTickController.SetTickManageMode(EMovementManageMode.Default);
		this.LockMode = EMovementLockMode.None;
	}

	// Token: 0x0400869A RID: 34458
	public EMovementLockMode LockMode;
}
