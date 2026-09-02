using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x0200700E RID: 28686
	public class CommonTouchUiEditRootPanel : UiPanelBase
	{
		// Token: 0x06045714 RID: 284436 RVA: 0x01228419 File Offset: 0x01226619
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture))
			};
		}

		// Token: 0x06045715 RID: 284437 RVA: 0x01228452 File Offset: 0x01226652
		[NullableContext(2)]
		public UUIItem GetItemAttachRoot()
		{
			return base.GetItem(0);
		}

		// Token: 0x06045716 RID: 284438 RVA: 0x0122845C File Offset: 0x0122665C
		[NullableContext(1)]
		public void SetBackgroundTexture(string texturePath)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture == null || string.IsNullOrEmpty(texturePath))
			{
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				return;
			}
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			base.SetTextureByPath(texturePath, texture, null, null);
		}

		// Token: 0x0200CC74 RID: 52340
		private static class EComponent
		{
			// Token: 0x0403EAC1 RID: 256705
			public const int ItemAttachRoot = 0;

			// Token: 0x0403EAC2 RID: 256706
			public const int TexBg = 1;
		}
	}
}
