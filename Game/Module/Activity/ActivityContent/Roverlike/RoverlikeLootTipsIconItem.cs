using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006400 RID: 25600
	public class RoverlikeLootTipsIconItem : UiPanelBase
	{
		// Token: 0x0604046D RID: 263277 RVA: 0x0107941C File Offset: 0x0107761C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604046E RID: 263278 RVA: 0x01079464 File Offset: 0x01077664
		[NullableContext(1)]
		public void Refresh(string iconPath)
		{
			base.SetTextureByPath(iconPath, base.GetTexture(0), null, null);
		}

		// Token: 0x0200C467 RID: 50279
		private class EComponents
		{
			// Token: 0x0403C74E RID: 247630
			public const int TexIcon = 0;
		}
	}
}
