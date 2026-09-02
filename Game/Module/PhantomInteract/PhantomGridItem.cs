using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomInteract
{
	// Token: 0x02005464 RID: 21604
	internal class PhantomGridItem : UiPanelBase
	{
		// Token: 0x06037063 RID: 225379 RVA: 0x00DF77C2 File Offset: 0x00DF59C2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUITexture))
			};
		}

		// Token: 0x06037064 RID: 225380 RVA: 0x00DF77FC File Offset: 0x00DF59FC
		[NullableContext(2)]
		public void SetIcon(string path)
		{
			UUITexture texture = base.GetTexture(1);
			if (path == null)
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
			base.SetTextureByPath(path, texture, null, null);
		}
	}
}
