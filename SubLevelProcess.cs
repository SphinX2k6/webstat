using System;

// Token: 0x020034A1 RID: 13473
public abstract class SubLevelProcess
{
	// Token: 0x0601C6B5 RID: 116405 RVA: 0x0088447C File Offset: 0x0088267C
	protected SubLevelProcess(ESubLevelProcessType type)
	{
	}

	// Token: 0x17002670 RID: 9840
	// (get) Token: 0x0601C6B6 RID: 116406 RVA: 0x0088448B File Offset: 0x0088268B
	public ESubLevelProcessType Type { get; } = type;
}
