using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F42 RID: 24386
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class SkillCdController : ControllerBase<SkillCdController>
	{
		// Token: 0x0603D441 RID: 250945 RVA: 0x00F94CA4 File Offset: 0x00F92EA4
		protected override bool OnInit()
		{
			Net instance = Singleton<Net>.Instance;
			ENotifyMessageId id = ENotifyMessageId.PlayerSkillInfoPbNotify;
			Action<PlayerSkillInfoPbNotify, Net.CallbackStatus> callback;
			if ((callback = SkillCdController.<>O.<0>__HandlePlayerSkillInfoPbNotify) == null)
			{
				callback = (SkillCdController.<>O.<0>__HandlePlayerSkillInfoPbNotify = new Action<PlayerSkillInfoPbNotify, Net.CallbackStatus>(SkillCdController.HandlePlayerSkillInfoPbNotify));
			}
			instance.Register<PlayerSkillInfoPbNotify>(id, callback);
			Net instance2 = Singleton<Net>.Instance;
			ENotifyMessageId id2 = ENotifyMessageId.PassiveSkillNotify;
			Action<PassiveSkillNotify, Net.CallbackStatus> callback2;
			if ((callback2 = SkillCdController.<>O.<1>__HandlePassiveSkillNotify) == null)
			{
				callback2 = (SkillCdController.<>O.<1>__HandlePassiveSkillNotify = new Action<PassiveSkillNotify, Net.CallbackStatus>(SkillCdController.HandlePassiveSkillNotify));
			}
			instance2.Register<PassiveSkillNotify>(id2, callback2);
			return true;
		}

		// Token: 0x0603D442 RID: 250946 RVA: 0x00F94D08 File Offset: 0x00F92F08
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerSkillInfoPbNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PassiveSkillNotify);
			return true;
		}

		// Token: 0x0603D443 RID: 250947 RVA: 0x00F94D2B File Offset: 0x00F92F2B
		private static void HandlePlayerSkillInfoPbNotify(PlayerSkillInfoPbNotify notify, Net.CallbackStatus callbackStatus)
		{
			ModelBase<SkillCdModel>.Instance.HandlePlayerSkillInfoPbNotify(notify);
		}

		// Token: 0x0603D444 RID: 250948 RVA: 0x00F94D38 File Offset: 0x00F92F38
		private static void HandlePassiveSkillNotify(PassiveSkillNotify notify, Net.CallbackStatus callbackStatus)
		{
			ModelBase<SkillCdModel>.Instance.HandlePassiveSkillNotify(notify);
		}

		// Token: 0x0603D445 RID: 250949 RVA: 0x00F94D45 File Offset: 0x00F92F45
		protected override void OnTick(float delta)
		{
		}

		// Token: 0x0603D446 RID: 250950 RVA: 0x00F94D48 File Offset: 0x00F92F48
		public void Pause(ESkillCdPauseReason reason, bool isPause)
		{
			bool flag = this.IsPause();
			this._pauseState = VisibleStateUtil.SetVisible(this._pauseState, !isPause, (int)reason);
			bool flag2 = this.IsPause();
			if (flag != flag2)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.CharSkillCdPauseStateChanged, flag2);
			}
		}

		// Token: 0x0603D447 RID: 250951 RVA: 0x00F94D89 File Offset: 0x00F92F89
		public bool IsPause()
		{
			return this._pauseState != 0;
		}

		// Token: 0x040225D1 RID: 140753
		private int _pauseState;

		// Token: 0x0200BF69 RID: 49001
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403AEA9 RID: 241321
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<PlayerSkillInfoPbNotify, Net.CallbackStatus> <0>__HandlePlayerSkillInfoPbNotify;

			// Token: 0x0403AEAA RID: 241322
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<PassiveSkillNotify, Net.CallbackStatus> <1>__HandlePassiveSkillNotify;
		}
	}
}
