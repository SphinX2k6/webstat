using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED9 RID: 20185
	public class TowerDefensePhantomLockItem : UiPanelBase
	{
		// Token: 0x06034238 RID: 213560 RVA: 0x00D095C4 File Offset: 0x00D077C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034239 RID: 213561 RVA: 0x00D09650 File Offset: 0x00D07850
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(false);
		}

		// Token: 0x0603423A RID: 213562 RVA: 0x00D09681 File Offset: 0x00D07881
		[NullableContext(1)]
		public void SetText(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
		}

		// Token: 0x0200AE85 RID: 44677
		private class ELockItemComponent
		{
			// Token: 0x04036304 RID: 221956
			public const int LockSprite = 0;

			// Token: 0x04036305 RID: 221957
			public const int ActiveText = 1;

			// Token: 0x04036306 RID: 221958
			public const int FunctionButton = 2;
		}
	}
}
