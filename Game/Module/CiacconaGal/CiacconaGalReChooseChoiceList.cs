using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC4 RID: 24260
	public class CiacconaGalReChooseChoiceList : UiPanelBase
	{
		// Token: 0x0603CF95 RID: 249749 RVA: 0x00F7C0FC File Offset: 0x00F7A2FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CF96 RID: 249750 RVA: 0x00F7C165 File Offset: 0x00F7A365
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<CiacconaGalReChooseChoiceItem, ICiacconaGalReChooseChoiceParam>(base.GetVerticalLayout(0), new Func<CiacconaGalReChooseChoiceItem>(this.GetChoiceItem), null, false, true);
		}

		// Token: 0x0603CF97 RID: 249751 RVA: 0x00F7C188 File Offset: 0x00F7A388
		[NullableContext(1)]
		public void Refresh(Action onRestart, Action onReturn)
		{
			this.Layout.RefreshByData(new <>z__ReadOnlyArray<ICiacconaGalReChooseChoiceParam>(new ICiacconaGalReChooseChoiceParam[]
			{
				new CiacconaGalReChooseChoiceParam
				{
					Text = "Xkjsx_Option_Reselection",
					TogState = EToggleState.ETT_UnChecked,
					IconResId = "T_PlotReasoningIcon03",
					OnClick = onRestart
				},
				new CiacconaGalReChooseChoiceParam
				{
					Text = "Xkjsx_Option_Cancel",
					TogState = EToggleState.ETT_UnChecked,
					IconResId = "T_PlotReasoningIcon05",
					OnClick = onReturn
				}
			}), null, false);
		}

		// Token: 0x0603CF98 RID: 249752 RVA: 0x00F7C205 File Offset: 0x00F7A405
		[NullableContext(1)]
		private CiacconaGalReChooseChoiceItem GetChoiceItem()
		{
			return new CiacconaGalReChooseChoiceItem();
		}

		// Token: 0x0402238C RID: 140172
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CiacconaGalReChooseChoiceItem, ICiacconaGalReChooseChoiceParam> Layout;

		// Token: 0x0200BEB9 RID: 48825
		public class EChoiceListComponentDefine
		{
			// Token: 0x0403AB4F RID: 240463
			public const int LayoutList = 0;

			// Token: 0x0403AB50 RID: 240464
			public const int ItemChoice = 1;
		}
	}
}
