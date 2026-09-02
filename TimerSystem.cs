using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BEE RID: 3054
[NullableContext(1)]
[Nullable(0)]
public class TimerSystem : IStaticVariableResetter
{
	// Token: 0x170000C8 RID: 200
	// (get) Token: 0x06003285 RID: 12933 RVA: 0x00023584 File Offset: 0x00021784
	public static TimerSystemInstance Instance
	{
		get
		{
			return TimerSystem._instance;
		}
	}

	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x06003286 RID: 12934 RVA: 0x0002358B File Offset: 0x0002178B
	public static TimerSystemInstance RealTimeInstance
	{
		get
		{
			return TimerSystem._realTimeInstance;
		}
	}

	// Token: 0x170000CA RID: 202
	// (get) Token: 0x06003287 RID: 12935 RVA: 0x00023592 File Offset: 0x00021792
	public static TimerSystemInstance FlowTimeInstance
	{
		get
		{
			return TimerSystem._flowTimeInstance;
		}
	}

	// Token: 0x170000CB RID: 203
	// (get) Token: 0x06003288 RID: 12936 RVA: 0x00023599 File Offset: 0x00021799
	public static TimerSystemInstance GameplayTimeInstance
	{
		get
		{
			return TimerSystem._gameplayTimeInstance;
		}
	}

	// Token: 0x06003289 RID: 12937 RVA: 0x000235A0 File Offset: 0x000217A0
	static TimerSystem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TimerSystem.CreateStaticDefaultValue), new Action(TimerSystem.ResetStaticDefaultValue));
	}

	// Token: 0x0600328A RID: 12938 RVA: 0x000235BF File Offset: 0x000217BF
	public static void CreateStaticDefaultValue()
	{
		TimerSystem._instance = new TimerSystemInstance();
		TimerSystem._realTimeInstance = new TimerSystemInstance();
		TimerSystem._flowTimeInstance = new TimerSystemInstance();
		TimerSystem._gameplayTimeInstance = new TimerSystemInstance();
	}

	// Token: 0x0600328B RID: 12939 RVA: 0x000235E9 File Offset: 0x000217E9
	public static void ResetStaticDefaultValue()
	{
		TimerSystem._instance = null;
		TimerSystem._realTimeInstance = null;
		TimerSystem._flowTimeInstance = null;
		TimerSystem._gameplayTimeInstance = null;
	}

	// Token: 0x04000551 RID: 1361
	[Nullable(2)]
	private static TimerSystemInstance _instance;

	// Token: 0x04000552 RID: 1362
	[Nullable(2)]
	private static TimerSystemInstance _realTimeInstance;

	// Token: 0x04000553 RID: 1363
	[Nullable(2)]
	private static TimerSystemInstance _flowTimeInstance;

	// Token: 0x04000554 RID: 1364
	[Nullable(2)]
	private static TimerSystemInstance _gameplayTimeInstance;
}
