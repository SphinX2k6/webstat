using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200484B RID: 18507
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemManipulableAdsorbedState : SceneItemManipulableBaseState
	{
		// Token: 0x06030258 RID: 197208 RVA: 0x00BAD46C File Offset: 0x00BAB66C
		public SceneItemManipulableAdsorbedState(SceneItemManipulatableComponent sceneItem) : base(sceneItem)
		{
		}

		// Token: 0x06030259 RID: 197209 RVA: 0x00BAD4CC File Offset: 0x00BAB6CC
		protected override void OnEnter()
		{
			this.SceneItem.ClearCastDestroyTimer();
			this.SceneItem.TryAddTagById(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中"]);
			this.SceneItem.IsCanBeHeld = true;
			base.OpenPhysicsSplit();
			this.PropComp.IsMoving = false;
			if (!FNameUtil.IsNothing(this.SceneItem.ManipulateBaseConfig.待机状态碰撞预设))
			{
				this.SceneItem.ActorComp.GetPrimitiveComponent().SetCollisionProfileName(this.SceneItem.ManipulateBaseConfig.待机状态碰撞预设, true);
			}
			if (!this.IsInit)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CH;
				string message = "被控物进入被吸附状态之前未初始化吸附配置";
				string item = "PbDataId";
				SceneItemManipulatableComponent sceneItem = this.SceneItem;
				int? num;
				if (sceneItem == null)
				{
					num = null;
				}
				else
				{
					SceneItemActorComponent actorComp = sceneItem.ActorComp;
					num = ((actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				}
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.SceneItem.ForceMoving = true;
			this.SceneItem.ResetForceDisplace();
			this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.Kinematic;
			this.AdsorbTimer = 0f;
			this.IsFirst = true;
			Rotator startRot = this.StartRot;
			FRotator actorRotation = this.SceneItem.ActorComp.ActorRotation;
			startRot.DeepCopy(actorRotation);
		}

		// Token: 0x0603025A RID: 197210 RVA: 0x00BAD61C File Offset: 0x00BAB81C
		protected override void OnExit()
		{
			base.OnExit();
			this.SceneItem.ForceMoving = false;
			this.IsInit = false;
		}

		// Token: 0x0603025B RID: 197211 RVA: 0x00BAD638 File Offset: 0x00BAB838
		protected override void OnTick(float delta)
		{
			if (this.IsFirst)
			{
				this.StartLoc.DeepCopy(this.SceneItem.ActorComp.ActorLocationProxy);
				this.IsFirst = false;
			}
			this.AdsorbTimer += delta;
			this.AdsorbTimer = Math.Min(this.AdsorbTimer, this.AdsorptionCurveLength);
			float floatValue = this.AdsorptionCurve.GetFloatValue(this.AdsorbTimer / this.AdsorptionCurveLength);
			Vector.Lerp(this.StartLoc, this.EndLoc, (double)floatValue, this.CurrentLoc);
			Rotator.Lerp(this.StartRot, this.EndRot, floatValue, this.CurrentRot);
			this.SceneItem.ActorComp.SetActorLocationAndRotation(this.CurrentLoc.ToUeVector(false), this.CurrentRot.ToUeRotator(), "[SceneItemOutletComponent.EntityMoveTickHandle]", false, null);
			if (this.AdsorbTimer >= this.AdsorptionCurveLength)
			{
				this.MatchOutlet();
				SceneItemManipulatableComponent sceneItem = this.SceneItem;
				if (sceneItem == null)
				{
					return;
				}
				sceneItem.SetState(SceneItemManipulatableComponent.EManipulatableState.MatchingOutlet, "AdsorbState over time");
			}
		}

		// Token: 0x0603025C RID: 197212 RVA: 0x00BAD740 File Offset: 0x00BAB940
		public void InitAdsorptionConfig([Nullable(2)] UCurveFloat adsorptionCurve, Vector endLoc, Rotator endRot)
		{
			this.IsInit = true;
			this.AdsorptionCurve = adsorptionCurve;
			if (adsorptionCurve != null)
			{
				float num = 0f;
				float adsorptionCurveLength = 0f;
				adsorptionCurve.GetTimeRange(ref num, ref adsorptionCurveLength);
				this.AdsorptionCurveLength = adsorptionCurveLength;
			}
			this.EndLoc.DeepCopy(endLoc);
			this.EndRot.DeepCopy(endRot);
		}

		// Token: 0x0603025D RID: 197213 RVA: 0x00BAD793 File Offset: 0x00BAB993
		private void MatchOutlet()
		{
			this.SceneItem.ActivatedOutlet = this.SceneItem.TargetOutletComponent;
			this.SceneItem.ActivatedOutlet.EntityInSocket = this.SceneItem;
			this.SceneItem.RequestAttachToOutlet();
		}

		// Token: 0x0401BA2E RID: 113198
		private bool IsInit;

		// Token: 0x0401BA2F RID: 113199
		[Nullable(2)]
		private UCurveFloat AdsorptionCurve;

		// Token: 0x0401BA30 RID: 113200
		private float AdsorptionCurveLength;

		// Token: 0x0401BA31 RID: 113201
		private float AdsorbTimer;

		// Token: 0x0401BA32 RID: 113202
		private bool IsFirst = true;

		// Token: 0x0401BA33 RID: 113203
		private readonly Vector StartLoc = Vector.Create();

		// Token: 0x0401BA34 RID: 113204
		private readonly Vector EndLoc = Vector.Create();

		// Token: 0x0401BA35 RID: 113205
		private readonly Vector CurrentLoc = Vector.Create();

		// Token: 0x0401BA36 RID: 113206
		private readonly Rotator StartRot = Rotator.Create();

		// Token: 0x0401BA37 RID: 113207
		private readonly Rotator EndRot = Rotator.Create();

		// Token: 0x0401BA38 RID: 113208
		private readonly Rotator CurrentRot = Rotator.Create();
	}
}
