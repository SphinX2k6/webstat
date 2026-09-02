using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EAC RID: 24236
	internal class CiacconaGalPlayerChoosingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CEB2 RID: 249522 RVA: 0x00F79BDF File Offset: 0x00F77DDF
		[NullableContext(1)]
		public CiacconaGalPlayerChoosingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEB3 RID: 249523 RVA: 0x00F79BEA File Offset: 0x00F77DEA
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
			ModelBase<CiacconaGalModel>.Instance.IsCurStepDataListDirty = true;
		}

		// Token: 0x0603CEB4 RID: 249524 RVA: 0x00F79C00 File Offset: 0x00F77E00
		public override void OnClick(int? choiceId = null)
		{
			if (choiceId == null)
			{
				return;
			}
			CiacconaGalChoiceData choiceDataById = ModelBase<CiacconaGalModel>.Instance.GetChoiceDataById(choiceId.Value);
			if (choiceDataById == null)
			{
				return;
			}
			CiacconaGalStepData stepDataById = ModelBase<CiacconaGalModel>.Instance.GetStepDataById(this.Owner.CurHandlingStepId);
			int toStepId = (choiceDataById.ToStepId == 0) ? stepDataById.NextStepId : choiceDataById.ToStepId;
			int id = ModelBase<CiacconaGalModel>.Instance.ActivityData.Id;
			int curHandlingChapterId = this.Owner.CurHandlingChapterId;
			int inspirationCount = ModelBase<CiacconaGalModel>.Instance.ActivityData.InspirationCount;
			int requiredInspiration = choiceDataById.RequiredInspiration;
			switch (choiceDataById.State)
			{
			case ECiacconaGalStepState.Normal:
				stepDataById.ChosenId = choiceId.Value;
				this.Owner.TryContinue(toStepId);
				return;
			case ECiacconaGalStepState.LockingByInspiration:
				if (inspirationCount >= requiredInspiration)
				{
					ControllerBase<CiacconaGalController>.Instance.RequestUnlockChoice(id, curHandlingChapterId, choiceId.Value);
					return;
				}
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InspirationNotEnough", Array.Empty<object>());
				return;
			case ECiacconaGalStepState.LockingByCondition:
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RequireConditionToUnlock", Array.Empty<object>());
				return;
			case ECiacconaGalStepState.Chosen:
				Singleton<EventSystem>.Instance.Emit<CiacconaGalStepData, CiacconaGalChoiceData>(EEventName.OnCiacconaAvgReChoose, stepDataById, choiceDataById);
				return;
			default:
				return;
			}
		}
	}
}
