using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x020058A0 RID: 22688
	public class TemporaryTeleportMarkItemChildIconHandle : MarkItemChildIconHandle
	{
		// Token: 0x06039A79 RID: 236153 RVA: 0x00E9EF45 File Offset: 0x00E9D145
		[NullableContext(1)]
		public TemporaryTeleportMarkItemChildIconHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A7A RID: 236154 RVA: 0x00E9EF50 File Offset: 0x00E9D150
		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (!this.Context.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.ChildIcon, false))
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkTime");
				this.Context.MarkItemEntity.Resource.ChildIconPath = resourcePath;
				base.SetVisible(true);
			}
		}
	}
}
