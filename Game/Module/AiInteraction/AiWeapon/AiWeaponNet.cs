using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.AiInteraction.AiWeapon
{
	// Token: 0x02006186 RID: 24966
	[NullableContext(1)]
	[Nullable(0)]
	public class AiWeaponNet
	{
		// Token: 0x0603F169 RID: 258409 RVA: 0x0102E2D7 File Offset: 0x0102C4D7
		public void RegisterNet()
		{
			Singleton<Net>.Instance.Register<HoldWeaponNotify>(ENotifyMessageId.HoldWeaponNotify, delegate(HoldWeaponNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				this.OnHoldWeaponNotify(response);
			});
		}

		// Token: 0x0603F16A RID: 258410 RVA: 0x0102E2F5 File Offset: 0x0102C4F5
		public void UnRegisterNet()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HoldWeaponNotify);
		}

		// Token: 0x0603F16B RID: 258411 RVA: 0x0102E308 File Offset: 0x0102C508
		private void OnHoldWeaponNotify(HoldWeaponNotify response)
		{
			long creatureDataId = Singleton<MathUtils>.Instance.LongToNumber(response.EntityId);
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
			if (entity == null)
			{
				return;
			}
			WorldEntity entity2 = entity.Entity;
			CharacterWeaponComponent characterWeaponComponent = (entity2 != null) ? entity2.GetComponent<CharacterWeaponComponent>() : null;
			if (characterWeaponComponent == null)
			{
				return;
			}
			if (response.WeaponConfId != 0)
			{
				characterWeaponComponent.RegisterCharacterDropWeaponEvent(response.WeaponConfId);
				characterWeaponComponent.ChangeWeaponByWeaponByConfigId(response.WeaponConfId);
				return;
			}
			characterWeaponComponent.ClearWeaponForAi();
		}

		// Token: 0x0603F16C RID: 258412 RVA: 0x0102E374 File Offset: 0x0102C574
		public bool SendHoldWeaponPushOnSafe(int entityId, int itemEntityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(itemEntityId);
			return entity != null && entity.GetComponent<SceneItemAiInteractionComponent>().CanBeUsed() && this.SendHoldWeaponPush(entityId, itemEntityId);
		}

		// Token: 0x0603F16D RID: 258413 RVA: 0x0102E3AC File Offset: 0x0102C5AC
		public bool SendHoldWeaponPush(int entityId, int itemEntityId)
		{
			HoldWeaponPush holdWeaponPush = HoldWeaponPush.Create();
			holdWeaponPush.EntityId = this.GetCreateDataId(entityId);
			holdWeaponPush.WeaponEntityId = this.GetCreateDataId(itemEntityId);
			Singleton<Net>.Instance.Send(EPushMessageId.HoldWeaponPush, holdWeaponPush);
			return true;
		}

		// Token: 0x0603F16E RID: 258414 RVA: 0x0102E3EC File Offset: 0x0102C5EC
		public bool SendDiscardWeaponPush(CharacterWeaponComponent weaponComp)
		{
			if (weaponComp.AiWeaponConfigId == 0)
			{
				return false;
			}
			SWeaponSocketItem weaponConfigByConfigId = ModelBase<AiWeaponModel>.Instance.GetWeaponConfigByConfigId(weaponComp.AiWeaponConfigId, weaponComp.Entity);
			if (weaponConfigByConfigId == null)
			{
				return false;
			}
			DiscardWeaponRequest discardWeaponRequest = DiscardWeaponRequest.Create();
			MovementInformation movementInformation = MovementInformation.Create();
			discardWeaponRequest.EntityId = this.GetCreateDataId(weaponComp.Entity.Id);
			CharacterActorComponent component = weaponComp.Entity.GetComponent<CharacterActorComponent>();
			CharacterHitComponent component2 = weaponComp.Entity.GetComponent<CharacterHitComponent>();
			global::Vector vector;
			if (component2.GetHitData() != null)
			{
				vector = global::Vector.Create(component2.GetHitData().HitPosition);
			}
			else
			{
				vector = global::Vector.Create(component.ActorLocation);
				vector.Z -= 50.0;
			}
			global::Vector vector2 = global::Vector.Create(component.ActorLocation);
			vector2.SubtractionEqual(vector);
			vector2.X *= 100.0;
			vector2.Y *= 100.0;
			vector2.Z *= 5.0;
			vector2.X = this.CalculateWeight(vector2.X);
			vector2.Y = this.CalculateWeight(vector2.Y);
			vector2.Z = Math.Abs(this.CalculateWeight(vector2.Z));
			FVectorDouble fvectorDouble = component.Actor.Mesh.D_GetSocketLocation(weaponConfigByConfigId.DropSocket);
			global::Rotator rotator = global::Rotator.Create();
			vector2.Rotation(rotator);
			movementInformation.Location = Aki.Protocol.Vector.Create();
			movementInformation.Location.X = (float)fvectorDouble.X;
			movementInformation.Location.Y = (float)fvectorDouble.Y;
			movementInformation.Location.Z = (float)fvectorDouble.Z;
			movementInformation.Rotation = Aki.Protocol.Rotator.Create();
			movementInformation.Rotation.Roll = rotator.Roll;
			movementInformation.Rotation.Pitch = rotator.Pitch;
			movementInformation.Rotation.Yaw = rotator.Yaw;
			movementInformation.LinearVelocity = Aki.Protocol.Vector.Create();
			movementInformation.LinearVelocity.X = (float)vector2.X;
			movementInformation.LinearVelocity.Y = (float)vector2.Y;
			movementInformation.LinearVelocity.Z = (float)vector2.Z;
			discardWeaponRequest.MovementInformation = movementInformation;
			Singleton<Net>.Instance.Call<DiscardWeaponResponse>(ERequestMessageId.DiscardWeaponRequest, discardWeaponRequest, delegate(DiscardWeaponResponse _, Net.CallbackStatus _)
			{
			}, 0);
			return true;
		}

		// Token: 0x0603F16F RID: 258415 RVA: 0x0102E678 File Offset: 0x0102C878
		private long GetCreateDataId(int entityId)
		{
			long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId);
			return Singleton<MathUtils>.Instance.NumberToLong(creatureDataId);
		}

		// Token: 0x0603F170 RID: 258416 RVA: 0x0102E69C File Offset: 0x0102C89C
		public double CalculateWeight(double size)
		{
			double num = Math.Abs(size);
			int num2 = (size > 0.0) ? 1 : -1;
			int num3 = 600;
			num = Singleton<MathUtils>.Instance.Clamp(num, 0.0, (double)num3);
			return ((double)num3 - num) * (double)num2;
		}

		// Token: 0x0402361C RID: 144924
		private const int MAX_SPEED_SIZE = 600;
	}
}
