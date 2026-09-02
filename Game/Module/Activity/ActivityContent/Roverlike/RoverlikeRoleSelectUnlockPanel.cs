using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006441 RID: 25665
	public class RoverlikeRoleSelectUnlockPanel : UiPanelBase
	{
		// Token: 0x060406D3 RID: 263891 RVA: 0x01084450 File Offset: 0x01082650
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickFunction));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060406D4 RID: 263892 RVA: 0x01084517 File Offset: 0x01082717
		[NullableContext(1)]
		public void SetFunctionCallback(Action callback)
		{
			this.FunctionCallback = callback;
		}

		// Token: 0x060406D5 RID: 263893 RVA: 0x01084520 File Offset: 0x01082720
		public void SetFunctionButtonActive(bool active)
		{
			UUIButtonComponent button = base.GetButton(2);
			AUIBaseActor auibaseActor = ((button != null) ? button.GetOwner() : null) as AUIBaseActor;
			if (auibaseActor == null)
			{
				return;
			}
			UUIItem uiitem = auibaseActor.GetUIItem();
			if (uiitem == null)
			{
				return;
			}
			uiitem.SetUIActive(active);
		}

		// Token: 0x060406D6 RID: 263894 RVA: 0x01084550 File Offset: 0x01082750
		[NullableContext(1)]
		public void RefreshUnlockDesc(string textId)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(textId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, Array.Empty<object>());
				return;
			}
			text.SetText("", true);
		}

		// Token: 0x060406D7 RID: 263895 RVA: 0x0108458F File Offset: 0x0108278F
		private void OnClickFunction()
		{
			Action functionCallback = this.FunctionCallback;
			if (functionCallback == null)
			{
				return;
			}
			functionCallback();
		}

		// Token: 0x0402413A RID: 147770
		[Nullable(2)]
		private Action FunctionCallback;

		// Token: 0x0200C4B7 RID: 50359
		private class EComponents
		{
			// Token: 0x0403C8C2 RID: 248002
			public const int SprLock = 0;

			// Token: 0x0403C8C3 RID: 248003
			public const int TxtActivated = 1;

			// Token: 0x0403C8C4 RID: 248004
			public const int BtnFunctionA = 2;
		}
	}
}
