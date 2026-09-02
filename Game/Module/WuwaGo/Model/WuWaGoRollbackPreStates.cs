using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model
{
	// Token: 0x02004AD7 RID: 19159
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoRollbackPreStates : IStaticVariableResetter
	{
		// Token: 0x06031F4C RID: 204620 RVA: 0x00C8217F File Offset: 0x00C8037F
		static WuWaGoRollbackPreStates()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(WuWaGoRollbackPreStates.CreateStaticDefaultValue), new Action(WuWaGoRollbackPreStates.ResetStaticDefaultValue));
		}

		// Token: 0x06031F4D RID: 204621 RVA: 0x00C8219E File Offset: 0x00C8039E
		public static void CreateStaticDefaultValue()
		{
			WuWaGoRollbackPreStates._activeInstance = null;
		}

		// Token: 0x06031F4E RID: 204622 RVA: 0x00C821A6 File Offset: 0x00C803A6
		public static void ResetStaticDefaultValue()
		{
			WuWaGoRollbackPreStates._activeInstance = null;
		}

		// Token: 0x06031F4F RID: 204623 RVA: 0x00C821AE File Offset: 0x00C803AE
		[NullableContext(2)]
		public static void Activate(WuWaGoRollbackPreStates instance)
		{
			WuWaGoRollbackPreStates._activeInstance = instance;
		}

		// Token: 0x06031F50 RID: 204624 RVA: 0x00C821B6 File Offset: 0x00C803B6
		public static void MarkDirty(WuWaGoBaseUnit unit)
		{
			WuWaGoRollbackPreStates activeInstance = WuWaGoRollbackPreStates._activeInstance;
			if (activeInstance == null)
			{
				return;
			}
			activeInstance.MarkDirtyInner(unit);
		}

		// Token: 0x06031F51 RID: 204625 RVA: 0x00C821C8 File Offset: 0x00C803C8
		public static bool IsSuppressed()
		{
			WuWaGoRollbackPreStates activeInstance = WuWaGoRollbackPreStates._activeInstance;
			return activeInstance != null && activeInstance.Suppressed;
		}

		// Token: 0x06031F52 RID: 204626 RVA: 0x00C821DA File Offset: 0x00C803DA
		public void RegisterCommitHandler(Action<Dictionary<int, IRollbackCapture>> handler)
		{
			this.CommitHandler = handler;
		}

		// Token: 0x06031F53 RID: 204627 RVA: 0x00C821E3 File Offset: 0x00C803E3
		public void Begin()
		{
			this.FlushPendingCommit();
			this.Captures.Clear();
			this.Active = true;
		}

		// Token: 0x06031F54 RID: 204628 RVA: 0x00C82200 File Offset: 0x00C80400
		public void FlushPendingCommit()
		{
			if (this.Captures.Count == 0)
			{
				return;
			}
			Action<Dictionary<int, IRollbackCapture>> commitHandler = this.CommitHandler;
			if (commitHandler == null)
			{
				return;
			}
			Dictionary<int, IRollbackCapture> obj = new Dictionary<int, IRollbackCapture>(this.Captures);
			this.Captures.Clear();
			commitHandler(obj);
		}

		// Token: 0x06031F55 RID: 204629 RVA: 0x00C82244 File Offset: 0x00C80444
		public void ResetCaptures()
		{
			this.Captures.Clear();
		}

		// Token: 0x06031F56 RID: 204630 RVA: 0x00C82251 File Offset: 0x00C80451
		public void Discard()
		{
			this.Active = false;
			this.Captures.Clear();
		}

		// Token: 0x06031F57 RID: 204631 RVA: 0x00C82268 File Offset: 0x00C80468
		public T WithSuppressed<[Nullable(2)] T>(Func<T> fn)
		{
			bool suppressed = this.Suppressed;
			this.Suppressed = true;
			T result;
			try
			{
				result = fn();
			}
			finally
			{
				this.Suppressed = suppressed;
			}
			return result;
		}

		// Token: 0x06031F58 RID: 204632 RVA: 0x00C822A8 File Offset: 0x00C804A8
		public void SetSuppressed(bool suppressed)
		{
			this.Suppressed = suppressed;
		}

		// Token: 0x06031F59 RID: 204633 RVA: 0x00C822B4 File Offset: 0x00C804B4
		private void MarkDirtyInner(WuWaGoBaseUnit unit)
		{
			if (!this.Active || this.Suppressed)
			{
				return;
			}
			if (this.Captures.ContainsKey(unit.Id))
			{
				return;
			}
			IRollbackCapture rollbackCapture = unit.CaptureRollback();
			if (rollbackCapture == null)
			{
				return;
			}
			this.Captures[unit.Id] = rollbackCapture;
		}

		// Token: 0x0401D3BB RID: 119739
		[Nullable(2)]
		private static WuWaGoRollbackPreStates _activeInstance;

		// Token: 0x0401D3BC RID: 119740
		private bool Active;

		// Token: 0x0401D3BD RID: 119741
		private bool Suppressed;

		// Token: 0x0401D3BE RID: 119742
		private readonly Dictionary<int, IRollbackCapture> Captures = new Dictionary<int, IRollbackCapture>();

		// Token: 0x0401D3BF RID: 119743
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<Dictionary<int, IRollbackCapture>> CommitHandler;
	}
}
