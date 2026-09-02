using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Audio;
using UnrealEngine;

// Token: 0x02002DD7 RID: 11735
[NullableContext(2)]
[Nullable(0)]
public class HitStaticFunction
{
	// Token: 0x06017A6D RID: 96877 RVA: 0x0069981D File Offset: 0x00697A1D
	public static void PlayHitAudio(ELoadEffectResult result, int handle, string audioEvent, ERoleAudioPriorityType fromPrimaryRole)
	{
		if (result != ELoadEffectResult.Success)
		{
			return;
		}
		HitStaticFunction.PlayHitAudioByActor(Singleton<EffectSystem>.Instance.GetSureEffectActor(handle), audioEvent, fromPrimaryRole);
	}

	// Token: 0x06017A6E RID: 96878 RVA: 0x00699838 File Offset: 0x00697A38
	public static void PlayHitAudioByActor(AActor actor, string audioEvent, ERoleAudioPriorityType fromPrimaryRole)
	{
		if (audioEvent == null || StringUtils.IsBlank(audioEvent))
		{
			return;
		}
		if (ControllerBase<EffectAudioController>.Instance.CheckHitEffectCooldownTime(new EHitEffectType?(EHitEffectType.BulletHitEffect), audioEvent))
		{
			return;
		}
		ControllerBase<EffectAudioController>.Instance.AddPlayEffectAudio(audioEvent, (actor != null) ? actor.D_GetTransform() : default(FTransformDouble), new EHitEffectType?(EHitEffectType.BulletHitEffect), new ERoleAudioPriorityType?((fromPrimaryRole == ERoleAudioPriorityType.PlayerControl) ? ERoleAudioPriorityType.PlayerControl : ERoleAudioPriorityType.OtherControl), null, new bool?(true));
	}

	// Token: 0x06017A6F RID: 96879 RVA: 0x006998A8 File Offset: 0x00697AA8
	public static EffectContext CreateEffectContext(Entity attacker, bool disablePostProcess)
	{
		if (attacker == null)
		{
			return null;
		}
		CharacterAudioComponent component = attacker.GetComponent<CharacterAudioComponent>();
		BaseActorComponent component2 = attacker.GetComponent<BaseActorComponent>();
		EffectContext effectContext = null;
		if (component2 != null && component2.Valid)
		{
			if (component != null)
			{
				effectContext = new EffectAudioContext
				{
					FromPrimaryRole = (component.CurrentPriority == ERoleAudioPriorityType.PlayerControl)
				};
			}
			else
			{
				effectContext = new EffectContext();
			}
			effectContext.SourceObject = component2.Owner;
			effectContext.EntityId = new int?(attacker.Id);
			effectContext.DisablePostProcess = disablePostProcess;
		}
		return effectContext;
	}
}
