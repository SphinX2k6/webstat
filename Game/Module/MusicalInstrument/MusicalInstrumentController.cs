using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056D5 RID: 22229
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MusicalInstrumentController : ControllerBase<MusicalInstrumentController>
	{
		// Token: 0x0603894C RID: 231756 RVA: 0x00E55BD1 File Offset: 0x00E53DD1
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<ZitherPlayNoteNotify>(ENotifyMessageId.ZitherPlayNoteNotify, new Action<ZitherPlayNoteNotify, Net.CallbackStatus>(this.OnZitherPlayNoteNotify));
			return true;
		}

		// Token: 0x0603894D RID: 231757 RVA: 0x00E55BF0 File Offset: 0x00E53DF0
		private void OnZitherPlayNoteNotify(ZitherPlayNoteNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (string.IsNullOrEmpty(notify.Note))
			{
				return;
			}
			long creatureDataId = Singleton<MathUtils>.Instance.LongToNumber(notify.EntityId);
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
			AActor aactor;
			if (entity == null)
			{
				aactor = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				if (entity2 == null)
				{
					aactor = null;
				}
				else
				{
					BaseActorComponent component = entity2.GetComponent<BaseActorComponent>();
					aactor = ((component != null) ? component.Owner : null);
				}
			}
			AActor aactor2 = aactor;
			if (aactor2 == null)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent(notify.Note, aactor2, new PostEventArgs?(new PostEventArgs
			{
				StopWhenOwnerDestroyed = new bool?(true)
			}));
		}

		// Token: 0x0603894E RID: 231758 RVA: 0x00E55C7D File Offset: 0x00E53E7D
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ZitherPlayNoteNotify);
			this.SubControllerMap.Clear();
			this.IsEntering = false;
			this.IsExiting = false;
			return true;
		}

		// Token: 0x0603894F RID: 231759 RVA: 0x00E55CAC File Offset: 0x00E53EAC
		public UniTask Enter(MusicalInstrumentEnterParam param)
		{
			MusicalInstrumentController.<Enter>d__6 <Enter>d__;
			<Enter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Enter>d__.<>4__this = this;
			<Enter>d__.param = param;
			<Enter>d__.<>1__state = -1;
			<Enter>d__.<>t__builder.Start<MusicalInstrumentController.<Enter>d__6>(ref <Enter>d__);
			return <Enter>d__.<>t__builder.Task;
		}

		// Token: 0x06038950 RID: 231760 RVA: 0x00E55CF8 File Offset: 0x00E53EF8
		[NullableContext(0)]
		public UniTask<bool> Exit([Nullable(1)] MusicalInstrumentExitParam param)
		{
			MusicalInstrumentController.<Exit>d__7 <Exit>d__;
			<Exit>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Exit>d__.<>4__this = this;
			<Exit>d__.param = param;
			<Exit>d__.<>1__state = -1;
			<Exit>d__.<>t__builder.Start<MusicalInstrumentController.<Exit>d__7>(ref <Exit>d__);
			return <Exit>d__.<>t__builder.Task;
		}

		// Token: 0x06038951 RID: 231761 RVA: 0x00E55D43 File Offset: 0x00E53F43
		[NullableContext(2)]
		public MusicalInstrumentSubController GetSubController(EInstrumentType type)
		{
			return this.SubControllerMap.GetValueOrDefault(type);
		}

		// Token: 0x06038952 RID: 231762 RVA: 0x00E55D54 File Offset: 0x00E53F54
		public void SyncServerRequest(string @event)
		{
			ZitherPlayNotePush zitherPlayNotePush = ZitherPlayNotePush.Create();
			zitherPlayNotePush.Note = @event;
			Singleton<Net>.Instance.Send(EPushMessageId.ZitherPlayNotePush, zitherPlayNotePush);
		}

		// Token: 0x06038953 RID: 231763 RVA: 0x00E55D7E File Offset: 0x00E53F7E
		private void MuteOtherAudio()
		{
			Singleton<AudioSystem>.Instance.SetState("instrument_game_mode", "mute_other_bgm", true);
		}

		// Token: 0x06038954 RID: 231764 RVA: 0x00E55D95 File Offset: 0x00E53F95
		private void ResumeOtherAudio()
		{
			Singleton<AudioSystem>.Instance.SetState("instrument_game_mode", "none", true);
		}

		// Token: 0x0402047C RID: 132220
		private readonly Dictionary<EInstrumentType, MusicalInstrumentSubController> SubControllerMap = new Dictionary<EInstrumentType, MusicalInstrumentSubController>();

		// Token: 0x0402047D RID: 132221
		private bool IsEntering;

		// Token: 0x0402047E RID: 132222
		private bool IsExiting;
	}
}
