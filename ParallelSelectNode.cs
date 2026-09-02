using System;
using Aki.TDConfigMgr.Quest;

// Token: 0x02001DCB RID: 7627
public class ParallelSelectNode : LogicNodeBase
{
	// Token: 0x0600E1CC RID: 57804 RVA: 0x003CD310 File Offset: 0x003CB510
	public ParallelSelectNode(int nodeId) : base(nodeId)
	{
	}

	// Token: 0x170011AA RID: 4522
	// (get) Token: 0x0600E1CD RID: 57805 RVA: 0x003CD319 File Offset: 0x003CB519
	public override EBtNode NodeType
	{
		get
		{
			return EBtNode.ParallelSelect;
		}
	}
}
