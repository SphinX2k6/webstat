using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance.Level
{
	// Token: 0x02006EBF RID: 28351
	[NullableContext(1)]
	[Nullable(0)]
	public class FindSunSpiritShootEffect
	{
		// Token: 0x06044B9D RID: 281501 RVA: 0x011DDF60 File Offset: 0x011DC160
		public void InitConfig(string lineEffectPath, string endEffectPath)
		{
			this.LineEffectPath = lineEffectPath;
			this.EndEffectPath = endEffectPath;
			this.TempTransform.SetRotation(ModelBase<FindSunSpiritModel>.Instance.LevelQuat);
		}

		// Token: 0x06044B9E RID: 281502 RVA: 0x011DDF88 File Offset: 0x011DC188
		public void SpawnEffect(Vector targetLocation)
		{
			Vector tempVector = this.TempVector;
			Vector tempVector2 = this.TempVector2;
			Vector vector = tempVector;
			FVectorDouble fvectorDouble = Global.CharacterCameraManager.D_GetCameraLocation();
			vector.FromUeVector(fvectorDouble);
			Vector vector2 = tempVector2;
			FVector actorUpVector = Global.CharacterCameraManager.GetActorUpVector();
			vector2.FromUeVector(actorUpVector);
			tempVector.AdditionEqual(tempVector2.MultiplyEqual(-150.0));
			Transform tempTransform = this.TempTransform;
			tempTransform.SetLocation(tempVector);
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(tempTransform.ToUeTransform());
			int id = instance.SpawnEffect(world, ftransformDouble, this.LineEffectPath, "[FindSunSpiritGuideLine.SpawnShootLineEffect]", null, EEffectType.Scene, null, null, null, false, false);
			OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> niagaraComponent = Singleton<EffectSystem>.Instance.GetNiagaraComponent(id);
			FVector fvector = UKismetMathLibrary.WD_WorldToLocal(GlobalData.World, targetLocation.ToUeVector(false));
			niagaraComponent.SetNiagaraVariableVec3("end", fvector);
			tempTransform.SetLocation(targetLocation);
			EffectSystem instance2 = Singleton<EffectSystem>.Instance;
			UObject world2 = GlobalData.World;
			ftransformDouble = new FTransformDouble?(tempTransform.ToUeTransform());
			instance2.SpawnEffect(world2, ftransformDouble, this.EndEffectPath, "[FindSunSpiritGuideLine.SpawnShootEndEffect]", null, EEffectType.Scene, null, null, null, false, false);
		}

		// Token: 0x04026444 RID: 156740
		private const float OFFSET_LENGTH = -150f;

		// Token: 0x04026445 RID: 156741
		private string LineEffectPath = "";

		// Token: 0x04026446 RID: 156742
		private string EndEffectPath = "";

		// Token: 0x04026447 RID: 156743
		private readonly Transform TempTransform = Transform.Create();

		// Token: 0x04026448 RID: 156744
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x04026449 RID: 156745
		private readonly Vector TempVector2 = Vector.Create();
	}
}
