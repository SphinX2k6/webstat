using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006018 RID: 24600
	public class GuestItem : BattleChildView
	{
		// Token: 0x0603DFD4 RID: 253908 RVA: 0x00FD1740 File Offset: 0x00FCF940
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DFD5 RID: 253909 RVA: 0x00FD1830 File Offset: 0x00FCFA30
		protected override void OnShowBattleChildView()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PlotShowTalk, new Action<ITalkItem, bool>(this.OnShowTalk));
			Singleton<EventSystem>.Instance.Add(EEventName.PlotEndShowTalk, new Action(this.OnShowTalkEnd));
			Singleton<EventSystem>.Instance.Add(EEventName.ShowGuestEffect, new Action<bool>(this.OnGuestEffect));
		}

		// Token: 0x0603DFD6 RID: 253910 RVA: 0x00FD1894 File Offset: 0x00FCFA94
		protected override void OnHideBattleChildView()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotShowTalk, new Action<ITalkItem, bool>(this.OnShowTalk));
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotEndShowTalk, new Action(this.OnShowTalkEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.ShowGuestEffect, new Action<bool>(this.OnGuestEffect));
		}

		// Token: 0x0603DFD7 RID: 253911 RVA: 0x00FD18F8 File Offset: 0x00FCFAF8
		[NullableContext(1)]
		private void OnShowTalk(ITalkItem talkItem, bool bShow)
		{
			if (!bShow)
			{
				return;
			}
			if (talkItem.WhoId != null)
			{
				HashSet<int> speakerSet = this.SpeakerSet;
				if (speakerSet != null && speakerSet.Contains(talkItem.WhoId.Value))
				{
					if (this.IsSpeaking)
					{
						return;
					}
					this.IsSpeaking = true;
					TArray<UActorComponent> tarray = base.GetItem(1).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
					for (int i = 0; i < tarray.Num(); i++)
					{
						((ULGUIPlayTweenComponent)tarray.Get(i)).Play();
					}
					return;
				}
			}
			this.OnShowTalkEnd();
		}

		// Token: 0x0603DFD8 RID: 253912 RVA: 0x00FD1990 File Offset: 0x00FCFB90
		private void OnShowTalkEnd()
		{
			if (!this.IsSpeaking)
			{
				return;
			}
			this.IsSpeaking = false;
			TArray<UActorComponent> tarray = base.GetItem(2).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			for (int i = 0; i < tarray.Num(); i++)
			{
				((ULGUIPlayTweenComponent)tarray.Get(i)).Play();
			}
		}

		// Token: 0x0603DFD9 RID: 253913 RVA: 0x00FD19EC File Offset: 0x00FCFBEC
		private void OnGuestEffect(bool bShow)
		{
			GuestItem.EChildType name = bShow ? GuestItem.EChildType.BuffInAnim : GuestItem.EChildType.BuffOutAnim;
			TArray<UActorComponent> tarray = base.GetItem((int)name).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			for (int i = 0; i < tarray.Num(); i++)
			{
				((ULGUIPlayTweenComponent)tarray.Get(i)).Play();
			}
		}

		// Token: 0x0603DFDA RID: 253914 RVA: 0x00FD1A40 File Offset: 0x00FCFC40
		protected override UniTask OnBeforeStartAsync()
		{
			GuestItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GuestItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DFDB RID: 253915 RVA: 0x00FD1A83 File Offset: 0x00FCFC83
		protected override void OnAfterShow()
		{
			if (ModelBase<BattleUiModel>.Instance.GuestEffect)
			{
				this.OnGuestEffect(true);
			}
		}

		// Token: 0x0603DFDC RID: 253916 RVA: 0x00FD1A98 File Offset: 0x00FCFC98
		public UniTask SetGuest(int id)
		{
			GuestItem.<SetGuest>d__11 <SetGuest>d__;
			<SetGuest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetGuest>d__.<>4__this = this;
			<SetGuest>d__.id = id;
			<SetGuest>d__.<>1__state = -1;
			<SetGuest>d__.<>t__builder.Start<GuestItem.<SetGuest>d__11>(ref <SetGuest>d__);
			return <SetGuest>d__.<>t__builder.Task;
		}

		// Token: 0x04022C36 RID: 142390
		[Nullable(2)]
		private HashSet<int> SpeakerSet;

		// Token: 0x04022C37 RID: 142391
		private bool IsSpeaking;

		// Token: 0x0200C0C0 RID: 49344
		private enum EChildType
		{
			// Token: 0x0403B57C RID: 243068
			HeadIcon,
			// Token: 0x0403B57D RID: 243069
			TalkInAnim,
			// Token: 0x0403B57E RID: 243070
			TalkOutAnim,
			// Token: 0x0403B57F RID: 243071
			BuffInAnim,
			// Token: 0x0403B580 RID: 243072
			BuffOutAnim,
			// Token: 0x0403B581 RID: 243073
			BuffNiagara
		}
	}
}
