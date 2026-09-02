using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BFA RID: 27642
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventSpawnBlueprintActor : LevelEventBase
	{
		// Token: 0x06044115 RID: 278805 RVA: 0x011ABA90 File Offset: 0x011A9C90
		public LevelEventSpawnBlueprintActor(int id) : base(id)
		{
		}

		// Token: 0x06044116 RID: 278806 RVA: 0x011ABA99 File Offset: 0x011A9C99
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			LevelEventSpawnBlueprintActor.ExecuteNewManually(inParams, context);
		}

		// Token: 0x06044117 RID: 278807 RVA: 0x011ABAA4 File Offset: 0x011A9CA4
		public unsafe static void ExecuteNewManually(ActionParams inParams, [Nullable(2)] GeneralContext context = null)
		{
			ActionSpawnBlueprintActor actionSpawnBlueprintActor = inParams as ActionSpawnBlueprintActor;
			if (actionSpawnBlueprintActor != null)
			{
				if (actionSpawnBlueprintActor.SpawnBlueprintParam == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.XDW;
					string message = "[LevelEventSpawnBlueprintActor] 无效参数";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("inParams", inParams);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("context", context);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				if (actionSpawnBlueprintActor.SpawnBlueprintParam.Type == ELevelEventBlueprintToSpawnType.DestructibleStoneTrackTargetWhileRotate)
				{
					LevelEventSpawnBlueprintActor.SpawnDestructibleStoneTrackTargetWhileRotate(actionSpawnBlueprintActor.SpawnBlueprintParam);
				}
			}
		}

		// Token: 0x06044118 RID: 278808 RVA: 0x011ABB30 File Offset: 0x011A9D30
		private static UniTask LoadTypeAsync(EBpTypeName name)
		{
			LevelEventSpawnBlueprintActor.<LoadTypeAsync>d__3 <LoadTypeAsync>d__;
			<LoadTypeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadTypeAsync>d__.name = name;
			<LoadTypeAsync>d__.<>1__state = -1;
			<LoadTypeAsync>d__.<>t__builder.Start<LevelEventSpawnBlueprintActor.<LoadTypeAsync>d__3>(ref <LoadTypeAsync>d__);
			return <LoadTypeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044119 RID: 278809 RVA: 0x011ABB74 File Offset: 0x011A9D74
		private static void ApplyRotateParam([Nullable(2)] UKuroFauxPhysicsRotateComponentBase baseRotateComponent, IFauxPhysicsRotateParam rotateParam)
		{
			if (baseRotateComponent != null && baseRotateComponent.IsValid())
			{
				baseRotateComponent.ResetInternalState();
				FVector? fvector = null;
				if (rotateParam.RelativeOffset != null)
				{
					FVector fvector2 = baseRotateComponent.K2_GetComponentLocation();
					FVector? relativeOffset = rotateParam.RelativeOffset;
					FVector? fvector3;
					if (relativeOffset == null)
					{
						fvector3 = null;
					}
					else
					{
						FVector fvector4 = relativeOffset.GetValueOrDefault();
						fvector3 = new FVector?(fvector2 + fvector4);
					}
					fvector = fvector3;
				}
				if (rotateParam.Origin != null)
				{
					fvector = rotateParam.Origin;
				}
				if (fvector != null)
				{
					if (rotateParam.Impulse != null)
					{
						FVector fvector4 = fvector.Value;
						FVector fvector2 = rotateParam.Impulse.Value;
						baseRotateComponent.ApplyImpulse(fvector4, fvector2);
					}
					if (rotateParam.Force != null)
					{
						FVector fvector4 = fvector.Value;
						FVector fvector2 = rotateParam.Force.Value;
						baseRotateComponent.ApplyForce(fvector4, fvector2);
					}
					if (rotateParam.Movement != null)
					{
						FVector fvector4 = fvector.Value;
						FVector fvector2 = rotateParam.Movement.Value;
						baseRotateComponent.ApplyMovement(fvector4, fvector2);
					}
				}
			}
		}

		// Token: 0x0604411A RID: 278810 RVA: 0x011ABCA4 File Offset: 0x011A9EA4
		private static UniTask SpawnDestructibleStoneTrackTargetWhileRotate(ISpawnDestructibleStoneTrackTargetWhileRotate inParams)
		{
			LevelEventSpawnBlueprintActor.<SpawnDestructibleStoneTrackTargetWhileRotate>d__5 <SpawnDestructibleStoneTrackTargetWhileRotate>d__;
			<SpawnDestructibleStoneTrackTargetWhileRotate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SpawnDestructibleStoneTrackTargetWhileRotate>d__.inParams = inParams;
			<SpawnDestructibleStoneTrackTargetWhileRotate>d__.<>1__state = -1;
			<SpawnDestructibleStoneTrackTargetWhileRotate>d__.<>t__builder.Start<LevelEventSpawnBlueprintActor.<SpawnDestructibleStoneTrackTargetWhileRotate>d__5>(ref <SpawnDestructibleStoneTrackTargetWhileRotate>d__);
			return <SpawnDestructibleStoneTrackTargetWhileRotate>d__.<>t__builder.Task;
		}
	}
}
