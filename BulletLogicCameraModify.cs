using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02002DBC RID: 11708
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicCameraModify : BulletLogicController<LogicDataCameraModify, BulletHitActorData>
{
	// Token: 0x060179CE RID: 96718 RVA: 0x00692227 File Offset: 0x00690427
	[NullableContext(1)]
	public BulletLogicCameraModify(LogicDataCameraModify logicData, Entity bulletEntity) : base(logicData, bulletEntity)
	{
		this.Config = logicData;
	}

	// Token: 0x060179CF RID: 96719 RVA: 0x00692238 File Offset: 0x00690438
	public override void BulletLogicAction(BulletHitActorData param = null)
	{
		EBulletCameraModifyPlayer player = this.Config.Player;
		if (player == EBulletCameraModifyPlayer.Attacker || player == EBulletCameraModifyPlayer.AttackerAndVictim)
		{
			this.PlayCameraModify(this.Bullet.GetBulletInfo().AttackerHandle);
		}
		if (player == EBulletCameraModifyPlayer.Victim || player == EBulletCameraModifyPlayer.AttackerAndVictim)
		{
			this.PlayCameraModify((param != null) ? param.EntityHandle : null);
		}
	}

	// Token: 0x060179D0 RID: 96720 RVA: 0x00692288 File Offset: 0x00690488
	private void PlayCameraModify(EntityHandle entityHandle)
	{
		if (entityHandle == null || !entityHandle.Valid)
		{
			return;
		}
		CharacterActorComponent component = entityHandle.Entity.GetComponent<CharacterActorComponent>();
		TsBaseCharacter tsBaseCharacter = (component != null) ? component.Actor : null;
		if (tsBaseCharacter == null)
		{
			return;
		}
		if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityHandle))
		{
			return;
		}
		FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
		if (logicComponent == null || !logicComponent.Valid)
		{
			return;
		}
		if (CameraUtility.CheckApplyCameraModifyCondition(entityHandle, this.Config.ModifierSettings, this.Config.ClientType, this.Config.Conditions))
		{
			OneOf<TsBaseCharacter, TsBaseVehicle> newLookAtActor = default(OneOf<TsBaseCharacter, TsBaseVehicle>);
			if (this.Config.ClientType != ECameraAnsEffectiveClientType.单客户端_角色为中心_ && this.Config.ClientType != ECameraAnsEffectiveClientType.全客户端_角色为中心_ && this.Config.ClientType != ECameraAnsEffectiveClientType.锁定目标客户端_角色为中心_ && this.Config.ClientType != ECameraAnsEffectiveClientType.仇恨目标客户端_角色为中心_)
			{
				newLookAtActor = tsBaseCharacter;
				this.Config.ModifierSettings.IsLockInput = true;
				this.Config.ModifierSettings.OverrideCameraInput = true;
			}
			logicComponent.ApplyCameraModify(new FGameplayTag?(this.Config.Tag), this.Config.Duration, this.Config.BlendIn, this.Config.BlendOut, this.Config.ModifierSettings, null, this.Config.BlendOutInterrupt, null, null, newLookAtActor, this.Config.CameraAttachSocket, new OneOf<TsBaseCharacter, TsBaseVehicle>(tsBaseCharacter));
		}
	}

	// Token: 0x0400B5DA RID: 46554
	private readonly LogicDataCameraModify Config;
}
