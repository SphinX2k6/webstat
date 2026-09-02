using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelFlow.Node;

namespace CSharpScript.Game.LevelFlow.Section
{
	// Token: 0x02006F7E RID: 28542
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowSection : IStaticVariableResetter
	{
		// Token: 0x06045125 RID: 282917 RVA: 0x01202E87 File Offset: 0x01201087
		static LevelFlowSection()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelFlowSection.CreateStaticDefaultValue), new Action(LevelFlowSection.ResetStaticDefaultValue));
		}

		// Token: 0x06045126 RID: 282918 RVA: 0x01202EA8 File Offset: 0x012010A8
		public LevelFlowSection(List<LevelFlowNode> nodeList, List<LevelFlowNode> resetNodeList)
		{
			this.ResetNodeList = resetNodeList;
			this.SectionId = LevelFlowSection.SelfIncrementId++;
			this.NodeList = nodeList;
		}

		// Token: 0x06045127 RID: 282919 RVA: 0x01202EFD File Offset: 0x012010FD
		public void BindCompleteCallBack(Action<LevelFlowSection, bool> completeCallBack)
		{
			this.CompleteCallBack = completeCallBack;
		}

		// Token: 0x06045128 RID: 282920 RVA: 0x01202F06 File Offset: 0x01201106
		public void BindResetCompleteCallBack(Action<LevelFlowSection, bool> completeCallBack)
		{
			this.ResetCompleteCallBack = completeCallBack;
		}

		// Token: 0x06045129 RID: 282921 RVA: 0x01202F10 File Offset: 0x01201110
		public void Enter()
		{
			this.NodeSet.Clear();
			foreach (LevelFlowNode levelFlowNode in this.NodeList)
			{
				this.NodeSet.Add(levelFlowNode);
				levelFlowNode.BindCompleteCallBack(new Action<LevelFlowNode, bool>(this.OnNodeComplete));
			}
			foreach (LevelFlowNode levelFlowNode2 in this.NodeSet)
			{
				levelFlowNode2.Enter();
			}
		}

		// Token: 0x0604512A RID: 282922 RVA: 0x01202FC8 File Offset: 0x012011C8
		public void Tick(float deltaTime)
		{
			foreach (LevelFlowNode levelFlowNode in this.NodeSet)
			{
				levelFlowNode.Tick(deltaTime);
			}
		}

		// Token: 0x0604512B RID: 282923 RVA: 0x0120301C File Offset: 0x0120121C
		public void Exit()
		{
			foreach (LevelFlowNode levelFlowNode in this.NodeList)
			{
				levelFlowNode.Exit();
			}
			this.NodeSet.Clear();
			this.NodeList.Clear();
			this.CompleteCallBack = null;
		}

		// Token: 0x0604512C RID: 282924 RVA: 0x0120308C File Offset: 0x0120128C
		public void Reset()
		{
			foreach (LevelFlowNode levelFlowNode in this.NodeList)
			{
				levelFlowNode.Reset();
			}
			this.NodeSet.Clear();
			foreach (LevelFlowNode item in this.ResetNodeList)
			{
				this.NodeSet.Add(item);
			}
			foreach (LevelFlowNode levelFlowNode2 in this.ResetNodeList)
			{
				levelFlowNode2.BindCompleteCallBack(new Action<LevelFlowNode, bool>(this.OnResetNodeComplete));
				levelFlowNode2.Enter();
			}
		}

		// Token: 0x0604512D RID: 282925 RVA: 0x01203180 File Offset: 0x01201380
		private void OnNodeComplete(LevelFlowNode node, bool isSuccess)
		{
			if (isSuccess)
			{
				node.Exit();
				this.NodeSet.Remove(node);
				if (this.NodeSet.Count == 0)
				{
					Action<LevelFlowSection, bool> completeCallBack = this.CompleteCallBack;
					if (completeCallBack == null)
					{
						return;
					}
					completeCallBack(this, true);
				}
				return;
			}
			Action<LevelFlowSection, bool> completeCallBack2 = this.CompleteCallBack;
			if (completeCallBack2 == null)
			{
				return;
			}
			completeCallBack2(this, false);
		}

		// Token: 0x0604512E RID: 282926 RVA: 0x012031D8 File Offset: 0x012013D8
		private void OnResetNodeComplete(LevelFlowNode node, bool isSuccess)
		{
			if (isSuccess)
			{
				node.Exit();
				this.NodeSet.Remove(node);
				if (this.NodeSet.Count == 0)
				{
					foreach (LevelFlowNode levelFlowNode in this.ResetNodeList)
					{
						levelFlowNode.Reset();
					}
					Action<LevelFlowSection, bool> resetCompleteCallBack = this.ResetCompleteCallBack;
					if (resetCompleteCallBack == null)
					{
						return;
					}
					resetCompleteCallBack(this, true);
				}
				return;
			}
			Action<LevelFlowSection, bool> resetCompleteCallBack2 = this.ResetCompleteCallBack;
			if (resetCompleteCallBack2 == null)
			{
				return;
			}
			resetCompleteCallBack2(this, false);
		}

		// Token: 0x0604512F RID: 282927 RVA: 0x01203270 File Offset: 0x01201470
		public static void CreateStaticDefaultValue()
		{
			LevelFlowSection.SelfIncrementId = 0;
		}

		// Token: 0x06045130 RID: 282928 RVA: 0x01203278 File Offset: 0x01201478
		public static void ResetStaticDefaultValue()
		{
			LevelFlowSection.SelfIncrementId = 0;
		}

		// Token: 0x040268B2 RID: 157874
		public readonly int SectionId;

		// Token: 0x040268B3 RID: 157875
		private static int SelfIncrementId;

		// Token: 0x040268B4 RID: 157876
		private readonly List<LevelFlowNode> NodeList = new List<LevelFlowNode>();

		// Token: 0x040268B5 RID: 157877
		private readonly List<LevelFlowNode> ResetNodeList = new List<LevelFlowNode>();

		// Token: 0x040268B6 RID: 157878
		private readonly HashSet<LevelFlowNode> NodeSet = new HashSet<LevelFlowNode>();

		// Token: 0x040268B7 RID: 157879
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<LevelFlowSection, bool> CompleteCallBack;

		// Token: 0x040268B8 RID: 157880
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<LevelFlowSection, bool> ResetCompleteCallBack;
	}
}
