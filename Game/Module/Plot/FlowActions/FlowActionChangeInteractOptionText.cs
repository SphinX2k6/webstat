using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005417 RID: 21527
	public class FlowActionChangeInteractOptionText : FlowActionBase
	{
		// Token: 0x06036F29 RID: 225065 RVA: 0x00DF2964 File Offset: 0x00DF0B64
		protected override void OnExecute()
		{
			int? currentInteractEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
			if (currentInteractEntityId == null)
			{
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(currentInteractEntityId.Value);
			if (entity == null)
			{
				return;
			}
			PawnInteractNewComponent component = entity.GetComponent<PawnInteractNewComponent>();
			if (component == null)
			{
				return;
			}
			PawnInteractController interactController = component.GetInteractController();
			if (interactController == null)
			{
				return;
			}
			CommonInteractOption currentInteractOption = interactController.CurrentInteractOption;
			if (currentInteractOption == null)
			{
				return;
			}
			ChangeInteractOptionText changeInteractOptionText = this.ActionInfo.Params as ChangeInteractOptionText;
			currentInteractOption.TidContent = ((changeInteractOptionText != null) ? changeInteractOptionText.TidContent : null);
		}
	}
}
