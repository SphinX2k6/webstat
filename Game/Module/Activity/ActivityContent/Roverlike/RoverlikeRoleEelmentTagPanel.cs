using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006442 RID: 25666
	public class RoverlikeRoleEelmentTagPanel : UiPanelBase
	{
		// Token: 0x060406D9 RID: 263897 RVA: 0x010845AC File Offset: 0x010827AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060406DA RID: 263898 RVA: 0x01084638 File Offset: 0x01082838
		[NullableContext(2)]
		public void Refresh(string iconPath, string textId)
		{
			UUISprite sprite = base.GetSprite(1);
			base.TrySetSpriteByPath(iconPath, sprite, false, null, null);
			UUIText text = base.GetText(2);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(text, textId, Array.Empty<object>());
		}

		// Token: 0x060406DB RID: 263899 RVA: 0x01084679 File Offset: 0x01082879
		public void SetTagBgColor(FColor color)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetColor(color);
		}

		// Token: 0x0200C4B8 RID: 50360
		private class ETagComponents
		{
			// Token: 0x0403C8C5 RID: 248005
			public const int SprTagBg = 0;

			// Token: 0x0403C8C6 RID: 248006
			public const int SprTypeIcon = 1;

			// Token: 0x0403C8C7 RID: 248007
			public const int TxtType = 2;
		}
	}
}
