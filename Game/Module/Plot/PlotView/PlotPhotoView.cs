using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053C0 RID: 21440
	public class PlotPhotoView : UiViewBase
	{
		// Token: 0x06036AC2 RID: 223938 RVA: 0x00DDA5CE File Offset: 0x00DD87CE
		[NullableContext(1)]
		public PlotPhotoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036AC3 RID: 223939 RVA: 0x00DDA5D8 File Offset: 0x00DD87D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCloseButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06036AC4 RID: 223940 RVA: 0x00DDA766 File Offset: 0x00DD8966
		private void OnClickCloseButton()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PlotPhotoView, null);
		}

		// Token: 0x06036AC5 RID: 223941 RVA: 0x00DDA778 File Offset: 0x00DD8978
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x06036AC6 RID: 223942 RVA: 0x00DDA77A File Offset: 0x00DD897A
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x06036AC7 RID: 223943 RVA: 0x00DDA77C File Offset: 0x00DD897C
		protected override void OnStart()
		{
			this.Callback = (this.OpenParam as Action);
		}

		// Token: 0x06036AC8 RID: 223944 RVA: 0x00DDA790 File Offset: 0x00DD8990
		protected override void OnAfterShow()
		{
			base.GetSprite(0).SetUIActive(false);
			base.GetSprite(1).SetUIActive(false);
			base.GetText(4).SetUIActive(false);
			base.GetText(6).SetUIActive(false);
			base.GetText(7).SetUIActive(false);
			base.GetText(8).SetUIActive(false);
			base.GetTexture(3).SetUIActive(false);
			base.GetText(5).SetText("test/残鸣初奏", true);
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath((playerGender == EPlayerGender.Male) ? "PlotPhoto_Male" : "PlotPhoto_Female");
			Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(resourcePath, delegate([Nullable(2)] UTexture loadObject, string _)
			{
				if (loadObject == null || !loadObject.IsValid())
				{
					return;
				}
				base.GetTexture(3).SetTexture(loadObject);
				base.GetTexture(3).SetUIActive(true);
			}, 100, "js_undefined");
		}

		// Token: 0x06036AC9 RID: 223945 RVA: 0x00DDA84F File Offset: 0x00DD8A4F
		protected override void OnBeforeDestroy()
		{
			if (this.Callback != null)
			{
				this.Callback();
				this.Callback = null;
			}
		}

		// Token: 0x0401F7DC RID: 128988
		[Nullable(2)]
		private Action Callback;

		// Token: 0x0200B32D RID: 45869
		private static class EPhotoFullComponents
		{
			// Token: 0x04037818 RID: 227352
			public const int LastButton = 0;

			// Token: 0x04037819 RID: 227353
			public const int NextButton = 1;

			// Token: 0x0403781A RID: 227354
			public const int CloseButton = 2;

			// Token: 0x0403781B RID: 227355
			public const int Texture = 3;

			// Token: 0x0403781C RID: 227356
			public const int UITextDark = 4;

			// Token: 0x0403781D RID: 227357
			public const int UITextName = 5;

			// Token: 0x0403781E RID: 227358
			public const int UITextDate = 6;

			// Token: 0x0403781F RID: 227359
			public const int UITextNumber = 7;

			// Token: 0x04037820 RID: 227360
			public const int UITextDescription = 8;
		}
	}
}
