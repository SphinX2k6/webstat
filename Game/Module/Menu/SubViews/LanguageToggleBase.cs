using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005781 RID: 22401
	[NullableContext(1)]
	[Nullable(0)]
	public class LanguageToggleBase : UiPanelBase
	{
		// Token: 0x06039007 RID: 233479 RVA: 0x00E71A63 File Offset: 0x00E6FC63
		public void Initialize(UUIItem toggleItem, int index, bool isToggled)
		{
			this.Index = index;
			this.PreToggled = isToggled;
			base.CreateThenShowByActor(toggleItem.GetOwner(), null);
		}

		// Token: 0x06039008 RID: 233480 RVA: 0x00E71A80 File Offset: 0x00E6FC80
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.DoSelected))
			};
		}

		// Token: 0x06039009 RID: 233481 RVA: 0x00E71AFD File Offset: 0x00E6FCFD
		protected override void OnStart()
		{
			if (this.PreToggled)
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
			this.MainText = base.GetText(1);
		}

		// Token: 0x0603900A RID: 233482 RVA: 0x00E71B25 File Offset: 0x00E6FD25
		protected override void OnBeforeDestroyImplement()
		{
			base.GetExtendToggle(0).CanExecuteChange.Unbind();
			this.ProgressBuilder.Clear();
		}

		// Token: 0x0603900B RID: 233483 RVA: 0x00E71B44 File Offset: 0x00E6FD44
		private void DoSelected(EToggleState state)
		{
			Action<LanguageToggleBase, EToggleState> selectedCallBack = this.SelectedCallBack;
			if (selectedCallBack != null)
			{
				selectedCallBack(this, state);
			}
			this.OnSelected();
		}

		// Token: 0x0603900C RID: 233484 RVA: 0x00E71B5F File Offset: 0x00E6FD5F
		public void SetSelectedCallBack(Action<LanguageToggleBase, EToggleState> callBack)
		{
			this.SelectedCallBack = callBack;
		}

		// Token: 0x0603900D RID: 233485 RVA: 0x00E71B68 File Offset: 0x00E6FD68
		public void SetMainText(string textId)
		{
			this.MainText.ShowTextNew(textId);
		}

		// Token: 0x0603900E RID: 233486 RVA: 0x00E71B76 File Offset: 0x00E6FD76
		public string GetMainText()
		{
			return this.MainText.text;
		}

		// Token: 0x0603900F RID: 233487 RVA: 0x00E71B83 File Offset: 0x00E6FD83
		public int GetIndex()
		{
			return this.Index;
		}

		// Token: 0x06039010 RID: 233488 RVA: 0x00E71B8B File Offset: 0x00E6FD8B
		public void UnSelect()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			this.OnUnSelected();
		}

		// Token: 0x06039011 RID: 233489 RVA: 0x00E71BA4 File Offset: 0x00E6FDA4
		protected virtual void OnSelected()
		{
		}

		// Token: 0x06039012 RID: 233490 RVA: 0x00E71BA6 File Offset: 0x00E6FDA6
		protected virtual void OnUnSelected()
		{
		}

		// Token: 0x04020738 RID: 132920
		protected readonly StringBuilder ProgressBuilder = new StringBuilder();

		// Token: 0x04020739 RID: 132921
		protected int Index;

		// Token: 0x0402073A RID: 132922
		protected bool PreToggled;

		// Token: 0x0402073B RID: 132923
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Action<LanguageToggleBase, EToggleState> SelectedCallBack;

		// Token: 0x0402073C RID: 132924
		[Nullable(2)]
		protected UUIText MainText;
	}
}
