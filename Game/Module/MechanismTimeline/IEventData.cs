using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057DD RID: 22493
	[NullableContext(1)]
	public interface IEventData
	{
		// Token: 0x170091B8 RID: 37304
		// (get) Token: 0x06039273 RID: 234099
		// (set) Token: 0x06039274 RID: 234100
		string EventName { get; set; }

		// Token: 0x170091B9 RID: 37305
		// (get) Token: 0x06039275 RID: 234101
		// (set) Token: 0x06039276 RID: 234102
		string EventType { get; set; }

		// Token: 0x170091BA RID: 37306
		// (get) Token: 0x06039277 RID: 234103
		// (set) Token: 0x06039278 RID: 234104
		bool IsAnimNotifyState { get; set; }

		// Token: 0x170091BB RID: 37307
		// (get) Token: 0x06039279 RID: 234105
		// (set) Token: 0x0603927A RID: 234106
		int StartFrame { get; set; }

		// Token: 0x170091BC RID: 37308
		// (get) Token: 0x0603927B RID: 234107
		// (set) Token: 0x0603927C RID: 234108
		int EndFrame { get; set; }

		// Token: 0x170091BD RID: 37309
		// (get) Token: 0x0603927D RID: 234109
		// (set) Token: 0x0603927E RID: 234110
		int RowIndex { get; set; }
	}
}
