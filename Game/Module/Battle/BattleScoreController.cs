using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F3F RID: 24383
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class BattleScoreController : ControllerBase<BattleScoreController>
	{
		// Token: 0x0603D42E RID: 250926 RVA: 0x00F94A3C File Offset: 0x00F92C3C
		protected override bool OnInit()
		{
			Net instance = Singleton<Net>.Instance;
			ENotifyMessageId id = ENotifyMessageId.BattleScoreNotify;
			Action<BattleScoreNotify, Net.CallbackStatus> callback;
			if ((callback = BattleScoreController.<>O.<0>__HandleBattleScoreNotify) == null)
			{
				callback = (BattleScoreController.<>O.<0>__HandleBattleScoreNotify = new Action<BattleScoreNotify, Net.CallbackStatus>(BattleScoreController.HandleBattleScoreNotify));
			}
			instance.Register<BattleScoreNotify>(id, callback);
			Net instance2 = Singleton<Net>.Instance;
			ENotifyMessageId id2 = ENotifyMessageId.BattleScoreEnableNotify;
			Action<BattleScoreEnableNotify, Net.CallbackStatus> callback2;
			if ((callback2 = BattleScoreController.<>O.<1>__HandleBattleScoreEnableNotify) == null)
			{
				callback2 = (BattleScoreController.<>O.<1>__HandleBattleScoreEnableNotify = new Action<BattleScoreEnableNotify, Net.CallbackStatus>(BattleScoreController.HandleBattleScoreEnableNotify));
			}
			instance2.Register<BattleScoreEnableNotify>(id2, callback2);
			return true;
		}

		// Token: 0x0603D42F RID: 250927 RVA: 0x00F94AA0 File Offset: 0x00F92CA0
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BattleScoreNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BattleScoreEnableNotify);
			return true;
		}

		// Token: 0x0603D430 RID: 250928 RVA: 0x00F94AC3 File Offset: 0x00F92CC3
		private static void HandleBattleScoreNotify(BattleScoreNotify notify, Net.CallbackStatus callbackStatus)
		{
			ModelBase<BattleScoreModel>.Instance.HandleBattleScoreNotify(notify);
		}

		// Token: 0x0603D431 RID: 250929 RVA: 0x00F94AD0 File Offset: 0x00F92CD0
		private static void HandleBattleScoreEnableNotify(BattleScoreEnableNotify notify, Net.CallbackStatus callbackStatus)
		{
			ModelBase<BattleScoreModel>.Instance.HandleBattleScoreEnableNotify(notify);
		}

		// Token: 0x0200BF68 RID: 49000
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403AEA7 RID: 241319
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<BattleScoreNotify, Net.CallbackStatus> <0>__HandleBattleScoreNotify;

			// Token: 0x0403AEA8 RID: 241320
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<BattleScoreEnableNotify, Net.CallbackStatus> <1>__HandleBattleScoreEnableNotify;
		}
	}
}
