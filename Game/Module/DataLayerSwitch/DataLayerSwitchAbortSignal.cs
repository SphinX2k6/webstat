using System;
using CSharpScript.Game.World.StepSequence;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.DataLayerSwitch
{
	// Token: 0x02005DD1 RID: 24017
	public class DataLayerSwitchAbortSignal : ISequenceAbortSignal
	{
		// Token: 0x170098C7 RID: 39111
		// (get) Token: 0x0603C759 RID: 247641 RVA: 0x00F5ADE1 File Offset: 0x00F58FE1
		public bool Aborted
		{
			get
			{
				GameModeModel instance = ModelBase<GameModeModel>.Instance;
				return instance != null && instance.SwitchDataLayerContext.DataLayerSwitchAborted;
			}
		}

		// Token: 0x170098C8 RID: 39112
		// (get) Token: 0x0603C75A RID: 247642 RVA: 0x00F5ADF8 File Offset: 0x00F58FF8
		public UniTask<bool>? Promise
		{
			get
			{
				GameModeModel instance = ModelBase<GameModeModel>.Instance;
				if (instance == null)
				{
					return null;
				}
				CustomPromise<bool> dataLayerSwitchAbortPromise = instance.SwitchDataLayerContext.DataLayerSwitchAbortPromise;
				if (dataLayerSwitchAbortPromise == null)
				{
					return null;
				}
				return new UniTask<bool>?(dataLayerSwitchAbortPromise.Promise);
			}
		}

		// Token: 0x0603C75B RID: 247643 RVA: 0x00F5AE3C File Offset: 0x00F5903C
		public void Abort()
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.ZYL, "DataLayerSwitchAbortSignal:Abort", default(ReadOnlySpan<ValueTuple<string, object>>));
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SwitchDataLayerContext.AbortDataLayerSwitch();
		}
	}
}
