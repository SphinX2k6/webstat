using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E56 RID: 20054
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseTalentTreeRowNodeListItem : UiPanelBase
	{
		// Token: 0x06033D23 RID: 212259 RVA: 0x00CF5490 File Offset: 0x00CF3690
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033D24 RID: 212260 RVA: 0x00CF5580 File Offset: 0x00CF3780
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseTalentTreeRowNodeListItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseTalentTreeRowNodeListItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D25 RID: 212261 RVA: 0x00CF55C3 File Offset: 0x00CF37C3
		public TrapDefenseTalentTreeNodeItem GetNodeItem(int index)
		{
			if (index < 0 || index >= this.NodeItemList.Count)
			{
				return null;
			}
			return this.NodeItemList[index];
		}

		// Token: 0x06033D26 RID: 212262 RVA: 0x00CF55E8 File Offset: 0x00CF37E8
		public List<UUIItem> GetAllLines()
		{
			List<UUIItem> list = new List<UUIItem>();
			foreach (TrapDefenseTalentTreeNodeItem trapDefenseTalentTreeNodeItem in this.NodeItemList)
			{
				foreach (UUIItem item in trapDefenseTalentTreeNodeItem.GetAllLines())
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06033D27 RID: 212263 RVA: 0x00CF565C File Offset: 0x00CF385C
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<UUIItem, UUIItem>? GetLinesByIndexInLineId(int index)
		{
			if (index < 6)
			{
				return new ValueTuple<UUIItem, UUIItem>?(this.NodeItemList[index].GetUpLines());
			}
			if (index >= 12 && index < 18)
			{
				return new ValueTuple<UUIItem, UUIItem>?(this.NodeItemList[index - 12].GetDownLines());
			}
			if (index >= 6 && index < 12)
			{
				return new ValueTuple<UUIItem, UUIItem>?(this.NodeItemList[index - 6].GetMidLines());
			}
			return null;
		}

		// Token: 0x0401DFAF RID: 122799
		private readonly List<TrapDefenseTalentTreeNodeItem> NodeItemList = new List<TrapDefenseTalentTreeNodeItem>();

		// Token: 0x0200ADF4 RID: 44532
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403605D RID: 221277
			public const int Node1 = 0;

			// Token: 0x0403605E RID: 221278
			public const int Node2 = 1;

			// Token: 0x0403605F RID: 221279
			public const int Node3 = 2;

			// Token: 0x04036060 RID: 221280
			public const int Node4 = 3;

			// Token: 0x04036061 RID: 221281
			public const int Node5 = 4;

			// Token: 0x04036062 RID: 221282
			public const int Node6 = 5;
		}
	}
}
