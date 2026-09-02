using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x02005066 RID: 20582
	public class RoleFetterVisionDesc : UiPanelBase
	{
		// Token: 0x0603506E RID: 217198 RVA: 0x00D4CF7E File Offset: 0x00D4B17E
		[NullableContext(1)]
		public RoleFetterVisionDesc(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603506F RID: 217199 RVA: 0x00D4CF93 File Offset: 0x00D4B193
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06035070 RID: 217200 RVA: 0x00D4CFCC File Offset: 0x00D4B1CC
		[NullableContext(1)]
		public void Refresh(IReadOnlyList<PhantomFetter> data)
		{
			this.RoleVisionDescScroller.SetActive(data.Count > 0);
			this.RoleVisionDescScroller.Update(data);
		}

		// Token: 0x06035071 RID: 217201 RVA: 0x00D4CFEE File Offset: 0x00D4B1EE
		protected override void OnBeforeDestroy()
		{
			this.RoleVisionDescScroller.Destroy(null);
		}

		// Token: 0x0401E897 RID: 125079
		[Nullable(2)]
		private readonly RoleVisionDescScroller RoleVisionDescScroller;

		// Token: 0x0200B01D RID: 45085
		private enum EComponent
		{
			// Token: 0x04036A1D RID: 223773
			Title,
			// Token: 0x04036A1E RID: 223774
			DescScrollerItem
		}
	}
}
