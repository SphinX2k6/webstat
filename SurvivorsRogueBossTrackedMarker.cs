using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D81 RID: 7553
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueBossTrackedMarker : UiPanelBase
{
	// Token: 0x0600DE3A RID: 56890 RVA: 0x003BC328 File Offset: 0x003BA528
	public SurvivorsRogueBossTrackedMarker(int entityId)
	{
		this.TrackedEntityId = entityId;
		SurvivorsRogueSubModel survivorsRogueSubModel = ControllerBase<KuroSimpleCombatController>.Instance.GetSubModel(EKscGameplayType.SurvivorsRogue) as SurvivorsRogueSubModel;
		this.TrackedEntity = survivorsRogueSubModel.KscEntities.GetValueOrDefault(entityId);
		this.ScreenPosition = Vector2D.Create();
		this.LastScreenPosition = Vector2D.Create();
		this.TempRotator = new Rotator();
		UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
		this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
		this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
	}

	// Token: 0x0600DE3B RID: 56891 RVA: 0x003BC406 File Offset: 0x003BA606
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600DE3C RID: 56892 RVA: 0x003BC429 File Offset: 0x003BA629
	protected override void OnStart()
	{
		this.DirectionArrow = base.GetItem(0);
		this.AnimSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.AnimSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.Recycle();
			}
		}, false);
	}

	// Token: 0x0600DE3D RID: 56893 RVA: 0x003BC464 File Offset: 0x003BA664
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		if (this.AnimSequencePlayer.IsPlayingSequence("Close"))
		{
			this.AnimSequencePlayer.StopSequenceByKey("Close", false, false);
		}
		this.AnimSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600DE3E RID: 56894 RVA: 0x003BC4B5 File Offset: 0x003BA6B5
	protected override void OnBeforeShow()
	{
		this.TickEnabled = true;
	}

	// Token: 0x0600DE3F RID: 56895 RVA: 0x003BC4BE File Offset: 0x003BA6BE
	protected override void OnBeforeHide()
	{
		this.TickEnabled = false;
	}

	// Token: 0x0600DE40 RID: 56896 RVA: 0x003BC4C8 File Offset: 0x003BA6C8
	public UniTask CreateByPoolResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
	{
		SurvivorsRogueBossTrackedMarker.<CreateByPoolResourceIdAsync>d__27 <CreateByPoolResourceIdAsync>d__;
		<CreateByPoolResourceIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateByPoolResourceIdAsync>d__.<>4__this = this;
		<CreateByPoolResourceIdAsync>d__.resourceId = resourceId;
		<CreateByPoolResourceIdAsync>d__.parentItem = parentItem;
		<CreateByPoolResourceIdAsync>d__.<>1__state = -1;
		<CreateByPoolResourceIdAsync>d__.<>t__builder.Start<SurvivorsRogueBossTrackedMarker.<CreateByPoolResourceIdAsync>d__27>(ref <CreateByPoolResourceIdAsync>d__);
		return <CreateByPoolResourceIdAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE41 RID: 56897 RVA: 0x003BC51C File Offset: 0x003BA71C
	private UniTask CreatePoolActorAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
	{
		SurvivorsRogueBossTrackedMarker.<CreatePoolActorAsync>d__28 <CreatePoolActorAsync>d__;
		<CreatePoolActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePoolActorAsync>d__.<>4__this = this;
		<CreatePoolActorAsync>d__.resourceId = resourceId;
		<CreatePoolActorAsync>d__.parentItem = parentItem;
		<CreatePoolActorAsync>d__.<>1__state = -1;
		<CreatePoolActorAsync>d__.<>t__builder.Start<SurvivorsRogueBossTrackedMarker.<CreatePoolActorAsync>d__28>(ref <CreatePoolActorAsync>d__);
		return <CreatePoolActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE42 RID: 56898 RVA: 0x003BC56F File Offset: 0x003BA76F
	public void Recycle()
	{
		Singleton<UiActorPool>.Instance.RecycleAsync(this.MarkerActor, this.ResourceId);
	}

	// Token: 0x0600DE43 RID: 56899 RVA: 0x003BC588 File Offset: 0x003BA788
	public void DelayRecycle()
	{
		if (this.AnimSequencePlayer.IsPlayingSequence("Start"))
		{
			this.AnimSequencePlayer.StopSequenceByKey("Start", false, false);
		}
		else if (this.AnimSequencePlayer.IsPlayingSequence("Close"))
		{
			return;
		}
		this.AnimSequencePlayer.PlayOrReplaySequenceByName("Close", false, null);
	}

	// Token: 0x0600DE44 RID: 56900 RVA: 0x003BC5E8 File Offset: 0x003BA7E8
	public void OnTick(float deltaTime)
	{
		if (!this.TickEnabled)
		{
			return;
		}
		if (Global.CharacterController == null || this.TrackedEntity == null)
		{
			return;
		}
		AKSC_Entity kscEntity = this.TrackedEntity.KscEntity;
		if (kscEntity == null)
		{
			return;
		}
		this.UpdateTargetPosition(kscEntity.K2_GetActorLocation());
	}

	// Token: 0x0600DE45 RID: 56901 RVA: 0x003BC62C File Offset: 0x003BA82C
	public void UpdateTargetPosition(FVector targetPosition)
	{
		TsCharacterController characterController = Global.CharacterController;
		APlayerController player = characterController;
		FVectorDouble fvectorDouble = targetPosition;
		bool flag = UGameplayStatics.D_ProjectWorldToScreen(player, fvectorDouble, ref this.ScreenPositionRef, false);
		if (!flag)
		{
			FTransformDouble? cameraTransform = ModelBase<CameraModel>.Instance.MainModel.CameraTransform;
			FTransformDouble value = cameraTransform.Value;
			fvectorDouble = targetPosition;
			FVectorDouble fvectorDouble2 = value.InverseTransformPositionNoScale(fvectorDouble);
			fvectorDouble2.X = -fvectorDouble2.X;
			FVectorDouble fvectorDouble3 = cameraTransform.Value.TransformPositionNoScale(fvectorDouble2);
			UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble3, ref this.ScreenPositionRef, false);
		}
		this.ScreenPosition.Set((double)this.ScreenPositionRef.X, (double)this.ScreenPositionRef.Y);
		if (!this.LastScreenPosition.Equals(this.ScreenPosition, 1.0))
		{
			this.LastScreenPosition.DeepCopy(this.ScreenPosition);
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			this.ScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(this.PointTransport);
			this.InRange = this.ClampToEllipse(this.ScreenPosition, flag);
			this.RootItem.SetAnchorOffset(this.ScreenPosition.ToUeVector2D(false));
			if (!this.InRange)
			{
				this.TempRotator.Reset();
				this.TempRotator.Yaw = (float)(Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.2957763671875);
				UUIItem directionArrow = this.DirectionArrow;
				FRotator frotator = this.TempRotator.ToUeRotator();
				directionArrow.SetUIRelativeRotation(frotator);
				base.SetUiActive(true);
				return;
			}
			base.SetUiActive(false);
		}
	}

	// Token: 0x0600DE46 RID: 56902 RVA: 0x003BC7D8 File Offset: 0x003BA9D8
	protected bool ClampToEllipse(Vector2D vector, bool inFront)
	{
		double x = vector.X;
		double y = vector.Y;
		float limitA = this.LimitA;
		float limitB = this.LimitB;
		if (inFront && x * x / (double)(limitA * limitA) + y * y / (double)(limitB * limitB) <= 1.0)
		{
			return true;
		}
		double inB = (double)(limitA * limitB) / Math.Sqrt((double)(limitB * limitB) * x * x + (double)(limitA * limitA) * y * y);
		vector.MultiplyEqual(inB);
		return false;
	}

	// Token: 0x04006AB8 RID: 27320
	private const float MAX_A = 1176f;

	// Token: 0x04006AB9 RID: 27321
	private const float MARGIN_A = 1008f;

	// Token: 0x04006ABA RID: 27322
	private const float MAX_B = 712.5f;

	// Token: 0x04006ABB RID: 27323
	private const float MARGIN_B = 495f;

	// Token: 0x04006ABC RID: 27324
	private const float RAD_2_DEG = 57.295776f;

	// Token: 0x04006ABD RID: 27325
	[Nullable(2)]
	protected UUIItem DirectionArrow;

	// Token: 0x04006ABE RID: 27326
	[Nullable(2)]
	protected UiPoolActor MarkerActor;

	// Token: 0x04006ABF RID: 27327
	[Nullable(2)]
	protected string ResourceId;

	// Token: 0x04006AC0 RID: 27328
	protected LevelSequencePlayer AnimSequencePlayer;

	// Token: 0x04006AC1 RID: 27329
	protected FVector2D ScreenPositionRef;

	// Token: 0x04006AC2 RID: 27330
	protected int TrackedEntityId;

	// Token: 0x04006AC3 RID: 27331
	[Nullable(2)]
	protected KscEntityHandle TrackedEntity;

	// Token: 0x04006AC4 RID: 27332
	protected Vector2D ScreenPosition;

	// Token: 0x04006AC5 RID: 27333
	protected Vector2D LastScreenPosition;

	// Token: 0x04006AC6 RID: 27334
	protected readonly Vector2D PointTransport = new Vector2D(1.0, -1.0);

	// Token: 0x04006AC7 RID: 27335
	protected bool InRange;

	// Token: 0x04006AC8 RID: 27336
	protected Rotator TempRotator;

	// Token: 0x04006AC9 RID: 27337
	protected float LimitA;

	// Token: 0x04006ACA RID: 27338
	protected float LimitB;

	// Token: 0x04006ACB RID: 27339
	protected bool TickEnabled;

	// Token: 0x02008107 RID: 33031
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BDE4 RID: 179684
		public const int DirectionArrow = 0;
	}
}
