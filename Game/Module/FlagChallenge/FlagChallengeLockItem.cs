using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D78 RID: 23928
	public class FlagChallengeLockItem : UiPanelBase
	{
		// Token: 0x0603C44B RID: 246859 RVA: 0x00F4AD88 File Offset: 0x00F48F88
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
		}

		// Token: 0x0603C44C RID: 246860 RVA: 0x00F4ADE2 File Offset: 0x00F48FE2
		[NullableContext(1)]
		public void SetText(string key)
		{
			base.GetText(1).ShowTextNew(key);
		}
	}
}
