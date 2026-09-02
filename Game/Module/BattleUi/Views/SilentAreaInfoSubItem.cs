using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A4 RID: 24740
	[NullableContext(1)]
	[Nullable(0)]
	public class SilentAreaInfoSubItem : UiPanelBase
	{
		// Token: 0x0603E75A RID: 255834 RVA: 0x00FF6B38 File Offset: 0x00FF4D38
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

		// Token: 0x0603E75B RID: 255835 RVA: 0x00FF6BA1 File Offset: 0x00FF4DA1
		public void SetCurrentShowType(EInformationViewType type)
		{
			this.CurrentShowType = type;
		}

		// Token: 0x0603E75C RID: 255836 RVA: 0x00FF6BAC File Offset: 0x00FF4DAC
		public void Initialize(AActor actor, IInformationSubTitle config)
		{
			base.CreateByActorAsync(actor, null, false).ContinueWith(delegate()
			{
				this.UpdateItem(config);
			}).Forget();
		}

		// Token: 0x0603E75D RID: 255837 RVA: 0x00FF6BEC File Offset: 0x00FF4DEC
		public void UpdateItem(IInformationSubTitle config)
		{
			bool flag = this.UpdateTitleText(config.TidTitle);
			this.UpdateDescribeText(config.TidContent, flag ? 32 : 36);
		}

		// Token: 0x0603E75E RID: 255838 RVA: 0x00FF6C1C File Offset: 0x00FF4E1C
		private bool UpdateTitleText(string title)
		{
			UUIText text = base.GetText(0);
			string text2;
			if (this.CurrentShowType == EInformationViewType.LevelPlay)
			{
				text2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey(title);
			}
			else
			{
				text2 = ConfigMultiTextLang.GetLocalTextNew(title, null);
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				if (text != null)
				{
					UUIItem parentAsUIItem = text.GetParentAsUIItem();
					if (parentAsUIItem != null)
					{
						parentAsUIItem.SetUIActive(false);
					}
				}
				return false;
			}
			if (text != null)
			{
				text.SetText(text2, true);
			}
			if (text != null)
			{
				UUIItem parentAsUIItem2 = text.GetParentAsUIItem();
				if (parentAsUIItem2 != null)
				{
					parentAsUIItem2.SetUIActive(true);
				}
			}
			return true;
		}

		// Token: 0x0603E75F RID: 255839 RVA: 0x00FF6C90 File Offset: 0x00FF4E90
		private void UpdateDescribeText(string title, int fontSize)
		{
			UUIText text = base.GetText(1);
			string text2;
			if (this.CurrentShowType == EInformationViewType.LevelPlay)
			{
				text2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey(title);
			}
			else
			{
				text2 = ConfigMultiTextLang.GetLocalTextNew(title, null);
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
				return;
			}
			if (text != null)
			{
				text.SetText(text2, true);
			}
			if (text != null)
			{
				text.SetFontSize((float)fontSize);
			}
			if (text != null)
			{
				text.SetUIActive(true);
			}
		}

		// Token: 0x04023038 RID: 143416
		private EInformationViewType CurrentShowType;

		// Token: 0x0200C1B6 RID: 49590
		[NullableContext(0)]
		private enum EChildComponent
		{
			// Token: 0x0403BA47 RID: 244295
			Title,
			// Token: 0x0403BA48 RID: 244296
			Describe
		}
	}
}
