using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020030F7 RID: 12535
[NullableContext(1)]
[Nullable(0)]
public class PerformActionPool : IStaticVariableResetter
{
	// Token: 0x06019EC9 RID: 106185 RVA: 0x00794673 File Offset: 0x00792873
	static PerformActionPool()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PerformActionPool.CreateStaticDefaultValue), new Action(PerformActionPool.ResetStaticDefaultValue));
	}

	// Token: 0x1700232B RID: 9003
	// (get) Token: 0x06019ECA RID: 106186 RVA: 0x00794692 File Offset: 0x00792892
	private static Dictionary<EPerformAction, List<PerformActionBase>> Pool
	{
		get
		{
			return PerformActionPool._pool;
		}
	}

	// Token: 0x06019ECB RID: 106187 RVA: 0x0079469C File Offset: 0x0079289C
	public static IPerformActionBase GetAction(EPerformAction action, int id, IActionParamMap param, BasePerformComponent performComp, EPerformGroup group, Action onFinish, [Nullable(2)] Action<int> onBeforeExecute = null, [Nullable(2)] Action<int> onAfterExecute = null)
	{
		PerformActionBase performActionBase;
		if (PerformActionPool.Pool.ContainsKey(action) && PerformActionPool.Pool[action].Count > 0)
		{
			performActionBase = PerformActionPool.Pool[action][PerformActionPool.Pool[action].Count - 1];
			PerformActionPool.Pool[action].RemoveAt(PerformActionPool.Pool[action].Count - 1);
		}
		else
		{
			performActionBase = ActionClasses.CreateAction(action);
		}
		performActionBase.Id = id;
		performActionBase.Param = param;
		performActionBase.PerformComp = performComp;
		performActionBase.Group = group;
		performActionBase.OnFinish = onFinish;
		performActionBase.OnBeforeExecute = onBeforeExecute;
		performActionBase.OnAfterExecute = onAfterExecute;
		return performActionBase;
	}

	// Token: 0x06019ECC RID: 106188 RVA: 0x00794754 File Offset: 0x00792954
	public static void ReturnAction(IPerformActionBase inAction)
	{
		PerformActionBase performActionBase = inAction as PerformActionBase;
		performActionBase.Reset();
		EPerformAction name = performActionBase.Name;
		if (!PerformActionPool.Pool.ContainsKey(name))
		{
			PerformActionPool.Pool[name] = new List<PerformActionBase>();
		}
		PerformActionPool.Pool[name].Add(performActionBase);
	}

	// Token: 0x06019ECD RID: 106189 RVA: 0x007947A3 File Offset: 0x007929A3
	public static void Clear()
	{
		PerformActionPool._pool = new Dictionary<EPerformAction, List<PerformActionBase>>();
	}

	// Token: 0x06019ECE RID: 106190 RVA: 0x007947AF File Offset: 0x007929AF
	public static void CreateStaticDefaultValue()
	{
		PerformActionPool._pool = new Dictionary<EPerformAction, List<PerformActionBase>>();
	}

	// Token: 0x06019ECF RID: 106191 RVA: 0x007947BB File Offset: 0x007929BB
	public static void ResetStaticDefaultValue()
	{
		PerformActionPool._pool = null;
	}

	// Token: 0x0400CFD5 RID: 53205
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<EPerformAction, List<PerformActionBase>> _pool;
}
