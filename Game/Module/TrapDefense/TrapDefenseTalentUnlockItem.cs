using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E58 RID: 20056
	public class TrapDefenseTalentUnlockItem : UiPanelBase
	{
		// Token: 0x06033D3C RID: 212284 RVA: 0x00CF5CE8 File Offset: 0x00CF3EE8
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

		// Token: 0x06033D3D RID: 212285 RVA: 0x00CF5D72 File Offset: 0x00CF3F72
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), ETrapDefenseTextKey.TalentNodeUnlocked.ToString(), Array.Empty<object>());
		}

		// Token: 0x0200ADFB RID: 44539
		private class EComponentDefine
		{
			// Token: 0x04036082 RID: 221314
			public const int SpriteLock = 0;

			// Token: 0x04036083 RID: 221315
			public const int TextUnlock = 1;

			// Token: 0x04036084 RID: 221316
			public const int BtnHelp = 2;
		}
	}
}
