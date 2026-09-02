using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006440 RID: 25664
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeRoleSelectTitlePanel : UiPanelBase
	{
		// Token: 0x060406CD RID: 263885 RVA: 0x01084164 File Offset: 0x01082364
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060406CE RID: 263886 RVA: 0x01084254 File Offset: 0x01082454
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeRoleSelectTitlePanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeRoleSelectTitlePanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060406CF RID: 263887 RVA: 0x01084297 File Offset: 0x01082497
		protected override void OnBeforeDestroy()
		{
			this.LightTagPanel = null;
			this.DarkTagPanel = null;
		}

		// Token: 0x060406D0 RID: 263888 RVA: 0x010842A8 File Offset: 0x010824A8
		public void RefreshElement(bool isLight, RoverRogueRoleType? cfg)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(isLight);
			}
			UUISprite sprite2 = base.GetSprite(2);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(!isLight);
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				if (!string.IsNullOrEmpty((cfg != null) ? cfg.GetValueOrDefault().Element : null))
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, cfg.Value.Element, Array.Empty<object>());
				}
				else
				{
					text.SetText("", true);
				}
				if (cfg.Value.Id == 1)
				{
					text.useChangeColor = false;
				}
				else
				{
					text.useChangeColor = true;
				}
			}
			RoverlikeRoleEelmentTagPanel panel = isLight ? this.LightTagPanel : this.DarkTagPanel;
			RoverlikeRoleEelmentTagPanel panel2 = isLight ? this.DarkTagPanel : this.LightTagPanel;
			this.RefreshTagPanel(panel, cfg, 0);
			this.RefreshTagPanel(panel2, cfg, 1);
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(isLight);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!isLight);
		}

		// Token: 0x060406D1 RID: 263889 RVA: 0x010843B8 File Offset: 0x010825B8
		private void RefreshTagPanel(RoverlikeRoleEelmentTagPanel panel, RoverRogueRoleType? cfg, int tagIndex)
		{
			if (panel == null)
			{
				return;
			}
			if (cfg != null && cfg.Value.TagLength > tagIndex)
			{
				DicStringString? dicStringString = cfg.Value.Tag(tagIndex);
				panel.SetActive(true);
				panel.Refresh((dicStringString != null) ? dicStringString.GetValueOrDefault().Key : null, (dicStringString != null) ? dicStringString.GetValueOrDefault().Value : null);
				return;
			}
			panel.SetActive(false);
		}

		// Token: 0x04024138 RID: 147768
		private RoverlikeRoleEelmentTagPanel LightTagPanel;

		// Token: 0x04024139 RID: 147769
		private RoverlikeRoleEelmentTagPanel DarkTagPanel;

		// Token: 0x0200C4B5 RID: 50357
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C8B8 RID: 247992
			public const int TxtElementName = 0;

			// Token: 0x0403C8B9 RID: 247993
			public const int SprElementLight = 1;

			// Token: 0x0403C8BA RID: 247994
			public const int SprElementDark = 2;

			// Token: 0x0403C8BB RID: 247995
			public const int PnlTypeLight = 3;

			// Token: 0x0403C8BC RID: 247996
			public const int PnlTypeDark = 4;

			// Token: 0x0403C8BD RID: 247997
			public const int TxtType = 5;
		}
	}
}
