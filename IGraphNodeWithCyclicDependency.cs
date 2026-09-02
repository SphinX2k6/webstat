using System;
using System.Runtime.CompilerServices;

// Token: 0x020034CD RID: 13517
[NullableContext(1)]
public interface IGraphNodeWithCyclicDependency
{
	// Token: 0x170026CC RID: 9932
	// (get) Token: 0x0601C8FE RID: 116990 RVA: 0x0088FCAC File Offset: 0x0088DEAC
	bool HasCycle
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170026CD RID: 9933
	// (get) Token: 0x0601C8FF RID: 116991
	// (set) Token: 0x0601C900 RID: 116992
	string[] Cycle { get; set; }
}
