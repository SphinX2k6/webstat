using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B3 RID: 20915
	public class RogueSelectResultBaseView : UiViewBase
	{
		// Token: 0x06035C52 RID: 220242 RVA: 0x00D85FA0 File Offset: 0x00D841A0
		[NullableContext(1)]
		public RogueSelectResultBaseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035C53 RID: 220243 RVA: 0x00D85FAC File Offset: 0x00D841AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.CloseBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.TabBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035C54 RID: 220244 RVA: 0x00D860DC File Offset: 0x00D842DC
		protected override void OnStart()
		{
			EToggleState state = (ModelBase<RoguelikeModel>.Instance.GetDescModel() == EDescModel.SIMPLE) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, true, false, false);
		}

		// Token: 0x06035C55 RID: 220245 RVA: 0x00D86110 File Offset: 0x00D84310
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeDataUpdate, new Action(this.OnDescModelChange));
		}

		// Token: 0x06035C56 RID: 220246 RVA: 0x00D8612F File Offset: 0x00D8432F
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeDataUpdate, new Action(this.OnDescModelChange));
		}

		// Token: 0x06035C57 RID: 220247 RVA: 0x00D8614E File Offset: 0x00D8434E
		protected virtual void OnDescModelChange()
		{
			this.Refresh();
		}

		// Token: 0x06035C58 RID: 220248 RVA: 0x00D86156 File Offset: 0x00D84356
		protected virtual void Refresh()
		{
		}

		// Token: 0x06035C59 RID: 220249 RVA: 0x00D86158 File Offset: 0x00D84358
		protected virtual void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06035C5A RID: 220250 RVA: 0x00D86161 File Offset: 0x00D84361
		protected virtual void CloseBtn()
		{
			this.OnCloseBtnClick();
		}

		// Token: 0x06035C5B RID: 220251 RVA: 0x00D86169 File Offset: 0x00D84369
		protected virtual void TabBtn(EToggleState state)
		{
			ModelBase<RoguelikeModel>.Instance.UpdateDescModel(state == EToggleState.ETT_Checked);
		}
	}
}
