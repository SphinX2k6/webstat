using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006546 RID: 25926
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenTabDynamicItem : UiPanelBase, IDynamicScrollBaseItem<RealmBetweenAreaData>
	{
		// Token: 0x06040CE0 RID: 265440 RVA: 0x0109E168 File Offset: 0x0109C368
		public UniTask Init(UUIItem actor)
		{
			RealmBetweenTabDynamicItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RealmBetweenTabDynamicItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06040CE1 RID: 265441 RVA: 0x0109E1B3 File Offset: 0x0109C3B3
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06040CE2 RID: 265442 RVA: 0x0109E1EC File Offset: 0x0109C3EC
		public FVector2D GetItemSize(RealmBetweenAreaData itemData)
		{
			UUIItem rootItem = base.GetRootItem();
			this.VectorValue.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.VectorValue.ToUeVector2D(false);
		}

		// Token: 0x06040CE3 RID: 265443 RVA: 0x0109E225 File Offset: 0x0109C425
		public void ClearItem()
		{
		}

		// Token: 0x040245A6 RID: 148902
		private Vector2D VectorValue;
	}
}
