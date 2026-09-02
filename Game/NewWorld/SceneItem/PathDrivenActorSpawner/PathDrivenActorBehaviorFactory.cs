using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x02004831 RID: 18481
	[NullableContext(1)]
	[Nullable(0)]
	public class PathDrivenActorBehaviorFactory
	{
		// Token: 0x06030171 RID: 196977 RVA: 0x00BA9F00 File Offset: 0x00BA8100
		public PathDrivenActorBehaviorFactory()
		{
			this.RegisterPathDrivenActorBehavior("BP_ExplosiveBarrel_C", (int? ownerPbDataId) => new ExplosiveBarrelPathDrivenBehavior(ownerPbDataId));
		}

		// Token: 0x06030172 RID: 196978 RVA: 0x00BA9F3D File Offset: 0x00BA813D
		public void RegisterPathDrivenActorBehavior(string actorClassName, Func<int?, IPathDrivenActorBehavior> createBehavior)
		{
			this.BehaviorCtorMap[actorClassName] = createBehavior;
		}

		// Token: 0x06030173 RID: 196979 RVA: 0x00BA9F4C File Offset: 0x00BA814C
		[return: Nullable(2)]
		public IPathDrivenActorBehavior CreateBehavior(AActor actor, int? ownerPbDataId)
		{
			string name = actor.GetClass().ToClass().GetName();
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			Func<int?, IPathDrivenActorBehavior> func;
			if (!this.BehaviorCtorMap.TryGetValue(name, out func))
			{
				return null;
			}
			return func(ownerPbDataId);
		}

		// Token: 0x0401B9CF RID: 113103
		private readonly Dictionary<string, Func<int?, IPathDrivenActorBehavior>> BehaviorCtorMap = new Dictionary<string, Func<int?, IPathDrivenActorBehavior>>();
	}
}
