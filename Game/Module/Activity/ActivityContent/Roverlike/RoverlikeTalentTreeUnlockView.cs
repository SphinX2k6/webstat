using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200646D RID: 25709
	public class RoverlikeTalentTreeUnlockView : UiViewBase
	{
		// Token: 0x060407DB RID: 264155 RVA: 0x01086F48 File Offset: 0x01085148
		[NullableContext(1)]
		public RoverlikeTalentTreeUnlockView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060407DC RID: 264156 RVA: 0x01086F54 File Offset: 0x01085154
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060407DD RID: 264157 RVA: 0x0108701C File Offset: 0x0108521C
		protected override void OnStart()
		{
			RoverlikeTalentUnlockViewParam roverlikeTalentUnlockViewParam = this.OpenParam as RoverlikeTalentUnlockViewParam;
			if (roverlikeTalentUnlockViewParam != null && !string.IsNullOrEmpty(roverlikeTalentUnlockViewParam.DescTextId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), roverlikeTalentUnlockViewParam.DescTextId, roverlikeTalentUnlockViewParam.DescParams.ToArray());
			}
		}

		// Token: 0x060407DE RID: 264158 RVA: 0x01087067 File Offset: 0x01085267
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200C4C9 RID: 50377
		private class EComponentDefine
		{
			// Token: 0x0403C947 RID: 248135
			public const int BtnClose = 0;

			// Token: 0x0403C948 RID: 248136
			public const int TxtInfo = 1;

			// Token: 0x0403C949 RID: 248137
			public const int TxtTips = 2;
		}
	}
}
