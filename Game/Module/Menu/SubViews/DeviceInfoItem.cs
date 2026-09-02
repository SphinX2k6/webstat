using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200577B RID: 22395
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeviceInfoItem : GridProxyAbstract<DeviceInfoItemData>
	{
		// Token: 0x06038FE5 RID: 233445 RVA: 0x00E70FB0 File Offset: 0x00E6F1B0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06038FE6 RID: 233446 RVA: 0x00E7100A File Offset: 0x00E6F20A
		public override void Refresh(DeviceInfoItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.UpdateDisplay();
		}

		// Token: 0x06038FE7 RID: 233447 RVA: 0x00E7101C File Offset: 0x00E6F21C
		private void UpdateDisplay()
		{
			if (this.Data == null || string.IsNullOrEmpty(this.Data.Name) || this.Data.GetInfoFunction == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.Data.Name, Array.Empty<object>());
			ValueTuple<string, bool> valueTuple = this.Data.GetInfoFunction();
			string item = valueTuple.Item1;
			bool item2 = valueTuple.Item2;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(item, true);
			}
			if (!string.IsNullOrEmpty(this.Data.LowText))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.Data.LowText, Array.Empty<object>());
			}
			UUIText text2 = base.GetText(2);
			if (text2 != null)
			{
				text2.SetUIActive(item2);
			}
		}

		// Token: 0x0402071C RID: 132892
		[Nullable(2)]
		private DeviceInfoItemData Data;
	}
}
