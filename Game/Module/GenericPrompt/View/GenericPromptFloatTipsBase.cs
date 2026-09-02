using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CBA RID: 23738
	[NullableContext(2)]
	[Nullable(0)]
	public class GenericPromptFloatTipsBase : UiTickViewBase
	{
		// Token: 0x0603BE3B RID: 245307 RVA: 0x00F2D9EB File Offset: 0x00F2BBEB
		[NullableContext(1)]
		public GenericPromptFloatTipsBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE3C RID: 245308 RVA: 0x00F2D9F4 File Offset: 0x00F2BBF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BE3D RID: 245309 RVA: 0x00F2DA5D File Offset: 0x00F2BC5D
		protected override void OnBeforeCreate()
		{
			this.Data = (this.OpenParam as IPromptParamHub);
			this.TypeConfig = ConfigBase<GenericPromptConfig>.Instance.GetPromptTypeInfo(this.Data.TypeId);
		}

		// Token: 0x0603BE3E RID: 245310 RVA: 0x00F2DA8C File Offset: 0x00F2BC8C
		protected override void OnStart()
		{
			IReadOnlyList<object> mainText = this.Data.MainTextParams ?? Array.Empty<object>();
			this.SetMainText(mainText);
			IReadOnlyList<object> extraText = this.Data.ExtraTextParams ?? Array.Empty<object>();
			this.SetExtraText(extraText);
			this.SetTickDuration();
			this.SetVerticalOffset();
		}

		// Token: 0x0603BE3F RID: 245311 RVA: 0x00F2DAE0 File Offset: 0x00F2BCE0
		protected virtual void SetMainText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			UUIText text = base.GetText(0);
			if (this.Data.MainTextObj == null && this.Data.PromptId == null && param.Count > 0 && !string.IsNullOrEmpty(param[0] as string))
			{
				string text2 = param[0] as string;
				if (!string.IsNullOrEmpty(text2))
				{
					text.SetText(text2, true);
					text.SetUIActive(true);
					return;
				}
				text.SetUIActive(false);
				return;
			}
			else
			{
				if (this.Data.MainTextObj != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.Data.MainTextObj.TextKey, param);
					text.SetUIActive(true);
					return;
				}
				if (!StringUtils.IsBlank(this.TypeConfig.Value.GeneralText))
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.TypeConfig.Value.GeneralText, param);
					text.SetUIActive(true);
					return;
				}
				text.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603BE40 RID: 245312 RVA: 0x00F2DBDC File Offset: 0x00F2BDDC
		protected virtual void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			UUIText text = base.GetText(1);
			if (this.Data.ExtraTextObj == null && this.Data.PromptId == null && param.Count > 0 && !string.IsNullOrEmpty(param[0] as string))
			{
				string newText = param[0] as string;
				text.SetText(newText, true);
				text.SetUIActive(true);
				return;
			}
			if (this.Data.ExtraTextObj != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.Data.ExtraTextObj.TextKey, param);
				text.SetUIActive(true);
				return;
			}
			if (!StringUtils.IsBlank(this.TypeConfig.Value.GeneralExtraText))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.TypeConfig.Value.GeneralExtraText, param);
				text.SetUIActive(true);
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0603BE41 RID: 245313 RVA: 0x00F2DCC8 File Offset: 0x00F2BEC8
		private void SetTickDuration()
		{
			float? duration = this.Data.Duration;
			float num = 0f;
			if (duration.GetValueOrDefault() > num & duration != null)
			{
				this.TickDuration = (double)this.Data.Duration.Value;
				return;
			}
			if (this.Data.PromptId != null)
			{
				int? promptId = this.Data.PromptId;
				int num2 = 0;
				if (!(promptId.GetValueOrDefault() == num2 & promptId != null))
				{
					GenericPrompt? promptInfo = ConfigBase<GenericPromptConfig>.Instance.GetPromptInfo(this.Data.PromptId.GetValueOrDefault());
					this.TickDuration = (double)((promptInfo != null) ? promptInfo.GetValueOrDefault().Duration : 0);
				}
			}
			if (this.TickDuration == 0.0)
			{
				this.TickDuration = (double)((this.TypeConfig != null) ? this.TypeConfig.GetValueOrDefault().Duration : 0);
			}
			if (this.TickDuration == 0.0)
			{
				this.TickTime = -1.0;
			}
		}

		// Token: 0x0603BE42 RID: 245314 RVA: 0x00F2DDE8 File Offset: 0x00F2BFE8
		private void SetVerticalOffset()
		{
			if (this.Data.TypeId == 0)
			{
				return;
			}
			GenericPromptTypes? promptTypeInfo = ConfigBase<GenericPromptConfig>.Instance.GetPromptTypeInfo(this.Data.TypeId);
			if (promptTypeInfo.Value.OffsetY == 0f)
			{
				return;
			}
			this.RootItem.SetAnchorOffsetY(promptTypeInfo.Value.OffsetY);
		}

		// Token: 0x0603BE43 RID: 245315 RVA: 0x00F2DE4C File Offset: 0x00F2C04C
		protected override void OnTick(float delta)
		{
			if (this.ClosePromise != null)
			{
				this.TickTime = -1.0;
				return;
			}
			if (this.TickTime < 0.0)
			{
				return;
			}
			this.TickTime += (double)delta;
			if (this.TickTime > this.TickDuration * 1000.0)
			{
				base.CloseMe(delegate(bool success)
				{
					if (success)
					{
						Action closeCallback = this.Data.CloseCallback;
						if (closeCallback == null)
						{
							return;
						}
						closeCallback();
					}
				});
			}
		}

		// Token: 0x1700983F RID: 38975
		// (get) Token: 0x0603BE44 RID: 245316 RVA: 0x00F2DEBC File Offset: 0x00F2C0BC
		protected UUIText MainText
		{
			get
			{
				return base.GetText(0);
			}
		}

		// Token: 0x17009840 RID: 38976
		// (get) Token: 0x0603BE45 RID: 245317 RVA: 0x00F2DEC5 File Offset: 0x00F2C0C5
		protected UUIText ExtraText
		{
			get
			{
				return base.GetText(1);
			}
		}

		// Token: 0x04021AB2 RID: 137906
		protected double TickDuration;

		// Token: 0x04021AB3 RID: 137907
		protected double TickTime;

		// Token: 0x04021AB4 RID: 137908
		protected IPromptParamHub Data;

		// Token: 0x04021AB5 RID: 137909
		protected GenericPromptTypes? TypeConfig;

		// Token: 0x0200BD44 RID: 48452
		[NullableContext(0)]
		private class EGenericPromptFloatTipsBase
		{
			// Token: 0x0403A520 RID: 238880
			public const int MainTextItem = 0;

			// Token: 0x0403A521 RID: 238881
			public const int ExtraTextItem = 1;
		}
	}
}
