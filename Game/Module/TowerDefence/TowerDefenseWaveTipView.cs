using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EDD RID: 20189
	public class TowerDefenseWaveTipView : GenericPromptFloatTipsBase
	{
		// Token: 0x0603425B RID: 213595 RVA: 0x00D09F20 File Offset: 0x00D08120
		[NullableContext(1)]
		public TowerDefenseWaveTipView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603425C RID: 213596 RVA: 0x00D09F2C File Offset: 0x00D0812C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603425D RID: 213597 RVA: 0x00D09F74 File Offset: 0x00D08174
		protected override void OnStart()
		{
			IPromptParamHub promptParamHub = this.OpenParam as IPromptParamHub;
			TableTextArgNew promptMainTextObj = ConfigBase<GenericPromptConfig>.Instance.GetPromptMainTextObj(promptParamHub.PromptId.Value);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), promptMainTextObj.TextKey ?? "", Array.Empty<object>());
		}

		// Token: 0x0200AE91 RID: 44689
		private class EComponent
		{
			// Token: 0x04036334 RID: 222004
			public const int WaveText = 0;
		}
	}
}
