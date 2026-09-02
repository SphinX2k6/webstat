using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E0B RID: 19979
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseTalentTreeViewModel
	{
		// Token: 0x06033AA4 RID: 211620 RVA: 0x00CE949B File Offset: 0x00CE769B
		public static TrapDefenseTalentTreeViewModel Create()
		{
			return new TrapDefenseTalentTreeViewModel();
		}

		// Token: 0x06033AA5 RID: 211621 RVA: 0x00CE94A2 File Offset: 0x00CE76A2
		public void AddDelegateOnNodeSelect(Action<TrapDefenseTalentTreeNodeData, bool> @delegate)
		{
			this.DelegatesOnNodeSelect.Add(@delegate);
		}

		// Token: 0x06033AA6 RID: 211622 RVA: 0x00CE94B0 File Offset: 0x00CE76B0
		public void RemoveDelegateOnNodeSelect(Action<TrapDefenseTalentTreeNodeData, bool> @delegate)
		{
			int num = this.DelegatesOnNodeSelect.IndexOf(@delegate);
			if (num != -1)
			{
				this.DelegatesOnNodeSelect.RemoveAt(num);
			}
		}

		// Token: 0x06033AA7 RID: 211623 RVA: 0x00CE94DA File Offset: 0x00CE76DA
		public void SelectNode(TrapDefenseTalentTreeNodeData node, bool shouldScroll)
		{
			if (node == null || (this.SelectedNode != null && this.SelectedNode.Id == node.Id))
			{
				return;
			}
			this.SelectedNode = node;
			this.NotifyNodeSelect(node, shouldScroll);
		}

		// Token: 0x06033AA8 RID: 211624 RVA: 0x00CE950C File Offset: 0x00CE770C
		private void NotifyNodeSelect(TrapDefenseTalentTreeNodeData node, bool shouldScroll)
		{
			foreach (Action<TrapDefenseTalentTreeNodeData, bool> action in this.DelegatesOnNodeSelect)
			{
				action(node, shouldScroll);
			}
		}

		// Token: 0x06033AA9 RID: 211625 RVA: 0x00CE9560 File Offset: 0x00CE7760
		public void OnViewClose()
		{
			this.DelegatesOnNodeSelect = new List<Action<TrapDefenseTalentTreeNodeData, bool>>();
			this.SelectedNode = null;
		}

		// Token: 0x0401DED3 RID: 122579
		public List<Action<TrapDefenseTalentTreeNodeData, bool>> DelegatesOnNodeSelect = new List<Action<TrapDefenseTalentTreeNodeData, bool>>();

		// Token: 0x0401DED4 RID: 122580
		[Nullable(2)]
		public TrapDefenseTalentTreeNodeData SelectedNode;
	}
}
