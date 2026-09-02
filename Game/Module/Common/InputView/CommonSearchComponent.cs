using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.InputView
{
	// Token: 0x02005E70 RID: 24176
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonSearchComponent : UiPanelBase
	{
		// Token: 0x0603CCD9 RID: 249049 RVA: 0x00F7032B File Offset: 0x00F6E52B
		public CommonSearchComponent(UUIItem uiItem, Action<string> SearchFunction, Action ClearFunction)
		{
			this.SearchFunction = SearchFunction;
			this.ClearFunction = ClearFunction;
			this.IsDeleteState = false;
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CCDA RID: 249050 RVA: 0x00F70358 File Offset: 0x00F6E558
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITextInputComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<bool>(this.ActiveInput));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.SearchClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.ClearClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CCDB RID: 249051 RVA: 0x00F70465 File Offset: 0x00F6E665
		private void ActiveInput(bool active)
		{
			if (active)
			{
				this.InputText.ActivateInputText();
			}
		}

		// Token: 0x0603CCDC RID: 249052 RVA: 0x00F70478 File Offset: 0x00F6E678
		private void SearchClick()
		{
			string text = this.InputText.GetText();
			Action<string> searchFunction = this.SearchFunction;
			if (searchFunction != null)
			{
				searchFunction(text);
			}
			this.ChangeSearchButtonState(false);
			this.IsDeleteState = true;
		}

		// Token: 0x0603CCDD RID: 249053 RVA: 0x00F704B1 File Offset: 0x00F6E6B1
		private void ClearClick()
		{
			this.ResetSearch(true);
		}

		// Token: 0x0603CCDE RID: 249054 RVA: 0x00F704BC File Offset: 0x00F6E6BC
		protected override void OnStart()
		{
			this.SearchButton = base.GetButton(1);
			this.ClearButton = base.GetButton(2);
			this.InputText = base.GetInputText(0);
			this.InputText.OnTextChange.Bind(new Action<string>(this.RefreshButton));
			this.InputText.OnTextSubmit.Bind(delegate(string _)
			{
				this.SearchClick();
			});
			this.ResetSearch(false);
			this.ChangeSearchButtonState(true);
			this.SearchButton.SetSelfInteractive(false);
		}

		// Token: 0x0603CCDF RID: 249055 RVA: 0x00F70544 File Offset: 0x00F6E744
		private void RefreshButton(string searchText)
		{
			if (!StringUtils.IsEmpty(searchText))
			{
				if (this.IsDeleteState)
				{
					this.ChangeSearchButtonState(true);
				}
				this.SearchButton.SetSelfInteractive(true);
				return;
			}
			this.ChangeSearchButtonState(true);
			this.SearchButton.SetSelfInteractive(false);
			Action clearFunction = this.ClearFunction;
			if (clearFunction == null)
			{
				return;
			}
			clearFunction();
		}

		// Token: 0x0603CCE0 RID: 249056 RVA: 0x00F70598 File Offset: 0x00F6E798
		protected override void OnBeforeDestroy()
		{
			this.InputText = null;
			this.SearchButton = null;
			this.ClearButton = null;
		}

		// Token: 0x0603CCE1 RID: 249057 RVA: 0x00F705B0 File Offset: 0x00F6E7B0
		private void ChangeSearchButtonState(bool isShowSearch)
		{
			this.SearchButton.RootUIComp.Get().SetUIActive(isShowSearch);
			this.ClearButton.RootUIComp.Get().SetUIActive(!isShowSearch);
			this.IsDeleteState = !isShowSearch;
		}

		// Token: 0x0603CCE2 RID: 249058 RVA: 0x00F705FC File Offset: 0x00F6E7FC
		public void ResetSearch(bool isFire)
		{
			this.InputText.SetText("", isFire);
		}

		// Token: 0x04022264 RID: 139876
		[Nullable(2)]
		private UUITextInputComponent InputText;

		// Token: 0x04022265 RID: 139877
		[Nullable(2)]
		private UUIButtonComponent SearchButton;

		// Token: 0x04022266 RID: 139878
		[Nullable(2)]
		private UUIButtonComponent ClearButton;

		// Token: 0x04022267 RID: 139879
		private bool IsDeleteState;

		// Token: 0x04022268 RID: 139880
		private Action<string> SearchFunction;

		// Token: 0x04022269 RID: 139881
		private Action ClearFunction;

		// Token: 0x0200BE80 RID: 48768
		[NullableContext(0)]
		private enum ECompDefine
		{
			// Token: 0x0403AA84 RID: 240260
			InputTextComp,
			// Token: 0x0403AA85 RID: 240261
			SearchButton,
			// Token: 0x0403AA86 RID: 240262
			ClearButton
		}
	}
}
