using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D9 RID: 25049
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySwitchToggleDynamicItem : UiPanelBase, IDynamicScrollBaseItem<IActivityCategoryTabData>
	{
		// Token: 0x17009B47 RID: 39751
		// (get) Token: 0x0603F367 RID: 258919 RVA: 0x0103A00A File Offset: 0x0103820A
		// (set) Token: 0x0603F368 RID: 258920 RVA: 0x0103A012 File Offset: 0x01038212
		private Vector2D ItemSizeVector { get; set; }

		// Token: 0x0603F369 RID: 258921 RVA: 0x0103A01C File Offset: 0x0103821C
		[NullableContext(1)]
		public UniTask Init(UUIItem actor)
		{
			ActivitySwitchToggleDynamicItem.<Init>d__5 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ActivitySwitchToggleDynamicItem.<Init>d__5>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603F36A RID: 258922 RVA: 0x0103A068 File Offset: 0x01038268
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F36B RID: 258923 RVA: 0x0103A0D4 File Offset: 0x010382D4
		[NullableContext(1)]
		public FVector2D GetItemSize(IActivityCategoryTabData data)
		{
			if (this.ItemSizeVector == null)
			{
				this.ItemSizeVector = Vector2D.Create();
			}
			if (data.IsLineType)
			{
				UUIItem item = base.GetItem(1);
				this.ItemSizeVector.Set((double)item.GetWidth(), (double)item.GetHeight());
				return this.ItemSizeVector.ToUeVector2D(false);
			}
			UUIItem rootItem = base.GetRootItem();
			this.ItemSizeVector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
			return this.ItemSizeVector.ToUeVector2D(false);
		}

		// Token: 0x0603F36C RID: 258924 RVA: 0x0103A156 File Offset: 0x01038356
		public void ClearItem()
		{
		}

		// Token: 0x0200C31B RID: 49947
		[NullableContext(0)]
		private class ECategoryComponents
		{
			// Token: 0x0403C234 RID: 246324
			public const int ItemTypeTitle = 1;

			// Token: 0x0403C235 RID: 246325
			public const int PanelTab = 0;
		}
	}
}
