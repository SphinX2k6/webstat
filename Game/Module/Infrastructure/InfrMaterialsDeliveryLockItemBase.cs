using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C64 RID: 23652
	public class InfrMaterialsDeliveryLockItemBase : UiPanelBase
	{
		// Token: 0x0603BC34 RID: 244788 RVA: 0x00F2567C File Offset: 0x00F2387C
		[NullableContext(1)]
		public void Refresh(InfrastructureDefine.IInfrMaterialsDeliveryLockData data)
		{
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.LockDescriptionTextId, data.LockDescriptionTextArgs ?? Array.Empty<string>());
		}

		// Token: 0x0200BCFB RID: 48379
		private class EChildType
		{
			// Token: 0x0403A3BE RID: 238526
			public const int LockSprite = 0;

			// Token: 0x0403A3BF RID: 238527
			public const int LockDescriptionText = 1;

			// Token: 0x0403A3C0 RID: 238528
			public const int FunctionButton = 2;
		}
	}
}
