using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.SceneItem.Jigsaw;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004806 RID: 18438
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemPickInteractComponent : EntityComponent
	{
		// Token: 0x0602FF51 RID: 196433 RVA: 0x00B972D8 File Offset: 0x00B954D8
		protected override bool OnInitData(IEntityArgs args = null)
		{
			PickInteractComponent pickInteractComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemPickInteractComponent>() as PickInteractComponent;
			if (pickInteractComponent != null)
			{
				IChessmanPickInteraction pickInteractType = pickInteractComponent.PickInteractType;
				if (pickInteractType != null)
				{
					this.SelectEffectPathName = pickInteractType.AvailablePosEffect;
				}
			}
			return true;
		}

		// Token: 0x0602FF52 RID: 196434 RVA: 0x00B97310 File Offset: 0x00B95510
		protected override bool OnStart()
		{
			this.ItemComponent = base.Entity.GetComponent<SceneItemJigsawItemComponent>();
			return true;
		}

		// Token: 0x17008222 RID: 33314
		// (get) Token: 0x0602FF53 RID: 196435 RVA: 0x00B97324 File Offset: 0x00B95524
		public JigsawIndex Index
		{
			get
			{
				SceneItemJigsawItemComponent itemComponent = this.ItemComponent;
				if (itemComponent == null)
				{
					return null;
				}
				return itemComponent.PutDownIndex;
			}
		}

		// Token: 0x17008223 RID: 33315
		// (get) Token: 0x0602FF54 RID: 196436 RVA: 0x00B97337 File Offset: 0x00B95537
		public SceneItemJigsawItemComponent Item
		{
			get
			{
				return this.ItemComponent;
			}
		}

		// Token: 0x0602FF55 RID: 196437 RVA: 0x00B97340 File Offset: 0x00B95540
		public void OnSelect()
		{
			if (this.ItemComponent != null)
			{
				SceneItemJigsawBaseComponent putDownBase = this.ItemComponent.PutDownBase;
				List<Vector> list = (putDownBase != null) ? putDownBase.OnItemTicTacToeSelect(this) : null;
				if (list == null)
				{
					return;
				}
				if (!string.IsNullOrEmpty(this.SelectEffectPathName))
				{
					foreach (Vector vector in list)
					{
						EffectSystem instance = Singleton<EffectSystem>.Instance;
						UObject world = GlobalData.World;
						FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
						int num = instance.SpawnEffect(world, ftransformDouble, this.SelectEffectPathName, "PickInteractComponent.OnSelect", new EffectContext(new int?(base.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
						if (Singleton<EffectSystem>.Instance.IsValid(num))
						{
							OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
							FVectorDouble fvectorDouble = vector.ToUeVector(false);
							effectActor.D_K2_SetActorLocation(fvectorDouble, false, ref WorldGlobal.SweepHitResult, true);
							this.SelectNieghtborEffects.Add(num);
						}
					}
				}
			}
		}

		// Token: 0x0602FF56 RID: 196438 RVA: 0x00B9744C File Offset: 0x00B9564C
		public void OnSelectEnd()
		{
			foreach (int handle in this.SelectNieghtborEffects)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(handle, "PickInteractComponent.OnSelectEnd", false, null);
			}
			this.SelectNieghtborEffects.Clear();
		}

		// Token: 0x0602FF57 RID: 196439 RVA: 0x00B974C0 File Offset: 0x00B956C0
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemPickInteractComponent sceneItemPickInteractComponent = (SceneItemPickInteractComponent)componentTemplate;
			if (base.CanResetComponentProperty("ItemComponent"))
			{
				if (sceneItemPickInteractComponent.ItemComponent == null)
				{
					this.ItemComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemJigsawItemComponent>(this.ItemComponent), "ItemComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SelectNieghtborEffects") && sceneItemPickInteractComponent.SelectNieghtborEffects != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<int>>(this.SelectNieghtborEffects), "SelectNieghtborEffects"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("SelectEffectPathName"))
			{
				this.SelectEffectPathName = sceneItemPickInteractComponent.SelectEffectPathName;
			}
			return true;
		}

		// Token: 0x0401B860 RID: 112736
		private SceneItemJigsawItemComponent ItemComponent;

		// Token: 0x0401B861 RID: 112737
		[Nullable(1)]
		private readonly List<int> SelectNieghtborEffects = new List<int>();

		// Token: 0x0401B862 RID: 112738
		private string SelectEffectPathName;
	}
}
