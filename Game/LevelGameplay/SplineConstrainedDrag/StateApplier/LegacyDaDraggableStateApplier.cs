using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.StateApplier
{
	// Token: 0x02006ADE RID: 27358
	[NullableContext(1)]
	[Nullable(0)]
	public class LegacyDaDraggableStateApplier : IDraggableStateApplier
	{
		// Token: 0x06043A56 RID: 277078 RVA: 0x0117371A File Offset: 0x0117191A
		[NullableContext(2)]
		public LegacyDaDraggableStateApplier(string daPath)
		{
			this.DaPath = daPath;
		}

		// Token: 0x06043A57 RID: 277079 RVA: 0x01173729 File Offset: 0x01171929
		public void Initialize(AActor actor)
		{
		}

		// Token: 0x06043A58 RID: 277080 RVA: 0x0117372B File Offset: 0x0117192B
		public void ApplyState(AActor actor, EDraggableState state)
		{
			if (state == EDraggableState.Selected)
			{
				this.AddSelectionMaterial(actor);
				return;
			}
			this.ClearSelectionMaterial();
		}

		// Token: 0x06043A59 RID: 277081 RVA: 0x0117373F File Offset: 0x0117193F
		public void Dispose(AActor actor)
		{
			this.ClearSelectionMaterial();
		}

		// Token: 0x06043A5A RID: 277082 RVA: 0x01173748 File Offset: 0x01171948
		private void AddSelectionMaterial(AActor actor)
		{
			this.ClearSelectionMaterial();
			if (actor == null || !actor.IsValid())
			{
				return;
			}
			if (this.DaPath == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[LegacyDaDraggableStateApplier] AddSelectionMaterial: DraggableActorEffectDa is empty";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actor", actor);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ISelectionMatCacheEntry selectionMatCacheEntry = ModelBase<SplineConstrainedDragModel>.Instance.GetSelectionMatCacheEntry(this.DaPath);
			ItemMaterialControllerActorData itemMaterialControllerActorData = (selectionMatCacheEntry != null) ? selectionMatCacheEntry.Asset : null;
			if (itemMaterialControllerActorData == null || !itemMaterialControllerActorData.IsValid())
			{
				itemMaterialControllerActorData = Singleton<ResourceSystem>.Instance.Load<ItemMaterialControllerActorData>(this.DaPath, "js_undefined");
				if (itemMaterialControllerActorData == null || !itemMaterialControllerActorData.IsValid())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.LevelPlay;
					ELogAuthor author2 = ELogAuthor.XDW;
					string message2 = "[LegacyDaDraggableStateApplier] AddSelectionMaterial sync load failed";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("path", this.DaPath);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				if (selectionMatCacheEntry != null)
				{
					selectionMatCacheEntry.Asset = itemMaterialControllerActorData;
				}
			}
			this.CurrentHandle = new int?(Singleton<ItemMaterialManager>.Instance.AddMaterialData(actor, itemMaterialControllerActorData));
		}

		// Token: 0x06043A5B RID: 277083 RVA: 0x01173844 File Offset: 0x01171A44
		private void ClearSelectionMaterial()
		{
			int? currentHandle = this.CurrentHandle;
			if (currentHandle == null)
			{
				return;
			}
			Singleton<ItemMaterialManager>.Instance.DisableActorData(this.CurrentHandle.Value);
			this.CurrentHandle = null;
		}

		// Token: 0x04025CAB RID: 154795
		private int? CurrentHandle;

		// Token: 0x04025CAC RID: 154796
		[Nullable(2)]
		private readonly string DaPath;
	}
}
