using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020030F1 RID: 12529
[NullableContext(1)]
[Nullable(0)]
public class ActionClasses : IStaticVariableResetter
{
	// Token: 0x06019EAA RID: 106154 RVA: 0x0079448F File Offset: 0x0079268F
	static ActionClasses()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActionClasses.CreateStaticDefaultValue), new Action(ActionClasses.ResetStaticDefaultValue));
	}

	// Token: 0x1700231F RID: 8991
	// (get) Token: 0x06019EAB RID: 106155 RVA: 0x007944AE File Offset: 0x007926AE
	private static Dictionary<EPerformAction, Func<PerformActionBase>> SActionClasses
	{
		get
		{
			return ActionClasses._sActionClasses;
		}
	}

	// Token: 0x06019EAC RID: 106156 RVA: 0x007944B5 File Offset: 0x007926B5
	public static PerformActionBase CreateAction(EPerformAction action)
	{
		return ActionClasses.SActionClasses[action]();
	}

	// Token: 0x06019EAD RID: 106157 RVA: 0x007944C8 File Offset: 0x007926C8
	public static void CreateStaticDefaultValue()
	{
		Dictionary<EPerformAction, Func<PerformActionBase>> dictionary = new Dictionary<EPerformAction, Func<PerformActionBase>>();
		dictionary[EPerformAction.PlayMontage] = (() => new PerformPlayMontage());
		dictionary[EPerformAction.StopMontage] = (() => new PerformStopMontage());
		dictionary[EPerformAction.Turn] = (() => new PerformTurn());
		dictionary[EPerformAction.SwitchState] = (() => new PerformSwitchState());
		dictionary[EPerformAction.StartMove] = (() => new PerformStartMove());
		dictionary[EPerformAction.StopMove] = (() => new PerformStopMove());
		ActionClasses._sActionClasses = dictionary;
	}

	// Token: 0x06019EAE RID: 106158 RVA: 0x007945C3 File Offset: 0x007927C3
	public static void ResetStaticDefaultValue()
	{
		ActionClasses._sActionClasses = null;
	}

	// Token: 0x0400CFC9 RID: 53193
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<EPerformAction, Func<PerformActionBase>> _sActionClasses;
}
