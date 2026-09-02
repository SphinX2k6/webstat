using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using UnrealEngine;

// Token: 0x02002FAE RID: 12206
[NullableContext(2)]
[Nullable(0)]
public class GameplayCueManipulateInteract : GameplayCueBase
{
	// Token: 0x06018E3F RID: 101951 RVA: 0x0070CDBB File Offset: 0x0070AFBB
	protected override void OnInit()
	{
	}

	// Token: 0x06018E40 RID: 101952 RVA: 0x0070CDBD File Offset: 0x0070AFBD
	protected override void OnTick(float delta)
	{
	}

	// Token: 0x06018E41 RID: 101953 RVA: 0x0070CDC0 File Offset: 0x0070AFC0
	protected override void OnCreate()
	{
		FVectorDouble? targetPosition = this.GetTargetPosition();
		if (targetPosition == null)
		{
			return;
		}
		bool lineAttach = this.CueConfig.ParametersLength <= 0 || this.CueConfig.Parameters(0) == "0";
		this.HookItem = GameplayCueHookCommonItem.Spawn(this.ActorInternal, FNameUtil.GetDynamicFName(this.CueConfig.Socket).Value, targetPosition.Value, this.CueConfig.Resources(), lineAttach);
	}

	// Token: 0x06018E42 RID: 101954 RVA: 0x0070CE42 File Offset: 0x0070B042
	protected override void OnDestroy()
	{
		if (this.HookItem != null)
		{
			this.HookItem.Destroy();
			this.HookItem = null;
		}
	}

	// Token: 0x06018E43 RID: 101955 RVA: 0x0070CE60 File Offset: 0x0070B060
	protected FVectorDouble? GetTargetPosition()
	{
		CharacterManipulateInteractComponent interactComponent = this.GetInteractComponent();
		if (interactComponent == null)
		{
			return null;
		}
		return new FVectorDouble?(interactComponent.GetTargetLocation().ToUeVector(false));
	}

	// Token: 0x06018E44 RID: 101956 RVA: 0x0070CE94 File Offset: 0x0070B094
	private CharacterManipulateInteractComponent GetInteractComponent()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterManipulateInteractComponent component = entity.GetComponent<CharacterManipulateInteractComponent>();
		if (component != null)
		{
			return component;
		}
		if (entity.GetComponent<FollowShooterComponent>() == null)
		{
			return null;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			return null;
		}
		WorldEntity entity2 = getCurrentEntity.Entity;
		if (entity2 == null)
		{
			return null;
		}
		return entity2.GetComponent<CharacterManipulateInteractComponent>();
	}

	// Token: 0x0400C281 RID: 49793
	private GameplayCueHookCommonItem HookItem;
}
