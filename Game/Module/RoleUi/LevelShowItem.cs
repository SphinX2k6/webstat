using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005056 RID: 20566
	public class LevelShowItem : UiPanelBase
	{
		// Token: 0x06034F33 RID: 216883 RVA: 0x00D472E0 File Offset: 0x00D454E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06034F34 RID: 216884 RVA: 0x00D4733A File Offset: 0x00D4553A
		[NullableContext(2)]
		public void Refresh(int lvPreUpgrade, int lvUpgrade, string formatId, bool? isMax)
		{
			base.GetArtText(0).SetText(lvPreUpgrade.ToString());
			base.GetArtText(1).SetText(lvUpgrade.ToString());
			base.GetItem(2).SetUIActive(isMax.GetValueOrDefault());
		}

		// Token: 0x0200AFF8 RID: 45048
		private enum ELevelPanelNode
		{
			// Token: 0x0403696B RID: 223595
			PreUpgradeLevel,
			// Token: 0x0403696C RID: 223596
			UpgradeLevel,
			// Token: 0x0403696D RID: 223597
			SpriteMax
		}
	}
}
