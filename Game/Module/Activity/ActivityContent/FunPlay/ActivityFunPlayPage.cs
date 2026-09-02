using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006776 RID: 26486
	internal class ActivityFunPlayPage : GridProxyAbstract<FunPlaySharpComment>
	{
		// Token: 0x0604205B RID: 270427 RVA: 0x010F089C File Offset: 0x010EEA9C
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

		// Token: 0x0604205C RID: 270428 RVA: 0x010F08E4 File Offset: 0x010EEAE4
		public override void Refresh(FunPlaySharpComment data, bool isSelected, int gridIndex)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0604205D RID: 270429 RVA: 0x010F08F8 File Offset: 0x010EEAF8
		public override void OnSelected(bool fireEvent)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
		}

		// Token: 0x0604205E RID: 270430 RVA: 0x010F090C File Offset: 0x010EEB0C
		public override void OnDeselected(bool fireEvent)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0200C792 RID: 51090
		private class EComponent
		{
			// Token: 0x0403D710 RID: 251664
			public const int DotPic = 0;
		}
	}
}
