using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.SubView
{
	// Token: 0x0200694D RID: 26957
	[NullableContext(1)]
	[Nullable(0)]
	public class SkipMainQuestWindowView : UiViewBase
	{
		// Token: 0x06042E69 RID: 274025 RVA: 0x0112C0DF File Offset: 0x0112A2DF
		public SkipMainQuestWindowView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042E6A RID: 274026 RVA: 0x0112C0E8 File Offset: 0x0112A2E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042E6B RID: 274027 RVA: 0x0112C1B4 File Offset: 0x0112A3B4
		protected override void OnStart()
		{
			ISkipMainQuestWindowParam skipMainQuestWindowParam = this.OpenParam as ISkipMainQuestWindowParam;
			ActivityDirectTrainModel instance = ModelBase<ActivityDirectTrainModel>.Instance;
			this.SkipCallBack = ((skipMainQuestWindowParam != null) ? skipMainQuestWindowParam.SkipCallBack : null);
			this.ActivityId = ((skipMainQuestWindowParam != null) ? skipMainQuestWindowParam.ActivityId : 0);
			this.CancelBtn = new ButtonItem(base.GetButton(2).RootUIComp.Get());
			this.CancelBtn.SetFunction(new Action<int>(this.OnCancelBtnClick));
			this.CancelBtn.SetLocalTextNew("ConfirmBox_1_ButtonText_0", Array.Empty<object>());
			this.SkipBtn = new ButtonItem(base.GetButton(3).RootUIComp.Get());
			this.SkipBtn.SetFunction(new Action<int>(this.OnSkipBtnClick));
			this.SetDescriptionTxtByTextId(instance.GetSkipTipTitleTextId(this.ActivityId), Array.Empty<string>());
			this.SetPlotTxtByTextId(instance.GetSkipTipContentTextId(this.ActivityId), Array.Empty<string>());
		}

		// Token: 0x06042E6C RID: 274028 RVA: 0x0112C2A6 File Offset: 0x0112A4A6
		private void OnCancelBtnClick(int _)
		{
			base.CloseMe(null);
		}

		// Token: 0x06042E6D RID: 274029 RVA: 0x0112C2AF File Offset: 0x0112A4AF
		private void OnSkipBtnClick(int _)
		{
			base.CloseMe(null);
			TSkipMainQuestWindowSkipCallBack skipCallBack = this.SkipCallBack;
			if (skipCallBack == null)
			{
				return;
			}
			skipCallBack();
		}

		// Token: 0x06042E6E RID: 274030 RVA: 0x0112C2C8 File Offset: 0x0112A4C8
		private void SetPlotTxtByTextId(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
		}

		// Token: 0x06042E6F RID: 274031 RVA: 0x0112C2DD File Offset: 0x0112A4DD
		private void SetDescriptionTxtByTextId(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textId, args);
		}

		// Token: 0x04025458 RID: 152664
		[Nullable(2)]
		private ButtonItem CancelBtn;

		// Token: 0x04025459 RID: 152665
		[Nullable(2)]
		private ButtonItem SkipBtn;

		// Token: 0x0402545A RID: 152666
		[Nullable(2)]
		private TSkipMainQuestWindowSkipCallBack SkipCallBack;

		// Token: 0x0402545B RID: 152667
		private int ActivityId;

		// Token: 0x0200C8EB RID: 51435
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403DCE4 RID: 253156
			TxtPlot,
			// Token: 0x0403DCE5 RID: 253157
			TxtContent,
			// Token: 0x0403DCE6 RID: 253158
			BtnConfirmA,
			// Token: 0x0403DCE7 RID: 253159
			BtnConfirmA2,
			// Token: 0x0403DCE8 RID: 253160
			TxtDescription
		}
	}
}
