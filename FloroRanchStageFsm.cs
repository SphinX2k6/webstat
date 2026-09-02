using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001C23 RID: 7203
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchStageFsm : FloroRanchFsmBase<EFloroRanchStageStateType, FloroRanchStateBase>
{
	// Token: 0x0600D16D RID: 53613 RVA: 0x003793CC File Offset: 0x003775CC
	protected override void InitStateInstance()
	{
		this.CurrentStateType = EFloroRanchStageStateType.None;
		base.RegisterState(EFloroRanchStageStateType.GameStart, new FloroRanchGameStartState(this));
		base.RegisterState(EFloroRanchStageStateType.DailyInStage, new FloroRanchDailyInStageState(this));
		base.RegisterState(EFloroRanchStageStateType.StageFail, new FloroRanchStageFailState(this));
		base.RegisterState(EFloroRanchStageStateType.StageSuccess, new FloroRanchStageSuccessState(this));
		base.RegisterState(EFloroRanchStageStateType.GameExit, new FloroRanchGameExitState(this));
	}

	// Token: 0x0600D16E RID: 53614 RVA: 0x00379424 File Offset: 0x00377624
	protected unsafe override bool CheckCanChangeState(EFloroRanchStageStateType curStateType, EFloroRanchStageStateType nextStateType)
	{
		List<EFloroRanchStageStateType> list;
		if (!FloroRanchDefine.FloroRanchStageTransitionMap.TryGetValue(curStateType, out list))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchStageFsm 检查状态转换失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("curStateType", curStateType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("nextStateType", nextStateType);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (!list.Contains(nextStateType))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.FloroRanchGamePlay;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "FloroRanchStageFsm 检查状态转换失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("curStateType", curStateType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("nextStateType", nextStateType);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return false;
		}
		return true;
	}
}
