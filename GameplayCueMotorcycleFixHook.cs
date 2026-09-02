using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;

// Token: 0x02002FB2 RID: 12210
public class GameplayCueMotorcycleFixHook : GameplayCueBase
{
	// Token: 0x06018E6A RID: 101994 RVA: 0x0070D8E0 File Offset: 0x0070BAE0
	protected override void OnInit()
	{
	}

	// Token: 0x06018E6B RID: 101995 RVA: 0x0070D8E2 File Offset: 0x0070BAE2
	protected override void OnTick(float delta)
	{
	}

	// Token: 0x06018E6C RID: 101996 RVA: 0x0070D8E4 File Offset: 0x0070BAE4
	protected override void OnCreate()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		MotorcycleExploreComponent motorcycleExploreComponent = (entity != null) ? entity.GetComponent<MotorcycleExploreComponent>() : null;
		if (motorcycleExploreComponent == null || !motorcycleExploreComponent.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CK, "GameplayCueMotorcycleFixHook播放失败, 当前探索组件已失效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Vector interactingTargetLocation = motorcycleExploreComponent.GetInteractingTargetLocation();
		if (interactingTargetLocation == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CK;
			string message = "GameplayCueMotorcycleFixHook播放失败, interactingTargetLocation为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ClientEntityId", motorcycleExploreComponent.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.HookItem = GameplayCueHookCommonItem.Spawn(this.ActorInternal, FNameUtil.GetDynamicFName(this.CueConfig.Socket).Value, interactingTargetLocation.ToUeVector(false), this.GetResourcePaths(), true);
	}

	// Token: 0x06018E6D RID: 101997 RVA: 0x0070D9B0 File Offset: 0x0070BBB0
	[NullableContext(1)]
	private string[] GetResourcePaths()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
		string[] array = this.CueConfig.Resources();
		if (baseActorComponent == null || !baseActorComponent.Valid)
		{
			return array;
		}
		string[] array2 = new string[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = (baseActorComponent.GetReplaceEffect(array[i]) ?? array[i]);
		}
		return array2;
	}

	// Token: 0x06018E6E RID: 101998 RVA: 0x0070DA1F File Offset: 0x0070BC1F
	protected override void OnDestroy()
	{
		if (this.HookItem != null)
		{
			this.HookItem.Destroy();
			this.HookItem = null;
		}
	}

	// Token: 0x0400C28B RID: 49803
	[Nullable(2)]
	private GameplayCueHookCommonItem HookItem;
}
