using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B6 RID: 26550
	public class ListItem : GridProxyAbstract<int>
	{
		// Token: 0x060423A7 RID: 271271 RVA: 0x010FD900 File Offset: 0x010FBB00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060423A8 RID: 271272 RVA: 0x010FD948 File Offset: 0x010FBB48
		protected override void OnStart()
		{
			this.Sprite = base.GetSprite(0);
		}

		// Token: 0x060423A9 RID: 271273 RVA: 0x010FD957 File Offset: 0x010FBB57
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.IsActive = (data == 1);
			this.Sprite.SetAlpha((float)data);
		}

		// Token: 0x060423AA RID: 271274 RVA: 0x010FD970 File Offset: 0x010FBB70
		[NullableContext(1)]
		public void SetSpriteByQuality(string gridColor)
		{
			if (this.IsActive)
			{
				this.Sprite.SetColor(FColor.FromHex(gridColor));
			}
		}

		// Token: 0x04024E37 RID: 151095
		protected bool IsActive;

		// Token: 0x04024E38 RID: 151096
		[Nullable(1)]
		private UUISprite Sprite;

		// Token: 0x0200C7E3 RID: 51171
		private class EListItem
		{
			// Token: 0x0403D868 RID: 252008
			public const int BgSprite = 0;
		}
	}
}
