using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE0 RID: 20448
	public class SheriffMainAnalysisClueItem : UiPanelBase
	{
		// Token: 0x06034BA5 RID: 215973 RVA: 0x00D39D54 File Offset: 0x00D37F54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034BA6 RID: 215974 RVA: 0x00D39E44 File Offset: 0x00D38044
		protected override void OnStart()
		{
			base.GetExtendToggle(0).SetActive(false, false);
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
			base.GetButton(4).RootUIComp.Get().SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x06034BA7 RID: 215975 RVA: 0x00D39EA4 File Offset: 0x00D380A4
		public void Refresh(int? clueId)
		{
			base.SetUiActive(clueId != null);
			if (clueId == null)
			{
				return;
			}
			SheriffClue value = ConfigBase<SheriffConfig>.Instance.GetClueConfigById(clueId.Value).Value;
			base.GetText(1).ShowTextNew(value.Name);
			base.SetTextureByPath(value.Icon, base.GetTexture(2), null, null);
		}

		// Token: 0x0200AFBB RID: 44987
		private static class EDefine
		{
			// Token: 0x04036873 RID: 223347
			public const int Tog = 0;

			// Token: 0x04036874 RID: 223348
			public const int TxtName = 1;

			// Token: 0x04036875 RID: 223349
			public const int TxtIcon = 2;

			// Token: 0x04036876 RID: 223350
			public const int PanelLock = 3;

			// Token: 0x04036877 RID: 223351
			public const int BtnCommon = 4;

			// Token: 0x04036878 RID: 223352
			public const int PanelHint = 5;
		}
	}
}
