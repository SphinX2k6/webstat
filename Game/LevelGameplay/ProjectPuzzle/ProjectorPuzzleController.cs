using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ProjectPuzzle
{
	// Token: 0x02006B2F RID: 27439
	[NullableContext(1)]
	[Nullable(0)]
	public class ProjectorPuzzleController : IStaticVariableResetter
	{
		// Token: 0x06043CBF RID: 277695 RVA: 0x0118428A File Offset: 0x0118248A
		static ProjectorPuzzleController()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ProjectorPuzzleController.CreateStaticDefaultValue), new Action(ProjectorPuzzleController.ResetStaticDefaultValue));
		}

		// Token: 0x06043CC0 RID: 277696 RVA: 0x011842B8 File Offset: 0x011824B8
		public static void CreateStaticDefaultValue()
		{
			ProjectorPuzzleController.CurrentGameplayAssistantActor = null;
			ProjectorPuzzleController.CurrentGameplayBackgroundEntityId = 0;
			ProjectorPuzzleController.DelayRemoveAssistantTimer = null;
			ProjectorPuzzleController.DelayedRemoveAssistantActor = null;
			ProjectorPuzzleController.DelayedRemoveBackgroundEntityId = 0;
			ProjectorPuzzleController.DelayedRemoveBackgroundEntityHandle = null;
			ProjectorPuzzleController.IsBackgroundEntityRemoveListenerRegistered = false;
		}

		// Token: 0x06043CC1 RID: 277697 RVA: 0x011842E4 File Offset: 0x011824E4
		public static void ResetStaticDefaultValue()
		{
			ProjectorPuzzleController.CurrentGameplayAssistantActor = null;
			ProjectorPuzzleController.CurrentGameplayBackgroundEntityId = 0;
			ProjectorPuzzleController.DelayRemoveAssistantTimer = null;
			ProjectorPuzzleController.DelayedRemoveAssistantActor = null;
			ProjectorPuzzleController.DelayedRemoveBackgroundEntityId = 0;
			ProjectorPuzzleController.DelayedRemoveBackgroundEntityHandle = null;
			ProjectorPuzzleController.IsBackgroundEntityRemoveListenerRegistered = false;
		}

		// Token: 0x06043CC2 RID: 277698 RVA: 0x01184310 File Offset: 0x01182510
		public static void StartProjectorPuzzle(int entityId, Action<bool> finishCallback)
		{
			ProjectorPuzzleController.ClearDelayRemoveAssistantTimer();
			ProjectorPuzzleController.TryRemovePendingAssistantActor("[ProjectorPuzzleController] StartProjectorPuzzleClearPending");
			ProjectorPuzzleController.UnregisterBackgroundEntityRemoveListener();
			ProjectorComponent projectorComponent = ProjectorPuzzleController.ValidateAndGetProjectorComponent(entityId, finishCallback);
			if (projectorComponent == null)
			{
				return;
			}
			ProjectorPuzzleController.CloseGameplay(false, false, false);
			ProjectorComponent projectorConfig = projectorComponent.ProjectorConfig;
			global::Rotator[] targetRotators = projectorComponent.TargetRotators;
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			instance.Reset();
			float valueOrDefault = projectorConfig.DragRotationCoefficient.GetValueOrDefault();
			instance.InitFromComponent(entityId, projectorConfig.RotationSpeed, valueOrDefault, projectorConfig.MatchTolerance, targetRotators, finishCallback);
			ProjectorPuzzleController.StartGameplayAsync(projectorComponent);
		}

		// Token: 0x06043CC3 RID: 277699 RVA: 0x0118438C File Offset: 0x0118258C
		private static UniTask StartGameplayAsync(ProjectorComponent projectorComponent)
		{
			ProjectorPuzzleController.<StartGameplayAsync>d__20 <StartGameplayAsync>d__;
			<StartGameplayAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartGameplayAsync>d__.projectorComponent = projectorComponent;
			<StartGameplayAsync>d__.<>1__state = -1;
			<StartGameplayAsync>d__.<>t__builder.Start<ProjectorPuzzleController.<StartGameplayAsync>d__20>(ref <StartGameplayAsync>d__);
			return <StartGameplayAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043CC4 RID: 277700 RVA: 0x011843D0 File Offset: 0x011825D0
		[return: Nullable(2)]
		private unsafe static ProjectorComponent ValidateAndGetProjectorComponent(int entityId, Action<bool> finishCallback)
		{
			ProjectorPuzzleController.<>c__DisplayClass21_0 CS$<>8__locals1;
			CS$<>8__locals1.finishCallback = finishCallback;
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return ProjectorPuzzleController.<ValidateAndGetProjectorComponent>g__Fail|21_0("ProjectorPuzzle启动失败，实体不存在", default(ReadOnlySpan<ValueTuple<string, object>>), ref CS$<>8__locals1);
			}
			ProjectorComponent component = entity.GetComponent<ProjectorComponent>();
			if (component == null)
			{
				return ProjectorPuzzleController.<ValidateAndGetProjectorComponent>g__Fail|21_0("ProjectorPuzzle启动失败，缺少ProjectorComponent组件", default(ReadOnlySpan<ValueTuple<string, object>>), ref CS$<>8__locals1);
			}
			ProjectorComponent projectorConfig = component.ProjectorConfig;
			if (projectorConfig == null)
			{
				return ProjectorPuzzleController.<ValidateAndGetProjectorComponent>g__Fail|21_0("ProjectorPuzzle启动失败，缺少ProjectorComponent配置", default(ReadOnlySpan<ValueTuple<string, object>>), ref CS$<>8__locals1);
			}
			if (component.Pattern == null)
			{
				string message = "ProjectorPuzzle启动失败，找不到投影仪玩法配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ProjectorPatternId", projectorConfig.ProjectorPatternId);
				return ProjectorPuzzleController.<ValidateAndGetProjectorComponent>g__Fail|21_0(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple), ref CS$<>8__locals1);
			}
			if (component.TargetRotators.Length == 0)
			{
				return ProjectorPuzzleController.<ValidateAndGetProjectorComponent>g__Fail|21_0("ProjectorPuzzle启动失败，RotationTargetAngles为空", default(ReadOnlySpan<ValueTuple<string, object>>), ref CS$<>8__locals1);
			}
			if (string.IsNullOrEmpty(component.MeshPath))
			{
				return ProjectorPuzzleController.<ValidateAndGetProjectorComponent>g__Fail|21_0("ProjectorPuzzle启动失败，被投影物mesh为空", default(ReadOnlySpan<ValueTuple<string, object>>), ref CS$<>8__locals1);
			}
			int backgroundEntityId = component.BackgroundEntityId;
			string backgroundDecalPath = component.BackgroundDecalPath;
			if (backgroundEntityId == 0 || string.IsNullOrEmpty(backgroundDecalPath))
			{
				string message2 = "ProjectorPuzzle启动失败，背景板配置缺失";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BackgroundEntityId", backgroundEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BackgroundDecalPath", backgroundDecalPath);
				return ProjectorPuzzleController.<ValidateAndGetProjectorComponent>g__Fail|21_0(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2), ref CS$<>8__locals1);
			}
			return component;
		}

		// Token: 0x06043CC5 RID: 277701 RVA: 0x01184540 File Offset: 0x01182740
		public static void CloseGameplay(bool callFinishCallback = false, bool closeView = true, bool result = false)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive)
			{
				return;
			}
			object obj = callFinishCallback ? instance.FinishCallback : null;
			int backgroundDecalEffectId = instance.BackgroundDecalEffectId;
			AActor currentGameplayAssistantActor = ProjectorPuzzleController.CurrentGameplayAssistantActor;
			int currentGameplayBackgroundEntityId = ProjectorPuzzleController.CurrentGameplayBackgroundEntityId;
			ProjectorPuzzleController.ClearDelayRemoveAssistantTimer();
			ProjectorPuzzleController.TryRemovePendingAssistantActor("[ProjectorPuzzleController] ClearPendingBeforeCloseGameplay");
			ProjectorPuzzleController.UnregisterBackgroundEntityRemoveListener();
			if (Singleton<EffectSystem>.Instance.IsValid(backgroundDecalEffectId))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(backgroundDecalEffectId, "[ProjectorPuzzleController] DelayStopBackgroundDecal", false, new bool?(false));
				if (currentGameplayAssistantActor != null && currentGameplayAssistantActor.IsValid())
				{
					ProjectorPuzzleController.DelayedRemoveAssistantActor = currentGameplayAssistantActor;
					ProjectorPuzzleController.DelayedRemoveBackgroundEntityId = currentGameplayBackgroundEntityId;
					ProjectorPuzzleController.RegisterBackgroundEntityRemoveListener();
					ProjectorPuzzleController.DelayRemoveAssistantTimer = TimerSystem.Instance.Delay(delegate(float _)
					{
						ProjectorPuzzleController.DelayRemoveAssistantTimer = null;
						ProjectorPuzzleController.TryRemovePendingAssistantActor("[ProjectorPuzzleController] DelayRemoveAssistantActor");
						ProjectorPuzzleController.UnregisterBackgroundEntityRemoveListener();
					}, 5000f, null, "[ProjectorPuzzleController] DelayRemoveAssistantActor", true, 1f);
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.ProjectorPuzzle;
					ELogAuthor author = ELogAuthor.WRY;
					string message = "ProjectorPuzzle准备延迟移除辅助Actor时对象已失效";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BackgroundEntityId", currentGameplayBackgroundEntityId);
					instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			else if (currentGameplayAssistantActor != null && currentGameplayAssistantActor.IsValid())
			{
				UKuroGameBudgetAllocatorCSharpInterface.RemoveAssistantActor(currentGameplayAssistantActor);
			}
			ProjectorPuzzleController.CurrentGameplayAssistantActor = null;
			ProjectorPuzzleController.CurrentGameplayBackgroundEntityId = 0;
			ProjectorPuzzleController.StopRotationAudio();
			ProjectorPuzzleController.ReleaseShadowCompensationActor(instance);
			instance.Reset();
			if (closeView)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ProjectorPuzzleView, null);
			}
			object obj2 = obj;
			if (obj2 == null)
			{
				return;
			}
			obj2(result);
		}

		// Token: 0x06043CC6 RID: 277702 RVA: 0x01184694 File Offset: 0x01182894
		public static void ResetGameplay()
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			AActor aactor = (instance != null) ? instance.AttachActor : null;
			if (instance == null || !instance.IsActive || aactor == null || !aactor.IsValid())
			{
				return;
			}
			instance.IsCompleted = false;
			ProjectorPuzzleController.StopRotationAudio();
			instance.ResetInputState();
			ProjectorPuzzleController.ResetAttachActorRotation(aactor, instance.InitialAttachRelativeRotator);
		}

		// Token: 0x06043CC7 RID: 277703 RVA: 0x011846EC File Offset: 0x011828EC
		public static void BeginInput(float localX, float localY, double width, double height)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive || instance.IsCompleted)
			{
				return;
			}
			instance.DragCenterX = localX;
			instance.DragCenterY = localY;
			ProjectorPuzzleController.GetArcballVector(localX, localY, width, height, instance.DragCenterX, instance.DragCenterY, instance.LastArcballVector);
			instance.HasLastArcballVector = true;
		}

		// Token: 0x06043CC8 RID: 277704 RVA: 0x01184744 File Offset: 0x01182944
		public static void UpdateInput(float localX, float localY, double width, double height)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive || instance.IsCompleted)
			{
				return;
			}
			if (!instance.HasLastArcballVector)
			{
				ProjectorPuzzleController.BeginInput(localX, localY, width, height);
				return;
			}
			ProjectorPuzzleController.GetArcballVector(localX, localY, width, height, instance.DragCenterX, instance.DragCenterY, instance.TempArcballVector);
			if (ProjectorPuzzleController.ShouldRecenterArcball(localX, localY, width, height, instance.DragCenterX, instance.DragCenterY))
			{
				instance.DragCenterX = localX;
				instance.DragCenterY = localY;
				ProjectorPuzzleController.GetArcballVector(localX, localY, width, height, instance.DragCenterX, instance.DragCenterY, instance.TempArcballVector);
				instance.LastArcballVector.DeepCopy(instance.TempArcballVector);
				return;
			}
			ProjectorPuzzleController.ApplyArcballRotation(instance.LastArcballVector, instance.TempArcballVector);
			instance.LastArcballVector.DeepCopy(instance.TempArcballVector);
		}

		// Token: 0x06043CC9 RID: 277705 RVA: 0x0118480C File Offset: 0x01182A0C
		public static void EndInput()
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive)
			{
				return;
			}
			instance.HasLastArcballVector = false;
		}

		// Token: 0x06043CCA RID: 277706 RVA: 0x01184834 File Offset: 0x01182A34
		public static void Update(float delta, float rollInput = 0f)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive || instance.IsCompleted)
			{
				return;
			}
			if ((double)Math.Abs(rollInput) > 1E-08)
			{
				ProjectorPuzzleController.ApplyRollRotation(rollInput, delta);
			}
			ProjectorPuzzleController.CheckRotationMatch();
			ProjectorPuzzleController.UpdateShadowCompensation();
			ProjectorPuzzleController.UpdateRotationAudio(delta);
		}

		// Token: 0x06043CCB RID: 277707 RVA: 0x01184884 File Offset: 0x01182A84
		public static void UpdateStickRotation(float inputX, float inputY, float delta)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			AActor aactor = (instance != null) ? instance.AttachActor : null;
			if (instance == null || instance.IsCompleted || aactor == null || !aactor.IsValid())
			{
				return;
			}
			if ((double)Math.Abs(inputX) <= 1E-08 && (double)Math.Abs(inputY) <= 1E-08)
			{
				return;
			}
			float num = delta * 0.001f;
			if (num <= 0f)
			{
				return;
			}
			float rotationSpeed = instance.RotationSpeed;
			if (rotationSpeed <= 0f)
			{
				return;
			}
			float num2 = -inputX * rotationSpeed * 0.017453292f * num;
			float num3 = inputY * rotationSpeed * 0.017453292f * num;
			if ((double)Math.Abs(num2) <= 1E-08 && (double)Math.Abs(num3) <= 1E-08)
			{
				return;
			}
			if (ProjectorPuzzleController.TryGetReferenceRotation(instance.TempRotator))
			{
				instance.TempRotator.Quaternion(instance.TempQuat2);
				instance.TempAxis.Set(0.0, 0.0, 1.0);
				instance.TempQuat2.RotateVector(instance.TempAxis, instance.TempWorldAxis);
				instance.TempAxis.Set(1.0, 0.0, 0.0);
				instance.TempQuat2.RotateVector(instance.TempAxis, instance.TempArcballVector);
			}
			else
			{
				instance.TempWorldAxis.Set(0.0, 0.0, 1.0);
				instance.TempArcballVector.Set(1.0, 0.0, 0.0);
			}
			if ((double)Math.Abs(num2) > 1E-08 && !instance.TempWorldAxis.IsNearlyZero(1E-08))
			{
				instance.TempWorldAxis.Normalize(9.99999993922529E-09);
				Quat.ConstructorByAxisAngle(instance.TempWorldAxis, num2, instance.TempQuat);
				instance.TempQuat2.FromUeQuat(aactor.K2_GetActorQuaternion());
				instance.TempQuat.Multiply(instance.TempQuat2, instance.TempQuat2);
				instance.TempQuat2.Rotator(instance.TempRotator);
				aactor.K2_SetActorRotation(instance.TempRotator.ToUeRotator(), false);
				instance.FrameStickAngle += Math.Abs(num2);
			}
			if ((double)Math.Abs(num3) > 1E-08 && !instance.TempArcballVector.IsNearlyZero(1E-08))
			{
				instance.TempArcballVector.Normalize(9.99999993922529E-09);
				Quat.ConstructorByAxisAngle(instance.TempArcballVector, num3, instance.TempQuat);
				instance.TempQuat2.FromUeQuat(aactor.K2_GetActorQuaternion());
				instance.TempQuat.Multiply(instance.TempQuat2, instance.TempQuat2);
				instance.TempQuat2.Rotator(instance.TempRotator);
				aactor.K2_SetActorRotation(instance.TempRotator.ToUeRotator(), false);
				instance.FrameStickAngle += Math.Abs(num3);
			}
		}

		// Token: 0x06043CCC RID: 277708 RVA: 0x01184BA0 File Offset: 0x01182DA0
		private unsafe static bool SetupBackgroundDecal(int backgroundEntityId, string decalPath)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive)
			{
				return false;
			}
			CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance2 != null) ? instance2.GetEntityByPbDataId(backgroundEntityId) : null;
			WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
			if (worldEntity == null || !worldEntity.IsInit)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ProjectorPuzzle;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "ProjectorPuzzle背景板实体无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BackgroundEntityId", backgroundEntityId);
				instance3.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			SceneItemActorComponent component = worldEntity.GetComponent<SceneItemActorComponent>();
			AActor aactor = (component != null) ? component.Owner : null;
			if (aactor == null || !aactor.IsValid())
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.ProjectorPuzzle;
				ELogAuthor author2 = ELogAuthor.WRY;
				string message2 = "ProjectorPuzzle背景板Actor无效";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("BackgroundEntityId", backgroundEntityId);
				instance4.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			AActor aactor2 = (component != null) ? component.GetActorInSceneInteraction("ProjectorDecalAttachActor") : null;
			if (aactor2 == null || !aactor2.IsValid())
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.ProjectorPuzzle;
				ELogAuthor author3 = ELogAuthor.WRY;
				string message3 = "ProjectorPuzzle背景贴花挂点Actor无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BackgroundEntityId", backgroundEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AttachActorKey", "ProjectorDecalAttachActor");
				instance5.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			FTransformDouble value = new FTransformDouble();
			FVectorDouble fvectorDouble = aactor2.D_K2_GetActorLocation();
			value.SetLocation(fvectorDouble);
			FQuat fquat = aactor2.K2_GetActorQuaternion();
			value.SetRotation(fquat);
			EffectSystem instance6 = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(value);
			int num = instance6.SpawnEffect(world, ftransformDouble, decalPath, "[ProjectorPuzzleController] SpawnBackgroundDecal", null, EEffectType.Scene, null, null, null, false, false);
			if (!Singleton<EffectSystem>.Instance.IsValid(num))
			{
				Log instance7 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.ProjectorPuzzle;
				ELogAuthor author4 = ELogAuthor.WRY;
				string message4 = "ProjectorPuzzle背景贴花加载失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("decalPath", decalPath);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("BackgroundEntityId", backgroundEntityId);
				instance7.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
			AActor parent = aactor2;
			FName? fname = null;
			effectActor.K2_AttachToActor(parent, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
			instance.BackgroundDecalEffectId = num;
			instance.BackgroundActor = aactor;
			ProjectorPuzzleController.CurrentGameplayBackgroundEntityId = backgroundEntityId;
			ProjectorPuzzleController.CurrentGameplayAssistantActor = aactor2;
			UKuroGameBudgetAllocatorCSharpInterface.AddAssistantActor(aactor2);
			return true;
		}

		// Token: 0x06043CCD RID: 277709 RVA: 0x01184DF0 File Offset: 0x01182FF0
		private static void RegisterBackgroundEntityRemoveListener()
		{
			if (ProjectorPuzzleController.IsBackgroundEntityRemoveListenerRegistered)
			{
				return;
			}
			int delayedRemoveBackgroundEntityId = ProjectorPuzzleController.DelayedRemoveBackgroundEntityId;
			if (delayedRemoveBackgroundEntityId <= 0)
			{
				return;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(delayedRemoveBackgroundEntityId) : null;
			if (entityHandle == null || !entityHandle.Valid)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ProjectorPuzzle;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "ProjectorPuzzle注册背景板移除监听失败，实体句柄无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BackgroundEntityId", delayedRemoveBackgroundEntityId);
				instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ProjectorPuzzleController.DelayedRemoveBackgroundEntityHandle = entityHandle;
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			object target = entityHandle;
			EEventName name = EEventName.RemoveEntity;
			Action<ERemoveEntityType, EntityHandle> handle;
			if ((handle = ProjectorPuzzleController.<>O.<0>__OnBackgroundEntityRemoved) == null)
			{
				handle = (ProjectorPuzzleController.<>O.<0>__OnBackgroundEntityRemoved = new Action<ERemoveEntityType, EntityHandle>(ProjectorPuzzleController.OnBackgroundEntityRemoved));
			}
			instance3.AddWithTarget(target, name, handle);
			ProjectorPuzzleController.IsBackgroundEntityRemoveListenerRegistered = true;
		}

		// Token: 0x06043CCE RID: 277710 RVA: 0x01184E98 File Offset: 0x01183098
		private static void UnregisterBackgroundEntityRemoveListener()
		{
			if (!ProjectorPuzzleController.IsBackgroundEntityRemoveListenerRegistered)
			{
				return;
			}
			EntityHandle delayedRemoveBackgroundEntityHandle = ProjectorPuzzleController.DelayedRemoveBackgroundEntityHandle;
			if (delayedRemoveBackgroundEntityHandle != null)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				object target = delayedRemoveBackgroundEntityHandle;
				EEventName name = EEventName.RemoveEntity;
				Action<ERemoveEntityType, EntityHandle> handle;
				if ((handle = ProjectorPuzzleController.<>O.<0>__OnBackgroundEntityRemoved) == null)
				{
					handle = (ProjectorPuzzleController.<>O.<0>__OnBackgroundEntityRemoved = new Action<ERemoveEntityType, EntityHandle>(ProjectorPuzzleController.OnBackgroundEntityRemoved));
				}
				if (instance.HasWithTarget(target, name, handle))
				{
					EventSystem instance2 = Singleton<EventSystem>.Instance;
					object target2 = delayedRemoveBackgroundEntityHandle;
					EEventName name2 = EEventName.RemoveEntity;
					Action<ERemoveEntityType, EntityHandle> handle2;
					if ((handle2 = ProjectorPuzzleController.<>O.<0>__OnBackgroundEntityRemoved) == null)
					{
						handle2 = (ProjectorPuzzleController.<>O.<0>__OnBackgroundEntityRemoved = new Action<ERemoveEntityType, EntityHandle>(ProjectorPuzzleController.OnBackgroundEntityRemoved));
					}
					instance2.RemoveWithTarget(target2, name2, handle2);
				}
			}
			ProjectorPuzzleController.DelayedRemoveBackgroundEntityHandle = null;
			ProjectorPuzzleController.IsBackgroundEntityRemoveListenerRegistered = false;
		}

		// Token: 0x06043CCF RID: 277711 RVA: 0x01184F1B File Offset: 0x0118311B
		private static void ClearDelayRemoveAssistantTimer()
		{
			if (ProjectorPuzzleController.DelayRemoveAssistantTimer != null && ProjectorPuzzleController.DelayRemoveAssistantTimer.Valid())
			{
				TimerSystem.Instance.Remove(ProjectorPuzzleController.DelayRemoveAssistantTimer);
			}
			ProjectorPuzzleController.DelayRemoveAssistantTimer = null;
		}

		// Token: 0x06043CD0 RID: 277712 RVA: 0x01184F48 File Offset: 0x01183148
		private unsafe static void TryRemovePendingAssistantActor(string reason)
		{
			AActor delayedRemoveAssistantActor = ProjectorPuzzleController.DelayedRemoveAssistantActor;
			if (delayedRemoveAssistantActor != null && delayedRemoveAssistantActor.IsValid())
			{
				UKuroGameBudgetAllocatorCSharpInterface.RemoveAssistantActor(delayedRemoveAssistantActor);
			}
			else if (ProjectorPuzzleController.DelayedRemoveBackgroundEntityId > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ProjectorPuzzle;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "ProjectorPuzzle移除辅助Actor时对象已失效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BackgroundEntityId", ProjectorPuzzleController.DelayedRemoveBackgroundEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			ProjectorPuzzleController.DelayedRemoveAssistantActor = null;
			ProjectorPuzzleController.DelayedRemoveBackgroundEntityId = 0;
		}

		// Token: 0x06043CD1 RID: 277713 RVA: 0x01184FE4 File Offset: 0x011831E4
		private static void CheckRotationMatch()
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			AActor aactor = (instance != null) ? instance.AttachActor : null;
			if (instance == null || instance.IsCompleted || aactor == null || !aactor.IsValid())
			{
				return;
			}
			if (instance.TargetRotators.Length == 0)
			{
				return;
			}
			global::Rotator tempRotator = instance.TempRotator;
			FRotator frotator = aactor.K2_GetActorRotation();
			tempRotator.FromUeRotator(frotator);
			float matchTolerance = instance.MatchTolerance;
			foreach (global::Rotator b in instance.TargetRotators)
			{
				if (instance.TempRotator.Equals(b, matchTolerance))
				{
					ProjectorPuzzleController.OnRotationCompleted();
					return;
				}
			}
		}

		// Token: 0x06043CD2 RID: 277714 RVA: 0x01185078 File Offset: 0x01183278
		private static void OnRotationCompleted()
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || instance.IsCompleted)
			{
				return;
			}
			instance.IsCompleted = true;
			ProjectorPuzzleController.FinishGameplay();
		}

		// Token: 0x06043CD3 RID: 277715 RVA: 0x011850A4 File Offset: 0x011832A4
		private static void FinishGameplay()
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive)
			{
				return;
			}
			ProjectorPuzzleController.CloseGameplay(true, true, true);
		}

		// Token: 0x06043CD4 RID: 277716 RVA: 0x011850CC File Offset: 0x011832CC
		private static void ApplyArcballRotation(global::Vector from, global::Vector to)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			AActor aactor = (instance != null) ? instance.AttachActor : null;
			if (instance == null || instance.IsCompleted || aactor == null || !aactor.IsValid())
			{
				return;
			}
			to.CrossProduct(from, instance.TempAxis);
			if (instance.TempAxis.IsNearlyZero(1E-08))
			{
				return;
			}
			float num = (float)Math.Acos(Singleton<MathUtils>.Instance.Clamp(from.DotProduct(to), -1.0, 1.0));
			if ((double)num <= 1E-08)
			{
				return;
			}
			float dragRotationCoefficient = instance.DragRotationCoefficient;
			if (dragRotationCoefficient > 0f)
			{
				num *= dragRotationCoefficient;
			}
			double x = instance.TempAxis.X;
			instance.TempAxis.X = instance.TempAxis.Y;
			instance.TempAxis.Y = x;
			instance.TempAxis.Normalize(9.99999993922529E-09);
			if (ProjectorPuzzleController.TryGetReferenceRotation(instance.TempRotator))
			{
				instance.TempRotator.Quaternion(instance.TempQuat2);
				instance.TempQuat2.RotateVector(instance.TempAxis, instance.TempWorldAxis);
			}
			else
			{
				instance.TempWorldAxis.DeepCopy(instance.TempAxis);
			}
			Quat.ConstructorByAxisAngle(instance.TempWorldAxis, num, instance.TempQuat);
			instance.TempQuat2.FromUeQuat(aactor.K2_GetActorQuaternion());
			instance.TempQuat.Multiply(instance.TempQuat2, instance.TempQuat2);
			instance.TempQuat2.Rotator(instance.TempRotator);
			aactor.K2_SetActorRotation(instance.TempRotator.ToUeRotator(), false);
			instance.FrameDragAngle += Math.Abs(num);
		}

		// Token: 0x06043CD5 RID: 277717 RVA: 0x01185274 File Offset: 0x01183474
		private static void ApplyRollRotation(float rollInput, float delta)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			AActor aactor = (instance != null) ? instance.AttachActor : null;
			if (instance == null || instance.IsCompleted || aactor == null || !aactor.IsValid())
			{
				return;
			}
			float num = delta * 0.001f;
			if (num <= 0f)
			{
				return;
			}
			float rotationSpeed = instance.RotationSpeed;
			if (rotationSpeed <= 0f)
			{
				return;
			}
			float num2 = rollInput * rotationSpeed * 0.017453292f * num;
			if ((double)Math.Abs(num2) <= 1E-08)
			{
				return;
			}
			instance.TempAxis.Set(0.0, 1.0, 0.0);
			if (ProjectorPuzzleController.TryGetReferenceRotation(instance.TempRotator))
			{
				instance.TempRotator.Quaternion(instance.TempQuat2);
				instance.TempQuat2.RotateVector(instance.TempAxis, instance.TempWorldAxis);
			}
			else
			{
				instance.TempWorldAxis.Set(0.0, 1.0, 0.0);
			}
			if (instance.TempWorldAxis.IsNearlyZero(1E-08))
			{
				return;
			}
			instance.TempWorldAxis.Normalize(9.99999993922529E-09);
			Quat.ConstructorByAxisAngle(instance.TempWorldAxis, num2, instance.TempQuat);
			instance.TempQuat2.FromUeQuat(aactor.K2_GetActorQuaternion());
			instance.TempQuat.Multiply(instance.TempQuat2, instance.TempQuat2);
			instance.TempQuat2.Rotator(instance.TempRotator);
			aactor.K2_SetActorRotation(instance.TempRotator.ToUeRotator(), false);
			instance.FrameStickAngle += Math.Abs(num2);
		}

		// Token: 0x06043CD6 RID: 277718 RVA: 0x01185414 File Offset: 0x01183614
		private static void GetArcballVector(float localX, float localY, double width, double height, float centerX, float centerY, global::Vector outValue)
		{
			double num = width * 0.5;
			double num2 = height * 0.5;
			if (num <= 0.0 || num2 <= 0.0)
			{
				outValue.Reset();
				return;
			}
			double num3 = Singleton<MathUtils>.Instance.Clamp((double)(localX - centerX) / num, -1.0, 1.0);
			double num4 = Singleton<MathUtils>.Instance.Clamp((double)(localY - centerY) / num2, -1.0, 1.0);
			double num5 = num3 * num3 + num4 * num4;
			double inX = 0.0;
			if (num5 <= 1.0)
			{
				inX = Math.Sqrt(1.0 - num5);
			}
			else if (num5 > 1E-08)
			{
				double num6 = Math.Sqrt(num5);
				num3 /= num6;
				num4 /= num6;
				inX = 0.0;
			}
			outValue.Set(inX, num3, num4);
		}

		// Token: 0x06043CD7 RID: 277719 RVA: 0x01185510 File Offset: 0x01183710
		private static bool ShouldRecenterArcball(float localX, float localY, double width, double height, float centerX, float centerY)
		{
			double num = width * 0.5;
			double num2 = height * 0.5;
			if (num <= 0.0 || num2 <= 0.0)
			{
				return false;
			}
			double num3 = (double)(localX - centerX) / num;
			double num4 = (double)(localY - centerY) / num2;
			return num3 * num3 + num4 * num4 >= 1.0;
		}

		// Token: 0x06043CD8 RID: 277720 RVA: 0x01185574 File Offset: 0x01183774
		private static bool TryGetReferenceRotation(global::Rotator outValue)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			AActor aactor = (instance != null) ? instance.BackgroundActor : null;
			if (aactor != null && aactor.IsValid())
			{
				FRotator frotator = aactor.K2_GetActorRotation();
				outValue.FromUeRotator(frotator);
				return true;
			}
			return false;
		}

		// Token: 0x06043CD9 RID: 277721 RVA: 0x011855B0 File Offset: 0x011837B0
		private static void OnBackgroundEntityRemoved(ERemoveEntityType removeType, EntityHandle handle)
		{
			ProjectorPuzzleController.ClearDelayRemoveAssistantTimer();
			ProjectorPuzzleController.TryRemovePendingAssistantActor("[ProjectorPuzzleController] BackgroundEntityRemoveAssistantActor");
			ProjectorPuzzleController.UnregisterBackgroundEntityRemoveListener();
		}

		// Token: 0x06043CDA RID: 277722 RVA: 0x011855C8 File Offset: 0x011837C8
		private static void CacheInitialAttachRelativeRotation(AActor actor, global::Rotator outValue)
		{
			USceneComponent usceneComponent = actor.K2_GetRootComponent();
			if (usceneComponent != null && usceneComponent.IsValid())
			{
				FRotator relativeRotation = usceneComponent.RelativeRotation;
				outValue.FromUeRotator(relativeRotation);
				return;
			}
			outValue.Set(0f, 0f, 0f);
			Singleton<Log>.Instance.Warn(ELogModule.ProjectorPuzzle, ELogAuthor.WRY, "ProjectorPuzzle缓存挂点初始相对旋转失败，RootComponent无效", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06043CDB RID: 277723 RVA: 0x0118562C File Offset: 0x0118382C
		private static void ResetAttachActorRotation(AActor actor, global::Rotator initialRotator)
		{
			FHitResult fhitResult = new FHitResult();
			actor.K2_SetActorRelativeRotation(initialRotator.ToUeRotator(), false, ref fhitResult, false);
		}

		// Token: 0x06043CDC RID: 277724 RVA: 0x01185650 File Offset: 0x01183850
		private static void UpdateRotationAudio(float delta)
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive)
			{
				return;
			}
			AActor attachActor = instance.AttachActor;
			if (attachActor == null || !attachActor.IsValid())
			{
				return;
			}
			float frameDragAngle = instance.FrameDragAngle;
			float frameStickAngle = instance.FrameStickAngle;
			instance.FrameDragAngle = 0f;
			instance.FrameStickAngle = 0f;
			float num = delta * 0.001f;
			bool flag = (double)(frameDragAngle + frameStickAngle) > 1E-08 && num > 0f;
			if (flag && instance.RotationAudioHandle <= 0)
			{
				instance.RotationAudioHandle = Singleton<AudioSystem>.Instance.PostEvent("play_sfx_gp_projectorpuzzle_stonerotate_loop", attachActor, null);
			}
			else if (!flag && instance.RotationAudioHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(instance.RotationAudioHandle, EAudioActionType.Stop, null);
				instance.RotationAudioHandle = 0;
			}
			if (num > 0f)
			{
				float num2 = instance.RotationSpeed * 0.017453292f;
				float val = ((double)num2 > 1E-08) ? Singleton<MathUtils>.Instance.Clamp(frameStickAngle / num / num2, 0f, 1f) : 0f;
				float val2 = Singleton<MathUtils>.Instance.Clamp(frameDragAngle / num / 6.2831855f, 0f, 1f);
				float value = Math.Max(val, val2);
				Singleton<AudioSystem>.Instance.SetRtpcValue("projectorpuzzle_rotation", value, new SetRtpcValueArgs?(new SetRtpcValueArgs
				{
					Actor = attachActor
				}));
			}
		}

		// Token: 0x06043CDD RID: 277725 RVA: 0x011857C8 File Offset: 0x011839C8
		private static void StopRotationAudio()
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null)
			{
				return;
			}
			if (instance.RotationAudioHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(instance.RotationAudioHandle, EAudioActionType.Stop, null);
				instance.RotationAudioHandle = 0;
			}
			instance.FrameDragAngle = 0f;
			instance.FrameStickAngle = 0f;
			AActor attachActor = instance.AttachActor;
			if (attachActor != null && attachActor.IsValid())
			{
				Singleton<AudioSystem>.Instance.SetRtpcValue("projectorpuzzle_rotation", 0f, new SetRtpcValueArgs?(new SetRtpcValueArgs
				{
					Actor = attachActor
				}));
			}
		}

		// Token: 0x06043CDE RID: 277726 RVA: 0x0118585C File Offset: 0x01183A5C
		private static bool SetupShadowCompensationActor(ProjectorComponent projectorComponent, ProjectorModel model)
		{
			AStaticMeshActor projectedActor = projectorComponent.ProjectedActor;
			if (projectedActor == null || !projectedActor.IsValid())
			{
				return false;
			}
			UStaticMeshComponent staticMeshComponent = projectedActor.StaticMeshComponent;
			UStaticMesh ustaticMesh = (staticMeshComponent != null) ? staticMeshComponent.StaticMesh : null;
			if (ustaticMesh == null || !ustaticMesh.IsValid())
			{
				return false;
			}
			AStaticMeshActor shadowActor = Singleton<ActorSystem>.Instance.Get(AStaticMeshActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as AStaticMeshActor;
			if (shadowActor == null || !shadowActor.IsValid())
			{
				Singleton<Log>.Instance.Warn(ELogModule.ProjectorPuzzle, ELogAuthor.WRY, "ProjectorPuzzle阴影补偿Actor创建失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			UStaticMeshComponent shadowMeshComp = shadowActor.StaticMeshComponent;
			if (shadowMeshComp == null)
			{
				Singleton<ActorSystem>.Instance.Put("[ProjectorPuzzleController] ShadowActorNoMeshComp", shadowActor, null);
				return false;
			}
			shadowMeshComp.SetMobility(EComponentMobility.Movable);
			shadowMeshComp.SetStaticMesh(ustaticMesh);
			shadowMeshComp.SetCastShadow(false);
			shadowMeshComp.MobileCastShadow = false;
			if (!string.IsNullOrEmpty("/Game/Aki/Render/Shaders/Scene/Interaction/MaterialInstance/MI_SceneInteraction_PlaneShadow.MI_SceneInteraction_PlaneShadow"))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInterface>("/Game/Aki/Render/Shaders/Scene/Interaction/MaterialInstance/MI_SceneInteraction_PlaneShadow.MI_SceneInteraction_PlaneShadow", delegate([Nullable(2)] UMaterialInterface mat, string _)
				{
					ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
					if (instance == null || !instance.IsActive)
					{
						return;
					}
					if (!shadowActor.IsValid() || !shadowMeshComp.IsValid())
					{
						instance.ShadowCompensationActor = null;
						return;
					}
					if (mat == null || !mat.IsValid())
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module = ELogModule.ProjectorPuzzle;
						ELogAuthor author = ELogAuthor.WRY;
						string message = "ProjectorPuzzle阴影补偿材质加载失败";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MaterialPath", "/Game/Aki/Render/Shaders/Scene/Interaction/MaterialInstance/MI_SceneInteraction_PlaneShadow.MI_SceneInteraction_PlaneShadow");
						instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						ProjectorPuzzleController.ReleaseShadowCompensationActor(instance);
						return;
					}
					if (!projectorComponent.Valid)
					{
						Singleton<Log>.Instance.Warn(ELogModule.ProjectorPuzzle, ELogAuthor.WRY, "ProjectorPuzzle阴影补偿材质回调时ProjectorComponent已失效", default(ReadOnlySpan<ValueTuple<string, object>>));
						ProjectorPuzzleController.ReleaseShadowCompensationActor(instance);
						return;
					}
					SceneItemActorComponent component = projectorComponent.Entity.GetComponent<SceneItemActorComponent>();
					if (component == null)
					{
						Singleton<Log>.Instance.Warn(ELogModule.ProjectorPuzzle, ELogAuthor.WRY, "ProjectorComponent找不到SceneItemActorComponent组件", default(ReadOnlySpan<ValueTuple<string, object>>));
						ProjectorPuzzleController.ReleaseShadowCompensationActor(instance);
						return;
					}
					AActor actorInSceneInteraction = component.GetActorInSceneInteraction("SpotLight");
					if (actorInSceneInteraction == null || !actorInSceneInteraction.IsValid())
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.ProjectorPuzzle;
						ELogAuthor author2 = ELogAuthor.WRY;
						string message2 = "ProjectorComponent找不到Light挂点Actor";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Key", "SpotLight");
						instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						ProjectorPuzzleController.ReleaseShadowCompensationActor(instance);
						return;
					}
					UMaterialInstanceDynamic umaterialInstanceDynamic = UKismetMaterialLibrary.CreateDynamicMaterialInstance(shadowActor, mat, default(FName), EMIDCreationFlags.None);
					if (umaterialInstanceDynamic == null || !umaterialInstanceDynamic.IsValid())
					{
						Singleton<Log>.Instance.Warn(ELogModule.ProjectorPuzzle, ELogAuthor.WRY, "ProjectorPuzzle阴影补偿动态材质实例创建失败", default(ReadOnlySpan<ValueTuple<string, object>>));
						ProjectorPuzzleController.ReleaseShadowCompensationActor(instance);
						return;
					}
					for (int i = 0; i < shadowMeshComp.GetNumMaterials(); i++)
					{
						shadowMeshComp.SetMaterial(i, umaterialInstanceDynamic);
					}
					global::Vector vector = global::Vector.Create(actorInSceneInteraction.D_K2_GetActorLocation());
					FLinearColor value = new FLinearColor((float)vector.X, (float)vector.Y, (float)vector.Z, 0f);
					umaterialInstanceDynamic.SetVectorParameterValue(ProjectorPuzzleController.SHADOW_COMPENSATION_LIGHT_POINT_POS_NAME, value);
					AStaticMeshActor projectedActor2 = projectorComponent.ProjectedActor;
					if (projectedActor2 != null && projectedActor2.IsValid())
					{
						shadowActor.D_K2_SetActorLocationAndRotation(projectedActor2.D_K2_GetActorLocation(), projectedActor2.K2_GetActorRotation(), false, ref WorldGlobal.SweepHitResult, false);
						shadowActor.D_SetActorScale3D(new FVectorDouble(3.299999952316284, 3.299999952316284, 3.299999952316284));
					}
				}, 100, "js_undefined");
			}
			model.ShadowCompensationActor = shadowActor;
			return true;
		}

		// Token: 0x06043CDF RID: 277727 RVA: 0x011859AC File Offset: 0x01183BAC
		private static void UpdateShadowCompensation()
		{
			ProjectorModel instance = ModelBase<ProjectorModel>.Instance;
			if (instance == null || !instance.IsActive)
			{
				return;
			}
			AStaticMeshActor shadowCompensationActor = instance.ShadowCompensationActor;
			if (shadowCompensationActor == null || !shadowCompensationActor.IsValid())
			{
				return;
			}
			AActor attachActor = instance.AttachActor;
			if (attachActor == null || !attachActor.IsValid())
			{
				return;
			}
			FRotator newRotation = attachActor.K2_GetActorRotation();
			shadowCompensationActor.K2_SetActorRotation(newRotation, false);
		}

		// Token: 0x06043CE0 RID: 277728 RVA: 0x01185A04 File Offset: 0x01183C04
		private static void ReleaseShadowCompensationActor(ProjectorModel model)
		{
			AStaticMeshActor shadowCompensationActor = model.ShadowCompensationActor;
			if (shadowCompensationActor != null && shadowCompensationActor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("[ProjectorPuzzleController] ReleaseShadowCompensationActor", shadowCompensationActor, null);
			}
			model.ShadowCompensationActor = null;
		}

		// Token: 0x06043CE2 RID: 277730 RVA: 0x01185A44 File Offset: 0x01183C44
		[CompilerGenerated]
		[return: Nullable(2)]
		internal static ProjectorComponent <ValidateAndGetProjectorComponent>g__Fail|21_0(string message, [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs, ref ProjectorPuzzleController.<>c__DisplayClass21_0 A_2)
		{
			Singleton<Log>.Instance.Warn(ELogModule.ProjectorPuzzle, ELogAuthor.WRY, message, pairs);
			A_2.finishCallback(false);
			return null;
		}

		// Token: 0x04025EC1 RID: 155329
		private const string BACKGROUND_DECAL_ATTACH_ACTOR_KEY = "ProjectorDecalAttachActor";

		// Token: 0x04025EC2 RID: 155330
		private const int BACKGROUND_DECAL_DELAY_REMOVE_ASSISTANT_ACTOR = 5000;

		// Token: 0x04025EC3 RID: 155331
		private const string SPOT_LIGHT_KEY = "SpotLight";

		// Token: 0x04025EC4 RID: 155332
		private const float SHADOW_COMPENSATION_SCALE = 3.3f;

		// Token: 0x04025EC5 RID: 155333
		private const string SHADOW_COMPENSATION_MATERIAL_PATH = "/Game/Aki/Render/Shaders/Scene/Interaction/MaterialInstance/MI_SceneInteraction_PlaneShadow.MI_SceneInteraction_PlaneShadow";

		// Token: 0x04025EC6 RID: 155334
		private static readonly FName SHADOW_COMPENSATION_LIGHT_POINT_POS_NAME = new FName("LightPointPos");

		// Token: 0x04025EC7 RID: 155335
		private const string ROTATION_LOOP_AUDIO_EVENT = "play_sfx_gp_projectorpuzzle_stonerotate_loop";

		// Token: 0x04025EC8 RID: 155336
		private const string ROTATION_RTPC_NAME = "projectorpuzzle_rotation";

		// Token: 0x04025EC9 RID: 155337
		private const float DRAG_RTPC_MAX_ANGULAR_VELOCITY = 6.2831855f;

		// Token: 0x04025ECA RID: 155338
		[Nullable(2)]
		private static AActor CurrentGameplayAssistantActor;

		// Token: 0x04025ECB RID: 155339
		private static int CurrentGameplayBackgroundEntityId;

		// Token: 0x04025ECC RID: 155340
		[Nullable(2)]
		private static TimerHandle DelayRemoveAssistantTimer;

		// Token: 0x04025ECD RID: 155341
		[Nullable(2)]
		private static AActor DelayedRemoveAssistantActor;

		// Token: 0x04025ECE RID: 155342
		private static int DelayedRemoveBackgroundEntityId;

		// Token: 0x04025ECF RID: 155343
		[Nullable(2)]
		private static EntityHandle DelayedRemoveBackgroundEntityHandle;

		// Token: 0x04025ED0 RID: 155344
		private static bool IsBackgroundEntityRemoveListenerRegistered;

		// Token: 0x0200CA22 RID: 51746
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403E18E RID: 254350
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<ERemoveEntityType, EntityHandle> <0>__OnBackgroundEntityRemoved;
		}
	}
}
