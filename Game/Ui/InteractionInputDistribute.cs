using System;
using CSharpScript.Core.Common;
using CSharpScript.Game.LevelGamePlay.LevelPickControl;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A00 RID: 18944
	public class InteractionInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318C2 RID: 202946 RVA: 0x00C593D4 File Offset: 0x00C575D4
		public unsafe override bool OnRefresh()
		{
			if (ModelBase<InteractionModel>.Instance.IsInteractionTurning || TsInteractionUtils.IsInteractWaitOpenViewName)
			{
				if (Singleton<InputManager>.Instance.IsShowMouseCursor() && Singleton<Info>.Instance.IsInKeyBoard())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Input;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "[InputDistribute]刷新交互列表输入Tag时,鼠标处于显示状态，并且在键鼠设备";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsInteractionTurning", ModelBase<InteractionModel>.Instance.IsInteractionTurning);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsInteractWaitOpenViewName", TsInteractionUtils.IsInteractWaitOpenViewName);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					base.SetInputDistributeTags(new string[]
					{
						"UiInputRoot.MouseInputTag",
						"UiInputRoot.Navigation",
						"InteractionRoot"
					});
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Input;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "[InputDistribute]刷新交互列表输入Tag时,鼠标处于显示状态，并且不是键鼠设备";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("IsInteractionTurning", ModelBase<InteractionModel>.Instance.IsInteractionTurning);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("IsInteractWaitOpenViewName", TsInteractionUtils.IsInteractWaitOpenViewName);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					base.SetInputDistributeTags(new string[]
					{
						"UiInputRoot.Navigation",
						"InteractionRoot"
					});
				}
				return true;
			}
			if (ModelBase<InteractionModel>.Instance.LockInteractionEntity != null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.WLJ, "[InputDistribute]刷新交互列表输入Tag时,处于交互锁定状态", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation",
					"InteractionRoot"
				});
				return true;
			}
			int? currentInteractEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
			Entity entity = Singleton<EntitySystem>.Instance.Get(currentInteractEntityId.GetValueOrDefault());
			PawnInteractNewComponent pawnInteractNewComponent = (entity != null) ? entity.GetComponent<PawnInteractNewComponent>() : null;
			if (pawnInteractNewComponent != null && !pawnInteractNewComponent.GetClientCanInteraction())
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新交互列表输入Tag时,当前交互实体在执行交互,禁用热键", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot",
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation",
					"InteractionRoot"
				});
				return true;
			}
			if (ControllerBase<LevelPickInteractController>.Instance.InPickInteractModel)
			{
				base.SetInputDistributeTags(new string[]
				{
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation"
				});
				return true;
			}
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InteractionHintView) && !ModelBase<BattleUiModel>.Instance.ExistBattleInteract())
			{
				return false;
			}
			if (TsInteractionUtils.IsInteractionOpenView())
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Input;
				ELogAuthor author3 = ELogAuthor.XXJ;
				string message3 = "[InputDistribute]刷新交互列表输入Tag时,当前通过交互打开了界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", TsInteractionUtils.GetCurrentOpenViewName());
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			UUIItem layerRootUiItem = Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.HUD);
			if (layerRootUiItem == null || !layerRootUiItem.bIsUIActive)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新交互列表输入Tag时,Hud层没有显示", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (Singleton<InputManager>.Instance.IsShowMouseCursor())
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新交互列表输入Tag时,鼠标处于显示状态", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot.FightInput.AxisInput.MoveInput",
					"FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation",
					"UiInputRoot.ShortcutKeyTag",
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation",
					"InteractionRoot"
				});
				return false;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomExploreView))
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新交互列表输入Tag时,探索轮盘界面在打开中，只允许角色输入，界面快捷键，鼠标输入，界面导航输入", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot.FightInput.AxisInput.MoveInput",
					"UiInputRoot.ShortcutKeyTag",
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation"
				});
				return true;
			}
			if (Singleton<Info>.Instance.IsInGamepad() || Singleton<Info>.Instance.IsInTouch())
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新交互列表输入Tag时,鼠标处于隐藏状态并且在用手柄或手机输入", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTags(new string[]
				{
					"FightInputRoot",
					"UiInputRoot.ShortcutKeyTag",
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation",
					"InteractionRoot"
				});
				return true;
			}
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]刷新交互列表输入Tag时,鼠标处于隐藏状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.SetInputDistributeTags(new string[]
			{
				"FightInputRoot.FightInput.ActionInput",
				"FightInputRoot.FightInput.AxisInput.MoveInput",
				"FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation",
				"UiInputRoot.ShortcutKeyTag",
				"UiInputRoot.MouseInputTag",
				"UiInputRoot.Navigation",
				"InteractionRoot"
			});
			return true;
		}
	}
}
