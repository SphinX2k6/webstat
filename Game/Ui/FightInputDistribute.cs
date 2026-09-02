using System;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.SkillButtonUi;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049FD RID: 18941
	public class FightInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318B7 RID: 202935 RVA: 0x00C59150 File Offset: 0x00C57350
		private void HandleGamepadSwitchInteract()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
				bool flag;
				if (instance == null)
				{
					flag = false;
				}
				else
				{
					SkillButtonUiGamepadDataBase gamepadData = instance.GamepadData;
					flag = ((gamepadData != null) ? new bool?(gamepadData.SwitchInteractData.IsSwitchInteractOpen) : null).GetValueOrDefault();
				}
				if (flag)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新战斗输入时，手柄开启了优化通用交互功能,添加分发类型 InteractionRootTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.AddInputDistributeTag("InteractionRoot");
				}
			}
		}

		// Token: 0x060318B8 RID: 202936 RVA: 0x00C591CC File Offset: 0x00C573CC
		public override bool OnRefresh()
		{
			if (!Singleton<UiLayer>.Instance.UiRootItem.IsUIActiveSelf() && !Singleton<UiLayer>.Instance.WorldSpaceUiRootItem.IsUIActiveSelf())
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]尝试刷新战斗输入时，当任何界面都没显示时，只允许战斗输入", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot"
				});
				this.HandleGamepadSwitchInteract();
				return true;
			}
			BattleUiOnlyAllowFightInputHandle onlyAllowFightInputHandle = ModelBase<BattleUiModel>.Instance.OnlyAllowFightInputHandle;
			if (onlyAllowFightInputHandle != null && onlyAllowFightInputHandle.GetEnable())
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.CFT, "[InputDistribute]当前战斗界面处于只允许战斗输入的状态, 设置输入分发Tag为 FightInputRootTag", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot"
				});
				return true;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			CharacterInputComponent characterInputComponent;
			if (getCurrentEntity == null)
			{
				characterInputComponent = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				characterInputComponent = ((entity != null) ? entity.GetComponent<CharacterInputComponent>() : null);
			}
			CharacterInputComponent characterInputComponent2 = characterInputComponent;
			if (characterInputComponent2 != null && characterInputComponent2.IsOnlyAllowFightInput())
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.WWJ, "[InputDistribute]当前角色处于只允许战斗输入的状态, 设置输入分发Tag为 FightInputRootTag", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot"
				});
				return true;
			}
			if (Singleton<InputManager>.Instance.IsShowMouseCursor() && Singleton<Info>.Instance.IsInKeyBoard())
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新战斗输入时，处于键鼠设备并且在显示鼠标，设置输入分发Tag为 UiInputRootTag", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTag("UiInputRoot");
			}
			else
			{
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot",
					"UiInputRoot"
				});
				this.HandleGamepadSwitchInteract();
			}
			return true;
		}
	}
}
