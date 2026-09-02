using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x020048FC RID: 18684
	[NullableContext(1)]
	[Nullable(0)]
	public class HookPointUtils
	{
		// Token: 0x06030C9A RID: 199834 RVA: 0x00C0F608 File Offset: 0x00C0D808
		public static bool HookPointEqual(HookPointInfo a, HookPointInfo b)
		{
			return a.Point == b.Point && a.PortalPairId == b.PortalPairId && a.PortalA2B == b.PortalA2B;
		}

		// Token: 0x06030C9B RID: 199835 RVA: 0x00C0F636 File Offset: 0x00C0D836
		[return: Nullable(new byte[]
		{
			1,
			1,
			1,
			0
		})]
		public static Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> HookPointSetAdd([Nullable(new byte[]
		{
			1,
			1,
			1,
			0
		})] Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> container, HookPointInfo pointPathway)
		{
			return HookPointUtils.HookPointSetAdd(container, pointPathway.Point, pointPathway.PortalPairId, pointPathway.PortalA2B);
		}

		// Token: 0x06030C9C RID: 199836 RVA: 0x00C0F650 File Offset: 0x00C0D850
		[return: Nullable(new byte[]
		{
			1,
			1,
			1,
			0
		})]
		public static Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> HookPointSetAdd([Nullable(new byte[]
		{
			1,
			1,
			1,
			0
		})] Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> container, GrapplingHookPointComponent point, long portalPairId = 0L, bool portalA2B = true)
		{
			List<ValueTuple<long, bool>> list;
			if (!container.TryGetValue(point, out list))
			{
				list = new List<ValueTuple<long, bool>>();
				container[point] = list;
			}
			else if (list.FindIndex((ValueTuple<long, bool> value) => value.Item1 == portalPairId && value.Item2 == portalA2B) != -1)
			{
				return container;
			}
			list.Add(new ValueTuple<long, bool>(portalPairId, portalA2B));
			return container;
		}

		// Token: 0x06030C9D RID: 199837 RVA: 0x00C0F6BB File Offset: 0x00C0D8BB
		public static bool HookPointSetHas([Nullable(new byte[]
		{
			1,
			1,
			1,
			0
		})] Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> container, HookPointInfo pointPathway)
		{
			return HookPointUtils.HookPointSetHas(container, pointPathway.Point, pointPathway.PortalPairId, pointPathway.PortalA2B);
		}

		// Token: 0x06030C9E RID: 199838 RVA: 0x00C0F6D8 File Offset: 0x00C0D8D8
		public static bool HookPointSetHas([Nullable(new byte[]
		{
			1,
			1,
			1,
			0
		})] Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> container, GrapplingHookPointComponent point, long portalPairId = 0L, bool portalA2B = true)
		{
			List<ValueTuple<long, bool>> list;
			return container.TryGetValue(point, out list) && list.FindIndex((ValueTuple<long, bool> value) => value.Item1 == portalPairId && value.Item2 == portalA2B) != -1;
		}

		// Token: 0x06030C9F RID: 199839 RVA: 0x00C0F71E File Offset: 0x00C0D91E
		public static bool HookPointSetDelete([Nullable(new byte[]
		{
			1,
			1,
			1,
			0
		})] Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> container, HookPointInfo pointPathway)
		{
			return HookPointUtils.HookPointSetDelete(container, pointPathway.Point, pointPathway.PortalPairId, pointPathway.PortalA2B);
		}

		// Token: 0x06030CA0 RID: 199840 RVA: 0x00C0F738 File Offset: 0x00C0D938
		public static bool HookPointSetDelete([Nullable(new byte[]
		{
			1,
			1,
			1,
			0
		})] Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> container, GrapplingHookPointComponent point, long portalPairId = 0L, bool portalA2B = true)
		{
			List<ValueTuple<long, bool>> list;
			if (!container.TryGetValue(point, out list))
			{
				return false;
			}
			int num = list.FindIndex((ValueTuple<long, bool> value) => value.Item1 == portalPairId && value.Item2 == portalA2B);
			if (num != -1)
			{
				list.RemoveAt(num);
			}
			if (list.Count == 0)
			{
				container.Remove(point);
			}
			return num != -1;
		}

		// Token: 0x06030CA1 RID: 199841 RVA: 0x00C0F79C File Offset: 0x00C0D99C
		public static void HookPointSetForEach([Nullable(new byte[]
		{
			2,
			1,
			1,
			0
		})] Dictionary<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> container, THookPointSetCallback callbackFn)
		{
			if (container == null)
			{
				return;
			}
			int num = 0;
			foreach (KeyValuePair<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> keyValuePair in container)
			{
				num += keyValuePair.Value.Count;
			}
			if (num == 0)
			{
				return;
			}
			if (HookPointUtils.s_HookPointSnapshot.Length < num)
			{
				HookPointUtils.s_HookPointSnapshot = new ValueTuple<GrapplingHookPointComponent, long, bool>[num];
			}
			int num2 = 0;
			foreach (KeyValuePair<GrapplingHookPointComponent, List<ValueTuple<long, bool>>> keyValuePair2 in container)
			{
				GrapplingHookPointComponent key = keyValuePair2.Key;
				foreach (ValueTuple<long, bool> valueTuple in keyValuePair2.Value)
				{
					HookPointUtils.s_HookPointSnapshot[num2++] = new ValueTuple<GrapplingHookPointComponent, long, bool>(key, valueTuple.Item1, valueTuple.Item2);
				}
			}
			for (int i = 0; i < num; i++)
			{
				ValueTuple<GrapplingHookPointComponent, long, bool> valueTuple2 = HookPointUtils.s_HookPointSnapshot[i];
				GrapplingHookPointComponent item = valueTuple2.Item1;
				long item2 = valueTuple2.Item2;
				bool item3 = valueTuple2.Item3;
				callbackFn(item, item2, item3);
			}
		}

		// Token: 0x0401C0A7 RID: 114855
		[TupleElementNames(new string[]
		{
			"point",
			"portalPairId",
			"portalA2B"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		[StaticVariableRuleIgnore]
		private static ValueTuple<GrapplingHookPointComponent, long, bool>[] s_HookPointSnapshot = Array.Empty<ValueTuple<GrapplingHookPointComponent, long, bool>>();
	}
}
