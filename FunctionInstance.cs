using System;

// Token: 0x02001CB5 RID: 7349
public class FunctionInstance
{
	// Token: 0x0600D7B2 RID: 55218 RVA: 0x0039AF78 File Offset: 0x00399178
	public FunctionInstance(int flag, EFunctionType functionId)
	{
		this.Flag = flag;
		this.FunctionType = functionId;
		this.IsLockByBehaviorTree = false;
	}

	// Token: 0x0600D7B3 RID: 55219 RVA: 0x0039AF95 File Offset: 0x00399195
	public int GetFunctionId()
	{
		return (int)this.FunctionType;
	}

	// Token: 0x0600D7B4 RID: 55220 RVA: 0x0039AF9D File Offset: 0x0039919D
	public bool GetIsShow()
	{
		return (this.Flag & 1) > 0;
	}

	// Token: 0x0600D7B5 RID: 55221 RVA: 0x0039AFAA File Offset: 0x003991AA
	public bool GetIsOpen()
	{
		return (this.Flag & 2) > 0;
	}

	// Token: 0x0600D7B6 RID: 55222 RVA: 0x0039AFB7 File Offset: 0x003991B7
	public bool GetHasManualShowUi()
	{
		return (this.Flag & 4) > 0;
	}

	// Token: 0x0600D7B7 RID: 55223 RVA: 0x0039AFC4 File Offset: 0x003991C4
	public void SetFlag(int value)
	{
		this.Flag = value;
	}

	// Token: 0x0600D7B8 RID: 55224 RVA: 0x0039AFCD File Offset: 0x003991CD
	public void SetIsLockByBehaviorTree(bool value)
	{
		this.IsLockByBehaviorTree = value;
	}

	// Token: 0x0600D7B9 RID: 55225 RVA: 0x0039AFD6 File Offset: 0x003991D6
	public bool GetIsLockByBehaviorTree()
	{
		return this.IsLockByBehaviorTree;
	}

	// Token: 0x040066B7 RID: 26295
	private readonly EFunctionType FunctionType;

	// Token: 0x040066B8 RID: 26296
	private int Flag;

	// Token: 0x040066B9 RID: 26297
	private bool IsLockByBehaviorTree;
}
