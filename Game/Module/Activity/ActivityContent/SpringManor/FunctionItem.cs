using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006351 RID: 25425
	public class FunctionItem : UiPanelBase
	{
		// Token: 0x0603FD79 RID: 261497 RVA: 0x01060604 File Offset: 0x0105E804
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickFunction))
			};
		}

		// Token: 0x0603FD7A RID: 261498 RVA: 0x0106071C File Offset: 0x0105E91C
		public FunctionItem(ESpringFunctionType functionType)
		{
			this.FunctionType = functionType;
		}

		// Token: 0x0603FD7B RID: 261499 RVA: 0x0106072B File Offset: 0x0105E92B
		protected override void OnStart()
		{
			this.Refresh();
			this.InitRedDot();
		}

		// Token: 0x0603FD7C RID: 261500 RVA: 0x01060739 File Offset: 0x0105E939
		protected override void OnBeforeDestroy()
		{
			this.DestroyRedDot();
		}

		// Token: 0x0603FD7D RID: 261501 RVA: 0x01060744 File Offset: 0x0105E944
		private void InitRedDot()
		{
			SpringManorGameHandleBase gameplayData = ModelBase<SpringManorModel>.Instance.GetGameplayData(this.FunctionType);
			this.RedDotName = gameplayData.GetRedDotName();
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, base.GetItem(9), null, 0);
				return;
			}
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603FD7E RID: 261502 RVA: 0x010607AE File Offset: 0x0105E9AE
		private void DestroyRedDot()
		{
			if (this.RedDotName == null)
			{
				return;
			}
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(9), 0);
		}

		// Token: 0x0603FD7F RID: 261503 RVA: 0x010607DC File Offset: 0x0105E9DC
		public void Refresh()
		{
			this.RefreshState();
			this.SetLockState(this.State != EFunctionState.Unlock);
			switch (this.State)
			{
			case EFunctionState.LockBeforeTime:
			{
				SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
				string item = (instance != null) ? instance.GetFunctionUnlockRemainText(this.FunctionType) : null;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Spring26_Gameplay_TimeLock", new <>z__ReadOnlySingleElementList<object>(item));
				return;
			}
			case EFunctionState.LockAfterTime:
			{
				SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
				SpringFestivalUnlock? springFestivalUnlock = (instance2 != null) ? instance2.GetFunctionConfigById((int)this.FunctionType) : null;
				int? num = (springFestivalUnlock != null) ? new int?(springFestivalUnlock.GetValueOrDefault().ConditionGroup) : null;
				ConditionConfig instance3 = ConfigBase<ConditionConfig>.Instance;
				ConditionGroup? conditionGroup = (instance3 != null) ? instance3.GetConditionGroupConfig(num.Value) : null;
				string key = (conditionGroup != null) ? conditionGroup.GetValueOrDefault().HintText : null;
				UUIText text = base.GetText(5);
				if (text == null)
				{
					return;
				}
				text.ShowTextNew(key);
				return;
			}
			case EFunctionState.Unlock:
			{
				SpringManorGameHandleBase gameplayData = ModelBase<SpringManorModel>.Instance.GetGameplayData(this.FunctionType);
				int currentProgress = gameplayData.GetCurrentProgress();
				int totalProgress = gameplayData.GetTotalProgress();
				string textStringId = (currentProgress >= totalProgress) ? "Spring26_GameProgress_Done" : "Spring26_GameProgress";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId, new <>z__ReadOnlyArray<object>(new object[]
				{
					currentProgress.ToString(),
					totalProgress.ToString()
				}));
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0603FD80 RID: 261504 RVA: 0x0106095C File Offset: 0x0105EB5C
		private void RefreshState()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance.ActivityData.IsFunctionUnlocked(this.FunctionType))
			{
				this.State = EFunctionState.Unlock;
				return;
			}
			string functionUnlockRemainText = instance.GetFunctionUnlockRemainText(this.FunctionType);
			this.State = ((functionUnlockRemainText == null) ? EFunctionState.LockAfterTime : EFunctionState.LockBeforeTime);
		}

		// Token: 0x0603FD81 RID: 261505 RVA: 0x010609A4 File Offset: 0x0105EBA4
		private void SetLockState(bool isLock)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!isLock);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(isLock);
			}
			UUIItem item3 = base.GetItem(7);
			if (item3 != null)
			{
				item3.SetUIActive(!isLock);
			}
			UUIItem item4 = base.GetItem(1);
			if (item4 != null)
			{
				item4.SetUIActive(!isLock);
			}
			UUIItem item5 = base.GetItem(2);
			if (item5 == null)
			{
				return;
			}
			item5.SetUIActive(isLock);
		}

		// Token: 0x0603FD82 RID: 261506 RVA: 0x01060A18 File Offset: 0x0105EC18
		private void OnClickFunction()
		{
			if (this.State != EFunctionState.Unlock)
			{
				this.OnClickSkip();
				return;
			}
			ModelBase<SpringManorModel>.Instance.GetGameplayData(this.FunctionType).EnterGame();
		}

		// Token: 0x0603FD83 RID: 261507 RVA: 0x01060A40 File Offset: 0x0105EC40
		private void OnClickSkip()
		{
			if (this.State == EFunctionState.LockBeforeTime)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Spring26_Gameplay_TimeLimit", Array.Empty<object>());
				return;
			}
			List<IActivityConditionData> list = new List<IActivityConditionData>();
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			SpringFestivalUnlock? springFestivalUnlock = (instance != null) ? instance.GetFunctionConfigById((int)this.FunctionType) : null;
			foreach (int conditionId in ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(springFestivalUnlock.Value.ConditionGroup))
			{
				Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId);
				int accessType = -1;
				if (conditionConfig.Value.AccessId != 0)
				{
					accessType = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId).Value.SkipName;
				}
				ActivityConditionData item = new ActivityConditionData
				{
					ConditionId = conditionId,
					ConditionTextId = conditionConfig.Value.Description,
					IsFinished = this.IsConditionFinished(conditionId),
					AccessId = conditionConfig.Value.AccessId,
					AccessType = accessType
				};
				list.Add(item);
			}
			ConditionGroupData param = new ConditionGroupData(springFestivalUnlock.Value.ConditionGroup, list, "", false);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
		}

		// Token: 0x0603FD84 RID: 261508 RVA: 0x01060BA4 File Offset: 0x0105EDA4
		private bool IsConditionFinished(int conditionId)
		{
			return false;
		}

		// Token: 0x04023E1D RID: 146973
		private EFunctionState State;

		// Token: 0x04023E1E RID: 146974
		private ERedDotName? RedDotName;

		// Token: 0x04023E1F RID: 146975
		private readonly ESpringFunctionType FunctionType;
	}
}
