using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x0200186F RID: 6255
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ComboTeachingController : UiControllerBase<ComboTeachingController>
{
	// Token: 0x0600B334 RID: 45876 RVA: 0x002FD79B File Offset: 0x002FB99B
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ComboTeachingViewOpen, new Action<int>(this.OnOpenComboTeachingView));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x0600B335 RID: 45877 RVA: 0x002FD7D5 File Offset: 0x002FB9D5
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ComboTeachingViewOpen, new Action<int>(this.OnOpenComboTeachingView));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x0600B336 RID: 45878 RVA: 0x002FD80F File Offset: 0x002FBA0F
	private void OnOpenComboTeachingView(int comboId)
	{
		ModelBase<ComboTeachingModel>.Instance.RecoveryComboId = comboId;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ComboTeachingView, comboId, null);
	}

	// Token: 0x0600B337 RID: 45879 RVA: 0x002FD832 File Offset: 0x002FBA32
	private void OnWorldDone()
	{
		ModelBase<ComboTeachingModel>.Instance.InitStart = true;
	}

	// Token: 0x0600B338 RID: 45880 RVA: 0x002FD83F File Offset: 0x002FBA3F
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.ComboTeachingView, new Func<EUiViewName, object, bool>(this.CheckOpenComboTeachingView), "ComboTeachingController.CheckOpenComboTeachingView");
	}

	// Token: 0x0600B339 RID: 45881 RVA: 0x002FD861 File Offset: 0x002FBA61
	private bool CheckOpenComboTeachingView(EUiViewName viewName, object param)
	{
		return ControllerBase<GameModeController>.Instance.IsInInstance();
	}

	// Token: 0x0600B33A RID: 45882 RVA: 0x002FD86D File Offset: 0x002FBA6D
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.ComboTeachingView, new Func<EUiViewName, object, bool>(this.CheckOpenComboTeachingView));
	}

	// Token: 0x0600B33B RID: 45883 RVA: 0x002FD88C File Offset: 0x002FBA8C
	public BaseCheckCondition GetSuccessChecker(int type, string conditionString)
	{
		switch (type)
		{
		case 0:
			return new CheckSkillIdSuccessCondition(conditionString, true);
		case 1:
			return new CheckSkillHitSuccessCondition(conditionString, true);
		case 2:
			return new CheckSkillEnterNextAttrCondition(conditionString, true);
		case 3:
			return new CheckEnergyCondition(conditionString, true);
		case 4:
			return new CheckBuffAddCondition(conditionString, true);
		case 5:
			return new CheckTagAddCondition(conditionString, true);
		case 6:
			return new CheckIsJumpCondition(conditionString, true);
		case 7:
			return new CheckBuffNotHaveCondition(conditionString, true);
		case 8:
			return new CheckTagNotHaveCondition(conditionString, true);
		case 9:
			return new CheckBulletHitCondition(conditionString, true);
		case 10:
			return new CheckKeyInputCondition(conditionString, true);
		case 11:
			return new CheckKeyHoldingCondition(conditionString, true);
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ComboTeaching;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "角色出招教学，成功条件检查未实现";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new BaseCheckCondition(conditionString, true);
		}
		}
	}

	// Token: 0x0600B33C RID: 45884 RVA: 0x002FD968 File Offset: 0x002FBB68
	public BaseCheckCondition GetFailChecker(int type, string conditionString)
	{
		switch (type)
		{
		case 0:
			return new CheckSkillIdFailCondition(conditionString, false);
		case 1:
			return new CheckSkillExitNextAttrCondition(conditionString, false);
		case 2:
			return new CheckNotInSkillCondition(conditionString, false);
		case 3:
			return new CheckEnergyCondition(conditionString, false);
		case 4:
			return new CheckBuffNotHaveCondition(conditionString, false);
		case 5:
			return new CheckTagNotHaveCondition(conditionString, false);
		case 6:
			return new CheckIsInJumpCondition(conditionString, false);
		case 7:
			return new CheckKeyInputCondition(conditionString, false);
		case 8:
			return new CheckKeyHoldingCondition(conditionString, false);
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ComboTeaching;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "角色出招教学，失败条件检查未实现";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new BaseCheckCondition(conditionString, false);
		}
		}
	}
}
