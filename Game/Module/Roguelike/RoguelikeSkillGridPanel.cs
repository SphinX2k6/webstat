using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A5 RID: 20901
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeSkillGridPanel : UiPanelBase, IGridProxy<List<RogueTalentTree>>
	{
		// Token: 0x17008C8D RID: 35981
		// (get) Token: 0x06035BFA RID: 220154 RVA: 0x00D840D3 File Offset: 0x00D822D3
		// (set) Token: 0x06035BFB RID: 220155 RVA: 0x00D840DB File Offset: 0x00D822DB
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<List<RogueTalentTree>>, List<RogueTalentTree>> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] set; }

		// Token: 0x17008C8E RID: 35982
		// (get) Token: 0x06035BFC RID: 220156 RVA: 0x00D840E4 File Offset: 0x00D822E4
		// (set) Token: 0x06035BFD RID: 220157 RVA: 0x00D840EC File Offset: 0x00D822EC
		public int GridIndex { get; set; }

		// Token: 0x17008C8F RID: 35983
		// (get) Token: 0x06035BFE RID: 220158 RVA: 0x00D840F5 File Offset: 0x00D822F5
		// (set) Token: 0x06035BFF RID: 220159 RVA: 0x00D840FD File Offset: 0x00D822FD
		public int DisplayIndex { get; set; }

		// Token: 0x06035C00 RID: 220160 RVA: 0x00D84108 File Offset: 0x00D82308
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C01 RID: 220161 RVA: 0x00D84192 File Offset: 0x00D82392
		public RoguelikeSkillNode GetNodeByPos(int pos)
		{
			return this.NodeMap[pos];
		}

		// Token: 0x06035C02 RID: 220162 RVA: 0x00D841A0 File Offset: 0x00D823A0
		protected override void OnStart()
		{
		}

		// Token: 0x06035C03 RID: 220163 RVA: 0x00D841A4 File Offset: 0x00D823A4
		public void BuildNode()
		{
			foreach (RogueTalentTree data in this.NodeDataList)
			{
				UUIItem item = base.GetItem(data.Row);
				RoguelikeSkillNode skillNode = new RoguelikeSkillNode(item, data, this.RootItem);
				while (this.NodeMap.Count <= data.Row)
				{
					this.NodeMap.Add(null);
				}
				this.NodeMap[data.Row] = skillNode;
				skillNode.CreateThenShowByResourceIdAsync("RoguelikeSkillNodeB", item, false).ContinueWith(delegate()
				{
					skillNode.Refresh(null);
				});
			}
		}

		// Token: 0x06035C04 RID: 220164 RVA: 0x00D8427C File Offset: 0x00D8247C
		public void Refresh(List<RogueTalentTree> data, bool isSelected, int gridIndex)
		{
			this.NodeDataList = data;
			this.BuildNode();
		}

		// Token: 0x06035C05 RID: 220165 RVA: 0x00D8428B File Offset: 0x00D8248B
		public void Clear()
		{
		}

		// Token: 0x06035C06 RID: 220166 RVA: 0x00D8428D File Offset: 0x00D8248D
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06035C07 RID: 220167 RVA: 0x00D8428F File Offset: 0x00D8248F
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06035C08 RID: 220168 RVA: 0x00D84291 File Offset: 0x00D82491
		public object GetKey(List<RogueTalentTree> data, int gridIndex)
		{
			return null;
		}

		// Token: 0x0401ED85 RID: 126341
		public List<RoguelikeSkillNode> NodeMap = new List<RoguelikeSkillNode>();

		// Token: 0x0401ED86 RID: 126342
		public List<RogueTalentTree> NodeDataList = new List<RogueTalentTree>();

		// Token: 0x0200B17B RID: 45435
		[NullableContext(0)]
		private class ERoguelikeSkillGridPanelDefine
		{
			// Token: 0x040370A9 RID: 225449
			public const int Pos1 = 0;

			// Token: 0x040370AA RID: 225450
			public const int Pos2 = 1;

			// Token: 0x040370AB RID: 225451
			public const int Pos3 = 2;
		}
	}
}
