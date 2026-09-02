using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005AA7 RID: 23207
	internal class EmptyGrid : SyncGridProxyAbstract<int>
	{
		// Token: 0x0603AB40 RID: 240448 RVA: 0x00EE1088 File Offset: 0x00EDF288
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

		// Token: 0x0603AB41 RID: 240449 RVA: 0x00EE10D0 File Offset: 0x00EDF2D0
		public override void Refresh(int data)
		{
		}

		// Token: 0x0200BAAB RID: 47787
		private enum EEmptyComp
		{
			// Token: 0x04039A1A RID: 236058
			PanelEmpty
		}
	}
}
