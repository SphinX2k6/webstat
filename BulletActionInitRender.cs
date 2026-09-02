using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Render;
using UnrealEngine;

// Token: 0x02002D8D RID: 11661
public class BulletActionInitRender : BulletActionBase
{
	// Token: 0x06017848 RID: 96328 RVA: 0x006892C9 File Offset: 0x006874C9
	public BulletActionInitRender(EBulletAction type) : base(type)
	{
	}

	// Token: 0x06017849 RID: 96329 RVA: 0x006892D4 File Offset: 0x006874D4
	protected override void OnExecute()
	{
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		if (bulletDataMain.Logic.InteractWithAirWall)
		{
			this.AirWallEffect = new SceneObjectAirWallEffect();
			this.AirWallEffect.Start(this.BulletInfo.CollisionInfo.CollisionComponent);
			SceneInteractionManager.Get().RegisterAirWallEffectObject(this.AirWallEffect);
		}
		FName attackerCameraShakeOnStart = bulletDataMain.Render.AttackerCameraShakeOnStart;
		if (attackerCameraShakeOnStart != FName.NAME_None)
		{
			EntityHandle attackerHandle = this.BulletInfo.AttackerHandle;
			if (attackerHandle != null && attackerHandle.Valid && CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(this.BulletInfo.AttackerHandle) && this.BulletInfo.IsAutonomousProxy && BulletUtil.IsPlayerOrSummons(this.BulletInfo))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(attackerCameraShakeOnStart.ToString(), delegate([Nullable(2)] UClass shakeType, string _)
				{
					FVectorDouble value = Global.CharacterCameraManager.D_GetCameraLocation();
					ControllerBase<CameraController>.Instance.PlayWorldCameraShake(shakeType, new FVectorDouble?(value), 0f, 100f, 1f, false, "MainCamera");
				}, 100, "js_undefined");
			}
		}
	}

	// Token: 0x0601784A RID: 96330 RVA: 0x006893D0 File Offset: 0x006875D0
	public float GetSize()
	{
		if (this.BulletInfo.BulletDataMain.Base.Shape == EBulletShape.Cube)
		{
			return (float)Math.Max(this.BulletInfo.Size.X, this.BulletInfo.Size.Y);
		}
		return (float)this.BulletInfo.Size.X;
	}

	// Token: 0x0601784B RID: 96331 RVA: 0x0068942C File Offset: 0x0068762C
	public override void Clear()
	{
		base.Clear();
		if (this.AirWallEffect != null)
		{
			SceneInteractionManager.Get().UnregisterAirWallEffectObject(this.AirWallEffect);
			this.AirWallEffect = null;
		}
	}

	// Token: 0x0400B472 RID: 46194
	[Nullable(2)]
	private SceneObjectAirWallEffect AirWallEffect;
}
