using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200516C RID: 20844
	public class RoguelikePhantomDotItem : GridProxyAbstract<int>
	{
		// Token: 0x06035A48 RID: 219720 RVA: 0x00D7964C File Offset: 0x00D7784C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035A49 RID: 219721 RVA: 0x00D79694 File Offset: 0x00D77894
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			base.GetItem(0).SetUIActive(isSelected);
		}

		// Token: 0x06035A4A RID: 219722 RVA: 0x00D796A3 File Offset: 0x00D778A3
		public override void OnDeselected(bool fireEvent)
		{
			base.GetItem(0).SetUIActive(false);
		}

		// Token: 0x06035A4B RID: 219723 RVA: 0x00D796B2 File Offset: 0x00D778B2
		public override void OnSelected(bool fireEvent)
		{
			base.GetItem(0).SetUIActive(true);
		}

		// Token: 0x0200B11B RID: 45339
		private class EComponents
		{
			// Token: 0x04036EFB RID: 225019
			public const int Item = 0;
		}
	}
}
