using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FFD RID: 24573
	[NullableContext(1)]
	[Nullable(0)]
	public class ChatRowDynamicItem : UiPanelBase, IDynamicScrollItem<ChatRowData>
	{
		// Token: 0x0603DE2A RID: 253482 RVA: 0x00FC8728 File Offset: 0x00FC6928
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DE2B RID: 253483 RVA: 0x00FC8791 File Offset: 0x00FC6991
		public AUIBaseActor GetUsingItem(ChatRowData data)
		{
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		}

		// Token: 0x0603DE2C RID: 253484 RVA: 0x00FC87A4 File Offset: 0x00FC69A4
		public void Update(ChatRowData chatRowData, int index)
		{
			ChatRowDynamicItemInSide itemInSide = this.ItemInSide;
			if (itemInSide == null)
			{
				return;
			}
			itemInSide.Update(chatRowData, index);
		}

		// Token: 0x0603DE2D RID: 253485 RVA: 0x00FC87B8 File Offset: 0x00FC69B8
		public UniTask Init(UUIItem actor)
		{
			ChatRowDynamicItem.<Init>d__5 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ChatRowDynamicItem.<Init>d__5>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE2E RID: 253486 RVA: 0x00FC8804 File Offset: 0x00FC6A04
		private UniTask InitChildItem()
		{
			ChatRowDynamicItem.<InitChildItem>d__6 <InitChildItem>d__;
			<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitChildItem>d__.<>4__this = this;
			<InitChildItem>d__.<>1__state = -1;
			<InitChildItem>d__.<>t__builder.Start<ChatRowDynamicItem.<InitChildItem>d__6>(ref <InitChildItem>d__);
			return <InitChildItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE2F RID: 253487 RVA: 0x00FC8847 File Offset: 0x00FC6A47
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x04022B61 RID: 142177
		[Nullable(2)]
		private ChatRowDynamicItemInSide ItemInSide;

		// Token: 0x0200C084 RID: 49284
		[NullableContext(0)]
		private enum EChild
		{
			// Token: 0x0403B46C RID: 242796
			RootItem,
			// Token: 0x0403B46D RID: 242797
			PanelHorizon
		}
	}
}
