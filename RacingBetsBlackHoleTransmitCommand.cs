using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.RacingBets;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D5 RID: 9941
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsBlackHoleTransmitCommand : RacingBetsCommandBase
{
	// Token: 0x170018C9 RID: 6345
	// (get) Token: 0x060139E6 RID: 80358 RVA: 0x00578BC6 File Offset: 0x00576DC6
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.BlackHole;
		}
	}

	// Token: 0x060139E7 RID: 80359 RVA: 0x00578BCA File Offset: 0x00576DCA
	public void Init(RacingBetsDangoActionBlackHoleTransmit transmitAction)
	{
		this.TransmitAction = transmitAction;
	}

	// Token: 0x060139E8 RID: 80360 RVA: 0x00578BD4 File Offset: 0x00576DD4
	public override UniTask OnExecute()
	{
		RacingBetsBlackHoleTransmitCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsBlackHoleTransmitCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x060139E9 RID: 80361 RVA: 0x00578C18 File Offset: 0x00576E18
	private UniTask PhaseSink(BaseActorComponent headActorComp, double organZ, [Nullable(2)] Action<float> onProgress = null)
	{
		RacingBetsBlackHoleTransmitCommand.<PhaseSink>d__5 <PhaseSink>d__;
		<PhaseSink>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PhaseSink>d__.<>4__this = this;
		<PhaseSink>d__.headActorComp = headActorComp;
		<PhaseSink>d__.organZ = organZ;
		<PhaseSink>d__.onProgress = onProgress;
		<PhaseSink>d__.<>1__state = -1;
		<PhaseSink>d__.<>t__builder.Start<RacingBetsBlackHoleTransmitCommand.<PhaseSink>d__5>(ref <PhaseSink>d__);
		return <PhaseSink>d__.<>t__builder.Task;
	}

	// Token: 0x060139EA RID: 80362 RVA: 0x00578C74 File Offset: 0x00576E74
	private UniTask PhaseFall(BaseActorComponent headActorComp, double targetZ)
	{
		RacingBetsBlackHoleTransmitCommand.<PhaseFall>d__6 <PhaseFall>d__;
		<PhaseFall>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PhaseFall>d__.<>4__this = this;
		<PhaseFall>d__.headActorComp = headActorComp;
		<PhaseFall>d__.targetZ = targetZ;
		<PhaseFall>d__.<>1__state = -1;
		<PhaseFall>d__.<>t__builder.Start<RacingBetsBlackHoleTransmitCommand.<PhaseFall>d__6>(ref <PhaseFall>d__);
		return <PhaseFall>d__.<>t__builder.Task;
	}

	// Token: 0x060139EB RID: 80363 RVA: 0x00578CC8 File Offset: 0x00576EC8
	private void OnEffectRefresh(int pointId, float value)
	{
		RacingBetsModel instance = ModelBase<RacingBetsModel>.Instance;
		IRacingBetsEffectData racingBetsEffectData = (instance != null) ? instance.GetPointEffectByType(pointId, ERacingBetsEffectType.Default) : null;
		if (racingBetsEffectData == null)
		{
			return;
		}
		int handle = racingBetsEffectData.Handle;
		Singleton<EffectSystem>.Instance.GetNiagaraComponent(handle).SetNiagaraVariableFloat("Dissolve", value);
	}

	// Token: 0x060139EC RID: 80364 RVA: 0x00578D0A File Offset: 0x00576F0A
	public override string LogInfo()
	{
		return "RacingBetsBlackHoleTransmitCommand";
	}

	// Token: 0x040098A9 RID: 39081
	private RacingBetsDangoActionBlackHoleTransmit TransmitAction;
}
