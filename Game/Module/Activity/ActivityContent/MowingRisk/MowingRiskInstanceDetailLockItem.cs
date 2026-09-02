using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A9 RID: 26281
	public class MowingRiskInstanceDetailLockItem : UiPanelBase
	{
		// Token: 0x06041A16 RID: 268822 RVA: 0x010D408C File Offset: 0x010D228C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
		}

		// Token: 0x06041A17 RID: 268823 RVA: 0x010D40E8 File Offset: 0x010D22E8
		[NullableContext(1)]
		public void RefreshExternalByData(IMowingRiskInstanceDetailLockItemData data)
		{
			UUIText text = base.GetText(1);
			if (!string.IsNullOrEmpty(data.LockDescriptionTextId))
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.LockDescriptionTextId, data.LockDescriptionTextArgs);
				return;
			}
			if (text != null)
			{
				text.SetUIActive(false);
			}
		}

		// Token: 0x0200C6CF RID: 50895
		private static class ELockComponent
		{
			// Token: 0x0403D36B RID: 250731
			public const int LockSprite = 0;

			// Token: 0x0403D36C RID: 250732
			public const int LockDescriptionText = 1;

			// Token: 0x0403D36D RID: 250733
			public const int FunctionButton = 2;
		}
	}
}
