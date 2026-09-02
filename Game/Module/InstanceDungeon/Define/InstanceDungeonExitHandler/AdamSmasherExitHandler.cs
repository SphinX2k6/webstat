using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C30 RID: 23600
	public class AdamSmasherExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA5E RID: 244318 RVA: 0x00F1C893 File Offset: 0x00F1AA93
		public override bool Checker()
		{
			return ControllerBase<AdamSmasherController>.Instance.IsInAdamSmasherDungeon();
		}

		// Token: 0x0603BA5F RID: 244319 RVA: 0x00F1C8A0 File Offset: 0x00F1AAA0
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CyberPunkExitChallengeViewConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
			};
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(6090, 0, null).Forget<bool>();
			};
			confirmBoxDataNew.FunctionMap[0] = delegate()
			{
				InstanceDungeonExitHandlerData data2 = data;
				if (data2 == null)
				{
					return;
				}
				Action cancelBack = data2.CancelBack;
				if (cancelBack == null)
				{
					return;
				}
				cancelBack();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}
}
