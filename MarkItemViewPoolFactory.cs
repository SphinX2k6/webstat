using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;

// Token: 0x02002242 RID: 8770
[NullableContext(1)]
[Nullable(0)]
public class MarkItemViewPoolFactory
{
	// Token: 0x060108E1 RID: 67809 RVA: 0x0048716C File Offset: 0x0048536C
	private static MarkItemViewPoolBase GetPool(string poolName)
	{
		MarkItemViewPoolBase markItemViewPoolBase;
		if (MarkItemViewPoolFactory.PoolMap.TryGetValue(poolName, out markItemViewPoolBase))
		{
			return markItemViewPoolBase;
		}
		markItemViewPoolBase = new MarkPanelPool();
		MarkItemViewPoolFactory.PoolMap[poolName] = markItemViewPoolBase;
		return markItemViewPoolBase;
	}

	// Token: 0x060108E2 RID: 67810 RVA: 0x0048719D File Offset: 0x0048539D
	[return: Nullable(2)]
	public static T Get<[Nullable(0)] T>(string poolName) where T : MarkPanelBase
	{
		return MarkItemViewPoolFactory.GetPool(poolName).Get<T>();
	}

	// Token: 0x060108E3 RID: 67811 RVA: 0x004871AA File Offset: 0x004853AA
	public static void Recycle(string poolName, MarkPanelBase poolObj)
	{
		MarkItemViewPoolFactory.GetPool(poolName).Recycle(poolObj);
	}

	// Token: 0x060108E4 RID: 67812 RVA: 0x004871B8 File Offset: 0x004853B8
	public static void Tick()
	{
		foreach (MarkItemViewPoolBase markItemViewPoolBase in MarkItemViewPoolFactory.PoolMap.Values)
		{
			markItemViewPoolBase.Tick();
		}
	}

	// Token: 0x060108E5 RID: 67813 RVA: 0x0048720C File Offset: 0x0048540C
	public static void Dispose()
	{
		foreach (MarkItemViewPoolBase markItemViewPoolBase in MarkItemViewPoolFactory.PoolMap.Values)
		{
			markItemViewPoolBase.Dispose();
		}
		MarkItemViewPoolFactory.PoolMap.Clear();
	}

	// Token: 0x04008250 RID: 33360
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<string, MarkItemViewPoolBase> PoolMap = new Dictionary<string, MarkItemViewPoolBase>();
}
