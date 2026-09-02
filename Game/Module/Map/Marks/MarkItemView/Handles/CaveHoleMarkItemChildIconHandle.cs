using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200588B RID: 22667
	public class CaveHoleMarkItemChildIconHandle : MarkItemChildIconHandle
	{
		// Token: 0x060399E6 RID: 236006 RVA: 0x00E9D9B4 File Offset: 0x00E9BBB4
		[NullableContext(1)]
		public CaveHoleMarkItemChildIconHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x060399E7 RID: 236007 RVA: 0x00E9D9C0 File Offset: 0x00E9BBC0
		protected override void OnUpdate()
		{
			MarkItem markItem = this.Context.MarkItem;
			if (markItem.IsMultiMap())
			{
				bool isSelectThisFloor = markItem.IsSelectThisFloor;
				bool flag = markItem.LocateInGround() && isSelectThisFloor;
				base.SetVisible(!flag);
				this.Context.MarkItemEntity.Resource.ChildIconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(isSelectThisFloor ? "SP_MarkMultiMapSelect" : "SP_MarkMultiMap");
				return;
			}
			base.SetVisible(false);
		}
	}
}
