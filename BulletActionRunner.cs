using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;

// Token: 0x02002D8F RID: 11663
[NullableContext(1)]
[Nullable(0)]
public class BulletActionRunner : IStaticVariableResetter
{
	// Token: 0x0601784C RID: 96332 RVA: 0x00689453 File Offset: 0x00687653
	static BulletActionRunner()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BulletActionRunner.CreateStaticDefaultValue), new Action(BulletActionRunner.ResetStaticDefaultValue));
	}

	// Token: 0x17001F03 RID: 7939
	// (get) Token: 0x0601784D RID: 96333 RVA: 0x0068948B File Offset: 0x0068768B
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private static List<Stat> ActionStatList
	{
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		get
		{
			return BulletActionRunner._actionStatList;
		}
	}

	// Token: 0x0601784E RID: 96334 RVA: 0x00689492 File Offset: 0x00687692
	public void Init()
	{
		this.ActionCenter.Init();
	}

	// Token: 0x0601784F RID: 96335 RVA: 0x0068949F File Offset: 0x0068769F
	public void Clear()
	{
		this.ActionCenter.Clear();
	}

	// Token: 0x06017850 RID: 96336 RVA: 0x006894AC File Offset: 0x006876AC
	public BulletActionCenter GetActionCenter()
	{
		return this.ActionCenter;
	}

	// Token: 0x06017851 RID: 96337 RVA: 0x006894B4 File Offset: 0x006876B4
	public void Pause()
	{
		if (this.State != EBulletActionRunnerState.Idle)
		{
			Singleton<Log>.Instance.Error(ELogModule.Temp, ELogAuthor.CFT, "当前不是空闲状态，不允许暂停", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.State = EBulletActionRunnerState.Pause;
	}

	// Token: 0x06017852 RID: 96338 RVA: 0x006894EC File Offset: 0x006876EC
	public void Resume()
	{
		if (this.State != EBulletActionRunnerState.Pause)
		{
			Singleton<Log>.Instance.Error(ELogModule.Temp, ELogAuthor.CFT, "当前不是暂停状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.State = EBulletActionRunnerState.Idle;
	}

	// Token: 0x06017853 RID: 96339 RVA: 0x00689528 File Offset: 0x00687728
	public void Run(float delta = 0f, bool isAfterTick = false)
	{
		if (this.State != EBulletActionRunnerState.Idle)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "当前不是空闲状态，不允许切换到运行状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.State = EBulletActionRunnerState.Running;
		OrderedDictionary<int, BulletEntity> bulletEntityMap = ModelBase<BulletModel>.Instance.GetBulletEntityMap();
		if (delta > 0f)
		{
			this.BulletInfoList.Clear();
			this.NextBulletInfoList.Clear();
			foreach (BulletEntity bulletEntity in bulletEntityMap.Values)
			{
				BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
				this.BulletInfoList.Add(bulletInfo);
			}
		}
		this.RunCurBulletInfoList(delta, isAfterTick);
		this.BulletInfoList.Clear();
		while (this.NextBulletInfoList.Count > 0)
		{
			List<BulletInfo> bulletInfoList = this.BulletInfoList;
			this.BulletInfoList = this.NextBulletInfoList;
			this.NextBulletInfoList = bulletInfoList;
			this.RunCurBulletInfoList(0f, false);
			this.BulletInfoList.Clear();
		}
		this.State = EBulletActionRunnerState.ClearBullet;
		ModelBase<BulletModel>.Instance.ClearDestroyedBullets();
		this.State = EBulletActionRunnerState.Idle;
	}

	// Token: 0x06017854 RID: 96340 RVA: 0x00689648 File Offset: 0x00687848
	private unsafe void RunCurBulletInfoList(float delta = 0f, bool isAfterTick = false)
	{
		double num = 0.0;
		BulletActionCenter actionCenter = this.ActionCenter;
		foreach (BulletInfo bulletInfo in this.BulletInfoList)
		{
			if (Singleton<PerformanceController>.Instance.IsEntityTickPerformanceTest)
			{
				num = KuroTime.GetMilliseconds64();
			}
			try
			{
				this.CurRunningBulletInfo = bulletInfo;
				if (delta > 0f)
				{
					List<BulletActionBase> persistentActionList = bulletInfo.PersistentActionList;
					if (!isAfterTick)
					{
						using (List<BulletActionBase>.Enumerator enumerator2 = persistentActionList.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								BulletActionBase bulletActionBase = enumerator2.Current;
								bulletActionBase.Tick(delta);
							}
							goto IL_BF;
						}
					}
					foreach (BulletActionBase bulletActionBase2 in persistentActionList)
					{
						bulletActionBase2.AfterTick(delta);
					}
					IL_BF:
					for (int i = persistentActionList.Count - 1; i >= 0; i--)
					{
						BulletActionBase bulletActionBase3 = persistentActionList[i];
						if (bulletActionBase3.IsFinish)
						{
							persistentActionList.RemoveAt(i);
							actionCenter.RecycleBulletAction(bulletActionBase3);
						}
					}
				}
				while (bulletInfo.ActionInfoList.Count > 0 || bulletInfo.NextActionInfoList.Count > 0)
				{
					foreach (BulletActionInfoBase bulletActionInfoBase in bulletInfo.ActionInfoList)
					{
						BulletActionBase bulletActionBase4 = actionCenter.CreateBulletAction(bulletActionInfoBase.Type);
						if (Singleton<BulletConstant>.Instance.OpenActionStat)
						{
							bulletActionBase4.Execute(bulletInfo, bulletActionInfoBase);
						}
						else
						{
							bulletActionBase4.Execute(bulletInfo, bulletActionInfoBase);
						}
						if (!bulletActionBase4.IsInPool)
						{
							if (bulletActionBase4.IsFinish)
							{
								actionCenter.RecycleBulletAction(bulletActionBase4);
							}
							else
							{
								bulletInfo.PersistentActionList.Add(bulletActionBase4);
							}
						}
						else
						{
							actionCenter.RecycleBulletAction(bulletActionBase4);
						}
					}
					bulletInfo.SwapActionInfoList();
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Bullet;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "Run BulletAction Error";
				Exception error = ex;
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BulletEntityId", bulletInfo.BulletEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BulletRowName", bulletInfo.BulletRowName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			if (Singleton<PerformanceController>.Instance.IsEntityTickPerformanceTest)
			{
				Singleton<PerformanceController>.Instance.CollectTickPerformanceInfo("Bullet", false, KuroTime.GetMilliseconds64() - num, EMeasureMode.Tick, bulletInfo.BornFrameCount);
			}
		}
		this.CurRunningBulletInfo = null;
	}

	// Token: 0x06017855 RID: 96341 RVA: 0x00689974 File Offset: 0x00687B74
	public void AddAction(BulletInfo bulletInfo, BulletActionInfoBase actionInfo)
	{
		switch (this.State)
		{
		case EBulletActionRunnerState.Idle:
			bulletInfo.ActionInfoList.Add(actionInfo);
			this.BulletInfoList.Add(bulletInfo);
			this.Run(0f, false);
			return;
		case EBulletActionRunnerState.Pause:
			bulletInfo.ActionInfoList.Add(actionInfo);
			return;
		case EBulletActionRunnerState.Running:
			bulletInfo.NextActionInfoList.Add(actionInfo);
			if (bulletInfo != this.CurRunningBulletInfo)
			{
				this.NextBulletInfoList.Add(bulletInfo);
				return;
			}
			break;
		case EBulletActionRunnerState.ClearBullet:
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "清理子弹数据期间不允许有新的行为进来，请检查代码逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		default:
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "当前状态异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			break;
		}
	}

	// Token: 0x06017856 RID: 96342 RVA: 0x00689A2D File Offset: 0x00687C2D
	public bool IsRunning()
	{
		return this.State == EBulletActionRunnerState.Running;
	}

	// Token: 0x06017857 RID: 96343 RVA: 0x00689A38 File Offset: 0x00687C38
	public static void InitStat()
	{
		if (!Singleton<BulletConstant>.Instance.OpenActionStat)
		{
			return;
		}
		if (BulletActionRunner.ActionStatList.Count > 0)
		{
			return;
		}
		for (int i = 0; i < 19; i++)
		{
			if (i == 6)
			{
				BulletActionRunner.ActionStatList.Add(Stat.Create("BulletActionInitCollision", "", ""));
			}
			else if (i == 3)
			{
				BulletActionRunner.ActionStatList.Add(Stat.Create("BulletActionInitMove", "", ""));
			}
			else if (i == 7)
			{
				BulletActionRunner.ActionStatList.Add(Stat.Create("BulletActionUpdateEffect", "", ""));
			}
			else if (i == 13)
			{
				BulletActionRunner.ActionStatList.Add(Stat.Create("BulletActionDestroyBullet", "", ""));
			}
			else if (i == 11)
			{
				BulletActionRunner.ActionStatList.Add(Stat.Create("BulletActionSummonBullet", "", ""));
			}
			else if (Singleton<BulletConstant>.Instance.OpenAllActionStat)
			{
				Stat item = null;
				BulletActionRunner.ActionStatList.Add(item);
			}
			else
			{
				BulletActionRunner.ActionStatList.Add(null);
			}
		}
	}

	// Token: 0x06017858 RID: 96344 RVA: 0x00689B55 File Offset: 0x00687D55
	public static void CreateStaticDefaultValue()
	{
		BulletActionRunner._actionStatList = new List<Stat>();
	}

	// Token: 0x06017859 RID: 96345 RVA: 0x00689B61 File Offset: 0x00687D61
	public static void ResetStaticDefaultValue()
	{
		BulletActionRunner._actionStatList = null;
	}

	// Token: 0x0400B478 RID: 46200
	[StaticVariableRuleIgnore]
	private static readonly Stat RunStat = Stat.Create("BulletActionRunner", "", "");

	// Token: 0x0400B479 RID: 46201
	[Nullable(2)]
	private static List<Stat> _actionStatList;

	// Token: 0x0400B47A RID: 46202
	private readonly BulletActionCenter ActionCenter = new BulletActionCenter();

	// Token: 0x0400B47B RID: 46203
	private EBulletActionRunnerState State;

	// Token: 0x0400B47C RID: 46204
	private List<BulletInfo> BulletInfoList = new List<BulletInfo>();

	// Token: 0x0400B47D RID: 46205
	private List<BulletInfo> NextBulletInfoList = new List<BulletInfo>();

	// Token: 0x0400B47E RID: 46206
	[Nullable(2)]
	private BulletInfo CurRunningBulletInfo;
}
