using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite
{
	// Token: 0x02006EB2 RID: 28338
	public class FindSunSpiritView : UiViewBase
	{
		// Token: 0x06044B34 RID: 281396 RVA: 0x011DC4B8 File Offset: 0x011DA6B8
		[NullableContext(1)]
		public FindSunSpiritView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044B35 RID: 281397 RVA: 0x011DC4C4 File Offset: 0x011DA6C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnTriggerButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnResetButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnLeftButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnRightButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044B36 RID: 281398 RVA: 0x011DC658 File Offset: 0x011DA858
		protected override UniTask OnBeforeStartAsync()
		{
			FindSunSpiritView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FindSunSpiritView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044B37 RID: 281399 RVA: 0x011DC69B File Offset: 0x011DA89B
		protected override void OnBeforeShow()
		{
			this.RefreshTriggerTimes();
		}

		// Token: 0x06044B38 RID: 281400 RVA: 0x011DC6A3 File Offset: 0x011DA8A3
		protected override void OnBeforeDestroy()
		{
			if (ModelBase<FindSunSpiritModel>.Instance.Config != null)
			{
				ControllerBase<FindSunSpiritController>.Instance.FinishFindSunSpirit();
			}
		}

		// Token: 0x06044B39 RID: 281401 RVA: 0x011DC6BB File Offset: 0x011DA8BB
		private void OnTriggerButtonClick()
		{
			this.TriggerModifierAsync();
		}

		// Token: 0x06044B3A RID: 281402 RVA: 0x011DC6C4 File Offset: 0x011DA8C4
		private UniTask TriggerModifierAsync()
		{
			FindSunSpiritView.<TriggerModifierAsync>d__9 <TriggerModifierAsync>d__;
			<TriggerModifierAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TriggerModifierAsync>d__.<>4__this = this;
			<TriggerModifierAsync>d__.<>1__state = -1;
			<TriggerModifierAsync>d__.<>t__builder.Start<FindSunSpiritView.<TriggerModifierAsync>d__9>(ref <TriggerModifierAsync>d__);
			return <TriggerModifierAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044B3B RID: 281403 RVA: 0x011DC707 File Offset: 0x011DA907
		private void OnResetButtonClick()
		{
			if (this.DisableInput)
			{
				return;
			}
			this.ResetFindSunSpirit();
		}

		// Token: 0x06044B3C RID: 281404 RVA: 0x011DC718 File Offset: 0x011DA918
		private void OnCloseButtonClick()
		{
			if (this.DisableInput)
			{
				return;
			}
			ControllerBase<FindSunSpiritController>.Instance.FinishFindSunSpirit();
			base.CloseMe(null);
		}

		// Token: 0x06044B3D RID: 281405 RVA: 0x011DC734 File Offset: 0x011DA934
		private void OnLeftButtonClick()
		{
			if (this.DisableInput)
			{
				return;
			}
			ControllerBase<FindSunSpiritController>.Instance.SelectModifier(false);
		}

		// Token: 0x06044B3E RID: 281406 RVA: 0x011DC74A File Offset: 0x011DA94A
		private void OnRightButtonClick()
		{
			if (this.DisableInput)
			{
				return;
			}
			ControllerBase<FindSunSpiritController>.Instance.SelectModifier(true);
		}

		// Token: 0x06044B3F RID: 281407 RVA: 0x011DC760 File Offset: 0x011DA960
		private void ResetFindSunSpirit()
		{
			ControllerBase<FindSunSpiritController>.Instance.ResetFindSunSpirit(delegate
			{
				this.DisableInput = false;
				this.RefreshTriggerTimes();
			});
		}

		// Token: 0x06044B40 RID: 281408 RVA: 0x011DC778 File Offset: 0x011DA978
		private void RefreshTriggerTimes()
		{
			FindSunSpiritModel instance = ModelBase<FindSunSpiritModel>.Instance;
			FindSunSpiritLevelConfig levelConfig = instance.LevelConfig;
			FindSunSpiritLevelPlay levelPlay = instance.LevelPlay;
			int num = levelConfig.MaxStep - levelPlay.CurrentStep;
			UUIText text = base.GetText(5);
			if (text == null)
			{
				return;
			}
			text.SetText(num.ToString(), true);
		}

		// Token: 0x04026405 RID: 156677
		private bool DisableInput;

		// Token: 0x04026406 RID: 156678
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0200CB85 RID: 52101
		private class EComponentType
		{
			// Token: 0x0403E72D RID: 255789
			public const int CaptionItem = 0;

			// Token: 0x0403E72E RID: 255790
			public const int LeftBtn = 1;

			// Token: 0x0403E72F RID: 255791
			public const int RightBtn = 2;

			// Token: 0x0403E730 RID: 255792
			public const int TriggerBtn = 3;

			// Token: 0x0403E731 RID: 255793
			public const int ResetBtn = 4;

			// Token: 0x0403E732 RID: 255794
			public const int TimesText = 5;
		}
	}
}
