using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007017 RID: 28695
	[NullableContext(1)]
	public interface ITouchUiEditView
	{
		// Token: 0x06045795 RID: 284565
		UUIItem GetAttachRoot();

		// Token: 0x06045796 RID: 284566
		[NullableContext(2)]
		UUISliderComponent GetScaleSlider();
	}
}
