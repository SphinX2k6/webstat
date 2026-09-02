using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005986 RID: 22918
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupComponentDescription : UiPanelBase
	{
		// Token: 0x0603A0E5 RID: 237797 RVA: 0x00EB1C8D File Offset: 0x00EAFE8D
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0603A0E6 RID: 237798 RVA: 0x00EB1CB0 File Offset: 0x00EAFEB0
		public void SetDescriptionByTextId(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x0603A0E7 RID: 237799 RVA: 0x00EB1CC5 File Offset: 0x00EAFEC5
		public void SetDescriptionByText(string text)
		{
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x0603A0E8 RID: 237800 RVA: 0x00EB1CD5 File Offset: 0x00EAFED5
		public void SetDescriptionVisible(bool bVisible)
		{
			base.GetText(1).SetUIActive(bVisible);
		}
	}
}
