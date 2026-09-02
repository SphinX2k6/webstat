using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006324 RID: 25380
	public class SpringManorBrochureDetailPointItem : GridProxyAbstract<int>
	{
		// Token: 0x0603FC5A RID: 261210 RVA: 0x01059C3A File Offset: 0x01057E3A
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x0603FC5B RID: 261211 RVA: 0x01059C73 File Offset: 0x01057E73
		public override void Refresh(int curIndex, bool isSelected, int gridIndex)
		{
			this.SetSelectedState(isSelected);
		}

		// Token: 0x0603FC5C RID: 261212 RVA: 0x01059C7C File Offset: 0x01057E7C
		private void SetSelectedState(bool isSelected)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(isSelected);
		}

		// Token: 0x0603FC5D RID: 261213 RVA: 0x01059C90 File Offset: 0x01057E90
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelectedState(true);
		}

		// Token: 0x0603FC5E RID: 261214 RVA: 0x01059C99 File Offset: 0x01057E99
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelectedState(false);
		}
	}
}
