using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200600B RID: 24587
	public class FormationConcertoItem : UiPanelBase
	{
		// Token: 0x0603DEE6 RID: 253670 RVA: 0x00FCC550 File Offset: 0x00FCA750
		[NullableContext(1)]
		public FormationConcertoItem(AActor rootActor)
		{
			base.CreateThenShowByActor(rootActor, null);
		}

		// Token: 0x0603DEE7 RID: 253671 RVA: 0x00FCC56C File Offset: 0x00FCA76C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DEE8 RID: 253672 RVA: 0x00FCC5D8 File Offset: 0x00FCA7D8
		public void RefreshConcertoInfoView(in ElementInfo info, int elementId, FColor color)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetColor(color);
			}
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetColor(color);
			}
			string lastSetIconPath = this.LastSetIconPath;
			ElementInfo elementInfo = info;
			if (lastSetIconPath != elementInfo.Icon3)
			{
				elementInfo = info;
				this.LastSetIconPath = elementInfo.Icon3;
				elementInfo = info;
				base.SetElementIcon(elementInfo.Icon3, texture, elementId, null);
			}
		}

		// Token: 0x0603DEE9 RID: 253673 RVA: 0x00FCC658 File Offset: 0x00FCA858
		public void RefreshConcertoProgress(float progress)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(progress);
		}

		// Token: 0x04022BCD RID: 142285
		[Nullable(1)]
		private string LastSetIconPath = string.Empty;

		// Token: 0x0200C0A3 RID: 49315
		private enum EChildType
		{
			// Token: 0x0403B4F1 RID: 242929
			ProgressSprite,
			// Token: 0x0403B4F2 RID: 242930
			ContentTexture
		}
	}
}
