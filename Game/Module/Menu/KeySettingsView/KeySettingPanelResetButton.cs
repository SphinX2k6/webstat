using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C6 RID: 22470
	public class KeySettingPanelResetButton : UiPanelBase
	{
		// Token: 0x060391CD RID: 233933 RVA: 0x00E79648 File Offset: 0x00E77848
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x060391CE RID: 233934 RVA: 0x00E796A2 File Offset: 0x00E778A2
		[NullableContext(1)]
		public void SetConfirmText(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
		}

		// Token: 0x0200B846 RID: 47174
		public class EComponent
		{
			// Token: 0x04038FEF RID: 233455
			public const int Button = 0;

			// Token: 0x04038FF0 RID: 233456
			public const int TxtConfirm = 1;

			// Token: 0x04038FF1 RID: 233457
			public const int RedDot = 2;
		}
	}
}
