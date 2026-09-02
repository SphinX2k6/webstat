using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005863 RID: 22627
	[NullableContext(1)]
	[Nullable(0)]
	public class CaveHoleMarkItemView : ConfigMarkItemView
	{
		// Token: 0x060398D3 RID: 235731 RVA: 0x00E9A493 File Offset: 0x00E98693
		public CaveHoleMarkItemView(CaveHoleMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060398D4 RID: 235732 RVA: 0x00E9A49C File Offset: 0x00E9869C
		public override void UpdateIcon()
		{
			MapMark? mapMark;
			string iconPath = (base.MarkConfig != null) ? mapMark.GetValueOrDefault().UnlockMarkPic : null;
			this.OnIconPathChanged(iconPath);
		}

		// Token: 0x060398D5 RID: 235733 RVA: 0x00E9A4D3 File Offset: 0x00E986D3
		protected override void OnViewRefresh()
		{
			this.UpdateIcon();
		}

		// Token: 0x060398D6 RID: 235734 RVA: 0x00E9A4DC File Offset: 0x00E986DC
		public override void OnIconPathChanged(string iconPath)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			base.LoadIcon(sprite, iconPath);
			base.MarkItemChildIconHandle.Update();
			base.MarkItemChildIconHandle.ApplyModified();
		}

		// Token: 0x060398D7 RID: 235735 RVA: 0x00E9A519 File Offset: 0x00E98719
		[PreserveBaseOverrides]
		protected new virtual MarkItemChildIconHandle CreateChildIconHandle(IMarkItemComponentContext markComponentContext)
		{
			return new CaveHoleMarkItemChildIconHandle(markComponentContext);
		}
	}
}
