using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D1D RID: 7453
[NullableContext(1)]
[Nullable(0)]
public class KurotatoBossTrackedMarker : UiPanelBase
{
	// Token: 0x17001162 RID: 4450
	// (get) Token: 0x0600DAFA RID: 56058 RVA: 0x003ACD20 File Offset: 0x003AAF20
	protected int CurHp
	{
		get
		{
			TMap<EKSC_AttrType, int> attrMap = this.AttrMap;
			int? num = (attrMap != null) ? attrMap.GetValueOrNull(EKSC_AttrType.Life) : null;
			if (num != null && num.GetValueOrDefault() > 0)
			{
				return num.Value;
			}
			return 0;
		}
	}

	// Token: 0x17001163 RID: 4451
	// (get) Token: 0x0600DAFB RID: 56059 RVA: 0x003ACD68 File Offset: 0x003AAF68
	protected int MaxHp
	{
		get
		{
			TMap<EKSC_AttrType, int> attrMap = this.AttrMap;
			int? num = (attrMap != null) ? attrMap.GetValueOrNull(EKSC_AttrType.LifeMax) : null;
			if (num != null && num.GetValueOrDefault() > 0)
			{
				this.LastValidMaxHp = num.Value;
				return num.Value;
			}
			return this.LastValidMaxHp;
		}
	}

	// Token: 0x0600DAFC RID: 56060 RVA: 0x003ACDC0 File Offset: 0x003AAFC0
	public KurotatoBossTrackedMarker(int entityId)
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

	// Token: 0x0600DAFD RID: 56061 RVA: 0x003ACEBB File Offset: 0x003AB0BB
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x0600DAFE RID: 56062 RVA: 0x003ACEF4 File Offset: 0x003AB0F4
	protected override void OnStart()
	{
		this.DirectionArrow = base.GetItem(0);
		this.TextureHpBar = base.GetTexture(1);
		this.HpBarLerpDuration = (float)ConfigCommonParamById.GetIntConfig("KurotatoBossHpBarAttenuateSpeed").Value;
		this.AnimSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.AnimSequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.Recycle();
			}
		}, false);
	}

	// Token: 0x0600DAFF RID: 56063 RVA: 0x003ACF60 File Offset: 0x003AB160
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		if (this.InRange)
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

	// Token: 0x0600DB00 RID: 56064 RVA: 0x003ACFCD File Offset: 0x003AB1CD
	protected override void OnBeforeShow()
	{
		this.TickEnabled = true;
	}

	// Token: 0x0600DB01 RID: 56065 RVA: 0x003ACFD6 File Offset: 0x003AB1D6
	protected override void OnBeforeHide()
	{
		this.TickEnabled = false;
	}

	// Token: 0x0600DB02 RID: 56066 RVA: 0x003ACFE0 File Offset: 0x003AB1E0
	public UniTask CreateByPoolResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
	{
		KurotatoBossTrackedMarker.<CreateByPoolResourceIdAsync>d__39 <CreateByPoolResourceIdAsync>d__;
		<CreateByPoolResourceIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateByPoolResourceIdAsync>d__.<>4__this = this;
		<CreateByPoolResourceIdAsync>d__.resourceId = resourceId;
		<CreateByPoolResourceIdAsync>d__.parentItem = parentItem;
		<CreateByPoolResourceIdAsync>d__.<>1__state = -1;
		<CreateByPoolResourceIdAsync>d__.<>t__builder.Start<KurotatoBossTrackedMarker.<CreateByPoolResourceIdAsync>d__39>(ref <CreateByPoolResourceIdAsync>d__);
		return <CreateByPoolResourceIdAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB03 RID: 56067 RVA: 0x003AD034 File Offset: 0x003AB234
	private UniTask CreatePoolActorAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
	{
		KurotatoBossTrackedMarker.<CreatePoolActorAsync>d__40 <CreatePoolActorAsync>d__;
		<CreatePoolActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePoolActorAsync>d__.<>4__this = this;
		<CreatePoolActorAsync>d__.resourceId = resourceId;
		<CreatePoolActorAsync>d__.parentItem = parentItem;
		<CreatePoolActorAsync>d__.<>1__state = -1;
		<CreatePoolActorAsync>d__.<>t__builder.Start<KurotatoBossTrackedMarker.<CreatePoolActorAsync>d__40>(ref <CreatePoolActorAsync>d__);
		return <CreatePoolActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB04 RID: 56068 RVA: 0x003AD087 File Offset: 0x003AB287
	public void Recycle()
	{
		Singleton<UiActorPool>.Instance.RecycleAsync(this.MarkerActor, this.ResourceId);
	}

	// Token: 0x0600DB05 RID: 56069 RVA: 0x003AD0A0 File Offset: 0x003AB2A0
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

	// Token: 0x0600DB06 RID: 56070 RVA: 0x003AD114 File Offset: 0x003AB314
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
		this.TickHpBar(deltaTime);
	}

	// Token: 0x0600DB07 RID: 56071 RVA: 0x003AD160 File Offset: 0x003AB360
	private void TickHpBar(float delta)
	{
		if (this.AttrMap == null)
		{
			KscEntityHandle trackedEntity = this.TrackedEntity;
			TMap<EKSC_AttrType, int> attrMap;
			if (trackedEntity == null)
			{
				attrMap = null;
			}
			else
			{
				AKSC_Entity kscEntity = trackedEntity.KscEntity;
				if (kscEntity == null)
				{
					attrMap = null;
				}
				else
				{
					UKSC_SkillComp skillComp = kscEntity.GetSkillComp();
					if (skillComp == null)
					{
						attrMap = null;
					}
					else
					{
						UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
						attrMap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
					}
				}
			}
			this.AttrMap = attrMap;
			if (this.AttrMap == null)
			{
				return;
			}
		}
		if (this.MaxHp <= 0)
		{
			return;
		}
		float num = Singleton<MathUtils>.Instance.Clamp((float)this.CurHp / (float)this.MaxHp, 0f, 1f);
		if (this.CurrentBarPercent < 0f)
		{
			this.ApplyBarPercent(num);
			return;
		}
		if (num >= this.CurrentBarPercent)
		{
			if (num != this.CurrentBarPercent)
			{
				this.ApplyBarPercent(num);
			}
			this.HpBarLerpTime = -1f;
			return;
		}
		if (this.HpBarLerpTime < 0f || num != this.TargetBarPercent)
		{
			this.SourceBarPercent = this.CurrentBarPercent;
			this.TargetBarPercent = num;
			this.HpBarLerpTime = 0f;
		}
		this.HpBarLerpTime += delta;
		if (this.HpBarLerpTime >= this.HpBarLerpDuration)
		{
			this.ApplyBarPercent(this.TargetBarPercent);
			this.HpBarLerpTime = -1f;
			return;
		}
		float alpha = this.HpBarLerpTime / this.HpBarLerpDuration;
		this.ApplyBarPercent(Singleton<MathUtils>.Instance.Lerp(this.SourceBarPercent, this.TargetBarPercent, alpha));
	}

	// Token: 0x0600DB08 RID: 56072 RVA: 0x003AD2B7 File Offset: 0x003AB4B7
	private void ApplyBarPercent(float percent)
	{
		this.CurrentBarPercent = percent;
		this.TextureHpBar.SetFillAmount(percent);
	}

	// Token: 0x0600DB09 RID: 56073 RVA: 0x003AD2CC File Offset: 0x003AB4CC
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
				this.TempRotator.Yaw = (float)(Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.2957763671875 - 90.0);
				UUIItem directionArrow = this.DirectionArrow;
				FRotator frotator = this.TempRotator.ToUeRotator();
				directionArrow.SetUIRelativeRotation(frotator);
				base.SetUiActive(true);
				return;
			}
			base.SetUiActive(false);
		}
	}

	// Token: 0x0600DB0A RID: 56074 RVA: 0x003AD480 File Offset: 0x003AB680
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

	// Token: 0x0400687F RID: 26751
	private const float MAX_A = 1176f;

	// Token: 0x04006880 RID: 26752
	private const float MARGIN_A = 1008f;

	// Token: 0x04006881 RID: 26753
	private const float MAX_B = 712.5f;

	// Token: 0x04006882 RID: 26754
	private const float MARGIN_B = 495f;

	// Token: 0x04006883 RID: 26755
	private const float RAD_2_DEG = 57.295776f;

	// Token: 0x04006884 RID: 26756
	[Nullable(2)]
	protected UUIItem DirectionArrow;

	// Token: 0x04006885 RID: 26757
	protected UUITexture TextureHpBar;

	// Token: 0x04006886 RID: 26758
	[Nullable(2)]
	protected UiPoolActor MarkerActor;

	// Token: 0x04006887 RID: 26759
	[Nullable(2)]
	protected string ResourceId;

	// Token: 0x04006888 RID: 26760
	[Nullable(2)]
	protected LevelSequencePlayer AnimSequencePlayer;

	// Token: 0x04006889 RID: 26761
	protected FVector2D ScreenPositionRef;

	// Token: 0x0400688A RID: 26762
	protected int TrackedEntityId;

	// Token: 0x0400688B RID: 26763
	[Nullable(2)]
	protected KscEntityHandle TrackedEntity;

	// Token: 0x0400688C RID: 26764
	protected Vector2D ScreenPosition;

	// Token: 0x0400688D RID: 26765
	protected Vector2D LastScreenPosition;

	// Token: 0x0400688E RID: 26766
	protected readonly Vector2D PointTransport = new Vector2D(1.0, -1.0);

	// Token: 0x0400688F RID: 26767
	protected bool InRange;

	// Token: 0x04006890 RID: 26768
	protected Rotator TempRotator;

	// Token: 0x04006891 RID: 26769
	protected float LimitA;

	// Token: 0x04006892 RID: 26770
	protected float LimitB;

	// Token: 0x04006893 RID: 26771
	protected bool TickEnabled;

	// Token: 0x04006894 RID: 26772
	[Nullable(2)]
	protected TMap<EKSC_AttrType, int> AttrMap;

	// Token: 0x04006895 RID: 26773
	protected int LastValidMaxHp = -1;

	// Token: 0x04006896 RID: 26774
	protected float CurrentBarPercent = -1f;

	// Token: 0x04006897 RID: 26775
	protected float SourceBarPercent;

	// Token: 0x04006898 RID: 26776
	protected float TargetBarPercent;

	// Token: 0x04006899 RID: 26777
	protected float HpBarLerpTime = -1f;

	// Token: 0x0400689A RID: 26778
	protected float HpBarLerpDuration;

	// Token: 0x02008094 RID: 32916
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BBA8 RID: 179112
		public const int DirectionArrow = 0;

		// Token: 0x0402BBA9 RID: 179113
		public const int TextureHpBar = 1;
	}
}
