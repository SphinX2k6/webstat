using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D40 RID: 7488
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleBattleBuff : UiPanelBase
{
	// Token: 0x0600DCAA RID: 56490 RVA: 0x003B4CB7 File Offset: 0x003B2EB7
	protected virtual string GetResourceId()
	{
		return "MotorcycleBattleBuff";
	}

	// Token: 0x0600DCAB RID: 56491 RVA: 0x003B4CC0 File Offset: 0x003B2EC0
	public void CreateHeadStateView(USceneComponent parentComponent, IBuffGateDesc buffInfo)
	{
		string resourceId = this.GetResourceId();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.CreateByPathAsync(resourcePath, (UUIItem)parentComponent, true).Forget();
		this.BuffInfo = buffInfo;
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("MotorBuffItemOffset");
		if (intArrayConfig != null && intArrayConfig.Count >= 3)
		{
			this.Offset.Set((double)intArrayConfig[0], (double)intArrayConfig[1], (double)intArrayConfig[2]);
		}
	}

	// Token: 0x0600DCAC RID: 56492 RVA: 0x003B4D34 File Offset: 0x003B2F34
	public void UpdateBuffInfo(IBuffGateDesc buffInfo)
	{
		this.BuffInfo = buffInfo;
		if (this.ButtItem != null)
		{
			this.ButtItem.SetDesc(this.BuffInfo);
		}
	}

	// Token: 0x0600DCAD RID: 56493 RVA: 0x003B4D56 File Offset: 0x003B2F56
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600DCAE RID: 56494 RVA: 0x003B4D90 File Offset: 0x003B2F90
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleBattleBuff.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleBattleBuff.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCAF RID: 56495 RVA: 0x003B4DD3 File Offset: 0x003B2FD3
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600DCB0 RID: 56496 RVA: 0x003B4DE8 File Offset: 0x003B2FE8
	protected override void OnBeforeShow()
	{
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		this.IsFree = false;
		this.IsUp = false;
		this.CloseTime = (float)Singleton<Time>.Instance.WorldTimeSeconds + 2000f;
		this.RefreshHeadStateRotation();
	}

	// Token: 0x0600DCB1 RID: 56497 RVA: 0x003B4E4C File Offset: 0x003B304C
	public void SetUp()
	{
		this.IsUp = true;
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlaySequencePurely("Up", false, false, null, null, false);
	}

	// Token: 0x0600DCB2 RID: 56498 RVA: 0x003B4E8C File Offset: 0x003B308C
	protected override UniTask OnBeforeHideAsync()
	{
		MotorcycleBattleBuff.<OnBeforeHideAsync>d__17 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<MotorcycleBattleBuff.<OnBeforeHideAsync>d__17>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCB3 RID: 56499 RVA: 0x003B4ED0 File Offset: 0x003B30D0
	public void Tick()
	{
		if (this.IsFree)
		{
			return;
		}
		if ((float)Singleton<Time>.Instance.WorldTimeSeconds > this.CloseTime)
		{
			this.SetActive(false);
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetCurrentEntity : null;
		if (entityHandle != null && entityHandle.Valid)
		{
			global::Vector actorLocationProxy = entityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy;
			global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			actorLocationProxy.Addition(this.Offset, commonTempVector);
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIRelativeLocation(commonTempVector.ToUeVectorOld());
		}
	}

	// Token: 0x0600DCB4 RID: 56500 RVA: 0x003B4F5C File Offset: 0x003B315C
	protected void RefreshHeadStateRotation()
	{
		Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
		Rotator commonTempRotator = Singleton<MathUtils>.Instance.CommonTempRotator;
		commonTempRotator.Yaw = cameraRotator.Yaw + 90f;
		commonTempRotator.Roll = cameraRotator.Pitch - 90f;
		commonTempRotator.Pitch = 0f;
		UUIItem rootItem = this.RootItem;
		FRotator frotator = commonTempRotator.ToUeRotator();
		rootItem.SetUIRelativeRotation(frotator);
	}

	// Token: 0x040069A4 RID: 27044
	private const int SHOW_DURATION = 2000;

	// Token: 0x040069A5 RID: 27045
	[Nullable(2)]
	private IBuffGateDesc BuffInfo;

	// Token: 0x040069A6 RID: 27046
	[Nullable(2)]
	private MotorcycleBuffItem ButtItem;

	// Token: 0x040069A7 RID: 27047
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040069A8 RID: 27048
	public bool IsFree = true;

	// Token: 0x040069A9 RID: 27049
	public bool IsUp;

	// Token: 0x040069AA RID: 27050
	public float CloseTime;

	// Token: 0x040069AB RID: 27051
	private readonly global::Vector Offset = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x020080D5 RID: 32981
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BD0E RID: 179470
		public const int Self = 0;

		// Token: 0x0402BD0F RID: 179471
		public const int ButtItem = 1;
	}
}
