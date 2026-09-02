using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using UnrealEngine;

// Token: 0x02001F3B RID: 7995
[NullableContext(2)]
public interface IHonamiStoryMainButtonConfig
{
	// Token: 0x17001237 RID: 4663
	// (get) Token: 0x0600EF05 RID: 61189
	// (set) Token: 0x0600EF06 RID: 61190
	EHonamiStoryMainButtonFunctionType Type { get; set; }

	// Token: 0x17001238 RID: 4664
	// (get) Token: 0x0600EF07 RID: 61191
	// (set) Token: 0x0600EF08 RID: 61192
	EHonamiStoryMainComponent ComponentId { get; set; }

	// Token: 0x17001239 RID: 4665
	// (get) Token: 0x0600EF09 RID: 61193
	// (set) Token: 0x0600EF0A RID: 61194
	EFunctionType? FunctionId { get; set; }

	// Token: 0x1700123A RID: 4666
	// (get) Token: 0x0600EF0B RID: 61195
	// (set) Token: 0x0600EF0C RID: 61196
	Func<bool> ShowRedDot { get; set; }

	// Token: 0x1700123B RID: 4667
	// (get) Token: 0x0600EF0D RID: 61197
	// (set) Token: 0x0600EF0E RID: 61198
	Action<UUIText> SetTextCallback { get; set; }

	// Token: 0x1700123C RID: 4668
	// (get) Token: 0x0600EF0F RID: 61199
	// (set) Token: 0x0600EF10 RID: 61200
	Action OnClickCallback { get; set; }

	// Token: 0x1700123D RID: 4669
	// (get) Token: 0x0600EF11 RID: 61201
	// (set) Token: 0x0600EF12 RID: 61202
	Func<bool> ShowCallback { get; set; }

	// Token: 0x1700123E RID: 4670
	// (get) Token: 0x0600EF13 RID: 61203
	// (set) Token: 0x0600EF14 RID: 61204
	string SpecialSequenceName { get; set; }

	// Token: 0x1700123F RID: 4671
	// (get) Token: 0x0600EF15 RID: 61205
	// (set) Token: 0x0600EF16 RID: 61206
	string SpecialParamName { get; set; }
}
