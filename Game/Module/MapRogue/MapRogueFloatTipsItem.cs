using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200593D RID: 22845
	public class MapRogueFloatTipsItem : UiPanelBase
	{
		// Token: 0x06039F3A RID: 237370 RVA: 0x00EAABBD File Offset: 0x00EA8DBD
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06039F3B RID: 237371 RVA: 0x00EAABF6 File Offset: 0x00EA8DF6
		protected override void OnStart()
		{
			base.GetItem(1).SetAnchorOffsetY(-80f);
		}

		// Token: 0x06039F3C RID: 237372 RVA: 0x00EAAC09 File Offset: 0x00EA8E09
		[NullableContext(1)]
		public void SetText(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
		}

		// Token: 0x04020D5B RID: 134491
		private const int TIPS_OFFSET_Y = -80;
	}
}
