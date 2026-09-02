using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200646A RID: 25706
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeTalentTreeNodeGroupItem : UiPanelBase
	{
		// Token: 0x060407B2 RID: 264114 RVA: 0x01086320 File Offset: 0x01084520
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

		// Token: 0x060407B3 RID: 264115 RVA: 0x01086410 File Offset: 0x01084610
		private static string GetNodeResourceId([Nullable(2)] RoverlikeTalentNodeData node)
		{
			if (node != null && node.HeadConfig.Type == 2)
			{
				return "UiItem_RoverRougeTalentTreeSPNode";
			}
			return "UiItem_RoverRougeTalentTreeNorNode";
		}

		// Token: 0x060407B4 RID: 264116 RVA: 0x0108643C File Offset: 0x0108463C
		public UniTask EnsureNodeItemsAsync(IReadOnlyList<RoverlikeTalentNodeData> nodes)
		{
			RoverlikeTalentTreeNodeGroupItem.<EnsureNodeItemsAsync>d__5 <EnsureNodeItemsAsync>d__;
			<EnsureNodeItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnsureNodeItemsAsync>d__.<>4__this = this;
			<EnsureNodeItemsAsync>d__.nodes = nodes;
			<EnsureNodeItemsAsync>d__.<>1__state = -1;
			<EnsureNodeItemsAsync>d__.<>t__builder.Start<RoverlikeTalentTreeNodeGroupItem.<EnsureNodeItemsAsync>d__5>(ref <EnsureNodeItemsAsync>d__);
			return <EnsureNodeItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060407B5 RID: 264117 RVA: 0x01086488 File Offset: 0x01084688
		private UniTask EnsureSlotItemAsync(int slotIndex, string resourceId)
		{
			RoverlikeTalentTreeNodeGroupItem.<EnsureSlotItemAsync>d__6 <EnsureSlotItemAsync>d__;
			<EnsureSlotItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnsureSlotItemAsync>d__.<>4__this = this;
			<EnsureSlotItemAsync>d__.slotIndex = slotIndex;
			<EnsureSlotItemAsync>d__.resourceId = resourceId;
			<EnsureSlotItemAsync>d__.<>1__state = -1;
			<EnsureSlotItemAsync>d__.<>t__builder.Start<RoverlikeTalentTreeNodeGroupItem.<EnsureSlotItemAsync>d__6>(ref <EnsureSlotItemAsync>d__);
			return <EnsureSlotItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060407B6 RID: 264118 RVA: 0x010864DB File Offset: 0x010846DB
		[NullableContext(2)]
		public RoverlikeTalentTreeNodeItem GetNodeItem(int index)
		{
			if (index < 0 || index >= 6)
			{
				return null;
			}
			return this.ActiveItems[index];
		}

		// Token: 0x060407B7 RID: 264119 RVA: 0x010864F0 File Offset: 0x010846F0
		public List<RoverlikeTalentTreeNodeItem> GetAllNodeItems()
		{
			List<RoverlikeTalentTreeNodeItem> list = new List<RoverlikeTalentTreeNodeItem>();
			foreach (RoverlikeTalentTreeNodeItem roverlikeTalentTreeNodeItem in this.ActiveItems)
			{
				if (roverlikeTalentTreeNodeItem != null)
				{
					list.Add(roverlikeTalentTreeNodeItem);
				}
			}
			return list;
		}

		// Token: 0x060407B8 RID: 264120 RVA: 0x01086528 File Offset: 0x01084728
		public List<UUIItem> GetAllLines()
		{
			List<UUIItem> list = new List<UUIItem>();
			foreach (RoverlikeTalentTreeNodeItem roverlikeTalentTreeNodeItem in this.GetAllNodeItems())
			{
				list.AddRange(roverlikeTalentTreeNodeItem.GetAllLines());
			}
			return list;
		}

		// Token: 0x060407B9 RID: 264121 RVA: 0x01086588 File Offset: 0x01084788
		[NullableContext(2)]
		public UUIItem GetSolidLineByIndexInLineId(int index)
		{
			if (index < 6)
			{
				RoverlikeTalentTreeNodeItem nodeItem = this.GetNodeItem(index);
				if (nodeItem == null)
				{
					return null;
				}
				return nodeItem.GetUpSolidLine();
			}
			else if (index >= 12 && index < 18)
			{
				RoverlikeTalentTreeNodeItem nodeItem2 = this.GetNodeItem(index - 12);
				if (nodeItem2 == null)
				{
					return null;
				}
				return nodeItem2.GetDownSolidLine();
			}
			else
			{
				if (index < 6 || index >= 12)
				{
					return null;
				}
				RoverlikeTalentTreeNodeItem nodeItem3 = this.GetNodeItem(index - 6);
				if (nodeItem3 == null)
				{
					return null;
				}
				return nodeItem3.GetMidSolidLine();
			}
		}

		// Token: 0x060407BA RID: 264122 RVA: 0x010865EC File Offset: 0x010847EC
		[NullableContext(2)]
		public UUIItem GetDashedLineByIndexInLineId(int index)
		{
			if (index < 6)
			{
				RoverlikeTalentTreeNodeItem nodeItem = this.GetNodeItem(index);
				if (nodeItem == null)
				{
					return null;
				}
				return nodeItem.GetUpDashedLine();
			}
			else if (index >= 12 && index < 18)
			{
				RoverlikeTalentTreeNodeItem nodeItem2 = this.GetNodeItem(index - 12);
				if (nodeItem2 == null)
				{
					return null;
				}
				return nodeItem2.GetDownDashedLine();
			}
			else
			{
				if (index < 6 || index >= 12)
				{
					return null;
				}
				RoverlikeTalentTreeNodeItem nodeItem3 = this.GetNodeItem(index - 6);
				if (nodeItem3 == null)
				{
					return null;
				}
				return nodeItem3.GetMidDashedLine();
			}
		}

		// Token: 0x04024192 RID: 147858
		private readonly Dictionary<int, Dictionary<string, RoverlikeTalentTreeNodeItem>> NodeItemMap = new Dictionary<int, Dictionary<string, RoverlikeTalentTreeNodeItem>>();

		// Token: 0x04024193 RID: 147859
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly RoverlikeTalentTreeNodeItem[] ActiveItems = new RoverlikeTalentTreeNodeItem[6];

		// Token: 0x0200C4C1 RID: 50369
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403C911 RID: 248081
			public const int Node1 = 0;

			// Token: 0x0403C912 RID: 248082
			public const int Node2 = 1;

			// Token: 0x0403C913 RID: 248083
			public const int Node3 = 2;

			// Token: 0x0403C914 RID: 248084
			public const int Node4 = 3;

			// Token: 0x0403C915 RID: 248085
			public const int Node5 = 4;

			// Token: 0x0403C916 RID: 248086
			public const int Node6 = 5;
		}
	}
}
