using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.TeleControl;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Portal;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Jigsaw;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x02004854 RID: 18516
	public class SceneItemManipulableDrawState : SceneItemManipulableBaseState
	{
		// Token: 0x060302AB RID: 197291 RVA: 0x00BAF54C File Offset: 0x00BAD74C
		[NullableContext(1)]
		public SceneItemManipulableDrawState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase> cameraShake, [Nullable(2)] UKuroForceFeedbackEffect gamepadShake, FGameplayTag subCameraTag) : base(sceneItem)
		{
			this.CameraShake = new TSubclassOf<UCameraShakeBase>?(cameraShake);
			this.GamepadShake = gamepadShake;
			this.SubCameraTag = new FGameplayTag?(subCameraTag);
		}

		// Token: 0x060302AC RID: 197292 RVA: 0x00BAF598 File Offset: 0x00BAD798
		[NullableContext(1)]
		public void SetEnterCallback(Action callback)
		{
			this.EnterCallback = callback;
		}

		// Token: 0x060302AD RID: 197293 RVA: 0x00BAF5A4 File Offset: 0x00BAD7A4
		protected override void OnEnter()
		{
			this.SceneItem.NeedRemoveControllerId = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[CharacterManipulateComp] DrawState OnEnter";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
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
			ptr = new ValueTuple<string, object>(item, num);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "ActivatedOutlet";
			SceneItemOutletComponent activatedOutlet = this.SceneItem.ActivatedOutlet;
			ptr2 = new ValueTuple<string, object>(item2, (activatedOutlet != null) ? new bool?(activatedOutlet.Valid) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			SceneItemOutletComponent activatedOutlet2 = this.SceneItem.ActivatedOutlet;
			if (activatedOutlet2 != null && activatedOutlet2.Valid && this.SceneItem.MatchSequence != null)
			{
				this.SceneItem.PlayingMatchSequence = true;
				this.SceneItem.PlayMatchSequence(delegate
				{
					this.EnterInternal();
					this.SceneItem.PlayingMatchSequence = false;
					this.SceneItem.MatchSequence = null;
				}, true);
			}
			if (this.SceneItem.MatchSequence == null)
			{
				this.EnterInternal();
			}
			if (!FNameUtil.IsNothing(this.SceneItem.ManipulateBaseConfig.吸取状态碰撞预设))
			{
				this.SceneItem.ActorComp.GetPrimitiveComponent().SetCollisionProfileName(this.SceneItem.ManipulateBaseConfig.吸取状态碰撞预设, true);
			}
		}

		// Token: 0x060302AE RID: 197294 RVA: 0x00BAF710 File Offset: 0x00BAD910
		private void EnterInternal()
		{
			SceneItemOutletComponent activatedOutlet = this.SceneItem.ActivatedOutlet;
			if (activatedOutlet != null && activatedOutlet.Valid)
			{
				this.SceneItem.ClearAttachOutletInfo();
			}
			base.StartCameraShake(this.CameraShake);
			base.StartGamepadShake(this.GamepadShake);
			Singleton<EventSystem>.Instance.Emit<FGameplayTag>(EEventName.AddSubCameraTag, this.SubCameraTag.Value);
			this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.Kinematic;
			this.Timer = 0f;
			Vector drawStartLocation = this.SceneItem.GetDrawStartLocation();
			this.StartLoc = new FVectorDouble?(new FVectorDouble(drawStartLocation.X, drawStartLocation.Y, drawStartLocation.Z));
			this.StartRot = new FRotator?(this.SceneItem.ActorComp.ActorRotation);
			this.PassedThroughPortal = false;
			if (this.EnterCallback != null)
			{
				this.EnterCallback();
			}
		}

		// Token: 0x060302AF RID: 197295 RVA: 0x00BAF7F4 File Offset: 0x00BAD9F4
		protected override void OnTick(float delta)
		{
			if (this.SceneItem.PlayingMatchSequence)
			{
				return;
			}
			this.Timer += delta;
			ValueTuple<FVectorDouble, FRotator> targetLocationAndRotation = this.GetTargetLocationAndRotation();
			this.SceneItem.ActorComp.SetActorLocationAndRotation(targetLocationAndRotation.Item1, targetLocationAndRotation.Item2, "[ManipulableDrawState.Tick]", true, null);
		}

		// Token: 0x060302B0 RID: 197296 RVA: 0x00BAF850 File Offset: 0x00BADA50
		protected override void OnExit()
		{
			base.StopCameraShake();
			base.StopGamepadShake(this.GamepadShake);
			Singleton<EventSystem>.Instance.Emit<FGameplayTag>(EEventName.RemoveSubCameraTag, this.SubCameraTag.Value);
		}

		// Token: 0x060302B1 RID: 197297 RVA: 0x00BAF880 File Offset: 0x00BADA80
		[return: TupleElementNames(new string[]
		{
			"Loc",
			"Rot"
		})]
		private ValueTuple<FVectorDouble, FRotator> GetTargetLocationAndRotation()
		{
			BP_TeleControlConfig_C manipulateBaseConfig = this.SceneItem.ManipulateBaseConfig;
			float num = 1f;
			float num2 = 1f;
			if (this.Timer < manipulateBaseConfig.对齐时间)
			{
				num = Singleton<MathUtils>.Instance.Clamp(this.Timer / manipulateBaseConfig.对齐时间, 0f, 1f);
				num = UKismetMathLibrary.Ease(0f, 1f, num, EEasingFunc.EaseIn, 2f, 2);
			}
			if (this.Timer < manipulateBaseConfig.吸取时间)
			{
				num2 = Singleton<MathUtils>.Instance.Clamp((this.Timer - manipulateBaseConfig.吸取延迟) / (manipulateBaseConfig.吸取时间 - manipulateBaseConfig.吸取延迟), 0f, 1f);
				num2 = UKismetMathLibrary.Ease(0f, 1f, num2, EEasingFunc.EaseInOut, 2f, 2);
			}
			Vector vector = Vector.Create(0.0, 0.0, (double)(manipulateBaseConfig.牵引高度 * num));
			Singleton<GravityUtils>.Instance.RotatedVectorByActorInitGravity(this.SceneItem.ActorComp, vector);
			FVectorDouble a = new FVectorDouble(this.StartLoc.Value.X + vector.X, this.StartLoc.Value.Y + vector.Y, this.StartLoc.Value.Z + vector.Z);
			FRotator? startRot = this.StartRot;
			ValueTuple<FVectorDouble, FRotator> drawEndLocationAndRotation = this.GetDrawEndLocationAndRotation();
			FVectorDouble item = drawEndLocationAndRotation.Item1;
			FRotator item2 = drawEndLocationAndRotation.Item2;
			FVectorDouble fvectorDouble = item;
			FRotator item3 = item2;
			bool flag = this.SceneItem.GetPassThroughPortalType() > CharacterManipulateComponent.EPassThroughPortalType.None;
			double num3 = 0.0;
			List<Vector> list = null;
			if (flag)
			{
				list = this.GetMoveTrackWithPortal(this.StartLoc.Value, item);
				if (list.Count != 4)
				{
					return new ValueTuple<FVectorDouble, FRotator>(fvectorDouble, item3);
				}
				double num4 = Vector.Dist(list[0], list[1]);
				num4 += Vector.Dist(list[2], list[3]);
				num3 = Vector.Dist(list[0], list[1]) / num4;
			}
			if (num2 < 1f)
			{
				if (flag)
				{
					if ((double)num2 < num3)
					{
						fvectorDouble = UKismetMathLibrary.D_VLerp(list[0].ToUeVector(false), list[1].ToUeVector(false), (double)num2 / num3);
					}
					else
					{
						fvectorDouble = UKismetMathLibrary.D_VLerp(list[2].ToUeVector(false), list[3].ToUeVector(false), ((double)num2 - num3) / (1.0 - num3));
						if (!this.PassedThroughPortal)
						{
							this.PassedThroughPortal = true;
							this.SceneItem.ActorComp.SetActorLocation(fvectorDouble, "[ManipulableDrawState.PassThroughPortal]", false);
						}
					}
				}
				else
				{
					fvectorDouble = UKismetMathLibrary.D_VLerp(a, item, (double)num2);
				}
				item3 = UKismetMathLibrary.RLerp(startRot.Value, item2, num2, true);
			}
			return new ValueTuple<FVectorDouble, FRotator>(fvectorDouble, item3);
		}

		// Token: 0x060302B2 RID: 197298 RVA: 0x00BAFB58 File Offset: 0x00BADD58
		[return: TupleElementNames(new string[]
		{
			"Loc",
			"Rot"
		})]
		private ValueTuple<FVectorDouble, FRotator> GetDrawEndLocationAndRotation()
		{
			ValueTuple<FVectorDouble, FRotator>? valueTuple = this.TryGetMechascoutWeaponProp05EndLocationAndRotation();
			if (valueTuple != null)
			{
				return valueTuple.Value;
			}
			FVectorDouble fvectorDouble = this.SceneItem.UsingAssistantHoldOffset ? this.SceneItem.ConfigAssistantHoldOffset.Value : this.SceneItem.ConfigHoldOffset.Value;
			FTransformDouble actorTransform = Global.BaseCharacter.CharacterActorComponent.ActorTransform;
			FVectorDouble item = actorTransform.TransformPositionNoScale(fvectorDouble);
			FRotator rot = UKismetMathLibrary.ComposeRotators(this.SceneItem.ConfigHoldRotator.Value, actorTransform.Rotator());
			return new ValueTuple<FVectorDouble, FRotator>(item, this.ApplyJigsawRotation(rot));
		}

		// Token: 0x060302B3 RID: 197299 RVA: 0x00BAFBF0 File Offset: 0x00BADDF0
		[return: TupleElementNames(new string[]
		{
			"Loc",
			"Rot"
		})]
		private ValueTuple<FVectorDouble, FRotator>? TryGetMechascoutWeaponProp05EndLocationAndRotation()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent != null && characterActorComponent.Valid)
			{
				TsBaseCharacter actor = characterActorComponent.Actor;
				if (((actor != null) ? actor.Mesh : null) != null)
				{
					CreatureDataComponent component = characterActorComponent.Entity.GetComponent<CreatureDataComponent>();
					if (!ManipulateSkillConfig.IsMechascoutRole((component != null) ? component.GetRoleId() : 0))
					{
						return null;
					}
					FVectorDouble translation = characterActorComponent.Actor.Mesh.D_GetSocketTransform(this.MechascoutManipulateAttachSocket, ERelativeTransformSpace.RTS_World).GetTranslation();
					FTransformDouble actorTransform = characterActorComponent.ActorTransform;
					FRotator rot = UKismetMathLibrary.ComposeRotators(this.SceneItem.ConfigHoldRotator.Value, actorTransform.Rotator());
					return new ValueTuple<FVectorDouble, FRotator>?(new ValueTuple<FVectorDouble, FRotator>(translation, this.ApplyJigsawRotation(rot)));
				}
			}
			return null;
		}

		// Token: 0x060302B4 RID: 197300 RVA: 0x00BAFCBC File Offset: 0x00BADEBC
		private FRotator ApplyJigsawRotation(FRotator rot)
		{
			SceneItemJigsawItemComponent component = this.SceneItem.Entity.GetComponent<SceneItemJigsawItemComponent>();
			if (component != null && component.Valid)
			{
				return UKismetMathLibrary.ComposeRotators(new FRotator(0f, (float)(-(float)component.Rotation), 0f), rot);
			}
			return rot;
		}

		// Token: 0x060302B5 RID: 197301 RVA: 0x00BAFD0C File Offset: 0x00BADF0C
		[NullableContext(1)]
		private List<Vector> GetMoveTrackWithPortal(FVectorDouble startLoc, FVectorDouble endLoc)
		{
			List<Vector> list = new List<Vector>();
			bool flag = this.SceneItem.GetPassThroughPortalType() == CharacterManipulateComponent.EPassThroughPortalType.AToB;
			Vector vector = Vector.Create(endLoc.X, endLoc.Y, endLoc.Z);
			Vector vector2 = Vector.Create();
			Singleton<PortalUtils>.Instance.GetMappingPosToOtherPortal(vector, this.SceneItem.GetPassThroughPortalId(), flag, vector2);
			BP_Portal_C portal = ModelBase<PortalModel>.Instance.GetPortal(this.SceneItem.GetPassThroughPortalId());
			Vector vector3 = Vector.Create();
			Vector vector4 = Vector.Create();
			if (portal != null)
			{
				FVectorDouble location = ((!flag) ? portal.PortalWorldTransform1 : portal.PortalWorldTransform2).GetLocation();
				vector4.Set(location.X, location.Y, location.Z);
			}
			Vector vector5 = Vector.Create();
			if (portal != null)
			{
				FVector forwardVector = ((!flag) ? portal.PortalWorldTransform1 : portal.PortalWorldTransform2).GetRotation().GetForwardVector();
				vector5.Set((double)forwardVector.X, (double)forwardVector.Y, (double)forwardVector.Z);
			}
			Singleton<MathUtils>.Instance.LinePlaneIntersectionOriginNormal(vector2, Vector.Create(startLoc.X, startLoc.Y, startLoc.Z), vector4, vector5, vector3);
			if (!vector3.IsZero())
			{
				list.Add(Vector.Create(startLoc.X, startLoc.Y, startLoc.Z));
				list.Add(Vector.Create(vector3.X, vector3.Y, vector3.Z));
			}
			vector.Set(startLoc.X, startLoc.Y, startLoc.Z);
			Singleton<PortalUtils>.Instance.GetMappingPosToOtherPortal(vector, this.SceneItem.GetPassThroughPortalId(), !flag, vector2);
			if (portal != null)
			{
				FVectorDouble location2 = (flag ? portal.PortalWorldTransform1 : portal.PortalWorldTransform2).GetLocation();
				vector4.Set(location2.X, location2.Y, location2.Z);
			}
			if (portal != null)
			{
				FVector forwardVector2 = (flag ? portal.PortalWorldTransform1 : portal.PortalWorldTransform2).GetRotation().GetForwardVector();
				vector5.Set((double)forwardVector2.X, (double)forwardVector2.Y, (double)forwardVector2.Z);
			}
			Singleton<MathUtils>.Instance.LinePlaneIntersectionOriginNormal(vector2, Vector.Create(endLoc.X, endLoc.Y, endLoc.Z), vector4, vector5, vector3);
			if (!vector3.IsZero())
			{
				list.Add(Vector.Create(vector3.X, vector3.Y, vector3.Z));
				list.Add(Vector.Create(endLoc.X, endLoc.Y, endLoc.Z));
			}
			return list;
		}

		// Token: 0x0401BA6E RID: 113262
		[Nullable(new byte[]
		{
			0,
			1
		})]
		private readonly TSubclassOf<UCameraShakeBase>? CameraShake;

		// Token: 0x0401BA6F RID: 113263
		[Nullable(2)]
		private readonly UKuroForceFeedbackEffect GamepadShake;

		// Token: 0x0401BA70 RID: 113264
		private FVectorDouble? StartLoc;

		// Token: 0x0401BA71 RID: 113265
		private FRotator? StartRot;

		// Token: 0x0401BA72 RID: 113266
		private readonly FGameplayTag? SubCameraTag;

		// Token: 0x0401BA73 RID: 113267
		private bool PassedThroughPortal;

		// Token: 0x0401BA74 RID: 113268
		private readonly FName MechascoutManipulateAttachSocket = FNameUtil.GetDynamicFName("WeaponProp05").Value;
	}
}
