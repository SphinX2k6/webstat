using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006218 RID: 25112
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerResultViewButtonData : IWheelTowerResultViewButtonData
	{
		// Token: 0x17009BD8 RID: 39896
		// (get) Token: 0x0603F5B2 RID: 259506 RVA: 0x0103EB6C File Offset: 0x0103CD6C
		// (set) Token: 0x0603F5B3 RID: 259507 RVA: 0x0103EB74 File Offset: 0x0103CD74
		public string Name { get; set; } = string.Empty;

		// Token: 0x17009BD9 RID: 39897
		// (get) Token: 0x0603F5B4 RID: 259508 RVA: 0x0103EB7D File Offset: 0x0103CD7D
		// (set) Token: 0x0603F5B5 RID: 259509 RVA: 0x0103EB85 File Offset: 0x0103CD85
		public Action OnClick { get; set; } = delegate()
		{
		};

		// Token: 0x17009BDA RID: 39898
		// (get) Token: 0x0603F5B6 RID: 259510 RVA: 0x0103EB8E File Offset: 0x0103CD8E
		// (set) Token: 0x0603F5B7 RID: 259511 RVA: 0x0103EB96 File Offset: 0x0103CD96
		public EConfirmBoxConfigId? ConfirmBoxId { get; set; }
	}
}
