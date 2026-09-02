using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Common.Component;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004909 RID: 18697
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterOutlookComponent : BaseOutlookComponent
	{
		// Token: 0x06030DD7 RID: 200151 RVA: 0x00C1B028 File Offset: 0x00C19228
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			if (this.ActorComp != null)
			{
				this.SkelMeshComp = this.ActorComp.Actor.Mesh;
				this.CharRenderComp = this.ActorComp.Actor.CharRenderingComponent;
			}
			return true;
		}

		// Token: 0x06030DD8 RID: 200152 RVA: 0x00C1B07B File Offset: 0x00C1927B
		protected override void OnActivate()
		{
			base.OnActivate();
			this.RefreshOrnaments();
		}

		// Token: 0x06030DD9 RID: 200153 RVA: 0x00C1B08C File Offset: 0x00C1928C
		public void RefreshOrnaments()
		{
			if (this.ActorComp == null)
			{
				return;
			}
			int skinId = this.ActorComp.CreatureData.GetSkinId();
			List<int> decorationIds = RoleUtils.MergeDefaultOrnaments(this.ActorComp.CreatureData.GetOrnamentIds(), skinId);
			base.EquipDecoration(decorationIds);
		}

		// Token: 0x06030DDA RID: 200154 RVA: 0x00C1B0D4 File Offset: 0x00C192D4
		public void OnEntityDressOrnamentChangeNotify(EntityDressOrnamentChangeNotify notify)
		{
			if (this.ActorComp == null)
			{
				return;
			}
			List<int> list = new List<int>();
			OrnamentComponentPb ornamentComponentPb = notify.OrnamentComponentPb;
			if (((ornamentComponentPb != null) ? ornamentComponentPb.OrnamentIds : null) != null)
			{
				RepeatedField<int> ornamentIds = notify.OrnamentComponentPb.OrnamentIds;
				list = new List<int>(ornamentIds.Count);
				for (int i = 0; i < ornamentIds.Count; i++)
				{
					list.Add(ornamentIds[i]);
				}
			}
			this.ActorComp.CreatureData.SetOrnamentIds(list);
			int skinId = this.ActorComp.CreatureData.GetSkinId();
			List<int> decorationIds = RoleUtils.MergeDefaultOrnaments(list, skinId);
			base.EquipDecoration(decorationIds);
		}

		// Token: 0x06030DDB RID: 200155 RVA: 0x00C1B170 File Offset: 0x00C19370
		protected override void AddRenderMesh(DecorationItem item)
		{
			CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
			if (component != null && item.MeshComp != null)
			{
				component.Actor.CharRenderingComponent.AddComponent(item.MeshComp.GetName(), item.MeshComp);
			}
		}

		// Token: 0x06030DDC RID: 200156 RVA: 0x00C1B1B8 File Offset: 0x00C193B8
		protected override int? GetDecorationModelId(int decorationId)
		{
			Ornament? config = ConfigOrnamentById.GetConfig(decorationId, true);
			if (config == null)
			{
				return null;
			}
			if (config.Value.ModelIdLength <= 0)
			{
				return null;
			}
			if (this.IsFemaleMainRole() && config.Value.ModelIdLength > 1)
			{
				return new int?(config.Value.ModelId(1));
			}
			if (config.Value.ModelIdLength > 0)
			{
				return new int?(config.Value.ModelId(0));
			}
			return null;
		}

		// Token: 0x06030DDD RID: 200157 RVA: 0x00C1B260 File Offset: 0x00C19460
		private bool IsFemaleMainRole()
		{
			if (this.ActorComp == null)
			{
				return false;
			}
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(this.ActorComp.CreatureData.GetPbDataId());
			return ModelBase<RoleModel>.Instance.IsMainRole(baseRoleId) && ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female;
		}

		// Token: 0x06030DDE RID: 200158 RVA: 0x00C1B2B0 File Offset: 0x00C194B0
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterOutlookComponent characterOutlookComponent = (CharacterOutlookComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterOutlookComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CharRenderComp"))
			{
				if (characterOutlookComponent.CharRenderComp == null)
				{
					this.CharRenderComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharRenderingComponent>(this.CharRenderComp), "CharRenderComp"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C168 RID: 115048
		[Nullable(2)]
		protected CharacterActorComponent ActorComp;

		// Token: 0x0401C169 RID: 115049
		[Nullable(2)]
		protected CharRenderingComponent CharRenderComp;
	}
}
