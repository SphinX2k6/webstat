using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x0200661F RID: 26143
	internal class ClassComponent : UiPanelBase
	{
		// Token: 0x06041530 RID: 267568 RVA: 0x010C1388 File Offset: 0x010BF588
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041531 RID: 267569 RVA: 0x010C13F4 File Offset: 0x010BF5F4
		public void RefreshItem(int classId)
		{
			PinballClassConfig? pinballClassConfigById = ConfigBase<PinballConfig>.Instance.GetPinballClassConfigById(classId);
			if (pinballClassConfigById == null)
			{
				return;
			}
			base.SetTextureByPath(pinballClassConfigById.Value.Icon, base.GetTexture(1), null, null);
			base.GetItem(0).SetColor(FColor.FromHex(pinballClassConfigById.Value.BgColor));
		}

		// Token: 0x0200C64C RID: 50764
		private enum EClassComponent
		{
			// Token: 0x0403D0A3 RID: 250019
			BgItem,
			// Token: 0x0403D0A4 RID: 250020
			Texture
		}
	}
}
