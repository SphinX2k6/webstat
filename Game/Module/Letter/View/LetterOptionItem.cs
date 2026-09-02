using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Letter.View
{
	// Token: 0x02005A22 RID: 23074
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LetterOptionItem : GridProxyAbstract<ITalkOption>
	{
		// Token: 0x0603A6A5 RID: 239269 RVA: 0x00ECF9E8 File Offset: 0x00ECDBE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A6A6 RID: 239270 RVA: 0x00ECFA90 File Offset: 0x00ECDC90
		public override void Refresh(ITalkOption data, bool isSelected, int gridIndex)
		{
			this.CurData = data;
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, true, false);
			}
			UUIText text = base.GetText(0);
			if (text != null && !string.IsNullOrEmpty(data.TidTalkOption))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TidTalkOption, Array.Empty<object>());
			}
		}

		// Token: 0x0603A6A7 RID: 239271 RVA: 0x00ECFAE8 File Offset: 0x00ECDCE8
		public void SetOnClick(Action<ITalkOption> callback)
		{
			this.OnClickCallback = callback;
		}

		// Token: 0x0603A6A8 RID: 239272 RVA: 0x00ECFAF1 File Offset: 0x00ECDCF1
		private void OnClickToggle(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked || this.CurData == null)
			{
				return;
			}
			Action<ITalkOption> onClickCallback = this.OnClickCallback;
			if (onClickCallback == null)
			{
				return;
			}
			onClickCallback(this.CurData);
		}

		// Token: 0x0402115A RID: 135514
		[Nullable(2)]
		private ITalkOption CurData;

		// Token: 0x0402115B RID: 135515
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ITalkOption> OnClickCallback;

		// Token: 0x0200BA06 RID: 47622
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04039777 RID: 235383
			public const int TxtOption = 0;

			// Token: 0x04039778 RID: 235384
			public const int TogOption = 1;
		}
	}
}
