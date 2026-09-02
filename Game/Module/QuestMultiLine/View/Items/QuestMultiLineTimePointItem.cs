using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x0200533C RID: 21308
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class QuestMultiLineTimePointItem : GridProxyAbstract<QuestMultiLineTimePointData>
	{
		// Token: 0x060365BE RID: 222654 RVA: 0x00DB47E0 File Offset: 0x00DB29E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggleSpriteTransition)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIExtendToggle))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnClick)),
				new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnToggleClick))
			};
		}

		// Token: 0x060365BF RID: 222655 RVA: 0x00DB48E4 File Offset: 0x00DB2AE4
		public override void Refresh(QuestMultiLineTimePointData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GetSprite(0).SetUIActive(true);
			this.RefreshPointSprite(data);
			if (this.Data.IsUnLock)
			{
				base.GetText(6).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.Name, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), data.NameBottom, Array.Empty<object>());
			}
			else
			{
				base.GetText(6).SetUIActive(false);
				base.GetText(3).SetText("???", true);
			}
			this.RefreshRedDot();
			this.RefreshSelected(isSelected);
		}

		// Token: 0x060365C0 RID: 222656 RVA: 0x00DB4990 File Offset: 0x00DB2B90
		private UniTask RefreshPointSprite(QuestMultiLineTimePointData data)
		{
			QuestMultiLineTimePointItem.<RefreshPointSprite>d__4 <RefreshPointSprite>d__;
			<RefreshPointSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshPointSprite>d__.<>4__this = this;
			<RefreshPointSprite>d__.data = data;
			<RefreshPointSprite>d__.<>1__state = -1;
			<RefreshPointSprite>d__.<>t__builder.Start<QuestMultiLineTimePointItem.<RefreshPointSprite>d__4>(ref <RefreshPointSprite>d__);
			return <RefreshPointSprite>d__.<>t__builder.Task;
		}

		// Token: 0x060365C1 RID: 222657 RVA: 0x00DB49DC File Offset: 0x00DB2BDC
		private void RefreshRedDot()
		{
			QuestMultiLineTimePointData data = this.Data;
			bool uiactive = data != null && data.IsUnLock && ModelBase<QuestMultiLineModel>.Instance.GetTimePointRedDot(this.Data.Id);
			base.GetItem(4).SetUIActive(uiactive);
		}

		// Token: 0x060365C2 RID: 222658 RVA: 0x00DB4A23 File Offset: 0x00DB2C23
		public override void OnSelected(bool fireEvent)
		{
			ModelBase<QuestMultiLineModel>.Instance.ClearTimePointRedDot(this.Data.Id);
			this.RefreshRedDot();
			this.RefreshSelected(true);
		}

		// Token: 0x060365C3 RID: 222659 RVA: 0x00DB4A47 File Offset: 0x00DB2C47
		public override void OnDeselected(bool fireEvent)
		{
			this.RefreshSelected(false);
		}

		// Token: 0x060365C4 RID: 222660 RVA: 0x00DB4A50 File Offset: 0x00DB2C50
		public void RefreshSelected(bool selected)
		{
			UUIText text = base.GetText(3);
			UUIItem uuiitem = text;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(selected, fcolor);
			UUIText text2 = base.GetText(6);
			UUIItem uuiitem2 = text2;
			fcolor = new FColor?(text2.changeColor);
			uuiitem2.SetChangeColor(selected, fcolor);
			UUIExtendToggle extendToggle = base.GetExtendToggle(7);
			if (extendToggle != null)
			{
				EToggleState state = selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
				extendToggle.SetToggleStateForce(state, false, false, false);
			}
		}

		// Token: 0x060365C5 RID: 222661 RVA: 0x00DB4AB6 File Offset: 0x00DB2CB6
		public void SetFunction(Action<QuestMultiLineTimePointData> buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x060365C6 RID: 222662 RVA: 0x00DB4ABF File Offset: 0x00DB2CBF
		private void OnClick()
		{
			Action<QuestMultiLineTimePointData> buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction(this.Data);
		}

		// Token: 0x060365C7 RID: 222663 RVA: 0x00DB4AD7 File Offset: 0x00DB2CD7
		private void OnToggleClick(EToggleState state)
		{
			this.OnClick();
		}

		// Token: 0x0401F433 RID: 128051
		[Nullable(2)]
		private QuestMultiLineTimePointData Data;

		// Token: 0x0401F434 RID: 128052
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<QuestMultiLineTimePointData> ButtonFunction;
	}
}
