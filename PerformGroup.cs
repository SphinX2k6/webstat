using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200318F RID: 12687
[NullableContext(1)]
[Nullable(0)]
public class PerformGroup : IStaticVariableResetter
{
	// Token: 0x0601A4E3 RID: 107747 RVA: 0x007BF246 File Offset: 0x007BD446
	static PerformGroup()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PerformGroup.CreateStaticDefaultValue), new Action(PerformGroup.ResetStaticDefaultValue));
	}

	// Token: 0x0601A4E4 RID: 107748 RVA: 0x007BF268 File Offset: 0x007BD468
	public void Register(Entity entity)
	{
		this.Entity = entity;
		foreach (PerformAction performAction in this.ActionList)
		{
			performAction.Register(entity);
		}
	}

	// Token: 0x0601A4E5 RID: 107749 RVA: 0x007BF2C0 File Offset: 0x007BD4C0
	public void UnRegister()
	{
		foreach (PerformAction performAction in this.ActionList)
		{
			performAction.UnRegister();
		}
		this.Entity = null;
	}

	// Token: 0x0601A4E6 RID: 107750 RVA: 0x007BF318 File Offset: 0x007BD518
	public void AddAction(PerformAction action)
	{
		this.ActionList.Add(action);
		if (this.Entity != null)
		{
			action.Register(this.Entity);
		}
	}

	// Token: 0x0601A4E7 RID: 107751 RVA: 0x007BF33C File Offset: 0x007BD53C
	public void Start()
	{
		foreach (PerformAction performAction in this.ActionList)
		{
			performAction.Begin();
		}
	}

	// Token: 0x0601A4E8 RID: 107752 RVA: 0x007BF38C File Offset: 0x007BD58C
	public void Tick(double delta)
	{
		foreach (PerformAction performAction in this.ActionList)
		{
			performAction.Tick(delta);
		}
	}

	// Token: 0x0601A4E9 RID: 107753 RVA: 0x007BF3E0 File Offset: 0x007BD5E0
	public void Stop()
	{
		foreach (PerformAction performAction in this.ActionList)
		{
			performAction.End();
		}
	}

	// Token: 0x0601A4EA RID: 107754 RVA: 0x007BF430 File Offset: 0x007BD630
	public static void CreateStaticDefaultValue()
	{
		PerformGroup.IdGenerator = 0;
	}

	// Token: 0x0601A4EB RID: 107755 RVA: 0x007BF438 File Offset: 0x007BD638
	public static void ResetStaticDefaultValue()
	{
		PerformGroup.IdGenerator = 0;
	}

	// Token: 0x0400D40C RID: 54284
	private static int IdGenerator;

	// Token: 0x0400D40D RID: 54285
	public int Id = ++PerformGroup.IdGenerator;

	// Token: 0x0400D40E RID: 54286
	[Nullable(2)]
	public Entity Entity;

	// Token: 0x0400D40F RID: 54287
	public string SwitchKey = "None";

	// Token: 0x0400D410 RID: 54288
	public List<PerformAction> ActionList = new List<PerformAction>();
}
