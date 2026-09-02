using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064A4 RID: 25764
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookTabDynamicItem : UiPanelBase, IDynamicScrollBaseItem<RoadBookAreaData>
	{
		// Token: 0x06040986 RID: 264582 RVA: 0x0108EF0C File Offset: 0x0108D10C
		public UniTask Init(UUIItem actor)
		{
			RoadBookTabDynamicItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RoadBookTabDynamicItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06040987 RID: 264583 RVA: 0x0108EF57 File Offset: 0x0108D157
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06040988 RID: 264584 RVA: 0x0108EF90 File Offset: 0x0108D190
		public FVector2D GetItemSize(RoadBookAreaData itemData)
		{
			UUIItem rootItem = base.GetRootItem();
			this.VectorValue.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.VectorValue.ToUeVector2D(false);
		}

		// Token: 0x06040989 RID: 264585 RVA: 0x0108EFC9 File Offset: 0x0108D1C9
		public void ClearItem()
		{
		}

		// Token: 0x040242A6 RID: 148134
		private Vector2D VectorValue;
	}
}
