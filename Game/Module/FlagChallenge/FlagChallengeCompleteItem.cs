using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D7A RID: 23930
	public class FlagChallengeCompleteItem : UiPanelBase
	{
		// Token: 0x0603C44E RID: 246862 RVA: 0x00F4ADF9 File Offset: 0x00F48FF9
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0603C44F RID: 246863 RVA: 0x00F4AE32 File Offset: 0x00F49032
		[NullableContext(1)]
		public void SetText(string key)
		{
			base.GetText(1).ShowTextNew(key);
		}
	}
}
