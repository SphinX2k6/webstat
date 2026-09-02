using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000088 RID: 136
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public class ComponentIndexGetter<[Nullable(0)] T> where T : EntityComponent
{
	// Token: 0x1700006A RID: 106
	// (get) Token: 0x0600031B RID: 795 RVA: 0x00012CA1 File Offset: 0x00010EA1
	public static int Index { get; }

	// Token: 0x0600031C RID: 796 RVA: 0x00012CA8 File Offset: 0x00010EA8
	public static int GetByType(string typeName, bool useCache = false)
	{
		if (useCache)
		{
			int num = -1;
			if (ComponentIndexGetter<T>.ComponentIndex != null)
			{
				if (ComponentIndexGetter<T>.ComponentIndex.TryGetValue(typeName, out num))
				{
					return num;
				}
			}
			else
			{
				ComponentIndexGetter<T>.ComponentIndex = new Dictionary<string, int>();
			}
			EComponent ecomponent;
			num = (int)(Enum.TryParse<EComponent>(typeName, out ecomponent) ? ecomponent : ((EComponent)(-1)));
			if (num != -1)
			{
				ComponentIndexGetter<T>.ComponentIndex[typeName] = num;
			}
			return num;
		}
		EComponent result;
		if (!Enum.TryParse<EComponent>(typeName, out result))
		{
			return -1;
		}
		return (int)result;
	}

	// Token: 0x0600031E RID: 798 RVA: 0x00012D14 File Offset: 0x00010F14
	// Note: this type is marked as 'beforefieldinit'.
	static ComponentIndexGetter()
	{
		EComponent ecomponent;
		ComponentIndexGetter<T>.Index = (Enum.TryParse<EComponent>(typeof(T).Name, out ecomponent) ? ecomponent : ((EComponent)(-1)));
	}

	// Token: 0x04000339 RID: 825
	[StaticVariableRuleIgnore]
	public static Dictionary<string, int> ComponentIndex;
}
