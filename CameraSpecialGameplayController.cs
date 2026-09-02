using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Camera.FightCameraController.SpecialGameplay;
using UnrealEngine;

// Token: 0x02000E31 RID: 3633
[GeneratePropertyAccessMethod(true)]
public class CameraSpecialGameplayController : CameraControllerBase<EFightCameraSpecialGameplay>
{
	// Token: 0x06005617 RID: 22039 RVA: 0x000EB377 File Offset: 0x000E9577
	[NullableContext(1)]
	public CameraSpecialGameplayController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x06005618 RID: 22040 RVA: 0x000EB380 File Offset: 0x000E9580
	[NullableContext(1)]
	public override string Name()
	{
		return "SpecialGameplayController";
	}

	// Token: 0x06005619 RID: 22041 RVA: 0x000EB387 File Offset: 0x000E9587
	protected override void OnInit()
	{
		base.Lock(this);
	}

	// Token: 0x0600561A RID: 22042 RVA: 0x000EB390 File Offset: 0x000E9590
	protected override void UpdateInternal(float deltaTime)
	{
		ISpecialGameplayCamera currentGameplay = this.CurrentGameplay;
		if (currentGameplay == null)
		{
			return;
		}
		currentGameplay.Update(deltaTime);
	}

	// Token: 0x0600561B RID: 22043 RVA: 0x000EB3A4 File Offset: 0x000E95A4
	public void EnterSpecialGameplayController(int gameplayId, float blendInTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear)
	{
		if (this.CameraActor == null)
		{
			this.CameraActor = ControllerBase<CameraController>.Instance.SpawnCameraActor();
		}
		ControllerBase<CameraController>.Instance.SetViewTarget(this.CameraActor, "EnterSpecialGameplayController", blendInTime, blendFunction, 0f, new bool?(false), new bool?(false), this.Camera.CameraModel.CameraName, null, null);
		if (SpecialGameplayCamera.GameplayMap.ContainsKey(gameplayId))
		{
			this.CurrentGameplay = SpecialGameplayCamera.GameplayMap[gameplayId]();
			this.CurrentGameplayId = new int?(gameplayId);
			this.CurrentGameplay.OnInit(this.CameraActor, base.CameraModel);
		}
		base.Unlock(this);
	}

	// Token: 0x0600561C RID: 22044 RVA: 0x000EB450 File Offset: 0x000E9650
	public void ExitSpecialGameplayController(float blendOutTime = 0f)
	{
		if (this.Camera.CameraActor.IsValid())
		{
			ControllerBase<CameraController>.Instance.SetViewTarget(this.Camera.CameraActor, "ExitSpecialGameplayController", blendOutTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), this.Camera.CameraModel.CameraName, null, null);
		}
		if (this.CameraActor != null)
		{
			Singleton<ActorSystem>.Instance.Put("CameraSpecialGameplayController.ExitSpecialGameplayController", this.CameraActor, null);
			this.CameraActor = null;
		}
		ISpecialGameplayCamera currentGameplay = this.CurrentGameplay;
		if (currentGameplay != null)
		{
			currentGameplay.OnDestroy();
		}
		this.CurrentGameplay = null;
		this.CurrentGameplayId = null;
		base.Lock(this);
	}

	// Token: 0x0600561D RID: 22045 RVA: 0x000EB500 File Offset: 0x000E9700
	public bool CheckIsInSpecialGameplay(int gameplayId)
	{
		int? currentGameplayId = this.CurrentGameplayId;
		return currentGameplayId.GetValueOrDefault() == gameplayId & currentGameplayId != null;
	}

	// Token: 0x0600561E RID: 22046 RVA: 0x000EB528 File Offset: 0x000E9728
	[NullableContext(1)]
	[return: Nullable(2)]
	public T GetCurrentGameplay<T>() where T : class, ISpecialGameplayCamera
	{
		return this.CurrentGameplay as T;
	}

	// Token: 0x0600561F RID: 22047 RVA: 0x000EB53A File Offset: 0x000E973A
	[NullableContext(1)]
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraSpecialGameplay)key);
	}

	// Token: 0x06005620 RID: 22048 RVA: 0x000EB544 File Offset: 0x000E9744
	public override bool TryGetMember(string key, out object value)
	{
		if (key == "CameraActor")
		{
			value = this.CameraActor;
			return true;
		}
		if (key == "CurrentGameplay")
		{
			value = this.CurrentGameplay;
			return true;
		}
		if (!(key == "CurrentGameplayId"))
		{
			return base.TryGetMember(key, out value);
		}
		value = this.CurrentGameplayId;
		return true;
	}

	// Token: 0x06005621 RID: 22049 RVA: 0x000EB5A8 File Offset: 0x000E97A8
	public override void SetMember(string key, object value)
	{
		if (key == "CameraActor")
		{
			this.CameraActor = (ACameraActor)value;
			return;
		}
		if (key == "CurrentGameplay")
		{
			this.CurrentGameplay = (ISpecialGameplayCamera)value;
			return;
		}
		if (!(key == "CurrentGameplayId"))
		{
			base.SetMember(key, value);
			return;
		}
		this.CurrentGameplayId = (int?)value;
	}

	// Token: 0x06005622 RID: 22050 RVA: 0x000EB60D File Offset: 0x000E980D
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraSpecialGameplayController.<MemberIter>d__14 <MemberIter>d__ = new CameraSpecialGameplayController.<MemberIter>d__14(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001BD6 RID: 7126
	[Nullable(2)]
	public ACameraActor CameraActor;

	// Token: 0x04001BD7 RID: 7127
	[Nullable(2)]
	private ISpecialGameplayCamera CurrentGameplay;

	// Token: 0x04001BD8 RID: 7128
	private int? CurrentGameplayId;
}
