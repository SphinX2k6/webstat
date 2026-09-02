using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200589F RID: 22687
	public class TeleportMarkItemChildIconHandle : MarkItemChildIconHandle
	{
		// Token: 0x06039A77 RID: 236151 RVA: 0x00E9EED5 File Offset: 0x00E9D0D5
		[NullableContext(1)]
		public TeleportMarkItemChildIconHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A78 RID: 236152 RVA: 0x00E9EEE0 File Offset: 0x00E9D0E0
		protected override void OnUpdate()
		{
			TeleportMarkItem teleportMarkItem = this.Context.MarkItem as TeleportMarkItem;
			if (teleportMarkItem.IsDungeonEntrance)
			{
				bool isFogUnlock = teleportMarkItem.IsFogUnlock;
				if (!isFogUnlock)
				{
					this.Context.MarkItemEntity.Resource.ChildIconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkRecommend");
				}
				base.SetVisible(!isFogUnlock);
				return;
			}
			base.OnUpdate();
		}
	}
}
