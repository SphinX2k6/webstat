using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E54 RID: 20052
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseTalentTreeRowItem : GridProxyAbstract<TrapDefenseTalentTreeRowData>
	{
		// Token: 0x06033D13 RID: 212243 RVA: 0x00CF4BE4 File Offset: 0x00CF2DE4
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

		// Token: 0x06033D14 RID: 212244 RVA: 0x00CF4C50 File Offset: 0x00CF2E50
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseTalentTreeRowItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseTalentTreeRowItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D15 RID: 212245 RVA: 0x00CF4C94 File Offset: 0x00CF2E94
		public override void Refresh(TrapDefenseTalentTreeRowData data, bool isSelected, int gridIndex)
		{
			this.ResetAllLines();
			this.ResetAllNodes();
			this.RefreshAllDots();
			foreach (TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData in data.NodeList)
			{
				TrapDefenseTalentTreeNodeItem nodeItem = this.NodeList.GetNodeItem(trapDefenseTalentTreeNodeData.Index);
				if (nodeItem != null)
				{
					nodeItem.SetNodeActive(true);
				}
				TrapDefenseTalentTreeNodeItem nodeItem2 = this.NodeList.GetNodeItem(trapDefenseTalentTreeNodeData.Index);
				if (nodeItem2 != null)
				{
					nodeItem2.Refresh(trapDefenseTalentTreeNodeData);
				}
			}
			foreach (KeyValuePair<int, ETrapDefenseTalentTreePathType> keyValuePair in ModelBase<TrapDefenseModel>.Instance.TalentTreeData.LineTypeMap[data.Row])
			{
				int key = keyValuePair.Key;
				ETrapDefenseTalentTreePathType value = keyValuePair.Value;
				ValueTuple<UUIItem, UUIItem>? linesByIndex = this.GetLinesByIndex(key);
				if (linesByIndex != null)
				{
					UUIItem item = linesByIndex.Value.Item1;
					UUIItem item2 = linesByIndex.Value.Item2;
					item.SetUIActive(value == ETrapDefenseTalentTreePathType.Solid);
					item2.SetUIActive(value == ETrapDefenseTalentTreePathType.Dashed);
					foreach (ValueTuple<UUIItem, UUIItem> valueTuple in this.LineList.GetDotsByIndexInLineId(key))
					{
						UUIItem item3 = valueTuple.Item1;
						UUIItem item4 = valueTuple.Item2;
						int index = TrapDefenseDefine.LineIndex2NodeIndex(key);
						if (!ModelBase<TrapDefenseModel>.Instance.TalentTreeData.IsDotVisible(data.Row, index))
						{
							item3.SetUIActive(false);
							item4.SetUIActive(false);
						}
						else if (item3.IsUIActiveInHierarchy())
						{
							item4.SetUIActive(false);
						}
						else
						{
							item3.SetUIActive(value == ETrapDefenseTalentTreePathType.Solid);
							item4.SetUIActive(value == ETrapDefenseTalentTreePathType.Dashed);
						}
					}
				}
			}
		}

		// Token: 0x06033D16 RID: 212246 RVA: 0x00CF4EB0 File Offset: 0x00CF30B0
		public override object GetKey(TrapDefenseTalentTreeRowData data, int displayIndex)
		{
			return data.Row;
		}

		// Token: 0x06033D17 RID: 212247 RVA: 0x00CF4EC0 File Offset: 0x00CF30C0
		private void ResetAllLines()
		{
			List<UUIItem> allLines = this.LineList.GetAllLines();
			for (int i = 0; i < allLines.Count; i++)
			{
				UUIItem uuiitem = allLines[i];
				uuiitem.SetUIActive(false);
				if (i < 8)
				{
					uuiitem.SetStretchRight(-8.5f);
				}
			}
			foreach (UUIItem uuiitem2 in this.NodeList.GetAllLines())
			{
				uuiitem2.SetUIActive(false);
			}
		}

		// Token: 0x06033D18 RID: 212248 RVA: 0x00CF4F54 File Offset: 0x00CF3154
		private void ResetAllNodes()
		{
			for (int i = 0; i < 6; i++)
			{
				TrapDefenseTalentTreeNodeItem nodeItem = this.NodeList.GetNodeItem(i);
				if (nodeItem != null)
				{
					nodeItem.SetNodeActive(false);
				}
			}
		}

		// Token: 0x06033D19 RID: 212249 RVA: 0x00CF4F88 File Offset: 0x00CF3188
		private void RefreshAllDots()
		{
			foreach (UUIItem uuiitem in this.LineList.GetAllDots())
			{
				uuiitem.SetUIActive(false);
			}
		}

		// Token: 0x06033D1A RID: 212250 RVA: 0x00CF4FE0 File Offset: 0x00CF31E0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private ValueTuple<UUIItem, UUIItem>? GetLinesByIndex(int index)
		{
			ValueTuple<UUIItem, UUIItem>? linesByIndexInLineId = this.LineList.GetLinesByIndexInLineId(index);
			if (linesByIndexInLineId != null)
			{
				return linesByIndexInLineId;
			}
			return this.NodeList.GetLinesByIndexInLineId(index);
		}

		// Token: 0x0401DFAD RID: 122797
		private TrapDefenseTalentTreeRowNodeListItem NodeList;

		// Token: 0x0401DFAE RID: 122798
		private TrapDefenseTalentTreeRowLineListItem LineList;

		// Token: 0x0200ADF1 RID: 44529
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04036041 RID: 221249
			public const int ItemNodeList = 0;

			// Token: 0x04036042 RID: 221250
			public const int ItemLineList = 1;
		}
	}
}
