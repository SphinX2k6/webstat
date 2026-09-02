using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.NewWorld.Pawn.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02003012 RID: 12306
[NullableContext(2)]
[Nullable(0)]
public class OnHitMaterialAction
{
	// Token: 0x0601914E RID: 102734 RVA: 0x00720C75 File Offset: 0x0071EE75
	[NullableContext(1)]
	public OnHitMaterialAction(CharRenderingComponent RenderingCompInternal, [Nullable(2)] PawnTimeScaleComponent TimeScaleComp = null)
	{
		this.RenderingCompInternal = RenderingCompInternal;
		this.TimeScaleComp = TimeScaleComp;
	}

	// Token: 0x170021C9 RID: 8649
	// (get) Token: 0x0601914F RID: 102735 RVA: 0x00720C8B File Offset: 0x0071EE8B
	public bool IsPlaying
	{
		get
		{
			return this.IsPlayingInternal;
		}
	}

	// Token: 0x170021CA RID: 8650
	// (get) Token: 0x06019150 RID: 102736 RVA: 0x00720C93 File Offset: 0x0071EE93
	public long BulletId
	{
		get
		{
			return this.BulletIdInternal;
		}
	}

	// Token: 0x170021CB RID: 8651
	// (get) Token: 0x06019151 RID: 102737 RVA: 0x00720C9B File Offset: 0x0071EE9B
	public int AttackerId
	{
		get
		{
			return this.AttackerIdInternal;
		}
	}

	// Token: 0x06019152 RID: 102738 RVA: 0x00720CA3 File Offset: 0x0071EEA3
	public bool IsDelayFinish()
	{
		return this.ElapsedMs >= this.DelayMsInternal;
	}

	// Token: 0x06019153 RID: 102739 RVA: 0x00720CB6 File Offset: 0x0071EEB6
	private bool IsFinish()
	{
		return (float)this.ElapsedMs > this.DurationMsInternal + (float)this.DelayMsInternal;
	}

	// Token: 0x06019154 RID: 102740 RVA: 0x00720CCF File Offset: 0x0071EECF
	public bool ComparePriority(long bulletId, int attackerId)
	{
		return !this.IsBeginInternal || this.AttackerIdInternal == attackerId || ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Id != this.AttackerIdInternal;
	}

	// Token: 0x06019155 RID: 102741 RVA: 0x00720D00 File Offset: 0x0071EF00
	[NullableContext(1)]
	public void Start(string pathDp, int delay, long bulletId, int attackerId, [Nullable(2)] string pathPartDp = null)
	{
		this.IsBeginInternal = true;
		this.PathDpInternal = pathDp;
		this.DurationMsInternal = 1000f;
		this.DelayMsInternal = delay;
		this.BulletIdInternal = bulletId;
		this.AttackerIdInternal = attackerId;
		this.IsPlayingInternal = false;
		this.AssetDpPreload = null;
		this.AssetPartDpPreload = null;
		this.ElapsedMs = 0;
		this.IdInternal++;
		this.StartAsync(this.IdInternal, pathDp, pathPartDp);
		if (!TimerSystem.Instance.Has(this.TimerHandle))
		{
			this.TimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.Loop), 20f, 1f, null, "[OnHitMaterial.Loop]", true);
		}
	}

	// Token: 0x06019156 RID: 102742 RVA: 0x00720DB8 File Offset: 0x0071EFB8
	[NullableContext(1)]
	private UniTask StartAsync(int id, string pathDp, [Nullable(2)] string pathPartDp)
	{
		OnHitMaterialAction.<StartAsync>d__29 <StartAsync>d__;
		<StartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartAsync>d__.<>4__this = this;
		<StartAsync>d__.id = id;
		<StartAsync>d__.pathDp = pathDp;
		<StartAsync>d__.pathPartDp = pathPartDp;
		<StartAsync>d__.<>1__state = -1;
		<StartAsync>d__.<>t__builder.Start<OnHitMaterialAction.<StartAsync>d__29>(ref <StartAsync>d__);
		return <StartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06019157 RID: 102743 RVA: 0x00720E14 File Offset: 0x0071F014
	[NullableContext(1)]
	private UniTask LoadDpAsset(string pathDp, [Nullable(new byte[]
	{
		1,
		2
	})] PD_CharacterControllerData_C[] materialCtrl, int index)
	{
		OnHitMaterialAction.<LoadDpAsset>d__30 <LoadDpAsset>d__;
		<LoadDpAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadDpAsset>d__.pathDp = pathDp;
		<LoadDpAsset>d__.materialCtrl = materialCtrl;
		<LoadDpAsset>d__.index = index;
		<LoadDpAsset>d__.<>1__state = -1;
		<LoadDpAsset>d__.<>t__builder.Start<OnHitMaterialAction.<LoadDpAsset>d__30>(ref <LoadDpAsset>d__);
		return <LoadDpAsset>d__.<>t__builder.Task;
	}

	// Token: 0x06019158 RID: 102744 RVA: 0x00720E68 File Offset: 0x0071F068
	private void Loop(float deltaMs)
	{
		int elapsedMs = this.ElapsedMs;
		PawnTimeScaleComponent timeScaleComp = this.TimeScaleComp;
		this.ElapsedMs = elapsedMs + (int)(deltaMs * ((timeScaleComp != null) ? timeScaleComp.CurrentTimeScale : 1f));
		if (!this.IsPlayingInternal && this.IsDelayFinish())
		{
			this.Play(this.AssetDpPreload, this.AssetPartDpPreload, "OnHitMaterialAction 开始播放");
			return;
		}
		if (this.IsPlayingInternal && this.IsFinish())
		{
			this.Stop(false);
			this.End();
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
			}
			this.TimerHandle = null;
		}
	}

	// Token: 0x06019159 RID: 102745 RVA: 0x00720F00 File Offset: 0x0071F100
	private void Play(UObject assetDp, UObject assetPartDp, [Nullable(1)] string reason = "OnHitMaterialAction 开始播放")
	{
		this.IsPlayingInternal = true;
		if (assetDp != null)
		{
			this.Handle = this.RenderingCompInternal.AddMaterialControllerData(assetDp);
		}
		if (assetPartDp != null)
		{
			this.PartHandle = this.RenderingCompInternal.AddMaterialControllerData(assetPartDp);
		}
	}

	// Token: 0x0601915A RID: 102746 RVA: 0x00720F34 File Offset: 0x0071F134
	public void Stop(bool force = false)
	{
		if (this.Handle != 0)
		{
			this.RenderingCompInternal.RemoveMaterialControllerData(this.Handle);
		}
		if (this.PartHandle != 0)
		{
			this.RenderingCompInternal.RemoveMaterialControllerData(this.PartHandle);
		}
		this.Handle = 0;
		this.PartHandle = 0;
		this.AssetDpPreload = null;
		this.AssetPartDpPreload = null;
		this.IsPlayingInternal = false;
	}

	// Token: 0x0601915B RID: 102747 RVA: 0x00720F96 File Offset: 0x0071F196
	public void End()
	{
		this.IsBeginInternal = false;
	}

	// Token: 0x0400C486 RID: 50310
	private const int MILLIONSECOND_PER_SECOND = 1000;

	// Token: 0x0400C487 RID: 50311
	private const int SECOND_TO_MILLISECOND = 1000;

	// Token: 0x0400C488 RID: 50312
	private TimerHandle TimerHandle;

	// Token: 0x0400C489 RID: 50313
	[Nullable(1)]
	private readonly CharRenderingComponent RenderingCompInternal;

	// Token: 0x0400C48A RID: 50314
	private readonly PawnTimeScaleComponent TimeScaleComp;

	// Token: 0x0400C48B RID: 50315
	private int Handle;

	// Token: 0x0400C48C RID: 50316
	private int PartHandle;

	// Token: 0x0400C48D RID: 50317
	private string PathDpInternal;

	// Token: 0x0400C48E RID: 50318
	private int ElapsedMs;

	// Token: 0x0400C48F RID: 50319
	private float DurationMsInternal;

	// Token: 0x0400C490 RID: 50320
	private int DelayMsInternal;

	// Token: 0x0400C491 RID: 50321
	private bool IsPlayingInternal;

	// Token: 0x0400C492 RID: 50322
	private long BulletIdInternal;

	// Token: 0x0400C493 RID: 50323
	private int AttackerIdInternal;

	// Token: 0x0400C494 RID: 50324
	private UObject AssetDpPreload;

	// Token: 0x0400C495 RID: 50325
	private UObject AssetPartDpPreload;

	// Token: 0x0400C496 RID: 50326
	private bool IsBeginInternal;

	// Token: 0x0400C497 RID: 50327
	private int IdInternal;
}
