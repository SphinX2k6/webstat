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

// Token: 0x02001D26 RID: 7462
[NullableContext(1)]
[Nullable(0)]
public class KurotatoTreasureBoxTrackedMarker : UiPanelBase
{
	// Token: 0x0600DB8C RID: 56204 RVA: 0x003AFCA0 File Offset: 0x003ADEA0
	public KurotatoTreasureBoxTrackedMarker(int entityId)
	{
		this.TrackedEntityId = entityId;
		PotatoSubModel potatoSubModel = ControllerBase<KuroSimpleCombatController>.Instance.GetSubModel(EKscGameplayType.Potato) as PotatoSubModel;
		this.TrackedEntity = potatoSubModel.KscEntities.GetValueOrDefault(entityId);
		this.ScreenPosition = Vector2D.Create();
		this.LastScreenPosition = Vector2D.Create();
		this.TempRotator = new Rotator();
		UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
		this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
		this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
	}

	// Token: 0x0600DB8D RID: 56205 RVA: 0x003AFD7E File Offset: 0x003ADF7E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600DB8E RID: 56206 RVA: 0x003AFDA1 File Offset: 0x003ADFA1
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

	// Token: 0x0600DB8F RID: 56207 RVA: 0x003AFDDC File Offset: 0x003ADFDC
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		if (this.HasHidden)
		{
			base.SetUiActive(false);
			return;
		}
		LevelSequencePlayer animSequencePlayer = this.AnimSequencePlayer;
		if (animSequencePlayer != null && animSequencePlayer.IsPlayingSequence("Close"))
		{
			this.AnimSequencePlayer.StopSequenceByKey("Close", false, false);
		}
		LevelSequencePlayer animSequencePlayer2 = this.AnimSequencePlayer;
		if (animSequencePlayer2 == null)
		{
			return;
		}
		animSequencePlayer2.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600DB90 RID: 56208 RVA: 0x003AFE49 File Offset: 0x003AE049
	protected override void OnBeforeShow()
	{
		this.TickEnabled = true;
	}

	// Token: 0x0600DB91 RID: 56209 RVA: 0x003AFE52 File Offset: 0x003AE052
	protected override void OnBeforeHide()
	{
		this.TickEnabled = false;
	}

	// Token: 0x0600DB92 RID: 56210 RVA: 0x003AFE5C File Offset: 0x003AE05C
	public UniTask CreateByPoolResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
	{
		KurotatoTreasureBoxTrackedMarker.<CreateByPoolResourceIdAsync>d__29 <CreateByPoolResourceIdAsync>d__;
		<CreateByPoolResourceIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateByPoolResourceIdAsync>d__.<>4__this = this;
		<CreateByPoolResourceIdAsync>d__.resourceId = resourceId;
		<CreateByPoolResourceIdAsync>d__.parentItem = parentItem;
		<CreateByPoolResourceIdAsync>d__.<>1__state = -1;
		<CreateByPoolResourceIdAsync>d__.<>t__builder.Start<KurotatoTreasureBoxTrackedMarker.<CreateByPoolResourceIdAsync>d__29>(ref <CreateByPoolResourceIdAsync>d__);
		return <CreateByPoolResourceIdAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB93 RID: 56211 RVA: 0x003AFEB0 File Offset: 0x003AE0B0
	private UniTask CreatePoolActorAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
	{
		KurotatoTreasureBoxTrackedMarker.<CreatePoolActorAsync>d__30 <CreatePoolActorAsync>d__;
		<CreatePoolActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePoolActorAsync>d__.<>4__this = this;
		<CreatePoolActorAsync>d__.resourceId = resourceId;
		<CreatePoolActorAsync>d__.parentItem = parentItem;
		<CreatePoolActorAsync>d__.<>1__state = -1;
		<CreatePoolActorAsync>d__.<>t__builder.Start<KurotatoTreasureBoxTrackedMarker.<CreatePoolActorAsync>d__30>(ref <CreatePoolActorAsync>d__);
		return <CreatePoolActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB94 RID: 56212 RVA: 0x003AFF03 File Offset: 0x003AE103
	public void Recycle()
	{
		Singleton<UiActorPool>.Instance.RecycleAsync(this.MarkerActor, this.ResourceId);
	}

	// Token: 0x0600DB95 RID: 56213 RVA: 0x003AFF1C File Offset: 0x003AE11C
	public void DelayRecycle()
	{
		LevelSequencePlayer animSequencePlayer = this.AnimSequencePlayer;
		if (animSequencePlayer != null && animSequencePlayer.IsPlayingSequence("Start"))
		{
			this.AnimSequencePlayer.StopSequenceByKey("Start", false, false);
		}
		else
		{
			LevelSequencePlayer animSequencePlayer2 = this.AnimSequencePlayer;
			if (animSequencePlayer2 != null && animSequencePlayer2.IsPlayingSequence("Close"))
			{
				return;
			}
		}
		LevelSequencePlayer animSequencePlayer3 = this.AnimSequencePlayer;
		if (animSequencePlayer3 == null)
		{
			return;
		}
		animSequencePlayer3.PlayOrReplaySequenceByName("Close", false, null);
	}

	// Token: 0x0600DB96 RID: 56214 RVA: 0x003AFF90 File Offset: 0x003AE190
	public void OnTick(float deltaTime)
	{
		if (!this.TickEnabled || this.HasHidden)
		{
			return;
		}
		this.ElapsedMs += deltaTime;
		if (this.ElapsedMs >= 3000f)
		{
			base.SetUiActive(false);
			this.HasHidden = true;
			return;
		}
		if (Global.CharacterController == null || this.TrackedEntity == null)
		{
			return;
		}
		if (!this.TrackedEntity.Valid)
		{
			base.SetUiActive(false);
			this.HasHidden = true;
			return;
		}
		this.UpdateTargetPosition(this.TrackedEntity.KscEntity.D_K2_GetActorLocation());
	}

	// Token: 0x0600DB97 RID: 56215 RVA: 0x003B001C File Offset: 0x003AE21C
	public void UpdateTargetPosition(FVectorDouble targetPosition)
	{
		TsCharacterController characterController = Global.CharacterController;
		bool flag = UGameplayStatics.D_ProjectWorldToScreen(characterController, targetPosition, ref this.ScreenPositionRef, false);
		if (!flag)
		{
			FTransformDouble? cameraTransform = ModelBase<CameraModel>.Instance.MainModel.CameraTransform;
			FVectorDouble fvectorDouble = cameraTransform.Value.InverseTransformPositionNoScale(targetPosition);
			fvectorDouble.X = -fvectorDouble.X;
			FVectorDouble fvectorDouble2 = cameraTransform.Value.TransformPositionNoScale(fvectorDouble);
			UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble2, ref this.ScreenPositionRef, false);
		}
		this.ScreenPosition.Set((double)this.ScreenPositionRef.X, (double)this.ScreenPositionRef.Y);
		if (!this.LastScreenPosition.Equals(this.ScreenPosition, 1.0))
		{
			this.LastScreenPosition.DeepCopy(this.ScreenPosition);
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			this.ScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(this.PointTransport);
			bool flag2 = this.ClampToEllipse(this.ScreenPosition, flag);
			this.RootItem.SetAnchorOffset(this.ScreenPosition.ToUeVector2D(false));
			if (!flag2)
			{
				this.TempRotator.Reset();
				this.TempRotator.Yaw = (float)(Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.2957763671875 - 90.0);
				UUIItem directionArrow = this.DirectionArrow;
				FRotator frotator = this.TempRotator.ToUeRotator();
				directionArrow.SetUIRelativeRotation(frotator);
				base.SetUiActive(true);
				return;
			}
			base.SetUiActive(false);
			this.HasHidden = true;
		}
	}

	// Token: 0x0600DB98 RID: 56216 RVA: 0x003B01B8 File Offset: 0x003AE3B8
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

	// Token: 0x040068E4 RID: 26852
	private const float MAX_A = 1176f;

	// Token: 0x040068E5 RID: 26853
	private const float MARGIN_A = 1008f;

	// Token: 0x040068E6 RID: 26854
	private const float MAX_B = 712.5f;

	// Token: 0x040068E7 RID: 26855
	private const float MARGIN_B = 495f;

	// Token: 0x040068E8 RID: 26856
	private const float RAD_2_DEG = 57.295776f;

	// Token: 0x040068E9 RID: 26857
	private const float AUTO_HIDE_DELAY_MS = 3000f;

	// Token: 0x040068EA RID: 26858
	[Nullable(2)]
	protected UUIItem DirectionArrow;

	// Token: 0x040068EB RID: 26859
	[Nullable(2)]
	protected UiPoolActor MarkerActor;

	// Token: 0x040068EC RID: 26860
	[Nullable(2)]
	protected string ResourceId;

	// Token: 0x040068ED RID: 26861
	[Nullable(2)]
	protected LevelSequencePlayer AnimSequencePlayer;

	// Token: 0x040068EE RID: 26862
	protected FVector2D ScreenPositionRef;

	// Token: 0x040068EF RID: 26863
	protected int TrackedEntityId;

	// Token: 0x040068F0 RID: 26864
	[Nullable(2)]
	protected KscEntityHandle TrackedEntity;

	// Token: 0x040068F1 RID: 26865
	protected Vector2D ScreenPosition;

	// Token: 0x040068F2 RID: 26866
	protected Vector2D LastScreenPosition;

	// Token: 0x040068F3 RID: 26867
	protected readonly Vector2D PointTransport = new Vector2D(1.0, -1.0);

	// Token: 0x040068F4 RID: 26868
	protected Rotator TempRotator;

	// Token: 0x040068F5 RID: 26869
	protected float LimitA;

	// Token: 0x040068F6 RID: 26870
	protected float LimitB;

	// Token: 0x040068F7 RID: 26871
	protected bool TickEnabled;

	// Token: 0x040068F8 RID: 26872
	protected float ElapsedMs;

	// Token: 0x040068F9 RID: 26873
	protected bool HasHidden;

	// Token: 0x020080A5 RID: 32933
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BC0F RID: 179215
		public const int DirectionArrow = 0;
	}
}
