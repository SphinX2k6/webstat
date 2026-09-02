using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A04 RID: 23044
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginDebugPlayerNameView : UiViewBase
	{
		// Token: 0x0603A5E4 RID: 239076 RVA: 0x00ECCC0E File Offset: 0x00ECAE0E
		public LoginDebugPlayerNameView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A5E5 RID: 239077 RVA: 0x00ECCC18 File Offset: 0x00ECAE18
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITextInputComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCancelBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A5E6 RID: 239078 RVA: 0x00ECCD44 File Offset: 0x00ECAF44
		protected override void OnBeforeCreate()
		{
			this.OnSuccessCallBack = (Action)this.OpenParam;
		}

		// Token: 0x0603A5E7 RID: 239079 RVA: 0x00ECCD57 File Offset: 0x00ECAF57
		private void OnTextChangeCallBack(string inString)
		{
			UUIButtonComponent button = base.GetButton(3);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(inString.Length > 0);
		}

		// Token: 0x0603A5E8 RID: 239080 RVA: 0x00ECCD74 File Offset: 0x00ECAF74
		protected override void OnStart()
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			base.GetInputText(0).OnTextChange.Bind(new Action<string>(this.OnTextChangeCallBack));
			UUIButtonComponent button = base.GetButton(3);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(false);
		}

		// Token: 0x0603A5E9 RID: 239081 RVA: 0x00ECCDC3 File Offset: 0x00ECAFC3
		private void OnClickCancelBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603A5EA RID: 239082 RVA: 0x00ECCDCC File Offset: 0x00ECAFCC
		private void OnClickConfirmBtn()
		{
			string text = base.GetInputText(0).GetText();
			if (StringUtils.GetStringRealCount(text) > 12)
			{
				this.ShowNameTooLongView();
				return;
			}
			ModelBase<LoginModel>.Instance.SetPlayerName(text);
			base.CloseMe(null);
			Action onSuccessCallBack = this.OnSuccessCallBack;
			if (onSuccessCallBack == null)
			{
				return;
			}
			onSuccessCallBack();
		}

		// Token: 0x0603A5EB RID: 239083 RVA: 0x00ECCE1C File Offset: 0x00ECB01C
		private void ShowNameTooLongView()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ChangeName);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603A5EC RID: 239084 RVA: 0x00ECCE3D File Offset: 0x00ECB03D
		protected override void OnBeforeDestroy()
		{
			this.OnSuccessCallBack = null;
		}

		// Token: 0x040210DD RID: 135389
		private Action OnSuccessCallBack;
	}
}
