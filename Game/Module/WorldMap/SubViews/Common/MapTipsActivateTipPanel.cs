using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common
{
	// Token: 0x02004BC9 RID: 19401
	public class MapTipsActivateTipPanel : UiPanelBase
	{
		// Token: 0x06032A3B RID: 207419 RVA: 0x00CAF698 File Offset: 0x00CAD898
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
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHelpButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032A3C RID: 207420 RVA: 0x00CAF75F File Offset: 0x00CAD95F
		protected override void OnStart()
		{
			this.SetDistanceTips();
		}

		// Token: 0x06032A3D RID: 207421 RVA: 0x00CAF767 File Offset: 0x00CAD967
		private void OnClickHelpButton()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(119);
		}

		// Token: 0x06032A3E RID: 207422 RVA: 0x00CAF778 File Offset: 0x00CAD978
		[NullableContext(2)]
		public void SetHideTip(string hideReason)
		{
			if (hideReason != null)
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.SetText(hideReason, true);
				}
			}
			else
			{
				this.SetActivatedTip("PlayPointClearDesc_Text", null);
			}
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06032A3F RID: 207423 RVA: 0x00CAF7D4 File Offset: 0x00CAD9D4
		public void SetDistanceTips()
		{
			this.SetActivatedTip("QuickTravelOverDistance_Text", null);
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x06032A40 RID: 207424 RVA: 0x00CAF814 File Offset: 0x00CADA14
		[NullableContext(1)]
		public void SetActivatedTip(string textId, bool? showBtn = null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
			if (showBtn != null)
			{
				UUIButtonComponent button = base.GetButton(2);
				if (button == null)
				{
					return;
				}
				button.RootUIComp.Get().SetUIActive(showBtn.Value);
			}
		}

		// Token: 0x0401D806 RID: 120838
		private const int HELP_ID = 119;

		// Token: 0x0200ACB0 RID: 44208
		public static class EComponents
		{
			// Token: 0x04035A5F RID: 219743
			public const int SprLock = 0;

			// Token: 0x04035A60 RID: 219744
			public const int TxtActivated = 1;

			// Token: 0x04035A61 RID: 219745
			public const int BtnFunctionA = 2;
		}
	}
}
