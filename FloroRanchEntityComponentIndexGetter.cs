using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001BF5 RID: 7157
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public class FloroRanchEntityComponentIndexGetter<[Nullable(0)] T> where T : FloroRanchEntityComponentBase
{
	// Token: 0x170010FA RID: 4346
	// (get) Token: 0x0600D02A RID: 53290 RVA: 0x003743A0 File Offset: 0x003725A0
	public static int Index { get; }

	// Token: 0x0600D02B RID: 53291 RVA: 0x003743A8 File Offset: 0x003725A8
	public static int GetByType(string typeName, bool useCache = false)
	{
		if (useCache)
		{
			int num = -1;
			if (FloroRanchEntityComponentIndexGetter<T>.ComponentIndex != null)
			{
				if (FloroRanchEntityComponentIndexGetter<T>.ComponentIndex.TryGetValue(typeName, out num))
				{
					return num;
				}
			}
			else
			{
				FloroRanchEntityComponentIndexGetter<T>.ComponentIndex = new Dictionary<string, int>();
			}
			EFloroRanchEntityComponent efloroRanchEntityComponent;
			num = (int)(Enum.TryParse<EFloroRanchEntityComponent>(typeName, out efloroRanchEntityComponent) ? efloroRanchEntityComponent : ((EFloroRanchEntityComponent)(-1)));
			if (num != -1)
			{
				FloroRanchEntityComponentIndexGetter<T>.ComponentIndex[typeName] = num;
			}
			return num;
		}
		EFloroRanchEntityComponent result;
		if (!Enum.TryParse<EFloroRanchEntityComponent>(typeName, out result))
		{
			return -1;
		}
		return (int)result;
	}

	// Token: 0x0600D02D RID: 53293 RVA: 0x00374414 File Offset: 0x00372614
	// Note: this type is marked as 'beforefieldinit'.
	static FloroRanchEntityComponentIndexGetter()
	{
		EFloroRanchEntityComponent efloroRanchEntityComponent;
		FloroRanchEntityComponentIndexGetter<T>.Index = (Enum.TryParse<EFloroRanchEntityComponent>(typeof(T).Name, out efloroRanchEntityComponent) ? efloroRanchEntityComponent : ((EFloroRanchEntityComponent)(-1)));
	}

	// Token: 0x04006316 RID: 25366
	public static Dictionary<string, int> ComponentIndex;
}
