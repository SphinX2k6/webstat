using System;

// Token: 0x02001DFD RID: 7677
public abstract class PendingProcess : IStaticVariableResetter
{
	// Token: 0x0600E2CB RID: 58059 RVA: 0x003D16C4 File Offset: 0x003CF8C4
	static PendingProcess()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PendingProcess.CreateStaticDefaultValue), new Action(PendingProcess.ResetStaticDefaultValue));
	}

	// Token: 0x0600E2CC RID: 58060 RVA: 0x003D16E3 File Offset: 0x003CF8E3
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0600E2CD RID: 58061 RVA: 0x003D16E5 File Offset: 0x003CF8E5
	public static void ResetStaticDefaultValue()
	{
		PendingProcess.Id = 0;
	}

	// Token: 0x0600E2CE RID: 58062 RVA: 0x003D16ED File Offset: 0x003CF8ED
	protected PendingProcess(EProcessType processType)
	{
		this.ProcessType = processType;
		this.ProcessId = ++PendingProcess.Id;
	}

	// Token: 0x04006D0E RID: 27918
	public static int Id;

	// Token: 0x04006D0F RID: 27919
	public int ProcessId;

	// Token: 0x04006D10 RID: 27920
	public bool Finished;

	// Token: 0x04006D11 RID: 27921
	public EProcessType ProcessType;
}
