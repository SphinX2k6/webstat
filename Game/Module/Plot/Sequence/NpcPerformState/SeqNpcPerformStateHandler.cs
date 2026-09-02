using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.Sequence.NpcPerformState
{
	// Token: 0x0200539E RID: 21406
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class SeqNpcPerformStateHandler
	{
		// Token: 0x17008DAF RID: 36271
		// (get) Token: 0x06036958 RID: 223576
		public abstract ENpcGroupPerformType PerformType { get; }

		// Token: 0x17008DB0 RID: 36272
		// (get) Token: 0x06036959 RID: 223577
		public abstract ENpcRelationType RelationType { get; }

		// Token: 0x0603695A RID: 223578
		[return: Nullable(2)]
		public abstract NpcRelation Capture(string key);

		// Token: 0x0603695B RID: 223579
		public abstract void Restore(NpcRelation relation, string reason);

		// Token: 0x0603695C RID: 223580 RVA: 0x00DCCCD8 File Offset: 0x00DCAED8
		public virtual void OnBattleCharacterHidden(NpcRelation relation, string reason)
		{
		}
	}
}
