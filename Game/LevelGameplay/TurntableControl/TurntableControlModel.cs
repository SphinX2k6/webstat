using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

namespace CSharpScript.Game.LevelGamePlay.TurntableControl
{
	// Token: 0x02006A6A RID: 27242
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class TurntableControlModel : ModelBase<TurntableControlModel>
	{
		// Token: 0x1700A255 RID: 41557
		// (get) Token: 0x0604365C RID: 276060 RVA: 0x0115CB07 File Offset: 0x0115AD07
		public Entity CurControllerEntity
		{
			get
			{
				return this.CurControllerEntityInternal;
			}
		}

		// Token: 0x1700A256 RID: 41558
		// (get) Token: 0x0604365D RID: 276061 RVA: 0x0115CB0F File Offset: 0x0115AD0F
		public SceneItemTurntableControllerComponent CurControllerEntityComp
		{
			get
			{
				return this.CurControllerEntityCompInternal;
			}
		}

		// Token: 0x0604365E RID: 276062 RVA: 0x0115CB18 File Offset: 0x0115AD18
		public void SetCurControllerEntity(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(entityId);
			SceneItemTurntableControllerComponent sceneItemTurntableControllerComponent = (entity != null) ? entity.GetComponent<SceneItemTurntableControllerComponent>() : null;
			if (sceneItemTurntableControllerComponent == null)
			{
				this.ClearCurControllerEntity();
			}
			this.CurControllerEntityInternal = entity;
			this.CurControllerEntityCompInternal = sceneItemTurntableControllerComponent;
		}

		// Token: 0x0604365F RID: 276063 RVA: 0x0115CB55 File Offset: 0x0115AD55
		public void ClearCurControllerEntity()
		{
			this.CurControllerEntityInternal = null;
			this.CurControllerEntityCompInternal = null;
		}

		// Token: 0x06043660 RID: 276064 RVA: 0x0115CB65 File Offset: 0x0115AD65
		protected override bool OnClear()
		{
			this.ClearCurControllerEntity();
			return true;
		}

		// Token: 0x04025A07 RID: 154119
		private Entity CurControllerEntityInternal;

		// Token: 0x04025A08 RID: 154120
		private SceneItemTurntableControllerComponent CurControllerEntityCompInternal;
	}
}
