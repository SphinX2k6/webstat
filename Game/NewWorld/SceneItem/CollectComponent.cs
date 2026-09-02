using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047D9 RID: 18393
	public class CollectComponent : EntityComponent
	{
		// Token: 0x0602FB5B RID: 195419 RVA: 0x00B6A9DC File Offset: 0x00B68BDC
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			CollectComponent collectComponent = (CollectComponent)args.GetP1<CreateEntityData>().GetParam<CollectComponent>();
			this.IsDisableOneClickCollection = collectComponent.IsDisableOneClickCollection.GetValueOrDefault();
			return true;
		}

		// Token: 0x0602FB5C RID: 195420 RVA: 0x00B6AA0F File Offset: 0x00B68C0F
		public bool GetIsDisableOneClickCollection()
		{
			return this.IsDisableOneClickCollection;
		}

		// Token: 0x0602FB5D RID: 195421 RVA: 0x00B6AA18 File Offset: 0x00B68C18
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CollectComponent collectComponent = (CollectComponent)componentTemplate;
			if (base.CanResetComponentProperty("IsDisableOneClickCollection"))
			{
				this.IsDisableOneClickCollection = collectComponent.IsDisableOneClickCollection;
			}
			return true;
		}

		// Token: 0x0401B554 RID: 111956
		private bool IsDisableOneClickCollection;
	}
}
