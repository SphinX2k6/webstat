using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DD0 RID: 24016
	public class TowerDefenceReviveItem : UiPanelBase
	{
		// Token: 0x0603C756 RID: 247638 RVA: 0x00F5AD74 File Offset: 0x00F58F74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C757 RID: 247639 RVA: 0x00F5ADBC File Offset: 0x00F58FBC
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "TowerDefence_end", Array.Empty<object>());
		}

		// Token: 0x04021FDB RID: 139227
		[Nullable(1)]
		private const string BUTTON_TEXT_ID = "TowerDefence_end";

		// Token: 0x0200BE1F RID: 48671
		private class EItemComponent
		{
			// Token: 0x0403A890 RID: 239760
			public const int ButtonText = 1;
		}
	}
}
