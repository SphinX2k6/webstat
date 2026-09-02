using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200646C RID: 25708
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeTalentTreeNodeRowItem : GridProxyAbstract<RoverlikeTalentTreeNodeRowData>
	{
		// Token: 0x17009E44 RID: 40516
		// (get) Token: 0x060407CE RID: 264142 RVA: 0x01086C43 File Offset: 0x01084E43
		[Nullable(2)]
		private RoverlikeTalentTreeData TreeData
		{
			[NullableContext(2)]
			get
			{
				RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
				if (currentActivityData == null)
				{
					return null;
				}
				return currentActivityData.TalentTreeData;
			}
		}

		// Token: 0x060407CF RID: 264143 RVA: 0x01086C5C File Offset: 0x01084E5C
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

		// Token: 0x060407D0 RID: 264144 RVA: 0x01086CC8 File Offset: 0x01084EC8
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeTalentTreeNodeRowItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeTalentTreeNodeRowItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060407D1 RID: 264145 RVA: 0x01086D0B File Offset: 0x01084F0B
		public override void Refresh(RoverlikeTalentTreeNodeRowData data, bool isSelected, int gridIndex)
		{
			this.RefreshVersion++;
			this.RefreshInternalAsync(data, this.RefreshVersion).Forget();
		}

		// Token: 0x060407D2 RID: 264146 RVA: 0x01086D30 File Offset: 0x01084F30
		public override UniTask RefreshAsync(RoverlikeTalentTreeNodeRowData data, bool isSelected, int gridIndex)
		{
			RoverlikeTalentTreeNodeRowItem.<RefreshAsync>d__9 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<RoverlikeTalentTreeNodeRowItem.<RefreshAsync>d__9>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060407D3 RID: 264147 RVA: 0x01086D7C File Offset: 0x01084F7C
		private UniTask RefreshInternalAsync(RoverlikeTalentTreeNodeRowData data, int version)
		{
			RoverlikeTalentTreeNodeRowItem.<RefreshInternalAsync>d__10 <RefreshInternalAsync>d__;
			<RefreshInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshInternalAsync>d__.<>4__this = this;
			<RefreshInternalAsync>d__.data = data;
			<RefreshInternalAsync>d__.version = version;
			<RefreshInternalAsync>d__.<>1__state = -1;
			<RefreshInternalAsync>d__.<>t__builder.Start<RoverlikeTalentTreeNodeRowItem.<RefreshInternalAsync>d__10>(ref <RefreshInternalAsync>d__);
			return <RefreshInternalAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060407D4 RID: 264148 RVA: 0x01086DCF File Offset: 0x01084FCF
		public override object GetKey(RoverlikeTalentTreeNodeRowData data, int displayIndex)
		{
			return data.Row;
		}

		// Token: 0x060407D5 RID: 264149 RVA: 0x01086DDC File Offset: 0x01084FDC
		private void ResetAllLines()
		{
			foreach (UUIItem uuiitem in this.LineList.GetAllLines())
			{
				uuiitem.SetUIActive(false);
			}
			foreach (UUIItem uuiitem2 in this.NodeList.GetAllLines())
			{
				uuiitem2.SetUIActive(false);
			}
		}

		// Token: 0x060407D6 RID: 264150 RVA: 0x01086E78 File Offset: 0x01085078
		private void ResetAllNodes()
		{
			for (int i = 0; i < 6; i++)
			{
				RoverlikeTalentTreeNodeItem nodeItem = this.NodeList.GetNodeItem(i);
				if (nodeItem != null)
				{
					nodeItem.SetNodeActive(false);
				}
			}
		}

		// Token: 0x060407D7 RID: 264151 RVA: 0x01086EAC File Offset: 0x010850AC
		private void RefreshAllDots()
		{
			foreach (UUIItem uuiitem in this.LineList.GetAllDots())
			{
				uuiitem.SetUIActive(false);
			}
		}

		// Token: 0x060407D8 RID: 264152 RVA: 0x01086F04 File Offset: 0x01085104
		[NullableContext(2)]
		private UUIItem GetSolidLineByIndex(int index)
		{
			return this.LineList.GetSolidLineByIndexInLineId(index) ?? this.NodeList.GetSolidLineByIndexInLineId(index);
		}

		// Token: 0x060407D9 RID: 264153 RVA: 0x01086F22 File Offset: 0x01085122
		[NullableContext(2)]
		private UUIItem GetDashedLineByIndex(int index)
		{
			return this.LineList.GetDashedLineByIndexInLineId(index) ?? this.NodeList.GetDashedLineByIndexInLineId(index);
		}

		// Token: 0x04024195 RID: 147861
		private RoverlikeTalentTreeNodeGroupItem NodeList;

		// Token: 0x04024196 RID: 147862
		private RoverlikeTalentTreeLineGroupItem LineList;

		// Token: 0x04024197 RID: 147863
		private int RefreshVersion;

		// Token: 0x0200C4C5 RID: 50373
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403C935 RID: 248117
			public const int ItemNodeList = 0;

			// Token: 0x0403C936 RID: 248118
			public const int ItemLineList = 1;
		}
	}
}
