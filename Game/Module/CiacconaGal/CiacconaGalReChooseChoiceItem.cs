using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC3 RID: 24259
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaGalReChooseChoiceItem : GridProxyAbstract<ICiacconaGalReChooseChoiceParam>
	{
		// Token: 0x0603CF8A RID: 249738 RVA: 0x00F7BEB0 File Offset: 0x00F7A0B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggleTextureTransition));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CF8B RID: 249739 RVA: 0x00F7BF77 File Offset: 0x00F7A177
		protected override void OnBeforeDestroy()
		{
			this.RemoveProtectionTimer();
		}

		// Token: 0x0603CF8C RID: 249740 RVA: 0x00F7BF80 File Offset: 0x00F7A180
		public override void Refresh(ICiacconaGalReChooseChoiceParam data, bool isSelected, int gridIndex)
		{
			this.AddProtectionTimer();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Text, Array.Empty<object>());
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(data.TogState, false, false, false);
			}
			this.OnClick = data.OnClick;
			this.UpdateIcon(data.IconResId);
		}

		// Token: 0x0603CF8D RID: 249741 RVA: 0x00F7BFE4 File Offset: 0x00F7A1E4
		public override void Clear()
		{
			this.RemoveProtectionTimer();
		}

		// Token: 0x0603CF8E RID: 249742 RVA: 0x00F7BFEC File Offset: 0x00F7A1EC
		public void SetInteractive(bool isInteractive)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetSelfInteractive(isInteractive);
		}

		// Token: 0x0603CF8F RID: 249743 RVA: 0x00F7C000 File Offset: 0x00F7A200
		private void AddProtectionTimer()
		{
			this.CanClick = false;
			float interval = CiacconaGalUtils.GetAvgChoiceProtectingTime() * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.ProtectionTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.CanClick = true;
			}, interval, null, null, true, 1f);
		}

		// Token: 0x0603CF90 RID: 249744 RVA: 0x00F7C04B File Offset: 0x00F7A24B
		private void RemoveProtectionTimer()
		{
			if (this.ProtectionTimerHandle != null && TimerSystem.Instance.Has(this.ProtectionTimerHandle))
			{
				TimerSystem.Instance.Remove(this.ProtectionTimerHandle);
				this.ProtectionTimerHandle = null;
			}
		}

		// Token: 0x0603CF91 RID: 249745 RVA: 0x00F7C080 File Offset: 0x00F7A280
		private UniTask UpdateIcon(string resourceName)
		{
			CiacconaGalReChooseChoiceItem.<UpdateIcon>d__11 <UpdateIcon>d__;
			<UpdateIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateIcon>d__.<>4__this = this;
			<UpdateIcon>d__.resourceName = resourceName;
			<UpdateIcon>d__.<>1__state = -1;
			<UpdateIcon>d__.<>t__builder.Start<CiacconaGalReChooseChoiceItem.<UpdateIcon>d__11>(ref <UpdateIcon>d__);
			return <UpdateIcon>d__.<>t__builder.Task;
		}

		// Token: 0x0603CF92 RID: 249746 RVA: 0x00F7C0CB File Offset: 0x00F7A2CB
		private void OnClickInternal(EToggleState toggleState)
		{
			if (this.OnClick != null && this.CanClick)
			{
				this.OnClick();
			}
		}

		// Token: 0x04022389 RID: 140169
		private Action OnClick;

		// Token: 0x0402238A RID: 140170
		private bool CanClick;

		// Token: 0x0402238B RID: 140171
		private TimerHandle ProtectionTimerHandle;

		// Token: 0x0200BEB7 RID: 48823
		[NullableContext(0)]
		public class EChoiceItemComponentDefine
		{
			// Token: 0x0403AB47 RID: 240455
			public const int TogSelf = 0;

			// Token: 0x0403AB48 RID: 240456
			public const int Text = 1;

			// Token: 0x0403AB49 RID: 240457
			public const int TextureIconLock = 2;
		}
	}
}
