using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065CD RID: 26061
	public class PinballRoleBdItem : UiPanelBase
	{
		// Token: 0x060411DB RID: 266715 RVA: 0x010B51C0 File Offset: 0x010B33C0
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

		// Token: 0x060411DC RID: 266716 RVA: 0x010B5229 File Offset: 0x010B3429
		public void RefreshByBdId(int bdId)
		{
			this.BdId = bdId;
			this.Refresh();
		}

		// Token: 0x060411DD RID: 266717 RVA: 0x010B5238 File Offset: 0x010B3438
		private void Refresh()
		{
			PinballBdConfig? pinballRoleBdConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleBdConfigById(this.BdId);
			if (pinballRoleBdConfigById == null)
			{
				return;
			}
			base.GetSprite(0).SetColor(FColor.FromHex(pinballRoleBdConfigById.Value.BgColor));
			base.SetTextureByPath(pinballRoleBdConfigById.Value.Icon, base.GetTexture(1), null, null);
		}

		// Token: 0x0402479B RID: 149403
		private int BdId;

		// Token: 0x0200C5D1 RID: 50641
		private enum EComponent
		{
			// Token: 0x0403CE40 RID: 249408
			BgSprite,
			// Token: 0x0403CE41 RID: 249409
			IconTexture
		}
	}
}
