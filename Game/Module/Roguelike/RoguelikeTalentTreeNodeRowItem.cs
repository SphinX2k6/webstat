using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051BE RID: 20926
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeTalentTreeNodeRowItem : GridProxyAbstract<RoguelikeTalentTreeNodeRowData>
	{
		// Token: 0x06035CCE RID: 220366 RVA: 0x00D886A0 File Offset: 0x00D868A0
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

		// Token: 0x06035CCF RID: 220367 RVA: 0x00D8870C File Offset: 0x00D8690C
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeTalentTreeNodeRowItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeTalentTreeNodeRowItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035CD0 RID: 220368 RVA: 0x00D8874F File Offset: 0x00D8694F
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoguelikeTalentLevelUp, new Action<int>(this.OnSkillLevelUp));
		}

		// Token: 0x06035CD1 RID: 220369 RVA: 0x00D8876D File Offset: 0x00D8696D
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeTalentLevelUp, new Action<int>(this.OnSkillLevelUp));
		}

		// Token: 0x06035CD2 RID: 220370 RVA: 0x00D8878C File Offset: 0x00D8698C
		private void OnSkillLevelUp(int skillId)
		{
			foreach (KeyValuePair<int, bool> keyValuePair in ModelBase<RoguelikeModel>.Instance.GetTalentTreeViewModel().LineActiveMap[this.Data.Row])
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int index = num;
				bool flag2 = flag;
				UUIItem lineByIndex = this.GetLineByIndex(index);
				UUIItem uuiitem = lineByIndex;
				bool bUseChangeColor = !flag2;
				FColor? fcolor = new FColor?(lineByIndex.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
				foreach (UUIItem uuiitem2 in this.LineList.GetDotsByIndexInLineId(index))
				{
					UUIItem uuiitem3 = uuiitem2;
					bool bUseChangeColor2 = !flag2;
					fcolor = new FColor?(uuiitem2.changeColor);
					uuiitem3.SetChangeColor(bUseChangeColor2, fcolor);
				}
			}
		}

		// Token: 0x06035CD3 RID: 220371 RVA: 0x00D8888C File Offset: 0x00D86A8C
		public override void Refresh(RoguelikeTalentTreeNodeRowData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.ResetAllLines();
			this.ResetAllNodes();
			this.RefreshAllDots();
			foreach (RoguelikeTalentTreeNodeData roguelikeTalentTreeNodeData in data.NodeList)
			{
				RoguelikeTalentTreeNodeItem nodeItem = this.NodeList.GetNodeItem(roguelikeTalentTreeNodeData.Index);
				if (nodeItem != null)
				{
					nodeItem.SetNodeActive(true);
				}
				RoguelikeTalentTreeNodeItem nodeItem2 = this.NodeList.GetNodeItem(roguelikeTalentTreeNodeData.Index);
				if (nodeItem2 != null)
				{
					nodeItem2.Refresh(roguelikeTalentTreeNodeData);
				}
			}
			RoguelikeTalentTreeViewModel talentTreeViewModel = ModelBase<RoguelikeModel>.Instance.GetTalentTreeViewModel();
			foreach (KeyValuePair<int, bool> keyValuePair in talentTreeViewModel.LineActiveMap[data.Row])
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int num2 = num;
				bool flag2 = flag;
				UUIItem lineByIndex = this.GetLineByIndex(num2);
				UUIItem uuiitem = lineByIndex;
				bool bUseChangeColor = !flag2;
				FColor? fcolor = new FColor?(lineByIndex.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
				lineByIndex.SetUIActive(true);
				foreach (UUIItem uuiitem2 in this.LineList.GetDotsByIndexInLineId(num2))
				{
					int index = RogueTalentTreeDefine.rogueLineIndex2NodeIndex(num2);
					if (!talentTreeViewModel.IsDotVisible(data.Row, index))
					{
						uuiitem2.SetUIActive(false);
					}
					else
					{
						UUIItem uuiitem3 = uuiitem2;
						bool bUseChangeColor2 = !flag2;
						fcolor = new FColor?(uuiitem2.changeColor);
						uuiitem3.SetChangeColor(bUseChangeColor2, fcolor);
						uuiitem2.SetUIActive(true);
					}
				}
			}
		}

		// Token: 0x06035CD4 RID: 220372 RVA: 0x00D88A50 File Offset: 0x00D86C50
		public override object GetKey(RoguelikeTalentTreeNodeRowData data, int displayIndex)
		{
			return data.Row;
		}

		// Token: 0x06035CD5 RID: 220373 RVA: 0x00D88A60 File Offset: 0x00D86C60
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

		// Token: 0x06035CD6 RID: 220374 RVA: 0x00D88AFC File Offset: 0x00D86CFC
		private void ResetAllNodes()
		{
			for (int i = 0; i < 6; i++)
			{
				RoguelikeTalentTreeNodeItem nodeItem = this.NodeList.GetNodeItem(i);
				if (nodeItem != null)
				{
					nodeItem.SetNodeActive(false);
				}
			}
		}

		// Token: 0x06035CD7 RID: 220375 RVA: 0x00D88B30 File Offset: 0x00D86D30
		private void RefreshAllDots()
		{
			foreach (UUIItem uuiitem in this.LineList.GetAllDots())
			{
				uuiitem.SetUIActive(false);
			}
		}

		// Token: 0x06035CD8 RID: 220376 RVA: 0x00D88B88 File Offset: 0x00D86D88
		[NullableContext(2)]
		private UUIItem GetLineByIndex(int index)
		{
			return this.LineList.GetLinesByIndexInLineId(index) ?? this.NodeList.GetLineByIndexInLineId(index);
		}

		// Token: 0x0401EDC6 RID: 126406
		private RoguelikeTalentTreeNodeRowData Data;

		// Token: 0x0401EDC7 RID: 126407
		private RoguelikeTalentTreeNodeGroupItem NodeList;

		// Token: 0x0401EDC8 RID: 126408
		private RoguelikeTalentTreeLineGroupItem LineList;

		// Token: 0x0200B1A3 RID: 45475
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403717E RID: 225662
			public const int ItemNodeList = 0;

			// Token: 0x0403717F RID: 225663
			public const int ItemLineList = 1;
		}
	}
}
