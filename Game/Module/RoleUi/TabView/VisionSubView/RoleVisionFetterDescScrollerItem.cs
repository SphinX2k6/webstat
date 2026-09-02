using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x0200506A RID: 20586
	internal class RoleVisionFetterDescScrollerItem : UiPanelBase
	{
		// Token: 0x06035078 RID: 217208 RVA: 0x00D4D0D8 File Offset: 0x00D4B2D8
		[NullableContext(1)]
		public RoleVisionFetterDescScrollerItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x06035079 RID: 217209 RVA: 0x00D4D0ED File Offset: 0x00D4B2ED
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0603507A RID: 217210 RVA: 0x00D4D126 File Offset: 0x00D4B326
		public void Update(PhantomFetter data)
		{
			base.GetText(0).ShowTextNew(data.Name);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.EffectDescription, data.EffectDescriptionParam());
		}
	}
}
