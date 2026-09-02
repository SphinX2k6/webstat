using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005690 RID: 22160
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueResSkillGridPanel : UiPanelBase, IGridProxy<List<RogueResTalentTree>>
	{
		// Token: 0x1700909D RID: 37021
		// (get) Token: 0x06038720 RID: 231200 RVA: 0x00E4C7A6 File Offset: 0x00E4A9A6
		// (set) Token: 0x06038721 RID: 231201 RVA: 0x00E4C7AE File Offset: 0x00E4A9AE
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<List<RogueResTalentTree>>, List<RogueResTalentTree>> ScrollViewDelegate { [return: Nullable(new byte[]
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

		// Token: 0x1700909E RID: 37022
		// (get) Token: 0x06038722 RID: 231202 RVA: 0x00E4C7B7 File Offset: 0x00E4A9B7
		// (set) Token: 0x06038723 RID: 231203 RVA: 0x00E4C7BF File Offset: 0x00E4A9BF
		public int GridIndex { get; set; }

		// Token: 0x1700909F RID: 37023
		// (get) Token: 0x06038724 RID: 231204 RVA: 0x00E4C7C8 File Offset: 0x00E4A9C8
		// (set) Token: 0x06038725 RID: 231205 RVA: 0x00E4C7D0 File Offset: 0x00E4A9D0
		public int DisplayIndex { get; set; }

		// Token: 0x06038726 RID: 231206 RVA: 0x00E4C7DC File Offset: 0x00E4A9DC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06038727 RID: 231207 RVA: 0x00E4C836 File Offset: 0x00E4AA36
		public RogueResSkillNode GetNodeByPos(int pos)
		{
			return this.NodeMap[pos];
		}

		// Token: 0x06038728 RID: 231208 RVA: 0x00E4C844 File Offset: 0x00E4AA44
		protected override void OnStart()
		{
		}

		// Token: 0x06038729 RID: 231209 RVA: 0x00E4C848 File Offset: 0x00E4AA48
		public void BuildNode()
		{
			foreach (RogueResTalentTree data in this.NodeDataList)
			{
				RogueResSort? config = ConfigRogueResSortById.GetConfig(data.Id, true);
				UUIItem item = base.GetItem(config.Value.Row);
				RogueResSkillNode skillNode = new RogueResSkillNode(item, data, this.RootItem);
				while (this.NodeMap.Count <= config.Value.Row)
				{
					this.NodeMap.Add(null);
				}
				this.NodeMap[config.Value.Row] = skillNode;
				skillNode.CreateThenShowByResourceIdAsync("RoguelikeSkillNodeB", item, false).ContinueWith(delegate()
				{
					skillNode.Refresh(null);
				});
			}
		}

		// Token: 0x0603872A RID: 231210 RVA: 0x00E4C94C File Offset: 0x00E4AB4C
		public void Refresh(List<RogueResTalentTree> data, bool isSelected, int gridIndex)
		{
			this.NodeDataList = data;
			this.BuildNode();
		}

		// Token: 0x0603872B RID: 231211 RVA: 0x00E4C95B File Offset: 0x00E4AB5B
		public void Clear()
		{
		}

		// Token: 0x0603872C RID: 231212 RVA: 0x00E4C95D File Offset: 0x00E4AB5D
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x0603872D RID: 231213 RVA: 0x00E4C95F File Offset: 0x00E4AB5F
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x0603872E RID: 231214 RVA: 0x00E4C961 File Offset: 0x00E4AB61
		public object GetKey(List<RogueResTalentTree> data, int gridIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x04020376 RID: 131958
		public List<RogueResSkillNode> NodeMap = new List<RogueResSkillNode>();

		// Token: 0x04020377 RID: 131959
		public List<RogueResTalentTree> NodeDataList = new List<RogueResTalentTree>();

		// Token: 0x04020378 RID: 131960
		private IGridProxy<List<RogueResTalentTree>> GridProxyImplementation;
	}
}
