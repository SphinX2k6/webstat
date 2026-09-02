using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Debug;
using CSharpScript.Core.Common;
using CSharpScript.Game.Effect;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Game.Render.Effect.DebugTools
{
	// Token: 0x0200479C RID: 18332
	[NullableContext(2)]
	[Nullable(0)]
	public class AutoStatEffectDataMgr : IStaticVariableResetter
	{
		// Token: 0x0602F917 RID: 194839 RVA: 0x00B561C5 File Offset: 0x00B543C5
		static AutoStatEffectDataMgr()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(AutoStatEffectDataMgr.CreateStaticDefaultValue), new Action(AutoStatEffectDataMgr.ResetStaticDefaultValue));
		}

		// Token: 0x0602F918 RID: 194840 RVA: 0x00B56200 File Offset: 0x00B54400
		[NullableContext(1)]
		public static AutoStatEffectDataMgr Get()
		{
			if (AutoStatEffectDataMgr._Instance == null)
			{
				AutoStatEffectDataMgr._Instance = new AutoStatEffectDataMgr();
				AutoStatEffectDataMgr.SpawnEffectStat = Stat.Create("AutoStatEffectDataMgr:SpawnEffect", "", "");
				AutoStatEffectDataMgr.UpdateEffectStat = Stat.Create("AutoStatEffectDataMgr:UpdateEffect", "", "");
			}
			return AutoStatEffectDataMgr._Instance;
		}

		// Token: 0x0602F919 RID: 194841 RVA: 0x00B56255 File Offset: 0x00B54455
		public static double GetMicrosecond()
		{
			if (Singleton<Platform>.Instance.IsWindowsPlatform())
			{
				return KuroTime.GetCycles64() * 0.1;
			}
			return KuroTime.GetCycles64();
		}

		// Token: 0x0602F91A RID: 194842 RVA: 0x00B56278 File Offset: 0x00B54478
		private AutoStatEffectDataMgr()
		{
			this.TickId = -1;
		}

		// Token: 0x0602F91B RID: 194843 RVA: 0x00B56288 File Offset: 0x00B54488
		private void Reset()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle, "[AutoStatEffectDataMgr.Reset]", false, null);
				this.EffectHandle = 0;
			}
			this.EffectStats = new List<EffectStatData>();
			this.StateTime = 0f;
			this.State = EPlayEffectState.Waiting;
			this.EffectPlayTime = 0;
			this.IsOpenStatTrace = false;
			this.CurrentEffectPath = null;
			Singleton<EffectGlobal>.Instance.AllowEffectInPool = false;
			Singleton<EffectGlobal>.Instance.AllowEffectOutPool = false;
		}

		// Token: 0x0602F91C RID: 194844 RVA: 0x00B56338 File Offset: 0x00B54538
		public void Play(int inStartIndex = 0, int inEndIndex = -1)
		{
			if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.ZJF, "shipping 包或test 包", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.Reset();
			Singleton<ResourceSystem>.Instance.LoadAsync<PDA_EffectPaths_C>("/Game/Aki/Render/RuntimeBP/Effect/Debug/DA_EffectPaths.DA_EffectPaths", delegate([Nullable(2)] PDA_EffectPaths_C result, string _)
			{
				TArray<string> basePaths = result.BasePaths;
				int num = 0;
				if (inStartIndex > 0 && inStartIndex < basePaths.Num() - 1)
				{
					num = inStartIndex;
				}
				int num2 = basePaths.Num() - 1;
				if (inEndIndex != -1 && inEndIndex < basePaths.Num())
				{
					num2 = inEndIndex;
				}
				this.BasePaths = new List<string>();
				for (int i = num; i <= num2; i++)
				{
					this.BasePaths.Add(basePaths.Get(i));
				}
				this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "PlayEffectOneByOne", ETickingGroup.TG_PrePhysics, false, 0, false).Id;
			}, 100, "js_undefined");
		}

		// Token: 0x0602F91D RID: 194845 RVA: 0x00B563B4 File Offset: 0x00B545B4
		public void PlayWithTrace()
		{
			if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.ZJF, "shipping 包或test 包", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.Reset();
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Stat NamedEvents", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Trace.Start", null);
			this.IsOpenStatTrace = true;
			this.BasePaths = new List<string>();
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "PlayEffectOneByOne", ETickingGroup.TG_PrePhysics, false, 0, false).Id;
		}

		// Token: 0x0602F91E RID: 194846 RVA: 0x00B5644C File Offset: 0x00B5464C
		private void Tick(float delayTime)
		{
			this.UpdateState(delayTime);
		}

		// Token: 0x0602F91F RID: 194847 RVA: 0x00B56458 File Offset: 0x00B54658
		private void UpdateState(float deltaMillionSeconds)
		{
			this.StateTime += deltaMillionSeconds;
			EPlayEffectState state = this.State;
			if (state != EPlayEffectState.Playing)
			{
				if (state != EPlayEffectState.Waiting)
				{
					return;
				}
				if (this.StateTime >= AutoStatEffectDataMgr.EffectWaitingTime)
				{
					this.PlayNext();
					this.ChangeState(EPlayEffectState.Playing);
					this.TickCurrent((double)deltaMillionSeconds);
				}
				return;
			}
			else
			{
				if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle) || this.StateTime >= AutoStatEffectDataMgr.EffectMaxLoopTime)
				{
					this.StopCurrent();
					this.ChangeState(EPlayEffectState.Waiting);
					return;
				}
				this.TickCurrent((double)deltaMillionSeconds);
				return;
			}
		}

		// Token: 0x0602F920 RID: 194848 RVA: 0x00B564DA File Offset: 0x00B546DA
		private void ChangeState(EPlayEffectState state)
		{
			this.State = state;
			this.StateTime = 0f;
		}

		// Token: 0x0602F921 RID: 194849 RVA: 0x00B564F0 File Offset: 0x00B546F0
		private void TickCurrent(double deltaMillionSeconds)
		{
			if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
			{
				return;
			}
			double num = Singleton<PerformanceController>.Instance.ConsumeTickTime("NiagaraDebugTick");
			this.EffectStats[this.EffectStats.Count - 1].UpdateTimeArray.Add(num * 1000.0);
		}

		// Token: 0x0602F922 RID: 194850 RVA: 0x00B56550 File Offset: 0x00B54750
		private void StopCurrent()
		{
			if (Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle, "[AutoStatEffectDataMgr.StopCurrent]", true, null);
				this.EffectHandle = 0;
			}
			this.EffectStats[this.EffectStats.Count - 1].OnStop((double)this.StateTime);
		}

		// Token: 0x0602F923 RID: 194851 RVA: 0x00B565BC File Offset: 0x00B547BC
		private void PlayNext()
		{
			if (this.BasePaths.Count == 0)
			{
				if (this.TickId != -1)
				{
					Singleton<TickSystem>.Instance.Remove(this.TickId);
					this.TickId = -1;
				}
				List<string> list = new List<string>();
				foreach (EffectStatData effectStatData in this.EffectStats)
				{
					list.Add(effectStatData.ToCsv());
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
				defaultInterpolatedStringHandler.AppendFormatted(UKismetSystemLibrary.GetProjectSavedDirectory());
				defaultInterpolatedStringHandler.AppendLiteral("Profiling/");
				defaultInterpolatedStringHandler.AppendFormatted<long>(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
				defaultInterpolatedStringHandler.AppendLiteral("_EffectStats.csv");
				string fileName = defaultInterpolatedStringHandler.ToStringAndClear();
				bool value = UKuroStaticLibrary.SaveStringToFile(EffectStatData.CsvHeader + string.Join("\n", list), fileName, false);
				this.EffectStats.Clear();
				if (this.IsOpenStatTrace)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Trace.Stop", null);
				}
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[保存特效统计信息:");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(value);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				string text = defaultInterpolatedStringHandler.ToStringAndClear();
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ErrorCodeTips);
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					text
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return;
			}
			this.EffectPlayTime++;
			if (this.CurrentEffectPath == null || this.EffectPlayTime > AutoStatEffectDataMgr.EffectMaxPlayTime)
			{
				this.CurrentEffectPath = this.BasePaths[this.BasePaths.Count - 1];
				this.BasePaths.RemoveAt(this.BasePaths.Count - 1);
				this.EffectPlayTime = 1;
			}
			double microsecond = AutoStatEffectDataMgr.GetMicrosecond();
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(baseCharacter.D_GetTransform());
			this.EffectHandle = instance.SpawnEffect(world, ftransformDouble, this.CurrentEffectPath, "[AutoStatEffectDataMgr.PlayNext]", null, EEffectType.Scene, delegate(int h)
			{
				Singleton<EffectSystem>.Instance.DebugUpdate(h, true);
			}, null, null, false, false);
			if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
			{
				return;
			}
			double microsecond2 = AutoStatEffectDataMgr.GetMicrosecond();
			this.EffectStats.Add(new EffectStatData(this.CurrentEffectPath, microsecond2 - microsecond));
		}

		// Token: 0x0602F924 RID: 194852 RVA: 0x00B56830 File Offset: 0x00B54A30
		public static void CreateStaticDefaultValue()
		{
			AutoStatEffectDataMgr.SpawnEffectStat = null;
			AutoStatEffectDataMgr.UpdateEffectStat = null;
			AutoStatEffectDataMgr._Instance = null;
		}

		// Token: 0x0602F925 RID: 194853 RVA: 0x00B56844 File Offset: 0x00B54A44
		public static void ResetStaticDefaultValue()
		{
			AutoStatEffectDataMgr.SpawnEffectStat = null;
			AutoStatEffectDataMgr.UpdateEffectStat = null;
			AutoStatEffectDataMgr._Instance = null;
		}

		// Token: 0x0401B34A RID: 111434
		public int TickId;

		// Token: 0x0401B34B RID: 111435
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> BasePaths;

		// Token: 0x0401B34C RID: 111436
		private int EffectHandle;

		// Token: 0x0401B34D RID: 111437
		private float StateTime;

		// Token: 0x0401B34E RID: 111438
		private EPlayEffectState State;

		// Token: 0x0401B34F RID: 111439
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<EffectStatData> EffectStats;

		// Token: 0x0401B350 RID: 111440
		private int EffectPlayTime;

		// Token: 0x0401B351 RID: 111441
		private string CurrentEffectPath;

		// Token: 0x0401B352 RID: 111442
		private bool IsOpenStatTrace;

		// Token: 0x0401B353 RID: 111443
		private static readonly int EffectMaxPlayTime = 1;

		// Token: 0x0401B354 RID: 111444
		private static readonly float EffectMaxLoopTime = 5000f;

		// Token: 0x0401B355 RID: 111445
		private static readonly float EffectWaitingTime = 1000f;

		// Token: 0x0401B356 RID: 111446
		private static Stat SpawnEffectStat;

		// Token: 0x0401B357 RID: 111447
		private static Stat UpdateEffectStat;

		// Token: 0x0401B358 RID: 111448
		private static AutoStatEffectDataMgr _Instance;

		// Token: 0x0401B359 RID: 111449
		[Nullable(1)]
		private const string EFFECT_PATHS_DA_PATH = "/Game/Aki/Render/RuntimeBP/Effect/Debug/DA_EffectPaths.DA_EffectPaths";
	}
}
