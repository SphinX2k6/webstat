using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Utils.LockingHandler
{
	// Token: 0x0200711C RID: 28956
	[NullableContext(1)]
	[Nullable(0)]
	public class UniqueLockingHandler<[Nullable(2)] TLockReason>
	{
		// Token: 0x06046258 RID: 287320 RVA: 0x0126C51D File Offset: 0x0126A71D
		public void Lock(TLockReason lockReason)
		{
			this.LockSet.Add(lockReason);
		}

		// Token: 0x06046259 RID: 287321 RVA: 0x0126C52C File Offset: 0x0126A72C
		public void Unlock(TLockReason lockReason)
		{
			if (!this.LockSet.Contains(lockReason))
			{
				return;
			}
			this.LockSet.Remove(lockReason);
		}

		// Token: 0x0604625A RID: 287322 RVA: 0x0126C54A File Offset: 0x0126A74A
		public bool IsLocked()
		{
			return this.LockSet.Count > 0;
		}

		// Token: 0x0604625B RID: 287323 RVA: 0x0126C55A File Offset: 0x0126A75A
		public bool IsUnlocked()
		{
			return this.LockSet.Count <= 0;
		}

		// Token: 0x0604625C RID: 287324 RVA: 0x0126C56D File Offset: 0x0126A76D
		public bool HasLock(TLockReason lockReason)
		{
			return this.LockSet.Contains(lockReason);
		}

		// Token: 0x0604625D RID: 287325 RVA: 0x0126C57B File Offset: 0x0126A77B
		public void Clear()
		{
			this.LockSet.Clear();
		}

		// Token: 0x04027564 RID: 161124
		private readonly HashSet<TLockReason> LockSet = new HashSet<TLockReason>();
	}
}
