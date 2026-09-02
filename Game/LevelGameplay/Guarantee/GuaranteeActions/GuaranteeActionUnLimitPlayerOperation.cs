using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E7A RID: 28282
	public class GuaranteeActionUnLimitPlayerOperation : GuaranteeActionBase
	{
		// Token: 0x0604499A RID: 280986 RVA: 0x011D5694 File Offset: 0x011D3894
		[NullableContext(2)]
		protected override void OnExecute(ActionParams @params)
		{
			ControllerBase<InputController>.Instance.SetMoveControlEnabled(true, true, true, true);
			Singleton<LevelEventLockInputState>.Instance.Unlock();
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.LevelEvent, 0);
			ModelBase<BattleInputModel>.Instance.SetAllInputEnable(true, EBattleInputReason.LevelEvent);
			Singleton<LevelEventLockInputState>.Instance.InputLimitView = new List<EUiViewName>();
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity;
			if (baseCharacter == null)
			{
				entity = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			Entity entity2 = entity;
			if (entity2 != null && entity2.Valid)
			{
				BaseTagComponent component = entity2.GetComponent<BaseTagComponent>();
				int num = GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"];
				if (component != null && component.HasTag(num))
				{
					component.RemoveTag(new int?(num));
				}
				int num2 = GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制行走"];
				if (component != null && component.HasTag(num2))
				{
					component.RemoveTag(new int?(num2));
				}
				int num3 = GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制慢跑"];
				if (component != null && component.HasTag(num3))
				{
					component.RemoveTag(new int?(num3));
				}
			}
			ModelBase<LevelFuncFlagModel>.Instance.SetFuncFlagEnable(ELevelFuncFlagId.TempTeleporterPlacement, true);
		}
	}
}
