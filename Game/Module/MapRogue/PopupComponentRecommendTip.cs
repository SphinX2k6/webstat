using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005994 RID: 22932
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupComponentRecommendTip : UiPanelBase
	{
		// Token: 0x0603A10E RID: 237838 RVA: 0x00EB22C2 File Offset: 0x00EB04C2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x0603A10F RID: 237839 RVA: 0x00EB22FC File Offset: 0x00EB04FC
		public void SetTextChangeColor(bool bUseChange)
		{
			UUIItem sprite = base.GetSprite(1);
			FColor? fcolor = new FColor?(base.GetSprite(1).changeColor);
			sprite.SetChangeColor(bUseChange, fcolor);
		}

		// Token: 0x0603A110 RID: 237840 RVA: 0x00EB232A File Offset: 0x00EB052A
		public void SetDescriptionByTextId(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
		}

		// Token: 0x0603A111 RID: 237841 RVA: 0x00EB233F File Offset: 0x00EB053F
		public void SetDescriptionByText(string text)
		{
			base.GetText(0).SetText(text, true);
		}
	}
}
