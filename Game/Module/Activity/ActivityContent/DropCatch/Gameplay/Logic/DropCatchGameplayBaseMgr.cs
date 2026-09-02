using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200691D RID: 26909
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayBaseMgr
	{
		// Token: 0x06042D28 RID: 273704 RVA: 0x01126CD7 File Offset: 0x01124ED7
		public DropCatchGameplayBaseMgr(IGameplayLogicContext context)
		{
			this.Context = context;
		}

		// Token: 0x06042D29 RID: 273705 RVA: 0x01126CE6 File Offset: 0x01124EE6
		public virtual void Init()
		{
		}

		// Token: 0x06042D2A RID: 273706 RVA: 0x01126CE8 File Offset: 0x01124EE8
		public virtual UniTask InitAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06042D2B RID: 273707 RVA: 0x01126CEF File Offset: 0x01124EEF
		public virtual void OnReadyTick(float deltaTime)
		{
		}

		// Token: 0x06042D2C RID: 273708 RVA: 0x01126CF1 File Offset: 0x01124EF1
		public virtual void OnTick(float deltaTime)
		{
		}

		// Token: 0x06042D2D RID: 273709 RVA: 0x01126CF3 File Offset: 0x01124EF3
		public virtual void Destroy()
		{
		}

		// Token: 0x040253DB RID: 152539
		protected IGameplayLogicContext Context;
	}
}
