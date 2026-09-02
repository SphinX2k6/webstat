using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.BasicGraphicSetting
{
	// Token: 0x020057BA RID: 22458
	[NullableContext(1)]
	[Nullable(0)]
	public class BasicGraphicSettingView : UiViewBase
	{
		// Token: 0x06039171 RID: 233841 RVA: 0x00E7818D File Offset: 0x00E7638D
		public BasicGraphicSettingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039172 RID: 233842 RVA: 0x00E781A4 File Offset: 0x00E763A4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06039173 RID: 233843 RVA: 0x00E7826C File Offset: 0x00E7646C
		protected override UniTask OnBeforeStartAsync()
		{
			BasicGraphicSettingView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BasicGraphicSettingView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039174 RID: 233844 RVA: 0x00E782B0 File Offset: 0x00E764B0
		protected override void OnStart()
		{
			this.LayoutSlideBars = new GenericLayout<BasicGraphicSettingSliderItem, BasicGraphicSettingSliderData>(base.GetVerticalLayout(6), new Func<BasicGraphicSettingSliderItem>(this.CreateSliderBar), null, false, true);
			this.SliderBarDataList = BasicGraphicSettingData.GetBasicGraphicSettingSliderDataList();
			this.LayoutSlideBars.RefreshByData(this.SliderBarDataList, null, false);
			this.SettingData = ModelBase<MenuModel>.Instance.GetMenuDataByFunctionId(20203);
			this.CaptionItem.SetTitleByTextIdAndArgNew(this.SettingData.FunctionName, Array.Empty<object>());
			this.CaptionItem.SetHelpBtnActive(false);
			this.LayoutSlideBars.SetActive(false);
		}

		// Token: 0x06039175 RID: 233845 RVA: 0x00E78344 File Offset: 0x00E76544
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06039176 RID: 233846 RVA: 0x00E78362 File Offset: 0x00E76562
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06039177 RID: 233847 RVA: 0x00E78380 File Offset: 0x00E76580
		protected override void OnBeforeDestroy()
		{
			if (this.HasConfirmed)
			{
				foreach (BasicGraphicSettingSliderData basicGraphicSettingSliderData in this.SliderBarDataList)
				{
					basicGraphicSettingSliderData.OnApplyValue();
				}
			}
		}

		// Token: 0x06039178 RID: 233848 RVA: 0x00E783D8 File Offset: 0x00E765D8
		private void PlayAnim(string name)
		{
			UUIInturnAnimController uiAnimController = this.LayoutSlideBars.GetUiAnimController();
			if (uiAnimController == null)
			{
				return;
			}
			uiAnimController.Play(name, -1, false);
		}

		// Token: 0x06039179 RID: 233849 RVA: 0x00E783F2 File Offset: 0x00E765F2
		private void OnActivitySequenceEmitEvent(string param)
		{
			this.LayoutSlideBars.SetActive(true);
			this.PlayAnim(param);
		}

		// Token: 0x0603917A RID: 233850 RVA: 0x00E78408 File Offset: 0x00E76608
		private void OnReset(int _)
		{
			foreach (BasicGraphicSettingSliderData basicGraphicSettingSliderData in this.SliderBarDataList)
			{
				basicGraphicSettingSliderData.OnChangeValue(basicGraphicSettingSliderData.DefaultCurValue);
			}
			this.LayoutSlideBars.RefreshByData(this.SliderBarDataList, null, false);
		}

		// Token: 0x0603917B RID: 233851 RVA: 0x00E78478 File Offset: 0x00E76678
		private void OnConfirm(int _)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ImageColorSetting", Array.Empty<object>());
			this.HasConfirmed = true;
			base.CloseMe(null);
		}

		// Token: 0x0603917C RID: 233852 RVA: 0x00E7849C File Offset: 0x00E7669C
		private BasicGraphicSettingSliderItem CreateSliderBar()
		{
			return new BasicGraphicSettingSliderItem();
		}

		// Token: 0x040207FE RID: 133118
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<BasicGraphicSettingSliderItem, BasicGraphicSettingSliderData> LayoutSlideBars;

		// Token: 0x040207FF RID: 133119
		private List<BasicGraphicSettingSliderData> SliderBarDataList = new List<BasicGraphicSettingSliderData>();

		// Token: 0x04020800 RID: 133120
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04020801 RID: 133121
		[Nullable(2)]
		private ButtonItem ResetBtnItem;

		// Token: 0x04020802 RID: 133122
		[Nullable(2)]
		private ButtonItem ConfirmBtnItem;

		// Token: 0x04020803 RID: 133123
		private bool HasConfirmed;

		// Token: 0x04020804 RID: 133124
		[Nullable(2)]
		private MenuData SettingData;

		// Token: 0x0200B83A RID: 47162
		[NullableContext(0)]
		public class EComponentDefine
		{
			// Token: 0x04038FBC RID: 233404
			public const int TexLeft = 0;

			// Token: 0x04038FBD RID: 233405
			public const int TexMid = 1;

			// Token: 0x04038FBE RID: 233406
			public const int TexRight = 2;

			// Token: 0x04038FBF RID: 233407
			public const int ItemCaption = 3;

			// Token: 0x04038FC0 RID: 233408
			public const int BtnReset = 4;

			// Token: 0x04038FC1 RID: 233409
			public const int BtnConfirm = 5;

			// Token: 0x04038FC2 RID: 233410
			public const int VLayoutSlideBars = 6;

			// Token: 0x04038FC3 RID: 233411
			public const int SlideBar = 7;
		}
	}
}
