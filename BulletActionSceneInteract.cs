using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Module;
using UnrealEngine;

// Token: 0x02002D90 RID: 11664
public class BulletActionSceneInteract : BulletActionBase
{
	// Token: 0x0601785B RID: 96347 RVA: 0x00689B92 File Offset: 0x00687D92
	public BulletActionSceneInteract(EBulletAction type) : base(type)
	{
	}

	// Token: 0x0601785C RID: 96348 RVA: 0x00689B9C File Offset: 0x00687D9C
	protected override void OnExecute()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		if (!bulletDataMain.Interact.IsSceneInteract || !ModelBase<SceneBattleInteractModel>.Instance.Open)
		{
			this.IsFinish = true;
			return;
		}
		if (this.BulletInfo.CollisionInfo.CollisionComponent == null)
		{
			this.IsFinish = true;
			return;
		}
		BP_SceneBattleInteract_C bp_SceneBattleInteract_C = Singleton<ResourceSystem>.Instance.Load<BP_SceneBattleInteract_C>(bulletDataMain.Interact.SceneInteract.ToString(), "js_undefined");
		SceneBattleInteractEffect sceneBattleInteractEffect = ModelBase<SceneBattleInteractModel>.Instance.CreateSceneBattleInteract(bp_SceneBattleInteract_C, this.GetRadius(), 0f);
		if (sceneBattleInteractEffect != null)
		{
			this.HandleId = sceneBattleInteractEffect.Id;
			sceneBattleInteractEffect.SetUpdateLocationFunc(new Action<Vector, FVectorDouble?>(this.UpdateLocation));
			sceneBattleInteractEffect.SetEnable(true, 0f);
			global::ESceneBattleInteractEntityType esceneBattleInteractEntityType = (global::ESceneBattleInteractEntityType)bp_SceneBattleInteract_C.EntityType;
			if (esceneBattleInteractEntityType == global::ESceneBattleInteractEntityType.Player || esceneBattleInteractEntityType == global::ESceneBattleInteractEntityType.Summoned)
			{
				Entity attacker = this.BulletInfo.Attacker;
				if (attacker != null && attacker.Valid)
				{
					if (esceneBattleInteractEntityType == global::ESceneBattleInteractEntityType.Summoned)
					{
						CreatureDataComponent attackerCreatureDataComp = this.BulletInfo.AttackerCreatureDataComp;
						long? num = (attackerCreatureDataComp != null) ? new long?(attackerCreatureDataComp.GetSummonerId()) : null;
						if (num != null)
						{
							int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(num.Value);
							sceneBattleInteractEffect.BindEntityId(entityId);
							return;
						}
					}
					else
					{
						sceneBattleInteractEffect.BindEntityId(attacker.Id);
					}
				}
			}
		}
	}

	// Token: 0x0601785D RID: 96349 RVA: 0x00689CF4 File Offset: 0x00687EF4
	[NullableContext(1)]
	private void UpdateLocation(Vector outVector, FVectorDouble? offset = null)
	{
		Vector collisionLocation = this.BulletInfo.GetCollisionLocation(false);
		if (offset == null)
		{
			outVector.FromUeVector(collisionLocation);
			return;
		}
		FTransformDouble collisionTransform = this.BulletInfo.CollisionInfo.CollisionTransform;
		FVectorDouble value = offset.Value;
		FVectorDouble fvectorDouble = collisionTransform.TransformVector(value);
		outVector.FromUeVector(fvectorDouble);
		outVector.AdditionEqual(collisionLocation);
	}

	// Token: 0x0601785E RID: 96350 RVA: 0x00689D54 File Offset: 0x00687F54
	private float GetRadius()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		Vector size = this.BulletInfo.Size;
		float result = 0f;
		EBulletShape shape = bulletDataMain.Base.Shape;
		if (shape != EBulletShape.Cube)
		{
			if (shape - EBulletShape.Sphere <= 2)
			{
				result = (float)size.X;
			}
		}
		else
		{
			result = (float)size.GetMin();
		}
		return result;
	}

	// Token: 0x0601785F RID: 96351 RVA: 0x00689DA7 File Offset: 0x00687FA7
	public override void Clear()
	{
		base.Clear();
		ModelBase<SceneBattleInteractModel>.Instance.DestroySceneBattleInteract(this.HandleId);
	}

	// Token: 0x0400B47F RID: 46207
	private int HandleId;
}
