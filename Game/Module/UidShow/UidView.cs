using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UidShow
{
	// Token: 0x02004D87 RID: 19847
	public class UidView : UiViewBase
	{
		// Token: 0x0603363E RID: 210494 RVA: 0x00CDA9DF File Offset: 0x00CD8BDF
		[NullableContext(1)]
		public UidView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603363F RID: 210495 RVA: 0x00CDA9E8 File Offset: 0x00CD8BE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033640 RID: 210496 RVA: 0x00CDAA30 File Offset: 0x00CD8C30
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnPreparePhotoScreenShot, new Action<bool>(this.OnRefreshUidViewShowState));
		}

		// Token: 0x06033641 RID: 210497 RVA: 0x00CDAA4E File Offset: 0x00CD8C4E
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPreparePhotoScreenShot, new Action<bool>(this.OnRefreshUidViewShowState));
		}

		// Token: 0x06033642 RID: 210498 RVA: 0x00CDAA6C File Offset: 0x00CD8C6C
		protected override void OnStart()
		{
			string str = "";
			if (FeatureRestrictionTemplate.TemplateForPioneerClient.Check())
			{
				str = " " + ConfigBase<TextConfig>.Instance.GetTextById("BetaVersionTip");
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "FriendMyUid", new <>z__ReadOnlySingleElementList<object>(ModelBase<FunctionModel>.Instance.PlayerId.ToString() + str));
		}

		// Token: 0x06033643 RID: 210499 RVA: 0x00CDAAD8 File Offset: 0x00CD8CD8
		private void OnRefreshUidViewShowState(bool state)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(state);
			}
		}

		// Token: 0x0200AD64 RID: 44388
		private class EUidViewComponent
		{
			// Token: 0x04035DCB RID: 220619
			public const int UidText = 0;
		}
	}
}
