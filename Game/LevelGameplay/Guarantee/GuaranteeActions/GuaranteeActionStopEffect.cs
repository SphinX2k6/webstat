using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E78 RID: 28280
	[NullableContext(2)]
	[Nullable(0)]
	public class GuaranteeActionStopEffect : GuaranteeActionBase
	{
		// Token: 0x06044995 RID: 280981 RVA: 0x011D54F4 File Offset: 0x011D36F4
		protected override void OnExecute(ActionParams @params = null)
		{
			IGuaranteeStopEffectParams guaranteeStopEffectParams = @params as IGuaranteeStopEffectParams;
			if (guaranteeStopEffectParams == null)
			{
				return;
			}
			if (guaranteeStopEffectParams.ScreenEffectHandle != null)
			{
				ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(guaranteeStopEffectParams.ScreenEffectHandle.Value);
			}
			if (guaranteeStopEffectParams.EffectId != null)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(guaranteeStopEffectParams.EffectId.Value, "[GuaranteeActionStopEffect] 行为树保底销毁特效", true, null);
			}
			if (guaranteeStopEffectParams.Mp4Name != null)
			{
				ControllerBase<VideoBpController>.Instance.RemoveBp();
			}
		}

		// Token: 0x06044996 RID: 280982 RVA: 0x011D5580 File Offset: 0x011D3780
		protected override void OnClear(ActionParams @params, GeneralContext instigatorContext = null)
		{
			if (instigatorContext != null && instigatorContext.Type.GetValueOrDefault() == EGeneralContextType.GeneralLogicTree)
			{
				long treeIncId = (instigatorContext as GeneralLogicTreeContext).TreeIncId;
				if (!ModelBase<GeneralLogicTreeModel>.Instance.GuaranteeActionsWhenLogicTreeRemove.ContainsKey(treeIncId))
				{
					ModelBase<GeneralLogicTreeModel>.Instance.GuaranteeActionsWhenLogicTreeRemove[treeIncId] = new List<GuaranteeActionInfo>();
				}
				ModelBase<GeneralLogicTreeModel>.Instance.GuaranteeActionsWhenLogicTreeRemove[treeIncId].Add(new GuaranteeActionInfo
				{
					Name = EGuaranteeAction.StopEffect,
					Params = @params
				});
			}
		}
	}
}
