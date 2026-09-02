using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E61 RID: 28257
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GuaranteeActionCenter : Singleton<GuaranteeActionCenter>
	{
		// Token: 0x0604494F RID: 280911 RVA: 0x011D43D0 File Offset: 0x011D25D0
		public void RegGuaranteeActions()
		{
			<>f__AnonymousDelegate0<EGuaranteeAction, Func<GuaranteeActionBase>, EActionFilterMode> <>f__AnonymousDelegate = new <>f__AnonymousDelegate0<EGuaranteeAction, Func<GuaranteeActionBase>, EActionFilterMode>(this.SetupGuaranteeAction);
			<>f__AnonymousDelegate(EGuaranteeAction.RestorePlayerCameraAdjustment, () => new GuaranteeActionRestorePlayerCameraAdjustment(), EActionFilterMode.SameAction);
			<>f__AnonymousDelegate(EGuaranteeAction.EnablePlayerMoveControl, () => new GuaranteeActionEnablePlayerMoveControl(), EActionFilterMode.SameName);
			<>f__AnonymousDelegate(EGuaranteeAction.UnLimitPlayerOperation, () => new GuaranteeActionUnLimitPlayerOperation(), EActionFilterMode.SameName);
			<>f__AnonymousDelegate(EGuaranteeAction.ExitOrbitalCamera, () => new GuaranteeActionExitOrbitalCamera(), EActionFilterMode.SameName);
			<>f__AnonymousDelegate(EGuaranteeAction.ActionBlackScreenFadeOut, () => new GuaranteeActionBlackScreenFadeOut(), EActionFilterMode.SameName);
			<>f__AnonymousDelegate(EGuaranteeAction.DisableSplineMoveModel, () => new GuaranteeActionDisableSplineMoveModel(), EActionFilterMode.SameName);
			<>f__AnonymousDelegate(EGuaranteeAction.StopEffect, () => new GuaranteeActionStopEffect(), EActionFilterMode.SameAction);
			<>f__AnonymousDelegate(EGuaranteeAction.Preload, () => new GuaranteeActionPreload(), EActionFilterMode.SameName);
			<>f__AnonymousDelegate(EGuaranteeAction.DisableKey4Func, () => new GuaranteeActionDisableKey4Func(), EActionFilterMode.SameName);
			<>f__AnonymousDelegate(EGuaranteeAction.ActionExitMovieMode, () => new GuaranteeActionExitMovieMode(), EActionFilterMode.SameName);
			<>f__AnonymousDelegate(EGuaranteeAction.StopGamepadShake, () => new GuaranteeActionStopGamepadShake(), EActionFilterMode.SameName);
		}

		// Token: 0x06044950 RID: 280912 RVA: 0x011D4597 File Offset: 0x011D2797
		private void SetupGuaranteeAction(EGuaranteeAction guaranteeAction, Func<GuaranteeActionBase> actionClass, EActionFilterMode filterMode = EActionFilterMode.SameName)
		{
			if (!this.GuaranteeActionMap.ContainsKey(guaranteeAction))
			{
				this.GuaranteeActionMap[guaranteeAction] = actionClass;
			}
			if (!this.ActionFilterModeMap.ContainsKey(guaranteeAction))
			{
				this.ActionFilterModeMap[guaranteeAction] = filterMode;
			}
		}

		// Token: 0x06044951 RID: 280913 RVA: 0x011D45D0 File Offset: 0x011D27D0
		[NullableContext(2)]
		public GuaranteeActionBase GetGuaranteeAction(EGuaranteeAction guaranteeAction)
		{
			Func<GuaranteeActionBase> func;
			if (!this.GuaranteeActionMap.TryGetValue(guaranteeAction, out func))
			{
				return null;
			}
			return func();
		}

		// Token: 0x06044952 RID: 280914 RVA: 0x011D45F8 File Offset: 0x011D27F8
		public EActionFilterMode GetActionFilterMode(EGuaranteeAction guaranteeAction)
		{
			EActionFilterMode result;
			if (this.ActionFilterModeMap.TryGetValue(guaranteeAction, out result))
			{
				return result;
			}
			return EActionFilterMode.Never;
		}

		// Token: 0x040262D5 RID: 156373
		private readonly Dictionary<EGuaranteeAction, Func<GuaranteeActionBase>> GuaranteeActionMap = new Dictionary<EGuaranteeAction, Func<GuaranteeActionBase>>();

		// Token: 0x040262D6 RID: 156374
		private readonly Dictionary<EGuaranteeAction, EActionFilterMode> ActionFilterModeMap = new Dictionary<EGuaranteeAction, EActionFilterMode>();
	}
}
