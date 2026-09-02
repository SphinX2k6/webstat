using System;

// Token: 0x020034CC RID: 13516
public interface IGraphNodeWithNoCyclicDependency
{
	// Token: 0x170026CB RID: 9931
	// (get) Token: 0x0601C8FD RID: 116989 RVA: 0x0088FCA9 File Offset: 0x0088DEA9
	bool HasCycle
	{
		get
		{
			return false;
		}
	}
}
