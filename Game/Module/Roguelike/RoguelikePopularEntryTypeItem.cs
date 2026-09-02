using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005158 RID: 20824
	public class RoguelikePopularEntryTypeItem : GridProxyAbstract<ERoguelikeEntryType>
	{
		// Token: 0x060359A1 RID: 219553 RVA: 0x00D76C58 File Offset: 0x00D74E58
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060359A2 RID: 219554 RVA: 0x00D76CE2 File Offset: 0x00D74EE2
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x060359A3 RID: 219555 RVA: 0x00D76CF4 File Offset: 0x00D74EF4
		public override void Refresh(ERoguelikeEntryType type, bool isSelected, int gridIndex)
		{
			RogueHotEntryType? rogueHotEntryTypeConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueHotEntryTypeConfig((int)type);
			UUITexture texture = base.GetTexture(1);
			base.SetTextureByPath(rogueHotEntryTypeConfig.Value.Icon, texture, null, null);
		}

		// Token: 0x0200B105 RID: 45317
		private class EComponent
		{
			// Token: 0x04036E94 RID: 224916
			public const int PanelIcon = 0;

			// Token: 0x04036E95 RID: 224917
			public const int TexIcon = 1;

			// Token: 0x04036E96 RID: 224918
			public const int PanelEmpty = 2;
		}
	}
}
