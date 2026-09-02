using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006268 RID: 25192
	[NullableContext(1)]
	[Nullable(0)]
	public static class TotalTopUpDefine
	{
		// Token: 0x0603F787 RID: 259975 RVA: 0x0104578C File Offset: 0x0104398C
		private static bool CheckIsEquipBuffItem(int id, ItemConfig itemConfig)
		{
			int num;
			return ((itemConfig != null) ? itemConfig.Parameters : null) != null && (itemConfig.Parameters.TryGetValue(5, out num) && num > 0);
		}

		// Token: 0x0603F788 RID: 259976 RVA: 0x010457C0 File Offset: 0x010439C0
		private static void ShowEquipBuffItemTips(int id, ItemConfig itemConfig)
		{
			ControllerBase<SkinController>.Instance.OpenEquipBuffItemShowView(id, false);
		}

		// Token: 0x040239FC RID: 145916
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1,
			1,
			1
		})]
		[StaticVariableRuleIgnore]
		public static readonly List<ValueTuple<Func<int, ItemConfig, bool>, Action<int, ItemConfig>>> itemTipsFunctionList = new List<ValueTuple<Func<int, ItemConfig, bool>, Action<int, ItemConfig>>>
		{
			new ValueTuple<Func<int, ItemConfig, bool>, Action<int, ItemConfig>>(new Func<int, ItemConfig, bool>(TotalTopUpDefine.CheckIsEquipBuffItem), new Action<int, ItemConfig>(TotalTopUpDefine.ShowEquipBuffItemTips))
		};
	}
}
