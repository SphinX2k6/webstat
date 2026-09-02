using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D7 RID: 9943
[NullableContext(1)]
[Nullable(0)]
public abstract class RacingBetsCommandBase : IDangoDungeonCommand, IStaticVariableResetter
{
	// Token: 0x060139F3 RID: 80371 RVA: 0x00578D7B File Offset: 0x00576F7B
	static RacingBetsCommandBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RacingBetsCommandBase.CreateStaticDefaultValue), new Action(RacingBetsCommandBase.ResetStaticDefaultValue));
	}

	// Token: 0x060139F4 RID: 80372 RVA: 0x00578D9A File Offset: 0x00576F9A
	public RacingBetsCommandBase()
	{
		this.CommandIndex = ++RacingBetsCommandBase.SelfIncrementId;
	}

	// Token: 0x060139F5 RID: 80373 RVA: 0x00578DC0 File Offset: 0x00576FC0
	public static void CreateStaticDefaultValue()
	{
		RacingBetsCommandBase.SelfIncrementId = 0;
	}

	// Token: 0x060139F6 RID: 80374 RVA: 0x00578DC8 File Offset: 0x00576FC8
	public static void ResetStaticDefaultValue()
	{
		RacingBetsCommandBase.SelfIncrementId = 0;
	}

	// Token: 0x170018CB RID: 6347
	// (get) Token: 0x060139F7 RID: 80375 RVA: 0x00578DD0 File Offset: 0x00576FD0
	// (set) Token: 0x060139F8 RID: 80376 RVA: 0x00578DD8 File Offset: 0x00576FD8
	public int CommandIndex { get; set; }

	// Token: 0x170018CC RID: 6348
	// (get) Token: 0x060139F9 RID: 80377
	public abstract ERacingBetsCommandType CommandType { get; }

	// Token: 0x170018CD RID: 6349
	// (get) Token: 0x060139FA RID: 80378 RVA: 0x00578DE1 File Offset: 0x00576FE1
	// (set) Token: 0x060139FB RID: 80379 RVA: 0x00578DE9 File Offset: 0x00576FE9
	public int ActionIndex { get; set; }

	// Token: 0x170018CE RID: 6350
	// (get) Token: 0x060139FC RID: 80380 RVA: 0x00578DF2 File Offset: 0x00576FF2
	// (set) Token: 0x060139FD RID: 80381 RVA: 0x00578DFA File Offset: 0x00576FFA
	public bool IsAborted { get; set; }

	// Token: 0x060139FE RID: 80382 RVA: 0x00578E04 File Offset: 0x00577004
	public UniTask Execute()
	{
		RacingBetsCommandBase.<Execute>d__20 <Execute>d__;
		<Execute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Execute>d__.<>4__this = this;
		<Execute>d__.<>1__state = -1;
		<Execute>d__.<>t__builder.Start<RacingBetsCommandBase.<Execute>d__20>(ref <Execute>d__);
		return <Execute>d__.<>t__builder.Task;
	}

	// Token: 0x060139FF RID: 80383 RVA: 0x00578E47 File Offset: 0x00577047
	public virtual void OnActive()
	{
	}

	// Token: 0x06013A00 RID: 80384 RVA: 0x00578E49 File Offset: 0x00577049
	public virtual void OnDeActive()
	{
	}

	// Token: 0x06013A01 RID: 80385 RVA: 0x00578E4B File Offset: 0x0057704B
	public virtual UniTask OnExecute()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x06013A02 RID: 80386 RVA: 0x00578E52 File Offset: 0x00577052
	public virtual string LogInfo()
	{
		return "RacingBetsCommandBase";
	}

	// Token: 0x06013A03 RID: 80387 RVA: 0x00578E59 File Offset: 0x00577059
	public void PushBulletScreenTimes(List<BulletScreenTimes> bulletScreenTimes)
	{
		this.BulletScreenTimes = bulletScreenTimes;
	}

	// Token: 0x06013A04 RID: 80388 RVA: 0x00578E64 File Offset: 0x00577064
	protected int GetRandomBulletScreen(List<BulletScreenTimes> bulletScreenTimes)
	{
		int num = 0;
		foreach (BulletScreenTimes bulletScreenTimes2 in bulletScreenTimes)
		{
			num += bulletScreenTimes2.Num;
		}
		if (num == 0)
		{
			return 0;
		}
		int num2 = Random.Shared.Next(num);
		foreach (BulletScreenTimes bulletScreenTimes3 in bulletScreenTimes)
		{
			if (num2 < bulletScreenTimes3.Num)
			{
				BulletScreenTimes bulletScreenTimes4 = bulletScreenTimes3;
				int num3 = bulletScreenTimes4.Num;
				bulletScreenTimes4.Num = num3 - 1;
				return bulletScreenTimes3.BulletScreenId;
			}
			num2 -= bulletScreenTimes3.Num;
		}
		return 0;
	}

	// Token: 0x06013A05 RID: 80389 RVA: 0x00578F34 File Offset: 0x00577134
	private void BroadcastBulletScreen()
	{
		List<int> list = new List<int>();
		int randomBulletScreen;
		while ((randomBulletScreen = this.GetRandomBulletScreen(this.BulletScreenTimes)) != 0)
		{
			list.Add(randomBulletScreen);
		}
		if (list.Count <= 0)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>, bool>(EEventName.OnRacingBetsPushBulletScreen, list, false);
	}

	// Token: 0x040098AB RID: 39083
	private static int SelfIncrementId;

	// Token: 0x040098AC RID: 39084
	protected List<BulletScreenTimes> BulletScreenTimes = new List<BulletScreenTimes>();
}
