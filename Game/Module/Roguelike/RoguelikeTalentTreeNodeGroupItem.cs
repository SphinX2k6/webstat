using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051BC RID: 20924
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeTalentTreeNodeGroupItem : UiPanelBase
	{
		// Token: 0x06035CB7 RID: 220343 RVA: 0x00D87EE0 File Offset: 0x00D860E0
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

		// Token: 0x06035CB8 RID: 220344 RVA: 0x00D87FD0 File Offset: 0x00D861D0
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeTalentTreeNodeGroupItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeTalentTreeNodeGroupItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035CB9 RID: 220345 RVA: 0x00D88013 File Offset: 0x00D86213
		[NullableContext(2)]
		public RoguelikeTalentTreeNodeItem GetNodeItem(int index)
		{
			if (index < 0 || index >= this.NodeItemList.Count)
			{
				return null;
			}
			return this.NodeItemList[index];
		}

		// Token: 0x06035CBA RID: 220346 RVA: 0x00D88035 File Offset: 0x00D86235
		public List<RoguelikeTalentTreeNodeItem> GetAllNodeItems()
		{
			return this.NodeItemList;
		}

		// Token: 0x06035CBB RID: 220347 RVA: 0x00D88040 File Offset: 0x00D86240
		public List<UUIItem> GetAllLines()
		{
			List<UUIItem> list = new List<UUIItem>();
			foreach (RoguelikeTalentTreeNodeItem roguelikeTalentTreeNodeItem in this.NodeItemList)
			{
				list.AddRange(roguelikeTalentTreeNodeItem.GetAllLines());
			}
			return list;
		}

		// Token: 0x06035CBC RID: 220348 RVA: 0x00D880A0 File Offset: 0x00D862A0
		[NullableContext(2)]
		public UUIItem GetLineByIndexInLineId(int index)
		{
			if (index < 6)
			{
				return this.NodeItemList[index].GetUpLine();
			}
			if (index >= 12 && index < 18)
			{
				return this.NodeItemList[index - 12].GetDownLine();
			}
			if (index >= 6 && index < 12)
			{
				return this.NodeItemList[index - 6].GetMidLine();
			}
			return null;
		}

		// Token: 0x0401EDC2 RID: 126402
		private readonly List<RoguelikeTalentTreeNodeItem> NodeItemList = new List<RoguelikeTalentTreeNodeItem>();

		// Token: 0x0200B1A0 RID: 45472
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04037166 RID: 225638
			public const int Node1 = 0;

			// Token: 0x04037167 RID: 225639
			public const int Node2 = 1;

			// Token: 0x04037168 RID: 225640
			public const int Node3 = 2;

			// Token: 0x04037169 RID: 225641
			public const int Node4 = 3;

			// Token: 0x0403716A RID: 225642
			public const int Node5 = 4;

			// Token: 0x0403716B RID: 225643
			public const int Node6 = 5;
		}
	}
}
