using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C11 RID: 27665
	public class LevelEventStopUiScreenEffect : LevelEventBase
	{
		// Token: 0x0604417D RID: 278909 RVA: 0x011AE43D File Offset: 0x011AC63D
		public LevelEventStopUiScreenEffect(int id) : base(id)
		{
		}

		// Token: 0x0604417E RID: 278910 RVA: 0x011AE448 File Offset: 0x011AC648
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			StopUiScreenEffect stopUiScreenEffect = inParams as StopUiScreenEffect;
			if (!Singleton<ResourceSystem>.Instance.CheckAssetLoaded<EffectScreenPlayData_C>(stopUiScreenEffect.EffectDaPath))
			{
				base.FinishExecute(true, false, true);
				return;
			}
			ScreenEffectModel instance = ModelBase<ScreenEffectModel>.Instance;
			if (instance != null)
			{
				instance.EndScreenEffectByPath(stopUiScreenEffect.EffectDaPath);
			}
			if (this.IsAsync)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			EffectScreenPlayData_C loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<EffectScreenPlayData_C>(stopUiScreenEffect.EffectDaPath);
			if (loadedAsset == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventStopUiScreenEffect] 特效资源未加载, 无法获取End时间", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(true, false, true);
				return;
			}
			float num = loadedAsset.End * 1000f;
			if (num < 20f)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				base.FinishExecute(true, false, true);
			}, num, null, null, true, 1f);
		}
	}
}
