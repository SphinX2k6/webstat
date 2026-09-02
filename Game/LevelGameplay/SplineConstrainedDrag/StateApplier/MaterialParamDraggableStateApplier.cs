using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.StateApplier
{
	// Token: 0x02006ADF RID: 27359
	[NullableContext(1)]
	[Nullable(0)]
	public class MaterialParamDraggableStateApplier : IDraggableStateApplier
	{
		// Token: 0x06043A5C RID: 277084 RVA: 0x01173884 File Offset: 0x01171A84
		public void Initialize(AActor actor)
		{
			this.CollectStaticMeshComponents(actor);
			this.WriteStateParams(0, 0, 0);
		}

		// Token: 0x06043A5D RID: 277085 RVA: 0x01173898 File Offset: 0x01171A98
		public void ApplyState(AActor actor, EDraggableState state)
		{
			if (this.CachedStaticMeshComponents.Count == 0)
			{
				this.CollectStaticMeshComponents(actor);
			}
			switch (state)
			{
			case EDraggableState.Selectable:
				this.WriteStateParams(1, 0, 0);
				return;
			case EDraggableState.Hover:
				this.WriteStateParams(0, 1, 0);
				return;
			case EDraggableState.Selected:
				this.WriteStateParams(0, 0, 1);
				return;
			}
			this.WriteStateParams(0, 0, 0);
		}

		// Token: 0x06043A5E RID: 277086 RVA: 0x011738F8 File Offset: 0x01171AF8
		public void Dispose(AActor actor)
		{
			if (this.CachedStaticMeshComponents.Count == 0)
			{
				this.CollectStaticMeshComponents(actor);
			}
			this.WriteStateParams(0, 0, 0);
			this.CachedStaticMeshComponents = new List<UStaticMeshComponent>();
		}

		// Token: 0x06043A5F RID: 277087 RVA: 0x01173924 File Offset: 0x01171B24
		private void CollectStaticMeshComponents(AActor actor)
		{
			this.CachedStaticMeshComponents = new List<UStaticMeshComponent>();
			if (actor == null || !actor.IsValid())
			{
				return;
			}
			TArray<UActorComponent> tarray = actor.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
			if (tarray == null || tarray.Num() == 0)
			{
				return;
			}
			for (int i = 0; i < tarray.Num(); i++)
			{
				UStaticMeshComponent ustaticMeshComponent = tarray.Get(i) as UStaticMeshComponent;
				if (ustaticMeshComponent != null && ustaticMeshComponent.IsValid())
				{
					this.CachedStaticMeshComponents.Add(ustaticMeshComponent);
				}
			}
			if (this.CachedStaticMeshComponents.Count == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[MaterialParamDraggableStateApplier] CollectStaticMeshComponents: 可拖拽Actor无StaticMeshComponent来材质表现";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actor", actor);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06043A60 RID: 277088 RVA: 0x011739D4 File Offset: 0x01171BD4
		private void WriteStateParams(int state1, int state2, int state3)
		{
			foreach (UStaticMeshComponent ustaticMeshComponent in this.CachedStaticMeshComponents)
			{
				if (ustaticMeshComponent != null && ustaticMeshComponent.IsValid())
				{
					ustaticMeshComponent.SetScalarParameterValueOnMaterials(FNameUtil.GetDynamicFName("EnableState1").Value, (float)state1);
					ustaticMeshComponent.SetScalarParameterValueOnMaterials(FNameUtil.GetDynamicFName("EnableState2").Value, (float)state2);
					ustaticMeshComponent.SetScalarParameterValueOnMaterials(FNameUtil.GetDynamicFName("EnableState3").Value, (float)state3);
				}
			}
		}

		// Token: 0x04025CAD RID: 154797
		private List<UStaticMeshComponent> CachedStaticMeshComponents = new List<UStaticMeshComponent>();
	}
}
