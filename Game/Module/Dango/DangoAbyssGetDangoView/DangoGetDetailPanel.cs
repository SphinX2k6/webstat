using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango.DangoAbyssGetDangoView
{
	// Token: 0x02005DED RID: 24045
	internal class DangoGetDetailPanel : UiPanelBase
	{
		// Token: 0x0603C812 RID: 247826 RVA: 0x00F5D964 File Offset: 0x00F5BB64
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnConfirm))
			};
		}

		// Token: 0x0603C813 RID: 247827 RVA: 0x00F5DA39 File Offset: 0x00F5BC39
		public void OnClickBtnConfirm()
		{
			Action onClickCallback = this.OnClickCallback;
			if (onClickCallback == null)
			{
				return;
			}
			onClickCallback();
		}

		// Token: 0x0603C814 RID: 247828 RVA: 0x00F5DA4C File Offset: 0x00F5BC4C
		[NullableContext(1)]
		public void RefreshView(DangoAbyssDefine.IDangoUnlockData data)
		{
			base.GetText(1).SetText(data.DetailName, true);
			bool flag = data.DetailDialog != "";
			base.GetText(3).SetUIActive(flag);
			if (flag)
			{
				base.GetText(3).SetText(data.DetailDialog, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "AbyssDangoLV", new <>z__ReadOnlySingleElementList<object>(data.DangoLevel));
		}

		// Token: 0x04022050 RID: 139344
		[Nullable(2)]
		public Action OnClickCallback;
	}
}
