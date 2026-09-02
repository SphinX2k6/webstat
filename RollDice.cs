using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02001312 RID: 4882
[NullableContext(2)]
[Nullable(0)]
public class RollDice
{
	// Token: 0x060084D5 RID: 34005 RVA: 0x002302DC File Offset: 0x0022E4DC
	[NullableContext(1)]
	private RollDice(IRollDiceParam param)
	{
		this.Param = param;
	}

	// Token: 0x060084D6 RID: 34006 RVA: 0x002302FE File Offset: 0x0022E4FE
	[NullableContext(1)]
	public static RollDice Create(IRollDiceParam param)
	{
		return new RollDice(param);
	}

	// Token: 0x060084D7 RID: 34007 RVA: 0x00230308 File Offset: 0x0022E508
	public UniTask Run()
	{
		RollDice.<Run>d__14 <Run>d__;
		<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Run>d__.<>4__this = this;
		<Run>d__.<>1__state = -1;
		<Run>d__.<>t__builder.Start<RollDice.<Run>d__14>(ref <Run>d__);
		return <Run>d__.<>t__builder.Task;
	}

	// Token: 0x060084D8 RID: 34008 RVA: 0x0023034C File Offset: 0x0022E54C
	private void UpdateDiceParameter()
	{
		IRollDiceParam param = this.Param;
		Action timerRemove = this.TimerRemove;
		if (timerRemove != null)
		{
			timerRemove();
		}
		this.ProcessName = FNameUtil.GetDynamicFName("Ani_Process").Value;
		this.UpdateProgress(((param != null) ? param.AniProcess : null).GetValueOrDefault());
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.DiceMaterialParameterCollection, FNameUtil.GetDynamicFName("DiceNub").Value, (float)((param != null) ? param.DicePoints.Length : 0));
		int num = ((param != null) ? param.AniNum : null) ?? this.AniCount;
		int num2 = (int)Math.Floor((double)((float)(Random.Shared.NextDouble() * (double)num)));
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.DiceMaterialParameterCollection, FNameUtil.GetDynamicFName("Ani_Num").Value, (float)num2);
		if (((param != null) ? param.DicePoints : null) != null)
		{
			for (int i = 0; i < param.DicePoints.Length; i++)
			{
				int num3 = param.DicePoints[i];
				this.UpdateDicePoint(num3, i);
			}
		}
	}

	// Token: 0x060084D9 RID: 34009 RVA: 0x0023048C File Offset: 0x0022E68C
	public void UpdateSceneBind()
	{
		IRollDiceParam param = this.Param;
		if (((param != null) ? param.BpDiceCase : null) != null)
		{
			this.DiceOutlineBp = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(this.Param.BpDiceCase).Value, ECollectActorType.UI) as BP_DiceOL_C);
		}
		IRollDiceParam param2 = this.Param;
		if (((param2 != null) ? param2.DiceCameraCase : null) != null)
		{
			this.DiceCamera = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(this.Param.DiceCameraCase).Value, ECollectActorType.UI) as ACineCameraActor);
		}
	}

	// Token: 0x060084DA RID: 34010 RVA: 0x00230514 File Offset: 0x0022E714
	public void UpdateDicePoint(int num, int index = 0)
	{
		UObject world = GlobalData.GameInstance.GetWorld();
		UMaterialParameterCollection diceMaterialParameterCollection = this.DiceMaterialParameterCollection;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
		defaultInterpolatedStringHandler.AppendLiteral("DicePoints_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(index + 1);
		UKismetMaterialLibrary.SetScalarParameterValue(world, diceMaterialParameterCollection, FNameUtil.GetDynamicFName(defaultInterpolatedStringHandler.ToStringAndClear()).Value, (float)num);
	}

	// Token: 0x060084DB RID: 34011 RVA: 0x0023056C File Offset: 0x0022E76C
	private void UpdateProgress(float process)
	{
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.DiceMaterialParameterCollection, this.ProcessName, process);
	}

	// Token: 0x060084DC RID: 34012 RVA: 0x0023058C File Offset: 0x0022E78C
	private void OnTick(float deltaTime)
	{
		this.TickTime += deltaTime;
		if (this.TickTime >= this.TickMaxTime)
		{
			this.TickEnd();
			return;
		}
		float process = this.TickTime / this.TickMaxTime;
		this.UpdateProgress(process);
	}

	// Token: 0x060084DD RID: 34013 RVA: 0x002305D1 File Offset: 0x0022E7D1
	public void TimerSystemCreate()
	{
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTick), 20f, 1f, null, null, true);
	}

	// Token: 0x060084DE RID: 34014 RVA: 0x002305FC File Offset: 0x0022E7FC
	public void TimerSystemRemove()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x060084DF RID: 34015 RVA: 0x0023061E File Offset: 0x0022E81E
	public void FlowSystemCreate()
	{
		this.TimerHandle = TimerSystem.FlowTimeInstance.Forever(new TTimerAction(this.OnTick), 20f, 1f, null, null, true);
	}

	// Token: 0x060084E0 RID: 34016 RVA: 0x00230649 File Offset: 0x0022E849
	public void FlowSystemRemove()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.FlowTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x060084E1 RID: 34017 RVA: 0x0023066B File Offset: 0x0022E86B
	private void TickEnd()
	{
		Action timerRemove = this.TimerRemove;
		if (timerRemove != null)
		{
			timerRemove();
		}
		CustomPromise promise = this.Promise;
		if (promise != null)
		{
			promise.SetResult();
		}
		this.Promise = null;
	}

	// Token: 0x060084E2 RID: 34018 RVA: 0x00230696 File Offset: 0x0022E896
	public void TickStart()
	{
		this.TickTime = 0f;
		Action timerCreate = this.TimerCreate;
		if (timerCreate == null)
		{
			return;
		}
		timerCreate();
	}

	// Token: 0x04003EFB RID: 16123
	[Nullable(1)]
	private UMaterialParameterCollection DiceMaterialParameterCollection;

	// Token: 0x04003EFC RID: 16124
	public CustomPromise Promise;

	// Token: 0x04003EFD RID: 16125
	private TimerHandle TimerHandle;

	// Token: 0x04003EFE RID: 16126
	private readonly float TickMaxTime = 5000f;

	// Token: 0x04003EFF RID: 16127
	private readonly int AniCount = 10;

	// Token: 0x04003F00 RID: 16128
	private float TickTime;

	// Token: 0x04003F01 RID: 16129
	private FName ProcessName;

	// Token: 0x04003F02 RID: 16130
	public Action TimerCreate;

	// Token: 0x04003F03 RID: 16131
	public Action TimerRemove;

	// Token: 0x04003F04 RID: 16132
	public IRollDiceParam Param;

	// Token: 0x04003F05 RID: 16133
	public BP_DiceOL_C DiceOutlineBp;

	// Token: 0x04003F06 RID: 16134
	public ACineCameraActor DiceCamera;
}
