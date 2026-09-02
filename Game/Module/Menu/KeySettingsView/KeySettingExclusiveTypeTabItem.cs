using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C3 RID: 22467
	[NullableContext(1)]
	[Nullable(0)]
	public class KeySettingExclusiveTypeTabItem : CommonTabItemBase
	{
		// Token: 0x060391B2 RID: 233906 RVA: 0x00E79184 File Offset: 0x00E77384
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick))
			};
		}

		// Token: 0x060391B3 RID: 233907 RVA: 0x00E79201 File Offset: 0x00E77401
		protected override void OnStart()
		{
			base.OnStart();
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060391B4 RID: 233908 RVA: 0x00E7921C File Offset: 0x00E7741C
		protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
		{
			CommonTabData data2 = data.Data;
			base.UpdateTabIcon(((data2 != null) ? data2.GetIcon() : null) ?? "");
			UUIText text = base.GetText(2);
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText uiText = text;
			CommonTabData data3 = data.Data;
			string text2;
			if (data3 == null)
			{
				text2 = null;
			}
			else
			{
				CommonTabTitleData titleData = data3.GetTitleData();
				text2 = ((titleData != null) ? titleData.TextId : null);
			}
			instance.SetLocalTextNew(uiText, text2 ?? "", Array.Empty<object>());
		}

		// Token: 0x060391B5 RID: 233909 RVA: 0x00E79289 File Offset: 0x00E77489
		protected override UUIExtendToggle GetTabToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x060391B6 RID: 233910 RVA: 0x00E79294 File Offset: 0x00E77494
		protected override void OnUpdateTabIcon(string iconPath)
		{
			base.SetTextureByPath(iconPath, base.GetTexture(1), null, null);
		}

		// Token: 0x060391B7 RID: 233911 RVA: 0x00E792BC File Offset: 0x00E774BC
		protected override void OnSetToggleState(EToggleState state, bool bFire)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state, bFire, false, false);
			}
		}

		// Token: 0x060391B8 RID: 233912 RVA: 0x00E792DF File Offset: 0x00E774DF
		private void ToggleClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectedCallBack(base.GridIndex);
			}
		}

		// Token: 0x0200B842 RID: 47170
		[NullableContext(0)]
		public class EComponent
		{
			// Token: 0x04038FE4 RID: 233444
			public const int Toggle = 0;

			// Token: 0x04038FE5 RID: 233445
			public const int TexIcon = 1;

			// Token: 0x04038FE6 RID: 233446
			public const int TxtName = 2;
		}
	}
}
