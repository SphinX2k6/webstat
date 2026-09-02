using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.World.StepSequence;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.DataLayerSwitch
{
	// Token: 0x02005DD4 RID: 24020
	internal class DataLayerTransitionAbortSignal : ISequenceAbortSignal
	{
		// Token: 0x170098D0 RID: 39120
		// (get) Token: 0x0603C795 RID: 247701 RVA: 0x00F5C0E6 File Offset: 0x00F5A2E6
		public bool Aborted
		{
			get
			{
				return this.AbortPromise.IsFulfilled;
			}
		}

		// Token: 0x170098D1 RID: 39121
		// (get) Token: 0x0603C796 RID: 247702 RVA: 0x00F5C0F3 File Offset: 0x00F5A2F3
		public UniTask<bool>? Promise
		{
			get
			{
				return new UniTask<bool>?(this.AbortPromise.Promise);
			}
		}

		// Token: 0x0603C797 RID: 247703 RVA: 0x00F5C105 File Offset: 0x00F5A305
		public void Abort()
		{
			this.AbortPromise.SetResult(true);
		}

		// Token: 0x0402200D RID: 139277
		[Nullable(1)]
		private readonly CustomPromise<bool> AbortPromise = new CustomPromise<bool>();
	}
}
