using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056DE RID: 22238
	public abstract class MusicalInstrumentSubController
	{
		// Token: 0x0603897A RID: 231802
		public new abstract EInstrumentType GetType();

		// Token: 0x0603897B RID: 231803
		public abstract UniTask<bool> OnEnter([Nullable(1)] MusicalInstrumentEnterParam param);

		// Token: 0x0603897C RID: 231804
		public abstract UniTask<bool> OnExit([Nullable(1)] MusicalInstrumentExitParam param);

		// Token: 0x0603897D RID: 231805 RVA: 0x00E560BB File Offset: 0x00E542BB
		public virtual void CancelEnter()
		{
		}

		// Token: 0x0603897E RID: 231806 RVA: 0x00E560BD File Offset: 0x00E542BD
		[NullableContext(2)]
		protected MusicalInstrumentSubModel GetSubModel()
		{
			return ModelBase<MusicalInstrumentModel>.Instance.GetSubModel(this.GetType());
		}

		// Token: 0x0603897F RID: 231807 RVA: 0x00E560CF File Offset: 0x00E542CF
		public virtual void OnQteCompleted()
		{
		}
	}
}
